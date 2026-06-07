namespace Pathfinding
{
	public interface ITraversalProvider
	{
		bool filterDiagonalGridConnections => false;

		bool CanTraverse(Path path, GraphNode node)
		{
			return false;
		}

		bool CanTraverse(Path path, GraphNode from, GraphNode to)
		{
			return false;
		}

		uint GetTraversalCost(Path path, GraphNode node)
		{
			return 0u;
		}
	}
}
