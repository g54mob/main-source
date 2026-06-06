using Pathfinding.Drawing;

namespace Pathfinding.Util
{
	public struct NodeHasher
	{
		private readonly bool includePathSearchInfo;

		private readonly bool includeAreaInfo;

		private readonly bool includeHierarchicalNodeInfo;

		private readonly PathHandler debugData;

		public DrawingData.Hasher hasher;

		public NodeHasher(AstarPath active)
		{
			includePathSearchInfo = false;
			includeAreaInfo = false;
			includeHierarchicalNodeInfo = false;
			debugData = null;
			hasher = default(DrawingData.Hasher);
		}

		public void HashNode(GraphNode node)
		{
		}

		public void Add<T>(T v)
		{
		}

		public static implicit operator DrawingData.Hasher(NodeHasher hasher)
		{
			return default(DrawingData.Hasher);
		}
	}
}
