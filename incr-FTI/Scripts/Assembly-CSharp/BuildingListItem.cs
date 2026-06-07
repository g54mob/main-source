using System.Collections.Generic;
using System.Text;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingListItem : CommonListItem
{
	public BuildingState buildingState;

	public TextMeshProUGUI buildingLabel;

	public TextMeshProUGUI countLabel;

	public TextMeshProUGUI maxCountLabel;

	public Image iconImage;

	public ProgressButton createBuildingButton;

	public CostGrid costGrid;

	public MenuButton countRegion;

	public MenuButton titleButton;

	public MenuButton upgradeButton;

	public Image upgradeImage;

	public LabelButton removeButton;

	private double lastDisplayedProgress = double.MinValue;

	private float lastDisplayedNumWorkers = float.MinValue;

	private int lastDisplayedMaxState = int.MinValue;

	private int lastDisplayedNumConstructions = int.MinValue;

	private int lastDisplayedIncrement;

	private int lastDisplayedCostHash = int.MinValue;

	private Tweener countPunchTween;

	public override void Initialize()
	{
		base.Initialize();
		LoadAlert(buildingLabel.transform);
		createBuildingButton.AddPointerDownTrigger(OnBuildButtonPressed);
		createBuildingButton.buttonSoundType = ButtonSoundType.Default;
		removeButton.AddPointerClickTrigger(OnRemoveButtonPressed);
		rateDisplayRegion.rateDisplayMode = RateDisplayMode.TimeRemaining;
		rateDisplayRegion.ratioDisplayMode = RatioDisplayMode.RecipeRatio;
		rateDisplayRegion.iconDisplayMode = IconDisplayMode.PauseState;
		if (null != upgradeButton)
		{
			upgradeButton.buttonState = CustomButtonState.Background;
			upgradeButton.AddPointerClickTrigger(OnUpgradeClicked);
			upgradeButton.highlightTextDelegate = HighlightTextUpgrades;
		}
		titleButton.AddPointerClickTrigger(OnLabelClicked);
		if (costGrid.TryGetComponent<Image>(out var component))
		{
			component.raycastTarget = false;
		}
	}

	public void LoadState(BuildingState s)
	{
		buildingState = s;
		iconImage.sprite = IconManager.SpriteForBuilding(s.type);
		if (iconImage.sprite == null)
		{
			iconImage.enabled = false;
		}
		else
		{
			iconImage.enabled = true;
		}
		LoadCommonState(s.constructionState);
		titleButton.tooltipEntity = EntityId.FromBuilding(buildingState.type);
		titleButton.tooltipModifier = TooltipModifier.ShowGuide;
		titleButton.tooltipOptions = MenuManager.Instance.recipeLabelTooltipOptions;
	}

	public override void OnStateAssignmentChanged()
	{
		base.OnStateAssignmentChanged();
		UpdateCountsAndCost();
		createBuildingButton.AnimateInstant();
		removeButton.AnimateInstant();
		upgradeButton.AnimateInstant();
	}

	public void OnClickedCountRegion()
	{
	}

	public void UpdateButtonStates()
	{
		buildingState.FormatRemoveButton(removeButton);
		buildingState.FormatAddButton(createBuildingButton);
	}

	public override void UpdateDynamicDisplay()
	{
		base.UpdateDynamicDisplay();
		if (buildingState != null)
		{
			bool flag = false;
			if (UserInput.activeGlobalIncrement != lastDisplayedIncrement)
			{
				buildingState.CalcDisplayedCost();
				lastDisplayedIncrement = UserInput.activeGlobalIncrement;
				flag = true;
			}
			if (buildingState.dynamicCost.storedHash == 0)
			{
				buildingState.CalcDisplayedCost();
			}
			int num = ((UserInput.activeGlobalIncrement != 1) ? buildingState.dynamicCost.storedHash : buildingState.constructionState.inputHash);
			if (lastDisplayedCostHash != num)
			{
				LoadCost();
			}
			UpdateButtonStates();
			int num2 = buildingState.MaxStateFlag();
			createBuildingButton.slider.value = GameUtility.AsFloat(buildingState.constructionState.unitProgress);
			if (upgradeButton.gameObject.activeInHierarchy)
			{
				if (buildingState.hasUpgradeAvailable)
				{
					upgradeButton.buttonState = CustomButtonState.Default;
					upgradeImage.sprite = IconManager.Instance.upgradeOn;
				}
				else
				{
					upgradeButton.buttonState = CustomButtonState.Background;
					upgradeImage.sprite = IconManager.Instance.upgradeOff;
				}
			}
			if (GameUtility.NotEquals(buildingState.constructionState.unitProgress, lastDisplayedProgress) || GameUtility.NotEquals(buildingState.constructionState.numWorkersAssigned, lastDisplayedNumWorkers) || buildingState.pendingConstructions != lastDisplayedNumConstructions || num2 != lastDisplayedMaxState || flag)
			{
				ReloadButtonLabel();
			}
			if (UserInput.activeGlobalIncrement == 1)
			{
				float num3;
				if (GameUtility.IsNearlyZero(buildingState.constructionState.unitProgress))
				{
					num3 = 1f;
				}
				else
				{
					float num4 = GameUtility.AsFloat(buildingState.constructionState.unitProgress);
					num3 = Mathf.Clamp01(1f - num4);
				}
				foreach (ItemRateData item in buildingState.constructionState.input)
				{
					costGrid.SetAmount(item.state.AsEntity(), item.totalAmount * (double)num3);
				}
			}
			if (buildingState != null)
			{
				costGrid.UpdateDynamicAffordability();
			}
		}
		else
		{
			createBuildingButton.interactable = false;
		}
	}

	private void OnLabelClicked()
	{
		TooltipPanel tooltipPanel = MenuManager.Instance.tooltipPanel;
		EntityId entityId = buildingState.AsEntity();
		if (tooltipPanel.displayedEntity.Equals(entityId) && tooltipPanel.isPinned)
		{
			tooltipPanel.Unpin();
			return;
		}
		tooltipPanel.LoadEntityDescription(entityId);
		tooltipPanel.Pin();
	}

	private void OnRemoveButtonPressed()
	{
		TryRemove(removeButton);
		PunchCount();
	}

	public void TryRemove(MenuButton sender)
	{
		bool flag = false;
		if (sender.invalidReason != InvalidReason.None && !flag)
		{
			MenuManager.Instance.ShowMessage(sender.invalidReason);
			return;
		}
		buildingState.TryRemoveConstruction();
		UpdateCount();
	}

	public void OnBuildButtonPressed()
	{
		ClearAlertState();
		bool flag = false;
		int activeGlobalIncrement = UserInput.activeGlobalIncrement;
		for (int i = 0; i < activeGlobalIncrement; i++)
		{
			if (!buildingState.HasWorkerCapacityForSingleBuilding())
			{
				if (i == 0)
				{
					MenuManager.Instance.townStatsPanel.AnimateWorkerStat();
				}
				MenuManager.Instance.ShowMessage(InvalidReason.NotEnoughWorkers);
				break;
			}
			if (!buildingState.HasLandCapacityForSingleBuilding())
			{
				MenuManager.Instance.ShowMessage(InvalidReason.NotEnoughLand);
				break;
			}
			if (buildingState.currentCount + (double)buildingState.pendingConstructions >= buildingState.maxCount)
			{
				if (buildingState.buildingDef.isWonder && LocalizationManager.IsEnglish())
				{
					MenuManager.Instance.ShowMessage("You have reached the maximum number of this building type.\nLevel Up your town to increase this limit.");
				}
				else
				{
					MenuManager.Instance.ShowMessage(InvalidReason.MaxBuildings);
				}
				break;
			}
			flag |= buildingState.TryConstruct();
		}
		if (flag)
		{
			UpdateCount();
			PunchCount();
			buildingState.CalcDisplayedCost();
		}
	}

	private void PunchCount()
	{
		countPunchTween?.Kill(complete: true);
		float num = 0.2f;
		float duration = 0.25f;
		countPunchTween = countLabel.transform.DOPunchScale(new Vector3(num, num, 0f), duration, 0, 0f);
	}

	public void UpdateCountsAndCost()
	{
		UpdateCount();
		LoadCost();
		UpdateDynamicDisplay();
	}

	public void UpdateCount()
	{
		if (buildingState != null)
		{
			buildingState.CacheRemovalState(UserInput.activeGlobalIncrement);
			UpdateButtonStates();
			StringBuilder pooledStringBuilder = GameUtility.GetPooledStringBuilder();
			pooledStringBuilder.Append(TextDisplay.Multiplier);
			if (buildingState.maxCount < double.MaxValue)
			{
				pooledStringBuilder.AppendFormat(TextDisplay.FractionFormat, TextDisplay.LocalizedNumber(buildingState.currentCount), TextDisplay.LocalizedNumber(buildingState.maxCount));
			}
			else
			{
				pooledStringBuilder.Append(TextDisplay.LocalizedNumber(buildingState.currentCount));
			}
			if (buildingState.pendingConstructions > 0)
			{
				pooledStringBuilder.Append(' ');
				pooledStringBuilder.Append('+');
				pooledStringBuilder.Append(TextDisplay.LocalizedNumber(buildingState.pendingConstructions));
			}
			countLabel.SetText(pooledStringBuilder);
			GameUtility.ReturnToPool(pooledStringBuilder);
		}
	}

	public override void LoadCost()
	{
		base.LoadCost();
		costGrid.Clear();
		if (UserInput.activeGlobalIncrement != 1)
		{
			foreach (KeyValuePair<ItemType, double> item in buildingState.dynamicCost.items)
			{
				if (!Item.IsCostTrackedSeparately(item.Key))
				{
					if (buildingState.parentTown.inventory.TryGetValue(item.Key, out var value))
					{
						costGrid.AddStaticCost(value, item.Value);
					}
					lastDisplayedCostHash = buildingState.dynamicCost.storedHash;
				}
			}
		}
		else
		{
			foreach (ItemRateData item2 in buildingState.constructionState.input)
			{
				costGrid.AddInput(item2);
			}
			lastDisplayedCostHash = buildingState.constructionState.inputHash;
		}
		if ((float)buildingState.buildingDef.landRequired > 0f)
		{
			costGrid.AddStaticCost(buildingState.parentTown.landState, buildingState.buildingDef.landRequired * UserInput.activeGlobalIncrement);
		}
		if ((float)buildingState.buildingDef.workersRequired > 0f)
		{
			costGrid.AddStaticCost(buildingState.parentTown.workerState, buildingState.buildingDef.workersRequired * UserInput.activeGlobalIncrement);
		}
		costGrid.PerformLayout();
		costGrid.UpdateColors();
	}

	public override void ReloadLabelParent()
	{
		base.ReloadLabelParent();
		buildingLabel.text = TextDisplay.LabelForBuilding(buildingState.type);
		removeButton.label.text = "Remove".Localized();
		ReloadButtonLabel();
	}

	private void ReloadButtonLabel()
	{
		lastDisplayedProgress = buildingState.constructionState.unitProgress;
		lastDisplayedNumWorkers = buildingState.constructionState.numWorkersAssigned;
		lastDisplayedMaxState = buildingState.MaxStateFlag();
		lastDisplayedNumConstructions = buildingState.pendingConstructions;
		UpdateCount();
		string format = TextDisplay.LocalizedTwoValueFormat();
		if (buildingState.pendingConstructions > 0)
		{
			if (lastDisplayedIncrement > 1)
			{
				removeButton.label.text = string.Format(format, "Cancel".Localized(), "x" + TextDisplay.LocalizedNumber(lastDisplayedIncrement));
			}
			else
			{
				removeButton.label.text = "Cancel".Localized();
			}
		}
		else if (lastDisplayedIncrement > 1)
		{
			removeButton.label.text = string.Format(format, "Remove".Localized(), "x" + TextDisplay.LocalizedNumber(lastDisplayedIncrement));
		}
		else
		{
			removeButton.label.text = "Remove".Localized();
		}
		if (GameUtility.IsNearlyZero(lastDisplayedProgress) || lastDisplayedIncrement > 1)
		{
			if (lastDisplayedIncrement > 1)
			{
				createBuildingButton.label.text = string.Format(format, "Build".Localized(), "x" + TextDisplay.LocalizedNumber(lastDisplayedIncrement));
			}
			else
			{
				createBuildingButton.label.text = "Build".Localized();
			}
			createBuildingButton.label.color = Color.white;
		}
		else
		{
			createBuildingButton.label.color = Color.white;
			TextDisplay.SetPercent(createBuildingButton.label, buildingState.constructionState.UnitProgressPercent());
		}
	}

	protected override void OnSelectionStateChanged()
	{
		base.OnSelectionStateChanged();
		if (isSelected)
		{
			ClearAlertState();
		}
	}

	private void OnUpgradeClicked()
	{
		MenuManager.Instance.upgradesPanel.ShowWithFilter(buildingState);
	}

	public override void UpdateRegionAvailability()
	{
		base.UpdateRegionAvailability();
		if (null != upgradeButton)
		{
			bool active = GameManager.IsGlobalQuestComplete(QuestType.ResearchForUpgrades);
			upgradeButton.gameObject.SetActive(active);
		}
	}

	private string HighlightTextUpgrades()
	{
		return "Upgrades".Localized();
	}
}
