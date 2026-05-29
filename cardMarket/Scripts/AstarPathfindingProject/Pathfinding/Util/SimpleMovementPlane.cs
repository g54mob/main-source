using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Util
{
	public readonly struct SimpleMovementPlane : IMovementPlane
	{
		public readonly Quaternion rotation;

		public readonly Quaternion inverseRotation;

		private readonly byte plane;

		public static readonly SimpleMovementPlane XYPlane = new SimpleMovementPlane(Quaternion.Euler(-90f, 0f, 0f));

		public static readonly SimpleMovementPlane XZPlane = new SimpleMovementPlane(Quaternion.identity);

		public bool isXY => plane == 1;

		public bool isXZ => plane == 2;

		public SimpleMovementPlane(Quaternion rotation)
		{
			this.rotation = rotation;
			inverseRotation = Quaternion.Inverse(rotation);
			if (rotation == XYPlane.rotation)
			{
				plane = 1;
			}
			else if (rotation == Quaternion.identity)
			{
				plane = 2;
			}
			else
			{
				plane = 0;
			}
		}

		public Vector2 ToPlane(Vector3 point)
		{
			if (isXY)
			{
				return new Vector2(point.x, point.y);
			}
			if (!isXZ)
			{
				point = inverseRotation * point;
			}
			return new Vector2(point.x, point.z);
		}

		public float2 ToPlane(float3 point)
		{
			return ((float3)(inverseRotation * point)).xz;
		}

		public Vector2 ToPlane(Vector3 point, out float elevation)
		{
			if (!isXZ)
			{
				point = inverseRotation * point;
			}
			elevation = point.y;
			return new Vector2(point.x, point.z);
		}

		public float2 ToPlane(float3 point, out float elevation)
		{
			point = math.mul(inverseRotation, point);
			elevation = point.y;
			return point.xz;
		}

		public Vector3 ToWorld(Vector2 point, float elevation = 0f)
		{
			return rotation * new Vector3(point.x, elevation, point.y);
		}

		public float3 ToWorld(float2 point, float elevation = 0f)
		{
			return rotation * new Vector3(point.x, elevation, point.y);
		}

		public SimpleMovementPlane ToSimpleMovementPlane()
		{
			return this;
		}

		public static bool operator ==(SimpleMovementPlane lhs, SimpleMovementPlane rhs)
		{
			return lhs.rotation == rhs.rotation;
		}

		public static bool operator !=(SimpleMovementPlane lhs, SimpleMovementPlane rhs)
		{
			return lhs.rotation != rhs.rotation;
		}

		public override bool Equals(object other)
		{
			if (!(other is SimpleMovementPlane))
			{
				return false;
			}
			return rotation == ((SimpleMovementPlane)other).rotation;
		}

		public override int GetHashCode()
		{
			return rotation.GetHashCode();
		}
	}
}
