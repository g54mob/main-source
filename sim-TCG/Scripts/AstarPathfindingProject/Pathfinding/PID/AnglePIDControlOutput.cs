using Pathfinding.Util;
using Unity.Mathematics;

namespace Pathfinding.PID
{
	public struct AnglePIDControlOutput
	{
		public quaternion rotationDelta;

		public float3 positionDelta;

		public float maxDesiredWallDistance;

		public AnglePIDControlOutput(NativeMovementPlane movementPlane, AnglePIDControlOutput2D control2D)
		{
			rotationDelta = movementPlane.ToWorldRotationDelta(0f - control2D.rotationDelta);
			positionDelta = movementPlane.ToWorld(control2D.positionDelta);
			maxDesiredWallDistance = 0f;
		}
	}
}
