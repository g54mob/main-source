using System.Runtime.CompilerServices;

namespace Pathfinding
{
	public static class DefaultITraversalProvider
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool CanTraverse(ref TraversalConstraint traversalConstraint, GraphNode node)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float GetTraversalCostMultiplier(ref TraversalCosts traversalCosts, GraphNode node)
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint GetConnectionCost(ref TraversalCosts traversalCosts, GraphNode from, GraphNode to)
		{
			return 0u;
		}
	}
}
