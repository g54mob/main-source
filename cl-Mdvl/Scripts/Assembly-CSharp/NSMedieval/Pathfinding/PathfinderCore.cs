using System.Collections.Generic;
using NSMedieval.Types;
using NSMedieval.Village;

namespace NSMedieval.Pathfinding
{
	public static class PathfinderCore
	{
		internal static List<WorldObject> FetchList(GridDataType type)
		{
			return VillageManager.ActiveVillage.Map.GetWorldObjectsList<WorldObject>(type);
		}
	}
}
