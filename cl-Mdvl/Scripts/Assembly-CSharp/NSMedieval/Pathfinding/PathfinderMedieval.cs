using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.Utils.Pool;
using NSMedieval.Village;
using NSMedieval.Village.Map.Pathfinding;

namespace NSMedieval.Pathfinding
{
	public static class PathfinderMedieval
	{
		internal static bool ExploreForObjects(ExploreRequest request)
		{
			P2RegionReservableWoExplorerPath p2RegionReservableWoExplorerPath = P2RegionReservableWoExplorerPath.Construct(request.Agent, (request.StartPosOverride == Vec3Int.zero) ? request.StartPosOverride : request.Agent.GetGridPosition(), request.GridData, WorldObjectType.None, request.DoQuickSearch, request.Condition, request.OnFound);
			if (p2RegionReservableWoExplorerPath.Map.GetObjectCount(request.GridData) == 0)
			{
				return false;
			}
			MonoSingleton<PathProcessorManager>.Instance.InstantProcessPath(p2RegionReservableWoExplorerPath);
			if (p2RegionReservableWoExplorerPath.State != PathState.Calculated)
			{
				Path.ReleasePath(p2RegionReservableWoExplorerPath);
				return false;
			}
			Path.ReleasePath(p2RegionReservableWoExplorerPath);
			return true;
		}

		internal static List<TargetObject> FindMedievalObjects<T>(IPathfindingAgent agent, List<WorldObject> targets, Func<T, bool> condition = null, int endHitCount = 100, bool shouldSort = false) where T : WorldObject
		{
			if (targets.Count > 65533)
			{
				Log.Error("This is unsuported!", "C:\\GIT\\dev\\Assets\\Scripts\\PathFinding\\PathfinderMedieval.cs");
				return null;
			}
			bool flag = false;
			if (condition != null)
			{
				List<WorldObject> list = null;
				foreach (WorldObject item in targets.Where((WorldObject item) => condition((T)item)))
				{
					if (list == null)
					{
						list = ListPool<WorldObject>.Get();
						flag = true;
					}
					list.Add(item);
				}
				targets = list;
			}
			if (targets == null || targets.Count == 0)
			{
				if (flag)
				{
					ListPool<WorldObject>.Return(targets);
				}
				return null;
			}
			P2WorldObjectPath p2WorldObjectPath = P2WorldObjectPath.Construct(agent, endHitCount, targets, shouldSort);
			MonoSingleton<PathProcessorManager>.Instance.InstantProcessPath(p2WorldObjectPath);
			if (flag)
			{
				ListPool<WorldObject>.Return(targets);
			}
			if (p2WorldObjectPath.State != PathState.Calculated)
			{
				Path.ReleasePath(p2WorldObjectPath);
				return null;
			}
			List<TargetObject> result = p2WorldObjectPath.PathsFound.ToList();
			Path.ReleasePath(p2WorldObjectPath);
			return result;
		}
	}
}
