using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PerkListItem : CommonListItem
{
	public PerkState perkState;

	public TextMeshProUGUI primaryLabel;

	public TextMeshProUGUI countLabel;

	public TextMeshProUGUI lockedLabel;

	public Image iconImage;

	public MenuButton addButton;

	public MenuButton removeButton;

	public MenuButton lockedButton;

	public CostGrid costGrid;

	public Slider progressSlider;

	private TextColorChangeAnimation levelUpAnimation;

	public override void Initialize()
	{
		base.Initialize();
		levelUpAnimation = new TextColorChangeAnimation();
		addButton.highlightTextDelegate = AddButtonTooltip;
		removeButton.highlightTextDelegate = RemoveButtonTooltip;
		addButton.AddPointerDownTrigger(OnAddPerkPressed);
		addButton.AddRightClickTrigger(OnAddPerkRightClicked);
		removeButton.AddPointerDownTrigger(OnRemovePerkPressed);
		removeButton.AddRightClickTrigger(OnRemovePerkRightClicked);
		costGrid.useWideIcon = true;
		lockedButton.buttonState = CustomButtonState.None;
		lockedButton.highlightTextDelegate = LockHighlightText;
	}

	private string LockHighlightText()
	{
		foreach (Requirement requirement in perkState.unlockRequirements.requirements)
		{
			if (!requirement.IsMet())
			{
				if (LocalizationManager.IsEnglish())
				{
					return TextDisplay.FormattedKeyValue("Requires", TextDisplay.LabelForRequirement(requirement));
				}
				return TextDisplay.FormattedKeyValue("Requirements", TextDisplay.LabelForRequirement(requirement));
			}
		}
		return null;
	}

	private string AddButtonTooltip()
	{
		if (perkState.availability == BuildObjectAvailability.Locked)
		{
			foreach (Requirement requirement in perkState.unlockRequirements.requirements)
			{
				if (!requirement.IsMet())
				{
					if (LocalizationManager.IsEnglish())
					{
						return TextDisplay.FormattedKeyValue("Requires", TextDisplay.LabelForRequirement(requirement));
					}
					return TextDisplay.FormattedKeyValue("Requirements", TextDisplay.LabelForRequirement(requirement));
				}
			}
		}
		return null;
	}

	private string RemoveButtonTooltip()
	{
		return null;
	}

	public override void UpdateDynamicDisplay()
	{
		base.UpdateDynamicDisplay();
		UpdateButtonAvailability();
		costGrid.UpdateSinglePurchaseAffordability();
	}

	public void LoadState(PerkState s)
	{
		perkState = s;
		iconImage.sprite = IconManager.SpriteForPerk(s.type);
		selectionHandle = s.AsEntity();
		lockedButton.tooltipEntity = EntityId.FromPerk(s.type);
		ReloadLabelParent();
		removeButton.gameObject.SetActive(!CommonListItem.gm.arePerksPermanent);
	}

	public override void ReloadLabelParent()
	{
		primaryLabel.text = TextDisplay.LabelForPerk(perkState.type);
		lockedLabel.text = "Locked".Localized();
	}

	public void OnAddPerkPressed()
	{
		if (perkState.addInvalidReason == InvalidReason.None)
		{
			perkState.Increment();
			ProcessPerkCountChanged();
			return;
		}
		if (perkState.addInvalidReason == InvalidReason.LockedByRequirements)
		{
			foreach (Requirement requirement in perkState.unlockRequirements.requirements)
			{
				if (LocalizationManager.IsEnglish())
				{
					MenuManager.Instance.ShowMessage(TextDisplay.FormattedKeyValue("Requires", TextDisplay.LabelForRequirement(requirement)));
				}
				MenuManager.Instance.ShowMessage(TextDisplay.FormattedKeyValue("Requirements", TextDisplay.LabelForRequirement(requirement)));
			}
			return;
		}
		if (perkState.addInvalidReason == InvalidReason.CanNotAfford)
		{
			if (perkState.perk.isGlobal)
			{
				MenuManager.Instance.worldPerksPanel.AnimatePanelHeader();
				MenuManager.Instance.ShowMessage(InvalidReason.NotEnoughQuestCoins);
			}
			else
			{
				MenuManager.Instance.townPerksPanel.AnimatePanelHeader();
				MenuManager.Instance.ShowMessage(InvalidReason.NotEnoughPerkPoints);
			}
		}
		else
		{
			MenuManager.Instance.ShowMessage(perkState.addInvalidReason);
		}
	}

	public void TriggerLabelRefresh()
	{
		if (perkState.perk.isGlobal)
		{
			MenuManager.Instance.worldPerksPanel.ReloadLabels();
		}
		else
		{
			MenuManager.Instance.townPerksPanel.ReloadLabels();
		}
	}

	public void OnAddPerkRightClicked()
	{
		bool flag = false;
		while (perkState.addInvalidReason == InvalidReason.None && perkState.currentCount < perkState.maxCount)
		{
			perkState.Increment();
			flag = true;
		}
		if (flag)
		{
			ProcessPerkCountChanged();
		}
	}

	public void OnRemovePerkRightClicked()
	{
		bool flag = false;
		while (perkState.removeInvalidReason == InvalidReason.None && perkState.currentCount > 0.0)
		{
			perkState.Decrement();
			flag = true;
		}
		if (flag)
		{
			ProcessPerkCountChanged();
		}
	}

	private void ProcessPerkCountChanged()
	{
		perkState.CalcAvailability();
		if (perkState.parentTown != null)
		{
			perkState.parentTown.SetStaleFlagsForModifiedTownPerk(perkState.type);
			perkState.parentTown.CalcUnassignedPerkPoints();
			CommonListItem.gm.CalcUnassignedQuestCoins();
		}
		else
		{
			CommonListItem.gm.SetStaleFlagsForModifiedGlobalPerk(perkState.type);
			CommonListItem.gm.CalcUnassignedQuestCoins();
		}
		CommonListItem.gm.ProcessMetadataQueue();
		levelUpAnimation.Run(countLabel);
		UpdateCountsAndCost();
		TriggerLabelRefresh();
	}

	public void OnRemovePerkPressed()
	{
		if (perkState.removeInvalidReason == InvalidReason.None)
		{
			perkState.Decrement();
			ProcessPerkCountChanged();
			return;
		}
		if (perkState.removeInvalidReason == InvalidReason.LockedByRequirements)
		{
			foreach (Requirement requirement in perkState.unlockRequirements.requirements)
			{
				if (LocalizationManager.IsEnglish())
				{
					MenuManager.Instance.ShowMessage(TextDisplay.FormattedKeyValue("Requires", TextDisplay.LabelForRequirement(requirement)));
				}
				MenuManager.Instance.ShowMessage(TextDisplay.FormattedKeyValue("Requirements", TextDisplay.LabelForRequirement(requirement)));
			}
			return;
		}
		MenuManager.Instance.ShowMessage(perkState.removeInvalidReason);
	}

	public void UpdateCountsAndCost()
	{
		UpdateCount();
		LoadCost();
	}

	public void UpdateCount()
	{
		int num = 0;
		if (perkState != null)
		{
			num = GameUtility.RoundToInt(perkState.currentCount);
			if (perkState.maxCount > 0.0)
			{
				string text = string.Format(TextDisplay.LevelFormatShort, TextDisplay.LocalizedNumber(num));
				countLabel.text = text + " / " + TextDisplay.LocalizedNumber(perkState.maxCount);
				progressSlider.gameObject.SetActive(value: true);
				progressSlider.value = GameUtility.AsFloat(perkState.currentCount / perkState.maxCount);
			}
			else
			{
				progressSlider.gameObject.SetActive(value: false);
				TextDisplay.FormatLevelAbbreviation(countLabel, num);
			}
		}
		UpdateButtonAvailability();
		costGrid.UpdateSinglePurchaseAffordability();
		ReloadLabelParent();
	}

	public override void OnStateAssignmentChanged()
	{
		base.OnStateAssignmentChanged();
		addButton.AnimateInstant();
		removeButton.AnimateInstant();
		UpdateCount();
	}

	public void UpdateButtonAvailability()
	{
		if (perkState.availability == BuildObjectAvailability.Completed)
		{
			addButton.gameObject.SetActive(value: false);
			costGrid.gameObject.SetActive(value: false);
			countLabel.color = Color.gray;
			lockedButton.gameObject.SetActive(value: false);
		}
		else if (GameManager.freeMode)
		{
			addButton.gameObject.SetActive(value: true);
			addButton.invalidReason = InvalidReason.None;
			addButton.buttonState = CustomButtonState.Default;
			addButton.gameObject.SetActive(value: true);
			costGrid.gameObject.SetActive(value: true);
			countLabel.color = Color.white;
			lockedButton.gameObject.SetActive(value: false);
		}
		else if (perkState.availability == BuildObjectAvailability.Locked)
		{
			addButton.gameObject.SetActive(value: true);
			addButton.buttonState = CustomButtonState.Disabled;
			addButton.invalidReason = InvalidReason.None;
			costGrid.gameObject.SetActive(value: false);
			countLabel.color = Color.white;
			lockedButton.gameObject.SetActive(value: true);
		}
		else if (perkState.CanAffordPerk())
		{
			addButton.gameObject.SetActive(value: true);
			addButton.invalidReason = InvalidReason.None;
			addButton.buttonState = CustomButtonState.Default;
			addButton.gameObject.SetActive(value: true);
			costGrid.gameObject.SetActive(value: true);
			countLabel.color = Color.white;
			lockedButton.gameObject.SetActive(value: false);
		}
		else
		{
			addButton.gameObject.SetActive(value: true);
			addButton.invalidReason = InvalidReason.NotEnoughQuestCoins;
			addButton.buttonState = CustomButtonState.Disabled;
			addButton.gameObject.SetActive(value: true);
			costGrid.gameObject.SetActive(value: true);
			countLabel.color = Color.white;
			lockedButton.gameObject.SetActive(value: false);
		}
		if (perkState.removeInvalidReason == InvalidReason.None)
		{
			removeButton.buttonState = CustomButtonState.Default;
		}
		else
		{
			removeButton.buttonState = CustomButtonState.Disabled;
		}
	}

	public override void LoadCost()
	{
		base.LoadCost();
		costGrid.Clear();
		costGrid.AddStaticCost(perkState.cachedPointState, perkState.pointCost);
		costGrid.PerformLayout();
	}

	public override void OnPointerEnter(PointerEventData eventData)
	{
		base.OnPointerEnter(eventData);
		if (perkState.perk.isGlobal)
		{
			MenuManager.Instance.worldPerksPanel.OnHighlighted(this);
		}
		else
		{
			MenuManager.Instance.townPerksPanel.OnHighlighted(this);
		}
	}
}
