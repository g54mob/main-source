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
			math.sincos(currentRotation + rotationDelta * 0.5f, out var s, out var c);
			this.rotationDelta = rotationDelta;
			positionDelta = new float2(c, s) * moveDistance;
			this.targetRotation = targetRotation;
		}

		public static AnglePIDControlOutput2D WithMovementAtEnd(float currentRotation, float targetRotation, float rotationDelta, float moveDistance)
		{
			math.sincos(currentRotation + rotationDelta, out var s, out var c);
			return new AnglePIDControlOutput2D
			{
				rotationDelta = rotationDelta,
				targetRotation = targetRotation,
				positionDelta = new float2(c, s) * moveDistance
			};
		}
	}
}
