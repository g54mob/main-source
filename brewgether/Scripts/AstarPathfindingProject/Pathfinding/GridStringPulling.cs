using System;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;

namespace Pathfinding
{
	public static class GridStringPulling
	{
		private struct TriangleBounds
		{
			private int2 d1;

			private int2 d2;

			private int2 d3;

			private long t1;

			private long t2;

			private long t3;

			public TriangleBounds(int2 p1, int2 p2, int2 p3)
			{
				d1 = default(int2);
				d2 = default(int2);
				d3 = default(int2);
				t1 = 0L;
				t2 = 0L;
				t3 = 0L;
			}

			public bool Contains(int2 p)
			{
				return false;
			}
		}

		private enum PredicateFailMode
		{
			Undefined = 0,
			Turn = 1,
			LinecastObstacle = 2,
			LinecastCost = 3,
			ReachedEnd = 4
		}

		private static int2[] directionToCorners;

		private const int FixedPrecisionScale = 1024;

		private static ProfilerMarker marker1;

		private static ProfilerMarker marker2;

		private static ProfilerMarker marker3;

		private static ProfilerMarker marker4;

		private static ProfilerMarker marker5;

		private static ProfilerMarker marker6;

		private static ProfilerMarker marker7;

		private static long Cross(int2 lhs, int2 rhs)
		{
			return 0L;
		}

		private static long Dot(int2 a, int2 b)
		{
			return 0L;
		}

		private static bool RightOrColinear(int2 a, int2 b, int2 p)
		{
			return false;
		}

		private static int2 Perpendicular(int2 v)
		{
			return default(int2);
		}

		private static int2 ToFixedPrecision(Vector2 p)
		{
			return default(int2);
		}

		private static Vector2 FromFixedPrecision(int2 p)
		{
			return default(Vector2);
		}

		private static Side Side2D(int2 a, int2 b, int2 p)
		{
			return default(Side);
		}

		public static float IntersectionLength(int2 nodeCenter, int2 segmentStart, int2 segmentEnd)
		{
			return 0f;
		}

		internal static void TestIntersectionLength()
		{
		}

		private static uint LinecastCost(List<GraphNode> trace, int2 segmentStart, int2 segmentEnd, GridGraph gg, Func<GraphNode, uint> traversalCost)
		{
			return 0u;
		}

		public static List<Vector3> Calculate(List<GraphNode> pathNodes, int nodeStartIndex, int nodeEndIndex, Vector3 startPoint, Vector3 endPoint, Func<GraphNode, uint> traversalCost = null, Func<GraphNode, bool> filter = null, int maxCorners = int.MaxValue)
		{
			return null;
		}
	}
}
