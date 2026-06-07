using Pathfinding.Util;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.RVO
{
	public interface IMovementPlaneWrapper
	{
		float4x4 matrix { get; }

		float2 ToPlane(float3 p);

		float2 ToPlane(float3 p, out float elevation);

		float3 ToWorld(float2 p, float elevation = 0f);

		Bounds ToWorld(Bounds bounds);

		void Set(NativeMovementPlane plane);
	}
}
