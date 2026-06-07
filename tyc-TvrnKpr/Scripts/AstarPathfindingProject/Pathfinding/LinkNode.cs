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
		{
		}

		public override void RemovePartialConnection(GraphNode node)
		{
		}

		public override void Open(ref Path.SearchContext ctx, uint pathNodeIndex, uint gScore)
		{
		}

		public override void OpenAtPoint(ref Path.SearchContext ctx, uint pathNodeIndex, Int3 pos, uint gScore)
		{
		}
	}
}
