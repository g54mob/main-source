using NSMedieval.Enums;

namespace NSMedieval.CommanderAI.Utilities
{
	public static class CommanderAIFilters
	{
		public static readonly BuildingType BuildingTypesToSpreadAttack = BuildingType.ProductionBuilding | BuildingType.Chair | BuildingType.Table | BuildingType.Bed | BuildingType.Decoration | BuildingType.Shrine | BuildingType.Rug | BuildingType.PenMarker | BuildingType.Well | BuildingType.SiegeWeapon;
	}
}
