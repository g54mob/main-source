using UnityEngine;

namespace Pathfinding.Util
{
	public static class MovementUtilities
	{
		public static float FilterRotationDirection(ref Vector2 state, ref Vector2 state2, Vector2 deltaPosition, float threshold, float deltaTime, bool avoidingOtherAgents)
		{
			return 0f;
		}

		public static Vector2 ClampVelocity(Vector2 velocity, float maxSpeed, float speedLimitFactor, bool slowWhenNotFacingTarget, bool preventMovingBackwards, Vector2 forward)
		{
			return default(Vector2);
		}

		public static Vector2 CalculateAccelerationToReachPoint(Vector2 deltaPosition, Vector2 targetVelocity, Vector2 currentVelocity, float forwardsAcceleration, float rotationSpeed, float maxSpeed, Vector2 forwardsVector)
		{
			return default(Vector2);
		}
	}
}
