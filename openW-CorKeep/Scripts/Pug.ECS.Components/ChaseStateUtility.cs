using System.Runtime.CompilerServices;

public static class ChaseStateUtility
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float CalculateMovementSpeed(float speed, float movementSpeedMultiplier, bool isLeashed)
	{
		return (isLeashed ? 2f : 1f) * speed * movementSpeedMultiplier;
	}
}
