using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Crops;
using NSMedieval.Manager;
using NSMedieval.Model;

namespace NSMedieval.UI.Utils
{
	public static class ZoneUtils
	{
		public static List<KeyValuePair<string, string>> GetYieldResources(string itemId)
		{
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			if (!(Item(itemId) is Cropfield cropfield))
			{
				return list;
			}
			list.AddRange(PlantUtils.GetYieldResources(cropfield.DefaultPlant));
			return list;
		}

		public static List<string> GetInfoLines(string itemId, bool showTemperature)
		{
			List<string> list = new List<string>();
			if (!(Item(itemId) is Cropfield cropfield))
			{
				return list;
			}
			float num = 0f;
			float num2 = 0f;
			float num3 = ((cropfield.DefaultPlant.LifeCyclesCount == 0) ? 1 : cropfield.DefaultPlant.LifeCyclesCount);
			string key = $"general_symbol_{MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.TemperatureUnits}";
			foreach (PlantLifePhases lifePhase in cropfield.DefaultPlant.LifePhases)
			{
				num2 = lifePhase.DurationDays;
				num += lifePhase.DurationDays;
			}
			list.Add(GetLocalizedRequiredBotanicalSkillLevel(cropfield));
			list.Add(string.Format("{0} <color=#ffeca8>~{1} {2}</color>", MonoSingleton<LocalizationController>.Instance.GetText("crop_grow_time"), num, MonoSingleton<LocalizationController>.Instance.GetText("general_days")));
			list.Add(string.Format("{0} <color=#ffeca8>~{1} {2}</color>", MonoSingleton<LocalizationController>.Instance.GetText("max_yield_time"), num - num2, MonoSingleton<LocalizationController>.Instance.GetText("general_days")));
			list.Add(string.Format("{0} <color=#ffeca8>{1}</color>", MonoSingleton<LocalizationController>.Instance.GetText("number_of_harvests"), num3));
			if (!showTemperature)
			{
				return list;
			}
			float newPlantTemperatureLimit = cropfield.DefaultPlant.NewPlantTemperatureLimit;
			list.Add(string.Format("{0} <color=#ffeca8>{1} {2}</color>", MonoSingleton<LocalizationController>.Instance.GetText("crop_min_sow_temperature"), newPlantTemperatureLimit, MonoSingleton<LocalizationController>.Instance.GetText(key)));
			return list;
		}

		public static NSEipix.Base.Model Item(string itemId)
		{
			if (Repository<CropfieldRepository, Cropfield>.Instance.TryGetValue(itemId, out var model))
			{
				if (!(model != null))
				{
					return null;
				}
				return model;
			}
			return null;
		}

		public static string GetLocalizedRequiredBotanicalSkillLevel(Cropfield cropfield)
		{
			string text = MonoSingleton<LocalizationController>.Instance.GetText("needed_skills");
			int minBotanicalSkill = cropfield.DefaultPlant.MinBotanicalSkill;
			string spriteAsset = AssetUtils.GetSpriteAsset("botanical");
			return $"{text}: {spriteAsset} <style=AltColor>{minBotanicalSkill}</style>";
		}

		public static List<KeyValuePair<string, string>> GetFormattedRequiredSeed(string cropfieldID)
		{
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			if (!CropsManager.UseSeeds)
			{
				return list;
			}
			Cropfield byID = Repository<CropfieldRepository, Cropfield>.Instance.GetByID(cropfieldID);
			if (byID == null)
			{
				return list;
			}
			Resource seedBlueprint = byID.SeedBlueprint;
			if (seedBlueprint == null)
			{
				return list;
			}
			int num = 1;
			string value = ((MonoSingleton<ResourcePileTracker>.Instance.GetCount(seedBlueprint).AllowedCount < num) ? $"<style=DefaultRed>{num}</style>" : num.ToString());
			list.Add(new KeyValuePair<string, string>(seedBlueprint.GetID(), value));
			return list;
		}
	}
}
