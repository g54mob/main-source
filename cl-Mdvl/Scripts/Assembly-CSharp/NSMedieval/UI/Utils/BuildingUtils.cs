using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using JetBrains.Annotations;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Crops;
using NSMedieval.Enums;
using NSMedieval.Extensions;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.PlayerTriggeredEventSystem;
using NSMedieval.Production;
using NSMedieval.Repository;
using NSMedieval.Research;
using NSMedieval.RoomDetection;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Stockpiles;
using NSMedieval.StorageUniversal;
using NSMedieval.Tools;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.View;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.UI.Utils
{
	public static class BuildingUtils
	{
		private static readonly StringBuilder StringBuilder = new StringBuilder();

		private static readonly HashSet<string> ResearchBuildings = new HashSet<string> { "basic_research_table", "research_table", "advanced_research_table" };

		public static HashSet<string> GetResearchBuildings
		{
			get
			{
				if (ResearchBuildings.Count == 0)
				{
					throw new Exception("ResearchBuildings set should not be empty");
				}
				return ResearchBuildings;
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			StringBuilder.Clear();
		}

		public static BaseBuildingBlueprint GetBaseBlueprint(string itemId)
		{
			return Repository<BaseBuildingRepository, BaseBuildingBlueprint>.Instance.GetByID(itemId);
		}

		public static List<string> GetAlmanacTags(string buildingId)
		{
			return GetBaseBlueprint(buildingId).AlmanacTags;
		}

		[MustDisposeResource]
		public static PooledList<BaseBuildingInstance> GetPossibleEventHolders()
		{
			PooledList<BaseBuildingInstance> janitor = ListPool<BaseBuildingInstance>.GetJanitor();
			foreach (BaseBuildingInstance playerTriggeredEventHolder in VillageManager.ActiveVillage.Map.BuildingsManagerMain.PlayerTriggeredEventHolders)
			{
				foreach (string playerTriggeredEvent in playerTriggeredEventHolder.Blueprint.PlayerTriggeredEvents)
				{
					bool isEnabled;
					if (!MonoSingleton<PlayerTriggeredEventManager>.Instance.CanShowView(playerTriggeredEvent, playerTriggeredEventHolder, isSilent: true))
					{
						FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(16, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\BuildingUtils.cs");
						if (isEnabled)
						{
							messageBuilder.AppendFormatted(playerTriggeredEvent);
							messageBuilder.AppendLiteral(" can't show view");
						}
						Log.Debug(messageBuilder);
					}
					else if (GlobalSaveController.CurrentVillageData.PlayerTriggeredEventSaveData.IsEventViewShown(playerTriggeredEvent))
					{
						FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(22, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\BuildingUtils.cs");
						if (isEnabled)
						{
							messageBuilder.AppendFormatted(playerTriggeredEvent);
							messageBuilder.AppendLiteral(" view is already Shown");
						}
						Log.Debug(messageBuilder);
					}
					else
					{
						janitor.Add(playerTriggeredEventHolder);
					}
				}
			}
			return janitor;
		}

		private static string GetLocalizationNameKey(string itemId)
		{
			if (!GetLocKeys(itemId, out var locKeys))
			{
				return string.Empty;
			}
			return LocKeyUtils.GetName(locKeys);
		}

		private static string GetLocalizationInfoKey(string itemId)
		{
			if (!GetLocKeys(itemId, out var locKeys))
			{
				return string.Empty;
			}
			return LocKeyUtils.GetInfo(locKeys);
		}

		private static bool GetLocKeys(string itemId, out LocKeys[] locKeys)
		{
			locKeys = null;
			BaseBuildingBlueprint baseBlueprint = GetBaseBlueprint(itemId);
			if (baseBlueprint != null)
			{
				locKeys = baseBlueprint.LocKeys;
				return true;
			}
			Stockpile byID = Repository<StockpileRepository, Stockpile>.Instance.GetByID(itemId);
			if ((object)byID != null)
			{
				locKeys = byID.LocKeys;
				return true;
			}
			Cropfield byID2 = Repository<CropfieldRepository, Cropfield>.Instance.GetByID(itemId);
			if ((object)byID2 != null)
			{
				locKeys = byID2.LocKeys;
				return true;
			}
			return false;
		}

		public static string GetLocalizedTooltipLines(string buildableBaseId)
		{
			StringBuilder.Clear();
			if (GetLocKeys(buildableBaseId, out var locKeys) && LocKeyUtils.GetTooltipLines(locKeys, out var lines))
			{
				string[] array = lines;
				foreach (string key in array)
				{
					StringBuilder.Append("\n");
					StringBuilder.AppendFormat(UiUtils.Localize.GetText(key));
				}
			}
			return StringBuilder.ToString();
		}

		public static string GetIconPath(string id)
		{
			BaseBuildingBlueprint baseBlueprint = GetBaseBlueprint(id);
			if (baseBlueprint != null)
			{
				return baseBlueprint.IconPath;
			}
			Stockpile byID = Repository<StockpileRepository, Stockpile>.Instance.GetByID(id);
			if ((object)byID != null)
			{
				return byID.IconPath;
			}
			Cropfield byID2 = Repository<CropfieldRepository, Cropfield>.Instance.GetByID(id);
			if ((object)byID2 != null)
			{
				return byID2.IconPath;
			}
			return "UIResources/Icons/BuildingIcons/ph";
		}

		public static string GetIconColor(string baseBuildingId)
		{
			BaseBuildingBlueprint baseBlueprint = GetBaseBlueprint(baseBuildingId);
			if ((object)baseBlueprint == null)
			{
				return string.Empty;
			}
			if (string.IsNullOrEmpty(baseBlueprint.IconColorOverlay))
			{
				return string.Empty;
			}
			return baseBlueprint.IconColorOverlay;
		}

		public static string GetVariationIconName(string id, string variationName)
		{
			BaseBuildingBlueprint baseBlueprint = GetBaseBlueprint(id);
			if (baseBlueprint != null)
			{
				foreach (MeshVariationList variationList in baseBlueprint.VariationLists)
				{
					foreach (MeshVariation variation in variationList.Variations)
					{
						if (variation.Name.Equals(variationName))
						{
							return variation.Icon;
						}
					}
				}
			}
			return "pile_ph";
		}

		public static string GetLocalizedInfo(string buildableBaseId)
		{
			return UiUtils.Localize.GetText(GetLocalizationInfoKey(buildableBaseId));
		}

		public static List<string> GetLocalizedGetBuildPhaseInfo(BaseBuildingInstance baseBuildingInstance)
		{
			List<string> list = new List<string>();
			if (baseBuildingInstance.ConstructionPhase.Equals(ConstructionPhase.Blueprint))
			{
				if (baseBuildingInstance.Blueprint.TransfersStabilityIncludeBeams() && baseBuildingInstance.Stability > 0)
				{
					list.Add(string.Format("<link=\"Stability\">{0}:</link> <style=AltColor>{1}</style>\n", MonoSingleton<LocalizationController>.Instance.GetText("stability_link"), baseBuildingInstance.Stability));
				}
				list.Add(baseBuildingInstance.GetBuildingPhase());
				if (!baseBuildingInstance.Reachable)
				{
					list.Add("<style=DefaultRed>" + MonoSingleton<LocalizationController>.Instance.GetText("building_error_not_reachable") + "</style>");
				}
				if (!baseBuildingInstance.ResourcesAvailable)
				{
					list.Add("<style=DefaultRed>" + MonoSingleton<LocalizationController>.Instance.GetText("building_error_no_resources") + "</style>");
				}
				if (!baseBuildingInstance.SkilledConstructionWorkerExists && !baseBuildingInstance.IsMoveBlueprint)
				{
					int minBuildSkillRequired = baseBuildingInstance.Blueprint.MinBuildSkillRequired;
					string spriteAsset = AssetUtils.GetSpriteAsset("construction");
					list.Add(string.Format("<style=DefaultRed>{0}</style> {1} <style=AltColor>{2}</style>", MonoSingleton<LocalizationController>.Instance.GetText("building_error_no_skilled_construction_worker"), spriteAsset, minBuildSkillRequired));
				}
				list.Add(MonoSingleton<LocalizationController>.Instance.GetText("building_info_resources_needed"));
				return list;
			}
			if (baseBuildingInstance.ConstructionPhase.Equals(ConstructionPhase.Foundation))
			{
				list.Add(baseBuildingInstance.GetBuildingPhase());
				if (!baseBuildingInstance.Reachable)
				{
					list.Add("<style=DefaultRed>" + MonoSingleton<LocalizationController>.Instance.GetText("building_error_not_reachable") + "</style>");
				}
				string text = UiUtils.GetReservedByLocalized(baseBuildingInstance);
				if (text.Equals(string.Empty))
				{
					text = MonoSingleton<LocalizationController>.Instance.GetText("building_info_builder_needed");
				}
				list.Add(text);
			}
			else
			{
				if (baseBuildingInstance.Blueprint.TransfersStabilityIncludeBeams() && baseBuildingInstance.Stability > 0)
				{
					list.Add(string.Format("<link=\"Stability\">{0}:</link> <style=AltColor>{1}</style>\n", MonoSingleton<LocalizationController>.Instance.GetText("stability_link"), baseBuildingInstance.Stability));
				}
				if (baseBuildingInstance.MarkedForMoving || baseBuildingInstance.MarkedForUninstall)
				{
					list.Add(MonoSingleton<LocalizationController>.Instance.GetText("structure_info_uninstall"));
				}
				if (baseBuildingInstance.GetComponentInstance<WellComponentInstance>() != null)
				{
					list.Add(MonoSingleton<LocalizationController>.Instance.GetText("structure_info_well"));
				}
				list.AddIfNotNullOrEmpty(UiUtils.GetReservedByLocalized(baseBuildingInstance));
			}
			Room room = baseBuildingInstance.GetRoom();
			if (room != null && room.RoomType != null)
			{
				string text2 = ColorUtility.ToHtmlStringRGB(room.RoomType.Color);
				list.Add(MonoSingleton<LocalizationController>.Instance.GetText("inside") + ": <color=#" + text2 + "><link=\"select_room\"><style=LinkRoom>" + room.GetRoomTypeLocalized() + " (" + room.Impressiveness?.NameLocalized + ")</style></link></color>");
				if (room.RoomType.Prison && baseBuildingInstance.IsForbiddenPrisonCell)
				{
					list.AddIfNotNullOrEmpty(GetInPrisonCellInfo(baseBuildingInstance.Blueprint));
				}
			}
			return list;
		}

		public static string GetInPrisonCellInfo(BaseBuildingBlueprint blueprint)
		{
			if (blueprint == null)
			{
				return string.Empty;
			}
			string text = MonoSingleton<LocalizationController>.Instance.GetText("object_inside_prison_cell");
			string localizedName = GetLocalizedName(blueprint);
			return text.Replace("<object_name>", localizedName);
		}

		private static string GetLocalizedRequiredConstructionSkillLevel(BaseBuildingBlueprint baseBuildingBlueprint)
		{
			string text = MonoSingleton<LocalizationController>.Instance.GetText("needed_skills");
			int minBuildSkillRequired = baseBuildingBlueprint.MinBuildSkillRequired;
			if (minBuildSkillRequired == 0)
			{
				return string.Empty;
			}
			string spriteAsset = AssetUtils.GetSpriteAsset("construction");
			return $"{text}: {spriteAsset} <style=AltColor>{minBuildSkillRequired}</style>";
		}

		public static string GetLocalizedObjectSize(BaseBuildingBlueprint buildableBase)
		{
			return UiUtils.Localize.GetText("object_size") + ": <style=AltColor>" + buildableBase.Size.ToString() + "</style>";
		}

		public static string GetLocalizedGlobalPosition(BaseBuildingInstance baseBuildingInstance)
		{
			return string.Format("{0}: <color=#ffeca8>{1}, {2}, {3}</color>\n", MonoSingleton<LocalizationController>.Instance.GetText("global_position"), (int)baseBuildingInstance.WorldPosition.x, (int)baseBuildingInstance.WorldPosition.y, (int)baseBuildingInstance.WorldPosition.z);
		}

		public static string GetLocalizedBuildingRotation(BaseBuildingInstance baseBuildingInstance)
		{
			return string.Format("{0}: <style=AltColor>{1}\ufffd</style>", MonoSingleton<LocalizationController>.Instance.GetText("dev_rotation"), baseBuildingInstance.GetAngle());
		}

		public static string GetLocalizedHasStabilityToBuild(BaseBuildingInstance baseBuildingInstance)
		{
			if (!baseBuildingInstance.HasStabilityToBuild)
			{
				return MonoSingleton<LocalizationController>.Instance.GetText("has_stability_to_build") + ": <style=AltColor>" + MonoSingleton<LocalizationController>.Instance.GetText("general_false") + "</style>";
			}
			return MonoSingleton<LocalizationController>.Instance.GetText("has_stability_to_build") + ": <style=AltColor>" + MonoSingleton<LocalizationController>.Instance.GetText("general_true") + "</style>";
		}

		public static string GetLocalizedProducerName(BaseBuildingInstance baseBuildingInstance)
		{
			string producerName = baseBuildingInstance.GetProducerName();
			if (string.IsNullOrEmpty(producerName))
			{
				return null;
			}
			return MonoSingleton<LocalizationController>.Instance.GetText("made_by") + " " + producerName;
		}

		public static string GetLocalizedOwnershipInfo(BaseBuildingInstance baseBuildingInstance)
		{
			if (baseBuildingInstance.BuildingOwnershipInfo?.Owner != null)
			{
				return MonoSingleton<LocalizationController>.Instance.GetText("assigned_to") + ": <style=AltColor>" + baseBuildingInstance.BuildingOwnershipInfo.GetLocalizedOwner() + "</style>";
			}
			return string.Empty;
		}

		public static string GetLocalizedCoverPercentageLink(BaseBuildingBlueprint buildableBase)
		{
			float num = ((buildableBase.Cover > 0f) ? buildableBase.Cover : buildableBase.AttackTraversePenalty);
			string arg = string.Empty;
			if (!string.IsNullOrEmpty(buildableBase.WindowComponentID))
			{
				WindowComponentBlueprint byID = Repository<WindowComponentRepository, WindowComponentBlueprint>.Instance.GetByID(buildableBase.WindowComponentID);
				if (byID != null)
				{
					arg = string.Format("({0}:</style> <style=AltColor>{1}%</style>)", UiUtils.Localize.GetText("window_state_closed"), byID.CoverClosed * 100f);
				}
			}
			if (!string.IsNullOrEmpty(buildableBase.DoorComponentID))
			{
				DoorComponentBlueprint byID2 = Repository<DoorComponentRepository, DoorComponentBlueprint>.Instance.GetByID(buildableBase.DoorComponentID);
				if (byID2 != null)
				{
					arg = string.Format("({0}:</style> <style=AltColor>{1}%</style>)", UiUtils.Localize.GetText("window_state_open"), byID2.CoverOpen * 100f);
				}
			}
			if (num != 0f)
			{
				return string.Format("{0}: <style=AltColor>{1}%</style> {2}", UiUtils.GetLocalizedAlmanacLink("cover_percentage"), num * 100f, arg);
			}
			return string.Empty;
		}

		public static string GetLocalizedCoverPercentageLink(BaseBuildingInstance baseBuildingInstance)
		{
			float num = ((baseBuildingInstance.Blueprint.Cover > 0f) ? baseBuildingInstance.Blueprint.Cover : baseBuildingInstance.Blueprint.AttackTraversePenalty);
			string arg = string.Empty;
			if (!string.IsNullOrEmpty(baseBuildingInstance.Blueprint.WindowComponentID))
			{
				WindowComponentBlueprint byID = Repository<WindowComponentRepository, WindowComponentBlueprint>.Instance.GetByID(baseBuildingInstance.Blueprint.WindowComponentID);
				if (byID != null)
				{
					arg = string.Format("({0}:</style> <style=AltColor>{1}%</style>)", UiUtils.Localize.GetText("window_state_closed"), byID.CoverClosed * 100f);
				}
			}
			if (!string.IsNullOrEmpty(baseBuildingInstance.Blueprint.DoorComponentID))
			{
				DoorComponentBlueprint byID2 = Repository<DoorComponentRepository, DoorComponentBlueprint>.Instance.GetByID(baseBuildingInstance.Blueprint.DoorComponentID);
				if (byID2 != null)
				{
					arg = string.Format("({0}:</style> <style=AltColor>{1}%</style>)", UiUtils.Localize.GetText("window_state_open"), byID2.CoverOpen * 100f);
				}
			}
			if (num != 0f)
			{
				return string.Format("{0}: <style=AltColor>{1}%</style> {2}", UiUtils.GetLocalizedAlmanacLink("cover_percentage"), num * 100f, arg);
			}
			return string.Empty;
		}

		private static string GetLocalizedHitPoints(BaseBuildingBlueprint buildableBase)
		{
			Stat stat = buildableBase.Stats?.FirstOrDefault((Stat stat2) => stat2.Type == StatType.Health);
			if (stat == null)
			{
				return string.Empty;
			}
			float initialValue = stat.InitialValue;
			return string.Format("{0}: <style=AltColor>{1}</style>", UiUtils.Localize.GetText("menu_hit_points"), initialValue);
		}

		public static List<KeyValuePair<string, string>> GetMaterials(string buildingId)
		{
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			foreach (KeyValuePair<string, int> item in GetBaseBlueprint(buildingId).Materials.Dictionary)
			{
				string value = ((MonoSingleton<ResourcePileTracker>.Instance.GetCount(Repository<ResourceRepository, Resource>.Instance.GetByID(item.Key)).AllowedCount < item.Value) ? $"<style=DefaultRed>{item.Value}</style>" : item.Value.ToString());
				list.Add(new KeyValuePair<string, string>(item.Key, value));
			}
			return list;
		}

		public static List<string> GetInfoLines(string buildingId, Vec3Int gridPosition)
		{
			return GetInfoLines(GetBaseBlueprint(buildingId), gridPosition);
		}

		public static List<string> GetInfoLines(BaseBuildingBlueprint buildableBase, Vec3Int gridPosition)
		{
			List<string> list = new List<string>();
			bool hasQuality = buildableBase.HasQuality;
			list.AddIfNotNullOrEmpty(GetLocalizedPossibleDoorStates(buildableBase));
			list.AddIfNotNullOrEmpty(GetLocalizedRoomLinks(buildableBase));
			list.AddIfNotNullOrEmpty(GetLocalizedPteLinks(buildableBase));
			list.AddIfNotNullOrEmpty(GetLocalizedStorableCategories(buildableBase));
			list.AddIfNotNullOrEmpty(GetLocalizedFuelLinks(buildableBase));
			list.AddIfNotNullOrEmpty(GetLocalizedRequiredConstructionSkillLevel(buildableBase));
			list.AddIfNotNullAndTrue(GetLocalizedHitPoints(buildableBase), !hasQuality);
			list.AddIfNotNullOrEmpty(GetLocalizedThermalInsulation(buildableBase));
			list.AddIfNotNullOrEmpty(GetLocalizedHeatEmission(buildableBase));
			list.AddIfNotNullOrEmpty(GetLocalizedCoverPercentageLink(buildableBase));
			if (gridPosition != Vec3Int.zero)
			{
				list.AddIfNotNullOrEmpty(GetLocalizedWalkSpeed(buildableBase, gridPosition));
			}
			list.AddIfNotNullOrEmpty(GetLocalizedProductions(buildableBase));
			list.AddIfNotNullAndTrue(GetProductionBuildings(buildableBase.GroupIdentifier), hasQuality);
			list.AddIfNotNullAndTrue(GetLocalizedWealthPoints(buildableBase), !hasQuality);
			list.AddIfNotNullAndTrue(GetLocalizedBeautyPoints(buildableBase), !hasQuality);
			list.AddIfNotNullOrEmpty(GetLocalizedResearchLink(buildableBase));
			list.Add(GetLocalizedObjectSize(buildableBase));
			return list;
		}

		public static List<string> GetInfoLines(BaseBuildingInstance baseBuildingInstance)
		{
			List<string> list = new List<string>();
			BaseBuildingBlueprint blueprint = baseBuildingInstance.Blueprint;
			bool hasQuality = blueprint.HasQuality;
			list.AddIfNotNullOrEmpty(GetLocalizedHitPoints(blueprint));
			list.AddIfNotNullOrEmpty(GetLocalizedRequiredConstructionSkillLevel(blueprint));
			list.AddIfNotNullOrEmpty(GetLocalizedCoverPercentageLink(baseBuildingInstance));
			list.AddIfNotNullOrEmpty(GetLocalizedWalkSpeed(baseBuildingInstance, baseBuildingInstance.GridDataPosition));
			list.AddIfNotNullOrEmpty(GetLocalizedThermalInsulation(baseBuildingInstance));
			list.AddIfNotNullOrEmpty(GetLocalizedHeatEmission(baseBuildingInstance));
			list.AddIfNotNullAndTrue(GetLocalizedWealthPoints(baseBuildingInstance), !hasQuality);
			list.AddIfNotNullAndTrue(GetLocalizedBeautyPoints(baseBuildingInstance), !hasQuality);
			list.Add(GetLocalizedObjectSize(blueprint));
			list.Add(GetLocalizedBeautyPoints(blueprint));
			list.Add(GetLocalizedGlobalPosition(baseBuildingInstance));
			list.AddIfNotNullOrEmpty(GetLocalizedHasStabilityToBuild(baseBuildingInstance));
			list.AddIfNotNullOrEmpty(GetLocalizedProducerName(baseBuildingInstance));
			list.AddIfNotNullOrEmpty(GetLocalizedOwnershipInfo(baseBuildingInstance));
			if (baseBuildingInstance.Blueprint.HeatDamage > 0f)
			{
				list.Add(MonoSingleton<LocalizationController>.Instance.GetText("building_heat_damage_threshold") + ": <style=AltColor>" + WorldDate.GetLocalizedTemperature(baseBuildingInstance.Blueprint.HeatDamageThreshold) + "</style>");
				list.Add(string.Format("{0}: <style=AltColor>{1}</style>", MonoSingleton<LocalizationController>.Instance.GetText("building_heat_damage"), baseBuildingInstance.Blueprint.HeatDamage));
				list.Add(MonoSingleton<LocalizationController>.Instance.GetText("building_temperature") + ": <style=AltColor>" + WorldDate.GetLocalizedTemperature(baseBuildingInstance.GetAverageTemperature()) + "</style>");
			}
			list.AddIfNotNullOrEmpty(GetLocalizedRoomLinks(blueprint));
			list.AddIfNotNullOrEmpty(GetLocalizedPteLinks(blueprint));
			list.AddIfNotNullOrEmpty(GetTrapDebugInfo(baseBuildingInstance));
			list.AddIfNotNullOrEmpty(GetDoorDebugInfo(baseBuildingInstance));
			list.AddIfNotNullOrEmpty(GetWindowDebugInfo(baseBuildingInstance));
			list.AddIfNotNullOrEmpty(GetShelfDebugInfo(baseBuildingInstance));
			return list;
		}

		public static string GetLocalizedFuelLinks(BaseBuildingBlueprint baseBuildingBlueprint)
		{
			if (string.IsNullOrEmpty(baseBuildingBlueprint.FuelConsumerComponentID))
			{
				return null;
			}
			HashSet<string> hashSet = new HashSet<string>();
			FuelConsumerComponentBlueprint byID = Repository<FuelConsumerComponentRepository, FuelConsumerComponentBlueprint>.Instance.GetByID(baseBuildingBlueprint.FuelConsumerComponentID);
			foreach (Resource allItem in Repository<ResourceRepository, Resource>.Instance.GetAllItems())
			{
				if (allItem.Category.HasFlag(byID.FuelType))
				{
					hashSet.Add(LocKeyUtils.GetName(allItem.LocKeys));
				}
			}
			return "general_uses_fuel".ToLocalized() + ": " + UiUtils.GetLocalizedAlmanacLinks(hashSet.ToList());
		}

		public static string GetLocalizedRoomLinks(BaseBuildingBlueprint baseBuildingBlueprint)
		{
			List<string> list = new List<string>();
			foreach (RoomType allItem in Repository<RoomTypeRepository, RoomType>.Instance.GetAllItems())
			{
				foreach (RoomTypeMustHave item in allItem.MustHave)
				{
					if (item.Buildings.Contains(baseBuildingBlueprint.GetID()))
					{
						list.Add(LocKeyUtils.GetName(allItem.LocKeys));
					}
				}
			}
			if (list.Count == 0)
			{
				return string.Empty;
			}
			return "must_have_in_rooms".ToLocalized() + ": " + UiUtils.GetLocalizedAlmanacLinks(list, ", ");
		}

		public static string GetLocalizedResearchLink(BaseBuildingBlueprint baseBuildingBlueprint)
		{
			foreach (ResearchModel allItem in Repository<ResearchRepository, ResearchModel>.Instance.GetAllItems())
			{
				foreach (ResearchUnlock unlock in allItem.Unlocks)
				{
					if (unlock.UnlockId == baseBuildingBlueprint.GetID())
					{
						return "unlocked_with_research".ToLocalized() + ": " + UiUtils.GetResearchLink(allItem.GetID(), LocKeyUtils.GetName(allItem.LocKeys).ToLocalized());
					}
				}
			}
			return string.Empty;
		}

		public static string GetLocalizedPteLinks(BaseBuildingBlueprint baseBuildingBlueprint)
		{
			List<string> list = new List<string>();
			foreach (PlayerTriggeredEvent allItem in Repository<PlayerTriggeredEventRepository, PlayerTriggeredEvent>.Instance.GetAllItems())
			{
				if (allItem.BuildingIds.Contains(baseBuildingBlueprint.GetID()))
				{
					list.Add(LocKeyUtils.GetName(allItem.LocKeys));
				}
			}
			if (list.Count == 0)
			{
				return string.Empty;
			}
			return "can_host_events".ToLocalized() + ": " + UiUtils.GetLocalizedAlmanacLinks(list, ", ");
		}

		public static string GetLocalizedWealthPoints(BaseBuildingInstance baseBuildingInstance)
		{
			return string.Format("{0}: <style=AltColor>{1:F1}</style>", UiUtils.Localize.GetText("info_panel_wealth"), baseBuildingInstance.Blueprint.WealthPoints);
		}

		public static string GetLocalizedWealthPoints(BaseBuildingBlueprint baseBuildingBlueprint)
		{
			return string.Format("{0}: <style=AltColor>{1:F1}</style>", UiUtils.Localize.GetText("info_panel_wealth"), baseBuildingBlueprint.WealthPoints);
		}

		public static string GetLocalizedBeautyPoints(BaseBuildingInstance baseBuildingInstance)
		{
			return GetLocalizedBeautyPoints(baseBuildingInstance.Blueprint);
		}

		public static string GetLocalizedBeautyPoints(BaseBuildingBlueprint baseBuildingBlueprint)
		{
			if (baseBuildingBlueprint.BeautyBlocker)
			{
				return string.Empty;
			}
			return string.Format("{0}: <style=AltColor>{1}</style>", UiUtils.Localize.GetText("menu_beauty_points"), baseBuildingBlueprint.BeautyInput);
		}

		public static string GetLocalizedPossibleDoorStates(BaseBuildingBlueprint buildableBase)
		{
			if (string.IsNullOrEmpty(buildableBase.DoorComponentID))
			{
				return null;
			}
			DoorComponentBlueprint byID = Repository<DoorComponentRepository, DoorComponentBlueprint>.Instance.GetByID(buildableBase.DoorComponentID);
			if (byID == null)
			{
				return null;
			}
			List<string> list = new List<string>();
			foreach (LockStateData lockState in byID.LockStates)
			{
				list.Add(lockState.TextKey.ToLocalized());
			}
			return "possible_states".ToLocalized() + ": <style=AltColor>" + list.ToPrettyStringNoBrackets() + "</style>";
		}

		public static string GetLocalizedDoorLockState(DoorComponentInstance doorComponentInstance)
		{
			if (doorComponentInstance == null || doorComponentInstance.HasDisposed || doorComponentInstance.OwnerBuilding == null || doorComponentInstance.OwnerBuilding.HasDisposed)
			{
				return string.Empty;
			}
			if (doorComponentInstance.LockState == LockState.ForcedOpen)
			{
				return MonoSingleton<LocalizationController>.Instance.GetText("door_broken");
			}
			string text = GetLockStateOrderInfo();
			if (!string.IsNullOrEmpty(text))
			{
				return "<style=AltColor>" + text + "</style>";
			}
			return MonoSingleton<LocalizationController>.Instance.GetText(doorComponentInstance.GetLockStateDataForInfo()?.InfoTextKey);
			string GetLockStateOrderInfo()
			{
				if (!doorComponentInstance.ShouldChangeLockState())
				{
					return string.Empty;
				}
				return MonoSingleton<LocalizationController>.Instance.GetText("structure_change_state") + ": " + MonoSingleton<LocalizationController>.Instance.GetText(doorComponentInstance.GetLockStateData(doorComponentInstance.GetLockStateForOrder())?.TextKey);
			}
		}

		public static string GetDoorDebugInfo(BaseBuildingInstance baseBuildingInstance)
		{
			return string.Empty;
		}

		public static string GetWindowDebugInfo(BaseBuildingInstance baseBuildingInstance)
		{
			return string.Empty;
		}

		public static string GetShelfDebugInfo(BaseBuildingInstance baseBuildingInstance)
		{
			return string.Empty;
		}

		public static string GetLocalizedStorableCategories(BaseBuildingBlueprint baseBuildingBlueprint)
		{
			if (string.IsNullOrEmpty(baseBuildingBlueprint.ShelfComponentID))
			{
				return string.Empty;
			}
			ShelfComponentBlueprint byID = Repository<ShelfComponentRepository, ShelfComponentBlueprint>.Instance.GetByID(baseBuildingBlueprint.ShelfComponentID);
			if (!(byID == null))
			{
				return GetLocalizedStorableCategories(byID);
			}
			return string.Empty;
		}

		public static string GetLocalizedStorableCategories(ShelfComponentBlueprint shelfComponentBlueprint)
		{
			if (shelfComponentBlueprint == null)
			{
				return string.Empty;
			}
			if (shelfComponentBlueprint.StorageIDs == null || shelfComponentBlueprint.StorageIDs.Count == 0)
			{
				return null;
			}
			int num = 0;
			List<string> list = new List<string>();
			foreach (string storageID in shelfComponentBlueprint.StorageIDs)
			{
				UniversalStorageBlueprint byID = Repository<UniversalStorageRepository, UniversalStorageBlueprint>.Instance.GetByID(storageID);
				num += byID.MaxPileCount;
				foreach (string parentGroup in byID.GetParentGroups())
				{
					if (!list.Contains(parentGroup))
					{
						list.Add(parentGroup);
					}
				}
			}
			List<string> list2 = ListPool<string>.Get();
			foreach (string item in list)
			{
				string localizedAlmanacLink = UiUtils.GetLocalizedAlmanacLink("resource_group_" + item);
				if (!string.IsNullOrEmpty(localizedAlmanacLink))
				{
					list2.Add(localizedAlmanacLink);
				}
				else
				{
					list2.Add(UiUtils.Localize.GetText("resource_group_" + item) ?? "");
				}
			}
			string result = string.Format("{0}: <style=AltColor>{1} ({2})</style>", UiUtils.Localize.GetText("menu_storage"), num, TextFormatting.Join(list2));
			ListPool<string>.Return(list2);
			return result;
		}

		public static string GetTrapDebugInfo(BaseBuildingInstance baseBuildingInstance)
		{
			return string.Empty;
		}

		public static IEnumerable<string> GetProtoQualitySpecificInfos(BaseBuildingBlueprint baseBlueprint)
		{
			List<string> list = new List<string>();
			foreach (BaseBuildingBlueprint item in from bbb in Repository<BaseBuildingRepository, BaseBuildingBlueprint>.Instance.GetAllItems()
				where baseBlueprint.ProtoId == bbb.ProtoId
				select bbb)
			{
				if (item.Quality != ProductQuality.None)
				{
					list.AddRange(GetQualitySpecificInfos(item));
				}
			}
			return list;
		}

		public static IEnumerable<string> GetQualitySpecificInfos(BaseBuildingBlueprint furniture)
		{
			List<string> list = new List<string>();
			string item = "\n<style=AlmEntrySubtitle>" + UiUtils.Localize.GetText($"quality_{furniture.Quality}") + "</style>";
			list.Add(item);
			list.Add(GetLocalizedHitPoints(furniture));
			list.Add(GetLocalizedWealthPoints(furniture));
			list.AddIfNotNullOrEmpty(GetLocalizedBeautyPoints(furniture));
			return list;
		}

		public static string GetProductionBuildings(Resource resource)
		{
			return GetProductionBuildings((resource.GroupIdentifier == string.Empty) ? resource.GetID() : resource.GroupIdentifier);
		}

		public static string GetProductionBuildings(string groupIdentifier)
		{
			HashSet<string> hashSet = new HashSet<string>();
			List<string> list = new List<string>();
			foreach (BaseBuildingBlueprint allItem in Repository<BaseBuildingRepository, BaseBuildingBlueprint>.Instance.GetAllItems())
			{
				if (allItem == null || string.IsNullOrEmpty(allItem.ProductionComponentID) || string.IsNullOrEmpty(allItem.ProductionComponentID))
				{
					continue;
				}
				foreach (string production in Repository<ProductionComponentsRepository, ProductionComponentBlueprint>.Instance.GetByID(allItem.ProductionComponentID).Productions)
				{
					if (production == groupIdentifier && !hashSet.Contains(allItem.GroupIdentifier))
					{
						list.Add(UiUtils.GetLocalizedAlmanacLink("building_name_" + allItem.GetID()));
						hashSet.Add(allItem.GroupIdentifier);
					}
					List<CustomProduct> list2 = Repository<ProductionRepository, NSMedieval.Model.Production>.Instance.GetByID(production)?.CustomProducts;
					if (list2 != null && list2.Count > 0)
					{
						foreach (CustomProduct item in list2)
						{
							foreach (ProductModel product in item.Products)
							{
								if (!(product.GetID() != groupIdentifier) && !hashSet.Contains(allItem.GroupIdentifier))
								{
									list.Add(UiUtils.GetLocalizedAlmanacLink("building_name_" + allItem.GetID()));
									hashSet.Add(allItem.GroupIdentifier);
								}
							}
						}
					}
					List<ProductModel> list3 = Repository<ProductionRepository, NSMedieval.Model.Production>.Instance.GetByID(production.ToString())?.Products;
					if (list3 == null || list3.Count <= 0)
					{
						continue;
					}
					foreach (ProductModel item2 in list3)
					{
						if (!(item2.GetID() != groupIdentifier) && !hashSet.Contains(allItem.GroupIdentifier))
						{
							list.Add(UiUtils.GetLocalizedAlmanacLink("building_name_" + allItem.GetID()));
							hashSet.Add(allItem.GroupIdentifier);
						}
					}
				}
			}
			if (list.Count == 0)
			{
				return string.Empty;
			}
			list = list.Distinct().ToList();
			return UiUtils.Localize.GetText("menu_produced_in") + ": " + TextFormatting.Join(list);
		}

		private static string GetLocalizedProductions(BaseBuildingBlueprint buildableBase)
		{
			if (string.IsNullOrEmpty(buildableBase.ProductionComponentID))
			{
				return string.Empty;
			}
			ProductionComponentBlueprint byID = Repository<ProductionComponentsRepository, ProductionComponentBlueprint>.Instance.GetByID(buildableBase.ProductionComponentID);
			if (byID == null)
			{
				return string.Empty;
			}
			List<string> list = new List<string>();
			if (byID?.Productions != null)
			{
				foreach (string production in byID.Productions)
				{
					NSMedieval.Model.Production byID2 = Repository<ProductionRepository, NSMedieval.Model.Production>.Instance.GetByID(production);
					if (byID2.UseIngredientCombo)
					{
						foreach (Resource uniqueResourcesWithIngredient in Repository<ResourceRepository, Resource>.Instance.UniqueResourcesWithIngredients)
						{
							string linkKey = ResourceUtils.GetLinkKey(uniqueResourcesWithIngredient.GetID());
							if (!string.IsNullOrEmpty(linkKey))
							{
								list.Add(UiUtils.GetLocalizedAlmanacLink(linkKey));
							}
						}
					}
					List<CustomProduct> customProducts = byID2.CustomProducts;
					bool isEnabled;
					if (customProducts != null && customProducts.Count > 0)
					{
						foreach (CustomProduct item in customProducts)
						{
							foreach (ProductModel product in item.Products)
							{
								string linkKey2 = ResourceUtils.GetLinkKey(product.GetID());
								if (string.IsNullOrEmpty(linkKey2))
								{
									FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(29, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\BuildingUtils.cs");
									if (isEnabled)
									{
										messageBuilder.AppendLiteral("Missing product linkKey for: ");
										messageBuilder.AppendFormatted(product.GetID());
									}
									Log.Warning(messageBuilder);
								}
								else
								{
									list.Add(UiUtils.GetLocalizedAlmanacLink(linkKey2));
								}
							}
						}
						continue;
					}
					List<ProductModel> products = Repository<ProductionRepository, NSMedieval.Model.Production>.Instance.GetByID(production).Products;
					if (products != null && products.Count > 0)
					{
						foreach (ProductModel item2 in products)
						{
							string linkKey3 = ResourceUtils.GetLinkKey(item2.GetID());
							if (string.IsNullOrEmpty(linkKey3))
							{
								FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(29, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\BuildingUtils.cs");
								if (isEnabled)
								{
									messageBuilder.AppendLiteral("Missing product linkKey for: ");
									messageBuilder.AppendFormatted(item2.GetID());
								}
								Log.Warning(messageBuilder);
							}
							else
							{
								list.Add(UiUtils.GetLocalizedAlmanacLink(linkKey3));
							}
						}
					}
					else
					{
						string linkKey4 = ResourceUtils.GetLinkKey(production);
						if (!string.IsNullOrEmpty(linkKey4))
						{
							list.Add(UiUtils.GetLocalizedAlmanacLink(linkKey4));
						}
					}
				}
			}
			list = list.Distinct().ToList();
			return UiUtils.Localize.GetText("menu_produce") + ": " + TextFormatting.Join(list);
		}

		private static string GetLocalizedHeatEmission(BaseBuildingInstance baseBuildableObject)
		{
			ThermalModel defaultThermalModel = baseBuildableObject.Blueprint.DefaultThermalModel;
			if (defaultThermalModel == null)
			{
				return string.Empty;
			}
			ThermalModel thermalModel = baseBuildableObject.ThermalModel;
			float num = defaultThermalModel.Emission;
			float num2 = ((!(thermalModel == null)) ? thermalModel.Emission : 0);
			float num3 = ((num >= num2) ? num : num2);
			if (num3 != 0f)
			{
				return string.Format("{0}: <style=AltColor>{1}</style>", UiUtils.Localize.GetText("thermal_emission"), num3);
			}
			return string.Empty;
		}

		private static string GetLocalizedHeatEmission(BaseBuildingBlueprint baseBuildingBlueprint)
		{
			ThermalModel defaultThermalModel = baseBuildingBlueprint.DefaultThermalModel;
			if (defaultThermalModel == null)
			{
				return string.Empty;
			}
			ThermalModel thermalModel = null;
			if (!string.IsNullOrEmpty(baseBuildingBlueprint.ProductionComponentID))
			{
				ProductionComponentBlueprint byID = Repository<ProductionComponentsRepository, ProductionComponentBlueprint>.Instance.GetByID(baseBuildingBlueprint.ProductionComponentID);
				if (byID != null)
				{
					thermalModel = byID.ThermalModel;
				}
			}
			else if (!string.IsNullOrEmpty(baseBuildingBlueprint.FuelConsumerComponentID))
			{
				FuelConsumerComponentBlueprint byID2 = Repository<FuelConsumerComponentRepository, FuelConsumerComponentBlueprint>.Instance.GetByID(baseBuildingBlueprint.FuelConsumerComponentID);
				if (byID2 != null && byID2.CachedThermalModels.TryGetValue(byID2.StartingThermalModel, out var value))
				{
					thermalModel = value;
				}
			}
			float num = defaultThermalModel.Emission;
			float num2 = ((!(thermalModel == null)) ? thermalModel.Emission : 0);
			float num3 = ((num >= num2) ? num : num2);
			if (num3 != 0f)
			{
				return string.Format("{0}: <style=AltColor>{1}</style>", UiUtils.Localize.GetText("thermal_emission"), num3);
			}
			return string.Empty;
		}

		private static string GetLocalizedThermalInsulation(BaseBuildingInstance baseBuildableObject)
		{
			ThermalModel defaultThermalModel = baseBuildableObject.Blueprint.DefaultThermalModel;
			if (defaultThermalModel == null)
			{
				return string.Empty;
			}
			ThermalModel thermalModel = baseBuildableObject.ThermalModel;
			bool flag = baseBuildableObject.BuildingType == BuildingType.Roof || baseBuildableObject.BuildingType == BuildingType.Trap || baseBuildableObject.BuildingType == BuildingType.Floor || baseBuildableObject.BuildingType == BuildingType.Rug;
			float num = (flag ? defaultThermalModel.InsulationVertical : defaultThermalModel.Insulation);
			float num2 = ((thermalModel == null) ? 0f : (flag ? thermalModel.InsulationVertical : thermalModel.Insulation));
			float num3 = ((num >= num2) ? num : num2);
			if (num3 != 0f)
			{
				return string.Format("{0}: <style=AltColor>{1}</style>", UiUtils.Localize.GetText("thermal_insulation"), num3);
			}
			return string.Empty;
		}

		private static string GetLocalizedThermalInsulation(BaseBuildingBlueprint baseBuildingBlueprint)
		{
			ThermalModel defaultThermalModel = baseBuildingBlueprint.DefaultThermalModel;
			if (defaultThermalModel == null)
			{
				return string.Empty;
			}
			ThermalModel thermalModel = null;
			if (!string.IsNullOrEmpty(baseBuildingBlueprint.ProductionComponentID))
			{
				ProductionComponentBlueprint byID = Repository<ProductionComponentsRepository, ProductionComponentBlueprint>.Instance.GetByID(baseBuildingBlueprint.ProductionComponentID);
				if (byID != null)
				{
					thermalModel = byID.ThermalModel;
				}
			}
			else if (!string.IsNullOrEmpty(baseBuildingBlueprint.FuelConsumerComponentID))
			{
				FuelConsumerComponentBlueprint byID2 = Repository<FuelConsumerComponentRepository, FuelConsumerComponentBlueprint>.Instance.GetByID(baseBuildingBlueprint.FuelConsumerComponentID);
				if (byID2 != null && byID2.CachedThermalModels.TryGetValue(byID2.StartingThermalModel, out var value))
				{
					thermalModel = value;
				}
			}
			float num = Mathf.Max(defaultThermalModel.Insulation, defaultThermalModel.InsulationVertical);
			float num2 = ((thermalModel == null) ? 0f : Mathf.Max(thermalModel.Insulation, thermalModel.InsulationVertical));
			float num3 = ((num >= num2) ? num : num2);
			if (num3 != 0f)
			{
				return string.Format("{0}: <style=AltColor>{1}</style>", UiUtils.Localize.GetText("thermal_insulation"), num3);
			}
			return string.Empty;
		}

		private static string GetLocalizedWalkSpeed(BaseBuildingInstance baseBuildingInstance, Vec3Int gridPosition)
		{
			if (baseBuildingInstance.BuildingType != BuildingType.Floor)
			{
				return string.Empty;
			}
			if (gridPosition.Equals(Vec3Int.zero))
			{
				return string.Format("{0}: <style=AltColor>{1}%</style>", UiUtils.Localize.GetText("info_walk_speed"), (int)(100f * baseBuildingInstance.GetSpeedMultiplier()));
			}
			MapNode node = VillageManager.ActiveVillage.Map.GetNode(gridPosition);
			KeyValuePair<HumanoidInstance, WorkerView> keyValuePair = MonoSingleton<WorkerManager>.Instance.AllWorkers.FirstOrDefault();
			if (keyValuePair.Key == null)
			{
				return string.Empty;
			}
			WalkSpeedMultiplier walkSpeedMultiplierBlueprint = keyValuePair.Key.WalkableModel.WalkSpeedMultiplierBlueprint;
			int num = (int)(100f * WalkSpeedMultiplier.GetSpeedMultiplier(walkSpeedMultiplierBlueprint, node));
			return string.Format("{0}: <style=AltColor>{1}%</style>", UiUtils.Localize.GetText("info_walk_speed"), num);
		}

		private static string GetLocalizedWalkSpeed(BaseBuildingBlueprint baseBuildingBlueprint, Vec3Int gridPosition)
		{
			if (baseBuildingBlueprint.BuildingType != BuildingType.Floor)
			{
				return string.Empty;
			}
			if (gridPosition.Equals(Vec3Int.zero))
			{
				return string.Format("{0}: <style=AltColor>{1}%</style>", UiUtils.Localize.GetText("info_walk_speed"), (int)(100f * baseBuildingBlueprint.WalkSpeedMultiplier));
			}
			MapNode node = VillageManager.ActiveVillage.Map.GetNode(gridPosition);
			KeyValuePair<HumanoidInstance, WorkerView> keyValuePair = MonoSingleton<WorkerManager>.Instance.AllWorkers.FirstOrDefault();
			if (keyValuePair.Key == null)
			{
				return string.Empty;
			}
			WalkSpeedMultiplier walkSpeedMultiplierBlueprint = keyValuePair.Key.WalkableModel.WalkSpeedMultiplierBlueprint;
			int num = (int)(100f * WalkSpeedMultiplier.GetSpeedMultiplier(walkSpeedMultiplierBlueprint, node));
			return string.Format("{0}: <style=AltColor>{1}%</style>", UiUtils.Localize.GetText("info_walk_speed"), num);
		}

		public static string GetLocalizedName(string buildableBaseId)
		{
			string text = UiUtils.Localize.GetText(GetLocalizationNameKey(buildableBaseId));
			BaseBuildingBlueprint baseBlueprint = GetBaseBlueprint(buildableBaseId);
			if (baseBlueprint != null && baseBlueprint.HasQuality)
			{
				return text + " (" + UiUtils.Localize.GetText("quality_" + baseBlueprint.Quality.ToString().ToLower()) + ")";
			}
			return text;
		}

		public static string GetLocalizedName(BaseBuildingBlueprint baseBuildingBlueprint)
		{
			string text = UiUtils.Localize.GetText(GetLocalizationNameKey(baseBuildingBlueprint.GetID()));
			if (baseBuildingBlueprint.HasQuality)
			{
				return text + " (" + UiUtils.Localize.GetText("quality_" + baseBuildingBlueprint.Quality.ToString().ToLower()) + ")";
			}
			return GetLocalizedName(baseBuildingBlueprint.GetID());
		}
	}
}
