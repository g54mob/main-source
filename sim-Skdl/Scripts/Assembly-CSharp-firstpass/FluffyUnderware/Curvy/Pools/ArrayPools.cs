using FluffyUnderware.Curvy.Generator;
using ToolBuddy.Pooling.Pools;
using UnityEngine;

namespace FluffyUnderware.Curvy.Pools
{
	public static class ArrayPools
	{
		public static ArrayPool<Vector2> Vector2 { get; }

		public static ArrayPool<Vector3> Vector3 { get; }

		public static ArrayPool<Vector4> Vector4 { get; }

		public static ArrayPool<int> Int32 { get; }

		public static ArrayPool<float> Single { get; }

		public static ArrayPool<CGSpot> CGSpot { get; }

		static ArrayPools()
		{
		}
	}
}
