using System.Collections.Generic;
using System.Linq;
using System.Text;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Research;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Tools;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using UI.Enums;
using UnityEngine;

namespace NSMedieval.UI.Utils
{
	public static class ResourceUtils
	{
		public static string GetLocalizedProtoName(string id)
		{
			Resource blueprint = GetBlueprint(id);
			if ((object)blueprint != null)
			{
				return GetLocalizedResourceName(blueprint, showQuality: false);
			}
			return UiUtils.Localize.GetText("resource_name_" + id);
		}

		public static string GetLocalizedLink(string id)
		{
			Resource blueprint = GetBlueprint(id);
			if ((object)blueprint != null)
			{
				return UiUtils.GetLocalizedAlmanacLink(LocKeyUtils.GetName(blueprint.LocKeys));
			}
			return GetLocalizedResourceName(id);
		}

		public static string GetLocalizedResourceName(string id, bool showQuality = true, bool showMaterial = false)
		{
			Resource blueprint = GetBlueprint(id);
			if ((object)blueprint != null)
			{
				return GetLocalizedResourceName(blueprint, showQuality, showMaterial);
			}
			return UiUtils.Localize.GetText("resource_name_" + id);
		}

		public static string GetLocalizedResourceName(Resource resource, bool showQuality = true, bool showMaterial = false)
		{
			string text = UiUtils.Localize.GetText(LocKeyUtils.GetName(resource.LocKeys));
			if (!showQuality || resource.Quality == ProductQuality.None)
			{
				if (!resource.Tainted)
				{
					return text;
				}
				return text + " (" + UiUtils.Localize.GetText("tainted") + ")";
			}
			string text2 = UiUtils.Localize.GetText("quality_" + resource.Quality.ToString().ToLower());
			if (string.IsNullOrEmpty(resource.Material) || !showMaterial)
			{
				if (!resource.Tainted)
				{
					return text + " (" + text2 + ")";
				}
				return text + " (" + text2 + ") (" + UiUtils.Localize.GetText("tainted") + ")";
			}
			string text3 = UiUtils.Localize.GetText(LocKeyUtils.GetName(Repository<MaterialSettingsRepository, MaterialSettings>.Instance.GetByID(resource.Material).LocKeys));
			if (!resource.Tainted)
			{
				return text + " (" + text2 + ", " + text3 + ")";
			}
			return text + " (" + text2 + ", " + text3 + ") (" + UiUtils.Localize.GetText("tainted") + ")";
		}

		public static string GetLocalizedResourceInfo(string id)
		{
			Resource blueprint = GetBlueprint(id);
			if ((object)blueprint != null)
			{
				if (blueprint.IsBuildingStructure)
				{
					return BuildingUtils.GetLocalizedInfo(blueprint.BuildingBlueprintID);
				}
				return UiUtils.Localize.GetText(LocKeyUtils.GetInfo(blueprint.LocKeys));
			}
			return UiUtils.Localize.GetText("resource_info_" + id);
		}

