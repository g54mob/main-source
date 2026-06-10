using NSMedieval.BuildingComponents;
using NSMedieval.CombatAi;
using NSMedieval.Enums;

namespace NSMedieval.Utils
{
	public static class CombatInputUtils
	{
		public static bool IsBuildingAutoAttackable(BaseBuildingInstance building)
		{
			if (building == null || (building.BuildingType & BuildingType.AnyDoor) == 0 || building.OwnedByPlayer() || CombatAiUtils.IsAgentDefeated(building))
			{
				return false;
			}
			return true;
		}
	}
}
