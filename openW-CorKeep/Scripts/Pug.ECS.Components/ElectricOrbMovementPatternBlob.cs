using Unity.Mathematics;

public struct ElectricOrbMovementPatternBlob
{
	public ElectricOrbMovementPattern pattern;

	public float2 minMaxDurationSeconds;

	public float2 minMaxSpeed;

	public bool sinusoidalPattern;

	public float sinusoidalMaxTurnAngleRadians;

	public float sinusoidalRepeatTimeSeconds;
}
