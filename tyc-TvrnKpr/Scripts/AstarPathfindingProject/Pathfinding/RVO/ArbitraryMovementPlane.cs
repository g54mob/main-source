using Pathfinding.Util;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.RVO
{
	public struct ArbitraryMovementPlane : IMovementPlaneWrapper
	{
		private NativeMovementPlane plane;

		public float4x4 matrix => default(float4x4);

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

		public Bounds ToWorld(Bounds bounds)
		{
			return default(Bounds);
		}

		public void Set(NativeMovementPlane plane)
		{
		}
	}
}
