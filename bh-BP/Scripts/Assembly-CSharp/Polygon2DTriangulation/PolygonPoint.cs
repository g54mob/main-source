namespace Polygon2DTriangulation
{
	public class PolygonPoint : TriangulationPoint
	{
		public PolygonPoint Next { get; set; }

		public PolygonPoint Previous { get; set; }

		public PolygonPoint(double x, double y)
			: base(0.0, 0.0)
		{
		}

		public static Point2D ToBasePoint(PolygonPoint p)
		{
			return null;
		}

		public static TriangulationPoint ToTriangulationPoint(PolygonPoint p)
		{
			return null;
		}
	}
}
