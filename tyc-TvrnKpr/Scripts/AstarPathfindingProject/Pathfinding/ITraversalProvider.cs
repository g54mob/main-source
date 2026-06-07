using System;

namespace Pathfinding
{
	public interface ITraversalProvider
	{
		bool filterDiagonalGridConnections => false;

		bool CanTraverse(ref TraversalConstraint traversalConstraint, GraphNode node)
		{
			return false;
		}

		bool CanTraverse(ref TraversalConstraint traversalConstraint, GraphNode from, GraphNode to)
		{
			return false;
		}

		uint GetConnectionCost(ref TraversalCosts traversalCosts, GraphNode from, GraphNode to)
		{
			return 0u;
		}

		float GetTraversalCostMultiplier(ref TraversalCosts traversalCosts, GraphNode node)
		{
			return 0f;
		}

		[Obsolete("Use CanTraverse(ref TraversalConstraint, GraphNode, GraphNode) instead")]
		bool CanTraverse(Path path, GraphNode from, GraphNode to)
		{
			return false;
		}

		[Obsolete("Use CanTraverse(ref TraversalConstraint, GraphNode) instead")]
		bool CanTraverse(Path path, GraphNode node)
		{
			return false;
		}

		[Obsolete("Use GetTraversalCostMultiplier(ref TraversalCosts, GraphNode) instead")]
		uint GetTraversalCost(Path path, GraphNode node)
		{
			return 0u;
		}
	}
}
