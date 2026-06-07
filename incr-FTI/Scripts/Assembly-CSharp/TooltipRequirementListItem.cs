using TMPro;
using UnityEngine.UI;

public class TooltipRequirementListItem : MenuButton
{
	public Image iconImage;

	public Image statusImage;

	public TextMeshProUGUI primaryLabel;

	private bool hasInitialized;

	private Requirement displayedRequirement;

	public void DisplayRequirement(Requirement req)
	{
		displayedRequirement = req;
		primaryLabel.text = TextDisplay.LabelForRequirement(req);
		iconImage.sprite = IconManager.SpriteForRequirement(req);
		bool flag = req.IsMet();
		statusImage.sprite = (flag ? IconManager.Instance.checkboxOn : IconManager.Instance.checkboxOff);
		if (req.IsImpossible())
		{
			statusImage.sprite = IconManager.Instance.checkboxImpossible;
		}
		base.buttonState = (flag ? CustomButtonState.Default : CustomButtonState.Invalid);
		if (!hasInitialized)
		{
			AddPointerClickTrigger(OnRequirementPressed);
			hasInitialized = true;
		}
	}

	private void OnRequirementPressed()
	{
		if (displayedRequirement is RequiredResearch requiredResearch)
		{
			MenuManager.Instance.JumpToAndSelectResearch(requiredResearch.researchType);
			MenuManager.Instance.tooltipPanel.LoadEntityDescription(EntityId.FromResearch(requiredResearch.researchType));
		}
		else if (displayedRequirement is RequiredItem requiredItem)
		{
			MenuManager.Instance.tooltipPanel.LoadEntityDescription(EntityId.FromItem(requiredItem.itemType));
		}
		else if (displayedRequirement is RequiredQuest requiredQuest)
		{
			MenuManager.Instance.tooltipPanel.LoadEntityDescription(EntityId.FromQuest(requiredQuest.questType));
		}
		else if (displayedRequirement is RequiredMinBuildingCount requiredMinBuildingCount)
		{
			MenuManager.Instance.tooltipPanel.LoadEntityDescription(EntityId.FromBuilding(requiredMinBuildingCount.buildingType));
		}
		else if (displayedRequirement is RequiredNaturalResource requiredNaturalResource)
		{
			MenuManager.Instance.tooltipPanel.LoadEntityDescription(EntityId.FromNaturalResource(requiredNaturalResource.resourceType));
		}
		else if (displayedRequirement is RequiredTownLevel { requiredBiome: not BiomeType.None })
		{
			if (!MenuManager.Instance.worldPanel.isLocked)
			{
				MenuManager.Instance.worldPanel.ManuallyOpen();
			}
			else
			{
				MenuManager.Instance.questsPanelPopup.QueueJumpToQuest(Quest.UnlockWorldPanel);
			}
		}
		else if (displayedRequirement != null)
		{
			MenuManager.Instance.TryNavigateToRequirementRecursively(displayedRequirement);
		}
	}
}
