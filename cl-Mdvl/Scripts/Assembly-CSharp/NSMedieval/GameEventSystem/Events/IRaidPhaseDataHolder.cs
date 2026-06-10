using System.Collections.Generic;
using NSMedieval.BuildingComponents;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Village.Map;
using NSMedieval.WorldMap;

namespace NSMedieval.GameEventSystem.Events
{
	public interface IRaidPhaseDataHolder
	{
		WorldMapPlace BattleMapPlace { get; }

		VillagePlace RaiderOriginVillage { get; }

		FactionInstance RaiderFactionInstance { get; }

		ActiveRaidInfo CachedRaidInfo { get; set; }

		RaiderBlueprintId[] EnemyBlueprintIds { get; }

		SiegeWeaponComponentBlueprint[] SiegeWeaponBlueprints { get; }

		bool IsSiege { get; }

		List<MapNode> OverrideRaidSpawnPositions { get; set; }
	}
}
