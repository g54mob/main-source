namespace Pathfinding
{
	public static class DefaultITraversalProvider
	{
		public static bool CanTraverse(Path path, GraphNode node)
		{
			if (node.Walkable)
			{
				if (path != null)
				{
					return ((path.enabledTags >> (int)node.Tag) & 1) != 0;
				}
				return true;
			}
			return false;
		}

		public static uint GetTraversalCost(Path path, GraphNode node)
		{
			return node.Penalty + (path?.GetTagPenalty((int)node.Tag) ?? 0);
		}
	}
}
