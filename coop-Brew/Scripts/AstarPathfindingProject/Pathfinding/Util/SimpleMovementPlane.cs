using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Util
{
	[GenerateTestsForBurstCompatibility]
	public readonly struct SimpleMovementPlane : IMovementPlane
	{
		public readonly Quaternion rotation;

		public readonly Quaternion inverseRotation;

		private readonly byte plane;

		public static readonly SimpleMovementPlane XYPlane;

		public static readonly SimpleMovementPlane XZPlane;

		public bool isXY => false;

		public bool isXZ => false;

		public SimpleMovementPlane(Quaternion rotation)
		{
			this.rotation = default(Quaternion);
			inverseRotation = default(Quaternion);
			plane = 0;
		}

		public Vector2 ToPlane(Vector3 point)
		{
			return default(Vector2);
		}

		public float2 ToPlane(float3 point)
		{
			return default(float2);
		}

		public Vector2 ToPlane(Vector3 point, out float elevation)
		{
			elevation = default(float);
			return default(Vector2);
		}

		public float2 ToPlane(float3 point, out float elevation)
		{
			elevation = default(float);
			return default(float2);
		}

		public Vector3 ToWorld(Vector2 point, float elevation = 0f)
		{
			return default(Vector3);
		}

		public float3 ToWorld(float2 point, float elevation = 0f)
		{
			return default(float3);
		}

		public SimpleMovementPlane ToSimpleMovementPlane()
		{
			return default(SimpleMovementPlane);
		}

		public static bool operator ==(SimpleMovementPlane lhs, SimpleMovementPlane rhs)
		{
			return false;
		}

		public static bool operator !=(SimpleMovementPlane lhs, SimpleMovementPlane rhs)
		{
			return false;
		}

		public override bool Equals(object other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
