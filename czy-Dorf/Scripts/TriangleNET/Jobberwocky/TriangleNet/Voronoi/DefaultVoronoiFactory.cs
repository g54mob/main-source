using Jobberwocky.TriangleNet.Geometry;
using Jobberwocky.TriangleNet.Topology.DCEL;

namespace Jobberwocky.TriangleNet.Voronoi
{
	public class DefaultVoronoiFactory : IVoronoiFactory
	{
		public void Initialize(int vertexCount, int edgeCount, int faceCount)
		{
		}

		public Jobberwocky.TriangleNet.Topology.DCEL.Vertex CreateVertex(double x, double y)
		{
			return new Jobberwocky.TriangleNet.Topology.DCEL.Vertex(x, y);
		}

		public HalfEdge CreateHalfEdge(Jobberwocky.TriangleNet.Topology.DCEL.Vertex origin, Face face)
		{
			return new HalfEdge(origin, face);
		}

		public Face CreateFace(Jobberwocky.TriangleNet.Geometry.Vertex vertex)
		{
			return new Face(vertex);
		}
	}
}
