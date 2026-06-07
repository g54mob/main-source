using System;
using System.Collections.Generic;
using System.Linq;
using Poly2Tri.Triangulation.Util;
using Poly2Tri.Utility;

namespace Poly2Tri.Triangulation.Polygon
{
	public static class PolygonUtil
	{
		public enum PolyUnionError
		{
			None = 0,
			NoIntersections = 1,
			Poly1InsidePoly2 = 2,
			InfiniteLoop = 3
		}

		[Flags]
		public enum PolyOperation : uint
		{
			None = 0u,
			Union = 1u,
			Intersect = 2u,
			Subtract = 4u
		}

		public static Point2DList.WindingOrderType CalculateWindingOrder(IList<Point2D> l)
		{
			double num = 0.0;
			for (int i = 0; i < l.Count; i++)
			{
				int index = (i + 1) % l.Count;
				num += l[i].X * l[index].Y;
				num -= l[i].Y * l[index].X;
			}
			num /= 2.0;
			if (num < 0.0)
			{
				return Point2DList.WindingOrderType.Clockwise;
			}
			if (num > 0.0)
			{
				return Point2DList.WindingOrderType.AntiClockwise;
			}
			return Point2DList.WindingOrderType.Unknown;
		}

		public static bool PolygonsAreSame2D(IList<Point2D> poly1, IList<Point2D> poly2)
		{
			int count = poly1.Count;
			int count2 = poly2.Count;
			if (count != count2)
			{
				return false;
			}
			Point2D point2D = new Point2D(0.0, 0.0);
			for (int i = 0; i < count2; i++)
			{
				point2D.Set(poly1[0].X, poly1[0].Y);
				point2D.Subtract(poly2[i]);
				if (!(point2D.MagnitudeSquared() < 0.0001))
				{
					continue;
				}
				int num = i;
				bool flag = false;
				bool flag2;
				do
				{
					flag2 = true;
					for (int j = 1; j < count; j++)
					{
						if (!flag)
						{
							i++;
						}
						else
						{
							i--;
							if (i < 0)
							{
								i = count2 - 1;
							}
						}
						point2D.Set(poly1[j].X, poly1[j].Y);
						point2D.Subtract(poly2[i % count2]);
						if (point2D.MagnitudeSquared() >= 0.0001)
						{
							if (flag)
							{
								return false;
							}
							i = num;
							flag = true;
							flag2 = false;
							break;
						}
					}
				}
				while (!flag2);
				return true;
			}
			return false;
		}

		public static bool PointInPolygon2D(IList<Point2D> polygon, Point2D p)
		{
			if (polygon == null || polygon.Count < 3)
			{
				return false;
			}
			int count = polygon.Count;
			Point2D point2D = polygon[count - 1];
			bool flag = point2D.Y >= p.Y;
			bool flag2 = false;
			for (int i = 0; i < count; i++)
			{
				Point2D point2D2 = polygon[i];
				bool flag3 = point2D2.Y >= p.Y;
				if (flag != flag3 && (point2D2.Y - p.Y) * (point2D.X - point2D2.X) >= (point2D2.X - p.X) * (point2D.Y - point2D2.Y) == flag3)
				{
					flag2 = !flag2;
				}
				flag = flag3;
				point2D = point2D2;
			}
			return flag2;
		}

		public static bool PolygonsIntersect2D(IList<Point2D> poly1, Rect2D boundRect1, IList<Point2D> poly2, Rect2D boundRect2)
		{
			if (poly1 == null || poly1.Count < 3 || boundRect1.IsEmpty || poly2 == null || poly2.Count < 3 || boundRect2.IsEmpty)
			{
				return false;
			}
			if (!boundRect1.Intersects(boundRect2))
			{
				return false;
			}
			double epsilon = Math.Max(Math.Min(boundRect1.Width, boundRect2.Width) * 0.0010000000474974513, 1E-12);
			int count = poly1.Count;
			int count2 = poly2.Count;
			for (int i = 0; i < count; i++)
			{
				int num = i + 1;
				if (num == count)
				{
					num = 0;
				}
				for (int j = 0; j < count2; j++)
				{
					int num2 = j + 1;
					if (num2 == count2)
					{
						num2 = 0;
					}
					Point2D pIntersectionPt = null;
					if (TriangulationUtil.LinesIntersect2D(poly1[i], poly1[num], poly2[j], poly2[num2], ref pIntersectionPt, epsilon))
					{
						return true;
					}
				}
			}
			return false;
		}

