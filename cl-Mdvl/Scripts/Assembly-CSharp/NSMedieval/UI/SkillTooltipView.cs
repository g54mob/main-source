using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.StatsSystem;
using NSMedieval.UI.Utils;

namespace NSMedieval.UI
{
	public class SkillTooltipView : TooltipViewNew
	{
		[NonSerialized]
		private string experienceValues = string.Empty;

		[NonSerialized]
		private GoalPreferenceLevel goalPreferenceLevel;

		private SkillType skillType;

		private string skillId;

		[NonSerialized]
		private HumanoidInstance humanoid;

		protected override void OnDestroy()
		{
			base.OnDestroy();
			humanoid = null;
		}

		public void SetData(SkillType skillType, string experienceValues, int goalPreferenceLevel, HumanoidInstance humanoidInstance)
		{
			this.skillType = skillType;
			skillId = skillType.ToString();
			this.experienceValues = experienceValues;
			this.goalPreferenceLevel = (GoalPreferenceLevel)goalPreferenceLevel;
			humanoid = humanoidInstance;
		}

		protected override List<string> GetLinesToShow()
		{
			ClearLines();
			AppendLine(AssetUtils.GetSpriteAsset(skillId.ToLower()) + "  " + MonoSingleton<LocalizationController>.Instance.GetText("skill_name_" + skillId), TooltipStyles.TooltipTitle);
			AppendLine(MonoSingleton<LocalizationController>.Instance.GetText("skill_info_" + skillId), TooltipStyles.TooltipDescriptionLine);
			if (!string.IsNullOrEmpty(experienceValues))
			{
				AppendLine(experienceValues, TooltipStyles.TooltipAttribute);
			}
			GoalPreferenceLevel goalPreferenceLevel = this.goalPreferenceLevel;
			if (goalPreferenceLevel > GoalPreferenceLevel.None && goalPreferenceLevel < GoalPreferenceLevel.Incapable && this.goalPreferenceLevel != GoalPreferenceLevel.Indifferent)
			{
				AppendLine(HumanoidUtils.GetPreferenceLevelName(this.goalPreferenceLevel), TooltipStyles.TooltipAttribute);
				AppendLine(MonoSingleton<LocalizationController>.Instance.GetText($"goal_preference_info_{this.goalPreferenceLevel}", humanoid), TooltipStyles.TooltipDescriptionLine);
			}
			List<string> baseSkillModifiers = HumanoidUtils.GetBaseSkillModifiers(humanoid, skillId);
			if (baseSkillModifiers.Count > 0)
			{
				AppendLine(MonoSingleton<LocalizationController>.Instance.GetText("character_min_skill") + ": ", TooltipStyles.TooltipAttribute);
				foreach (string item in baseSkillModifiers)
				{
					AppendLine(" - " + item);
				}
			}
			if (humanoid.IsXpCapReached(skillType))
			{
				float xpCapValue = humanoid.GetXpCapValue(skillType);
				float xpAddedToday = humanoid.GetXpAddedToday(skillType);
				string text = MonoSingleton<LocalizationController>.Instance.GetText("xp_cap_reached");
				AppendLine(text.Replace("<daily_xp>", $"{xpAddedToday}/{xpCapValue}"));
			}
			return lines;
		}
	}
}
