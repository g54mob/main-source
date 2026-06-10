using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.Enums;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.UI.Utils;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class JobSkillLayoutItemView : LayoutGroupItemView, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		private readonly int background;

		private readonly int goalPrefsGroup = 1;

		[SerializeField]
		private GameObject[] priorityImages;

		private JobPriorities currentPriority;

		private Job job;

		private WorkerSkill jobSkill;

		private SoundButton priorityButton;

		private GoalPreferenceLevel goalPreferenceLevel;

		[NonSerialized]
		private HumanoidInstance humanoid;

		protected GoalPreferenceLayoutItemView GoalPrefsGroup => base.GroupItems[goalPrefsGroup].GetComponent<GoalPreferenceLayoutItemView>();

		public SoundButton PriorityButton
		{
			get
			{
				if (priorityButton == null)
				{
					priorityButton = GetComponent<SoundButton>();
				}
				return priorityButton;
			}
		}

		public bool HasJob(JobType jobType)
		{
			if (job != null)
			{
				return job.JobType == jobType;
			}
			return false;
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (MonoSingleton<UIController>.IsInstantiated())
			{
				MonoSingleton<UIController>.Instance.HoverJobToggle(base.transform.position, enabled: true);
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (MonoSingleton<UIController>.IsInstantiated())
			{
				MonoSingleton<UIController>.Instance.HoverJobToggle(base.transform.position, enabled: false);
			}
		}

		public void SetPriority(int priority)
		{
			currentPriority = (JobPriorities)priority;
			for (int i = 0; i < priorityImages.Length; i++)
			{
				priorityImages[i].SetActive(i == priority);
			}
			UpdateTooltipData();
		}

		public void SetJobSkillData(Job job, HumanoidInstance humanoid)
		{
			this.job = job;
			this.humanoid = humanoid;
			goalPreferenceLevel = GoalPreferenceLevel.Indifferent;
			foreach (KeyValuePair<GoalPreference, GoalPreferenceLevelData> item in humanoid.GoalPreferences.GetGoalPrefDictionary())
			{
				if (item.Key.IsRelatedToJob(job.JobType))
				{
					goalPreferenceLevel = item.Value.PreferenceLevel;
					break;
				}
			}
			GoalPrefsGroup.SetData((int)goalPreferenceLevel);
			base.GroupItems[background].GetComponent<Image>().sprite = AssetUtils.GetSprite("toggle_box_unskilled");
			UpdateTooltipData();
		}

		public void SetJobSkillData(WorkerSkill skill, HumanoidInstance humanoid, Job job)
		{
			this.humanoid = humanoid;
			jobSkill = skill;
			this.job = job;
			goalPreferenceLevel = (GoalPreferenceLevel)skill.GetGoalPreferenceLevel();
			GoalPrefsGroup.SetData(skill.GetGoalPreferenceLevel());
			base.GroupItems[background].GetComponent<Image>().sprite = AssetUtils.GetSprite(BackgroundFrame(skill.Level));
			UpdateTooltipData();
		}

		public void UpdateTooltipData()
		{
			if (base.TooltipNew is JobSkillTooltipView jobSkillTooltipView)
			{
				string skillID = "None";
				int skillLevel = -1;
				FloatRange experienceValues = null;
				if (jobSkill != null)
				{
					skillID = jobSkill.Id.ToString();
					skillLevel = jobSkill.Level;
					experienceValues = GetXPRange(jobSkill);
				}
				jobSkillTooltipView.SetTooltipData(skillID, job, currentPriority, humanoid, skillLevel, experienceValues, goalPreferenceLevel);
				jobSkillTooltipView.RefreshTooltip();
			}
		}

		private FloatRange GetXPRange(WorkerSkill skill)
		{
			if (skill.Level == skill.GetMaxLevel())
			{
				return null;
			}
			return new FloatRange(Mathf.Round(skill.Experience - Repository<SkillLevelsRepository, SkillLevels>.Instance.GetXpRequirement(skill.Id, skill.Level)), Mathf.Round(Repository<SkillLevelsRepository, SkillLevels>.Instance.GetXpRequirement(skill.Id, skill.Level + 1) - Repository<SkillLevelsRepository, SkillLevels>.Instance.GetXpRequirement(skill.Id, skill.Level)));
		}

		private string BackgroundFrame(int skillLevel)
		{
			string empty = string.Empty;
			SkillGrade[] skillGrades = EnumValues.SkillGrades;
			for (int i = 0; i < skillGrades.Length; i++)
			{
				SkillGrade skillGrade = skillGrades[i];
				if ((int)skillGrade >= skillLevel)
				{
					empty = skillGrade.ToString().ToLower();
					return "toggle_box_" + empty;
				}
			}
			return empty;
		}
	}
}