		public static bool PolygonContainsPolygon(IList<Point2D> poly1, Rect2D boundRect1, IList<Point2D> poly2, Rect2D boundRect2, bool runIntersectionTest = true)
		{
			if (poly1 == null || poly1.Count < 3 || poly2 == null || poly2.Count < 3)
			{
				return false;
			}
			if (runIntersectionTest)
			{
				if (poly1.Count == poly2.Count && PolygonsAreSame2D(poly1, poly2))
				{
					return false;
				}
				if (PolygonsIntersect2D(poly1, boundRect1, poly2, boundRect2))
				{
					return false;
				}
			}
			if (PointInPolygon2D(poly1, poly2[0]))
			{
				return true;
			}
			return false;
		}

		private static void ClipPolygonToEdge2D(Point2D edgeBegin, Point2D edgeEnd, IList<Point2D> poly, out List<Point2D> outPoly)
		{
			outPoly = null;
			if (edgeBegin == null || edgeEnd == null || poly == null || poly.Count < 3)
			{
				return;
			}
			outPoly = new List<Point2D>();
			int index = poly.Count - 1;
			Point2D ptRayVector = new Point2D(edgeEnd.X - edgeBegin.X, edgeEnd.Y - edgeBegin.Y);
			bool flag = TriangulationUtil.Orient2d(edgeBegin, edgeEnd, poly[index]) == Orientation.Clockwise;
			Point2D point2D = new Point2D(0.0, 0.0);
			for (int i = 0; i < poly.Count; i++)
			{
				bool num = TriangulationUtil.Orient2d(edgeBegin, edgeEnd, poly[i]) == Orientation.Clockwise;
				if (num)
				{
					if (flag)
					{
						outPoly.Add(poly[i]);
					}
					else
					{
						point2D.Set(poly[i].X - poly[index].X, poly[i].Y - poly[index].Y);
						Point2D ptIntersection = new Point2D(0.0, 0.0);
						if (TriangulationUtil.RaysIntersect2D(poly[index], point2D, edgeBegin, ptRayVector, ref ptIntersection))
						{
							outPoly.Add(ptIntersection);
							outPoly.Add(poly[i]);
						}
					}
				}
				else if (flag)
				{
					point2D.Set(poly[i].X - poly[index].X, poly[i].Y - poly[index].Y);
					Point2D ptIntersection2 = new Point2D(0.0, 0.0);
					if (TriangulationUtil.RaysIntersect2D(poly[index], point2D, edgeBegin, ptRayVector, ref ptIntersection2))
					{
						outPoly.Add(ptIntersection2);
					}
				}
				index = i;
				flag = num;
			}
		}

		public static void ClipPolygonToPolygon(IList<Point2D> poly, IList<Point2D> clipPoly, out List<Point2D> outPoly)
		{
			outPoly = null;
			if (poly != null && poly.Count >= 3 && clipPoly != null && clipPoly.Count >= 3)
			{
				outPoly = new List<Point2D>(poly);
				int count = clipPoly.Count;
				int index = count - 1;
				for (int i = 0; i < count; i++)
				{
					Point2D edgeBegin = clipPoly[index];
					Point2D edgeEnd = clipPoly[i];
					List<Point2D> outPoly2;
					ClipPolygonToEdge2D(edgeBegin, edgeEnd, outPoly, out outPoly2);
					outPoly.Clear();
					outPoly.AddRange(outPoly2);
					index = i;
				}
			}
		}

		public static PolyUnionError PolygonUnion(Point2DList polygon1, Point2DList polygon2, out Point2DList union)
		{
			PolygonOperationContext polygonOperationContext = new PolygonOperationContext();
			polygonOperationContext.Init(PolyOperation.Union, polygon1, polygon2);
			PolygonUnionInternal(polygonOperationContext);
			union = polygonOperationContext.Union;
			return polygonOperationContext.Error;
		}

