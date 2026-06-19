using System.Collections.Generic;
using I2.Loc;
using Pug.UnityExtensions;
using UnityEngine;

public class SkillTalentUIElement : UIelement
{
	public bool leftSideActive;

	public bool rightSideActive;

	private bool isFirstTalent;

	public SpriteRenderer icon;

	public PugText pointsText;

	public List<PugText> shadowPointsTexts;

	public SpriteRenderer leftLine;

	public SpriteRenderer rightLine;

	public SpriteRenderer completedLeftLine;

	public SpriteRenderer completedRightLine;

	public SkillTalentUIElement leftSkillTalent;

	public SkillTalentUIElement rightSkillTalent;

	private int talentIndex;

	private SkillID activeSkillTree;

	private SkillTalentsTable.SkillTalentInfo info;

	private int talentPoints;

	public SpriteRenderer hoverSR;

	public LocalizedString nextTalentPointTerm;

	public SpriteRenderer completedBorder;

	private const string talentPrefix = "SkillTalents/";

	private const string conditionPrefix = "Conditions/";

	private const string talentHoverTitleTerm = "textWithAmount";

	private const string maxTalentPoints = "5";

	private bool allowedToPlacePoints
	{
		get
		{
			if (!isFirstTalent && !leftSideActive)
			{
				return rightSideActive;
			}
			return true;
		}
	}

	public void UpdateTalent(SkillID skillTree, int index, SkillTalentsTable.SkillTalentInfo skillTalentInfo, int points)
	{
		Color skillColor = Manager.ui.GetSkillColor(skillTree);
		completedLeftLine.color = skillColor;
		completedRightLine.color = skillColor;
		completedBorder.color = skillColor;
		info = skillTalentInfo;
		activeSkillTree = skillTree;
		talentIndex = index;
		isFirstTalent = talentIndex == 0;
		icon.sprite = skillTalentInfo.icon;
		talentPoints = points;
		int currentPoints = GetCurrentPoints();
		int availableTalentPoints = Manager.saves.GetAvailableTalentPoints(activeSkillTree);
		bool flag = allowedToPlacePoints && (availableTalentPoints > 0 || currentPoints > 0);
		icon.SetAlpha(flag ? 1f : 0.25f);
		if (points >= 5)
		{
			if (leftLine != null)
			{
				leftLine.enabled = false;
			}
			if (rightLine != null)
			{
				rightLine.enabled = false;
			}
			if (completedLeftLine != null)
			{
				completedLeftLine.enabled = true;
			}
			if (completedRightLine != null)
			{
				completedRightLine.enabled = true;
			}
			if (leftSkillTalent != null)
			{
				leftSkillTalent.leftSideActive = true;
			}
			if (rightSkillTalent != null)
			{
				rightSkillTalent.rightSideActive = true;
			}
			completedBorder.enabled = true;
		}
		else
		{
			if (leftLine != null)
			{
				leftLine.enabled = true;
			}
			if (rightLine != null)
			{
				rightLine.enabled = true;
			}
			if (completedLeftLine != null)
			{
				completedLeftLine.enabled = false;
			}
			if (completedRightLine != null)
			{
				completedRightLine.enabled = false;
			}
			if (leftSkillTalent != null)
			{
				leftSkillTalent.leftSideActive = false;
			}
			if (rightSkillTalent != null)
			{
				rightSkillTalent.rightSideActive = false;
			}
			completedBorder.enabled = false;
		}
		if (points > 0)
		{
			pointsText.gameObject.SetActive(value: true);
			foreach (PugText shadowPointsText in shadowPointsTexts)
			{
				shadowPointsText.gameObject.SetActive(value: true);
			}
			string text = points.ToString();
			pointsText.Render(text);
			{
				foreach (PugText shadowPointsText2 in shadowPointsTexts)
				{
					shadowPointsText2.Render(text);
				}
				return;
			}
		}
		pointsText.gameObject.SetActive(value: false);
		foreach (PugText shadowPointsText3 in shadowPointsTexts)
		{
			shadowPointsText3.gameObject.SetActive(value: false);
		}
	}

	public override void OnLeftClicked(bool mod1, bool mod2)
	{
		PlayerController player = Manager.main.player;
		if (allowedToPlacePoints && Manager.saves.GetAvailableTalentPoints(activeSkillTree) > 0 && !(player == null))
		{
			int currentPoints = GetCurrentPoints();
			if (currentPoints < 5)
			{
				currentPoints++;
				Manager.saves.SetSkillTalentPoint(activeSkillTree, talentIndex, currentPoints);
				ConditionData conditionDataForSkillTalent = Manager.mod.SkillTalentsTable.GetConditionDataForSkillTalent(activeSkillTree, talentIndex, currentPoints);
				player.playerCommandSystem.SetSkillTalentCondition(player.entity, conditionDataForSkillTalent);
				AudioManager.SfxUI(SfxID.FIXME_menu_select, 1f, reuse: true, 1f, 0.15f, playOnGamepad: true);
			}
			base.OnLeftClicked(mod1, mod2);
		}
	}

	private int GetCurrentPoints()
	{
		int result = 0;
		List<int> skillTalentTreesPoints = Manager.saves.GetSkillTalentTreesPoints(activeSkillTree);
		if (skillTalentTreesPoints != null && skillTalentTreesPoints.Count > talentIndex)
		{
			result = skillTalentTreesPoints[talentIndex];
		}
		return result;
	}

	public override TextAndFormatFields GetHoverTitle()
	{
		LocalizationManager.GetTranslation("SkillTalents/" + info.name);
		TextAndFormatFields textAndFormatFields = new TextAndFormatFields();
		textAndFormatFields.text = "textWithAmount";
		textAndFormatFields.formatFields = new string[3]
		{
			LocalizationManager.GetTranslation("SkillTalents/" + info.name),
			talentPoints.ToString(),
			"5"
		};
		return textAndFormatFields;
	}

	public override List<TextAndFormatFields> GetHoverStats(bool previewReinforced)
	{
		List<TextAndFormatFields> list = new List<TextAndFormatFields>();
		if (talentPoints > 0)
		{
			int value = talentPoints * info.conditionValuePerPoint;
			ConditionData conditionData = new ConditionData
			{
				conditionID = info.givesCondition,
				value = value
			};
			TextAndFormatFields conditionTextAndFormatFields = ConditionUI.GetConditionTextAndFormatFields(default(ContainedObjectsBuffer), conditionData, previewReinforced: false, isReinforced: false, previewUpgraded: false);
			conditionTextAndFormatFields.color = Color.yellow;
			list.Add(conditionTextAndFormatFields);
		}
		if (talentPoints < 5)
		{
			int value2 = (talentPoints + 1) * info.conditionValuePerPoint;
			list.Add(new TextAndFormatFields
			{
				text = nextTalentPointTerm.mTerm
			});
			ConditionData conditionData2 = new ConditionData
			{
				conditionID = info.givesCondition,
				value = value2
			};
			TextAndFormatFields conditionTextAndFormatFields2 = ConditionUI.GetConditionTextAndFormatFields(default(ContainedObjectsBuffer), conditionData2, previewReinforced: false, isReinforced: false, previewUpgraded: false);
			conditionTextAndFormatFields2.color = Color.yellow;
			list.Add(conditionTextAndFormatFields2);
		}
		return list;
	}

	public override void OnSelected()
	{
		hoverSR.gameObject.SetActive(value: true);
		base.OnSelected();
	}

	public override void OnDeselected(bool playEffect = true)
	{
		hoverSR.gameObject.SetActive(value: false);
		base.OnDeselected(playEffect);
	}
}
