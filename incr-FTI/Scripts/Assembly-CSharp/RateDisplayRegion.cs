using System;
using TMPro;
using UnityEngine;

public class RateDisplayRegion : MenuButton
{
	private float lastDisplayedRate = float.MinValue;

	private float lastDisplayedPercent = float.MinValue;

	private float lastDisplayedWorkers = float.MinValue;

	public TextMeshProUGUI rateLabel;

	public TextMeshProUGUI percentRate;

	public StateManager state;

	[NonSerialized]
	public RateDisplayMode rateDisplayMode;

	[NonSerialized]
	public RatioDisplayMode ratioDisplayMode;

	[NonSerialized]
	public IconDisplayMode iconDisplayMode;

	[NonSerialized]
	public bool forceRefresh;

	private OverrideState lastDisplayedPause;

	private TradeMode lastDisplayedTradeMode;

	private RateDisplayMode displayedRateMode;

	private RatioDisplayMode displayedRatioMode;

	public ProgressButton progressButton;

	private bool skipAutoFormat;

	[NonSerialized]
	public bool debug;

	public void Initialize(bool embedded = false)
	{
		if (null != progressButton)
		{
			progressButton.InitializeButton();
			progressButton.buttonSoundType = ButtonSoundType.HeavyClick;
			progressButton.buttonState = CustomButtonState.Background;
			skipAutoFormat = true;
		}
	}

	public void ResetDisplay()
	{
		lastDisplayedRate = float.MinValue;
	}

	public void UpdateSimulationDisplay()
	{
		StateManager stateManager = state;
		forceRefresh |= !GameUtility.NearlyEquals(lastDisplayedWorkers, stateManager.numWorkersAssigned);
		forceRefresh |= lastDisplayedPause != stateManager.appliedPauseState;
		TradeMode tradeMode = TradeMode.None;
		if (stateManager is TradingState tradingState)
		{
			tradeMode = tradingState.activeTradeMode;
		}
		forceRefresh |= lastDisplayedTradeMode != tradeMode;
		if (rateDisplayMode != displayedRateMode || ratioDisplayMode != displayedRatioMode)
		{
			UpdateRateDisplayMode();
		}
		if (null != rateLabel)
		{
			if (rateDisplayMode == RateDisplayMode.RecipeRate)
			{
				TryDisplayRate(stateManager.displayedRecipeUnitRate);
			}
			else if (rateDisplayMode == RateDisplayMode.OutputRate)
			{
				TryDisplayRate(stateManager.displayedOutputRate);
			}
			else if (rateDisplayMode == RateDisplayMode.TimeRemaining)
			{
				TryDisplayTime(stateManager);
			}
			else
			{
				rateLabel.SetText("");
			}
		}
		if (null != percentRate && percentRate.gameObject.activeInHierarchy)
		{
			double num = 0.0;
			if (ratioDisplayMode == RatioDisplayMode.RelativeToBaseline)
			{
				float displayedRecipeUnitRate = stateManager.displayedRecipeUnitRate;
				double recipeUnitsPerWorkUnit = stateManager.recipeUnitsPerWorkUnit;
				if (recipeUnitsPerWorkUnit > 0.0)
				{
					num = (double)displayedRecipeUnitRate / recipeUnitsPerWorkUnit;
				}
			}
			else
			{
				_ = stateManager.recipeDebug;
				if (ratioDisplayMode == RatioDisplayMode.InputRatio)
				{
					num = stateManager.inputSupplyRatio;
				}
				else if (ratioDisplayMode == RatioDisplayMode.RecipeRatio)
				{
					num = stateManager.displayedProductionRatio;
				}
			}
			if (!GameUtility.NearlyEquals(lastDisplayedPercent, num) || forceRefresh)
			{
				if (stateManager.activePauseState)
				{
					percentRate.text = string.Empty;
				}
				else if (stateManager is TradingState && tradeMode == TradeMode.Off)
				{
					percentRate.text = string.Empty;
				}
				else if (GameUtility.IsNearlyZero(num) && GameUtility.IsNearlyZero(stateManager.numWorkersAssigned))
				{
					percentRate.SetText("");
				}
				else if (GameUtility.IsNearlyZero(num) && stateManager.outputCapacityState == AffordabilityState.CanNotProduce)
				{
					percentRate.text = "Full".Localized();
				}
				else
				{
					TextDisplay.SetPercent(percentRate, GameUtility.AsTruncatedFloat(num));
				}
				if (null != progressButton)
				{
					percentRate.color = Color.white;
					UpdateFillColorFromRatio();
					if (state.inputAffordabilityState == AffordabilityState.CanNotProduce || state.inputAffordabilityState == AffordabilityState.CanPartiallyProduce)
					{
						Color color = Color.Lerp(progressButton.progressFill.color, Color.white, 0.5f);
						percentRate.color = color;
					}
					else
					{
						percentRate.color = Color.white;
					}
				}
				else
				{
					UpdateLabelColorLocal(percentRate, stateManager, ratioDisplayMode);
				}
			}
			lastDisplayedWorkers = stateManager.numWorkersAssigned;
			lastDisplayedPercent = GameUtility.AsTruncatedFloat(num);
		}
		lastDisplayedPause = stateManager.appliedPauseState;
		lastDisplayedTradeMode = tradeMode;
		forceRefresh = false;
	}

