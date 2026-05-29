using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Util
{
	public readonly struct ToWorldMatrix
	{
		public readonly float3x3 matrix;

		public ToWorldMatrix(NativeMovementPlane plane)
		{
			matrix = new float3x3(plane.rotation);
		}

		public ToWorldMatrix(float3x3 matrix)
		{
			this.matrix = matrix;
		}

		public float3 ToWorld(float2 p, float elevation = 0f)
		{
			return math.mul(matrix, new float3(p.x, elevation, p.y));
		}

		public Bounds ToWorld(Bounds bounds)
		{
			return new Bounds
			{
				center = math.mul(matrix, bounds.center),
				extents = math.mul(new float3x3(math.abs(matrix.c0), math.abs(matrix.c1), math.abs(matrix.c2)), bounds.extents)
			};
		}
	}
}
