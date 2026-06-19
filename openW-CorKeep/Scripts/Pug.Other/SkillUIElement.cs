using System.Collections.Generic;
using I2.Loc;
using Unity.Mathematics;
using UnityEngine;

public class SkillUIElement : ButtonUIElement
{
	public SkillIconsTable skillIconsTable;

	public PugText skillLevelText;

	public Sprite backgroundSprite;

	public Sprite goldBackgroundSprite;

	public SpriteRenderer backgroundSR;

	public SpriteRenderer iconSR;

	public SpriteRenderer starSR;

	public Transform barPivot;

	public SkillID skillID;

	private int value;

	public SkillTalentTreeUI talentTreeUI;

	public SpriteRenderer activatedSR;

	public LocalizedString skillInfoText;

	public LocalizedString skillInfoGamepadText;

	private const string textWithAmountTerm = "textWithAmount";

	protected override void LateUpdate()
	{
		base.LateUpdate();
		value = Manager.saves.GetSkillValue(skillID);
		int levelFromSkill = SkillExtensions.GetLevelFromSkill(skillID, value);
		int skillFromLevel = SkillExtensions.GetSkillFromLevel(skillID, levelFromSkill);
		int skillFromLevel2 = SkillExtensions.GetSkillFromLevel(skillID, levelFromSkill + 1);
		int maxSkillLevel = SkillExtensions.GetMaxSkillLevel(skillID);
		bool flag = levelFromSkill >= maxSkillLevel;
		iconSR.sprite = ((!flag) ? skillIconsTable.GetIcon(skillID)?.icon : skillIconsTable.GetIcon(skillID)?.goldIcon);
		backgroundSR.sprite = (flag ? goldBackgroundSprite : backgroundSprite);
		float num = (flag ? 0f : ((float)(value - skillFromLevel) / (float)(skillFromLevel2 - skillFromLevel)));
		num = math.clamp(num, (num > 0f) ? 0.0625f : 0f, (num < 1f) ? 0.9375f : 1f);
		if (flag)
		{
			skillLevelText.gameObject.SetActive(value: false);
			starSR.gameObject.SetActive(value: true);
			iconSR.color = Color.white;
			num = 1f;
		}
		else
		{
			iconSR.color = Manager.ui.GetSkillColor(skillID);
			skillLevelText.gameObject.SetActive(value: true);
			starSR.gameObject.SetActive(value: false);
			string text = levelFromSkill.ToString();
			if (text != skillLevelText.GetText())
			{
				skillLevelText.Render(text);
			}
		}
		skillLevelText.SetTempColor((Manager.saves.GetAvailableTalentPoints(skillID) > 0) ? Color.yellow : Color.white);
		barPivot.localScale = new Vector3(num, 1f, 1f);
		activatedSR.enabled = talentTreeUI.isShowing && talentTreeUI.currentShowingSkillTreeID == skillID;
	}

	public override TextAndFormatFields GetHoverTitle()
	{
		int levelFromSkill = SkillExtensions.GetLevelFromSkill(skillID, value);
		int maxSkillLevel = SkillExtensions.GetMaxSkillLevel(skillID);
		levelFromSkill = math.min(levelFromSkill, maxSkillLevel);
		TextAndFormatFields textAndFormatFields = new TextAndFormatFields();
		textAndFormatFields.text = "textWithAmount";
		textAndFormatFields.formatFields = new string[3]
		{
			LocalizationManager.GetTranslation("Skills/" + skillID),
			levelFromSkill.ToString(),
			maxSkillLevel.ToString()
		};
		return textAndFormatFields;
	}

	public override List<TextAndFormatFields> GetHoverDescription()
	{
		return new List<TextAndFormatFields>
		{
			new TextAndFormatFields
			{
				text = "Skills/" + skillID.ToString() + "Desc"
			},
			new TextAndFormatFields
			{
				text = (Manager.input.SystemPrefersKeyboardAndMouse() ? skillInfoText.mTerm : skillInfoGamepadText.mTerm)
			}
		};
	}

	public override List<TextAndFormatFields> GetHoverStats(bool previewReinforced)
	{
		List<TextAndFormatFields> list = new List<TextAndFormatFields>();
		ConditionData conditionDataForSkill = SkillExtensions.GetConditionDataForSkill(skillID, value);
		TextAndFormatFields conditionTextAndFormatFields = ConditionUI.GetConditionTextAndFormatFields(default(ContainedObjectsBuffer), conditionDataForSkill, previewReinforced: false, isReinforced: false, previewUpgraded: false);
		conditionTextAndFormatFields.color = Color.yellow;
		list.Add(conditionTextAndFormatFields);
		return list;
	}

	public override void OnLeftClicked(bool mod1, bool mod2)
	{
		talentTreeUI.ToggleTalentTree(skillID);
		base.OnLeftClicked(mod1, mod2);
		AudioManager.Sfx(SfxTableID.inventorySFXSkill, Manager.main.player.transform.position);
	}
}
