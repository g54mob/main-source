using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Repository;
using NSMedieval.Enums;
using NSMedieval.Model;
using NSMedieval.StatsSystem;
using NSMedieval.Tools;
using NSMedieval.UI.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class EnemyHealthExtraPanel : SelectionExtraPanelBase
	{
		[SerializeField]
		private FillBarLayoutItemView hitpointsBar;

		[SerializeField]
		private List<StatType> stats;

		[SerializeField]
		private LayoutGroupView statsParent;

		[SerializeField]
		private LayoutGroupView effectorsParent;

		[SerializeField]
		private LayoutGroupView statusParent;

		[SerializeField]
		private LayoutGroupView woundsParent;

		private readonly List<TitleDescriptionLayoutItemView> statusMessages = new List<TitleDescriptionLayoutItemView>();

		private readonly List<FillBarLayoutItemView> workerStats = new List<FillBarLayoutItemView>();

		private readonly List<WoundEntryLayoutItemView> woundEntries = new List<WoundEntryLayoutItemView>();

		private readonly List<EffectorLayoutItemView> healthEffectors = new List<EffectorLayoutItemView>();

		protected override void SetupTabPanel()
		{
			int num = 0;
			foreach (StatType stat2 in stats)
			{
				StatInstance stat = base.Humanoid.Stats.GetStat(stat2);
				string localizedName = StatUtils.GetLocalizedName(stat.Blueprint, base.Humanoid.Info.BodyType);
				if (stat2 == StatType.Health)
				{
					hitpointsBar.SetBasicData(localizedName, stat2.ToString(), string.Empty, string.Empty, StatUtils.GetTooltipLines(stat, base.Humanoid.Info.BodyType), StatUtils.GetStatTrend(stat), StatUtils.GetSliderValues(stat), StatUtils.GetThresholds(stat), null, StatUtils.Invert(stat), string.Empty);
					continue;
				}
				workerStats.GetAt(statsParent, num).SetBasicData(localizedName, stat2.ToString(), string.Empty, string.Empty, StatUtils.GetTooltipLines(stat, base.Humanoid.Info.BodyType), StatUtils.GetStatTrend(stat), StatUtils.GetSliderValues(stat), StatUtils.GetThresholds(stat), null, StatUtils.Invert(stat), string.Empty);
				num++;
			}
			workerStats.SetActiveFromIndex(num, active: false);
			List<WoundData> list = new List<WoundData>();
			int num2 = 0;
			foreach (ActiveEffectorInfo activeEffector in base.Humanoid.Stats.GetActiveEffectors())
			{
				if (activeEffector.WoundInfo == null || activeEffector.WoundInfo.Blueprint == null)
				{
					continue;
				}
				StatEffectorWound obj = (StatEffectorWound)activeEffector.Blueprint;
				float currentSeverity = activeEffector.WoundInfo.CurrentSeverity;
				float timeLeft = WoundUtils.GetTimeLeft(base.Humanoid.Stats, activeEffector.WoundInfo);
				bool flag = WoundUtils.IsTended(activeEffector.WoundInfo);
				num2 = (flag ? num2 : (num2 + 1));
				int num3 = 0;
				List<string> list2 = new List<string>();
				EffectDetailsHolder[] effects = obj.Effects;
				foreach (EffectDetailsHolder effectDetailsHolder in effects)
				{
					if (effectDetailsHolder.Type == EffectorType.AttributeAdderModify && effectDetailsHolder.Parameters.Any((KeyValuePair<string, string> parameter) => parameter.Key == "Attribute" && (parameter.Value == 59.ToString() || parameter.Value == AttributeType.BloodLoss.ToString())) && effectDetailsHolder.Parameters.TryGetValue("Value", out var value))
					{
						int.TryParse(value, out var result);
						num3 += result;
					}
					if (effectDetailsHolder.Type != EffectorType.AttributeModify || !effectDetailsHolder.Parameters.TryGetValue("Attribute", out var value2))
					{
						continue;
					}
					if (!value2.TryParseEnumNameOrInt<AttributeType>(out var parsedEnumValue))
					{
						bool isEnabled;
						FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(33, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Selection\\EnemyHealthExtraPanel.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Failed to parse attribute enum '");
							messageBuilder.AppendFormatted(parsedEnumValue);
							messageBuilder.AppendLiteral("'");
						}
						Log.Error(messageBuilder);
					}
					Attribute byType = Repository<AttributeRepository, Attribute>.Instance.GetByType(parsedEnumValue);
					float result2 = 1f;
					if (effectDetailsHolder.Parameters.TryGetValue("Multiplier", out var value3))
					{
						float.TryParse(value3, NumberStyles.Float, CultureInfo.InvariantCulture, out result2);
					}
					list2.Add("<style=AltColor>" + AttributeUtils.GetLocalizedAttributeName(byType) + "</style>: " + AttributeUtils.GetLocalizedAttributeModifier(byType, result2));
				}
				bool flag2 = !flag && num3 != 0;
				string text = ((activeEffector.StackCount > 0) ? $"x{activeEffector.StackCount + 1}" : string.Empty);
				string item = base.Localize.GetText(LocKeyUtils.GetName(activeEffector.Blueprint.LocKeys)) + " " + text;
				List<string> list3 = new List<string>();
				list3.Add(item);
				list3.Add(base.Localize.GetText("wound_severity") + ": " + GetSeverity(currentSeverity));
				list3.Add((timeLeft >= 1f) ? string.Format("{0}: {1:#.##}h", base.Localize.GetText("expires_in"), timeLeft) : (base.Localize.GetText("expires_in") + ": " + base.Localize.GetText("general_imminent")));
				list3.AddIfNotNullAndTrue(string.Format("{0}: {1}/{2}", base.Localize.GetText("wound_blood_loss_rate"), num3, base.Localize.GetText("unit_suffix_hour")), flag2);
				list3.Add(base.Localize.GetText("general_effects") + ":");
				list3.AddRange(list2);
				list.Add(new WoundData(item, GetSeverity(currentSeverity), flag, flag2, list3));
			}
			int fromIndex = 0;
			if (num2 > 0)
			{
				statusMessages.GetAt(statusParent, fromIndex++).SetBasicData(string.Format("{0} {1}", num2, base.Localize.GetText("wounds_need_tending_title")), base.Localize.GetText("wounds_need_tending_info"));
			}
			statusMessages.SetActiveFromIndex(fromIndex, active: false);
			int fromIndex2 = 0;
			foreach (WoundData item2 in list)
			{
				woundEntries.GetAt(woundsParent, fromIndex2++).SetBasicData(item2.Name, item2.WoundSeverity, item2.Tended, item2.Bleeding, item2.TooltipData);
			}
			woundEntries.SetActiveFromIndex(fromIndex2, active: false);
			List<EffectorViewData> list4 = new List<EffectorViewData>();
			foreach (ActiveEffectorInfo activeEffector2 in base.Humanoid.Stats.Stats.First().Value.Owner.GetActiveEffectors())
			{
				if (!activeEffector2.Blueprint.UIGroup.HasFlag(EffectorUiGroup.Health))
				{
					continue;
				}
				string text2 = activeEffector2.Name;
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				int num4 = 1;
				float minutesLeft = -1f;
				num4 += activeEffector2.StackCount;
				if (activeEffector2.TimeLeft() > 0f)
				{
					minutesLeft = activeEffector2.TimeLeft();
				}
				LocKeys[] locKeys = null;
				if (activeEffector2.Blueprint != null)
				{
					locKeys = activeEffector2.Blueprint.LocKeys;
					EffectDetailsHolder[] effects = activeEffector2.Blueprint.Effects;
					foreach (EffectDetailsHolder effectDetailsHolder2 in effects)
					{
						if ((effectDetailsHolder2.Type == EffectorType.AttributeModify || effectDetailsHolder2.Type == EffectorType.AttributeAdderModify) && effectDetailsHolder2.Parameters.TryGetValue("Attribute", out var value4))
						{
							dictionary[value4] = string.Empty;
							if (effectDetailsHolder2.Parameters.TryGetValue("Multiplier", out var value5))
							{
								dictionary[effectDetailsHolder2.Parameters["Attribute"]] = value5;
							}
							if (effectDetailsHolder2.Parameters.TryGetValue("Value", out var value6))
							{
								dictionary[effectDetailsHolder2.Parameters["Attribute"]] = value6;
							}
						}
					}
				}
				list4.Add(new EffectorViewData(text2, float.NaN, num4, minutesLeft, dictionary, locKeys));
			}
			for (int num5 = 0; num5 < list4.Count; num5++)
			{
				EffectorViewData data = list4[num5];
				healthEffectors.GetAt(effectorsParent, num5).SetStatData(data, base.Humanoid, num5);
			}
			healthEffectors.SetActiveFromIndex(list4.Count, active: false);
			LayoutRebuilder.ForceRebuildLayoutImmediate(woundsParent.GetComponent<RectTransform>());
			LayoutRebuilder.ForceRebuildLayoutImmediate(statusParent.GetComponent<RectTransform>());
			LayoutRebuilder.ForceRebuildLayoutImmediate(effectorsParent.GetComponent<RectTransform>());
		}

		protected override void UpdateTabPanel()
		{
			SetupTabPanel();
		}

		private string GetSeverity(float severity)
		{
			WoundSeverity[] woundSeverities = EnumValues.WoundSeverities;
			for (int num = woundSeverities.Length - 1; num >= 0; num--)
			{
				if (severity > (float)woundSeverities[num])
				{
					return SeverityColor(base.Localize.GetText($"wound_severity_{woundSeverities[num]}"), (float)woundSeverities[num], woundSeverities.Length);
				}
			}
			return string.Empty;
		}

		private string SeverityColor(string inputText, float currentValue, float maxValue)
		{
			string gradientHex = ColorTools.GetGradientHex(currentValue, maxValue, new Color[2]
			{
				Color.white,
				ColorUtils.GetColor("red")
			});
			return "<#" + gradientHex + ">" + inputText + "</color>";
		}
	}
}
