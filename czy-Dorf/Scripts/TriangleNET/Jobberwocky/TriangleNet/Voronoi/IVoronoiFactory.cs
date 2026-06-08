using Jobberwocky.TriangleNet.Geometry;
using Jobberwocky.TriangleNet.Topology.DCEL;

namespace Jobberwocky.TriangleNet.Voronoi
{
	public interface IVoronoiFactory
	{
		void Initialize(int vertexCount, int edgeCount, int faceCount);

		Jobberwocky.TriangleNet.Topology.DCEL.Vertex CreateVertex(double x, double y);

		HalfEdge CreateHalfEdge(Jobberwocky.TriangleNet.Topology.DCEL.Vertex origin, Face face);

		Face CreateFace(Jobberwocky.TriangleNet.Geometry.Vertex vertex);
	}
}
