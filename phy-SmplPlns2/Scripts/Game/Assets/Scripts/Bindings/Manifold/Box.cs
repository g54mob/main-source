using Unity.Mathematics;
using Unity.Mathematics.Geometry;
using UnityEngine;

namespace Assets.Scripts.Bindings.Manifold
{
	public struct Box
	{
		public double3 min;

		public double3 max;

		public static explicit operator Bounds(Box box)
		{
			return new Bounds((float3)(box.min + box.max) * 0.5f, (float3)(box.max - box.min));
		}

		public static explicit operator MinMaxAABB(Box box)
		{
			return new MinMaxAABB((float3)box.min, (float3)box.max);
		}
	}
}
