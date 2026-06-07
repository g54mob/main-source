using System;
using System.Collections.Generic;
using Poly2Tri.Triangulation.Util;
using Poly2Tri.Utility;

namespace Poly2Tri.Triangulation.Polygon
{
	public class PolygonOperationContext
	{
		public PolygonUtil.PolyOperation Operations;

		public Point2DList OriginalPolygon2;

		public Point2DList Poly1;

		public Point2DList Poly2;

		public List<EdgeIntersectInfo> Intersections;

		public int StartingIndex;

		public PolygonUtil.PolyUnionError Error;

		public List<int> Poly1VectorAngles;

		public List<int> Poly2VectorAngles;

		public Dictionary<uint, Point2DList> Output = new Dictionary<uint, Point2DList>();

		public Point2DList Union
		{
			get
			{
				Point2DList value;
				if (!Output.TryGetValue(1u, out value))
				{
					value = new Point2DList();
					Output.Add(1u, value);
				}
				return value;
			}
		}

		public Point2DList Intersect
		{
			get
			{
				Point2DList value;
				if (!Output.TryGetValue(2u, out value))
				{
					value = new Point2DList();
					Output.Add(2u, value);
				}
				return value;
			}
		}

		public Point2DList Subtract
		{
			get
			{
				Point2DList value;
				if (!Output.TryGetValue(4u, out value))
				{
					value = new Point2DList();
					Output.Add(4u, value);
				}
				return value;
			}
		}

		public void Clear()
		{
			Operations = PolygonUtil.PolyOperation.None;
			OriginalPolygon2 = null;
			Poly1 = null;
			Poly2 = null;
			Intersections = null;
			StartingIndex = -1;
			Error = PolygonUtil.PolyUnionError.None;
			Poly1VectorAngles = null;
			Poly2VectorAngles = null;
			Output = new Dictionary<uint, Point2DList>();
		}

		public bool Init(PolygonUtil.PolyOperation operations, Point2DList polygon1, Point2DList polygon2)
		{
			Clear();
			Operations = operations;
			OriginalPolygon2 = polygon2;
			Poly1 = new Point2DList(polygon1)
			{
				WindingOrder = Point2DList.WindingOrderType.AntiClockwise
			};
			Poly2 = new Point2DList(polygon2)
			{
				WindingOrder = Point2DList.WindingOrderType.AntiClockwise
			};
			if (!VerticesIntersect(Poly1, Poly2, out Intersections))
			{
				Error = PolygonUtil.PolyUnionError.NoIntersections;
				return false;
			}
			int count = Intersections.Count;
			for (int i = 0; i < count; i++)
			{
				for (int j = i + 1; j < count; j++)
				{
					if (Intersections[i].EdgeOne.EdgeStart.Equals(Intersections[j].EdgeOne.EdgeStart) && Intersections[i].EdgeOne.EdgeEnd.Equals(Intersections[j].EdgeOne.EdgeEnd))
					{
						Intersections[j].EdgeOne.EdgeStart = Intersections[i].IntersectionPoint;
					}
					if (Intersections[i].EdgeTwo.EdgeStart.Equals(Intersections[j].EdgeTwo.EdgeStart) && Intersections[i].EdgeTwo.EdgeEnd.Equals(Intersections[j].EdgeTwo.EdgeEnd))
					{
						Intersections[j].EdgeTwo.EdgeStart = Intersections[i].IntersectionPoint;
					}
				}
			}
			foreach (EdgeIntersectInfo intersection in Intersections)
			{
				if (!Poly1.Contains(intersection.IntersectionPoint))
				{
					Poly1.Insert(Poly1.IndexOf(intersection.EdgeOne.EdgeStart) + 1, intersection.IntersectionPoint);
				}
				if (!Poly2.Contains(intersection.IntersectionPoint))
				{
					Poly2.Insert(Poly2.IndexOf(intersection.EdgeTwo.EdgeStart) + 1, intersection.IntersectionPoint);
				}
			}
			Poly1VectorAngles = new List<int>();
			for (int k = 0; k < Poly2.Count; k++)
			{
				Poly1VectorAngles.Add(-1);
			}
			Poly2VectorAngles = new List<int>();
			for (int l = 0; l < Poly1.Count; l++)
			{
				Poly2VectorAngles.Add(-1);
			}
			int num = 0;
			do
			{
				bool flag = PointInPolygonAngle(Poly1[num], Poly2);
				Poly2VectorAngles[num] = (flag ? 1 : 0);
				if (flag)
				{
					StartingIndex = num;
					break;
				}
				num = Poly1.NextIndex(num);
			}
			while (num != 0);
			if (StartingIndex == -1)
			{
				Error = PolygonUtil.PolyUnionError.Poly1InsidePoly2;
				return false;
			}
			return true;
		}

		private static bool VerticesIntersect(Point2DList polygon1, Point2DList polygon2, out List<EdgeIntersectInfo> intersections)
		{
			intersections = new List<EdgeIntersectInfo>();
			double epsilon = Math.Min(polygon1.Epsilon, polygon2.Epsilon);
			for (int i = 0; i < polygon1.Count; i++)
			{
				Point2D point2D = polygon1[i];
				Point2D point2D2 = polygon1[polygon1.NextIndex(i)];
				for (int j = 0; j < polygon2.Count; j++)
				{
					Point2D pIntersectionPt = new Point2D();
					Point2D point2D3 = polygon2[j];
					Point2D point2D4 = polygon2[polygon2.NextIndex(j)];
					if (TriangulationUtil.LinesIntersect2D(point2D, point2D2, point2D3, point2D4, ref pIntersectionPt, epsilon))
					{
						intersections.Add(new EdgeIntersectInfo(new Edge(point2D, point2D2), new Edge(point2D3, point2D4), pIntersectionPt));
					}
				}
			}
			return intersections.Count > 0;
		}

		public static bool PointInPolygonAngle(Point2D point, Point2DList polygon)
		{
			double num = 0.0;
			for (int i = 0; i < polygon.Count; i++)
			{
				Point2D p = polygon[i] - point;
				Point2D p2 = polygon[polygon.NextIndex(i)] - point;
				num += VectorAngle(p, p2);
			}
			if (Math.Abs(num) < Math.PI)
			{
				return false;
			}
			return true;
		}

		public static double VectorAngle(Point2D p1, Point2D p2)
		{
			double num = Math.Atan2(p1.Y, p1.X);
			double num2;
			for (num2 = Math.Atan2(p2.Y, p2.X) - num; num2 > Math.PI; num2 -= Math.PI * 2.0)
			{
			}
			for (; num2 < -Math.PI; num2 += Math.PI * 2.0)
			{
			}
			return num2;
		}
	}
}
