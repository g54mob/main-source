using Pathfinding.Util;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.RVO
{
	public struct ArbitraryMovementPlane : IMovementPlaneWrapper
	{
		private NativeMovementPlane plane;

		public float4x4 matrix => math.mul(float4x4.TRS(0, plane.rotation, 1), new float4x4(new float4(1f, 0f, 0f, 0f), new float4(0f, 0f, 1f, 0f), new float4(0f, 1f, 0f, 0f), new float4(0f, 0f, 0f, 1f)));

		public float2 ToPlane(float3 p)
		{
			return plane.ToPlane(p);
		}

		public float2 ToPlane(float3 p, out float elevation)
		{
			return plane.ToPlane(p, out elevation);
		}

		public float3 ToWorld(float2 p, float elevation = 0f)
		{
			return plane.ToWorld(p, elevation);
		}

		public Bounds ToWorld(Bounds bounds)
		{
			return plane.ToWorld(bounds);
		}

		public void Set(NativeMovementPlane plane)
		{
			this.plane = plane;
		}
	}
}
