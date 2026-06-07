using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Util
{
	public readonly struct NativeMovementPlane
	{
		public readonly quaternion rotation;

		public float3 up => default(float3);

		public NativeMovementPlane(quaternion rotation)
		{
			this.rotation = default(quaternion);
		}

		public NativeMovementPlane(SimpleMovementPlane plane)
		{
			rotation = default(quaternion);
		}

		public ToPlaneMatrix AsWorldToPlaneMatrix()
		{
			return default(ToPlaneMatrix);
		}

		public ToWorldMatrix AsPlaneToWorldMatrix()
		{
			return default(ToWorldMatrix);
		}

		public NativeMovementPlane MatchUpDirection(float3 up)
		{
			return default(NativeMovementPlane);
		}

		public float ProjectedLength(float3 v)
		{
			return 0f;
		}

		public float2 ToPlane(float3 p)
		{
			return default(float2);
		}

		public float2 ToPlane(float3 p, out float elevation)
		{
			elevation = default(float);
			return default(float2);
		}

		public float3 ToWorld(float2 p, float elevation = 0f)
		{
			return default(float3);
		}

		public float ToPlane(quaternion rotation)
		{
			return 0f;
		}

		public quaternion ToWorldRotation(float angle)
		{
			return default(quaternion);
		}

		public quaternion ToWorldRotationDelta(float deltaAngle)
		{
			return default(quaternion);
		}

		public Bounds ToWorld(Bounds bounds)
		{
			return default(Bounds);
		}
	}
}
