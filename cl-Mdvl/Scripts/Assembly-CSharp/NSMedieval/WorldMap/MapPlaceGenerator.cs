using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using Managers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Dialogs.Data;
using NSMedieval.GameEventSystem;
using NSMedieval.Model.SecondMap;
using NSMedieval.State;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village.Map;
using Repository.Map;
using UnityEngine;
using Utils;

namespace NSMedieval.WorldMap
{
	public static class MapPlaceGenerator
	{
		public static bool CanSpawnMarker(SecondMapType type)
		{
			return !MonoSingleton<WorldMap>.Instance.MarkerManager.HasMaxMarkerCount(type);
		}

		public static WorldMapMarkerPlace DebugSpawnMarker(SecondMapSaveInfo mapInfo)
		{
			using PooledList<string> mapIds = ListPool<string>.GetJanitor();
			mapIds.Add(mapInfo.Id);
			return mapInfo.Type switch
			{
				SecondMapType.Ambush => SpawnCaravanAmbush(GlobalSaveController.CurrentVillageData.WorldMapPlace.Position), 
				SecondMapType.Attack => MaybeSpawnBanditCamp(1f, null, null, null, mapIds), 
				SecondMapType.LootStash => MaybeSpawnLootStash(1f, null, null, null, mapIds), 
				_ => throw new Exception($"Unsupported map type: {mapInfo.Type}"), 
			};
		}

		public static WorldMapMarkerPlace SpawnCaravanAmbush(Vector2Int caravanGridPosition)
		{
			using PooledList<string> mapIds = Repository<SecondMapSaveRepository, SecondMapSaveInfo>.Instance.GetSaveIdsPooled(SecondMapType.Ambush);
			FactionInstance randomHostileFaction = FactionUtil.GetRandomHostileFaction();
			return SpawnMarker(null, new IntRange(999998, 999999), new IntRange(0, 0), mapIds, "general_ambush", "AmbushPlaceMarker", caravanGridPosition, createView: false, randomHostileFaction);
		}

		public static WorldMapMarkerPlace MaybeSpawnLootStash(float randomChance, Dictionary<int, string> lootConfigByWealth = null, IntRange durationRangeMinutes = null, IntRange spawnDistanceRange = null, PooledList<string> mapIds = default(PooledList<string>))
		{
			if (!CanSpawnMarker(SecondMapType.LootStash))
			{
				Log.Info("Can't spawn loot stash because the max number of active loot stashes has been reached", "C:\\GIT\\dev\\Assets\\Scripts\\WorldMap\\MapPlaceGenerator.cs");
				return null;
			}
			randomChance = Mathf.Clamp01(randomChance);
			if (UnityEngine.Random.value > randomChance)
			{
				Log.Info("Not spawning loot stash, dice roll didn't hit chance", "C:\\GIT\\dev\\Assets\\Scripts\\WorldMap\\MapPlaceGenerator.cs");
				return null;
			}
			if (lootConfigByWealth == null)
			{
				lootConfigByWealth = SingletonModel<MapPlaceSettings, MapPlaceSettingsData>.I.StashLootConfigByWealth;
			}
			if (durationRangeMinutes == null)
			{
				durationRangeMinutes = SingletonModel<MapPlaceSettings, MapPlaceSettingsData>.I.StashDurationRangeMinutes;
			}
			if (spawnDistanceRange == null)
			{
				spawnDistanceRange = SingletonModel<MapPlaceSettings, MapPlaceSettingsData>.I.StashSpawnDistanceRange;
			}
			bool flag = false;
			if (!mapIds.HasValue)
			{
				flag = true;
				mapIds = SingletonModel<MapPlaceSettings, MapPlaceSettingsData>.I.StashMapIds.ToPooledListJanitor();
			}
			WorldMapMarkerPlace worldMapMarkerPlace = SpawnMarker(lootConfigByWealth, durationRangeMinutes, spawnDistanceRange, mapIds, "general_loot_stash", "StashPlaceMarker");
			PublishStashNews(worldMapMarkerPlace);
			if (flag)
			{
				mapIds.Dispose();
			}
			return worldMapMarkerPlace;
		}

