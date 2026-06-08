using System.Collections.Generic;
using Jobberwocky.TriangleNet.Geometry;

namespace Jobberwocky.TriangleNet.Topology.DCEL
{
	public class DcelMesh
	{
		protected List<Vertex> vertices;

		protected List<HalfEdge> edges;

		protected List<Face> faces;

		public List<Vertex> Vertices => vertices;

		public List<HalfEdge> HalfEdges => edges;

		public List<Face> Faces => faces;

		public IEnumerable<IEdge> Edges => EnumerateEdges();

		protected DcelMesh(bool initialize)
		{
			if (initialize)
			{
				vertices = new List<Vertex>();
				edges = new List<HalfEdge>();
				faces = new List<Face>();
			}
		}

		public void ResolveBoundaryEdges()
		{
			Dictionary<int, HalfEdge> dictionary = new Dictionary<int, HalfEdge>();
			foreach (HalfEdge edge in edges)
			{
				if (edge.twin == null)
				{
					HalfEdge halfEdge = (edge.twin = new HalfEdge(edge.next.origin, Face.Empty));
					halfEdge.twin = edge;
					dictionary.Add(halfEdge.origin.id, halfEdge);
				}
			}
			int count = edges.Count;
			foreach (HalfEdge value in dictionary.Values)
			{
				value.id = count++;
				value.next = dictionary[value.twin.origin.id];
				edges.Add(value);
			}
		}

		protected virtual IEnumerable<IEdge> EnumerateEdges()
		{
			List<IEdge> list = new List<IEdge>(edges.Count / 2);
			foreach (HalfEdge edge in edges)
			{
				HalfEdge twin = edge.twin;
				if (edge.id < twin.id)
				{
					list.Add(new Edge(edge.origin.id, twin.origin.id));
				}
			}
			return list;
		}
	}
}
