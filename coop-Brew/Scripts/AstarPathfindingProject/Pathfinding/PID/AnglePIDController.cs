namespace Pathfinding.PID
{
	public static class AnglePIDController
	{
		private const float DampingRatio = 1f;

		public static float ApproximateTurningRadius(float followingStrength)
		{
			return 0f;
		}

		public static float RotationSpeedToFollowingStrength(float speed, float maxRotationSpeed)
		{
			return 0f;
		}

		public static float FollowingStrengthToRotationSpeed(float followingStrength)
		{
			return 0f;
		}

		public static AnglePIDControlOutput2D Control(ref PIDMovement settings, float followingStrength, float angle, float curveAngle, float curveCurvature, float curveDistanceSigned, float speed, float remainingDistance, float minRotationSpeed, bool isStationary, float dt)
		{
			return default(AnglePIDControlOutput2D);
		}
	}
}