		private static void PolygonUnionInternal(PolygonOperationContext ctx)
		{
			Point2DList union = ctx.Union;
			if (ctx.StartingIndex == -1)
			{
				switch (ctx.Error)
				{
				case PolyUnionError.NoIntersections:
				case PolyUnionError.InfiniteLoop:
					return;
				case PolyUnionError.Poly1InsidePoly2:
					union.AddRange(ctx.OriginalPolygon2);
					return;
				}
			}
			Point2DList point2DList = ctx.Poly1;
			Point2DList point2DList2 = ctx.Poly2;
			List<int> list = ctx.Poly1VectorAngles;
			Point2D p = ctx.Poly1[ctx.StartingIndex];
			int num = ctx.StartingIndex;
			int num2 = -1;
			union.Clear();
			do
			{
				union.Add(point2DList[num]);
				foreach (EdgeIntersectInfo intersection in ctx.Intersections)
				{
					if (!point2DList[num].Equals(intersection.IntersectionPoint, point2DList.Epsilon))
					{
						continue;
					}
					int num3 = point2DList2.IndexOf(intersection.IntersectionPoint);
					int index = point2DList2.NextIndex(num3);
					Point2D point = point2DList2[index];
					bool flag;
					if (list[index] == -1)
					{
						flag = PolygonOperationContext.PointInPolygonAngle(point, point2DList);
						list[index] = (flag ? 1 : 0);
					}
					else
					{
						flag = list[index] == 1;
					}
					if (flag)
					{
						continue;
					}
					if (point2DList == ctx.Poly1)
					{
						point2DList = ctx.Poly2;
						list = ctx.Poly2VectorAngles;
						point2DList2 = ctx.Poly1;
						if (num2 < 0)
						{
							num2 = num3;
						}
					}
					else
					{
						point2DList = ctx.Poly1;
						list = ctx.Poly1VectorAngles;
						point2DList2 = ctx.Poly2;
					}
					num = num3;
					break;
				}
				num = point2DList.NextIndex(num);
				if (point2DList == ctx.Poly1)
				{
					if (num == 0)
					{
						break;
					}
				}
				else if (num2 >= 0 && num == num2)
				{
					break;
				}
			}
			while (point2DList[num].Equals(p) && union.Count <= ctx.Poly1.Count + ctx.Poly2.Count);
			if (union.Count > ctx.Poly1.Count + ctx.Poly2.Count)
			{
				ctx.Error = PolyUnionError.InfiniteLoop;
			}
		}

		public static PolyUnionError PolygonIntersect(Point2DList polygon1, Point2DList polygon2, out Point2DList intersectOut)
		{
			PolygonOperationContext polygonOperationContext = new PolygonOperationContext();
			polygonOperationContext.Init(PolyOperation.Intersect, polygon1, polygon2);
			PolygonIntersectInternal(polygonOperationContext);
			intersectOut = polygonOperationContext.Intersect;
			return polygonOperationContext.Error;
		}

		private static void PolygonIntersectInternal(PolygonOperationContext ctx)
		{
			Point2DList intersect = ctx.Intersect;
			if (ctx.StartingIndex == -1)
			{
				switch (ctx.Error)
				{
				case PolyUnionError.NoIntersections:
				case PolyUnionError.InfiniteLoop:
					return;
				case PolyUnionError.Poly1InsidePoly2:
					intersect.AddRange(ctx.OriginalPolygon2);
					return;
				}
			}
			Point2DList point2DList = ctx.Poly1;
			Point2DList point2DList2 = ctx.Poly2;
			List<int> list = ctx.Poly1VectorAngles;
			int num = ctx.Poly1.IndexOf(ctx.Intersections[0].IntersectionPoint);
			Point2D p = ctx.Poly1[num];
			int num2 = num;
			int num3 = -1;
			intersect.Clear();
			while (!intersect.Contains(point2DList[num]))
			{
				intersect.Add(point2DList[num]);
				foreach (EdgeIntersectInfo intersection in ctx.Intersections)
				{
					if (!point2DList[num].Equals(intersection.IntersectionPoint, point2DList.Epsilon))
					{
						continue;
					}
					int num4 = point2DList2.IndexOf(intersection.IntersectionPoint);
					int index = point2DList2.NextIndex(num4);
					Point2D point = point2DList2[index];
					bool flag;
					if (list[index] == -1)
					{
						flag = PolygonOperationContext.PointInPolygonAngle(point, point2DList);
						list[index] = (flag ? 1 : 0);
					}
					else
					{
						flag = list[index] == 1;
					}
					if (!flag)
					{
						continue;
					}
					if (point2DList == ctx.Poly1)
					{
						point2DList = ctx.Poly2;
						list = ctx.Poly2VectorAngles;
						point2DList2 = ctx.Poly1;
						if (num3 < 0)
						{
							num3 = num4;
						}
					}
					else
					{
						point2DList = ctx.Poly1;
						list = ctx.Poly1VectorAngles;
						point2DList2 = ctx.Poly2;
					}
					num = num4;
					break;
				}
				num = point2DList.NextIndex(num);
				if (point2DList == ctx.Poly1)
				{
					if (num == num2)
					{
						break;
					}
				}
				else if (num3 >= 0 && num == num3)
				{
					break;
				}
				if (!point2DList[num].Equals(p) || intersect.Count > ctx.Poly1.Count + ctx.Poly2.Count)
				{
					break;
				}
			}
			if (intersect.Count > ctx.Poly1.Count + ctx.Poly2.Count)
			{
				ctx.Error = PolyUnionError.InfiniteLoop;
			}
		}

