using System.Collections.Generic;

namespace Pathfinding.Clipper2Lib
{
	public class ReuseableDataContainer64
	{
		internal readonly List<LocalMinima> _minimaList;

		internal readonly List<Vertex> _vertexList;

		internal readonly VertexPool _vertexPool;

		public void Clear()
		{
		}

		public void AddPaths(List<List<Point64>> paths, PathType pt, bool isOpen)
		{
		}
	}
}
