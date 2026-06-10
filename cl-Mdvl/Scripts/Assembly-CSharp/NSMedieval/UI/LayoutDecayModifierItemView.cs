using System;
using System.Collections.Generic;
using NSEipix.Repository;
using NSMedieval.Manager;
using NSMedieval.Repository;
using NSMedieval.StatsSystem;
using NSMedieval.UI.Utils;

namespace NSMedieval.UI
{
	public class LayoutDecayModifierItemView : LayoutGroupItemView
	{
		private readonly int labelIndex;

		private readonly int iconTemperatureIndex = 1;

		private readonly int iconGroundIndex = 2;

		private readonly int iconWeatherIndex = 3;

		private readonly int iconWaterIndex = 4;

		[NonSerialized]
		private readonly List<string> tooltipLines = new List<string>();

		[NonSerialized]
		private DecayModifierData decayModifierData;

		public void SetIcons(DecayModifierData decayModifierData)
		{
			this.decayModifierData = decayModifierData;
			LayoutGroupItemView component = base.GroupItems[iconTemperatureIndex].GetComponent<LayoutGroupItemView>();
			component.SetImage(DecayModifierUtils.GetTemperatureIconId(decayModifierData));
			SetTemperatureTooltipLines(component.TooltipNew);
			LayoutGroupItemView component2 = base.GroupItems[iconGroundIndex].GetComponent<LayoutGroupItemView>();
			component2.SetImage(DecayModifierUtils.GetGroundIconId(decayModifierData));
			SetGroundTooltipLines(component2.TooltipNew);
			LayoutGroupItemView component3 = base.GroupItems[iconWeatherIndex].GetComponent<LayoutGroupItemView>();
			component3.SetImage(DecayModifierUtils.GetWeatherIconId(decayModifierData));
			SetWeatherTooltipLines(component3.TooltipNew);
			LayoutGroupItemView component4 = base.GroupItems[iconWaterIndex].GetComponent<LayoutGroupItemView>();
			component4.SetImage(DecayModifierUtils.GetWaterIconId(decayModifierData));
			SetWaterTooltipLines(component4.TooltipNew);
		}

		private void SetWeatherTooltipLines(TooltipViewNew tooltipNew)
		{
			tooltipNew.ClearLines();
			float weatherCoefficient = decayModifierData.WeatherCoefficient;
			tooltipNew.AppendLine(string.Format("{0} (x{1:F2})", base.Localize.GetText("decay_speed_per_weather"), weatherCoefficient), TooltipStyles.TooltipTitle);
			tooltipNew.AppendLine(AssetUtils.GetSpriteAsset(DecayModifierUtils.WeatherIconSettings.GetIconId(0f)) + " " + base.Localize.GetText("weather_clear") + " x0");
			foreach (KeyValuePair<string, float> weatherModifier in decayModifierData.GetModifier().WeatherModifiers)
			{
				tooltipNew.AppendLine($"{AssetUtils.GetSpriteAsset(DecayModifierUtils.WeatherIconSettings.GetIconId(weatherModifier.Value))} {GetWeatherKey(weatherModifier.Key)} x{weatherModifier.Value:F2}");
			}
		}

		private string GetWeatherKey(string pairKey)
		{
			return pairKey switch
			{
				"rain" => base.Localize.GetText("weather_rain"), 
				"snow" => base.Localize.GetText("weather_snow"), 
				"game_event_thunderstorm" => base.Localize.GetText("weather_thunderstorm"), 
				"game_event_hailstorm" => base.Localize.GetText("weather_hailstorm"), 
				_ => throw new Exception("Unknown weather key: " + pairKey), 
			};
		}

		private void SetGroundTooltipLines(TooltipViewNew tooltipNew)
		{
			tooltipNew.ClearLines();
			float groundCoefficient = decayModifierData.GroundCoefficient;
			tooltipNew.AppendLine(string.Format("{0} (x{1:F2})", base.Localize.GetText("decay_speed_per_ground"), groundCoefficient), TooltipStyles.TooltipTitle);
			tooltipNew.AppendLine(AssetUtils.GetSpriteAsset(DecayModifierUtils.GroundIconSettings.GetIconId(0f)) + " " + base.Localize.GetText("menu_floor") + " x0");
			tooltipNew.AppendLine(string.Format("{0} {1} x{2:F2}", AssetUtils.GetSpriteAsset(DecayModifierUtils.GroundIconSettings.GetIconId(decayModifierData.GetModifier().GroundCoefficient)), base.Localize.GetText("ground"), decayModifierData.GetModifier().GroundCoefficient));
		}

		private void SetTemperatureTooltipLines(TooltipViewNew tooltipNew)
		{
			tooltipNew.ClearLines();
			tooltipNew.AppendLine(string.Format("{0} (x{1:F2})", base.Localize.GetText("decay_speed_per_temperature"), decayModifierData.TempCoefficient), TooltipStyles.TooltipTitle);
			tooltipNew.AppendLine($"{AssetUtils.GetSpriteAsset(DecayModifierUtils.TemperatureIconSettings(decayModifierData).GetIconId(0f))} (<= {GetTemperatureThreshold(0)}) x{0.0}");
			for (int i = 1; i < decayModifierData.GetModifier().TemperatureCoefficients.Length; i++)
			{
				float num = decayModifierData.GetModifier().TemperatureCoefficients[i];
				tooltipNew.AppendLine($"{AssetUtils.GetSpriteAsset(DecayModifierUtils.TemperatureIconSettings(decayModifierData).GetIconId(num))} (> {GetTemperatureThreshold(i - 1)}) x{num:F2}");
			}
		}

		private void SetWaterTooltipLines(TooltipViewNew tooltipNew)
		{
			tooltipNew.ClearLines();
			float waterCoefficient = decayModifierData.WaterCoefficient;
			tooltipNew.AppendLine(string.Format("{0} (x{1:F2})", base.Localize.GetText("decay_speed_under_water"), waterCoefficient), TooltipStyles.TooltipTitle);
			tooltipNew.AppendLine(AssetUtils.GetSpriteAsset(DecayModifierUtils.WaterIconSettings.GetIconId(0f)) + " " + base.Localize.GetText("general_none") + " x0");
			tooltipNew.AppendLine(string.Format("{0} {1} x{2:F2}", AssetUtils.GetSpriteAsset(DecayModifierUtils.WaterIconSettings.GetIconId(decayModifierData.GetModifier().WaterCoefficient)), base.Localize.GetText("structure_in_water"), decayModifierData.GetModifier().WaterCoefficient));
		}

		private string GetTemperatureThreshold(int index)
		{
			return WorldDate.GetLocalizedTemperature(Repository<ResourceSettingsData, ResourceSettings>.Instance.GetData<ResourceSettings>().TemperatureThresholds[index]);
		}
	}
}
