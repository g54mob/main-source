using System.Collections.Generic;

namespace Pathfinding.Clipper2Lib
{
	internal struct VertexPool
	{
		private Stack<Vertex> stack;

		public VertexPool(int capacity)
		{
			stack = null;
		}

		public Vertex GetNew(Point64 pt, VertexFlags flags, Vertex? prev)
		{
			return null;
		}

		public void Pool(Vertex v)
		{
		}
	}
}
