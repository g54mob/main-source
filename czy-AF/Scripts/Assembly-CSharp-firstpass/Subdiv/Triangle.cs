namespace Subdiv
{
	public class Triangle
	{
		public Vertex v0;

		public Vertex v1;

		public Vertex v2;

		public Edge e0;

		public Edge e1;

		public Edge e2;

		public Triangle(Vertex v0, Vertex v1, Vertex v2, Edge e0, Edge e1, Edge e2)
		{
			this.v0 = v0;
			this.v1 = v1;
			this.v2 = v2;
			this.e0 = e0;
			this.e1 = e1;
			this.e2 = e2;
		}

		public Vertex GetOtherVertex(Edge e)
		{
			if (!e.Has(v0))
			{
				return v0;
			}
			if (!e.Has(v1))
			{
				return v1;
			}
			return v2;
		}
	}
}