		public static string GetLocalizedMaterials(Resource resource)
		{
			if (resource == null)
			{
				return string.Empty;
			}
			Resource protoItemById = Repository<ResourceRepository, Resource>.Instance.GetProtoItemById(resource.GetID());
			if (protoItemById == null || protoItemById.Materials == null || protoItemById.Materials.Length == 0)
			{
				return string.Empty;
			}
			List<string> list = new List<string>();
			string[] materials = protoItemById.Materials;
			foreach (string text in materials)
			{
				if (string.IsNullOrEmpty(text))
				{
					continue;
				}
				MaterialSettings byID = Repository<MaterialSettingsRepository, MaterialSettings>.Instance.GetByID(text);
				if (byID == null)
				{
					bool isEnabled;
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(25, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\ResourceUtils.cs");
					if (isEnabled)
					{
						messageBuilder.AppendFormatted(text);
						messageBuilder.AppendLiteral(" MaterialSettings is null");
					}
					Log.Info(messageBuilder);
				}
				else
				{
					list.Add(UiUtils.GetMaterialLink(byID.GetID(), UiUtils.Localize.GetText(LocKeyUtils.GetName(byID.LocKeys))));
				}
			}
			if (list.Count <= 0)
			{
				return string.Empty;
			}
			return UiUtils.Localize.GetText("almanac_group_name_Material") + ": " + TextFormatting.Join(list);
		}

		public static bool GetLocalizedMaterial(Resource resource, out string localizedMaterial)
		{
			localizedMaterial = string.Empty;
			if (string.IsNullOrEmpty(resource.Material))
			{
				return false;
			}
			MaterialSettings byID = Repository<MaterialSettingsRepository, MaterialSettings>.Instance.GetByID(resource.Material);
			if (byID == null)
			{
				return false;
			}
			localizedMaterial = UiUtils.Localize.GetText(LocKeyUtils.GetName(byID.LocKeys));
			return true;
		}

		public static string GetIconPath(string id)
		{
			Resource byID = Repository<ResourceRepository, Resource>.Instance.GetByID(id);
			if (byID != null && !string.IsNullOrEmpty(byID.IconPath))
			{
				return byID.IconPath;
			}
			if (BuildingUtils.GetBaseBlueprint(id) != null)
			{
				return "ph";
			}
			return id;
		}

		public static string GetIconBackgroundPath(string id)
		{
			Resource byID = Repository<ResourceRepository, Resource>.Instance.GetByID(id);
			if (byID == null || string.IsNullOrEmpty(byID.IconBackgroundPath))
			{
				return string.Empty;
			}
			return byID.IconBackgroundPath;
		}

		public static string GetTextIcon(string id)
		{
			Resource blueprint = GetBlueprint(id);
			if ((object)blueprint != null)
			{
				return GetTextIcon(blueprint);
			}
			return string.Empty;
		}

		public static string GetTextIcon(Resource resource)
		{
			if (resource == null || string.IsNullOrEmpty(resource.IconPath))
			{
				return AssetUtils.GetSpriteAsset("protoAsset");
			}
			string text = resource.IconPath.Split('/').Last();
			if (string.IsNullOrEmpty(text) && resource.IsBuildingStructure)
			{
				text = (SpriteAssetRepository.SpriteAssetNames.Contains(resource.GetID()) ? BuildingUtils.GetBaseBlueprint(resource.GetID()).IconPath : "pile_ph");
			}
			string text2 = (string.IsNullOrEmpty(resource.IconBackgroundPath) ? string.Empty : resource.IconBackgroundPath.Split('/').Last());
			string iconColor = GetIconColor(resource.GetID());
			if (text2.Equals(string.Empty) && iconColor.Equals(string.Empty))
			{
				return AssetUtils.GetSpriteAsset(text);
			}
			return AssetUtils.GetSpriteAsset(text, text2, iconColor);
		}

		public static string GetIconColor(string resourceId)
		{
			Resource blueprint = GetBlueprint(resourceId);
			if ((object)blueprint == null)
			{
				return string.Empty;
			}
			if (!string.IsNullOrEmpty(blueprint.Material))
			{
				return Repository<MaterialSettingsRepository, MaterialSettings>.Instance.GetByID(blueprint.Material).IconColorValue;
			}
			if (!string.IsNullOrEmpty(blueprint.IconColorOverlay))
			{
				return blueprint.IconColorOverlay;
			}
			return string.Empty;
		}

		public static string GetLocalizedResourcePileName(string id)
		{
			string localizedResourceName = GetLocalizedResourceName(id);
			Resource blueprint = GetBlueprint(id);
			if ((object)blueprint == null)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(43, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\ResourceUtils.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Resource ");
					messageBuilder.AppendFormatted(id);
					messageBuilder.AppendLiteral(" not found in resource repository.");
				}
				Log.Info(messageBuilder);
				return string.Empty;
			}
			if ((decimal)blueprint.StackingLimit <= 1m)
			{
				return localizedResourceName;
			}
			Language currentLanguageEnum = UiUtils.Localize.GetCurrentLanguageEnum();
			if (currentLanguageEnum != Language.Polish && currentLanguageEnum != Language.Turkish)
			{
				return localizedResourceName + " " + UiUtils.Localize.GetText("hud_lb_pile");
			}
			return UiUtils.Localize.GetText("hud_lb_pile") + " " + localizedResourceName;
		}

