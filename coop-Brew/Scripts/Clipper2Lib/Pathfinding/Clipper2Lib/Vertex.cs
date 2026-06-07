namespace Pathfinding.Clipper2Lib
{
	internal class Vertex
	{
		public Point64 pt;

		public Vertex? next;

		public Vertex? prev;

		public VertexFlags flags;

		public Vertex(Point64 pt, VertexFlags flags, Vertex? prev)
		{
		}
	}
}
