using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestProgressBar : MenuButton
{
	public Image iconImage;

	public Image completionCheckmark;

	public TextMeshProUGUI label;

	public ProgressBar progressBar;

	private Requirement requirement;

	private TextFlashAnimation textFlashAnimation;

	public Quest parentQuest;

	public void Initialize()
	{
		AddPointerClickTrigger(OnClicked);
	}

	public void LoadRequirement(Requirement r)
	{
		requirement = r;
		progressBar.SetStale();
	}

	private void OnClicked()
	{
		if (parentQuest != null && parentQuest.IsReadyToClaim())
		{
			GameManager.Instance.ClaimQuestIndividually(parentQuest);
		}
		else
		{
			MenuManager.Instance.TryNavigateToRequirementRecursively(requirement);
		}
	}

	public void UpdateSimulationDisplay()
	{
		if (requirement == null)
		{
			return;
		}
		completionCheckmark.enabled = requirement.IsMet();
		if (requirement is RequiredProductionCount requiredProductionCount)
		{
			double num = requiredProductionCount.CurrentCount();
			if (num < 2147483647.0)
			{
				progressBar.TryUpdateDisplay(Math.Floor(num), requiredProductionCount.targetCount);
			}
			else
			{
				progressBar.TryUpdateDisplay(num, requiredProductionCount.targetCount);
			}
		}
		else if (requirement is RequiredMarketSellCount requiredMarketSellCount)
		{
			progressBar.TryUpdateDisplay(Math.Floor(requiredMarketSellCount.CurrentCount()), requiredMarketSellCount.targetCount);
		}
		else if (requirement is RequiredPopulationCount requiredPopulationCount)
		{
			progressBar.TryUpdateDisplay(requiredPopulationCount.CurrentLevel(), requiredPopulationCount.targetCount);
		}
		else if (requirement is RequiredMinBuildingCount requiredMinBuildingCount)
		{
			progressBar.TryUpdateDisplay(requiredMinBuildingCount.CurrentCount(), requiredMinBuildingCount.numBuildingsRequired);
		}
		else if (requirement is RequiredCoinSpendCount requiredCoinSpendCount)
		{
			progressBar.TryUpdateDisplay(requiredCoinSpendCount.CurrentCount(), requiredCoinSpendCount.targetCount);
		}
		else if (requirement is RequiredMinigameLevel requiredMinigameLevel)
		{
			progressBar.TryUpdateDisplay(requiredMinigameLevel.CurrentCount(), requiredMinigameLevel.requiredLevel);
		}
		else if (requirement is RequiredResearch requiredResearch)
		{
			progressBar.TryUpdateDisplay(requiredResearch.IsMet() ? 1f : 0f, 1.0);
		}
		else if (requirement is RequiredMinResearchCount requiredMinResearchCount)
		{
			progressBar.TryUpdateDisplay(requiredMinResearchCount.CurrentCount(), requiredMinResearchCount.amount);
		}
		else if (requirement is RequiredGenericFlag requiredGenericFlag)
		{
			progressBar.TryUpdateDisplay(requiredGenericFlag.IsMet() ? 1f : 0f, 1.0);
		}
		else if (requirement is RequiredGenericCount requiredGenericCount)
		{
			progressBar.TryUpdateDisplay(requiredGenericCount.CurrentCount(), requiredGenericCount.numRequired);
		}
		else if (requirement is RequiredPopulationCount requiredPopulationCount2)
		{
			progressBar.TryUpdateDisplay(requiredPopulationCount2.CurrentLevel(), requiredPopulationCount2.targetCount);
		}
		else if (requirement is RequiredTownLevel requiredTownLevel)
		{
			float num2 = requiredTownLevel.CurrentCount();
			progressBar.TryUpdateDisplay(Mathf.FloorToInt(num2), requiredTownLevel.requiredTownLevel);
			progressBar.slider.value = num2 / (float)requiredTownLevel.requiredTownLevel;
		}
		else if (requirement is RequiredSkillLevelCount requiredSkillLevelCount)
		{
			progressBar.TryUpdateDisplay(requiredSkillLevelCount.CurrentCount(), requiredSkillLevelCount.targetCount);
		}
		else if (requirement is RequiredSkillXP requiredSkillXP)
		{
			progressBar.TryUpdateDisplay(requiredSkillXP.CurrentCount(), requiredSkillXP.targetCount);
		}
		else if (requirement is RequiredBuildingSkills requiredBuildingSkills)
		{
			progressBar.TryUpdateDisplay(requiredBuildingSkills.CurrentCount(), requiredBuildingSkills.totalLevels);
		}
		else if (requirement is RequiredSkillLevel requiredSkillLevel)
		{
			progressBar.TryUpdateDisplay(requiredSkillLevel.CurrentCount(), requiredSkillLevel.targetLevel);
		}
		else if (requirement is RequiredUpgrade requiredUpgrade)
		{
			progressBar.TryUpdateDisplay(requiredUpgrade.CurrentCount(), requiredUpgrade.targetLevel);
		}
		else if (requirement is RequiredPerk requiredPerk)
		{
			progressBar.TryUpdateDisplay(requiredPerk.CurrentCount(), requiredPerk.targetLevel);
		}
		else if (requirement is RequiredUpgradeCount requiredUpgradeCount)
		{
			progressBar.TryUpdateDisplay(requiredUpgradeCount.CurrentCount(), requiredUpgradeCount.targetCount);
		}
		else if (requirement is RequiredQuest requiredQuest)
		{
			progressBar.TryUpdateDisplay(requiredQuest.IsMet() ? 1 : 0, 1.0);
		}
	}

	public void UpdateDynamicDisplay()
	{
		if (requirement != null)
		{
			textFlashAnimation?.UpdateAnimation();
		}
	}

	public void ReloadLabels()
	{
		label.text = TextDisplay.LabelForRequirement(requirement);
	}

	public void UpdateStaticDisplay()
	{
		ReloadLabels();
		iconImage.sprite = IconManager.SpriteForRequirement(requirement);
	}

	public void FlashIfIncomplete()
	{
		if (!requirement.IsMet())
		{
			if (textFlashAnimation == null)
			{
				textFlashAnimation = new TextFlashAnimation(label);
			}
			textFlashAnimation.Run();
		}
	}

	public override string HighlightText()
	{
		string text = TextDisplay.LabelForRequirement(requirement);
		if (requirement is RequiredTownLevel && LocalizationManager.IsEnglish())
		{
			text += TextDisplay.NewLine;
			text += "Craft and sell items to earn XP and raise town level";
		}
		return text;
	}

	public string DebugRequirement()
	{
		if (requirement != null)
		{
			return requirement.ToString();
		}
		return "No Req";
	}
}
