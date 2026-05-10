using System.Collections.Generic;

namespace Pathfinding.Poly2Tri
{
	public class Polygon : Triangulatable
	{
		protected List<TriangulationPoint> _points;

		protected List<TriangulationPoint> _steinerPoints;

		protected List<Polygon> _holes;

		protected List<DelaunayTriangle> _triangles;

		protected PolygonPoint _last;

		public TriangulationMode TriangulationMode => default(TriangulationMode);

		public IList<TriangulationPoint> Points => null;

		public IList<DelaunayTriangle> Triangles => null;

		public IList<Polygon> Holes => null;

		public Polygon(IList<PolygonPoint> points)
		{
		}

		public Polygon(params PolygonPoint[] points)
		{
		}

		public void AddSteinerPoint(TriangulationPoint point)
		{
		}

		public void AddSteinerPoints(List<TriangulationPoint> points)
		{
		}

		public void ClearSteinerPoints()
		{
		}

		public void AddHole(Polygon poly)
		{
		}

		public void InsertPointAfter(PolygonPoint point, PolygonPoint newPoint)
		{
		}

		public void AddPoints(IEnumerable<PolygonPoint> list)
		{
		}

		public void AddPoint(PolygonPoint p)
		{
		}

		public void RemovePoint(PolygonPoint p)
		{
		}

		public void AddTriangle(DelaunayTriangle t)
		{
		}

		public void AddTriangles(IEnumerable<DelaunayTriangle> list)
		{
		}

		public void ClearTriangles()
		{
		}

		public void Prepare(TriangulationContext tcx)
		{
		}
	}
}
