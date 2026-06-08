using Jobberwocky.TriangleNet.Geometry;

namespace Jobberwocky.TriangleNet.Topology
{
	public class SubSegment : ISegment, IEdge
	{
		internal int hash;

		internal Osub[] subsegs;

		internal Vertex[] vertices;

		internal Otri[] triangles;

		internal int boundary;

		public int P0 => vertices[0].id;

		public int P1 => vertices[1].id;

		public int Label => boundary;

		public SubSegment()
		{
			vertices = new Vertex[4];
			boundary = 0;
			subsegs = new Osub[2];
			triangles = new Otri[2];
		}

		public Vertex GetVertex(int index)
		{
			return vertices[index];
		}

		public override int GetHashCode()
		{
			return hash;
		}

		public override string ToString()
		{
			return $"SID {hash}";
		}
	}
}
