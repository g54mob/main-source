using System.Collections.Generic;

namespace Polygon2DTriangulation
{
	public class PolygonOperationContext
	{
		public PolygonUtil.PolyOperation mOperations;

		public Point2DList mOriginalPolygon1;

		public Point2DList mOriginalPolygon2;

		public Point2DList mPoly1;

		public Point2DList mPoly2;

		public List<EdgeIntersectInfo> mIntersections;

		public int mStartingIndex;

		public PolygonUtil.PolyUnionError mError;

		public List<int> mPoly1VectorAngles;

		public List<int> mPoly2VectorAngles;

		public Dictionary<uint, Point2DList> mOutput;

		public Point2DList Union => null;

		public Point2DList Intersect => null;

		public Point2DList Subtract => null;

		public void Clear()
		{
		}

		public bool Init(PolygonUtil.PolyOperation operations, Point2DList polygon1, Point2DList polygon2)
		{
			return false;
		}

		private bool VerticesIntersect(Point2DList polygon1, Point2DList polygon2, out List<EdgeIntersectInfo> intersections)
		{
			intersections = null;
			return false;
		}

		public bool PointInPolygonAngle(Point2D point, Point2DList polygon)
		{
			return false;
		}

		public double VectorAngle(Point2D p1, Point2D p2)
		{
			return 0.0;
		}
	}
}
