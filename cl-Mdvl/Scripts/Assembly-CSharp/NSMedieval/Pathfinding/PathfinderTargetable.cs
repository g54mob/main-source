using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.Utils.Pool;
using NSMedieval.Village.Map.Pathfinding;

namespace NSMedieval.Pathfinding
{
	public static class PathfinderTargetable
	{
		private static readonly Random Rnd = new Random();

		internal static List<TargetObject> FindObjects<T>(IPathfindingAgent agent, IEnumerable<T> objects, int maxCount = -1, Func<T, bool> condition = null) where T : IGoapTargetable
		{
			List<IGoapTargetable> list = ListPool<IGoapTargetable>.Get();
			foreach (T @object in objects)
			{
				list.Add(@object);
			}
			if (condition != null)
			{
				list = list.Where((IGoapTargetable item) => condition((T)item)).ToList();
			}
			if (list.Count == 0)
			{
				ListPool<IGoapTargetable>.Return(list);
				return null;
			}
			P2GoapTargetable p2GoapTargetable = P2GoapTargetable.Construct(agent, maxCount, list);
			MonoSingleton<PathProcessorManager>.Instance.InstantProcessPath(p2GoapTargetable);
			ListPool<IGoapTargetable>.Return(list);
			if (p2GoapTargetable.State != PathState.Calculated || p2GoapTargetable.PathsFound.Count == 0)
			{
				Path.ReleasePath(p2GoapTargetable);
				return null;
			}
			List<TargetObject> result = p2GoapTargetable.PathsFound.ToList();
			Path.ReleasePath(p2GoapTargetable);
			return result;
		}
	}
}
