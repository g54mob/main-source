namespace Polygon2DTriangulation
{
	public class TriangulationUtil
	{
		public static bool SmartIncircle(Point2D pa, Point2D pb, Point2D pc, Point2D pd)
		{
			return false;
		}

		public static bool InScanArea(Point2D pa, Point2D pb, Point2D pc, Point2D pd)
		{
			return false;
		}

		public static Orientation Orient2d(Point2D pa, Point2D pb, Point2D pc)
		{
			return default(Orientation);
		}

		public static bool PointInBoundingBox(double xmin, double xmax, double ymin, double ymax, Point2D p)
		{
			return false;
		}

		public static bool PointOnLineSegment2D(Point2D lineStart, Point2D lineEnd, Point2D p, double epsilon)
		{
			return false;
		}

		public static bool PointOnLineSegment2D(double x1, double y1, double x2, double y2, double x, double y, double epsilon)
		{
			return false;
		}

		public static bool RectsIntersect(Rect2D r1, Rect2D r2)
		{
			return false;
		}

		public static bool LinesIntersect2D(Point2D ptStart0, Point2D ptEnd0, Point2D ptStart1, Point2D ptEnd1, bool firstIsSegment, bool secondIsSegment, bool coincidentEndPointCollisions, ref Point2D pIntersectionPt, double epsilon)
		{
			return false;
		}

		public static bool LinesIntersect2D(Point2D ptStart0, Point2D ptEnd0, Point2D ptStart1, Point2D ptEnd1, ref Point2D pIntersectionPt, double epsilon)
		{
			return false;
		}

		public static double LI2DDotProduct(Point2D v0, Point2D v1)
		{
			return 0.0;
		}

		public static bool RaysIntersect2D(Point2D ptRayOrigin0, Point2D ptRayVector0, Point2D ptRayOrigin1, Point2D ptRayVector1, ref Point2D ptIntersection)
		{
			return false;
		}
	}
}
