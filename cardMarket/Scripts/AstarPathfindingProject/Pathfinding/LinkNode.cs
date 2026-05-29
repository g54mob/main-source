namespace Pathfinding
{
	public class LinkNode : PointNode
	{
		public OffMeshLinks.OffMeshLinkSource linkSource;

		public OffMeshLinks.OffMeshLinkConcrete linkConcrete;

		public int nodeInGraphIndex;

		public LinkNode()
		{
		}

		public LinkNode(AstarPath active)
			: base(active)
		{
		}

		public override void RemovePartialConnection(GraphNode node)
		{
			linkConcrete.staleConnections = true;
			AstarPath.active.offMeshLinks.DirtyNoSchedule(linkSource);
			base.RemovePartialConnection(node);
		}

		public override void Open(Path path, uint pathNodeIndex, uint gScore)
		{
			if (connections == null)
			{
				return;
			}
			PathHandler pathHandler = ((IPathInternals)path).PathHandler;
			PathNode pathNode = pathHandler.pathNodes[pathNodeIndex];
			bool flag = !pathHandler.IsTemporaryNode(pathNode.parentIndex) && pathHandler.GetNode(pathNode.parentIndex).GraphIndex == base.GraphIndex;
			for (int i = 0; i < connections.Length; i++)
			{
				GraphNode node = connections[i].node;
				if (flag == (node.GraphIndex != base.GraphIndex) && path.CanTraverse(this, node))
				{
					if (node is PointNode)
					{
						path.OpenCandidateConnection(pathNodeIndex, node.NodeIndex, gScore, connections[i].cost, 0u, node.position);
					}
					else
					{
						node.OpenAtPoint(path, pathNodeIndex, position, gScore);
					}
				}
			}
		}

		public override void OpenAtPoint(Path path, uint pathNodeIndex, Int3 pos, uint gScore)
		{
			if (path.CanTraverse(this))
			{
				uint costMagnitude = (uint)(pos - position).costMagnitude;
				path.OpenCandidateConnection(pathNodeIndex, base.NodeIndex, gScore, costMagnitude, 0u, position);
			}
		}
	}
}
