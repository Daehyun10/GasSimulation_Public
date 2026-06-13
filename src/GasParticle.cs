using UnityEngine;

/// <summary>
/// Controls one gas particle.
/// Chemistry link:
/// - Average molecular kinetic energy is proportional to absolute temperature T.
/// - A representative molecular speed therefore follows v proportional to sqrt(T).
/// - Below the critical temperature, intermolecular attraction is simplified as
///   probabilistic liquefaction after particle collisions.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class GasParticle : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GasManager manager;

    [Header("Motion")]
    [SerializeField] private float referenceTemperature = 300f;
    [SerializeField] private float baseSpeedAtReferenceTemperature = 6f;
    [SerializeField] private float gasVelocityCorrection = 4f;

    [Header("Liquefaction")]
    [SerializeField] private float liquidDrag = 3f;
    [SerializeField] private float liquidAngularDrag = 2f;
    [SerializeField] private float liquidSpeedMultiplier = 0.12f;
    [SerializeField] private Color gasColor = new Color(1f, 0.35f, 0.15f);
    [SerializeField] private Color liquidColor = Color.cyan;

    private Rigidbody rb;
    private Renderer cachedRenderer;
    private bool isLiquid;

    public bool IsLiquid => isLiquid;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cachedRenderer = GetComponent<Renderer>();

        rb.useGravity = false;
        rb.linearDamping = 0f;
        rb.angularDamping = 0f;
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

        if (cachedRenderer != null)
        {
            cachedRenderer.material.color = gasColor;
        }
    }

    public void Initialize(GasManager owner, float initialTemperature, Vector3 initialDirection)
    {
        manager = owner;
        isLiquid = false;

        rb.useGravity = false;
        rb.linearDamping = 0f;
        rb.angularDamping = 0f;

        if (cachedRenderer != null)
        {
            cachedRenderer.material.color = gasColor;
        }

        Vector3 direction = initialDirection.sqrMagnitude < 0.001f ? Random.onUnitSphere : initialDirection.normalized;
        rb.linearVelocity = direction * CalculateTargetSpeed(initialTemperature);
    }

    private void FixedUpdate()
    {
        if (manager == null || isLiquid)
        {
            return;
        }

        // v proportional to sqrt(T): if T becomes 4 times larger, speed becomes 2 times larger.
        float targetSpeed = CalculateTargetSpeed(manager.CurrentTemperature);
        Vector3 currentVelocity = rb.linearVelocity;

        if (currentVelocity.sqrMagnitude < 0.01f)
        {
            rb.linearVelocity = Random.onUnitSphere * targetSpeed;
            return;
        }

        Vector3 targetVelocity = currentVelocity.normalized * targetSpeed;
        rb.linearVelocity = Vector3.Lerp(currentVelocity, targetVelocity, gasVelocityCorrection * Time.fixedDeltaTime);
    }

    private float CalculateTargetSpeed(float temperature)
    {
        float safeTemperature = Mathf.Max(temperature, 1f);
        return baseSpeedAtReferenceTemperature * Mathf.Sqrt(safeTemperature / referenceTemperature);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (manager == null)
        {
            return;
        }

        if (!isLiquid && IsWallCollision(collision.collider))
        {
            // Collision impulse approximates momentum transferred to a wall.
            // GasManager divides this by time and surface area to estimate P_real.
            manager.RegisterWallImpulse(collision.impulse.magnitude);
        }

        if (!isLiquid && collision.collider.TryGetComponent(out GasParticle otherParticle) && !otherParticle.IsLiquid)
        {
            TryLiquefyAfterParticleCollision();
        }
    }

    private bool IsWallCollision(Collider other)
    {
        return other.CompareTag("Wall") || other.name.Contains("Wall");
    }

    private void TryLiquefyAfterParticleCollision()
    {
        if (manager.CurrentTemperature > manager.CriticalTemperature)
        {
            return;
        }

        float coldness = Mathf.InverseLerp(manager.CriticalTemperature, manager.MinimumTemperature, manager.CurrentTemperature);
        float probability = manager.LiquefactionChancePerCollision * coldness;

        if (Random.value < probability)
        {
            Liquefy();
        }
    }

    public void Liquefy()
    {
        if (isLiquid)
        {
            return;
        }

        isLiquid = true;

        // Liquid particles no longer behave like rapidly bouncing ideal gas particles.
        // Gravity and damping make them gather near the bottom and contribute less wall impulse.
        rb.useGravity = true;
        rb.linearDamping = liquidDrag;
        rb.angularDamping = liquidAngularDrag;
        rb.linearVelocity *= liquidSpeedMultiplier;

        if (cachedRenderer != null)
        {
            cachedRenderer.material.color = liquidColor;
        }

        manager.NotifyLiquefied();
    }
}
