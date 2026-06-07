using System;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSectionHeader : SectionHeader
{
	public MenuButton displayToggleButton;

	public MenuButton productionCapacityRegion;

	public Image productionCapacityImage;

	public TextMeshProUGUI capacityAvailableLabel;

	public TextMeshProUGUI capacityMaxLabel;

	public TextMeshProUGUI increaseLabel;

	public TextMeshProUGUI decreaseLabel;

	public TextMeshProUGUI buildingCountLabel;

	public MenuButton infoButton;

	public RectTransform layoutGroupLeft;

	public BuildingCountRegion constructionDetailsButton;

	[NonSerialized]
	public BuildingState displayedBuilding;

	private int lastDisplayedCostHash = int.MinValue;

	private const bool showTotalCount = false;

	public PauseRegion pauseRegion;

	public PriorityRegion priorityRegion;

	public AutoAssignRegion autoAssignRegion;

	public AutoClaimRegion autoClaimRegion;

	public ProductionTargetRegion productionTargetRegion;

	public MenuButton upgradeButton;

	public Image upgradeImage;

	public MenuButton addBuildingButton;

	public MenuButton removeBuildingButton;

	public ProgressBar addBuildingProgressBar;

	private TextFlashAnimation textAnimationPrimary;

	private TextFlashAnimation textAnimationDetail;

	private IncrementDisplayManager incrementDisplayManager;

	public TownProgressBarItem fulfillmentProgress;

	private int lastDisplayedProductionCapacityHash;

	protected override void Awake()
	{
		base.Awake();
		textAnimationPrimary = new TextFlashAnimation(primaryLabel);
		textAnimationDetail = new TextFlashAnimation(capacityAvailableLabel);
	}

	public override void ReloadLabels()
	{
		if (displayedBuilding != null)
		{
			string text = TextDisplay.LabelForBuilding(displayedBuilding.type);
			primaryLabel.text = text;
			UpdateBuildingCountLabel();
			constructionDetailsButton.CalcDisplayHashChange();
			UpdateProductionCapacityLabel();
		}
		if (null != fulfillmentProgress)
		{
			fulfillmentProgress.primaryLabel.text = string.Empty;
		}
		base.ReloadLabels();
	}

	private bool CalcProductionCapacityHashChange()
	{
		int num = 0;
		if (displayedBuilding != null)
		{
			num = displayedBuilding.GetProductionCapacityHash();
		}
		if (num != lastDisplayedProductionCapacityHash)
		{
			lastDisplayedProductionCapacityHash = num;
			return true;
		}
		return false;
	}

	public void UpdateBuildingCountLabel()
	{
		StringBuilder pooledStringBuilder = GameUtility.GetPooledStringBuilder();
		pooledStringBuilder.Append(TextDisplay.Multiplier);
		if (displayedBuilding.maxCount < double.MaxValue)
		{
			pooledStringBuilder.AppendFormat(TextDisplay.FractionFormat, TextDisplay.LocalizedNumber(displayedBuilding.currentCount), TextDisplay.LocalizedNumber(displayedBuilding.maxCount));
		}
		else
		{
			pooledStringBuilder.Append(TextDisplay.LocalizedNumber(displayedBuilding.currentCount));
		}
		if (displayedBuilding.pendingConstructions > 0)
		{
			pooledStringBuilder.Append(' ');
			pooledStringBuilder.Append('+');
			pooledStringBuilder.Append(TextDisplay.LocalizedNumber(displayedBuilding.pendingConstructions));
		}
		buildingCountLabel.SetText(pooledStringBuilder);
		GameUtility.ReturnToPool(pooledStringBuilder);
	}

	public void UpdateProductionCapacityLabel()
	{
		if (displayedBuilding != null)
		{
			lastDisplayedProductionCapacityHash = displayedBuilding.GetProductionCapacityHash();
		}
		else
		{
			lastDisplayedProductionCapacityHash = 0;
		}
		if (displayedBuilding != null)
		{
			double numAvailable;
			double value;
			if (displayedBuilding.type == BuildingType.House)
			{
				numAvailable = displayedBuilding.parentTown.workerState.numAvailable;
				value = displayedBuilding.parentTown.workerState.currentCount;
			}
			else
			{
				numAvailable = displayedBuilding.numAvailable;
				value = displayedBuilding.totalProductionCapacity;
			}
			if (numAvailable <= 0.0)
			{
				capacityAvailableLabel.color = Color.yellow;
			}
			else
			{
				capacityAvailableLabel.color = Color.white;
			}
			TextDisplay.SetNumber(capacityAvailableLabel, numAvailable);
			StringBuilder pooledStringBuilder = GameUtility.GetPooledStringBuilder();
			pooledStringBuilder.Append('/');
			pooledStringBuilder.Append(' ');
			pooledStringBuilder.Append(TextDisplay.LocalizedNumber(value));
			capacityMaxLabel.SetText(pooledStringBuilder);
			GameUtility.ReturnToPool(pooledStringBuilder);
		}
	}

	public override void Initialize()
	{
		base.Initialize();
		constructionDetailsButton.AddPointerClickTrigger(OnConstructionDetailsPressed);
		pauseRegion.Initialize(OnPauseChanged);
		pauseRegion.pauseButton.buttonState = CustomButtonState.Background;
		infoButton.AddPointerClickTrigger(OnInfoButtonClicked);
		infoButton.animateSize = true;
		if (null != priorityRegion)
		{
			priorityRegion.Initialize(OnPriorityChanged);
		}
		addBuildingButton.AddPointerDownTrigger(OnAddButtonPressed);
		removeBuildingButton.AddPointerDownTrigger(OnRemoveButtonPressed);
		productionCapacityRegion.highlightTextDelegate = ProductionHighlightText;
		productionCapacityRegion.AddRightClickTrigger(OnProductionCapacityRightClicked);
		if (null != autoAssignRegion)
		{
			autoAssignRegion.Initialize(OnAutoAssignClicked, OnAutoAssignChanged);
		}
		if (null != productionTargetRegion)
		{
			productionTargetRegion.InitializeAsStandaloneButton();
			productionTargetRegion.onLimitChangedDelegate = OnProductionLimitChanged;
			productionTargetRegion.onPauseChangedDelegate = OnPauseChanged;
		}
		incrementDisplayManager = new IncrementDisplayManager(increaseLabel, decreaseLabel);
		if (null != fulfillmentProgress)
		{
			fulfillmentProgress.highlightTextDelegate = FulfillmentHighlightText;
			fulfillmentProgress.progressBar.fillImage.color = ColorManager.fulfillment;
		}
		if (null != upgradeButton)
		{
			upgradeButton.buttonState = CustomButtonState.Background;
			upgradeButton.AddPointerClickTrigger(OnUpgradeClicked);
			upgradeButton.highlightTextDelegate = HighlightTextUpgrades;
		}
	}

	private string ProductionHighlightText()
	{
		return TextDisplay.ProductionHighlightText(displayedBuilding.type == BuildingType.House);
	}

	private string HighlightTextUpgrades()
	{
		return "Upgrades".Localized();
	}

	private string FulfillmentHighlightText()
	{
		return "AverageFulfillment".Localized();
	}

	private string HighlightTextAutoRestart()
	{
		string localizedValue = ((displayedBuilding.settings.autoClaim.value == OverrideState.On) ? "On".Localized() : "Off".Localized());
		return TextDisplay.FormattedKeyValue("ClaimAutomatically", localizedValue);
	}

	public void UpdateRegionAvailability()
	{
		if (displayedBuilding?.parentTown != null)
		{
			bool hasValidChildren = layoutManager.hasValidChildren;
			if (null != pauseRegion)
			{
				pauseRegion.gameObject.SetActive((!hasValidChildren || !GameManager.IsGlobalQuestComplete(Quest.UnlockPause)) && false);
			}
			if (null != productionTargetRegion)
			{
				productionTargetRegion.gameObject.SetActive(hasValidChildren && GameManager.IsGlobalQuestComplete(Quest.UnlockProductionLimits));
			}
			if (null != productionCapacityImage && displayedBuilding.type == BuildingType.House)
			{
				productionCapacityImage.sprite = IconManager.SpriteForItem(ItemType.Worker);
			}
			if (null != priorityRegion)
			{
				bool active = GameManager.IsGlobalQuestComplete(Quest.UnlockPrioritization) && hasValidChildren;
				priorityRegion.gameObject.SetActive(active);
			}
			if (null != autoAssignRegion)
			{
				bool active2 = GameManager.IsGlobalQuestComplete(Quest.UnlockAutoBalance) && hasValidChildren;
				autoAssignRegion.gameObject.SetActive(active2);
			}
			if (null != upgradeButton)
			{
				bool active3 = GameManager.IsGlobalQuestComplete(QuestType.ResearchForUpgrades);
				upgradeButton.gameObject.SetActive(active3);
			}
			if (null != autoClaimRegion)
			{
				bool active4 = GameManager.IsGlobalQuestComplete(QuestType.OmnitempleForAutoClaim);
				autoClaimRegion.gameObject.SetActive(active4);
			}
			if (null != productionCapacityRegion)
			{
				bool flag = hasValidChildren || displayedBuilding.type == BuildingType.House;
				productionCapacityRegion.gameObject.SetActive(flag && GameManager.IsGlobalQuestComplete(QuestType.HouseForHarvesterHut));
			}
			if (null != fulfillmentProgress)
			{
				fulfillmentProgress.gameObject.SetActive(displayedBuilding != null && displayedBuilding.buildingDef.isMarket && GameManager.IsGlobalQuestComplete(QuestType.GrainForFoodMarket));
			}
		}
	}

	public void OnAddButtonPressed()
	{
		MenuManager.Instance.pointerDelayCounter = 0f;
		bool flag = false;
		for (int i = 0; i < UserInput.activeGlobalIncrement; i++)
		{
			flag |= displayedBuilding.TryConstruct();
		}
		if (flag)
		{
			displayedBuilding.CalcDisplayedCost();
			UpdateBuildingData();
		}
	}

	private void OnProductionCapacityRightClicked()
	{
		PopupMenu popupMenu = MenuManager.Instance.ShowPopupMenu((RectTransform)productionCapacityRegion.transform);
		string text = "RemoveAll".Localized();
		popupMenu.AddLabelButton(text, null, OnRemoveCapacityClicked);
		popupMenu.ResizeHeight();
	}

	private void OnRemoveCapacityClicked(PopupMenuItem sender)
	{
		if (displayedBuilding.settings.autoAssign.value == OverrideState.On)
		{
			displayedBuilding.settings.autoAssign.ChangeValue(OverrideState.None);
			OnAutoAssignChanged();
		}
		foreach (StateManager dependentState in displayedBuilding.dependentStates)
		{
			dependentState.OnNumWorkersChanged(0f);
		}
		MenuManager.Instance.popupMenu.Hide();
	}

	public void OnRemoveButtonPressed()
	{
		_ = removeBuildingButton;
		if (removeBuildingButton.invalidReason != InvalidReason.None)
		{
			MenuManager.Instance.ShowMessage(removeBuildingButton.invalidReason);
		}
		else if (displayedBuilding.CanRemove(UserInput.activeGlobalIncrement))
		{
			displayedBuilding.TryRemoveConstruction();
			displayedBuilding.CalcDisplayedCost();
			ReloadLabels();
		}
	}

	private void OnUpgradeClicked()
	{
		MenuManager.Instance.upgradesPanel.ShowWithFilter(displayedBuilding);
	}

	private void OnPriorityChanged()
	{
		displayedBuilding.parentTown.OnPriorityChanged(displayedBuilding);
		parentPanel.isPriorityStale = true;
		MenuManager.Instance.isTooltipStale = true;
	}

	public void OnConstructionDetailsPressed()
	{
		MenuManager.Instance.constructionDetailsPanel.LoadState(displayedBuilding);
		MenuManager.Instance.constructionDetailsPanel.ShowForTown(displayedBuilding.parentTown);
		MenuManager.Instance.constructionDetailsPanel.Pin();
	}

	private void OnPauseChanged()
	{
		productionTargetRegion.debug = true;
		displayedBuilding.parentTown.CalcAllPause();
		parentPanel.isPauseStale = true;
		parentPanel.isProductionLimitStale = true;
		MenuManager.Instance.isTooltipStale = true;
	}

	private void OnProductionLimitChanged()
	{
		displayedBuilding.parentTown.OnProductionLimitChangedBuilding(displayedBuilding);
		parentPanel.isProductionLimitStale = true;
	}

	private void OnAutoAssignClicked()
	{
		displayedBuilding.settings.CycleAutoAssign();
		OnAutoAssignChanged();
	}

	private void OnAutoAssignChanged()
	{
		displayedBuilding.parentTown.CalcAllAutoAssign();
		parentPanel.isAutoAssignStale = true;
		MenuManager.Instance.isTooltipStale = true;
	}

	public void FormatAsNonBuilding()
	{
		priorityRegion.gameObject.SetActive(value: false);
		addBuildingButton.gameObject.SetActive(value: false);
		removeBuildingButton.gameObject.SetActive(value: false);
	}

	public void LoadState(BuildingState t)
	{
		layoutManager.linkedObject = t;
		layoutManager.layoutRect.SetHeight(layoutManager.heightOfSelf);
		constructionDetailsButton.loadedState = t;
		displayedBuilding = t;
		displayedBuilding.isUpgradeAvailabilityStale = true;
		buildingImage.sprite = IconManager.SpriteForEntity(t.AsEntity());
		infoButton.tooltipEntity = t.AsEntity();
		infoButton.tooltipModifier = TooltipModifier.ShowGuide;
		infoButton.tooltipOptions = MenuManager.Instance.headerInfoTooltipOptions;
		UpdateBuildingData();
		UpdateSimulationDisplay();
		UpdateConstructionSlider();
		addBuildingButton.AnimateInstant();
		removeBuildingButton.AnimateInstant();
		priorityRegion.displayedSettings = displayedBuilding.settings;
		pauseRegion.displayedSettings = displayedBuilding.settings;
		if (null != productionTargetRegion)
		{
			productionTargetRegion.displayedSettings = displayedBuilding.settings;
		}
		if (null != autoAssignRegion)
		{
			autoAssignRegion.displayedSettings = displayedBuilding.settings;
		}
	}

	public void UpdateProductionLimitDisplay()
	{
		if (null != productionTargetRegion && displayedBuilding != null)
		{
			productionTargetRegion.SetTargetImage();
		}
	}

	public void UpdatePriorityDisplay()
	{
		if (null != priorityRegion && displayedBuilding != null)
		{
			priorityRegion.SetPriorityImage(displayedBuilding.settings.craftingGroupPriority);
		}
	}

	public void UpdateAutoAssignDisplay()
	{
		if (null != autoAssignRegion && displayedBuilding != null)
		{
			autoAssignRegion.SetDisplayedState(displayedBuilding.settings.autoAssign.value == OverrideState.On);
		}
	}

	public void UpdateAutoClaimDisplay()
	{
		if (null != autoClaimRegion && displayedBuilding != null)
		{
			autoClaimRegion.SetDisplayedState(displayedBuilding.settings.autoClaim.value == OverrideState.On);
		}
	}

	public void UpdatePauseDisplay()
	{
		if (displayedBuilding != null)
		{
			pauseRegion.SetPauseDisplay(displayedBuilding.settings.pause.value == OverrideState.On);
		}
	}

	public void UpdateBuildingData()
	{
		if (displayedBuilding != null)
		{
			UpdatePauseDisplay();
			UpdatePriorityDisplay();
			UpdateAutoAssignDisplay();
			UpdateAddAndRemoveButtons();
			ReloadLabels();
		}
	}

	public void UpdateAddAndRemoveButtons()
	{
		if (displayedBuilding != null)
		{
			displayedBuilding.CacheRemovalState(UserInput.activeGlobalIncrement);
			displayedBuilding.FormatAddButton(addBuildingButton);
			displayedBuilding.FormatRemoveButton(removeBuildingButton);
		}
	}

	public void UpdateSimulationDisplay()
	{
		if (displayedBuilding == null)
		{
			return;
		}
		UpdateAddAndRemoveButtons();
		switch (displayedBuilding.constructionState.inputAffordabilityState)
		{
		case AffordabilityState.CanNotProduce:
			buildingCountLabel.color = ColorManager.inputStarved;
			break;
		case AffordabilityState.CanPartiallyProduce:
			buildingCountLabel.color = ColorManager.inputSlowed;
			break;
		default:
			buildingCountLabel.color = Color.white;
			break;
		}
		if (null != fulfillmentProgress && fulfillmentProgress.gameObject.activeInHierarchy)
		{
			float num = 0f;
			if (displayedBuilding.happinessCount > 0.0)
			{
				num = GameUtility.AsTruncatedFloat(displayedBuilding.happinessTotal / displayedBuilding.happinessCount);
			}
			TextDisplay.SetPercent(fulfillmentProgress.countLabel, num);
			fulfillmentProgress.progressBar.slider.value = num;
			int q = GameUtility.HappinessQuintileForSupplyRate(num);
			fulfillmentProgress.iconImage.sprite = IconManager.SpriteForHappinessQuintile(q);
		}
		if (constructionDetailsButton.CalcDisplayHashChange())
		{
			UpdateBuildingCountLabel();
		}
	}

	public void UpdateConstructionSlider()
	{
		addBuildingProgressBar.slider.value = displayedBuilding.constructionState.DisplayedDynamicProgress();
	}

	public void UpdateDynamicDisplay()
	{
		textAnimationPrimary?.UpdateAnimation();
		textAnimationDetail?.UpdateAnimation();
		incrementDisplayManager.UpdateDynamicDisplay(UserInput.activeGlobalIncrement);
		if (headerNavigationButton.isPointerInsideButton)
		{
			if (!infoButton.gameObject.activeSelf)
			{
				infoButton.gameObject.SetActive(value: true);
			}
		}
		else if (infoButton.gameObject.activeSelf)
		{
			infoButton.gameObject.SetActive(value: false);
		}
		if (displayedBuilding == null)
		{
			return;
		}
		UpdateConstructionSlider();
		if (displayedBuilding.isUpgradeAvailabilityStale)
		{
			displayedBuilding.CalcUpgradeAffordability();
			if (upgradeButton.gameObject.activeInHierarchy)
			{
				if (displayedBuilding.hasUpgradeAvailable)
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
			displayedBuilding.isUpgradeAvailabilityStale = false;
		}
		if (CalcProductionCapacityHashChange())
		{
			UpdateProductionCapacityLabel();
		}
	}

	public void AnimateTextFlash()
	{
		textAnimationDetail?.Run();
		textAnimationPrimary?.Run();
	}

	private void OnInfoButtonClicked()
	{
		TooltipPanel tooltipPanel = MenuManager.Instance.tooltipPanel;
		EntityId entityId = displayedBuilding.AsEntity();
		if (tooltipPanel.displayedEntity.Equals(entityId) && tooltipPanel.isPinned)
		{
			tooltipPanel.Unpin();
			return;
		}
		tooltipPanel.LoadEntityDescription(entityId);
		tooltipPanel.Pin();
	}
}
