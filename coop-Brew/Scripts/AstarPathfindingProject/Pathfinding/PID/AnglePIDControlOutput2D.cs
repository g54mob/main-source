using Unity.Mathematics;

namespace Pathfinding.PID
{
	public struct AnglePIDControlOutput2D
	{
		public float rotationDelta;

		public float targetRotation;

		public float2 positionDelta;

		public AnglePIDControlOutput2D(float currentRotation, float targetRotation, float rotationDelta, float moveDistance)
		{
			this.rotationDelta = 0f;
			this.targetRotation = 0f;
			positionDelta = default(float2);
		}

		public static AnglePIDControlOutput2D WithMovementAtEnd(float currentRotation, float targetRotation, float rotationDelta, float moveDistance)
		{
			return default(AnglePIDControlOutput2D);
		}
	}
}
