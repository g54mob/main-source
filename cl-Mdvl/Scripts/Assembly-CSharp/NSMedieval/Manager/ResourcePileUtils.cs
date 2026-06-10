using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Tools;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using NSMedieval.Views.Resources;
using NSMedieval.Village.Map.Pathfinding;
using UI.Enums;
using UnityEngine;

namespace NSMedieval.Manager
{
	public static class ResourcePileUtils
	{
		public static List<ResourcePileInstance> GetPilesFromStockpilesAndShelves()
		{
			return (from item in MonoSingleton<ResourcePileManager>.Instance.AllPiles
				select item.Key into item
				where item.IsPlacedOnStockpile() || item.IsPlacedOnStorageBuilding
				select item).ToList();
		}

		public static bool IsReachableByWorker(ResourcePileInstance pile)
		{
			foreach (HumanoidInstance worker in GlobalSaveController.CurrentVillageData.Workers)
			{
				if (!worker.HasDisposed && !worker.IsInIncognitoMode() && PathfinderUtil.IsPathPossible(worker.WalkableModel, worker.GetNode(), pile.GetNode()))
				{
					return true;
				}
			}
			return false;
		}

		public static bool Reachable(ResourcePileInstance pile, BaseBuildingInstance building)
		{
			foreach (HumanoidInstance worker in GlobalSaveController.CurrentVillageData.Workers)
			{
				if (Reachable(worker, pile, building))
				{
					return true;
				}
			}
			return false;
		}

		public static bool Reachable(CreatureBase creatureBase, ResourcePileInstance pile, BaseBuildingInstance building)
		{
			if (PathfinderUtil.IsPathPossible(creatureBase, pile))
			{
				return PathfinderUtil.IsPathPossible(creatureBase, building);
			}
			return false;
		}

		public static bool Reachable(CreatureBase creatureBase, Resource blueprint, BaseBuildingInstance building)
		{
			bool isReachable = false;
			MonoSingleton<ResourcePileManager>.Instance.BlueprintInstancesSafeOperation(blueprint, delegate(IEnumerable<ResourcePileInstance> piles)
			{
				foreach (ResourcePileInstance pile in piles)
				{
					if (Reachable(creatureBase, pile, building))
					{
						isReachable = true;
						break;
					}
				}
			});
			return isReachable;
		}

		public static bool Reachable(Resource blueprint, BaseBuildingInstance building)
		{
			foreach (HumanoidInstance worker in GlobalSaveController.CurrentVillageData.Workers)
			{
				if (Reachable(worker, blueprint, building))
				{
					return true;
				}
			}
			return false;
		}

		public static string GetStorage(ResourcePileInstance pileInstance)
		{
			if (pileInstance == null || !pileInstance.IsStoredOnStockpile())
			{
				return string.Empty;
			}
			string text = string.Empty;
			if (pileInstance.InstanceStockpile != null)
			{
				text = pileInstance.InstanceStockpile.StorageName;
			}
			if (string.IsNullOrEmpty(text) && pileInstance.InstanceStorage != null)
			{
				foreach (ShelfComponentInstance componentInstance in pileInstance.Map.ShelfComponentManager.ComponentInstances)
				{
					if (componentInstance.AllStorage.Contains(pileInstance.InstanceStorage))
					{
						text = componentInstance.StorageName;
						break;
					}
				}
			}
			int storageUniqueId = GetStorageUniqueId(pileInstance);
			if (text == string.Empty || storageUniqueId.Equals(0))
			{
				return text;
			}
			return string.Format("<link=\"{0}_{1}\"><style={2}>{3}</style></link>", "select_storage", storageUniqueId, LinkType.LinkAnimal, text);
		}

		public static int GetStorageUniqueId(ResourcePileInstance pileInstance)
		{
			return pileInstance.InstanceStockpile?.UniqueId ?? pileInstance.InstanceStorage?.UniqueId ?? 0;
		}

		public static float GetStatCurrentPercent(StatType statType, ResourcePileInstance resourcePileInstance)
		{
			StatInstance statInstance = resourcePileInstance?.GetStat(statType);
			if (statInstance == null)
			{
				return 0f;
			}
			float max = statInstance.Max;
			float current = statInstance.Current;
			if (statInstance.Max == 0f || statInstance.Current == 0f)
			{
				return 0f;
			}
			if (statType == StatType.Fermentation)
			{
				return 1f - current / max;
			}
			return current / max;
		}

		public static List<string> GetTooltipLines(ResourcePileInstance resourcePileInstance)
		{
			List<string> list = new List<string>();
			list.Add(TooltipStyles.ApplyStyle(AssetUtils.GetSpriteAsset(resourcePileInstance.Blueprint.IconPath) + " " + GetFormattedPileName(resourcePileInstance), TooltipStyles.TooltipTitle));
			if (resourcePileInstance.IsForbidden)
			{
				list.Add(TooltipStyles.ApplyStyle(MonoSingleton<LocalizationController>.Instance.GetText("forbidden_resource"), TooltipStyles.DefaultRed));
			}
			if (ResourceUtils.GetLocalizedMaterial(resourcePileInstance.Blueprint, out var localizedMaterial))
			{
				list.Add(UiUtils.Localize.GetText("resource_group_Material") + ": " + localizedMaterial);
			}
			StatInstance stat = resourcePileInstance.GetStat(StatType.Health);
			if (stat != null)
			{
				float num = resourcePileInstance.GetStoredResource()?.GetHealthInPercentage() ?? (-1f);
				int num2 = Mathf.RoundToInt(stat.Current);
				int num3 = Mathf.RoundToInt(stat.Max);
				if (num2 == num3 && num < 100f)
				{
					num2--;
				}
				string item = string.Format("<#{0}>{1}/{2} </color>  {3}", ColorTools.GetHexColor(num2, num3), num2, num3, MonoSingleton<LocalizationController>.Instance.GetText("menu_hit_points"));
				list.Add(item);
			}
			list.Add(MonoSingleton<LocalizationController>.Instance.GetText("resource_categories") + ": " + ResourceUtils.GetLocalizedCategories(resourcePileInstance.Blueprint));
			if (!LocKeyUtils.GetTooltipLines(resourcePileInstance.Blueprint.LocKeys, out var lines))
			{
				return list;
			}
			string[] array = lines;
			foreach (string text in array)
			{
				if (text.Equals("resource_tooltip_ice_room"))
				{
					list.Add(MonoSingleton<LocalizationController>.Instance.GetText(text).Replace("<zero_temp>", WorldDate.GetLocalizedTemperature(0f)));
				}
				else
				{
					list.Add(MonoSingleton<LocalizationController>.Instance.GetText(text));
				}
			}
			return list;
		}

		public static string GetFormattedPileName(ResourcePileInstance resourcePileInstance)
		{
			ResourceInstance storedResource = resourcePileInstance.GetStoredResource();
			if (storedResource == null)
			{
				return ResourceUtils.GetLocalizedResourcePileName(resourcePileInstance.BlueprintId);
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("resource_pile_name_count_pattern".ToLocalized(), ResourceUtils.GetLocalizedResourceName(resourcePileInstance.BlueprintId), storedResource.Amount);
			if (!string.IsNullOrEmpty(storedResource.LocalizedInheritedName))
			{
				stringBuilder.Append("(" + storedResource.LocalizedInheritedName + ")");
			}
			return stringBuilder.ToString();
		}
	}
}
