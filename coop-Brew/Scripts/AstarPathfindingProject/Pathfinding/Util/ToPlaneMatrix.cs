using Unity.Mathematics;

namespace Pathfinding.Util
{
	public readonly struct ToPlaneMatrix
	{
		public readonly float3x3 matrix;

		public ToPlaneMatrix(NativeMovementPlane plane)
		{
			matrix = default(float3x3);
		}

		public float2 ToPlane(float3 p)
		{
			return default(float2);
		}

		public float3 ToXZPlane(float3 p)
		{
			return default(float3);
		}

		public float2 ToPlane(float3 p, out float elevation)
		{
			elevation = default(float);
			return default(float2);
		}
	}
}