		public static string GetDefaultClothesAddress(BodyType bodyType)
		{
			return bodyType.ToString().ToLower() + "_underwear";
		}

		public static GameObject GetPrefabPile(string id)
		{
			GameObject byAddress = MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress(id);
			if (byAddress == null)
			{
				byAddress = MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress("default_pile");
			}
			return byAddress;
		}

		public static string GetLocalizedNameWithSprite(string resourceId)
		{
			Resource blueprint = GetBlueprint(resourceId);
			if ((object)blueprint != null)
			{
				return GetLocalizedNameWithSprite(blueprint);
			}
			return string.Empty;
		}

		public static string GetLocalizedNameWithSprite(Resource resource)
		{
			string textIcon = GetTextIcon(resource);
			string localizedResourceName = GetLocalizedResourceName(resource.GetID());
			if (BuildingUtils.GetBaseBlueprint(resource.GetID()) == null)
			{
				return textIcon + " " + localizedResourceName;
			}
			localizedResourceName = BuildingUtils.GetLocalizedName(Repository<BaseBuildingRepository, BaseBuildingBlueprint>.Instance.GetByID(resource.GetID()));
			return textIcon + " " + localizedResourceName;
		}

		public static List<string> GetInfoLines(Resource resource)
		{
			List<string> list = new List<string>();
			string localizedHitPoints = GetLocalizedHitPoints(resource);
			if (!string.IsNullOrEmpty(localizedHitPoints))
			{
				list.Add(localizedHitPoints);
			}
			list.AddRange(GetGeneralInfoLines(resource));
			return list;
		}

		public static List<string> GetGeneralInfoLines(Resource resource)
		{
			List<string> list = new List<string>();
			list.AddIfNotNullOrEmpty(GetLocalizedWeights(resource));
			list.AddIfNotNullOrGreaterThan(GetLocalizedStackingLimit(resource), resource.StackingLimit, 1f);
			list.AddIfNotNullOrGreaterThan(string.Format("{0}: <style=AltColor>{1}</style>", UiUtils.Localize.GetText("menu_nutrition"), resource.Nutrition), resource.Nutrition, 0f);
			list.AddIfNotNullOrGreaterThan(string.Format("{0}: <style=AltColor>{1}</style>", UiUtils.Localize.GetText("healing_multiplier"), resource.Healing), resource.Healing, 0f);
			list.AddIfNotNull(GetLocalizedWealth(resource), resource.WealthPoints);
			list.AddIfNotNull(UiUtils.Localize.GetText("resource_categories") + ": " + GetLocalizedCategories(resource), GetLocalizedCategories(resource));
			if (!string.IsNullOrEmpty(GetLocalizedUseEffectors(resource)))
			{
				list.Add(UiUtils.Localize.GetText("effector_on_use") + ": <style=AltColor>" + GetLocalizedUseEffectors(resource) + "</style>");
			}
			if (!string.IsNullOrEmpty(GetLocalizedProximityEffectors(resource)))
			{
				list.Add(UiUtils.Localize.GetText("effector_proximity") + ": <style=AltColor>" + GetLocalizedProximityEffectors(resource) + "</style>");
			}
			list.AddIfNotNullOrEmpty(BuildingUtils.GetProductionBuildings(resource));
			list.AddIfNotNullOrEmpty(GetLocalizedResearchLink(resource));
			list.AddIfNotNullOrEmpty(GetAlmanacTags(resource));
			list.AddIfNotNullOrGreaterThan(string.Format("{0}: {1}", MonoSingleton<LocalizationController>.Instance.GetText("fuel_strength"), resource.CaloriesCount), resource.CaloriesCount, 0f);
			return list;
		}

		public static string GetLocalizedResearchLink(Resource resource)
		{
			foreach (ResearchModel allItem in Repository<ResearchRepository, ResearchModel>.Instance.GetAllItems())
			{
				foreach (ResearchUnlock unlock in allItem.Unlocks)
				{
					if (unlock.UnlockId == resource.GetID() || unlock.UnlockId == resource.ProtoId)
					{
						return "unlocked_with_research".ToLocalized() + ": " + UiUtils.GetResearchLink(allItem.GetID(), LocKeyUtils.GetName(allItem.LocKeys).ToLocalized());
					}
				}
			}
			return string.Empty;
		}

