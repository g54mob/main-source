using System;
using System.Collections.Generic;
using Pathfinding.Util;
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
				if (RightOrColinear(p1, p2, p3))
				{
					int2 obj = p3;
					p3 = p1;
					p1 = obj;
				}
				d1 = Perpendicular(p2 - p1);
				d2 = Perpendicular(p3 - p2);
				d3 = Perpendicular(p1 - p3);
				t1 = Dot(d1, p1);
				t2 = Dot(d2, p2);
				t3 = Dot(d3, p3);
			}

			public bool Contains(int2 p)
			{
				if (Dot(d1, p) >= t1 && Dot(d2, p) >= t2)
				{
					return Dot(d3, p) >= t3;
				}
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

		private static int2[] directionToCorners = new int2[4]
		{
			new int2(0, 0),
			new int2(1024, 0),
			new int2(1024, 1024),
			new int2(0, 1024)
		};

		private const int FixedPrecisionScale = 1024;

		private static ProfilerMarker marker1 = new ProfilerMarker("Linecast hit");

		private static ProfilerMarker marker2 = new ProfilerMarker("Linecast success");

		private static ProfilerMarker marker3 = new ProfilerMarker("Trace");

		private static ProfilerMarker marker4 = new ProfilerMarker("Neighbours");

		private static ProfilerMarker marker5 = new ProfilerMarker("Re-evaluate linecast");

		private static ProfilerMarker marker6 = new ProfilerMarker("Init");

		private static ProfilerMarker marker7 = new ProfilerMarker("Initloop");

		private static long Cross(int2 lhs, int2 rhs)
		{
			return (long)lhs.x * (long)rhs.y - (long)lhs.y * (long)rhs.x;
		}

		private static long Dot(int2 a, int2 b)
		{
			return (long)a.x * (long)b.x + (long)a.y * (long)b.y;
		}

		private static bool RightOrColinear(int2 a, int2 b, int2 p)
		{
			return (long)(b.x - a.x) * (long)(p.y - a.y) - (long)(p.x - a.x) * (long)(b.y - a.y) <= 0;
		}

		private static int2 Perpendicular(int2 v)
		{
			return new int2(-v.y, v.x);
		}

		private static int2 ToFixedPrecision(Vector2 p)
		{
			return new int2(math.round(new float2(p) * 1024f));
		}

		private static Vector2 FromFixedPrecision(int2 p)
		{
			return (float2)p * 0.0009765625f;
		}

		private static Side Side2D(int2 a, int2 b, int2 p)
		{
			long num = Cross(b - a, p - a);
			if (num <= 0)
			{
				if (num >= 0)
				{
					return Side.Colinear;
				}
				return Side.Right;
			}
			return Side.Left;
		}

		public static float IntersectionLength(int2 nodeCenter, int2 segmentStart, int2 segmentEnd)
		{
			float2 float5 = math.rcp(segmentEnd - segmentStart);
			float num = math.length(segmentEnd - segmentStart);
			float num2 = float.NegativeInfinity;
			float num3 = float.PositiveInfinity;
			int2 int5 = segmentEnd - segmentStart;
			int2 int6 = nodeCenter;
			int2 int7 = nodeCenter + new int2(1024, 1024);
			if ((double)int5.x != 0.0)
			{
				float x = (float)(int6.x - segmentStart.x) * float5.x;
				float y = (float)(int7.x - segmentStart.x) * float5.x;
				num2 = math.max(num2, math.min(x, y));
				num3 = math.min(num3, math.max(x, y));
			}
			else if (segmentStart.x < int6.x || segmentStart.x > int7.x)
			{
				return 0f;
			}
			if ((double)int5.y != 0.0)
			{
				float x2 = (float)(int6.y - segmentStart.y) * float5.y;
				float y2 = (float)(int7.y - segmentStart.y) * float5.y;
				num2 = math.max(num2, math.min(x2, y2));
				num3 = math.min(num3, math.max(x2, y2));
			}
			else if (segmentStart.y < int6.y || segmentStart.y > int7.y)
			{
				return 0f;
			}
			num2 = math.max(0f, num2);
			num3 = math.min(1f, num3);
			return math.max(num3 - num2, 0f) * num * 0.0009765625f;
		}

		internal static void TestIntersectionLength()
		{
		}

		private static uint LinecastCost(List<GraphNode> trace, int2 segmentStart, int2 segmentEnd, GridGraph gg, Func<GraphNode, uint> traversalCost)
		{
			uint num = 0u;
			for (int i = 0; i < trace.Count; i++)
			{
				GridNodeBase gridNodeBase = trace[i] as GridNodeBase;
				num += (uint)(((float)traversalCost(gridNodeBase) + gg.nodeSize * 1000f) * IntersectionLength(new int2(gridNodeBase.XCoordinateInGrid, gridNodeBase.ZCoordinateInGrid) * 1024, segmentStart, segmentEnd));
			}
			return num;
		}

		public static List<Vector3> Calculate(List<GraphNode> pathNodes, int nodeStartIndex, int nodeEndIndex, Vector3 startPoint, Vector3 endPoint, Func<GraphNode, uint> traversalCost = null, Func<GraphNode, bool> filter = null, int maxCorners = int.MaxValue)
		{
			List<int> list = ListPool<int>.Claim();
			list.Add(0);
			int num = nodeEndIndex - nodeStartIndex + 1;
			GridGraph gridGraph = pathNodes[nodeStartIndex].Graph as GridGraph;
			List<GraphNode> list2 = ListPool<GraphNode>.Claim();
			Side side = Side.Colinear;
			int num2 = 0;
			num += 2;
			int num3 = num;
			GridNodeBase[] array = ArrayPool<GridNodeBase>.Claim(num3 * 2);
			int2[] array2 = ArrayPool<int2>.Claim(num3 * 2);
			int2[] array3 = ArrayPool<int2>.Claim(num3 * 2);
			uint[] array4 = ArrayPool<uint>.Claim(num3 * 2);
			uint num4 = 0u;
			for (int i = 0; i < num; i++)
			{
				GridNodeBase gridNodeBase = (array[i] = pathNodes[math.clamp(nodeStartIndex + i - 1, nodeStartIndex, nodeEndIndex)] as GridNodeBase);
				int2 int5 = new int2(gridNodeBase.XCoordinateInGrid, gridNodeBase.ZCoordinateInGrid);
				int2 int6 = int5 * 1024;
				int2 x;
				if (i == 0)
				{
					x = ToFixedPrecision(gridNodeBase.NormalizePoint(startPoint));
					x = math.clamp(x, int2.zero, new int2(1024, 1024));
				}
				else if (i == num - 1)
				{
					x = ToFixedPrecision(gridNodeBase.NormalizePoint(endPoint));
					x = math.clamp(x, int2.zero, new int2(1024, 1024));
				}
				else
				{
					x = new int2(512, 512);
				}
				array2[i] = int6 + x;
				array3[i] = x;
				if (i > 0 && traversalCost != null)
				{
					num4 += (uint)(((float)traversalCost(array[i - 1]) + gridGraph.nodeSize * 1000f) * IntersectionLength(new int2(array[i - 1].XCoordinateInGrid, array[i - 1].ZCoordinateInGrid) * 1024, array2[i - 1], array2[i]));
					num4 += (uint)(((float)traversalCost(array[i]) + gridGraph.nodeSize * 1000f) * IntersectionLength(int5 * 1024, array2[i - 1], array2[i]));
				}
				array4[i] = num4;
			}
			int num5 = 0;
			int num6 = 1;
			int num7 = 1;
			while (true)
			{
				if (num7 >= num)
				{
					list.Add(num - 1);
					break;
				}
				if (list.Count >= maxCorners)
				{
					break;
				}
				num2++;
				if (num2 > 10000)
				{
					Debug.LogError("Inf loop");
					break;
				}
				int num8 = list[list.Count - 1];
				int2 fixedNormalizedFromPoint = array3[num8];
				int num9 = ((list.Count > 1) ? list[list.Count - 2] : (-1));
				GridNodeBase fromNode = array[num8];
				int num10 = num - num7 - 1;
				int num11 = 0;
				int num12 = math.min(4, num10);
				PredicateFailMode predicateFailMode = PredicateFailMode.Undefined;
				GridHitInfo hit;
				while (true)
				{
					int num13 = num7 + num12;
					if (list.Count > 1 && Side2D(array2[num9], array2[num8], array2[num13]) != side)
					{
						predicateFailMode = PredicateFailMode.Turn;
						break;
					}
					list2.Clear();
					if (gridGraph.Linecast(fromNode, fixedNormalizedFromPoint, array[num13], array3[num13], out hit, list2, filter))
					{
						predicateFailMode = PredicateFailMode.LinecastObstacle;
						break;
					}
					if (traversalCost != null)
					{
						uint num14 = LinecastCost(list2, array2[num8], array2[num13], gridGraph, traversalCost);
						if (num14 > array4[num13] - array4[num8] + 5)
						{
							predicateFailMode = PredicateFailMode.LinecastCost;
							break;
						}
					}
					if (num12 < num10)
					{
						num11 = num12;
						num12 = math.min(num12 * 2, num10);
						continue;
					}
					predicateFailMode = PredicateFailMode.ReachedEnd;
					break;
				}
				if (predicateFailMode == PredicateFailMode.ReachedEnd)
				{
					list.Add(num - 1);
					break;
				}
				while (num12 > num11 + 1)
				{
					int num15 = (num11 + num12) / 2;
					int num16 = num7 + num15;
					bool flag;
					if (flag = list.Count > 1 && Side2D(array2[num9], array2[num8], array2[num16]) != side)
					{
						predicateFailMode = PredicateFailMode.Turn;
					}
					else
					{
						list2.Clear();
						if (gridGraph.Linecast(fromNode, fixedNormalizedFromPoint, array[num16], array3[num16], out hit, list2, filter))
						{
							predicateFailMode = PredicateFailMode.LinecastObstacle;
							flag = true;
						}
						else if (traversalCost != null)
						{
							uint num17 = LinecastCost(list2, array2[num8], array2[num16], gridGraph, traversalCost);
							if (num17 > array4[num16] - array4[num8] + 5)
							{
								predicateFailMode = PredicateFailMode.LinecastCost;
								flag = true;
							}
						}
					}
					if (flag)
					{
						num12 = num15;
					}
					else
					{
						num11 = num15;
					}
				}
				if (num11 > 0)
				{
					num5 = num8;
					num6 = num7 + num11;
				}
				else
				{
					bool flag2;
					if (!(flag2 = list.Count > 1 && Side2D(array2[num9], array2[num8], array2[num7 + num11]) != side))
					{
						list2.Clear();
						if (gridGraph.Linecast(fromNode, fixedNormalizedFromPoint, array[num7 + num11], array3[num7 + num11], out hit, list2, filter))
						{
							flag2 = true;
						}
						else if (traversalCost != null)
						{
							uint num18 = LinecastCost(list2, array2[num8], array2[num7 + num11], gridGraph, traversalCost);
							if (num18 > array4[num7 + num11] - array4[num8] + 5)
							{
								flag2 = true;
							}
						}
					}
					if (!flag2)
					{
						num5 = num8;
						num6 = num7 + num11;
					}
				}
				num7 += num12;
				list2.Clear();
				list2.Clear();
				switch (predicateFailMode)
				{
				case PredicateFailMode.LinecastCost:
					list.Add(num6);
					side = Side2D(array2[num8], array2[num6], array2[num7]);
					num5 = num6;
					num7--;
					continue;
				case PredicateFailMode.LinecastObstacle:
				{
					list2.Clear();
					int num19;
					if (gridGraph.Linecast(array[num5], array3[num5], array[num6], array3[num6], out hit, list2, filter))
					{
						num19 = num6;
						Debug.LogError("Inconsistent linecasts");
					}
					else
					{
						list2.Add(array[num7]);
						GridNodeBase gridNodeBase2 = null;
						int2 int7 = default(int2);
						uint num20 = 0u;
						int2 int8 = default(int2);
						int2 int9 = array2[num5];
						int2 int10 = array2[num6];
						int2 lhs = int10 - int9;
						TriangleBounds triangleBounds = new TriangleBounds(int9, int10, array2[num7]);
						int num21 = Math.Sign(Cross(lhs, array2[num7] - int9));
						uint num22 = array4[num5];
						for (int j = 0; j < list2.Count; j++)
						{
							GridNodeBase gridNodeBase3 = list2[j] as GridNodeBase;
							int2 int11 = new int2(gridNodeBase3.XCoordinateInGrid, gridNodeBase3.ZCoordinateInGrid) * 1024;
							if (traversalCost != null)
							{
								num22 += (uint)(((float)traversalCost(gridNodeBase3) + gridGraph.nodeSize * 1000f) * IntersectionLength(int11, int9, int10));
							}
							for (int k = 0; k < 4; k++)
							{
								if (gridNodeBase3.HasConnectionInDirection(k) && (filter == null || filter(gridNodeBase3.GetNeighbourAlongDirection(k))))
								{
									continue;
								}
								for (int l = 0; l < 2; l++)
								{
									int2 int12 = directionToCorners[(k + l) & 3];
									int2 int13 = int11 + int12;
									if (!triangleBounds.Contains(int13))
									{
										continue;
									}
									int2 int14 = int13 - int9;
									if (!math.all(int14 == 0) && !math.all(int13 == int10))
									{
										long num23 = Cross(int14, int8);
										if (gridNodeBase2 == null || Math.Sign(num23) == num21 || (num23 == 0L && math.lengthsq(int14) > math.lengthsq(int8)))
										{
											int8 = int14;
											gridNodeBase2 = gridNodeBase3;
											int7 = int12;
											num20 = num22;
										}
									}
								}
							}
						}
						if (gridNodeBase2 == null)
						{
							num19 = num6;
						}
						else
						{
							num19 = num3;
							array[num3] = gridNodeBase2;
							array3[num3] = int7;
							int2 int15 = new int2(gridNodeBase2.XCoordinateInGrid, gridNodeBase2.ZCoordinateInGrid);
							array2[num3] = int15 * 1024 + int7;
							array4[num3] = num20;
							num3++;
						}
					}
					list.Add(num19);
					side = Side2D(array2[num8], array2[num19], array2[num7]);
					num5 = num19;
					num7--;
					continue;
				}
				}
				num5 = num8;
				num6 = num7;
				if (list.Count <= 1)
				{
					continue;
				}
				int num24 = list[list.Count - 2];
				Side side2 = Side2D(array2[num24], array2[num8], array2[num7]);
				if (side != side2)
				{
					num5 = list[list.Count - 2];
					num6 = list[list.Count - 1];
					list.RemoveAt(list.Count - 1);
					if (list.Count > 1)
					{
						num8 = num24;
						num24 = list[list.Count - 2];
						side = Side2D(array2[num24], array2[num8], array2[num7]);
					}
					else
					{
						side = Side.Colinear;
					}
					num7--;
				}
			}
			List<Vector3> list3 = ListPool<Vector3>.Claim(list.Count);
			for (int m = 0; m < list.Count; m++)
			{
				int num25 = list[m];
				list3.Add(array[num25].UnNormalizePoint(FromFixedPrecision(array3[num25])));
			}
			ArrayPool<GridNodeBase>.Release(ref array);
			ArrayPool<int2>.Release(ref array2);
			ArrayPool<int2>.Release(ref array3);
			ArrayPool<uint>.Release(ref array4);
			ListPool<int>.Release(ref list);
			ListPool<GraphNode>.Release(ref list2);
			return list3;
		}
	}
}
