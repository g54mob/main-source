namespace Pathfinding
{
	public static class DefaultITraversalProvider
	{
		public static bool CanTraverse(Path path, GraphNode node)
		{
			return false;
		}

		public static uint GetTraversalCost(Path path, GraphNode node)
		{
			return 0u;
		}
	}
}