	public void UpdateDynamicDisplay()
	{
		if (null != progressButton)
		{
			progressButton.UpdateDynamicDisplay();
		}
	}

	private void UpdateRateDisplayMode()
	{
		displayedRateMode = rateDisplayMode;
		displayedRatioMode = ratioDisplayMode;
		SetLabelVisible(rateLabel, rateDisplayMode != RateDisplayMode.Off);
		SetLabelVisible(percentRate, ratioDisplayMode != RatioDisplayMode.Off);
		_ = skipAutoFormat;
	}

	private static void OffsetLabel(TextMeshProUGUI label, bool isTop)
	{
		if (null != label)
		{
			CenterLabel(label);
			label.rectTransform.SetPosY(isTop ? 10f : (-10f));
		}
	}

	private static void CenterLabel(TextMeshProUGUI label)
	{
		if (null != label)
		{
			label.gameObject.SetActive(value: true);
			RectTransform rectTransform = label.rectTransform;
			rectTransform.anchorMin = new Vector2(0f, 0.5f);
			rectTransform.anchorMax = new Vector2(1f, 0.5f);
			rectTransform.SetPosY(0f);
		}
	}

	private static void SetLabelVisible(TextMeshProUGUI label, bool nextState)
	{
		if (null != label)
		{
			label.gameObject.SetActive(nextState);
		}
	}

	private static void UpdateLabelColorLocal(TextMeshProUGUI label, StateManager sm, RateDisplayMode mode)
	{
		if (GameUtility.IsNearlyZero(sm.numWorkersAssigned))
		{
			label.color = Color.white;
		}
		else if (mode == RateDisplayMode.OutputRate)
		{
			UpdateLabelColorOutput(label, sm.outputCapacityState);
		}
		else
		{
			DeriveLabelColor(label, sm);
		}
	}

	private static void UpdateLabelColorLocal(TextMeshProUGUI label, StateManager sm, RatioDisplayMode mode)
	{
		if (GameUtility.IsNearlyZero(sm.numWorkersAssigned))
		{
			label.color = Color.white;
		}
		else if (mode == RatioDisplayMode.InputRatio)
		{
			UpdateLabelColorInput(label, sm.inputAffordabilityState);
		}
		else
		{
			DeriveLabelColor(label, sm);
		}
	}

	private void TryDisplayTime(StateManager sm)
	{
		if (sm.activePauseState)
		{
			rateLabel.text = string.Empty;
			return;
		}
		if (sm is TradingState { activeTradeMode: TradeMode.Off })
		{
			rateLabel.text = string.Empty;
			return;
		}
		if (sm.unitProgress >= 1.0)
		{
			rateLabel.SetText("");
			return;
		}
		float displayedRecipeUnitRate = sm.displayedRecipeUnitRate;
		float num = 0f;
		if (sm is ConstructionState && sm.numWorkersAssigned <= 0f)
		{
			rateLabel.text = string.Empty;
			return;
		}
		if (sm.numWorkersAssigned <= 0f && sm.recipeUnitsPerWorkUnit > 0.0)
		{
			num = GameUtility.AsTruncatedFloat(1.0 / sm.recipeUnitsPerWorkUnit * (double)(1f - GameUtility.AsFloat(sm.unitProgress)));
			num = Mathf.Ceil(num);
		}
		else if (displayedRecipeUnitRate > 1E-07f)
		{
			num = 1f / displayedRecipeUnitRate * (1f - GameUtility.AsFloat(sm.unitProgress));
			num = Mathf.Ceil(num);
		}
		else
		{
			_ = 0f;
		}
		if (GameUtility.NearlyEquals(num, lastDisplayedRate) && !forceRefresh)
		{
			return;
		}
		lastDisplayedRate = num;
		if (num > 0f)
		{
			try
			{
				rateLabel.text = TextDisplay.FormattedHoursMinutesSeconds(num);
				return;
			}
			catch (Exception)
			{
				rateLabel.SetText("");
				return;
			}
		}
		if (sm.numWorkersAssigned > 0f)
		{
			rateLabel.SetText("-");
		}
		else if (sm is ResearchState && sm.recipeUnitsPerWorkUnit > 0.0)
		{
			double value = Math.Ceiling(1.0 / sm.recipeUnitsPerWorkUnit * (1.0 - sm.unitProgress));
			rateLabel.text = TextDisplay.FormattedHoursMinutesSeconds(GameUtility.AsFloat(value));
		}
		else
		{
			rateLabel.SetText("");
		}
	}

