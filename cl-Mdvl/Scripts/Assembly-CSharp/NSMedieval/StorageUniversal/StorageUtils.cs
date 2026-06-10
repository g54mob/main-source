using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.RoomDetection;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.StorageUniversal
{
	public static class StorageUtils
	{
		public static List<string> GetEquipmentPileModifiers(ResourcePileInstance resourcePileInstance, Equipment item)
		{
			List<string> resourcePileModifiers = GetResourcePileModifiers(resourcePileInstance);
			if (item.RequiredSkills.Count <= 0)
			{
				return resourcePileModifiers;
			}
			string text = MonoSingleton<LocalizationController>.Instance.GetText("skill_needed") + ": ";
			foreach (SkillLevelPair requiredSkill in item.RequiredSkills)
			{
				string text2 = requiredSkill.Key.ToString().ToLower();
				text += string.Format("{0} <color=#ffeca8>{1} {2}</color>   ", AssetUtils.GetSpriteAsset(text2 ?? ""), requiredSkill.Value, MonoSingleton<LocalizationController>.Instance.GetText($"skill_name_{requiredSkill.Key}"));
			}
			resourcePileModifiers.Insert(0, string.Empty);
			resourcePileModifiers.Insert(0, text);
			return resourcePileModifiers;
		}

		public static List<string> GetResourcePileModifiers(ResourcePileInstance resourcePileInstance)
		{
			List<string> list = new List<string>();
			if (resourcePileInstance == null || resourcePileInstance.HasDisposed || resourcePileInstance.Blueprint == null || resourcePileInstance.Stats == null)
			{
				return list;
			}
			if (LocKeyUtils.GetTooltipLines(resourcePileInstance.Blueprint.LocKeys, out var lines))
			{
				string[] array = lines;
				foreach (string key in array)
				{
					list.Add(MonoSingleton<LocalizationController>.Instance.GetText(key));
				}
				list.Add(string.Empty);
			}
			float nutrition = resourcePileInstance.Blueprint.Nutrition;
			if (nutrition > 0f)
			{
				list.Add(string.Format("{0}: <style=AltColor>{1}</style>", MonoSingleton<LocalizationController>.Instance.GetText("menu_nutrition"), nutrition));
			}
			List<DecayModifierData> decayModifiers = DecayModifierUtils.GetDecayModifiers(resourcePileInstance);
			if (decayModifiers != null)
			{
				foreach (DecayModifierData item in decayModifiers)
				{
					list.Add(item.Label);
					list.Add(AssetUtils.GetSpriteAsset(DecayModifierUtils.GetTemperatureIconId(item)) + " " + AssetUtils.GetSpriteAsset(DecayModifierUtils.GetGroundIconId(item)) + " " + AssetUtils.GetSpriteAsset(DecayModifierUtils.GetWeatherIconId(item)) + " " + AssetUtils.GetSpriteAsset(DecayModifierUtils.GetWaterIconId(item)));
				}
			}
			if (resourcePileInstance.IsForbidden)
			{
				list.Add(MonoSingleton<LocalizationController>.Instance.GetText("forbidden_resource_info") ?? "");
			}
			Room room = resourcePileInstance.GetRoom();
			if (room != null)
			{
				string text = ColorUtility.ToHtmlStringRGB(room.RoomType.Color);
				list.Add(MonoSingleton<LocalizationController>.Instance.GetText("inside") + ": <color=#" + text + "><link=\"select_room\"><style=LinkRoom>" + room.GetRoomTypeLocalized() + " (" + room.Impressiveness?.NameLocalized + ")</style></link></color>");
			}
			return list;
		}

		public static bool ShouldRefill(UniversalStorage storage, float refillPercentageThreshold)
		{
			if (refillPercentageThreshold <= 0.1f)
			{
				return true;
			}
			StorageSlot[] storageSlots = storage.StorageSlots;
			foreach (StorageSlot storageSlot in storageSlots)
			{
				int valueOrDefault = (storageSlot.Pile?.GetStoredResource()?.Amount).GetValueOrDefault();
				if (valueOrDefault == 0)
				{
					return true;
				}
				float num = (storageSlot.Pile?.GetStoredResource()?.StackingLimit).GetValueOrDefault();
				if ((float)valueOrDefault / num * 100f < refillPercentageThreshold)
				{
					return true;
				}
			}
			return false;
		}
	}
}
