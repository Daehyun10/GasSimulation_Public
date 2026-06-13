using UnityEngine;

/// <summary>
/// Controls the six collider walls of the gas container.
/// The camera-facing wall renderers are hidden so the molecules remain visible,
/// but their colliders stay active and still register pressure collisions.
/// </summary>
public class WallController : MonoBehaviour
{
    [Header("Wall References")]
    [SerializeField] private Transform leftWall;
    [SerializeField] private Transform rightWall;
    [SerializeField] private Transform topWall;
    [SerializeField] private Transform bottomWall;
    [SerializeField] private Transform frontWall;
    [SerializeField] private Transform backWall;

    [Header("Container Size")]
    [SerializeField] private Vector3 containerSize = new Vector3(8f, 5f, 8f);
    [SerializeField] private Vector3 minimumSize = new Vector3(3f, 3f, 3f);
    [SerializeField] private Vector3 maximumSize = new Vector3(14f, 10f, 14f);
    [SerializeField] private float resizeSpeed = 3f;
    [SerializeField] private float wallThickness = 0.2f;

    public Vector3 ContainerSize => containerSize;

    private void Start()
    {
        FindWallsIfNeeded();
        ApplyWallTransforms();
        ApplyWallVisibility();
    }

    private void Update()
    {
        Vector3 input = Vector3.zero;

        if (Input.GetKey(KeyCode.RightArrow)) input.x += 1f;
        if (Input.GetKey(KeyCode.LeftArrow)) input.x -= 1f;
        if (Input.GetKey(KeyCode.UpArrow)) input.y += 1f;
        if (Input.GetKey(KeyCode.DownArrow)) input.y -= 1f;
        if (Input.GetKey(KeyCode.W)) input.z += 1f;
        if (Input.GetKey(KeyCode.S)) input.z -= 1f;

        if (input.sqrMagnitude > 0f)
        {
            containerSize += input * resizeSpeed * Time.deltaTime;
            containerSize.x = Mathf.Clamp(containerSize.x, minimumSize.x, maximumSize.x);
            containerSize.y = Mathf.Clamp(containerSize.y, minimumSize.y, maximumSize.y);
            containerSize.z = Mathf.Clamp(containerSize.z, minimumSize.z, maximumSize.z);
            ApplyWallTransforms();
        }
    }

    public void AssignWalls(
        Transform left,
        Transform right,
        Transform top,
        Transform bottom,
        Transform front,
        Transform back)
    {
        leftWall = left;
        rightWall = right;
        topWall = top;
        bottomWall = bottom;
        frontWall = front;
        backWall = back;
        ApplyWallTransforms();
        ApplyWallVisibility();
    }

    private void FindWallsIfNeeded()
    {
        if (leftWall == null) leftWall = GameObject.Find("LeftWall")?.transform;
        if (rightWall == null) rightWall = GameObject.Find("RightWall")?.transform;
        if (topWall == null) topWall = GameObject.Find("TopWall")?.transform;
        if (bottomWall == null) bottomWall = GameObject.Find("BottomWall")?.transform;
        if (frontWall == null) frontWall = GameObject.Find("FrontWall")?.transform;
        if (backWall == null) backWall = GameObject.Find("BackWall")?.transform;
    }

    private void ApplyWallTransforms()
    {
        float halfX = containerSize.x * 0.5f;
        float halfY = containerSize.y * 0.5f;
        float halfZ = containerSize.z * 0.5f;

        SetWall(leftWall, new Vector3(-halfX, 0f, 0f), new Vector3(wallThickness, containerSize.y, containerSize.z));
        SetWall(rightWall, new Vector3(halfX, 0f, 0f), new Vector3(wallThickness, containerSize.y, containerSize.z));
        SetWall(topWall, new Vector3(0f, halfY, 0f), new Vector3(containerSize.x, wallThickness, containerSize.z));
        SetWall(bottomWall, new Vector3(0f, -halfY, 0f), new Vector3(containerSize.x, wallThickness, containerSize.z));
        SetWall(frontWall, new Vector3(0f, 0f, halfZ), new Vector3(containerSize.x, containerSize.y, wallThickness));
        SetWall(backWall, new Vector3(0f, 0f, -halfZ), new Vector3(containerSize.x, containerSize.y, wallThickness));
    }

    private void SetWall(Transform wall, Vector3 localPosition, Vector3 localScale)
    {
        if (wall == null) return;

        wall.localPosition = localPosition;
        wall.localScale = localScale;
        wall.gameObject.tag = "Wall";

        if (wall.GetComponent<Collider>() == null)
        {
            wall.gameObject.AddComponent<BoxCollider>();
        }
    }

    private void ApplyWallVisibility()
    {
        SetVisibleWall(leftWall, new Color(0.55f, 0.75f, 1f, 1f));
        SetVisibleWall(rightWall, new Color(0.55f, 0.75f, 1f, 1f));
        SetVisibleWall(bottomWall, new Color(0.35f, 0.45f, 0.55f, 1f));
        SetVisibleWall(frontWall, new Color(0.30f, 0.60f, 1f, 1f));

        // The camera is placed at negative Z, so BackWall is the near wall. Hide it visually only.
        SetRendererEnabled(backWall, false);
        SetRendererEnabled(topWall, false);
    }

    private void SetVisibleWall(Transform wall, Color color)
    {
        if (wall == null) return;

        Renderer renderer = wall.GetComponent<Renderer>();
        if (renderer == null) return;

        renderer.enabled = true;
        Material material = renderer.material;
        material.color = color;
    }

    private void SetRendererEnabled(Transform wall, bool enabled)
    {
        if (wall == null) return;

        Renderer renderer = wall.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = enabled;
        }
    }
}