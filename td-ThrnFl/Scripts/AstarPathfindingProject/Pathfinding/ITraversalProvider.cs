namespace Pathfinding
{
	public interface ITraversalProvider
	{
		bool filterDiagonalGridConnections => true;

		bool CanTraverse(Path path, GraphNode node)
		{
			return DefaultITraversalProvider.CanTraverse(path, node);
		}

		bool CanTraverse(Path path, GraphNode from, GraphNode to)
		{
			return CanTraverse(path, to);
		}

		uint GetTraversalCost(Path path, GraphNode node)
		{
			return DefaultITraversalProvider.GetTraversalCost(path, node);
		}
	}
}
