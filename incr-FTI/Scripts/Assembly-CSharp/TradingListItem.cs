using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TradingListItem : CommonListItem
{
	public TradingState tradingState;

	public Image iconImage;

	public TextMeshProUGUI label;

	public CostGrid costGridInput;

	public InventoryListItem inventoryListItem;

	public TextMeshProUGUI tradeModeLabel;

	public TradeModeRegion tradeModeRegion;

	public Image topIcon;

	private float displayedUnitProgress;

	private int lastDisplayedBalanceFactor = int.MinValue;

	private float lastDisplayedNumWorkers;

	public void FinalizeLoad()
	{
		displayedUnitProgress = GameUtility.AsFloat(tradingState.unitProgress);
	}

	public void ReloadTradeModeDisplay()
	{
		bool isInherited = tradingState.localSettings.tradingConfig.value == TradeMode.None;
		tradeModeRegion.SetModeImage(tradingState.appliedTradeMode, isInherited);
		rateDisplayRegion.progressButton.slider.gameObject.SetActive(tradingState.activeTradeMode != TradeMode.Off);
	}

	public override void ReloadLabelParent()
	{
		base.ReloadLabelParent();
		tradeModeLabel.text = TextDisplay.LabelForTradeMode(tradingState.activeTradeMode);
		label.text = TextDisplay.LabelForItem(tradingState.itemType);
	}

	public override void Initialize()
	{
		base.Initialize();
		tradeModeRegion.Initialize();
		tradeModeRegion.onChangedDelegate = OnTradeModeChanged;
		LoadAlert(label.transform);
		rateDisplayRegion.ratioDisplayMode = RatioDisplayMode.RecipeRatio;
		rateDisplayRegion.rateDisplayMode = RateDisplayMode.OutputRate;
		rateDisplayRegion.iconDisplayMode = IconDisplayMode.PauseState;
		inventoryListItem.gameObject.SetActive(value: true);
		inventoryListItem.AddPointerClickTrigger(OnClickedWarehouse);
	}

	public void LoadState(TradingState state)
	{
		tradingState = state;
		tradeModeRegion.displayedSettings = state.localSettings;
		iconImage.sprite = IconManager.SpriteForItem(state.itemType);
		LoadCommonState(state);
		inventoryListItem.LoadState(state.globalWarehouseState);
		topIcon.sprite = IconManager.SpriteForState(state.globalWarehouseState);
		ReloadTradeModeDisplay();
	}

	public override void LoadCost()
	{
		CostGrid.debugPlacement = tradingState.itemType == ItemType.Water;
		_ = CostGrid.debugPlacement;
		base.LoadCost();
		costGridInput.Clear();
		if (CommonListItem.gm.isUsingExchangeTokens)
		{
			costGridInput.fixedSpacing = 48;
		}
		else
		{
			costGridInput.fixedSpacing = 0;
		}
		foreach (ItemRateData item in tradingState.input)
		{
			costGridInput.AddInput(item);
		}
		if (tradingState.activeTradeMode != TradeMode.Off)
		{
			costGridInput.gameObject.SetActive(value: true);
			costGridInput.AddSpacerArrow();
			costGridInput.craftArrowDelegate = OnRecipeClick;
		}
		else
		{
			costGridInput.gameObject.SetActive(value: false);
		}
		foreach (ItemRateData item2 in tradingState.output)
		{
			costGridInput.AddOutput(item2);
		}
		costGridInput.PerformLayout();
		if (CommonListItem.gm.isUsingExchangeTokens)
		{
			((RectTransform)costGridInput.transform).SetPosX(-420f);
		}
		else
		{
			((RectTransform)costGridInput.transform).SetPosX(-482f);
		}
		CostGrid.debugPlacement = false;
	}

	public void OnTradeModeChanged()
	{
		if (tradingState.CalcAppliedTradeMode() && tradingState.CalcActiveTradeMode())
		{
			tradingState.StoreItemStateCache();
			tradingState.PerformCalcSpeed();
		}
		if (tradingState.parentTown == GameManager.Instance.activeTown)
		{
			MenuManager.Instance.combinedProductionPanel.UpdateIfVisible(tradingState);
		}
	}

	public override void UpdateSimulationDisplay()
	{
		base.UpdateSimulationDisplay();
		if (tradingState != null)
		{
			costGridInput.UpdateDynamicAffordability();
			inventoryListItem.UpdateSimulationDisplay();
		}
	}

	public override void UpdateDynamicDisplay()
	{
		base.UpdateDynamicDisplay();
		if (tradingState != null && GameUtility.NotEquals(tradingState.numWorkersAssigned, lastDisplayedNumWorkers))
		{
			lastDisplayedNumWorkers = tradingState.numWorkersAssigned;
		}
	}

	public override void OnStateAssignmentChanged()
	{
		base.OnStateAssignmentChanged();
		tradeModeRegion.tradeTypeButton.AnimateInstant();
	}

	private void OnClickedWarehouse()
	{
		MenuManager.Instance.tooltipPanel.ShowWarehouse(tradingState.globalWarehouseState);
	}

	public void UpdateBuildingData()
	{
		UpdateStaticDisplay();
	}

	private void OnRecipeClick()
	{
		TryManuallyProduceFromCostGrid(costGridInput);
	}
}
