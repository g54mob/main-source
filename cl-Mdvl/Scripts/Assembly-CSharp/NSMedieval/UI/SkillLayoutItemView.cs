using System;
using System.Globalization;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Tools;
using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class SkillLayoutItemView : LayoutGroupItemView
	{
		private int skillTitle;

		private int skillIcon = 1;

		private int skillLevelText = 2;

		private int goalPrefsGroup = 3;

		private int skillLevelSlider = 4;

		private int enabledSkill = 5;

		private int blockedSkill = 6;

		private readonly int increaseButton = 7;

		private readonly int decreaseButton = 8;

		private bool levelObscured;

		[SerializeField]
		private Color[] levelColors;

		private SkillTooltipView skillTooltipView;

		[NonSerialized]
		private HumanoidInstance humanoid;

		protected GoalPreferenceLayoutItemView GoalPrefsGroup => base.GroupItems[goalPrefsGroup].GetComponent<GoalPreferenceLayoutItemView>();

		protected int SkillTitle => skillTitle;

		protected int SkillLevelText => skillLevelText;

		protected int SkillLevelSlider => skillLevelSlider;

		private SoundButton IncreaseButton => base.GroupItems[increaseButton].GetComponent<SoundButton>();

		private SoundButton DecreaseButton => base.GroupItems[decreaseButton].GetComponent<SoundButton>();

		public WorkerSkill Skill { get; protected set; }

		private SkillTooltipView SkillTooltipView
		{
			get
			{
				if (skillTooltipView == null)
				{
					skillTooltipView = base.TooltipNew as SkillTooltipView;
				}
				return skillTooltipView;
			}
		}

		protected HumanoidInstance Humanoid => humanoid;

		protected override void OnDestroy()
		{
			base.OnDestroy();
			humanoid = null;
		}

		public void SetSkillData(HumanoidInstance humanoidInstance, WorkerSkill skill, int index, bool obscured)
		{
			levelObscured = obscured;
			OnDevToolsActive(MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.DevTools);
			SetSkillData(humanoidInstance, skill, index);
		}

		public virtual void SetSkillData(HumanoidInstance humanoidInstance, WorkerSkill skill, int index)
		{
			SetBackground(index);
			SetSkillData(humanoidInstance, skill);
		}

		public virtual void SetSkillData(HumanoidInstance humanoidInstance, WorkerSkill skill)
		{
			humanoid = humanoidInstance;
			Skill = skill;
			RefreshSharedView();
			RefreshSpecificView();
		}

		protected virtual void RefreshSharedView()
		{
			SetTitle();
			SetSkillIcon();
			SetSkillLevelText(Skill.Level);
			SetTooltip();
			GoalPrefsGroup.SetData(Skill.GetGoalPreferenceLevel());
		}

		protected virtual void RefreshSpecificView()
		{
			bool flag = Humanoid.SkillIsBlocked(Skill.Id);
			SetEnabled(flag);
			SetSlider();
		}

		private void SetEnabled(bool blocked)
		{
			if (base.GroupItems.Count > enabledSkill && base.GroupItems[enabledSkill] != null)
			{
				base.GroupItems[enabledSkill].gameObject.SetActive(!blocked);
			}
			if (base.GroupItems.Count > blockedSkill && base.GroupItems[blockedSkill] != null)
			{
				base.GroupItems[blockedSkill].gameObject.SetActive(blocked);
			}
		}

		protected void SetSlider()
		{
			if (base.GroupItems.Count <= skillLevelSlider || base.GroupItems[skillLevelSlider] == null)
			{
				return;
			}
			base.GroupItems[skillLevelSlider].GetComponentInChildren<TMP_Text>().text = GetXpRange(Skill);
			Slider component = base.GroupItems[skillLevelSlider].GetComponent<Slider>();
			if (component != null)
			{
				if (Skill.Level >= Skill.GetMaxLevel())
				{
					component.value = 1f;
				}
				else
				{
					component.value = XPRange(Skill).Min / XPRange(Skill).Max;
				}
			}
		}

		protected string GetXpRange(WorkerSkill skill)
		{
			FloatRange floatRange = XPRange(skill);
			if (floatRange != null)
			{
				return string.Format("{0} ({1}/{2} {3})", skill.Level, floatRange.Min, floatRange.Max, base.Localize.GetText("general_xp"));
			}
			return MonoSingleton<LocalizationController>.Instance.GetText("general_maxLevel");
		}

		private void Start()
		{
			if (base.GroupItems.Count > increaseButton)
			{
				IncreaseButton.transform.parent.gameObject.SetActive(value: false);
				DecreaseButton.transform.parent.gameObject.SetActive(value: false);
			}
		}

		private void SetTooltip()
		{
			if (!(SkillTooltipView == null))
			{
				string experienceValues = MonoSingleton<LocalizationController>.Instance.GetText("skill_level") + ": " + GetXpRange(Skill);
				SkillTooltipView.SetData(Skill.Id, experienceValues, Skill.GetGoalPreferenceLevel(), Humanoid);
			}
		}

		protected void SetTitle()
		{
			SetText(skillTitle, MonoSingleton<LocalizationController>.Instance.GetText(Skill.GetSkillTextKey()));
		}

		protected void SetSkillLevelText(int level)
		{
			if (levelObscured)
			{
				base.GroupItems[skillLevelText].GetComponent<TMP_Text>().SetText("??");
			}
			base.GroupItems[skillLevelText].GetComponent<TMP_Text>().SetText("<#" + ColorTools.GetGradientHex(level, 30f, levelColors) + ">" + level + "</color>");
		}

		private void SetSkillIcon()
		{
			if (base.GroupItems[skillIcon] != null)
			{
				base.GroupItems[skillIcon].GetComponent<TMP_Text>().SetText(AssetUtils.GetSpriteAsset(Skill.Id.ToString().ToLower(CultureInfo.InvariantCulture) ?? ""));
			}
		}

		private FloatRange XPRange(WorkerSkill skill)
		{
			if (skill.Level == skill.GetMaxLevel())
			{
				return null;
			}
			return new FloatRange(Mathf.Round(skill.Experience - Repository<SkillLevelsRepository, SkillLevels>.Instance.GetXpRequirement(skill.Id, skill.Level)), Mathf.Round(Repository<SkillLevelsRepository, SkillLevels>.Instance.GetXpRequirement(skill.Id, skill.Level + 1) - Repository<SkillLevelsRepository, SkillLevels>.Instance.GetXpRequirement(skill.Id, skill.Level)));
		}

		private void OnDevToolsActive(bool active)
		{
			if (base.GroupItems.Count >= increaseButton)
			{
				base.GroupItems[increaseButton].transform.parent.gameObject.SetActive(value: false);
				base.GroupItems[decreaseButton].transform.parent.gameObject.SetActive(value: false);
			}
		}

		private void OnClickModifyValue(int sign)
		{
		}
	}
}
