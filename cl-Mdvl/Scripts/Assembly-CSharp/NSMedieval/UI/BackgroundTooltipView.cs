using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Model;
using NSMedieval.UI.Utils;

namespace NSMedieval.UI
{
	public class BackgroundTooltipView : CreatureBaseTooltipView
	{
		protected override List<string> GetLinesToShow()
		{
			ClearLines();
			if (base.Humanoid?.Info == null || base.Humanoid.HasDisposed)
			{
				return lines;
			}
			SetTooltipLines();
			return lines;
		}

		private void SetTooltipLines()
		{
			AppendLine(HumanoidUtils.GetBackgroundNameMerged(base.Humanoid), TooltipStyles.TooltipTitle);
			AppendLine(MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetInfo(base.Humanoid.Info.Background.LocKeys), base.Humanoid), TooltipStyles.TooltipDescriptionLine);
			string text = MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetInfo(base.Humanoid.Info.BackStory.LocKeys), base.Humanoid);
			string text2 = " ";
			if (text[0] == ',' || MonoSingleton<LocalizationController>.Instance.GetCurrentLanguageEnum() == Language.Chinese || MonoSingleton<LocalizationController>.Instance.GetCurrentLanguageEnum() == Language.Japanese)
			{
				text2 = string.Empty;
			}
			AppendLine(MonoSingleton<LocalizationController>.Instance.GetText($"background_context_link_0{base.Humanoid.Info.BackgroundContextLink}", base.Humanoid) + text2 + text, TooltipStyles.TooltipDescriptionLine);
			foreach (SkillValuePair skillModifier in GetSkillModifiers())
			{
				AppendLine(TooltipStyles.ApplyStyle(HumanoidUtils.SkillNameAndValue(skillModifier), TooltipStyles.TooltipAttribute));
			}
			if (!GetJobPreferencesCombined(out var goalPreferences))
			{
				return;
			}
			AppendLine("\n");
			AppendLine(TooltipStyles.ApplyStyle(UiUtils.Localize.GetText("job_preferences"), TooltipStyles.TooltipSubtitleLineStyle));
			foreach (StringIntPair item in goalPreferences)
			{
				if (item.Value != 0 && item.Value != 3)
				{
					AppendLine(TooltipStyles.ApplyStyle(HumanoidUtils.JobTypeAndPreference(item), TooltipStyles.TooltipAttribute));
				}
			}
		}

		private bool GetJobPreferencesCombined(out List<StringIntPair> goalPreferences)
		{
			goalPreferences = new List<StringIntPair>(base.Humanoid.Info.Background.GoalPreferences);
			goalPreferences.AddRange(base.Humanoid.Info.BackStory.GoalPreferences);
			return goalPreferences.Count > 0;
		}

		private IEnumerable<SkillValuePair> GetSkillModifiers()
		{
			List<SkillValuePair> list = new List<SkillValuePair>(base.Humanoid.Info.Background.SkillModifiers);
			foreach (SkillValuePair skillModifier in base.Humanoid.Info.BackStory.SkillModifiers)
			{
				SkillValuePair skillValuePair = list.FirstOrDefault((SkillValuePair skill) => skill.GetID().Equals(skillModifier.GetID()));
				if (skillValuePair == null)
				{
					list.Add(skillModifier);
				}
				else
				{
					list[list.IndexOf(skillValuePair)] = new SkillValuePair(skillValuePair.Key, skillValuePair.Value + skillModifier.Value);
				}
			}
			return list;
		}
	}
}