		public static PolyUnionError PolygonSubtract(Point2DList polygon1, Point2DList polygon2, out Point2DList subtract)
		{
			PolygonOperationContext polygonOperationContext = new PolygonOperationContext();
			polygonOperationContext.Init(PolyOperation.Subtract, polygon1, polygon2);
			PolygonSubtractInternal(polygonOperationContext);
			subtract = polygonOperationContext.Subtract;
			return polygonOperationContext.Error;
		}

		private static void PolygonSubtractInternal(PolygonOperationContext ctx)
		{
			Point2DList subtract = ctx.Subtract;
			if (ctx.StartingIndex == -1)
			{
				PolyUnionError error = ctx.Error;
				if ((uint)(error - 1) <= 2u)
				{
					return;
				}
			}
			Point2DList point2DList = ctx.Poly1;
			Point2DList point2DList2 = ctx.Poly2;
			List<int> list = ctx.Poly1VectorAngles;
			Point2D p = ctx.Poly1[ctx.StartingIndex];
			int index = ctx.StartingIndex;
			subtract.Clear();
			bool flag = true;
			do
			{
				subtract.Add(point2DList[index]);
				foreach (EdgeIntersectInfo intersection in ctx.Intersections)
				{
					if (!point2DList[index].Equals(intersection.IntersectionPoint, point2DList.Epsilon))
					{
						continue;
					}
					int num = point2DList2.IndexOf(intersection.IntersectionPoint);
					if (flag)
					{
						int index2 = point2DList2.PreviousIndex(num);
						Point2D point = point2DList2[index2];
						bool flag2;
						if (list[index2] == -1)
						{
							flag2 = PolygonOperationContext.PointInPolygonAngle(point, point2DList);
							list[index2] = (flag2 ? 1 : 0);
						}
						else
						{
							flag2 = list[index2] == 1;
						}
						if (flag2)
						{
							if (point2DList == ctx.Poly1)
							{
								point2DList = ctx.Poly2;
								list = ctx.Poly2VectorAngles;
								point2DList2 = ctx.Poly1;
							}
							else
							{
								point2DList = ctx.Poly1;
								list = ctx.Poly1VectorAngles;
								point2DList2 = ctx.Poly2;
							}
							index = num;
							flag = false;
							break;
						}
						continue;
					}
					int index3 = point2DList2.NextIndex(num);
					Point2D point2 = point2DList2[index3];
					bool flag3;
					if (list[index3] == -1)
					{
						flag3 = PolygonOperationContext.PointInPolygonAngle(point2, point2DList);
						list[index3] = (flag3 ? 1 : 0);
					}
					else
					{
						flag3 = list[index3] == 1;
					}
					if (!flag3)
					{
						if (point2DList == ctx.Poly1)
						{
							point2DList = ctx.Poly2;
							list = ctx.Poly2VectorAngles;
							point2DList2 = ctx.Poly1;
						}
						else
						{
							point2DList = ctx.Poly1;
							list = ctx.Poly1VectorAngles;
							point2DList2 = ctx.Poly2;
						}
						index = num;
						flag = true;
						break;
					}
				}
				index = (flag ? point2DList.NextIndex(index) : point2DList.PreviousIndex(index));
			}
			while (point2DList[index].Equals(p) && subtract.Count <= ctx.Poly1.Count + ctx.Poly2.Count);
			if (subtract.Count > ctx.Poly1.Count + ctx.Poly2.Count)
			{
				ctx.Error = PolyUnionError.InfiniteLoop;
			}
		}

		public static PolyUnionError PolygonOperation(PolyOperation operations, Point2DList polygon1, Point2DList polygon2, out Dictionary<uint, Point2DList> results)
		{
			PolygonOperationContext polygonOperationContext = new PolygonOperationContext();
			polygonOperationContext.Init(operations, polygon1, polygon2);
			results = polygonOperationContext.Output;
			return PolygonOperation(polygonOperationContext);
		}

