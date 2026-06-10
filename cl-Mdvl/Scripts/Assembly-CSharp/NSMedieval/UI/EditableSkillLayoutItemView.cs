using System;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class EditableSkillLayoutItemView : SkillLayoutItemView
	{
		private readonly int skillTitle;

		private readonly int skillIcon = 1;

		private readonly int skillLevelText = 2;

		private readonly int goalPrefsGroup = 3;

		private readonly int editValueGroup = 4;

		[SerializeField]
		private TMP_Text skillBaseModifierText;

		public EditableInputGroupLayoutItemView EditLevelGroup => base.GroupItems[editValueGroup].GetComponent<EditableInputGroupLayoutItemView>();

		public void OnEnable()
		{
			CharacterEditController instance = MonoSingleton<CharacterEditController>.Instance;
			instance.EditModeEnabledAction = (Action<bool>)Delegate.Combine(instance.EditModeEnabledAction, new Action<bool>(OnEditModeEnabled));
		}

		private void OnDisable()
		{
			if (MonoSingleton<CharacterEditController>.IsInstantiated())
			{
				CharacterEditController instance = MonoSingleton<CharacterEditController>.Instance;
				instance.EditModeEnabledAction = (Action<bool>)Delegate.Remove(instance.EditModeEnabledAction, new Action<bool>(OnEditModeEnabled));
			}
		}

		private void OnEditModeEnabled(bool enable)
		{
			base.GroupItems[editValueGroup].SetActive(enable);
			skillBaseModifierText.gameObject.SetActive(enable);
		}

		protected override void RefreshSpecificView()
		{
			EditLevelGroup.InputField.text = MonoSingleton<CharacterEditController>.Instance.GetSkillCreationPoints(base.Humanoid, base.Skill).ToString();
		}

		protected override void RefreshSharedView()
		{
			base.RefreshSharedView();
			SetSkillBaseLevelText();
		}

		protected void SetSkillBaseLevelText()
		{
			if ((bool)skillBaseModifierText)
			{
				int baseSkillPoints = HumanoidUtils.GetBaseSkillPoints(base.Humanoid, base.Skill);
				if (baseSkillPoints == 0)
				{
					skillBaseModifierText.SetText(string.Empty);
					return;
				}
				string styleName = ((baseSkillPoints < 0) ? TooltipStyles.DefaultRed : TooltipStyles.DefaultGreen);
				string arg = ((baseSkillPoints < 0) ? "" : "+");
				string text = $"{arg}{baseSkillPoints:N0}".ToStyled(styleName);
				skillBaseModifierText.SetText("(" + text + ")");
			}
		}

		public override void SetSkillData(HumanoidInstance humanoidInstance, WorkerSkill skill, int index)
		{
			EditLevelGroup.SetData(HumanoidUtils.GetSkillCreationPoints(humanoidInstance, skill).ToString(), ChangeSkill, ModifySkill);
			OnEditModeEnabled(MonoSingleton<CharacterEditController>.Instance.EditModeEnabled);
			base.SetSkillData(humanoidInstance, skill, index);
		}

		private void ModifySkill(int value)
		{
			MonoSingleton<CharacterEditController>.Instance.ModifySkillLevel(base.Skill, value);
		}

		private void ChangeSkill(int value)
		{
			MonoSingleton<CharacterEditController>.Instance.SetSkillLevel(base.Skill, value);
		}
	}
}
