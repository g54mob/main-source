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
			hasher = default(DrawingData.Hasher);
			debugData = active.debugPathData;
			includePathSearchInfo = debugData != null && (active.debugMode == GraphDebugMode.F || active.debugMode == GraphDebugMode.G || active.debugMode == GraphDebugMode.H || active.showSearchTree);
			includeAreaInfo = active.debugMode == GraphDebugMode.Areas;
			includeHierarchicalNodeInfo = active.debugMode == GraphDebugMode.HierarchicalNode;
			hasher.Add(active.debugMode);
			hasher.Add(active.debugFloor);
			hasher.Add(active.debugRoof);
			hasher.Add(AstarColor.ColorHash());
		}

		public void HashNode(GraphNode node)
		{
			hasher.Add(node.GetGizmoHashCode());
			if (includeAreaInfo)
			{
				hasher.Add((int)node.Area);
			}
			if (includeHierarchicalNodeInfo)
			{
				hasher.Add(node.HierarchicalNodeIndex);
			}
			if (includePathSearchInfo)
			{
				PathNode pathNode = debugData.pathNodes[node.NodeIndex];
				hasher.Add(pathNode.pathID);
				hasher.Add(pathNode.pathID == debugData.PathID);
			}
		}

		public void Add<T>(T v)
		{
			hasher.Add(v);
		}

		public static implicit operator DrawingData.Hasher(NodeHasher hasher)
		{
			return hasher.hasher;
		}
	}
}
