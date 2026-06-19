using Unity.Entities;

public struct ProjectileSpeedCurveCD : IComponentData, IQueryTypeParameter
{
	public const int SPEED_SAMPLE_POINTS = 16;

	public unsafe fixed float speedCurvePoints1[16];

	public unsafe fixed float speedCurvePoints2[16];
}