		public static PolyUnionError PolygonOperation(PolygonOperationContext ctx)
		{
			if ((ctx.Operations & PolyOperation.Union) == PolyOperation.Union)
			{
				PolygonUnionInternal(ctx);
			}
			if ((ctx.Operations & PolyOperation.Intersect) == PolyOperation.Intersect)
			{
				PolygonIntersectInternal(ctx);
			}
			if ((ctx.Operations & PolyOperation.Subtract) == PolyOperation.Subtract)
			{
				PolygonSubtractInternal(ctx);
			}
			return ctx.Error;
		}

		public static IEnumerable<Point2DList> SplitComplexPolygon(Point2DList verts, double epsilon)
		{
			int count = verts.Count;
			List<SplitComplexPolygonNode> list = verts.Select((Point2D t) => new SplitComplexPolygonNode(new Point2D(t.X, t.Y))).ToList();
			for (int num = 0; num < verts.Count; num++)
			{
				int index = ((num != count - 1) ? (num + 1) : 0);
				int index2 = ((num == 0) ? (count - 1) : (num - 1));
				list[num].AddConnection(list[index]);
				list[num].AddConnection(list[index2]);
			}
			int num2 = list.Count;
			bool flag = true;
			while (flag)
			{
				flag = false;
				int num3 = 0;
				while (!flag && num3 < num2)
				{
					int num4 = 0;
					while (!flag && num4 < list[num3].NumConnected)
					{
						int num5 = 0;
						while (!flag && num5 < num2)
						{
							if (num5 != num3 && !(list[num5] == list[num3][num4]))
							{
								int num6 = 0;
								while (!flag && num6 < list[num5].NumConnected)
								{
									if (!(list[num5][num6] == list[num3][num4]) && !(list[num5][num6] == list[num3]))
									{
										Point2D pIntersectionPt = new Point2D();
										if (TriangulationUtil.LinesIntersect2D(list[num3].Position, list[num3][num4].Position, list[num5].Position, list[num5][num6].Position, true, true, true, ref pIntersectionPt, epsilon))
										{
											flag = true;
											SplitComplexPolygonNode splitComplexPolygonNode = new SplitComplexPolygonNode(pIntersectionPt);
											int num7 = list.IndexOf(splitComplexPolygonNode);
											if (num7 >= 0 && num7 < list.Count)
											{
												splitComplexPolygonNode = list[num7];
											}
											else
											{
												list.Add(splitComplexPolygonNode);
												num2 = list.Count;
											}
											SplitComplexPolygonNode splitComplexPolygonNode2 = list[num3];
											SplitComplexPolygonNode splitComplexPolygonNode3 = list[num3][num4];
											SplitComplexPolygonNode splitComplexPolygonNode4 = list[num5];
											SplitComplexPolygonNode splitComplexPolygonNode5 = list[num5][num6];
											splitComplexPolygonNode3.RemoveConnection(splitComplexPolygonNode2);
											splitComplexPolygonNode2.RemoveConnection(splitComplexPolygonNode3);
											splitComplexPolygonNode5.RemoveConnection(splitComplexPolygonNode4);
											splitComplexPolygonNode4.RemoveConnection(splitComplexPolygonNode5);
											if (!splitComplexPolygonNode.Position.Equals(splitComplexPolygonNode2.Position, epsilon))
											{
												splitComplexPolygonNode.AddConnection(splitComplexPolygonNode2);
												splitComplexPolygonNode2.AddConnection(splitComplexPolygonNode);
											}
											if (!splitComplexPolygonNode.Position.Equals(splitComplexPolygonNode4.Position, epsilon))
											{
												splitComplexPolygonNode.AddConnection(splitComplexPolygonNode4);
												splitComplexPolygonNode4.AddConnection(splitComplexPolygonNode);
											}
											if (!splitComplexPolygonNode.Position.Equals(splitComplexPolygonNode3.Position, epsilon))
											{
												splitComplexPolygonNode.AddConnection(splitComplexPolygonNode3);
												splitComplexPolygonNode3.AddConnection(splitComplexPolygonNode);
											}
											if (!splitComplexPolygonNode.Position.Equals(splitComplexPolygonNode5.Position, epsilon))
											{
												splitComplexPolygonNode.AddConnection(splitComplexPolygonNode5);
												splitComplexPolygonNode5.AddConnection(splitComplexPolygonNode);
											}
										}
									}
									num6++;
								}
							}
							num5++;
						}
						num4++;
					}
					num3++;
				}
			}
			bool flag2 = true;
			int num8 = num2;
			double num9 = epsilon * epsilon;
			while (flag2)
			{
				flag2 = false;
				for (int num10 = 0; num10 < num2; num10++)
				{
					if (list[num10].NumConnected == 0)
					{
						continue;
					}
					for (int num11 = num10 + 1; num11 < num2; num11++)
					{
						if (list[num11].NumConnected == 0 || !((list[num10].Position - list[num11].Position).MagnitudeSquared() <= num9))
						{
							continue;
						}
						if (num8 <= 3)
						{
							throw new Exception("Eliminated so many duplicate points that resulting polygon has < 3 vertices!");
						}
						num8--;
						flag2 = true;
						SplitComplexPolygonNode splitComplexPolygonNode6 = list[num10];
						SplitComplexPolygonNode splitComplexPolygonNode7 = list[num11];
						int numConnected = splitComplexPolygonNode7.NumConnected;
						for (int num12 = 0; num12 < numConnected; num12++)
						{
							SplitComplexPolygonNode splitComplexPolygonNode8 = splitComplexPolygonNode7[num12];
							if (splitComplexPolygonNode8 != splitComplexPolygonNode6)
							{
								splitComplexPolygonNode6.AddConnection(splitComplexPolygonNode8);
								splitComplexPolygonNode8.AddConnection(splitComplexPolygonNode6);
							}
							splitComplexPolygonNode8.RemoveConnection(splitComplexPolygonNode7);
						}
						splitComplexPolygonNode7.ClearConnections();
						list.RemoveAt(num11);
						num2--;
					}
				}
			}
			double num13 = double.MaxValue;
			double num14 = double.MinValue;
			int index3 = -1;
			for (int num15 = 0; num15 < num2; num15++)
			{
				if (list[num15].Position.Y < num13 && list[num15].NumConnected > 1)
				{
					num13 = list[num15].Position.Y;
					index3 = num15;
					num14 = list[num15].Position.X;
				}
				else if (list[num15].Position.Y == num13 && list[num15].Position.X > num14 && list[num15].NumConnected > 1)
				{
					index3 = num15;
					num14 = list[num15].Position.X;
				}
			}
			Point2D incomingDir = new Point2D(1.0, 0.0);
			List<Point2D> list2 = new List<Point2D>();
			SplitComplexPolygonNode splitComplexPolygonNode9 = list[index3];
			SplitComplexPolygonNode splitComplexPolygonNode10 = splitComplexPolygonNode9;
			SplitComplexPolygonNode rightestConnection = splitComplexPolygonNode9.GetRightestConnection(incomingDir);
			if (rightestConnection == null)
			{
				return SplitComplexPolygonCleanup(verts);
			}
			list2.Add(splitComplexPolygonNode10.Position);
			while (rightestConnection != splitComplexPolygonNode10)
			{
				if (list2.Count > 4 * num2)
				{
					throw new Exception("nodes should never be visited four times apiece (proof?), so we've probably hit a loop...crap");
				}
				list2.Add(rightestConnection.Position);
				SplitComplexPolygonNode incoming = splitComplexPolygonNode9;
				splitComplexPolygonNode9 = rightestConnection;
				rightestConnection = splitComplexPolygonNode9.GetRightestConnection(incoming);
				if (rightestConnection == null)
				{
					return SplitComplexPolygonCleanup(list2);
				}
			}
			if (list2.Count < 1)
			{
				return SplitComplexPolygonCleanup(verts);
			}
			return SplitComplexPolygonCleanup(list2);
		}

		private static IEnumerable<Point2DList> SplitComplexPolygonCleanup(IEnumerable<Point2D> orig)
		{
			List<Point2DList> list = new List<Point2DList>();
			Point2DList point2DList = new Point2DList();
			point2DList.AddRange(orig);
			list.Add(point2DList);
			int i = 0;
			for (int num = list.Count; i < num; i++)
			{
				int num2 = list[i].Count;
				for (int j = 0; j < num2; j++)
				{
					for (int k = j + 1; k < num2; k++)
					{
						if (list[i][j].Equals(list[i][k], point2DList.Epsilon))
						{
							int num3 = k - j;
							Point2DList point2DList2 = new Point2DList();
							for (int l = j + 1; l <= k; l++)
							{
								point2DList2.Add(list[i][l]);
							}
							list[i].RemoveRange(j + 1, num3);
							list.Add(point2DList2);
							num++;
							num2 -= num3;
							k = j + 1;
						}
					}
				}
				list[i].Simplify();
			}
			return list;
		}
	}
}
