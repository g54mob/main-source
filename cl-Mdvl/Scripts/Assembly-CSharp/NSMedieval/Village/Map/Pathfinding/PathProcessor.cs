using System.Collections.Generic;
using NSMedieval.Goap;
using NSMedieval.Tools;

namespace NSMedieval.Village.Map.Pathfinding
{
	public class PathProcessor
	{
		private const int OpenNodesHeapInitialSize = 512;

		private BinaryHeap openNodes;

		private readonly HashSet<int> closedNodes;

		private Path currentPath;

		private Dictionary<int, PathSearchNode> searchNodePool;

		internal BinaryHeap OpenNodes => openNodes;

		internal HashSet<int> ClosedNodes => closedNodes;

		public PathProcessor()
		{
			openNodes = new BinaryHeap(512);
			closedNodes = new HashSet<int>();
			searchNodePool = new Dictionary<int, PathSearchNode>();
		}

		internal PathSearchNode GetSearchNode(Vec3Int pos)
		{
			return GetSearchNode(GridDataIndexTools.FastTo1DIndex(pos));
		}

		internal PathSearchNode GetSearchNode(int nodeIndex)
		{
			if (searchNodePool.TryGetValue(nodeIndex, out var value))
			{
				return value;
			}
			PathSearchNode pathSearchNode = PathSearchNodePool.Get();
			pathSearchNode.Node = currentPath.Map.GridSpaceData[nodeIndex];
			searchNodePool[nodeIndex] = pathSearchNode;
			return pathSearchNode;
		}

		internal void Reset()
		{
			foreach (PathSearchNode value in searchNodePool.Values)
			{
				value.TagA = false;
			}
		}

		public void ProcessPath(Path path)
		{
			IPathfindingAgent agent = path.Agent;
			if (agent?.PathDriver != null && agent.PathDriver.CurrentPath != null)
			{
				agent.Map?.AntiPathCrowdingManager?.OnAgentStopTraversingPath(agent.PathDriver, PathDriverCompletionState.Abort);
			}
			currentPath = path;
			openNodes.Clear();
			closedNodes.Clear();
			path.ExecuteInitialize(this);
			path.ExecutePathCalculations(this);
		}

		public void OnAbort()
		{
			searchNodePool.Clear();
			searchNodePool = null;
			currentPath = null;
			openNodes = null;
		}
	}
}
