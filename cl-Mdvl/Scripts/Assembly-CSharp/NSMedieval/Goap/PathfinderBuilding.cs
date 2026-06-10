using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Pathfinding;
using NSMedieval.Village;

namespace NSMedieval.Goap
{
	public static class PathfinderBuilding
	{
		public static List<TargetObject> FindDamaged(IPathfindingAgent agent, IEnumerable<BaseBuildingInstance> damagedBuildings)
		{
			if (damagedBuildings.Any())
			{
				return PathfinderMedieval.FindMedievalObjects<BaseBuildingInstance>(agent, damagedBuildings.Cast<WorldObject>().ToList());
			}
			return null;
		}

		public static List<TargetObject> FindAllMarkedForUninstall(IPathfindingAgent agent, Func<BaseBuildingInstance, bool> condition = null)
		{
			List<BaseBuildingInstance> list = MonoSingleton<ConstructablesGoapUninstallManager>.Instance.ObjectsToUninstall.ToList();
			if (list.Count == 0)
			{
				return null;
			}
			return PathfinderMedieval.FindMedievalObjects(agent, list.Cast<WorldObject>().ToList(), condition);
		}
	}
}
