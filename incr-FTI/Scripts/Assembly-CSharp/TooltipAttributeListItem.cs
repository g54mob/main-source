using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TooltipAttributeListItem : MenuButton
{
	public Image backgroundImage;

	public Image iconImage;

	public TextMeshProUGUI keyLabel;

	public TextMeshProUGUI contribution;

	public TextMeshProUGUI potentialAmount;

	public TextMeshProUGUI actualAmount;

	public TextMeshProUGUI percentFulfilled;

	private ConsumableState displayedState;

	private ItemRateData displayedRateData;

	public ProgressBar fulfillmentProgress;

	public bool isTrading;

	public TooltipPanel parentPanel;

	public AttributeType displayType;

	private bool isTooltipInitialized;

	public MenuButton labelButton;

	public MenuButton contributionButton;

	public MenuButton potentialRateButton;

	public MenuButton actualRateButton;

	public MenuButton pctPotentialButton;

	public void Initialize()
	{
		AddPointerClickTrigger(OnClickedAttribute);
		if (null != labelButton)
		{
			labelButton.InitializeButton();
			labelButton.AddPointerClickTrigger(OnClickedHeaderLabel);
			labelButton.buttonState = CustomButtonState.Background;
		}
		if (null != contributionButton)
		{
			contributionButton.InitializeButton();
			contributionButton.AddPointerClickTrigger(OnClickedHeaderContribution);
			contributionButton.buttonState = CustomButtonState.Background;
		}
		if (null != potentialRateButton)
		{
			potentialRateButton.AddPointerClickTrigger(OnClickedHeaderPotential);
			potentialRateButton.InitializeButton();
			potentialRateButton.buttonState = CustomButtonState.Background;
		}
		if (null != actualRateButton)
		{
			actualRateButton.AddPointerClickTrigger(OnClickedHeaderActual);
			actualRateButton.InitializeButton();
			actualRateButton.buttonState = CustomButtonState.Background;
		}
		if (null != pctPotentialButton)
		{
			pctPotentialButton.AddPointerClickTrigger(OnClickedHeaderPctPotential);
			pctPotentialButton.InitializeButton();
			pctPotentialButton.buttonState = CustomButtonState.Background;
		}
		isTooltipInitialized = true;
		highlightTextDelegate = GetHighlightText;
	}

	private string GetHighlightText()
	{
		if (displayedRateData is PassiveStateModifier passiveStateModifier)
		{
			StringBuilder highlightTextBuilder = TextDisplay.highlightTextBuilder;
			highlightTextBuilder.Clear();
			highlightTextBuilder.AppendFormat(TextDisplay.LocalizedKeyValueFormat(), "BaselineSpeed".Localized(), TextDisplay.PerSecondRate(passiveStateModifier.baselineRate));
			TextDisplay.AppendModifiers(highlightTextBuilder, passiveStateModifier.productionModifiers);
			highlightTextBuilder.Append(TextDisplay.NewLine);
			highlightTextBuilder.AppendFormat(TextDisplay.KeyValueFormatSpaced, "Potential".Localized(), TextDisplay.PerSecondRate(passiveStateModifier.rate));
			return highlightTextBuilder.ToString();
		}
		if (displayedRateData != null && displayedRateData.parentState != null)
		{
			return TextDisplay.RateHighlightText(displayedRateData.parentState);
		}
		return null;
	}

	public void ResetState()
	{
		if (!isTooltipInitialized)
		{
			Initialize();
		}
		isTrading = false;
		backgroundImage.color = ColorManager.backgroundNormal;
		backgroundImage.raycastTarget = false;
		displayedState = null;
		displayedRateData = null;
		keyLabel.fontStyle = FontStyles.Normal;
		actualAmount.fontStyle = FontStyles.Normal;
		potentialAmount.fontStyle = FontStyles.Normal;
		contribution.fontStyle = FontStyles.Normal;
		keyLabel.text = string.Empty;
		actualAmount.text = string.Empty;
		percentFulfilled.text = string.Empty;
		potentialAmount.text = string.Empty;
		contribution.text = string.Empty;
		fulfillmentProgress.gameObject.SetActive(value: false);
		fulfillmentProgress.SetStale();
		backgroundImage.enabled = true;
		if (null != labelButton)
		{
			labelButton.stateImage.enabled = false;
		}
		if (null != potentialRateButton)
		{
			potentialRateButton.stateImage.enabled = false;
		}
		if (null != contributionButton)
		{
			contributionButton.stateImage.enabled = false;
		}
		if (null != actualRateButton)
		{
			actualRateButton.stateImage.enabled = false;
		}
		if (null != pctPotentialButton)
		{
			pctPotentialButton.stateImage.enabled = false;
		}
	}

	public void LoadEntity(EntityId id, bool prependEntityCategory)
	{
		displayedRateData = null;
		iconImage.enabled = true;
		SetIcon(IconManager.SpriteForEntity(id));
		if (prependEntityCategory)
		{
			keyLabel.text = TextDisplay.FormattedRewardEntityWithType(id);
		}
		else
		{
			keyLabel.text = TextDisplay.LabelForEntity(id);
		}
	}

	public void ConfigureRateChange(ConsumableState state)
	{
		backgroundImage.sprite = IconManager.Instance.buttonBackgroundTransparentOutline;
		backgroundImage.color = ColorManager.backgroundNormal;
		backgroundImage.raycastTarget = false;
		SetIcon(null);
		displayedState = state;
		displayType = AttributeType.Rate;
	}

	public void ConfigureProductionTotal(ConsumableState state)
	{
		backgroundImage.sprite = IconManager.Instance.buttonBackgroundTransparentOutline;
		backgroundImage.color = ColorManager.listItemBackground;
		backgroundImage.enabled = false;
		SetIcon(null);
		displayType = AttributeType.TotalProduction;
		displayedState = state;
		fulfillmentProgress.gameObject.SetActive(value: true);
	}

	public void ConfigureConsumptionTotal(ConsumableState state)
	{
		backgroundImage.sprite = IconManager.Instance.buttonBackgroundTransparentOutline;
		backgroundImage.color = ColorManager.listItemBackground;
		backgroundImage.enabled = false;
		SetIcon(null);
		displayType = AttributeType.TotalConsumption;
		displayedState = state;
		fulfillmentProgress.gameObject.SetActive(value: true);
	}

	public void ConfigureProductionHeader(ConsumableState state)
	{
		backgroundImage.sprite = IconManager.Instance.buttonBackgroundCombined;
		backgroundImage.color = ColorManager.productionTooltipHeader;
		backgroundImage.raycastTarget = true;
		displayType = AttributeType.ProductionHeader;
		contribution.fontStyle = FontStyles.Underline;
		potentialAmount.fontStyle = FontStyles.Underline;
		actualAmount.fontStyle = FontStyles.Underline;
		percentFulfilled.fontStyle = FontStyles.Underline;
		contribution.text = "Contribution".Localized();
		potentialAmount.text = "Potential".Localized();
		actualAmount.text = "Actual".Localized();
		percentFulfilled.text = "% " + "Potential".Localized();
		labelButton.stateImage.enabled = true;
		potentialRateButton.stateImage.enabled = true;
		contributionButton.stateImage.enabled = true;
		actualRateButton.stateImage.enabled = true;
		pctPotentialButton.stateImage.enabled = true;
		UpdateSortDisplay();
	}

	public void ConfigureConsumptionHeader(ConsumableState state)
	{
		backgroundImage.sprite = IconManager.Instance.buttonBackgroundCombined;
		backgroundImage.color = ColorManager.productionTooltipHeader;
		displayedRateData = null;
		backgroundImage.raycastTarget = true;
		displayType = AttributeType.ConsumptionHeader;
		contribution.fontStyle = FontStyles.Underline;
		potentialAmount.fontStyle = FontStyles.Underline;
		actualAmount.fontStyle = FontStyles.Underline;
		percentFulfilled.fontStyle = FontStyles.Underline;
		contribution.text = "Contribution".Localized();
		labelButton.stateImage.enabled = true;
		potentialRateButton.stateImage.enabled = true;
		contributionButton.stateImage.enabled = true;
		actualRateButton.stateImage.enabled = true;
		pctPotentialButton.stateImage.enabled = true;
		if (LocalizationManager.HasLocalizedValueForKey("Demand"))
		{
			potentialAmount.text = "Demand".Localized();
		}
		else
		{
			potentialAmount.text = "Potential".Localized();
		}
		if (LocalizationManager.HasLocalizedValueForKey("Supplied"))
		{
			actualAmount.text = "Supplied".Localized();
		}
		else
		{
			actualAmount.text = "Actual".Localized();
		}
		percentFulfilled.text = "% " + "Potential".Localized();
		UpdateSortDisplay();
	}

	private void SetIcon(Sprite s)
	{
		if (null == s)
		{
			iconImage.enabled = false;
			return;
		}
		iconImage.sprite = s;
		iconImage.enabled = true;
	}

	public void LoadData(ItemRateData d, AttributeType attributeType)
	{
		displayType = attributeType;
		backgroundImage.color = ColorManager.backgroundNormal;
		backgroundImage.raycastTarget = true;
		displayedRateData = d;
		iconImage.enabled = true;
		if (isTrading)
		{
			SetIcon(IconManager.SpriteForBiome(d.parentState.parentTown.biomeType));
		}
		else
		{
			SetIcon(PrimarySprite());
		}
		fulfillmentProgress.gameObject.SetActive(value: true);
		keyLabel.text = GetLabel(d, attributeType);
	}

	public static string GetLabel(ItemRateData d, AttributeType attributeType)
	{
		if (d is PassiveStateModifier passiveStateModifier)
		{
			if (passiveStateModifier.tooltipEntity.type != EntityType.None)
			{
				return TextDisplay.LabelForEntity(passiveStateModifier.tooltipEntity);
			}
			if (d.parentState == null)
			{
				if (attributeType == AttributeType.Consumption)
				{
					return "Decay".Localized();
				}
				return "ResourceRegen".Localized();
			}
			return TextDisplay.LabelForEntity(d.parentState.AsEntity());
		}
		if (d is BuildingRateData buildingRateData)
		{
			return TextDisplay.LabelForBuilding(buildingRateData.buildingType);
		}
		if (d.state.parentTown == null && d.parentState.parentTown != null)
		{
			return d.parentState.parentTown.townName;
		}
		if (d.parentState is SellState { producingBuilding: not null } sellState)
		{
			return TextDisplay.FormattedKeyValue("Markets", TextDisplay.LabelForEntity(sellState.producingBuilding.AsEntity()));
		}
		if (d.parentState is ResearchState)
		{
			return TextDisplay.FormattedKeyValue("Research", TextDisplay.LabelForEntity(d.parentState.AsEntity()));
		}
		if (d.parentState is ConstructionState constructionState)
		{
			return TextDisplay.FormattedKeyValue("Construction", TextDisplay.LabelForBuilding(constructionState.parentBuildingState.type));
		}
		if (d.parentState is RecipeState recipeState)
		{
			if (attributeType == AttributeType.Production && recipeState.producingBuilding != null)
			{
				return string.Format(TextDisplay.KeyValueFormatSpaced, TextDisplay.LabelForBuilding(recipeState.producingBuilding.type), TextDisplay.LabelForEntity(recipeState.AsEntity()));
			}
			if (attributeType == AttributeType.Consumption && recipeState.producingBuilding != null)
			{
				return string.Format(TextDisplay.KeyValueFormatSpaced, TextDisplay.LabelForBuilding(recipeState.producingBuilding.type), TextDisplay.LabelForEntity(recipeState.AsEntity()));
			}
		}
		if (d.parentState?.producingBuilding != null)
		{
			return TextDisplay.LabelForBuilding(d.parentState.producingBuilding.type);
		}
		if (d.parentState is TradingState)
		{
			switch (attributeType)
			{
			case AttributeType.Production:
				return "Imports".Localized();
			case AttributeType.Consumption:
				return "Exports".Localized();
			}
		}
		else if (d.parentState is AutoHarvestState autoHarvestState)
		{
			return TextDisplay.LabelForBuilding(autoHarvestState.building.type);
		}
		return "???";
	}

	private void OnClickedHeaderLabel()
	{
		parentPanel.OnLabelSortClicked();
	}

	private void OnClickedHeaderContribution()
	{
		parentPanel.OnContributionSortClicked();
	}

	private void OnClickedHeaderPotential()
	{
		parentPanel.OnPotentialSortClicked();
	}

	private void OnClickedHeaderActual()
	{
		parentPanel.OnActualSortClicked();
	}

	private void OnClickedHeaderPctPotential()
	{
		parentPanel.OnPercentPotentialSortClicked();
	}

	private void OnClickedAttribute()
	{
		if (displayType == AttributeType.ConsumptionHeader)
		{
			parentPanel.OnConsumptionClicked();
		}
		else if (displayType == AttributeType.ProductionHeader)
		{
			parentPanel.OnProductionClicked();
		}
		else if (displayedRateData != null)
		{
			if (displayedRateData is BuildingRateData buildingRateData)
			{
				MenuManager.Instance.combinedProductionPanel.TrySetRootFromBuilding(buildingRateData.buildingType);
			}
			else
			{
				MenuManager.Instance.JumpToState(displayedRateData.parentState);
			}
			MenuManager.Instance.tooltipPanel.ManuallyClose();
		}
	}

	private Sprite PrimarySprite()
	{
		if (displayedRateData == null)
		{
			return null;
		}
		if (displayedRateData is BuildingRateData buildingRateData)
		{
			return IconManager.SpriteForBuilding(buildingRateData.buildingType);
		}
		if (displayType == AttributeType.Consumption)
		{
			if (displayedRateData.parentState?.producingBuilding != null)
			{
				return IconManager.SpriteForBuilding(displayedRateData.parentState.producingBuilding.type);
			}
			if (displayedRateData.parentState is AutoHarvestState autoHarvestState)
			{
				return IconManager.SpriteForBuilding(autoHarvestState.building.type);
			}
			if (displayedRateData.parentState != null)
			{
				using List<ItemRateData>.Enumerator enumerator = displayedRateData.parentState.output.GetEnumerator();
				if (enumerator.MoveNext())
				{
					return IconManager.SpriteForEntity(enumerator.Current.state.AsEntity());
				}
			}
			if (displayedRateData is PassiveStateModifier passiveStateModifier)
			{
				if (passiveStateModifier.tooltipEntity.type != EntityType.None)
				{
					return IconManager.SpriteForEntity(passiveStateModifier.tooltipEntity);
				}
				return IconManager.Instance.resourceRegen;
			}
		}
		else
		{
			if (displayedRateData is PassiveStateModifier passiveStateModifier2)
			{
				if (passiveStateModifier2.tooltipEntity.type != EntityType.None)
				{
					return IconManager.SpriteForEntity(passiveStateModifier2.tooltipEntity);
				}
				return IconManager.Instance.resourceRegen;
			}
			if (displayedRateData.parentState == null)
			{
				return null;
			}
			if (displayedRateData.parentState.producingBuilding != null)
			{
				return IconManager.SpriteForBuilding(displayedRateData.parentState.producingBuilding.type);
			}
			using List<ItemRateData>.Enumerator enumerator = displayedRateData.parentState.input.GetEnumerator();
			if (enumerator.MoveNext())
			{
				return IconManager.SpriteForEntity(enumerator.Current.state.AsEntity());
			}
		}
		if (displayedRateData.parentState == null)
		{
			return null;
		}
		return IconManager.SpriteForEntity(displayedRateData.parentState.AsEntity());
	}

	public void UpdateSimulationDisplay()
	{
		if (GameUtility.IsNearlyZero(TimeManager.SimulationDelta))
		{
			contribution.text = "-";
			potentialAmount.text = "-";
			actualAmount.text = "-";
			percentFulfilled.text = "-";
			fulfillmentProgress.slider.value = 0f;
		}
		else if (displayType == AttributeType.Rate)
		{
			if (displayedState != null)
			{
				TextDisplay.FormatInventoryChangeRate(percentFulfilled, displayedState);
				switch (displayedState.CurrentStateIndicator())
				{
				case StateIndicator.GrowingOrFull:
					actualAmount.text = "Surplus".Localized();
					break;
				case StateIndicator.Neutral:
					actualAmount.text = "Neutral".Localized();
					break;
				case StateIndicator.Decreasing:
					actualAmount.text = "Deficit".Localized();
					break;
				case StateIndicator.Starved:
					actualAmount.text = "Deficit".Localized();
					break;
				}
			}
		}
		else if (displayType == AttributeType.TotalProduction)
		{
			if (displayedState == null)
			{
				return;
			}
			double num = 0.0;
			foreach (ItemRateData outputRequester in displayedState.outputRequesters)
			{
				outputRequester.CalcDisplayedRates();
				num += outputRequester.displayedPotentialRate;
			}
			contribution.text = string.Empty;
			double value = displayedState.frameAdded / (double)TimeManager.SimulationDelta;
			TextDisplay.SetRate(potentialAmount, num, signed: false);
			TextDisplay.SetRate(actualAmount, value, signed: false);
			fulfillmentProgress.gameObject.SetActive(value: false);
		}
		else if (displayType == AttributeType.TotalConsumption)
		{
			contribution.text = string.Empty;
			if (displayedState == null)
			{
				return;
			}
			double num2 = 0.0;
			foreach (ItemRateData inputRequester in displayedState.inputRequesters)
			{
				inputRequester.CalcDisplayedRates();
				num2 += inputRequester.effectiveDemandRate;
			}
			double frameSubtracted = displayedState.frameSubtracted;
			TextDisplay.SetRate(potentialAmount, num2, signed: false);
			TextDisplay.SetRate(actualAmount, frameSubtracted / (double)TimeManager.SimulationDelta, signed: false);
			fulfillmentProgress.gameObject.SetActive(value: false);
		}
		else
		{
			if (displayedRateData == null)
			{
				return;
			}
			if (!(displayedRateData is BuildingRateData))
			{
				displayedRateData.CalcDisplayedRates();
			}
			double num3 = Math.Abs(displayedRateData.actualFrameDelta / (double)TimeManager.SimulationDelta);
			double num4 = ((displayType == AttributeType.Production) ? displayedRateData.displayedPotentialRate : displayedRateData.effectiveDemandRate);
			if (GameUtility.IsNearlyZero(num4))
			{
				contribution.text = TextDisplay.Percent(0f);
				TextDisplay.SetRate(potentialAmount, 0.0, signed: false);
				TextDisplay.SetRate(actualAmount, 0.0, signed: false);
				percentFulfilled.text = "-";
				fulfillmentProgress.slider.value = 0f;
				return;
			}
			TextDisplay.SetRate(potentialAmount, num4, signed: false);
			TextDisplay.SetRate(actualAmount, num3, signed: false);
			float value2 = ((displayType == AttributeType.Production) ? displayedRateData.displayedPercentPotential : GameUtility.AsTruncatedFloat(num3 / num4));
			TextDisplay.SetPercent(percentFulfilled, value2);
			if (displayType == AttributeType.Production)
			{
				float num5 = GameUtility.AsFloat(displayedRateData.state.frameAdded / (double)TimeManager.SimulationDelta);
				if (GameUtility.IsNotZero(num5))
				{
					TextDisplay.SetPercent(contribution, GameUtility.AsFloat(num3 / (double)num5));
				}
				else
				{
					contribution.text = "-";
				}
			}
			else
			{
				double num6 = displayedRateData.state.frameSubtracted / (double)TimeManager.SimulationDelta;
				if (GameUtility.IsNotZero(num6))
				{
					TextDisplay.SetPercent(contribution, GameUtility.AsFloat(num3 / num6));
				}
				else
				{
					contribution.text = "-";
				}
			}
			fulfillmentProgress.slider.value = value2;
		}
	}

	public void UpdateSortDisplay()
	{
		labelButton.isSelected = parentPanel.sortColumn == SortColumn.Label;
		contributionButton.isSelected = parentPanel.sortColumn == SortColumn.Contribution;
		potentialRateButton.isSelected = parentPanel.sortColumn == SortColumn.Potential;
		actualRateButton.isSelected = parentPanel.sortColumn == SortColumn.Actual;
		pctPotentialButton.isSelected = parentPanel.sortColumn == SortColumn.PercentPotential;
	}
}