		public static WorldMapMarkerPlace MaybeSpawnTradeDealPlace(float randomChance, IntRange durationRangeMinutes = null, IntRange spawnDistanceRange = null, FactionInstance factionInstance = null)
		{
			randomChance = Mathf.Clamp01(randomChance);
			if (UnityEngine.Random.value > randomChance)
			{
				Log.Info("Not spawning trade deal location, dice roll didn't hit chance", "C:\\GIT\\dev\\Assets\\Scripts\\WorldMap\\MapPlaceGenerator.cs");
				return null;
			}
			if (durationRangeMinutes == null)
			{
				durationRangeMinutes = SingletonModel<MapPlaceSettings, MapPlaceSettingsData>.I.StashDurationRangeMinutes;
			}
			if (spawnDistanceRange == null)
			{
				spawnDistanceRange = SingletonModel<MapPlaceSettings, MapPlaceSettingsData>.I.StashSpawnDistanceRange;
			}
			return SpawnTradeDealPlace(durationRangeMinutes, spawnDistanceRange, factionInstance);
		}

		public static WorldMapMarkerPlace MaybeSpawnBanditCamp(float randomChance, Dictionary<int, string> lootConfigByWealth = null, IntRange durationRangeMinutes = null, IntRange spawnDistanceRange = null, PooledList<string> mapIds = default(PooledList<string>), bool checkCanSpawn = true, string linkedObjective = null, string banditCampPrefabAddress = null)
		{
			if (checkCanSpawn && !CanSpawnMarker(SecondMapType.Attack))
			{
				Log.Info("Can't spawn bandit camp because the max number of active bandit camps has been reached", "C:\\GIT\\dev\\Assets\\Scripts\\WorldMap\\MapPlaceGenerator.cs");
				return null;
			}
			randomChance = Mathf.Clamp01(randomChance);
			if (UnityEngine.Random.value > randomChance)
			{
				Log.Info("Not spawning bandit camp, dice roll didn't hit chance", "C:\\GIT\\dev\\Assets\\Scripts\\WorldMap\\MapPlaceGenerator.cs");
				return null;
			}
			if (lootConfigByWealth == null)
			{
				lootConfigByWealth = SingletonModel<MapPlaceSettings, MapPlaceSettingsData>.I.BanditCampLootConfigByWealth;
			}
			if (durationRangeMinutes == null)
			{
				durationRangeMinutes = SingletonModel<MapPlaceSettings, MapPlaceSettingsData>.I.BanditCampDurationRangeMinutes;
			}
			if (spawnDistanceRange == null)
			{
				spawnDistanceRange = SingletonModel<MapPlaceSettings, MapPlaceSettingsData>.I.BanditCampSpawnDistanceRange;
			}
			bool flag = false;
			if (!mapIds.HasValue)
			{
				flag = true;
				mapIds = SingletonModel<MapPlaceSettings, MapPlaceSettingsData>.I.BanditCampMapIds.ToPooledListJanitor();
			}
			string prefabAddress = banditCampPrefabAddress ?? "BanditCampPlaceMarker";
			FactionInstance randomBanditFaction = FactionUtil.GetRandomBanditFaction();
			Dictionary<int, string> lootConfigByWealth2 = lootConfigByWealth;
			IntRange durationRangeMinutes2 = durationRangeMinutes;
			IntRange spawnDistanceRange2 = spawnDistanceRange;
			PooledList<string> mapIds2 = mapIds;
			FactionInstance faction = randomBanditFaction;
			WorldMapMarkerPlace worldMapMarkerPlace = SpawnMarker(lootConfigByWealth2, durationRangeMinutes2, spawnDistanceRange2, mapIds2, "general_bandit_camp", prefabAddress, null, createView: true, faction, linkedObjective);
			PublishBanditCampNews(worldMapMarkerPlace);
			if (flag)
			{
				mapIds.Dispose();
			}
			return worldMapMarkerPlace;
		}

		public static WorldMapMarkerPlace SpawnMarker(Dictionary<int, string> lootConfigByWealth, IntRange durationRangeMinutes, IntRange spawnDistanceRange, PooledList<string> mapIds, string markerName, string prefabAddress, Vector2Int? overrideCenterPosition = null, bool createView = true, FactionInstance faction = null, string linkedObjective = null)
		{
			string text = null;
			if (lootConfigByWealth != null)
			{
				List<(int Key, string Value)> list = (from pair in lootConfigByWealth
					orderby pair.Key descending
					select (Key: pair.Key, Value: pair.Value)).ToList();
				int num = (int)MonoSingleton<BaseWealth>.Instance.GetTotalWealth();
				foreach (var (num2, text2) in list)
				{
					if (num >= num2)
					{
						text = text2;
						break;
					}
				}
			}
			int durationMinutes = durationRangeMinutes.Random();
			Vector2Int center = MonoSingleton<WorldMap>.Instance.Data.VillagePosition;
			if (overrideCenterPosition.HasValue)
			{
				center = overrideCenterPosition.Value;
			}
			Vector2Int markerGridPosition = MonoSingleton<WorldMap>.Instance.MarkerManager.GenerateFreePosition(center, spawnDistanceRange);
			string text3 = WorldMapUtils.PickMapBiomeVariant(mapIds, in markerGridPosition);
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(48, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\WorldMap\\MapPlaceGenerator.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Spawning map marker ");
				messageBuilder.AppendFormatted(text3);
				messageBuilder.AppendLiteral(" at ");
				messageBuilder.AppendFormatted(markerGridPosition);
				messageBuilder.AppendLiteral(" with lootSpawnConfig '");
				messageBuilder.AppendFormatted(text);
				messageBuilder.AppendLiteral("'");
			}
			Log.Info(messageBuilder);
			return MonoSingleton<WorldMap>.Instance.MarkerManager.SpawnMarker(markerName.ToLocalized(), in markerGridPosition, text3, prefabAddress, durationMinutes, text, createView, faction, linkedObjective);
		}

