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
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Resources;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using UnityEngine;

namespace NSMedieval.UI.Utils
{
	public static class EquipmentUtils
	{
		public static List<string> GetInfoLines(Resource resource)
		{
			Equipment equipment = GetAllItemsByQuality(resource).FirstOrDefault();
			List<string> list = new List<string>();
			if (equipment == null)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(40, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\EquipmentUtils.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(resource.GetID());
					messageBuilder.AppendLiteral(" returned no elements. Not an Equipment!");
				}
				Log.Info(messageBuilder);
			}
			list.AddIfNotNullOrEmpty(GetLocalizedIsTwoHanded(equipment));
			list.AddIfNotNullOrEmpty("\n" + ResourceUtils.GetLocalizedMaterials(resource));
			list.AddIfNotNullOrEmpty(GetSkillLevelsLocalized(equipment));
			return list;
		}

		public static Dictionary<string, List<string>> GetMaterialQualityInfoLines(Resource resource)
		{
			Dictionary<string, List<Equipment>> allItemsByMaterialQuality = GetAllItemsByMaterialQuality(resource);
			Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
			foreach (KeyValuePair<string, List<Equipment>> item in allItemsByMaterialQuality)
			{
				if (!dictionary.ContainsKey(item.Key))
				{
					dictionary.Add(item.Key, new List<string>());
				}
				foreach (Equipment item2 in item.Value)
				{
					dictionary[item.Key].AddRange(GetQualitySpecificInfos(item2));
				}
			}
			return dictionary;
		}

		public static IEnumerable<string> GetQualitySpecificInfos(Equipment item)
		{
			Resource byID = Repository<ResourceRepository, Resource>.Instance.GetByID(item.GetID());
			List<string> list = new List<string>();
			string item2 = "\n<style=AlmEntrySubtitle>" + UiUtils.Localize.GetText($"quality_{byID.Quality}") + "</style>";
			if (ResourceUtils.GetLocalizedMaterial(byID, out var localizedMaterial))
			{
				item2 = "\n<style=AlmEntrySubtitle>" + UiUtils.Localize.GetText($"quality_{byID.Quality}") + " (" + localizedMaterial + ")</style>";
			}
			list.Add(item2);
			list.Add(ResourceUtils.GetLocalizedHitPoints(byID));
			list.Add(ResourceUtils.GetLocalizedWealth(byID));
			list.AddIfNotNullOrGreaterThan(string.Format("{0}: <style=AltColor>{1}</style>", UiUtils.Localize.GetText("damage"), item.PrimaryDamage), item.PrimaryDamage, 0f);
			list.AddIfNotNullOrGreaterThan(string.Format("{0}: <style=AltColor>{1}</style>", UiUtils.Localize.GetText("armor_rating"), item.ArmorRating), item.ArmorRating, 0f);
			list.AddIfNotNullOrGreaterThan(GetLocalizedPrecision(item), item.PrimaryPrecision, 0f);
			list.AddIfNotNullOrGreaterThan(GetLocalizedPrecisionFallof(item), item.PrimaryPrecisionFalloff, 0f);
			list.AddIfNotNullOrGreaterThan(GetLocalizedIgnoresArmor(item), item.PrimaryIgnoresArmor, 0f);
			list.AddIfNotNullOrGreaterThan(GetLocalizedArmorDamage(item), item.PrimaryArmorDamage, 0f);
			list.AddIfNotNullOrGreaterThan(GetLocalizedBuildingDamage(item), item.PrimaryBuildingDamage, 0f);
			list.AddIfNotNullOrGreaterThan(GetLocalizedRange(item), item.PrimaryRange, 0f);
			list.AddIfNotNullOrGreaterThan(GetLocalizedAttackDuration(item), item.PrimaryAttackSpeed, 0f);
			list.AddIfNotNullOrGreaterThan(GetLocalizedMeleeCover(item), item.GetCoverChance(DamageType.Melee), 0f);
			list.AddIfNotNullOrGreaterThan(GetLocalizedRangedCover(item), item.GetCoverChance(DamageType.Ranged), 0f);
			string localizedMinTemperature = GetLocalizedMinTemperature(item);
			string localizedMaxTemperature = GetLocalizedMaxTemperature(item);
			string localizedEquipEffectors = GetLocalizedEquipEffectors(item);
			if (!string.IsNullOrEmpty(localizedMinTemperature))
			{
				list.Add(localizedMinTemperature);
			}
			if (!string.IsNullOrEmpty(localizedMaxTemperature))
			{
				list.Add(localizedMaxTemperature);
			}
			if (!string.IsNullOrEmpty(localizedEquipEffectors))
			{
				list.Add(localizedEquipEffectors);
			}
			return list;
		}

