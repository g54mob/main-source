using System.Collections.Generic;

namespace PolygonIntersection
{
	public class Polygon
	{
		private List<Vector> points;

		private List<Vector> edges;

		public List<Vector> Edges => null;

		public List<Vector> Points => null;

		public Vector Center => default(Vector);

		public static void Test()
		{
		}

		public void BuildEdges()
		{
		}

		public void Offset(Vector v)
		{
		}

		public void Offset(float x, float y)
		{
		}

		public static void ProjectPolygon(Vector axis, Polygon polygon, ref float min, ref float max)
		{
		}

		public static float IntervalDistance(float minA, float maxA, float minB, float maxB)
		{
			return 0f;
		}

		public static PolygonCollisionResult PolygonCollision(Polygon polygonA, Polygon polygonB)
		{
			return default(PolygonCollisionResult);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
