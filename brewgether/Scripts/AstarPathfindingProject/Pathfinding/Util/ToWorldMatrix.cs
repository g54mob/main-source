using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Util
{
	public readonly struct ToWorldMatrix
	{
		public readonly float3x3 matrix;

		public ToWorldMatrix(NativeMovementPlane plane)
		{
			matrix = default(float3x3);
		}

		public ToWorldMatrix(float3x3 matrix)
		{
			this.matrix = default(float3x3);
		}

		public float3 ToWorld(float2 p, float elevation = 0f)
		{
			return default(float3);
		}

		public Bounds ToWorld(Bounds bounds)
		{
			return default(Bounds);
		}
	}
}
