using NSMedieval.BuildingComponents;
using NSMedieval.Manager;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;

namespace NSMedieval.Goap
{
	public static class PathfinderProduction
	{
		public static Vec3Int FindWorkPosition(IPathfindingAgent agent, ProductionComponentInstance obj)
		{
			if (CombatUtils.IsNullOrDisposed(agent) || obj == null)
			{
				return default(Vec3Int);
			}
			VillageMap map = obj.Map;
			PathTraversalProvider traversalProvider = agent?.PathTraversalProvider;
			uint area = agent.GetNode().Area;
			foreach (Vec3Int workplacePosition in obj.WorkplacePositions)
			{
				if (PathfinderUtil.IsAreaReachable(traversalProvider, map, area, map.GetNode(workplacePosition).Area))
				{
					return workplacePosition;
				}
			}
			return Vec3Int.zero;
		}
	}
}
