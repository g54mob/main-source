using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Model;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.UI
{
	public class JobSkillTooltipView : CreatureBaseTooltipView
	{
		private Job job;

		private Color[] priorityGradient;

		private string skillID;

		private JobPriorities priority;

		private FloatRange experienceValues;

		private int skillLevel;

		private GoalPreferenceLevel goalPreferenceLevel;

		public Color[] PriorityGradient
		{
			get
			{
				if (priorityGradient != null)
				{
					return priorityGradient;
				}
				priorityGradient = new Color[3]
				{
					ColorUtils.GetColor("green"),
					ColorUtils.GetColor("yellow"),
					ColorUtils.GetColor("grey")
				};
				return priorityGradient;
			}
		}

		public void SetTooltipData(string skillID, Job job, JobPriorities priority, HumanoidInstance humanoid, int skillLevel, FloatRange experienceValues, GoalPreferenceLevel goalPreferenceLevel)
		{
			this.skillID = skillID;
			this.job = job;
			this.priority = priority;
			this.experienceValues = experienceValues;
			this.skillLevel = skillLevel;
			this.goalPreferenceLevel = goalPreferenceLevel;
			SetTooltipData(skillID, humanoid);
		}

		protected override List<string> GetLinesToShow()
		{
			ClearLines();
			AppendLine(MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(job.LocKeys), base.Humanoid), TooltipStyles.TooltipTitle);
			AppendLine(MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetInfo(job.LocKeys), base.Humanoid), TooltipStyles.TooltipDescriptionLine);
			if (LocKeyUtils.GetTooltipLines(job.LocKeys, out var array))
			{
				string[] array2 = array;
				foreach (string key in array2)
				{
					AppendLine("<style=\"BulletPoint\">" + MonoSingleton<LocalizationController>.Instance.GetText(key) + "</style>");
				}
			}
			if (LocKeyUtils.GetTooltipNotes(job.LocKeys, out var array3))
			{
				string[] array2 = array3;
				foreach (string key2 in array2)
				{
					AppendLine(MonoSingleton<LocalizationController>.Instance.GetText(key2));
				}
			}
			if (skillLevel > -1)
			{
				AppendLine(MonoSingleton<LocalizationController>.Instance.GetText("general_relevant_skills"), TooltipStyles.TooltipSubtitleLineStyle);
				AppendLine(string.Format("{0} {1} ({2})", AssetUtils.GetSpriteAsset(base.KeyId.ToLower()), MonoSingleton<LocalizationController>.Instance.GetText("skill_name_" + skillID, base.Humanoid), skillLevel));
			}
			AppendLine(MonoSingleton<LocalizationController>.Instance.GetText($"job_priority_{priority}", base.Humanoid), MonoSingleton<TooltipStyles>.Instance.GetStyleForPriority(priority));
			GoalPreferenceLevel goalPreferenceLevel = this.goalPreferenceLevel;
			if (goalPreferenceLevel > GoalPreferenceLevel.None && goalPreferenceLevel < GoalPreferenceLevel.Incapable && this.goalPreferenceLevel != GoalPreferenceLevel.Indifferent)
			{
				AppendLine(HumanoidUtils.GetPreferenceLevelName(this.goalPreferenceLevel), TooltipStyles.TooltipAttribute);
				AppendLine(MonoSingleton<LocalizationController>.Instance.GetText($"goal_preference_info_{this.goalPreferenceLevel}"), TooltipStyles.TooltipDescriptionLine);
			}
			return lines;
		}
	}
}
