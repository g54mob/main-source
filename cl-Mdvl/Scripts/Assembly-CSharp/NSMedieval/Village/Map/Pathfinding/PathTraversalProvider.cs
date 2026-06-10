using NSMedieval.Model;

namespace NSMedieval.Village.Map.Pathfinding
{
	public class PathTraversalProvider
	{
		public static readonly PathTraversalProvider DefaultProvider = new PathTraversalProvider(null);

		private readonly PathfindingPenalty penaltyModel;

		private readonly bool isPenaltyModelSet;

		protected PathfindingPenalty PenaltyModel => penaltyModel;

		protected PathTraversalProvider(PathfindingPenalty penalty)
		{
			penaltyModel = penalty;
			isPenaltyModelSet = penaltyModel != null;
		}

		public virtual bool CanStandOnNode(MapNode node)
		{
			if (node.Map.WaterManager.CanDrown(node))
			{
				return false;
			}
			return node.IsWalkable;
		}

		public virtual bool CanTraverse(MapNode nodeTo, MapNode nodeFrom)
		{
			if (nodeTo.Map.WaterManager.CanDrown(nodeTo) || nodeFrom.Map.WaterManager.CanDrown(nodeFrom))
			{
				return false;
			}
			return nodeTo.IsWalkable;
		}

		public virtual bool CanStandOnRegion(Region region)
		{
			return true;
		}

		public virtual bool CanTraverse(Region regionTo, Region regionFrom)
		{
			return CanStandOnRegion(regionTo);
		}

		public virtual uint GetTraversalCost(MapNode start, MapNode destination)
		{
			if (!isPenaltyModelSet)
			{
				return 1000u;
			}
			return destination.GetPenalty(penaltyModel);
		}

		public MapNode GetNodeWithLowerTraversalCost(MapNode start, MapNode end1, MapNode end2)
		{
			if (GetTraversalCost(start, end1) >= GetTraversalCost(start, end2))
			{
				return end2;
			}
			return end1;
		}
	}
}
