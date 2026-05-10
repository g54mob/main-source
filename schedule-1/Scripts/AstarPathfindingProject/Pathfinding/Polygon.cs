using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
	public static class Polygon
	{
		private static readonly Dictionary<Int3, int> cached_Int3_int_dict;

		public static bool ContainsPointXZ(Vector3 a, Vector3 b, Vector3 c, Vector3 p)
		{
			return false;
		}

		public static bool ContainsPointXZ(Int3 a, Int3 b, Int3 c, Int3 p)
		{
			return false;
		}

		public static bool ContainsPoint(Int2 a, Int2 b, Int2 c, Int2 p)
		{
			return false;
		}

		public static bool ContainsPoint(Vector2[] polyPoints, Vector2 p)
		{
			return false;
		}

		public static bool ContainsPointXZ(Vector3[] polyPoints, Vector3 p)
		{
			return false;
		}

		public static int SampleYCoordinateInTriangle(Int3 p1, Int3 p2, Int3 p3, Int3 p)
		{
			return 0;
		}

		public static Vector3[] ConvexHullXZ(Vector3[] points)
		{
			return null;
		}

		public static Vector2 ClosestPointOnTriangle(Vector2 a, Vector2 b, Vector2 c, Vector2 p)
		{
			return default(Vector2);
		}

		public static Vector3 ClosestPointOnTriangleXZ(Vector3 a, Vector3 b, Vector3 c, Vector3 p)
		{
			return default(Vector3);
		}

		public static Vector3 ClosestPointOnTriangle(Vector3 a, Vector3 b, Vector3 c, Vector3 p)
		{
			return default(Vector3);
		}

		public static void CompressMesh(List<Int3> vertices, List<int> triangles, out Int3[] outVertices, out int[] outTriangles)
		{
			outVertices = null;
			outTriangles = null;
		}

		public static void TraceContours(Dictionary<int, int> outline, HashSet<int> hasInEdge, Action<List<int>, bool> results)
		{
		}

		public static void Subdivide(List<Vector3> points, List<Vector3> result, int subSegments)
		{
		}
	}
}
