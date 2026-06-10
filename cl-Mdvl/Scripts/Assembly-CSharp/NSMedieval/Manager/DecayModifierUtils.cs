using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.UI.Utils;

namespace NSMedieval.Manager
{
	public static class DecayModifierUtils
	{
		private const string TemperatureDecayId = "temperature_decay";

		private const string TemperatureFermentId = "temperature_ferment";

		private const string WeatherDecayId = "weather_decay";

		private const string GroundDecayId = "ground_decay";

		private const string WaterDecayId = "water_decay";

		public static DecayIconSettings GroundIconSettings => Repository<DecayIconSettingsRepository, DecayIconSettings>.Instance.GetByID("ground_decay");

		public static DecayIconSettings WeatherIconSettings => Repository<DecayIconSettingsRepository, DecayIconSettings>.Instance.GetByID("weather_decay");

		public static DecayIconSettings WaterIconSettings => Repository<DecayIconSettingsRepository, DecayIconSettings>.Instance.GetByID("water_decay");

		public static DecayIconSettings TemperatureIconSettings(DecayModifierData decayModifierData)
		{
			return decayModifierData.AttributeType switch
			{
				AttributeType.DecomposeSpeed => Repository<DecayIconSettingsRepository, DecayIconSettings>.Instance.GetByID("temperature_decay"), 
				AttributeType.RottingSpeed => Repository<DecayIconSettingsRepository, DecayIconSettings>.Instance.GetByID("temperature_decay"), 
				AttributeType.FermentingSpeed => Repository<DecayIconSettingsRepository, DecayIconSettings>.Instance.GetByID("temperature_ferment"), 
				_ => throw new Exception($"Unknown attribute type: {decayModifierData.AttributeType}"), 
			};
		}

		public static string GetTemperatureIconId(DecayModifierData decayModifierData)
		{
			return TemperatureIconSettings(decayModifierData).GetIconId(decayModifierData.TempCoefficient);
		}

		public static string GetGroundIconId(DecayModifierData decayModifierData)
		{
			return GroundIconSettings.GetIconId(decayModifierData.GroundCoefficient);
		}

		public static string GetWeatherIconId(DecayModifierData decayModifierData)
		{
			return WeatherIconSettings.GetIconId(decayModifierData.WeatherCoefficient);
		}

		public static string GetWaterIconId(DecayModifierData decayModifierData)
		{
			return WaterIconSettings.GetIconId(decayModifierData.WaterCoefficient);
		}

		public static List<DecayModifierData> GetDecayModifiers(ResourcePileInstance resourcePileInstance)
		{
			List<DecayModifierData> list = new List<DecayModifierData>();
			if (resourcePileInstance != null)
			{
				StatsInstance stats = resourcePileInstance.Stats;
				if (stats != null)
				{
					ModifierType[] modifierTypes = EnumValues.ModifierTypes;
					foreach (ModifierType type in modifierTypes)
					{
						ModifierInstanceStack modifierInstanceStack = stats.GetModifierInstanceStack(type);
						if (modifierInstanceStack == null)
						{
							continue;
						}
						foreach (ModifierInstance instance in modifierInstanceStack.Instances)
						{
							if (instance is DecayModifier decayModifier)
							{
								DecayModifierData uIData = decayModifier.GetUIData();
								uIData.SetLabel(MonoSingleton<LocalizationController>.Instance.GetText("effect_reason_time_" + decayModifier.AffectedAttributeType.ToString().ToLower()) + ": <style=AltColor>" + GetTimeLet(decayModifier, resourcePileInstance) + "</style>");
								uIData.SetModifiers(resourcePileInstance.Blueprint);
								list.Add(uIData);
							}
						}
					}
					return list;
				}
			}
			return list;
		}

		private static string GetTimeLet(ModifierInstance instance, ResourcePileInstance resourcePileInstance)
		{
			if (instance.AffectedAttributes == null || instance.AffectedAttributes.Count < 1)
			{
				return string.Empty;
			}
			switch (instance.AffectedAttributes[0].Type)
			{
			case AttributeType.RottingSpeed:
			{
				StatInstance stat3 = resourcePileInstance.GetStat(StatType.Freshness);
				if (stat3 != null && stat3.Step != 0f)
				{
					return UiUtils.GetTimeFormatByHours(stat3.Current / stat3.Step);
				}
				return MonoSingleton<LocalizationController>.Instance.GetText("autosave_never");
			}
			case AttributeType.DecomposeSpeed:
			{
				StatInstance stat2 = resourcePileInstance.GetStat(StatType.Health);
				if (stat2 != null && stat2.Step != 0f)
				{
					return UiUtils.GetTimeFormatByHours(stat2.Current / stat2.Step);
				}
				return MonoSingleton<LocalizationController>.Instance.GetText("autosave_never");
			}
			case AttributeType.FermentingSpeed:
			{
				StatInstance stat = resourcePileInstance.GetStat(StatType.Fermentation);
				if (stat != null && stat.Step != 0f)
				{
					return UiUtils.GetTimeFormatByHours(stat.Current / stat.Step);
				}
				return MonoSingleton<LocalizationController>.Instance.GetText("autosave_never");
			}
			default:
				return string.Empty;
			}
		}
	}
}
