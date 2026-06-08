namespace Jobberwocky.TriangleNet.Geometry
{
	public interface ISegment : IEdge
	{
		Vertex GetVertex(int index);
	}
}