		public static ItemQuality[] GetItemQualities(string id)
		{
			Equipment byID = Repository<EquipmentRepository, Equipment>.Instance.GetByID(id);
			if (byID == null)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(29, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\EquipmentUtils.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(id);
					messageBuilder.AppendLiteral(" is missing in Equipment.json");
				}
				Log.Info(messageBuilder);
				return null;
			}
			return byID.ItemType switch
			{
				ItemType.Weapon => Repository<WeaponQualitySettingsRepository, WeaponQualitySettings>.Instance.GetItemQualitiesByWeaponType(byID.PrimaryWeaponType), 
				ItemType.Garment => Repository<GarmentQualitySettingsRepository, GarmentQualitySettings>.Instance.GetItemQualitiesByGarmentType(byID.GarmentType), 
				ItemType.Armor => Repository<ArmorQualitySettingsRepository, ArmorQualitySettings>.Instance.GetItemQualitiesByArmorType(byID.ArmorType), 
				_ => null, 
			};
		}

		public static string GetSkillLevelsLocalized(Equipment equipment)
		{
			if (equipment.RequiredSkills.Count <= 0)
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(MonoSingleton<LocalizationController>.Instance.GetText("skill_needed") + ": ");
			foreach (SkillLevelPair requiredSkill in equipment.RequiredSkills)
			{
				string text = requiredSkill.Key.ToString().ToLower();
				stringBuilder.Append(string.Format("{0} <color=#ffeca8>{1} {2}</color>   ", AssetUtils.GetSpriteAsset(text ?? ""), requiredSkill.Value, MonoSingleton<LocalizationController>.Instance.GetText($"skill_name_{requiredSkill.Key}")));
			}
			return stringBuilder.ToString();
		}

		public static string GetLocalizedMaxTemperature(Equipment item)
		{
			if (item.WarmthModifier.Max == 0f && item.WarmthModifier.Min == 0f)
			{
				return string.Empty;
			}
			return UiUtils.Localize.GetText("general_max_temperature") + ": <style=AltColor>" + WorldDate.GetLocalizedTemperature(item.WarmthModifier.Max) + "</style>";
		}

		public static string GetLocalizedMinTemperature(Equipment item)
		{
			if (item.WarmthModifier.Max == 0f && item.WarmthModifier.Min == 0f)
			{
				return string.Empty;
			}
			return UiUtils.Localize.GetText("general_min_temperature") + ": <style=AltColor>" + WorldDate.GetLocalizedTemperature(item.WarmthModifier.Min) + "</style>";
		}

		public static string GetLocalizedAttackDuration(Equipment item)
		{
			return string.Format("{0}: <style=AltColor>{1}{2}</style>", UiUtils.Localize.GetText("attack_duration"), item.PrimaryAttackSpeed, UiUtils.Localize.GetText("unit_suffix_second"));
		}

		public static string GetLocalizedRange(Equipment item)
		{
			return string.Format("{0}: <style=AltColor>{1}{2}</style>", UiUtils.Localize.GetText("range"), item.PrimaryRange, UiUtils.Localize.GetText("unit_suffix_meter"));
		}

		public static string GetLocalizedBuildingDamage(Equipment item)
		{
			return string.Format("{0}: <style=AltColor>{1}%</style>", UiUtils.Localize.GetText("building_damage"), item.PrimaryBuildingDamage * 100f);
		}

		public static string GetLocalizedArmorDamage(Equipment item)
		{
			return string.Format("{0}: <style=AltColor>{1}%</style>", UiUtils.Localize.GetText("armor_damage"), item.PrimaryArmorDamage * 100f);
		}

		public static string GetLocalizedIgnoresArmor(Equipment item)
		{
			return string.Format("{0}: <style=AltColor>{1}%</style>", UiUtils.Localize.GetText("ignores_armor"), item.PrimaryIgnoresArmor * 100f);
		}

		public static string GetLocalizedPrecisionFallof(Equipment item)
		{
			return string.Format("{0}: <style=AltColor>{1}%/{2}</style>", UiUtils.Localize.GetText("precision_falloff"), item.PrimaryPrecisionFalloff, UiUtils.Localize.GetText("unit_suffix_meter"));
		}

		public static string GetLocalizedPrecision(Equipment item)
		{
			return string.Format("{0}: <style=AltColor>{1}%</style>", UiUtils.Localize.GetText("precision"), item.PrimaryPrecision * 100f);
		}

		public static string GetLocalizedMeleeCover(Equipment item)
		{
			return string.Format("{0}: <style=AltColor>{1}%</style>", UiUtils.Localize.GetText("melee_cover_amount"), item.GetCoverChance(DamageType.Melee) * 100f);
		}

		public static string GetLocalizedRangedCover(Equipment item)
		{
			return string.Format("{0}: <style=AltColor>{1}%</style>", UiUtils.Localize.GetText("ranged_cover_amount"), item.GetCoverChance(DamageType.Ranged) * 100f);
		}

		public static string GetLocalizedEquipEffectors(Equipment item)
		{
			List<string> list = new List<string>();
			if (item.OnEquipEffectors != null && item.OnEquipEffectors.Length != 0)
			{
				string[] onEquipEffectors = item.OnEquipEffectors;
				foreach (string id in onEquipEffectors)
				{
					StatEffector byID = Repository<EffectorRepository, StatEffector>.Instance.GetByID(id);
					if (!(byID == null) && !byID.UIGroup.HasFlag(EffectorUiGroup.None) && byID.LocKeys != null)
					{
						list.Add(UiUtils.Localize.GetText(LocKeyUtils.GetName(byID.LocKeys)));
					}
				}
			}
			if (list.Count != 0)
			{
				return UiUtils.Localize.GetText("effector_on_equip") + ": <style=AltColor>" + UiUtils.Localize.JoinLocalized(list) + "</style>";
			}
			return string.Empty;
		}

		public static string GetLocalizedIsTwoHanded(Equipment item)
		{
			if (item == null || item.EquipmentSlots.Equals(null))
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(46, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\EquipmentUtils.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("The item is null? ");
					messageBuilder.AppendFormatted(item == null);
					messageBuilder.AppendLiteral(" | EquipmentSlots are null? ");
					messageBuilder.AppendFormatted(item != null && item.EquipmentSlots.Equals(null));
				}
				Log.Error(messageBuilder);
				return string.Empty;
			}
			if (item.EquipmentSlots.HasFlag(EquipmentSlotType.RightHand) || item.EquipmentSlots.HasFlag(EquipmentSlotType.LeftHand))
			{
				return string.Concat(str2: (!item.EquipmentSlots.HasFlag(EquipmentSlotType.RightHand) || !item.EquipmentSlots.HasFlag(EquipmentSlotType.LeftHand)) ? UiUtils.GetLocalizedYesNo(isTrue: false) : UiUtils.GetLocalizedYesNo(isTrue: true), str0: UiUtils.Localize.GetText("two_handed"), str1: ": <style=AltColor>", str3: "</style>");
			}
			return string.Empty;
		}

		public static Dictionary<string, List<Equipment>> GetAllItemsByMaterialQuality(Resource resource)
		{
			Dictionary<string, List<Equipment>> dictionary = new Dictionary<string, List<Equipment>>();
			foreach (Resource allItem in Repository<ResourceRepository, Resource>.Instance.GetAllItems())
			{
				if (!(allItem.ProtoId != resource.ProtoId))
				{
					Equipment byID = Repository<EquipmentRepository, Equipment>.Instance.GetByID(allItem.GetID());
					string material = allItem.Material;
					if (!dictionary.ContainsKey(material))
					{
						dictionary.Add(material, new List<Equipment>());
					}
					dictionary[material].Add(byID);
				}
			}
			return dictionary;
		}

		public static IEnumerable<Equipment> GetAllItemsByQuality(Resource resource)
		{
			return (from res in Repository<ResourceRepository, Resource>.Instance.GetAllItems()
				where resource.ProtoId == res.ProtoId
				select Repository<EquipmentRepository, Equipment>.Instance.GetByID(res.GetID())).ToList();
		}

		public static Equipment GetEquipmentFromResource(Resource resource)
		{
			return Repository<EquipmentRepository, Equipment>.Instance.GetByID(resource.GetID());
		}

		public static string GetTooltipTitle(Equipment item)
		{
			return ResourceUtils.GetTextIcon(item.Resource) + "  " + ResourceUtils.GetLocalizedResourceName(item.Resource);
		}

		public static IEnumerable<string> GetTooltipLines(Equipment item, StatInstance durability)
		{
			List<string> list = new List<string>();
			list.Add(GetLocalizedMaterialEntry(item));
			list.AddIfNotNullOrEmpty(GetSkillLevelsLocalized(item));
			if (item.PrimaryDamage > 0f)
			{
				list.Add(string.Format("{0} <style=AltColor>{1:0.00}</style> {2}", AssetUtils.GetSpriteAsset("damage_icon"), item.PrimaryDamage / item.PrimaryAttackSpeed, MonoSingleton<LocalizationController>.Instance.GetText("damage_per_second_ab")));
			}
			if (item.PrimaryRange > 2f)
			{
				list.Add(string.Format("{0} <style=AltColor>{1}</style>% {2}</style>", AssetUtils.GetSpriteAsset("precision_icon"), (int)(item.PrimaryPrecision * 100f), MonoSingleton<LocalizationController>.Instance.GetText("precision")));
				list.Add(string.Format("{0} <style=AltColor>{1}m</style> {2}", AssetUtils.GetSpriteAsset("range_icon"), item.PrimaryRange, MonoSingleton<LocalizationController>.Instance.GetText("range")));
			}
			if (item.ArmorRating > 0f)
			{
				float num = ((durability != null) ? Mathf.Clamp(item.ArmorRating * (durability.Current / durability.Max), 0f, 1f) : item.ArmorRating);
				list.Add(string.Format("{0} <style=AltColor>{1:P2}</style> {2}", AssetUtils.GetSpriteAsset("body_armor_icon"), num, MonoSingleton<LocalizationController>.Instance.GetText("armor_rating")));
			}
			if (item.GetCoverChance(DamageType.Melee) > 0f)
			{
				list.Add(string.Format("{0} <style=AltColor>{1:P2}</style> {2}", AssetUtils.GetSpriteAsset("melee_cover_icon"), item.GetCoverChance(DamageType.Melee), MonoSingleton<LocalizationController>.Instance.GetText("melee_cover_amount")));
			}
			if (item.GetCoverChance(DamageType.Ranged) > 0f)
			{
				list.Add(string.Format("{0} <style=AltColor>{1:P2}</style> {2}", AssetUtils.GetSpriteAsset("ranged_cover_icon"), item.GetCoverChance(DamageType.Ranged), MonoSingleton<LocalizationController>.Instance.GetText("ranged_cover_amount")));
			}
			if (Math.Abs(item.WarmthModifier.Max) > 0.01f)
			{
				list.Add(AssetUtils.GetSpriteAsset("temperature_min_icon") + " " + WorldDate.GetLocalizedTemperatureRelative(item.WarmthModifier.Min) + " " + MonoSingleton<LocalizationController>.Instance.GetText("general_min_temperature"));
				list.Add(AssetUtils.GetSpriteAsset("temperature_max_icon") + " " + WorldDate.GetLocalizedTemperatureRelative(item.WarmthModifier.Max) + " " + MonoSingleton<LocalizationController>.Instance.GetText("general_max_temperature"));
			}
			if (LocKeyUtils.GetTooltipLines(item.Resource.LocKeys, out var lines))
			{
				string[] array = lines;
				foreach (string key in array)
				{
					list.Add(MonoSingleton<LocalizationController>.Instance.GetText(key));
				}
			}
			if (item.AgentFlammability > 0f)
			{
				list.Add(string.Format("{0}: {1:F1}%", MonoSingleton<LocalizationController>.Instance.GetText("equipment_flammability"), item.AgentFlammability * 100f));
				list.Add(string.Format("{0}: {1:F1}%", MonoSingleton<LocalizationController>.Instance.GetText("equipment_fire_damage_multiplier"), item.AgentFireDamageMultiplier * 100f));
			}
			return list;
		}

		public static string GetLocalizedMaterialEntry(Equipment item)
		{
			if (item == null)
			{
				return string.Empty;
			}
			MaterialSettings byID = Repository<MaterialSettingsRepository, MaterialSettings>.Instance.GetByID(item.Resource.Material);
			if (byID == null)
			{
				return string.Empty;
			}
			return UiUtils.Localize.GetText("resource_group_Material") + ": <style=AltColor>" + UiUtils.Localize.GetText(LocKeyUtils.GetName(byID.LocKeys)) + " </style>";
		}

		[MustDisposeResource]
		public static PooledDictionary<Resource, ManageGroupPreset> CalculateWantedResources(HumanoidInstance humanoid, WorldDate dateTime, bool dropInvalidForceUnequip, out EquipmentSlotType slotsToFill)
		{
			PooledDictionary<Resource, ManageGroupPreset> janitor = DictionaryPool<Resource, ManageGroupPreset>.GetJanitor();
			if (humanoid.IsCaptive())
			{
				slotsToFill = humanoid.CaptiveNpcBehaviour.AutoEquipSlots;
				return janitor;
			}
			using PooledList<ManageGroupPreset> presets = ListPool<ManageGroupPreset>.GetJanitor();
			foreach (KeyValuePair<string, string> item in humanoid.WorkerBehaviour.SelectedManagePresets.Dictionary)
			{
				item.Deconstruct(out var key, out var value);
				string groupId = key;
				string presetId = value;
				ManageGroupPreset manageGroupPreset = Repository<ManageGroupPresetRepository, ManageGroupPreset>.Instance.UserPresets.FirstOrDefault((ManageGroupPreset preset) => preset.GetID() == presetId);
				List<string> list = manageGroupPreset?.GetAllowedResources(dateTime);
				bool isEnabled;
				if (manageGroupPreset == null || list == null)
				{
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(73, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\EquipmentUtils.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("ManageGroupPreset not found: groupId = ");
						messageBuilder.AppendFormatted(groupId);
						messageBuilder.AppendLiteral(", presetId = ");
						messageBuilder.AppendFormatted(presetId);
						messageBuilder.AppendLiteral(". Setting to default.");
					}
					Log.Info(messageBuilder);
					manageGroupPreset = Repository<ManageGroupPresetRepository, ManageGroupPreset>.Instance.GetAllItems().FirstOrDefault((ManageGroupPreset preset) => groupId.Equals(preset.GroupId));
					list = manageGroupPreset?.GetAllowedResources(dateTime);
					if (manageGroupPreset == null || list == null)
					{
						messageBuilder = new FVLogInfoInterpolationHandler(45, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\EquipmentUtils.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Failed loading default preset with group id ");
							messageBuilder.AppendFormatted(groupId);
							messageBuilder.AppendLiteral(".");
						}
						Log.Info(messageBuilder);
						slotsToFill = EquipmentSlotType.None;
						return janitor;
					}
				}
				if (groupId.Equals("food_manage_group") || groupId.Equals("stimulants_manage_group"))
				{
					continue;
				}
				presets.Add(manageGroupPreset);
				using PooledHashSet<Resource> pooledHashSet = Repository<ManageGroupRepository, ManageGroup>.Instance.GetByID(groupId).GetResources();
				foreach (Resource item2 in pooledHashSet)
				{
					if (item2 == null || !item2.HasQuality)
					{
						continue;
					}
					if (item2.EquipmentBlueprint == null)
					{
						FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(57, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\EquipmentUtils.cs");
						if (isEnabled)
						{
							messageBuilder2.AppendLiteral("Tried to auto-equip a resource that is not equipment: '");
							messageBuilder2.AppendFormatted(item2.GetID());
							messageBuilder2.AppendLiteral("'!");
						}
						Log.Error(messageBuilder2);
					}
					else if (humanoid.CanEquip(item2.EquipmentBlueprint) && manageGroupPreset.IsResourceValid(item2, dateTime))
					{
						janitor[item2] = manageGroupPreset;
					}
				}
			}
			PooledDictionary<EquipmentInstance, ManageGroupPreset> unwantedItems = FindUnwantedInventoryItems(humanoid, presets, dateTime);
			slotsToFill = CalculateSlotsToFill(humanoid, unwantedItems, janitor);
			RemoveInvalidSlotResources(janitor, slotsToFill);
			if (dropInvalidForceUnequip)
			{
				MonoSingleton<ThreadingJobSystem>.Instance.ExecuteOnMainThreadBlocking(delegate
				{
					DropUnwantedForceUnequipItems(humanoid, unwantedItems);
				});
			}
			unwantedItems.Dispose();
			return janitor;
		}

		public static void DropUnwantedForceUnequipItems(HumanoidInstance humanoid, PooledDictionary<EquipmentInstance, ManageGroupPreset> unwantedItems)
		{
			foreach (var (item, manageGroupPreset2) in unwantedItems)
			{
				if (manageGroupPreset2.ForceUnequipInvalid)
				{
					MonoSingleton<WorkerController>.Instance.DropItem(item, humanoid.Inventory);
				}
			}
		}

		public static void RemoveInvalidSlotResources(PooledDictionary<Resource, ManageGroupPreset> allowedResourcesDict, EquipmentSlotType slotsToFill)
		{
			using PooledList<Resource> pooledList = ListPool<Resource>.GetJanitor();
			foreach (Resource key in allowedResourcesDict.Keys)
			{
				if ((key.EquipmentBlueprint.EquipmentSlots & slotsToFill) == 0)
				{
					pooledList.Add(key);
				}
			}
			foreach (Resource item in pooledList)
			{
				allowedResourcesDict.Remove(item);
			}
		}

		public static EquipmentSlotType CalculateSlotsToFill(HumanoidInstance humanoid, PooledDictionary<EquipmentInstance, ManageGroupPreset> unwantedItems, PooledDictionary<Resource, ManageGroupPreset> allowedResourcesDict)
		{
			EquipmentSlotType equipmentSlotType = EquipmentSlotType.None;
			foreach (EquipmentInstance key in unwantedItems.Keys)
			{
				equipmentSlotType |= key.Blueprint.EquipmentSlots;
			}
			EquipmentSlotType equipmentSlotType2 = ~humanoid.Inventory.OccupiedSlots;
			foreach (Resource key2 in allowedResourcesDict.Keys)
			{
				if (!(key2.EquipmentBlueprint == null))
				{
					EquipmentSlotType equipmentSlotType3 = equipmentSlotType2 & key2.EquipmentBlueprint.EquipmentSlots;
					equipmentSlotType |= equipmentSlotType3;
				}
			}
			return equipmentSlotType;
		}

		[MustDisposeResource]
		public static PooledDictionary<EquipmentInstance, ManageGroupPreset> FindUnwantedInventoryItems(HumanoidInstance humanoid, PooledList<ManageGroupPreset> presets, WorldDate dateTime)
		{
			PooledDictionary<EquipmentInstance, ManageGroupPreset> janitor = DictionaryPool<EquipmentInstance, ManageGroupPreset>.GetJanitor();
			using PooledList<EquipmentInstance> pooledList = humanoid.Inventory.GetEquipments().ToPooledListJanitor();
			foreach (EquipmentInstance item in pooledList)
			{
				if (item.IsManuallyEquiped)
				{
					continue;
				}
				foreach (ManageGroupPreset item2 in presets)
				{
					if (item2.IsResourcePartOfManageGroup(item.Blueprint.Resource) && !item2.IsItemValid(item, dateTime))
					{
						janitor[item] = item2;
						break;
					}
				}
			}
			return janitor;
		}
	}
}
