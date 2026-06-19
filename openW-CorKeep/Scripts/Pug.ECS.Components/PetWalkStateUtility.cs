using System.Runtime.CompilerServices;
using Unity.Mathematics;

public static class PetWalkStateUtility
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float CalculateMovementSpeed(float speed, float speedMultiplier)
	{
		return speed * speedMultiplier;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float CalculateSpeedMultiplier(float distanceToTarget)
	{
		return math.clamp(distanceToTarget / 2f, 1f, 1.5f);
	}
}
