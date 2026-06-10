using System;
using System.Collections.Generic;
using NSMedieval.Pathfinding;
using NSMedieval.State;

namespace NSMedieval.Goap
{
	public static class PathfinderAnimals
	{
		public static List<TargetObject> FindAnimals(IPathfindingAgent agent, IEnumerable<AnimalInstance> animals, int maxCount, Func<AnimalInstance, bool> condition = null)
		{
			return PathfinderTargetable.FindObjects(agent, animals, maxCount, condition);
		}
	}
}
