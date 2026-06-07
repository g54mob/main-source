using System.Collections.Generic;
using UnityEngine;

namespace Os.Utils
{
	public static class Intersections
	{
		public static readonly Vector3[] corners;

		private static Stack<HashSet<Vector3>> axisHashSets;

		public static bool TriangleRay(Vector3 p1, Vector3 p2, Vector3 p3, Ray ray)
		{
			return false;
		}

		public static bool BoxBox(Vector3 min0, Vector3 max0, Vector3 min1, Vector3 max1)
		{
			return false;
		}

		public static bool TriangleTriangle(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 v0, Vector3 v1, Vector3 v2, float minDistance = 0f)
		{
			return false;
		}

		private static bool TriangleTriangleInternal(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 v0, Vector3 v1, Vector3 v2, float minDistance)
		{
			return false;
		}

		public static bool OrientedBoxOrientedBox(Matrix4x4 box0, Matrix4x4 box1)
		{
			return false;
		}

		private static bool OrientedBoxOrientedBoxInternal(Matrix4x4 box0, Matrix4x4 box1, HashSet<Vector3> axisList)
		{
			return false;
		}

		public static bool OrientedBoxTriangle(Matrix4x4 box0, Vector3 p0, Vector3 p1, Vector3 p2)
		{
			return false;
		}
	}
}
