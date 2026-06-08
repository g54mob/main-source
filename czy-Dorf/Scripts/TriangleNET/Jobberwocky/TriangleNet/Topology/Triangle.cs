using Jobberwocky.TriangleNet.Geometry;

namespace Jobberwocky.TriangleNet.Topology
{
	public class Triangle : ITriangle
	{
		internal int hash;

		internal int id;

		internal Otri[] neighbors;

		internal Vertex[] vertices;

		internal Osub[] subsegs;

		internal int label;

		internal double area;

		internal bool infected;

		public Triangle()
		{
			vertices = new Vertex[3];
			subsegs = new Osub[3];
			neighbors = new Otri[3];
		}

		public Vertex GetVertex(int index)
		{
			return vertices[index];
		}

		public int GetVertexID(int index)
		{
			return vertices[index].id;
		}

		public override int GetHashCode()
		{
			return hash;
		}

		public override string ToString()
		{
			return $"TID {hash}";
		}
	}
}
