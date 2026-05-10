using System.Collections.Generic;

namespace Pathfinding.Poly2Tri
{
	public class PointSet : Triangulatable
	{
		public IList<TriangulationPoint> Points { get; private set; }

		public IList<DelaunayTriangle> Triangles { get; private set; }

		public virtual TriangulationMode TriangulationMode => default(TriangulationMode);

		public PointSet(List<TriangulationPoint> points)
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

		public virtual void Prepare(TriangulationContext tcx)
		{
		}
	}
}