	private void TryDisplayRate(float rate)
	{
		if (GameUtility.NearlyEquals(lastDisplayedRate, rate) && !forceRefresh)
		{
			return;
		}
		if (state.activePauseState)
		{
			rateLabel.text = string.Empty;
		}
		else if (state is TradingState { activeTradeMode: TradeMode.Off })
		{
			rateLabel.text = string.Empty;
		}
		else if (GameUtility.IsNearlyZero(rate) && GameUtility.IsNearlyZero(state.numWorkersAssigned))
		{
			rateLabel.SetText("");
		}
		else
		{
			_ = state.recipeDebug;
			if (state is ResearchState)
			{
				TextDisplay.SetRate(rateLabel, rate * 100f);
			}
			else
			{
				TextDisplay.SetRate(rateLabel, rate);
			}
		}
		if (null != progressButton)
		{
			rateLabel.color = Color.white;
		}
		else
		{
			UpdateLabelColorLocal(rateLabel, state, rateDisplayMode);
		}
		lastDisplayedRate = rate;
	}

	private void UpdateFillColorFromRatio()
	{
		if (state.outputCapacityState == AffordabilityState.CanNotProduce)
		{
			progressButton.progressFill.color = ColorManager.progressBarSatisfied;
		}
		else if (state.inputAffordabilityState == AffordabilityState.CanNotProduce)
		{
			progressButton.progressFill.color = ColorManager.inputStarved;
		}
		else if (state.rateCapacityState == AffordabilityState.CanNotProduce)
		{
			progressButton.progressFill.color = Color.white;
		}
		else if (state.outputCapacityState == AffordabilityState.CanPartiallyProduce)
		{
			progressButton.progressFill.color = ColorManager.progressBarSatisfied;
		}
		else if (state.inputAffordabilityState == AffordabilityState.CanPartiallyProduce)
		{
			progressButton.progressFill.color = ColorManager.progressBarInputSlowed;
		}
		else if (state.rateCapacityState == AffordabilityState.CanPartiallyProduce)
		{
			progressButton.progressFill.color = ColorManager.progressBarSatisfied;
		}
		else
		{
			progressButton.progressFill.color = ColorManager.progressBarDefault;
		}
	}

	private static void DeriveLabelColor(TextMeshProUGUI label, StateManager sm)
	{
		if (sm.outputCapacityState == AffordabilityState.CanNotProduce)
		{
			UpdateLabelColorOutput(label, sm.outputCapacityState);
		}
		else if (sm.inputAffordabilityState == AffordabilityState.CanNotProduce)
		{
			UpdateLabelColorInput(label, sm.inputAffordabilityState);
		}
		else if (sm.rateCapacityState == AffordabilityState.CanNotProduce)
		{
			UpdateLabelColorRate(label, sm.rateCapacityState);
		}
		else if (sm.outputCapacityState == AffordabilityState.CanPartiallyProduce)
		{
			UpdateLabelColorOutput(label, sm.outputCapacityState);
		}
		else if (sm.inputAffordabilityState == AffordabilityState.CanPartiallyProduce)
		{
			UpdateLabelColorInput(label, sm.inputAffordabilityState);
		}
		else if (sm.rateCapacityState == AffordabilityState.CanPartiallyProduce)
		{
			UpdateLabelColorRate(label, sm.rateCapacityState);
		}
		else
		{
			label.color = Color.white;
		}
	}

	private static void UpdateLabelColorInput(TextMeshProUGUI label, AffordabilityState affordabilityState)
	{
		switch (affordabilityState)
		{
		case AffordabilityState.CanNotProduce:
			label.color = ColorManager.inputStarved;
			break;
		case AffordabilityState.CanPartiallyProduce:
			label.color = ColorManager.inputSlowed;
			break;
		default:
			label.color = Color.white;
			break;
		}
	}

	private static void UpdateLabelColorRate(TextMeshProUGUI label, AffordabilityState affordabilityState)
	{
		switch (affordabilityState)
		{
		case AffordabilityState.CanNotProduce:
			label.color = ColorManager.outputFull;
			break;
		case AffordabilityState.CanPartiallyProduce:
			label.color = ColorManager.rateSlowed;
			break;
		default:
			label.color = Color.white;
			break;
		}
	}

	private static void UpdateLabelColorOutput(TextMeshProUGUI label, AffordabilityState affordabilityState)
	{
		switch (affordabilityState)
		{
		case AffordabilityState.CanNotProduce:
			label.color = ColorManager.outputFull;
			break;
		case AffordabilityState.CanPartiallyProduce:
			label.color = ColorManager.outputSlowed;
			break;
		default:
			label.color = Color.white;
			break;
		}
	}

	public string RateHighlightText()
	{
		return TextDisplay.RateHighlightText(state);
	}
}
