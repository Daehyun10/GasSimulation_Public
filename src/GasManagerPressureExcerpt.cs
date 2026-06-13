using UnityEngine;

/// <summary>
/// Public excerpt showing the pressure model used in the simulation.
/// This file is not a complete MonoBehaviour. It is included for report review.
/// </summary>
public static class GasManagerPressureExcerpt
{
    public static float CalculateIdealPressure(float particleCount, float moleScalePerParticle, float gasConstantR, float temperature, float volume)
    {
        float safeVolume = Mathf.Max(volume, 0.001f);
        float n = particleCount * moleScalePerParticle;
        return n * gasConstantR * temperature / safeVolume;
    }

    public static float EstimateRealPressure(float accumulatedWallImpulse, float sampleInterval, float surfaceArea, float realPressureScale)
    {
        float safeInterval = Mathf.Max(sampleInterval, 0.001f);
        float safeArea = Mathf.Max(surfaceArea, 0.001f);
        return (accumulatedWallImpulse / safeInterval) / safeArea * realPressureScale;
    }

    public static float CalculateErrorPercent(float idealPressure, float realPressure)
    {
        if (idealPressure <= 0f)
        {
            return 0f;
        }

        return Mathf.Abs(idealPressure - realPressure) / idealPressure * 100f;
    }
}
