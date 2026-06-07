using Poly2Tri.Utility;

namespace Poly2Tri.Triangulation
{
	public class Edge
	{
		public Point2D EdgeStart { get; set; }

		public Point2D EdgeEnd { get; set; }

		public Edge()
		{
			EdgeStart = null;
			EdgeEnd = null;
		}

		public Edge(Point2D edgeStart, Point2D edgeEnd)
		{
			EdgeStart = edgeStart;
			EdgeEnd = edgeEnd;
		}
	}
}
