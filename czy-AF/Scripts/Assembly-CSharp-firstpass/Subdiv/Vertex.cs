using System.Collections.Generic;
using UnityEngine;

namespace Subdiv
{
	public class Vertex
	{
		public Vector3 p;

		public List<Edge> edges;

		public List<Triangle> triangles;

		public Vertex updated;

		public int index;

		public Vertex(Vector3 p)
			: this(p, -1)
		{
		}

		public Vertex(Vector3 p, int index)
		{
			this.p = p;
			this.index = index;
			edges = new List<Edge>();
			triangles = new List<Triangle>();
		}

		public void AddEdge(Edge e)
		{
			edges.Add(e);
		}

		public void AddTriangle(Triangle f)
		{
			triangles.Add(f);
		}
	}
}
