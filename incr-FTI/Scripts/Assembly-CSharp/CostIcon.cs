using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CostIcon : MenuButton
{
	public TextMeshProUGUI label;

	public Image iconImage;

	public Image backgroundImage;

	private ItemRateData itemRateData;

	private CountableState itemState;

	private AffordabilityState lastAffordabilityState;

	private double amount;

	public ProgressBar progressBar;

	[NonSerialized]
	public double displayedAmount = double.MaxValue;

	[NonSerialized]
	public int tooltipLevel;

	[NonSerialized]
	public bool useProductionRatio;

	private const bool matchInventoryDisplay = true;

	private bool hasInitialized;

	[NonSerialized]
	public bool showGuideWhenClicked;

	private bool isCapacityInfinite;

	public void LoadItemRate(ItemRateData d)
	{
		itemRateData = d;
		LoadCost(d.state, d.totalAmount);
		tooltipEntity = d.state.AsEntity();
		isCapacityInfinite = d.state.isOutputCapacityInfinite;
		if (d.parentState is TradingState && d.state.parentTown == null)
		{
			iconImage.sprite = IconManager.SpriteForTradingPostItem(d.state);
			tooltipModifier = TooltipModifier.GlobalStorage;
		}
		else
		{
			tooltipModifier = TooltipModifier.None;
		}
		if (null != progressBar)
		{
			if (d.IsCurrency())
			{
				progressBar.gameObject.SetActive(value: false);
			}
			else
			{
				progressBar.gameObject.SetActive(value: true);
			}
		}
	}

	public void LoadStaticCost(CountableState state, double v)
	{
		itemRateData = null;
		LoadCost(state, v);
	}

	private void LoadCost(CountableState state, double v)
	{
		itemState = state;
		tooltipModifier = TooltipModifier.None;
		iconImage.sprite = IconManager.SpriteForState(state);
		isCapacityInfinite = itemState is ConsumableState consumableState && consumableState.isOutputCapacityInfinite;
		_ = CostGrid.costGridDebug;
		label.text = TextDisplay.LocalizedNumber(v);
		tooltipEntity = state.AsEntity();
		amount = v;
		displayedAmount = v;
	}

	private void Initialize()
	{
		hasInitialized = true;
		AddPointerDownTrigger(OnClickedCost);
		AddRightClickTrigger(OnRightClickedCost);
	}

	public void ResetState()
	{
		if (!hasInitialized)
		{
			Initialize();
		}
		if (!isInitialized)
		{
			InitializeButton();
		}
		lastAffordabilityState = AffordabilityState.None;
		label.enabled = true;
		iconImage.color = Color.white;
	}

	private void OnClickedCost()
	{
		if (showGuideWhenClicked)
		{
			MenuManager.Instance.tooltipPanel.ToggleEntityDescriptionState(tooltipEntity);
			return;
		}
		if (itemRateData.state.isLocked)
		{
			MenuManager.Instance.tooltipPanel.ToggleEntityDescriptionState(tooltipEntity);
			return;
		}
		if (itemRateData?.parentState != null)
		{
			MenuManager.Instance.TryAddToNavigationStack(itemRateData.parentState.AsEntity());
		}
		MenuManager.Instance.NavigateToCountableState(itemState);
	}

	private void OnRightClickedCost()
	{
		if (MenuManager.Instance.popupMenu.IsVisible() || tooltipModifier == TooltipModifier.GlobalStorage)
		{
			return;
		}
		PopupMenu popupMenu = MenuManager.Instance.ShowPopupMenu((RectTransform)base.transform);
		popupMenu.AddNavigationButton(TextDisplay.LabelForEntity(this.itemState.AsEntity()), this.itemState, OnAltNavigationSelected);
		if (this.itemState is ItemState itemState)
		{
			foreach (HarvestState value5 in this.itemState.parentTown.harvesting.Values)
			{
				if (!value5.isLocked && value5.def.harvestedItemType == itemState.type)
				{
					popupMenu.AddNavigationButton("Harvesting".Localized(), value5, OnAltNavigationSelected);
					break;
				}
			}
			foreach (RecipeState value6 in this.itemState.parentTown.recipes.Values)
			{
				if (value6.isLocked)
				{
					continue;
				}
				foreach (KeyValuePair<ItemType, double> item in value6.recipe.outputs.items)
				{
					if (item.Key == itemState.type)
					{
						popupMenu.AddNavigationButton(TextDisplay.LabelForRecipeType(value6.type), value6, OnAltNavigationSelected);
						break;
					}
				}
				foreach (KeyValuePair<ItemType, double> item2 in value6.recipe.inputs.items)
				{
					if (item2.Key == itemState.type)
					{
						popupMenu.AddNavigationButton(TextDisplay.LabelForRecipeType(value6.type), value6, OnAltNavigationSelected);
						break;
					}
				}
			}
			if (this.itemState.parentTown.marketItems.TryGetValue(itemState.type, out var value) && !value.isLocked)
			{
				popupMenu.AddNavigationButton("Markets".Localized(), value, OnAltNavigationSelected);
			}
			if (this.itemState.parentTown.trading.TryGetValue(itemState.type, out var value2) && !value2.isLocked)
			{
				popupMenu.AddNavigationButton("Trading".Localized(), value2, OnAltNavigationSelected);
			}
		}
		else if (this.itemState is ResourceState resourceState)
		{
			popupMenu.AddNavigationButton("MenuPanelClicker".Localized(), MenuPanelType.Clickables, OnAltNavigationSelected);
			foreach (HarvestState value7 in this.itemState.parentTown.harvesting.Values)
			{
				if (!value7.isLocked && value7.def.resourceType == resourceState.type)
				{
					popupMenu.AddNavigationButton(TextDisplay.LabelForBuilding(value7.def.producingBuildingType), value7, OnAltNavigationSelected);
				}
			}
			if (this.itemState.parentTown.farmingItems.TryGetValue(resourceState.type, out var value3) && !value3.isLocked)
			{
				popupMenu.AddNavigationButton("Cultivation".Localized(), value3, OnAltNavigationSelected);
			}
			if (this.itemState.parentTown.miningItems.TryGetValue(resourceState.type, out var value4) && !value4.isLocked)
			{
				popupMenu.AddNavigationButton("Prospecting".Localized(), value4, OnAltNavigationSelected);
			}
		}
		if (popupMenu.HasRows())
		{
			popupMenu.ResizeHeight(15);
		}
		else
		{
			popupMenu.Hide();
		}
	}

	public void OnAltNavigationSelected(PopupMenuItem sender)
	{
		MenuPanel value;
		if (sender.loadedObject is StateManager state)
		{
			MenuManager.Instance.ApplyStateManagerFilter(state);
		}
		else if (sender.loadedObject is ConsumableState)
		{
			TooltipPanel tooltipPanel = MenuManager.Instance.tooltipPanel;
			tooltipPanel.LoadEntityDescription(tooltipEntity);
			tooltipPanel.Pin();
			tooltipPanel.Show();
		}
		else if (sender.loadedObject is MenuPanelType key && MenuManager.Instance.menuPanels.TryGetValue(key, out value))
		{
			value.ManuallyOpen();
		}
		MenuManager.Instance.popupMenu.Hide();
	}

	public void UpdateSliderColorFromInventoryDelta()
	{
		if (null != progressBar)
		{
			if (itemRateData != null)
			{
				progressBar.fillImage.color = itemRateData.state.FillColor();
			}
			else if (itemState != null)
			{
				progressBar.fillImage.color = Color.magenta;
			}
		}
	}

	public void UpdateDynamicCapacity()
	{
		AffordabilityState affordabilityState = AffordabilityState.None;
		if (itemRateData != null)
		{
			affordabilityState = itemRateData.displayedAffordabilityState;
		}
		else if (itemState is ConsumableState consumableState)
		{
			affordabilityState = ((!consumableState.frameIsLimitingInput && !consumableState.frameIsLimitingOutput) ? AffordabilityState.CanFullyProduce : AffordabilityState.CanPartiallyProduce);
		}
		lastAffordabilityState = affordabilityState;
		switch (affordabilityState)
		{
		case AffordabilityState.CanNotProduce:
			label.color = ColorManager.outputFull;
			break;
		case AffordabilityState.CanPartiallyProduce:
			label.color = Color.white;
			break;
		default:
			label.color = Color.white;
			break;
		}
		if (null != progressBar)
		{
			if (itemRateData != null)
			{
				progressBar.fillImage.color = itemRateData.state.FillColor();
			}
			else if (itemRateData != null && GameUtility.IsNearlyZero(itemRateData.framePotentialAmount))
			{
				progressBar.fillImage.color = ColorManager.recipeNotActive;
			}
			else if (lastAffordabilityState == AffordabilityState.CanNotProduce)
			{
				progressBar.fillImage.color = ColorManager.outputFull;
			}
			else
			{
				switch (affordabilityState)
				{
				case AffordabilityState.CanPartiallyProduce:
					progressBar.fillImage.color = ColorManager.outputSlowed;
					break;
				case AffordabilityState.None:
					progressBar.fillImage.color = ColorManager.processingNormal;
					break;
				default:
					if (useProductionRatio)
					{
						progressBar.fillImage.color = ColorManager.processingNormal;
					}
					else
					{
						progressBar.fillImage.color = ColorManager.outputNormal;
					}
					break;
				}
			}
		}
		if (!(null != progressBar))
		{
			return;
		}
		if (itemRateData != null)
		{
			if (isCapacityInfinite)
			{
				progressBar.slider.value = ((itemRateData.state.currentCount > 0.0) ? 1f : 0f);
				return;
			}
			float value = (float)(itemRateData.state.currentCount / itemRateData.state.maxCount);
			progressBar.slider.value = value;
		}
		else if (itemState != null)
		{
			if (isCapacityInfinite)
			{
				progressBar.slider.value = ((itemState.currentCount > 0.0) ? 1f : 0f);
				return;
			}
			float value2 = GameUtility.AsFloat(itemState.currentCount / itemState.maxCount);
			progressBar.slider.value = value2;
		}
	}

	public bool IsDynamic()
	{
		return itemRateData != null;
	}

	public void UpdateSliderFillFromCapacity()
	{
		if (itemRateData != null)
		{
			if (isCapacityInfinite)
			{
				progressBar.slider.value = ((itemRateData.state.currentCount > 0.0) ? 1f : 0f);
				return;
			}
			float value = GameUtility.AsFloat(itemRateData.state.currentCount / itemRateData.state.maxCount);
			value = Mathf.Clamp(value, 0.05f, 1f);
			progressBar.slider.value = value;
		}
		else if (itemState != null)
		{
			if (isCapacityInfinite)
			{
				progressBar.slider.value = ((itemState.currentCount > 0.0) ? 1f : 0f);
				return;
			}
			float value2 = GameUtility.AsFloat(itemState.currentCount / itemState.maxCount);
			progressBar.slider.value = value2;
		}
	}

	public void UpdateSliderColorFromInputAffordability()
	{
		if (itemRateData == null)
		{
			return;
		}
		AffordabilityState displayedAffordabilityState = itemRateData.displayedAffordabilityState;
		if (GameUtility.IsNearlyZero(itemRateData.framePotentialAmount))
		{
			progressBar.fillImage.color = ColorManager.recipeNotActive;
			return;
		}
		if (lastAffordabilityState == AffordabilityState.CanNotProduce)
		{
			progressBar.fillImage.color = ColorManager.inputStarved;
			return;
		}
		switch (displayedAffordabilityState)
		{
		case AffordabilityState.CanPartiallyProduce:
			progressBar.fillImage.color = ColorManager.inputSlowed;
			break;
		case AffordabilityState.None:
			progressBar.fillImage.color = ColorManager.processingNormal;
			break;
		default:
			progressBar.fillImage.color = ColorManager.processingNormal;
			break;
		}
	}

	public void UpdateLabelColorFromStateIndicator()
	{
		if (itemRateData != null)
		{
			if (itemRateData.state.currentCount <= 0.0 && itemRateData.state.lastFrameDemand <= 0.0)
			{
				label.color = ColorManager.negativeRateFill;
				return;
			}
			if (itemRateData.state.hasUnlimitedCapacity)
			{
				UpdateLabelColorFromInputAffordability();
				return;
			}
			switch (itemRateData.state.CurrentStateIndicator())
			{
			case StateIndicator.Neutral:
				label.color = Color.white;
				break;
			case StateIndicator.GrowingOrFull:
				label.color = Color.white;
				break;
			case StateIndicator.Decreasing:
				label.color = ColorManager.inventoryDecrease;
				break;
			case StateIndicator.Starved:
				label.color = ColorManager.negativeRateFill;
				break;
			default:
				label.color = Color.white;
				break;
			}
		}
		else
		{
			label.color = Color.white;
		}
	}

	public void UpdateLabelColorFromInputAffordability()
	{
		if (itemRateData != null)
		{
			AffordabilityState affordabilityState = (lastAffordabilityState = itemRateData.displayedAffordabilityState);
			if (affordabilityState == AffordabilityState.CanNotProduce || affordabilityState == AffordabilityState.CanPartiallyProduce)
			{
				label.color = ColorManager.inputStarved;
			}
			else if (itemRateData.state.showDecreaseWarning)
			{
				label.color = ColorManager.inventoryDecrease;
			}
			else
			{
				label.color = Color.white;
			}
		}
		else
		{
			Debug.LogError("Was using GetDynamicAffordabilityState");
		}
	}

	public void UpdateSinglePurchaseAffordability()
	{
		AffordabilityState affordabilityState = AffordabilityState.CanNotProduce;
		double num = itemState.currentCount;
		if (itemState is CollectibleState collectibleState && (collectibleState.type == ItemType.UtilityQuestCoin || collectibleState.type == ItemType.UtilityPrestigePoint))
		{
			num = itemState.numAvailable;
		}
		else if (itemState is WorkerState workerState)
		{
			num = workerState.numAvailable;
		}
		if (num >= amount)
		{
			affordabilityState = AffordabilityState.CanFullyProduce;
		}
		if (affordabilityState != lastAffordabilityState)
		{
			lastAffordabilityState = affordabilityState;
			if (affordabilityState == AffordabilityState.CanNotProduce)
			{
				label.color = ColorManager.inputStarved;
			}
			else
			{
				label.color = Color.white;
			}
		}
		if (null != progressBar)
		{
			if (GameUtility.IsNearlyZero(amount))
			{
				progressBar.slider.value = 1f;
			}
			else
			{
				float value = GameUtility.AsFloat(num / amount);
				progressBar.slider.value = value;
			}
			if (affordabilityState == AffordabilityState.CanNotProduce)
			{
				progressBar.fillImage.color = ColorManager.inputStarved;
			}
			else
			{
				progressBar.fillImage.color = ColorManager.processingNormal;
			}
		}
	}
}
