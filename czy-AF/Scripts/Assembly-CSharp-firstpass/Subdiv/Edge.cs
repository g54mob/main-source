using System.Collections.Generic;

namespace Subdiv
{
	public class Edge
	{
		public Vertex a;

		public Vertex b;

		public List<Triangle> faces;

		public Vertex ept;

		public Edge(Vertex a, Vertex b)
		{
			this.a = a;
			this.b = b;
			faces = new List<Triangle>();
		}

		public void AddTriangle(Triangle f)
		{
			faces.Add(f);
		}

		public bool Has(Vertex v)
		{
			if (v != a)
			{
				return v == b;
			}
			return true;
		}

		public Vertex GetOtherVertex(Vertex v)
		{
			if (a != v)
			{
				return a;
			}
			return b;
		}
	}
}
