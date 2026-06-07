using System;
using System.Collections.Generic;

namespace Polygon2DTriangulation
{
	public class PolygonUtil
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
			return default(Point2DList.WindingOrderType);
		}

		public static bool PolygonsAreSame2D(IList<Point2D> poly1, IList<Point2D> poly2)
		{
			return false;
		}

		public static bool PointInPolygon2D(IList<Point2D> polygon, Point2D p)
		{
			return false;
		}

		public static bool PolygonsIntersect2D(IList<Point2D> poly1, Rect2D boundRect1, IList<Point2D> poly2, Rect2D boundRect2)
		{
			return false;
		}

		public bool PolygonContainsPolygon(IList<Point2D> poly1, Rect2D boundRect1, IList<Point2D> poly2, Rect2D boundRect2)
		{
			return false;
		}

		public static bool PolygonContainsPolygon(IList<Point2D> poly1, Rect2D boundRect1, IList<Point2D> poly2, Rect2D boundRect2, bool runIntersectionTest)
		{
			return false;
		}

		public static void ClipPolygonToEdge2D(Point2D edgeBegin, Point2D edgeEnd, IList<Point2D> poly, out List<Point2D> outPoly)
		{
			outPoly = null;
		}

		public static void ClipPolygonToPolygon(IList<Point2D> poly, IList<Point2D> clipPoly, out List<Point2D> outPoly)
		{
			outPoly = null;
		}

		public static PolyUnionError PolygonUnion(Point2DList polygon1, Point2DList polygon2, out Point2DList union)
		{
			union = null;
			return default(PolyUnionError);
		}

		protected static void PolygonUnionInternal(PolygonOperationContext ctx)
		{
		}

		public static PolyUnionError PolygonIntersect(Point2DList polygon1, Point2DList polygon2, out Point2DList intersectOut)
		{
			intersectOut = null;
			return default(PolyUnionError);
		}

		protected static void PolygonIntersectInternal(PolygonOperationContext ctx)
		{
		}

		public static PolyUnionError PolygonSubtract(Point2DList polygon1, Point2DList polygon2, out Point2DList subtract)
		{
			subtract = null;
			return default(PolyUnionError);
		}

		public static void PolygonSubtractInternal(PolygonOperationContext ctx)
		{
		}

		public static PolyUnionError PolygonOperation(PolyOperation operations, Point2DList polygon1, Point2DList polygon2, out Dictionary<uint, Point2DList> results)
		{
			results = null;
			return default(PolyUnionError);
		}

		public static PolyUnionError PolygonOperation(PolygonOperationContext ctx)
		{
			return default(PolyUnionError);
		}

		public static List<Point2DList> SplitComplexPolygon(Point2DList verts, double epsilon)
		{
			return null;
		}

		private static List<Point2DList> SplitComplexPolygonCleanup(IList<Point2D> orig)
		{
			return null;
		}
	}
}
