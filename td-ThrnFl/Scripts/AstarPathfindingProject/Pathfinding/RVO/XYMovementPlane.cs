using System.Runtime.InteropServices;
using Pathfinding.Util;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.RVO
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct XYMovementPlane : IMovementPlaneWrapper
	{
		public float4x4 matrix => float4x4.identity;

		public float2 ToPlane(float3 p)
		{
			return p.xy;
		}

		public float2 ToPlane(float3 p, out float elevation)
		{
			elevation = p.z;
			return p.xy;
		}

		public float3 ToWorld(float2 p, float elevation = 0f)
		{
			return new float3(p.x, p.y, elevation);
		}

		public Bounds ToWorld(Bounds bounds)
		{
			Vector3 center = bounds.center;
			Vector3 size = bounds.size;
			return new Bounds(new Vector3(center.x, center.z, center.y), new Vector3(size.x, size.z, size.y));
		}

		public void Set(NativeMovementPlane plane)
		{
		}
	}
}
