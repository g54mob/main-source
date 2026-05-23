using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Util
{
	public readonly struct NativeMovementPlane
	{
		public readonly quaternion rotation;

		public float3 up => 2f * new float3(rotation.value.x * rotation.value.y - rotation.value.w * rotation.value.z, 0.5f - rotation.value.x * rotation.value.x - rotation.value.z * rotation.value.z, rotation.value.w * rotation.value.x + rotation.value.y * rotation.value.z);

		public NativeMovementPlane(quaternion rotation)
		{
			this.rotation = math.normalizesafe(rotation);
		}

		public NativeMovementPlane(SimpleMovementPlane plane)
			: this(plane.rotation)
		{
		}

		public ToPlaneMatrix AsWorldToPlaneMatrix()
		{
			return new ToPlaneMatrix(this);
		}

		public ToWorldMatrix AsPlaneToWorldMatrix()
		{
			return new ToWorldMatrix(this);
		}

		public float ProjectedLength(float3 v)
		{
			return math.length(ToPlane(v));
		}

		public float2 ToPlane(float3 p)
		{
			return math.mul(math.conjugate(rotation), p).xz;
		}

		public float2 ToPlane(float3 p, out float elevation)
		{
			p = math.mul(math.conjugate(rotation), p);
			elevation = p.y;
			return p.xz;
		}

		public float3 ToWorld(float2 p, float elevation = 0f)
		{
			return math.mul(rotation, new float3(p.x, elevation, p.y));
		}

		public float ToPlane(quaternion rotation)
		{
			quaternion quaternion2 = math.mul(math.conjugate(this.rotation), rotation);
			if (quaternion2.value.y < 0f)
			{
				quaternion2.value = -quaternion2.value;
			}
			return 0f - VectorMath.QuaternionAngle(math.normalizesafe(new quaternion(0f, quaternion2.value.y, 0f, quaternion2.value.w)));
		}

		public quaternion ToWorldRotation(float angle)
		{
			return math.mul(rotation, quaternion.RotateY(0f - angle));
		}

		public quaternion ToWorldRotationDelta(float deltaAngle)
		{
			return quaternion.AxisAngle(ToWorld(float2.zero, 1f), 0f - deltaAngle);
		}

		public Bounds ToWorld(Bounds bounds)
		{
			return AsPlaneToWorldMatrix().ToWorld(bounds);
		}
	}
}
