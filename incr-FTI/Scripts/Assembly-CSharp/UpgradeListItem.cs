using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradeListItem : MenuButton, IPooledListItem
{
	public TextMeshProUGUI label;

	public Image iconImage;

	public LabelButton purchaseUpgradeButton;

	public CostGrid costGrid;

	public readonly Cost cost = new Cost();

	public Upgrade upgrade;

	public MenuButton titleButton;

	public QuestProgressBar questProgressBar;

	public UpgradesPanel parentPanel;

	private BuildObjectAvailability lastDisplayedAvailability;

	private bool lastDisplayedAffordability;

	public bool isCostStale;

	protected GameObject alert;

	public CanvasGroup canvas;

	private bool hasLoadedRequirement;

	public void ReloadLabels()
	{
		if (upgrade.displayAvailability == BuildObjectAvailability.Completed)
		{
			label.text = TextDisplay.LabelForUpgradeLevel(upgrade.type, upgrade.numCompleted);
		}
		else
		{
			label.text = TextDisplay.LabelForUpgradeLevel(upgrade.type, upgrade.numCompleted + 1);
		}
		if (hasLoadedRequirement)
		{
			questProgressBar.ReloadLabels();
		}
	}

	public void Initialize()
	{
		purchaseUpgradeButton.InitializeButton();
		purchaseUpgradeButton.AddPointerClickTrigger(OnUpgradePressed);
		purchaseUpgradeButton.buttonSoundType = ButtonSoundType.Purchase;
		alert = MenuManager.InstantiatedTextAlert(label.transform);
		alert.gameObject.SetActive(value: false);
		titleButton.AddPointerClickTrigger(OnLabelClicked);
		titleButton.tooltipOptions = MenuManager.Instance.recipeLabelTooltipOptions;
		canvas = base.gameObject.AddComponent<CanvasGroup>();
		questProgressBar.Initialize();
	}

	public void UpdateSimulationDisplay()
	{
		questProgressBar.UpdateSimulationDisplay();
	}

	public void UpdateDynamicDisplay()
	{
		if (isCostStale)
		{
			LoadCost();
		}
		if (alert.gameObject.activeInHierarchy && !upgrade.isInAlertState)
		{
			alert.gameObject.SetActive(value: false);
		}
		costGrid.UpdateSinglePurchaseAffordability();
		questProgressBar.UpdateDynamicDisplay();
		bool flag = upgrade.CanAffordCurrentLevel();
		if (upgrade.displayAvailability != lastDisplayedAvailability || lastDisplayedAffordability != flag)
		{
			lastDisplayedAffordability = flag;
			lastDisplayedAvailability = upgrade.displayAvailability;
			RefreshButtonDisplay();
		}
	}

	public override void ResetPointerAndHighlightState()
	{
		base.ResetPointerAndHighlightState();
		purchaseUpgradeButton.ResetPointerAndHighlightState();
	}

	private void RefreshButtonDisplay()
	{
		if (upgrade.displayAvailability == BuildObjectAvailability.Locked)
		{
			purchaseUpgradeButton.label.text = "Locked".Localized();
			purchaseUpgradeButton.invalidReason = InvalidReason.LockedByRequirements;
			purchaseUpgradeButton.buttonState = CustomButtonState.Disabled;
			costGrid.gameObject.SetActive(value: false);
			return;
		}
		if (upgrade.displayAvailability == BuildObjectAvailability.Completed)
		{
			purchaseUpgradeButton.label.text = "Completed".Localized();
			purchaseUpgradeButton.invalidReason = InvalidReason.ResearchAlreadyCompleted;
			purchaseUpgradeButton.buttonState = CustomButtonState.Disabled;
			costGrid.gameObject.SetActive(value: false);
			return;
		}
		if (upgrade.derivedAvailability == BuildObjectAvailability.InProgress)
		{
			costGrid.gameObject.SetActive(value: true);
			purchaseUpgradeButton.label.text = "InProgress".Localized();
			purchaseUpgradeButton.invalidReason = InvalidReason.LockedByRequirements;
			purchaseUpgradeButton.buttonState = CustomButtonState.Disabled;
			return;
		}
		costGrid.gameObject.SetActive(value: true);
		purchaseUpgradeButton.label.text = "Upgrade".Localized();
		if (cost.CanAfford())
		{
			purchaseUpgradeButton.invalidReason = InvalidReason.None;
			purchaseUpgradeButton.buttonState = CustomButtonState.Default;
		}
		else
		{
			purchaseUpgradeButton.invalidReason = InvalidReason.None;
			purchaseUpgradeButton.buttonState = CustomButtonState.Disabled;
		}
	}

	public void OnStateAssignmentChanged()
	{
		LoadCost();
		UpdateStaticDisplay();
		UpdateAlertState();
		ReloadLabels();
		RefreshButtonDisplay();
		purchaseUpgradeButton.AnimateInstant();
		if (hasLoadedRequirement)
		{
			questProgressBar.UpdateStaticDisplay();
			questProgressBar.UpdateSimulationDisplay();
			questProgressBar.UpdateDynamicDisplay();
		}
	}

	public void LoadUpgrade(Upgrade u)
	{
		upgrade = u;
		titleButton.tooltipEntity = EntityId.FromUpgrade(u.type);
		titleButton.tooltipModifier = TooltipModifier.ShowGuide;
		hasLoadedRequirement = false;
		if (u.displayAvailability == BuildObjectAvailability.Available)
		{
			IEnumerable<Requirement> enumerable = u.CurrentLevelRequirements();
			if (enumerable != null)
			{
				foreach (Requirement item in enumerable)
				{
					if (item is RequiredBiome || item is RequiredResearch { researchType: not ResearchType.OmnistoneUpgrades })
					{
						continue;
					}
					if (item is RequiredQuest requiredQuest)
					{
						foreach (Requirement requirement in requiredQuest.cachedQuest.completionRequirement.requirements)
						{
							if (!hasLoadedRequirement)
							{
								questProgressBar.LoadRequirement(requirement);
								hasLoadedRequirement = true;
							}
						}
					}
					else if (!hasLoadedRequirement)
					{
						questProgressBar.LoadRequirement(item);
						hasLoadedRequirement = true;
					}
				}
			}
		}
		else if (u.displayAvailability == BuildObjectAvailability.Locked)
		{
			foreach (Requirement displayRequirement in u.displayRequirements)
			{
				if (!displayRequirement.IsMet())
				{
					questProgressBar.LoadRequirement(displayRequirement);
					hasLoadedRequirement = true;
				}
			}
		}
		questProgressBar.gameObject.SetActive(hasLoadedRequirement);
	}

	public void UpdateAlertState()
	{
		alert.SetActive(upgrade.isInAlertState);
	}

	public void UpdateStaticDisplay()
	{
		ReloadLabels();
		iconImage.sprite = IconManager.SpriteForUpgrade(upgrade.type);
		if (hasLoadedRequirement)
		{
			questProgressBar.UpdateStaticDisplay();
		}
	}

	public void OnUpgradePressed()
	{
		if (!purchaseUpgradeButton.shouldIgnoreAction)
		{
			ResetPointerAndHighlightState();
			GameManager.Instance.OnUpgradePurchased(upgrade);
			UpdateStaticDisplay();
			LoadCost();
		}
	}

	private void OnLabelClicked()
	{
		MenuManager.Instance.tooltipPanel.ToggleEntityPinState(EntityId.FromUpgrade(upgrade.type));
	}

	public void LoadCost()
	{
		if (upgrade.cachedCurrentCostItem != null)
		{
			cost.Clear();
			cost.entries.Add((upgrade.cachedCurrentCostItem, upgrade.cachedCurrentCostAmount));
			costGrid.Clear();
			costGrid.AddStaticCost(cost);
			costGrid.PerformLayout();
			isCostStale = false;
		}
	}

	public void ClearAlertState()
	{
		if (upgrade.isInAlertState)
		{
			upgrade.isInAlertState = false;
			alert.SetActive(value: false);
			if (GameManager.Instance.gameState == GameState.InGame)
			{
				MenuManager.Instance.OnStateLostAlertDuringGame(upgrade);
			}
		}
	}

	public override void OnPointerEnter(PointerEventData eventData)
	{
		base.OnPointerEnter(eventData);
		parentPanel.OnHighlighted(this);
	}

	public override void OnRemoveFromList()
	{
		base.OnRemoveFromList();
		purchaseUpgradeButton.OnRemoveFromList();
	}

	public void SetVisible(bool visible)
	{
		canvas.alpha = (visible ? 1f : 0f);
		canvas.interactable = visible;
		canvas.blocksRaycasts = visible;
	}
}
