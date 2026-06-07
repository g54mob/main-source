using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConstructionDetailsPanel : MenuPanel
{
	public TextMeshProUGUI currentCountLabel;

	public TextMeshProUGUI underConstructionLabel;

	public TextMeshProUGUI constructionCostLabel;

	public LabelButton createBuildingButton;

	public LabelButton removeBuildingButton;

	private float lastDisplayedRate = float.MinValue;

	public CostGrid currentCostGrid;

	public CostGrid remainingConstructionCostGrid;

	private BuildingState buildingState;

	public RateDisplayRegion rateDisplayRegion;

	public ProductionTargetRegion productionTargetRegion;

	private double lastDisplayedProgress = double.MinValue;

	private double lastDisplayedCount = double.MinValue;

	private int lastDisplayedNumConstructions = int.MinValue;

	private int lastDisplayedIncrement;

	public PriorityRegion priorityRegion;

	public PauseRegion pauseRegion;

	private bool forceRefresh;

	private int lastDisplayedUpperCostHash = int.MinValue;

	private int lastDisplayedRemainingCostHash = int.MinValue;

	public override void Initialize()
	{
		base.Initialize();
		rateDisplayRegion.Initialize();
		rateDisplayRegion.rateDisplayMode = RateDisplayMode.TimeRemaining;
		rateDisplayRegion.ratioDisplayMode = RatioDisplayMode.RecipeRatio;
		rateDisplayRegion.highlightTextDelegate = rateDisplayRegion.RateHighlightText;
		rateDisplayRegion.isTooltipUpdatedEverySimulationStep = true;
		createBuildingButton.AddPointerDownTrigger(OnBuildButtonPressed);
		createBuildingButton.buttonSoundType = ButtonSoundType.Default;
		removeBuildingButton.AddPointerDownTrigger(OnRemoveButtonPressed);
		removeBuildingButton.buttonSoundType = ButtonSoundType.Default;
		priorityRegion.Initialize(OnPriorityChanged);
		pauseRegion.Initialize(OnPauseChanged);
		if (null != productionTargetRegion)
		{
			productionTargetRegion.priorityImage.enabled = false;
		}
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		constructionCostLabel.text = "ConstructionCost".Localized() + ":";
	}

	public override void CreateLayoutForActiveTown()
	{
		base.CreateLayoutForActiveTown();
		lastDisplayedIncrement = int.MinValue;
	}

	public override void Show()
	{
		base.Show();
		UpdatePinnedDisplay();
		UpdateRegionAvailability();
	}

	public override void UpdateStaticDisplay()
	{
		base.UpdateStaticDisplay();
		ReloadPriorityState();
		ReloadPauseState();
	}

	public override void UpdatePriorityDisplay()
	{
		base.UpdatePriorityDisplay();
		ReloadPriorityState();
	}

	public override void UpdatePauseDisplay()
	{
		base.UpdatePauseDisplay();
		ReloadPauseState();
	}

	protected override void UpdateDynamicDisplay()
	{
		base.UpdateDynamicDisplay();
		rateDisplayRegion.UpdateDynamicDisplay();
		if (buildingState == null)
		{
			return;
		}
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
		if (lastDisplayedUpperCostHash != buildingState.dynamicCost.storedHash)
		{
			LoadUpperCost();
		}
		int num = buildingState.constructionState.inputHash;
		if (buildingState.pendingConstructions == 0)
		{
			num = 0;
		}
		if (lastDisplayedRemainingCostHash != num)
		{
			LoadLowerCost();
		}
		UpdateButtonStates();
		buildingState.MaxStateFlag();
		float num2 = buildingState.constructionState.DisplayedDynamicProgress();
		if (GameUtility.NotEquals(num2, lastDisplayedProgress) || GameUtility.NotEquals(buildingState.currentCount, lastDisplayedCount) || buildingState.pendingConstructions != lastDisplayedNumConstructions || flag)
		{
			lastDisplayedProgress = num2;
			ReloadButtonLabel();
		}
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
			remainingConstructionCostGrid.SetAmount(item.state.AsEntity(), item.totalAmount * (double)num3);
		}
		if (buildingState != null)
		{
			remainingConstructionCostGrid.UpdateDynamicAffordability();
		}
	}

	protected override void UpdateSimulationDisplay()
	{
		base.UpdateSimulationDisplay();
		rateDisplayRegion.UpdateSimulationDisplay();
	}

	private void ReloadButtonLabel()
	{
		lastDisplayedNumConstructions = buildingState.pendingConstructions;
		lastDisplayedCount = buildingState.currentCount;
		UpdateCount();
		string format = TextDisplay.LocalizedTwoValueFormat();
		if (buildingState.pendingConstructions > 0)
		{
			if (lastDisplayedIncrement > 1)
			{
				removeBuildingButton.label.text = string.Format(format, "Cancel".Localized(), "x" + TextDisplay.LocalizedNumber(lastDisplayedIncrement));
			}
			else
			{
				removeBuildingButton.label.text = "Cancel".Localized();
			}
		}
		else if (lastDisplayedIncrement > 1)
		{
			removeBuildingButton.label.text = string.Format(format, "Remove".Localized(), "x" + TextDisplay.LocalizedNumber(lastDisplayedIncrement));
		}
		else
		{
			removeBuildingButton.label.text = "Remove".Localized();
		}
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

	public void UpdateButtonStates()
	{
		buildingState.FormatRemoveButton(removeBuildingButton);
		buildingState.FormatAddButton(createBuildingButton);
	}

	public void UpdateRegionAvailability()
	{
		priorityRegion.gameObject.SetActive(buildingState.parentTown.AllowPriority());
	}

	public void LoadState(BuildingState s)
	{
		s.CalcDisplayedCost();
		buildingState = s;
		header.headerIcon.sprite = IconManager.SpriteForBuilding(s.type);
		headerLocalizationKey = "Construction";
		header.displayedEntity = s.AsEntity();
		pauseRegion.pauseButton.AnimateInstant();
		priorityRegion.priorityButton.AnimateInstant();
		priorityRegion.displayedSettings = s.constructionState.localSettings;
		pauseRegion.displayedSettings = s.constructionState.localSettings;
		rateDisplayRegion.ResetDisplay();
		rateDisplayRegion.state = s.constructionState;
		if (null != rateDisplayRegion.progressButton)
		{
			rateDisplayRegion.progressButton.AnimateInstant();
			if (null != rateDisplayRegion.progressButton)
			{
				rateDisplayRegion.progressButton.stateManager = s.constructionState;
			}
		}
		UpdatePauseDisplay();
		UpdatePriorityDisplay();
		ReloadLabels();
	}

	public void OnBuildButtonPressed()
	{
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
			buildingState.CalcDisplayedCost();
		}
	}

	private void OnRemoveButtonPressed()
	{
		TryRemove(removeBuildingButton);
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

	public void UpdateCount()
	{
		if (buildingState != null)
		{
			buildingState.CacheRemovalState(UserInput.activeGlobalIncrement);
			UpdateButtonStates();
			StringBuilder pooledStringBuilder = GameUtility.GetPooledStringBuilder();
			pooledStringBuilder.Append("Completed".Localized());
			pooledStringBuilder.Append(':');
			pooledStringBuilder.Append(' ');
			pooledStringBuilder.Append(TextDisplay.LocalizedNumber(buildingState.currentCount));
			if (buildingState.maxCount < double.MaxValue)
			{
				pooledStringBuilder.Append(' ');
				pooledStringBuilder.Append('(');
				pooledStringBuilder.Append(TextDisplay.FormattedKeyValue("Max", TextDisplay.LocalizedNumber(buildingState.maxCount)));
				pooledStringBuilder.Append(')');
			}
			currentCountLabel.SetText(pooledStringBuilder);
			pooledStringBuilder.Clear();
			pooledStringBuilder.Append("InProgress".Localized());
			pooledStringBuilder.Append(':');
			pooledStringBuilder.Append(' ');
			pooledStringBuilder.Append(TextDisplay.LocalizedNumber(buildingState.pendingConstructions));
			underConstructionLabel.SetText(pooledStringBuilder);
			GameUtility.ReturnToPool(pooledStringBuilder);
		}
	}

	public void UpdateCountsAndCost()
	{
		UpdateCount();
		LoadUpperCost();
		UpdateDynamicDisplay();
	}

	public void LoadLowerCost()
	{
		remainingConstructionCostGrid.Clear();
		if (buildingState.pendingConstructions == 0)
		{
			lastDisplayedRemainingCostHash = 0;
		}
		else
		{
			foreach (ItemRateData item in buildingState.constructionState.input)
			{
				remainingConstructionCostGrid.AddInput(item);
			}
			lastDisplayedRemainingCostHash = buildingState.constructionState.inputHash;
		}
		remainingConstructionCostGrid.PerformLayout();
	}

	public void LoadUpperCost()
	{
		currentCostGrid.Clear();
		foreach (KeyValuePair<ItemType, double> item in buildingState.dynamicCost.items)
		{
			if (!Item.IsCostTrackedSeparately(item.Key) && buildingState.parentTown.inventory.TryGetValue(item.Key, out var value))
			{
				currentCostGrid.AddStaticCost(value, item.Value);
			}
		}
		if ((float)buildingState.buildingDef.landRequired > 0f)
		{
			currentCostGrid.AddStaticCost(buildingState.parentTown.landState, buildingState.buildingDef.landRequired * UserInput.activeGlobalIncrement);
		}
		if ((float)buildingState.buildingDef.workersRequired > 0f)
		{
			currentCostGrid.AddStaticCost(buildingState.parentTown.workerState, buildingState.buildingDef.workersRequired * UserInput.activeGlobalIncrement);
		}
		currentCostGrid.PerformLayout();
		lastDisplayedUpperCostHash = buildingState.dynamicCost.storedHash;
	}

	public void ReloadPauseState()
	{
		if (null != pauseRegion)
		{
			ReloadButtonState(pauseRegion.pauseButton, pauseRegion.pauseImage, buildingState.constructionState.localSettings.pause.value);
			pauseRegion.SetPauseDisplay(buildingState.constructionState.localSettings.pause.value, buildingState.constructionState.appliedPauseState);
		}
	}

	private static void ReloadButtonState(MenuButton button, Image targetImage, OverrideState localState)
	{
		button.isSelected = localState != OverrideState.None;
		if (localState == OverrideState.None)
		{
			targetImage.color = ColorManager.inheritedStateColor;
		}
		else
		{
			targetImage.color = Color.white;
		}
	}

	public void ReloadPriorityState()
	{
		if (null != priorityRegion)
		{
			priorityRegion.SetPriorityImage(buildingState.constructionState.localSettings.priority.value, buildingState.constructionState.appliedPriority);
		}
	}

	private void OnPriorityChanged()
	{
		if (buildingState != null)
		{
			buildingState.constructionState.parentTown.OnPriorityChanged(buildingState.constructionState);
			ReloadPriorityState();
			MenuManager.Instance.isTooltipStale = true;
		}
	}

	private void OnPauseChanged()
	{
		buildingState.constructionState.CalcAppliedPauseState();
		ReloadPauseState();
		MenuManager.Instance.isTooltipStale = true;
	}

	public void TryShowFromHighlightedRegion(BuildingCountRegion region)
	{
		if (!IsVisible() || !isPinned)
		{
			LoadState(region.loadedState);
			ShowForTown(displayedTown);
			TrySendToFront();
			RectTransform source = (RectTransform)region.transform;
			RectTransform target = (RectTransform)base.gameObject.transform;
			MenuPanel.m.SetTooltipPosition(source, target, TextAnchor.MiddleRight, TextAnchor.MiddleRight, 0f, centerX: false, centerY: false, allowHorizontalFlip: false);
		}
	}
}
