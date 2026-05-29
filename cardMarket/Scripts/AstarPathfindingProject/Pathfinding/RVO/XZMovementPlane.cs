using System.Runtime.InteropServices;
using Pathfinding.Util;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.RVO
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct XZMovementPlane : IMovementPlaneWrapper
	{
		public float4x4 matrix => float4x4.RotateX(math.radians(90f));

		public float2 ToPlane(float3 p)
		{
			return p.xz;
		}

		public float2 ToPlane(float3 p, out float elevation)
		{
			elevation = p.y;
			return p.xz;
		}

		public float3 ToWorld(float2 p, float elevation = 0f)
		{
			return new float3(p.x, elevation, p.y);
		}

		public Bounds ToWorld(Bounds bounds)
		{
			return bounds;
		}

		public void Set(NativeMovementPlane plane)
		{
		}
	}
}