		private static string GetLocalizedStackingLimit(Resource resource)
		{
			return string.Format("{0}: <style=AltColor>{1}</style>", UiUtils.Localize.GetText("max_stack"), resource.StackingLimit);
		}

		private static string GetLocalizedWeights(Resource resource)
		{
			if (resource.Weight != 0f)
			{
				return string.Format("{0}: <style=AltColor>{1}</style>", UiUtils.Localize.GetText("menu_character_weight"), resource.Weight);
			}
			return string.Empty;
		}

		public static string GetLocalizedWealth(Resource resource)
		{
			return string.Format("{0}: <style=AltColor>{1:F1}</style>", UiUtils.Localize.GetText("info_panel_wealth"), resource.WealthPoints);
		}

		public static string GetLocalizedHitPoints(Resource resource)
		{
			return string.Format("{0}: <style=AltColor>{1}</style>", UiUtils.Localize.GetText("menu_hit_points"), resource.Hitpoints);
		}

		public static string GetLocalizedCategories(ResourceCategory resourceCategory)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<style=ResourceCategory>");
			using PooledList<ResourceCategory> pooledList = ListPool<ResourceCategory>.GetJanitor();
			ResourceCategory[] allResourceCategories = EnumValues.AllResourceCategories;
			foreach (ResourceCategory resourceCategory2 in allResourceCategories)
			{
				if (resourceCategory.HasFlag(resourceCategory2))
				{
					pooledList.Add(resourceCategory2);
				}
			}
			for (int j = 0; j < pooledList.Count; j++)
			{
				stringBuilder.Append(UiUtils.Localize.GetText($"resource_category_name_{pooledList[j]}"));
				if (pooledList.Count > 0 && j < pooledList.Count - 1)
				{
					stringBuilder.Append(", ");
				}
			}
			stringBuilder.Append("</style>");
			return stringBuilder.ToString();
		}

		public static string GetLocalizedCategories(Resource resource)
		{
			return GetLocalizedCategories(resource.Category);
		}

