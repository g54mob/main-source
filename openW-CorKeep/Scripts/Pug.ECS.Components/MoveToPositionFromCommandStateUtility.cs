using System.Runtime.CompilerServices;

public static class MoveToPositionFromCommandStateUtility
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float CalculateMovementSpeed(float speed, float moveSpeedMultiplier)
	{
		return speed * moveSpeedMultiplier;
	}
}
