using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Drawing
{
	public static class DrawingUtilities
	{
		private static List<Component> componentBuffer;

		public static Bounds BoundsFrom(GameObject gameObject)
		{
			return default(Bounds);
		}

		public static Bounds BoundsFrom(Transform transform)
		{
			return default(Bounds);
		}

		public static Bounds BoundsFrom(List<Vector3> points)
		{
			return default(Bounds);
		}

		public static Bounds BoundsFrom(Vector3[] points)
		{
			return default(Bounds);
		}

		public static Bounds BoundsFrom(NativeArray<float3> points)
		{
			return default(Bounds);
		}
	}
}
