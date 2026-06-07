using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryListItem : SelectableButton, IPooledListItem
{
	public MenuButton itemIconButton;

	public ConsumableState itemState;

	public Image iconImage;

	public TextMeshProUGUI rateLabel;

	public TextMeshProUGUI increaseSymbols;

	public TextMeshProUGUI decreaseSymbols;

	public ProgressBar capacityProgressBar;

	public RectTransform positiveSliderRect;

	public RectTransform negativeSliderRect;

	public Image positiveSliderImage;

	public Image negativeSliderImage;

	public Image carat1;

	public Image carat2;

	public Image carat3;

	private double lastDisplayedRate = double.MaxValue;

	private bool lastDisplayedWarning;

	private Flag lastDisplayedZeroRate = Flag.Unknown;

	public bool isRateStale;

	public bool isCurrency;

	private bool isInfiniteSupply;

	public bool showSimplifiedRate = true;

	private const float fontSizeLarge = 22f;

	private int lastCaratDir;

	private bool debug;

	public CanvasGroup canvas;

	public void UpdateSimulationDisplay()
	{
		_ = debug;
		if (isInfiniteSupply)
		{
			capacityProgressBar.label.text = "∞";
			capacityProgressBar.slider.value = 1f;
		}
		else
		{
			capacityProgressBar.TryUpdateDisplay(itemState);
		}
		negativeSliderImage.enabled = false;
		positiveSliderImage.enabled = false;
		float num = 0.0005f;
		float num2 = 0.005f;
		float num3 = 0.02f;
		double perSecondAttemptedDelta = itemState.perSecondAttemptedDelta;
		float num4 = GameUtility.AsFloat(perSecondAttemptedDelta / itemState.maxCount);
		if (perSecondAttemptedDelta > 0.0)
		{
			carat1.enabled = num4 > num;
			carat2.enabled = num4 > num2;
			carat3.enabled = num4 > num3;
			if (lastCaratDir < 1)
			{
				Sprite caratRight = IconManager.Instance.caratRight;
				carat1.color = Color.green;
				carat2.color = Color.green;
				carat3.color = Color.green;
				carat1.sprite = caratRight;
				carat2.sprite = caratRight;
				carat3.sprite = caratRight;
				lastCaratDir = 1;
			}
		}
		else
		{
			carat1.enabled = num4 < 0f - num;
			carat2.enabled = num4 < 0f - num2;
			carat3.enabled = num4 < 0f - num3;
			if (lastCaratDir > -1)
			{
				Sprite caratLeft = IconManager.Instance.caratLeft;
				carat1.color = Color.red;
				carat2.color = Color.red;
				carat3.color = Color.red;
				carat1.sprite = caratLeft;
				carat2.sprite = caratLeft;
				carat3.sprite = caratLeft;
				lastCaratDir = -1;
			}
		}
		bool flag = GameUtility.IsNearlyZero(itemState.frameAdded) && GameUtility.IsNearlyZero(itemState.frameSubtracted);
		bool flag2 = lastDisplayedZeroRate == Flag.True;
		if (!isRateStale)
		{
			isRateStale = !GameUtility.NearlyEquals(lastDisplayedRate, perSecondAttemptedDelta) || lastDisplayedWarning != itemState.showDecreaseWarning || flag != flag2;
		}
		if (isRateStale)
		{
			lastDisplayedRate = perSecondAttemptedDelta;
			lastDisplayedWarning = itemState.showDecreaseWarning;
			isRateStale = false;
			lastDisplayedZeroRate = (flag ? Flag.True : Flag.False);
			TextDisplay.FormatInventoryChangeRate(rateLabel, itemState);
			FormatRateAsSymbol(isSymbol: false);
		}
	}

	private void FormatRateAsSymbol(bool isSymbol)
	{
		if (isSymbol)
		{
			rateLabel.fontSize = 22f;
		}
		else
		{
			rateLabel.fontSize = 12f;
		}
	}

	public void ReloadLabels()
	{
		isRateStale = true;
	}

	public void Initialize()
	{
		AddPointerClickTrigger(OnInventoryItemClicked);
		itemIconButton.AddPointerClickTrigger(OnClickedItemIcon);
		base.buttonState = CustomButtonState.Background;
		canvas = base.gameObject.AddComponent<CanvasGroup>();
		highlightMargin = 1f;
	}

	public void LoadState(ConsumableState state)
	{
		capacityProgressBar.hideMaxValue = true;
		isCurrency = state is ItemState itemState && Item.IsCurrency(itemState.type);
		if (state is ResourceState resourceState && resourceState.def.IsInfiniteSupply())
		{
			isInfiniteSupply = true;
		}
		else
		{
			isInfiniteSupply = false;
		}
		this.itemState = state;
		if (state.parentTown == null)
		{
			iconImage.sprite = IconManager.SpriteForTradingPostItem(state);
			tooltipOptions = MenuManager.Instance.tradeStorageTooltipOptions;
		}
		else
		{
			iconImage.sprite = IconManager.SpriteForState(state);
			tooltipOptions = MenuManager.Instance.inventoryTooltipOptions;
		}
		EntityId entityId = state.AsEntity();
		itemIconButton.tooltipEntity = entityId;
		tooltipModifier = TooltipModifier.ShowProductionDetails;
		tooltipEntity = this.itemState.AsEntity();
		capacityProgressBar.SetStale();
		if (isCurrency)
		{
			capacityProgressBar.slider.gameObject.SetActive(value: false);
		}
		else
		{
			capacityProgressBar.slider.gameObject.SetActive(value: true);
		}
		isRateStale = true;
		selectionHandle = entityId;
		debug = false;
	}

	public void OnStateAssignmentChanged()
	{
		ReloadLabels();
		UpdateSelectionState();
		UpdateSimulationDisplay();
		AnimateInstant();
	}

	public void SetVisible(bool visible)
	{
		if (null != canvas)
		{
			canvas.alpha = (visible ? 1f : 0f);
			canvas.interactable = visible;
			canvas.blocksRaycasts = visible;
		}
	}

	private void OnInventoryItemClicked()
	{
		Toggle();
	}

	public void OnClickedItemIcon()
	{
		if (MenuManager.Instance.combinedProductionPanel.itemFilter == itemState)
		{
			MenuManager.Instance.ApplyCountableStateFilter(null);
		}
		else
		{
			MenuManager.Instance.ApplyCountableStateFilter(itemState);
		}
	}
}
