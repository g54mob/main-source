using Unity.Mathematics;

namespace Pathfinding.Util
{
	public readonly struct ToPlaneMatrix
	{
		public readonly float3x3 matrix;

		public ToPlaneMatrix(NativeMovementPlane plane)
		{
			matrix = new float3x3(math.conjugate(plane.rotation));
		}

		public float2 ToPlane(float3 p)
		{
			return math.mul(matrix, p).xz;
		}

		public float3 ToXZPlane(float3 p)
		{
			return math.mul(matrix, p);
		}

		public float2 ToPlane(float3 p, out float elevation)
		{
			float3 float5 = math.mul(matrix, p);
			elevation = float5.y;
			return float5.xz;
		}
	}
}
