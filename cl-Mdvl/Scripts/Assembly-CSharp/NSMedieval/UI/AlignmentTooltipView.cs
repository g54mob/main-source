using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.UI.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NSMedieval.UI
{
	public class AlignmentTooltipView : TooltipViewNew
	{
		private List<KeyValuePair<string, int>> threshold;

		private List<string> thresholdLines;

		[NonSerialized]
		private HumanoidInstance humanoidInstance;

		public void SetTooltipData(HumanoidInstance humanoid, float value, StatType alignmentType, bool isLocked = false)
		{
			ClearLines();
			humanoidInstance = humanoid;
			InitThreshold(humanoid, alignmentType);
			AppendLine(MonoSingleton<LocalizationController>.Instance.GetText(GetThresholdByValue(value), humanoid) ?? "", TooltipStyles.TooltipTitle);
			AppendLine(MonoSingleton<LocalizationController>.Instance.GetText(GetThresholdByValue(value) + "_info", humanoid) + "\n\n");
			if (isLocked)
			{
				AppendLine("(" + UiUtils.Localize.GetText("stat_locked") + ")");
			}
			if (humanoid.HumanoidBelief.ReligiousEffectorsLog.Count > 0)
			{
				if (SceneManager.GetActiveScene().name.Equals("HomeScene"))
				{
					AppendLine(MonoSingleton<LocalizationController>.Instance.GetText("religious_align_scale_info") ?? "", TooltipStyles.TooltipSubtitleLineStyle);
					AppendThresholdLines(humanoid, alignmentType);
				}
				else
				{
					AppendLine(MonoSingleton<LocalizationController>.Instance.GetText("most_recent_interactions") ?? "", TooltipStyles.TooltipSubtitleLineStyle);
					AppendEffectorLogs(humanoid);
				}
			}
		}

		private void InitThreshold(HumanoidInstance humanoid, StatType alignmentType)
		{
			if (threshold == null)
			{
				threshold = new List<KeyValuePair<string, int>>();
				StatThresholdTrigger[] thresholdTriggers = humanoid.ActiveBehaviour.GetStatsModel().GetByType(alignmentType).ThresholdTriggers;
				for (int num = thresholdTriggers.Length - 1; num >= 0; num--)
				{
					threshold.Add(new KeyValuePair<string, int>(thresholdTriggers[num].Name, thresholdTriggers[num].Trigger));
				}
			}
		}

		private void AppendEffectorLogs(HumanoidInstance humanoid)
		{
			int num = Mathf.Max(humanoid.HumanoidBelief.ReligiousEffectorsLog.Count - 5, 0);
			for (int num2 = humanoid.HumanoidBelief.ReligiousEffectorsLog.Count - 1; num2 >= num; num2--)
			{
				EffectorLogStruct effectorLogStruct = humanoid.HumanoidBelief.ReligiousEffectorsLog.ElementAt(num2);
				StatEffector byID = Repository<EffectorRepository, StatEffector>.Instance.GetByID(effectorLogStruct.EffectorId);
				if (!(byID == null))
				{
					float effectorValue = effectorLogStruct.EffectorValue;
					string iD = Repository<ReligionRepository, ReligionConfig>.Instance.GetConfigForFaith(humanoidInstance.Stats.GetStat(StatType.ReligiousAlignment).Current).GetID();
					string text = (string.IsNullOrEmpty(effectorLogStruct.CreatureName) ? string.Empty : (" (" + effectorLogStruct.CreatureName + ")"));
					AppendLine(MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(byID.LocKeys)) + ":\n   " + UiUtils.FormatReligiousAlignment(effectorValue, iD) + text);
				}
			}
		}

		private void AppendThresholdLines(HumanoidInstance humanoid, StatType alignmentType)
		{
			if (thresholdLines == null)
			{
				thresholdLines = new List<string>();
				foreach (KeyValuePair<string, int> item in threshold)
				{
					thresholdLines.Add(TooltipStyles.ApplyStyle(MonoSingleton<LocalizationController>.Instance.GetText(item.Key, humanoid) ?? "", TooltipStyles.TooltipDescriptionLine));
				}
			}
			AppendLines(thresholdLines);
		}

		private string GetThresholdByValue(float value)
		{
			for (int i = 0; i < threshold.Count; i++)
			{
				if ((int)(value * 100f) < threshold[i].Value)
				{
					return threshold[i].Key;
				}
			}
			return string.Empty;
		}

		protected override List<string> GetLinesToShow()
		{
			return lines;
		}
	}
}