		public static string GetLocalizedUseEffectors(Resource resource)
		{
			List<string> list = new List<string>();
			if (resource.OnUseEffects != null && resource.OnUseEffects.Length != 0)
			{
				string[] onUseEffects = resource.OnUseEffects;
				foreach (string id in onUseEffects)
				{
					StatEffector byID = Repository<EffectorRepository, StatEffector>.Instance.GetByID(id);
					if (byID == null)
					{
						bool isEnabled;
						FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(39, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\ResourceUtils.cs");
						if (isEnabled)
						{
							messageBuilder.AppendFormatted(resource.GetID());
							messageBuilder.AppendLiteral(".OnUseEffects: string is null or empty!");
						}
						Log.Warning(messageBuilder);
					}
					else if (!byID.UIGroup.HasFlag(EffectorUiGroup.None))
					{
						list.Add(UiUtils.Localize.GetText(LocKeyUtils.GetName(byID.LocKeys)));
					}
				}
			}
			return UiUtils.Localize.JoinLocalized(list);
		}

		public static string GetSortingGroup(Resource blueprint)
		{
			string key = "resource_group_" + blueprint.SortingGroup;
			return UiUtils.Localize.GetText(key);
		}

		public static string GetLocalizedProximityEffectors(Resource resource)
		{
			List<string> list = new List<string>();
			if (!string.IsNullOrEmpty(resource.ProximityEffector))
			{
				StatEffector byID = Repository<EffectorRepository, StatEffector>.Instance.GetByID(resource.ProximityEffector);
				if ((object)byID != null)
				{
					LocKeys[] locKeys = byID.LocKeys;
					if (locKeys != null)
					{
						list.Add(UiUtils.Localize.GetText(LocKeyUtils.GetName(locKeys)) ?? "");
					}
				}
			}
			if (!string.IsNullOrEmpty(resource.ProximityEnterEffector))
			{
				StatEffector byID2 = Repository<EffectorRepository, StatEffector>.Instance.GetByID(resource.ProximityEnterEffector);
				if ((object)byID2 != null)
				{
					LocKeys[] locKeys2 = byID2.LocKeys;
					if (locKeys2 != null)
					{
						list.Add(UiUtils.Localize.GetText(LocKeyUtils.GetName(locKeys2)));
					}
				}
			}
			return TextFormatting.Join(list);
		}

		public static string GetAlmanacTags(Resource resource)
		{
			List<string> almanacTags = resource.AlmanacTags;
			if (almanacTags == null || almanacTags.Count == 0)
			{
				return string.Empty;
			}
			string text = UiUtils.JoinLocalizedLinks(almanacTags, LinkType.LinkAlmanac);
			if (!text.Equals(string.Empty))
			{
				return UiUtils.Localize.GetText("related_topics") + ": " + text;
			}
			return text;
		}

		public static string GetTruncatedQualityID(Resource resource)
		{
			if (resource.HasQuality)
			{
				return resource.GetID().Substring(resource.Quality.ToString().Length + 1);
			}
			return resource.GetID();
		}

		public static string GetLinkKey(string resourceId)
		{
			if (resourceId == "shield")
			{
				return "almanac_group_name_Shields";
			}
			if (Repository<ResourceRepository, Resource>.Instance.TryGetValue(resourceId, out var model))
			{
				return LocKeyUtils.GetName(model.LocKeys);
			}
			if (Repository<ResourceRepository, Resource>.Instance.TryGetValue("flimsy_" + resourceId, out var model2))
			{
				return LocKeyUtils.GetName(model2.LocKeys);
			}
			Resource byGroup = Repository<ResourceRepository, Resource>.Instance.GetByGroup(resourceId);
			if ((object)byGroup != null)
			{
				return LocKeyUtils.GetName(byGroup.LocKeys);
			}
			Resource byProtoID = Repository<ResourceRepository, Resource>.Instance.GetByProtoID(resourceId);
			if ((object)byProtoID != null)
			{
				return LocKeyUtils.GetName(byProtoID.LocKeys);
			}
			return string.Empty;
		}

		public static bool IsItem(Resource resource)
		{
			if (resource == null)
			{
				return false;
			}
			return (resource.Category & ResourceCategory.CtgItem) != 0;
		}

		public static List<string> GetTooltipData(string id)
		{
			Resource blueprint = GetBlueprint(id);
			if ((object)blueprint != null)
			{
				return GetTooltipData(blueprint);
			}
			bool isEnabled;
			FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(35, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\ResourceUtils.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("GetTooltipData failed for resource ");
				messageBuilder.AppendFormatted(id);
			}
			Log.Error(messageBuilder);
			return new List<string>();
		}

		public static List<string> GetTooltipData(Resource resource)
		{
			List<string> list = new List<string>();
			if (resource == null)
			{
				return list;
			}
			string line = (string.IsNullOrEmpty(resource.BuildingBlueprintID) ? GetLocalizedResourceName(resource) : BuildingUtils.GetLocalizedName(resource.GetID()));
			list.Add(TooltipStyles.ApplyStyle(line, TooltipStyles.TooltipTitle));
			if (resource.Nutrition > 0f)
			{
				list.Add(string.Format("{0}: {1}", MonoSingleton<LocalizationController>.Instance.GetText("menu_nutrition"), resource.Nutrition));
			}
			list.Add(string.Format("{0}: {1}{2}", MonoSingleton<LocalizationController>.Instance.GetText("menu_character_weight"), resource.Weight, MonoSingleton<LocalizationController>.Instance.GetText("general_kg")));
			if (!resource.Category.Equals(ResourceCategory.None))
			{
				list.Add(MonoSingleton<LocalizationController>.Instance.GetText("resource_categories") + ":\n" + GetLocalizedCategories(resource));
			}
			if (LocKeyUtils.GetTooltipLines(resource.LocKeys, out var lines))
			{
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
			}
			return list;
		}

		private static Resource GetBlueprint(string id)
		{
			if (!Repository<ResourceRepository, Resource>.Instance.TryGetValue(id, out var model))
			{
				return Repository<ResourceRepository, Resource>.Instance.GetByGroupIdentifier(id);
			}
			return model;
		}
	}
}
