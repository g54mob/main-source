using Jobberwocky.TriangleNet.Geometry;

namespace Jobberwocky.TriangleNet.Topology.DCEL
{
	public class Vertex : Point
	{
		internal HalfEdge leaving;

		public Vertex(double x, double y)
			: base(x, y)
		{
		}

		public override string ToString()
		{
			return $"V-ID {id}";
		}
	}
}
