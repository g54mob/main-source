using System.Collections.Generic;
using System.Linq;
using NSMedieval.Enums;
using NSMedieval.StatsSystem;
using NSMedieval.Tools;
using UnityEngine;

namespace NSMedieval.UI.Utils
{
	public static class StatUtils
	{
		public static List<KeyValuePair<string, string>> GetTooltipLines(StatInstance statInstance, BodyType bodyType)
		{
			if (statInstance.Type == StatType.None)
			{
				return null;
			}
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			float num = (Invert(statInstance) ? (statInstance.Max - statInstance.Current) : statInstance.Current);
			string text = (statInstance.IsDisabled ? string.Empty : $"({Mathf.Clamp(num / statInstance.Max, 0f, 1f):P0})");
			string key = GetLocalizedName(statInstance.Blueprint, bodyType) + " " + text;
			list.Add(new KeyValuePair<string, string>(key, TooltipStyles.TooltipTitle));
			if (statInstance.IsDisabled)
			{
				list.Add(new KeyValuePair<string, string>(UiUtils.Localize.GetText("stat_disabled"), TooltipStyles.TooltipAttribute));
				return list;
			}
			if (statInstance.IsLocked)
			{
				list.Add(new KeyValuePair<string, string>(UiUtils.Localize.GetText("stat_locked"), TooltipStyles.TooltipAttribute));
				return list;
			}
			list.Add(new KeyValuePair<string, string>($"{num:F0}/{statInstance.Max:F0}", TooltipStyles.TooltipDefault));
			if (statInstance.Type == StatType.Mood)
			{
				string key2 = string.Format("{0}: {1:P0}", UiUtils.Localize.GetText("atb_name_MoodTarget"), Mathf.Clamp(statInstance.Target / statInstance.Max, 0f, 1f));
				list.Add(new KeyValuePair<string, string>(key2, TooltipStyles.TooltipAttribute));
			}
			if (statInstance.Type.Equals(StatType.Beauty) || statInstance.Type.Equals(StatType.Comfort))
			{
				string key3 = string.Format("{0}: {1:P0}", UiUtils.Localize.GetText("stat_target"), Mathf.Clamp(statInstance.Target / statInstance.Max, 0f, 1f));
				list.Add(new KeyValuePair<string, string>(key3, TooltipStyles.TooltipAttribute));
			}
			list.Add(new KeyValuePair<string, string>(GetLocalizedInfo(statInstance.Blueprint, bodyType), TooltipStyles.TooltipDescriptionLine));
			if (statInstance.Blueprint.ThresholdTriggers != null && statInstance.Blueprint.ThresholdTriggers.Length > 1)
			{
				StatThresholdTrigger[] thresholdTriggers = statInstance.Blueprint.ThresholdTriggers;
				foreach (StatThresholdTrigger statThresholdTrigger in thresholdTriggers)
				{
					if (!statThresholdTrigger.Equals(statInstance.Blueprint.ThresholdTriggers.First()) && statThresholdTrigger.Name != string.Empty && statThresholdTrigger.Name.Length > 2 && statThresholdTrigger.Trigger >= 0)
					{
						string key4 = $"{UiUtils.Localize.GetText(statThresholdTrigger.Name, bodyType)}: {Mathf.Clamp(GetTriggerPercent(statInstance, statThresholdTrigger), 0f, 1f):P1}";
						list.Add(new KeyValuePair<string, string>(key4, TooltipStyles.TooltipAttribute));
					}
				}
			}
			return list;
		}

		public static string GetThreshold(StatInstance statInstance, BodyType bodyType)
		{
			string gradientHex = ColorTools.GetGradientHex(statInstance.Current, statInstance.Max, new Color[3]
			{
				ColorUtils.GetColor("stat_0"),
				ColorUtils.GetColor("stat_50"),
				ColorUtils.GetColor("stat_100")
			});
			string result = "<#" + gradientHex + ">" + UiUtils.Localize.GetText(statInstance.Blueprint.ThresholdTriggers.First().Name, bodyType) + "</color>";
			StatThresholdTrigger[] thresholdTriggers = statInstance.Blueprint.ThresholdTriggers;
			foreach (StatThresholdTrigger statThresholdTrigger in thresholdTriggers)
			{
				float num = (float)statThresholdTrigger.Trigger * statInstance.ThresholdMultiplier;
				if (statInstance.Current <= num && num > 0f && num <= 100f)
				{
					result = "<#" + gradientHex + ">" + UiUtils.Localize.GetText(statThresholdTrigger.Name, bodyType) + "</color>";
				}
			}
			return result;
		}

		public static List<float> GetThresholds(StatInstance statInstance)
		{
			if (statInstance.Blueprint.ThresholdTriggers == null)
			{
				return null;
			}
			List<float> list = new List<float>();
			StatThresholdTrigger[] thresholdTriggers = statInstance.Blueprint.ThresholdTriggers;
			foreach (StatThresholdTrigger statThresholdTrigger in thresholdTriggers)
			{
				if (!statThresholdTrigger.Equals(statInstance.Blueprint.ThresholdTriggers.First()) && statThresholdTrigger.Trigger >= 0)
				{
					list.Add(GetTriggerPercent(statInstance, statThresholdTrigger));
				}
			}
			return list;
		}

		private static float GetTriggerPercent(StatInstance statInstance, StatThresholdTrigger trigger)
		{
			float num = (float)trigger.Trigger * statInstance.ThresholdMultiplier;
			if (num > 0f && num < statInstance.Max)
			{
				num = (Invert(statInstance) ? (statInstance.Max - num) : num);
			}
			return num / statInstance.Max;
		}

		public static bool Invert(StatInstance statInstance)
		{
			return statInstance.Type == StatType.Pain;
		}

		public static StatTrend GetStatTrend(StatInstance statInstance)
		{
			StatTrend statTrend = statInstance.StatTrend;
			if (Invert(statInstance) && statTrend != StatTrend.None)
			{
				statTrend = ((statTrend == StatTrend.Down) ? StatTrend.Up : StatTrend.Down);
			}
			return statTrend;
		}

		public static List<float> GetSliderValues(StatInstance statInstance)
		{
			List<float> list = new List<float>();
			list.Add(0f);
			list.Add(statInstance.Max);
			if (Invert(statInstance))
			{
				list.Add(statInstance.Max - statInstance.Current);
			}
			else
			{
				list.Add(statInstance.Current);
			}
			return list;
		}

		public static string GetLocalizedName(Stat stat, BodyType bodyType = BodyType.None)
		{
			return UiUtils.Localize.GetText(LocKeyUtils.GetName(stat.LocKeys), bodyType);
		}

		public static string GetLocalizedInfo(Stat stat, BodyType bodyType = BodyType.None)
		{
			return UiUtils.Localize.GetText(LocKeyUtils.GetInfo(stat.LocKeys), bodyType);
		}
	}
}
