using Poly2Tri.Utility;

namespace Poly2Tri.Triangulation.Delaunay.Sweep
{
	public class DTSweepConstraint : TriangulationConstraint
	{
		public DTSweepConstraint(Point2D p1, Point2D p2)
			: base(p1, p2)
		{
			base.Q.AddEdge(this);
		}
	}
}
