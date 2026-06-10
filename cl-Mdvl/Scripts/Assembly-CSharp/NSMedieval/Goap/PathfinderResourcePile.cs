using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.Views.Resources;
using NSMedieval.Village;

namespace NSMedieval.Goap
{
	public static class PathfinderResourcePile
	{
		public static List<TargetObject> FindPiles(IPathfindingAgent agent, Func<ResourcePileInstance, bool> condition)
		{
			ResourcePileManager instance = MonoSingleton<ResourcePileManager>.Instance;
			List<WorldObject> list = ListPool<WorldObject>.Get(instance.GetPilesCount());
			foreach (KeyValuePair<ResourcePileInstance, ResourcePileView> allPile in instance.AllPiles)
			{
				ResourcePileInstance key = allPile.Key;
				if (!key.IsForbidden && !key.HasDisposed && condition(key))
				{
					list.Add(key);
				}
			}
			List<TargetObject> result = PathfinderMedieval.FindMedievalObjects<ResourcePileInstance>(agent, list);
			ListPool<WorldObject>.Return(list);
			return result;
		}

		public static List<TargetObject> FindCategoryPiles(IPathfindingAgent agent, ResourceCategory category, Func<ResourcePileInstance, bool> filter = null, bool includeForbiden = false)
		{
			List<WorldObject> targets = PathfinderCore.FetchList(GridDataType.ResourcePile);
			return PathfinderMedieval.FindMedievalObjects(agent, targets, (ResourcePileInstance pile) => (pile.Blueprint.Category & category) != ResourceCategory.None && (includeForbiden || !pile.IsForbidden) && (filter == null || filter(pile)));
		}

		public static List<TargetObject> FindHumanCarcasses(IPathfindingAgent agent, Func<ResourcePileInstance, bool> condition = null)
		{
			List<WorldObject> targets = (from item in PathfinderCore.FetchList(GridDataType.ResourcePile)
				where item is HumanCarcassPileInstance
				select item).ToList();
			return PathfinderMedieval.FindMedievalObjects(agent, targets, condition);
		}

		public static List<TargetObject> FindHumanCarcassesForStripping(IPathfindingAgent agent, Func<ResourcePileInstance, bool> condition = null)
		{
			List<WorldObject> targets = (from item in PathfinderCore.FetchList(GridDataType.ResourcePile)
				where item is HumanCarcassPileInstance humanCarcassPileInstance && humanCarcassPileInstance.MarkedForStripping
				select item).ToList();
			return PathfinderMedieval.FindMedievalObjects(agent, targets, condition);
		}
	}
}
