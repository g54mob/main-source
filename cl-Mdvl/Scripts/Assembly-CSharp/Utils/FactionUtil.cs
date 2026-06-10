using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSMedieval;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.WorldMap;
using UnityEngine;

namespace Utils
{
	public static class FactionUtil
	{
		public static FactionInstance FindById(string id)
		{
			return MonoSingleton<WorldMap>.Instance.Data.FactionInstances.FirstOrDefault((FactionInstance faction) => faction.BlueprintId == id);
		}

		public static FactionInstance GetClosestVillageFaction(Vector2Int worldMapPosition, bool includePermanentlyHostile = false)
		{
			return GetClosestVillage(worldMapPosition, includePermanentlyHostile)?.FactionInstance;
		}

		public static VillagePlace GetClosestVillage(Vector2Int worldMapPosition, bool includePermanentlyHostile = false)
		{
			return MonoSingleton<WorldMap>.Instance.Data.VillagePlaces.MinItem((VillagePlace village) => Vector2Int.Distance(worldMapPosition, village.Position), null, (VillagePlace village) => includePermanentlyHostile || !village.FactionInstance.IsPermanentlyHostile());
		}

		public static IEnumerable<FactionInstance> GetFactionsByFriendliness(HashSet<FactionFriendliness> friendlinessSet, HashSet<string> excludedFactions, bool mustHaveVillages = false)
		{
			WorldMapData worldMapData = GlobalSaveController.CurrentVillageData.WorldMapData;
			IEnumerable<FactionInstance> source;
			if (!mustHaveVillages)
			{
				IEnumerable<FactionInstance> factionInstances = worldMapData.FactionInstances;
				source = factionInstances;
			}
			else
			{
				IEnumerable<FactionInstance> factionInstances = worldMapData.FactionsOnMap;
				source = factionInstances;
			}
			return source.Where((FactionInstance faction) => !excludedFactions.Contains(faction.BlueprintId) && friendlinessSet.Contains(faction.GetFriendliness()));
		}

		public static FactionInstance GetRandomFaction(HashSet<FactionFriendliness> friendlinessSet, HashSet<string> excludedFactions, bool mustHaveVillages = false)
		{
			return GetFactionsByFriendliness(friendlinessSet, excludedFactions, mustHaveVillages).PickRandom();
		}

		public static FactionInstance GetRandomHostileFaction(bool mustHaveVillages = false)
		{
			WorldMapData worldMapData = GlobalSaveController.CurrentVillageData.WorldMapData;
			IEnumerable<FactionInstance> source;
			if (!mustHaveVillages)
			{
				IEnumerable<FactionInstance> factionInstances = worldMapData.FactionInstances;
				source = factionInstances;
			}
			else
			{
				IEnumerable<FactionInstance> factionInstances = worldMapData.FactionsOnMap;
				source = factionInstances;
			}
			return source.Where((FactionInstance faction) => faction.GetFriendliness() == FactionFriendliness.Hostile || faction.GetFriendliness() == FactionFriendliness.PermanentlyHostile).PickRandom();
		}

		public static FactionInstance GetRandomBanditFaction(bool mustHaveVillages = false)
		{
			WorldMapData worldMapData = GlobalSaveController.CurrentVillageData.WorldMapData;
			IEnumerable<FactionInstance> source;
			if (!mustHaveVillages)
			{
				IEnumerable<FactionInstance> factionInstances = worldMapData.FactionInstances;
				source = factionInstances;
			}
			else
			{
				IEnumerable<FactionInstance> factionInstances = worldMapData.FactionsOnMap;
				source = factionInstances;
			}
			return source.Where((FactionInstance faction) => faction.Blueprint.FactionType.GetID() == "bandits").PickRandom();
		}

		public static VillagePlaceReference GetRandomVillagePlace(FactionInstance factionInstance)
		{
			WorldMapData worldMapData = GlobalSaveController.CurrentVillageData.WorldMapData;
			using PooledList<VillagePlace> pooledList = ListPool<VillagePlace>.GetJanitor();
			foreach (VillagePlace villagePlace in worldMapData.VillagePlaces)
			{
				if (villagePlace.FactionInstance == factionInstance)
				{
					pooledList.Add(villagePlace);
				}
			}
			if (pooledList.Count == 0)
			{
				return null;
			}
			return new VillagePlaceReference(pooledList.PickRandom());
		}

		public static VillagePlaceReference FindVillagePlace(HashSet<FactionFriendliness> friendlinessSet, HashSet<string> excludedFactions)
		{
			return (VillagePlaceReference)(GetVillagesByFriendliness(friendlinessSet, excludedFactions).PickRandom()?.CreateReference());
		}

		public static IEnumerable<VillagePlace> GetVillagesByFriendliness(HashSet<FactionFriendliness> friendlinessSet, HashSet<string> excludedFactions)
		{
			return GlobalSaveController.CurrentVillageData.WorldMapData.VillagePlaces.Where((VillagePlace village) => !excludedFactions.Contains(village.FactionInstance.BlueprintId) && friendlinessSet.Contains(village.FactionInstance.GetFriendliness()));
		}
	}
}