		private static WorldMapMarkerPlace SpawnTradeDealPlace(IntRange durationRangeMinutes, IntRange spawnDistanceRange, FactionInstance factionInstance)
		{
			int durationMinutes = durationRangeMinutes.Random();
			Vector2Int villagePosition = MonoSingleton<WorldMap>.Instance.Data.VillagePosition;
			Vector2Int gridPosition = MonoSingleton<WorldMap>.Instance.MarkerManager.GenerateFreePosition(villagePosition, spawnDistanceRange);
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(36, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\WorldMap\\MapPlaceGenerator.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Spawning Trade Deal VillagePlace at ");
				messageBuilder.AppendFormatted(gridPosition);
			}
			Log.Info(messageBuilder);
			string mapId = null;
			string prefabAddress = "AmbushPlaceMarker";
			string text = MonoSingleton<LocalizationController>.Instance.GetText("trade_deal_name");
			return MonoSingleton<WorldMap>.Instance.MarkerManager.SpawnMarker(text, in gridPosition, mapId, prefabAddress, durationMinutes, null, createView: true, factionInstance);
		}

		private static void PublishStashNews(WorldMapMarkerPlace marker)
		{
			DialogContent dialogContent = new DialogContent
			{
				WindowTitle = "event_type_point_of_interest".ToLocalized(),
				ContentTitle = "event_stash_discovered".ToLocalized(),
				ContentBodyText = "event_stash_discovered_text".ToLocalized(),
				ContentBodyImagePath = "event_loot_stash",
				ShowCloseButton = true,
				Options = new List<DialogOption>
				{
					new DialogOption
					{
						Text = "general_ok".ToLocalized()
					},
					new DialogOption
					{
						Text = "general_jump_to_location".ToLocalized()
					}
				}
			};
			NewsData newsData = new NewsData("event_stash_discovered", "NewsGray", "", dialogContent, marker.CreateReference(), 1, marker.TimeInterval);
			if (!GlobalSaveController.CurrentVillageData.MapTableBuilt)
			{
				newsData.DialogContent.Options[1].Disabled = true;
				newsData.DialogContent.Options[1].Tooltips = new List<TooltipData>
				{
					new TooltipData
					{
						Key = "error_build_map_table"
					}
				};
			}
			MonoSingleton<NewsManager>.Instance.Publish(newsData);
		}

		private static void PublishBanditCampNews(WorldMapMarkerPlace marker)
		{
			DialogContent dialogContent = new DialogContent
			{
				WindowTitle = "event_type_point_of_interest".ToLocalized(),
				ContentTitle = "event_bandit_camp_discovered".ToLocalized(),
				ContentBodyText = "event_bandit_camp_discovered_text".ToLocalized(),
				ContentBodyImagePath = "event_bandit_camp",
				ShowCloseButton = true,
				Options = new List<DialogOption>
				{
					new DialogOption
					{
						Text = "general_ok".ToLocalized()
					},
					new DialogOption
					{
						Text = "general_jump_to_location".ToLocalized()
					}
				}
			};
			NewsData newsData = new NewsData("event_bandit_camp_discovered", "NewsGray", "", dialogContent, marker.CreateReference(), 1, marker.TimeInterval);
			if (!GlobalSaveController.CurrentVillageData.MapTableBuilt)
			{
				newsData.DialogContent.Options[1].Disabled = true;
				newsData.DialogContent.Options[1].Tooltips = new List<TooltipData>
				{
					new TooltipData
					{
						Key = "error_build_map_table"
					}
				};
			}
			MonoSingleton<NewsManager>.Instance.Publish(newsData);
		}
	}
}
