using System;
using TMPro;

public class TimeTokensPanel : MenuPanel
{
	public MenuButton buttonStop;

	public MenuButton buttonPlayNormal;

	public MenuButton buttonPlayFast;

	public MenuButton buttonPlayUltra;

	public CapacityRegion timeTokensCapacityRegion;

	public TextMeshProUGUI amountLabel;

	public TextMeshProUGUI gameSpeedDescription;

	public MenuButton progressBarButton;

	[NonSerialized]
	public double displayedTimeTokens = double.MinValue;

	private int displayedTimeMode = int.MinValue;

	private float displayedMultiplier = float.MinValue;

	[NonSerialized]
	public bool hasBeenViewed;

	private float lastDisplayedSeconds;

	private double timeTokens => GameManager.Instance.timeTokenState.currentCount;

	public override void Initialize()
	{
		base.Initialize();
		buttonStop.InitializeButton();
		buttonPlayNormal.InitializeButton();
		buttonPlayFast.InitializeButton();
		buttonPlayUltra.InitializeButton();
		buttonStop.buttonState = CustomButtonState.Background;
		buttonPlayNormal.buttonState = CustomButtonState.Background;
		buttonPlayFast.buttonState = CustomButtonState.Background;
		buttonPlayUltra.buttonState = CustomButtonState.Background;
		timeTokensCapacityRegion.iconImage.sprite = IconManager.DefaultSpriteForItem(ItemType.TimeToken);
		buttonStop.AddPointerClickTrigger(OnButtonStopPressed);
		buttonPlayNormal.AddPointerClickTrigger(OnButtonNormalPressed);
		buttonPlayFast.AddPointerClickTrigger(OnButtonFastPressed);
		buttonPlayUltra.AddPointerClickTrigger(OnButtonUltraPressed);
		progressBarButton.tooltipEntity = EntityId.FromItem(ItemType.TimeToken);
		progressBarButton.tooltipModifier = TooltipModifier.ShowGuide;
		progressBarButton.tooltipOptions = MenuManager.Instance.rewardTooltipOptions;
		progressBarButton.AddPointerClickTrigger(OnClickedProgressBar);
		buttonStop.highlightTextDelegate = ButtonStopTooltip;
		buttonPlayNormal.highlightTextDelegate = ButtonNormalTooltip;
		buttonPlayFast.highlightTextDelegate = ButtonFastTooltip;
		buttonPlayUltra.highlightTextDelegate = ButtonUltraTooltip;
	}

	private void OnClickedProgressBar()
	{
		MenuManager.Instance.tooltipPanel.ToggleEntityPinState(EntityId.FromItem(ItemType.TimeToken));
	}

	public override void Show()
	{
		base.Show();
		hasBeenViewed = true;
		MenuManager.Instance.navigationPanel.UpdateTimeTokensButtonState();
		buttonPlayFast.gameObject.SetActive(!MenuPanel.gm.isExtraActive);
		buttonPlayUltra.gameObject.SetActive(!MenuPanel.gm.isExtraActive);
		timeTokensCapacityRegion.gameObject.SetActive(!MenuPanel.gm.isExtraActive);
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		gameSpeedDescription.text = TextDisplay.LabelForTimeMode(TimeManager.timeMode, 1f);
	}

	private string ButtonStopTooltip()
	{
		return "Pause".Localized() + TextDisplay.NewLine + TextDisplay.FormattedKeyValue("Hotkey", UserInput.TimePauseHotkey);
	}

	private string ButtonNormalTooltip()
	{
		return "Normal".Localized() + TextDisplay.NewLine + TextDisplay.FormattedKeyValue("Hotkey", UserInput.TimeNormalHotkey);
	}

	private string ButtonFastTooltip()
	{
		return "TurboMode".Localized() + TextDisplay.NewLine + TextDisplay.FormattedKeyValue("Hotkey", UserInput.TimeFastHotkey);
	}

	private string ButtonUltraTooltip()
	{
		return "TurboMode".Localized() + " (" + "Max".Localized() + ")" + TextDisplay.NewLine + TextDisplay.FormattedKeyValue("Hotkey", UserInput.TimeUltraHotkey);
	}

	protected override void UpdateDynamicDisplay()
	{
		base.UpdateDynamicDisplay();
		if (displayedTimeMode != TimeManager.timeMode || GameUtility.NotEquals(displayedMultiplier, TimeManager.targetSpeedMultiplier))
		{
			ReloadLabels();
			displayedMultiplier = 1f;
		}
		if (displayedTimeMode != TimeManager.timeMode)
		{
			displayedTimeMode = TimeManager.timeMode;
			buttonStop.isSelected = displayedTimeMode == -1;
			buttonPlayNormal.isSelected = displayedTimeMode == 0;
			buttonPlayFast.isSelected = displayedTimeMode == 1;
			buttonPlayUltra.isSelected = displayedTimeMode == 2;
		}
		double num = MenuPanel.gm.DisplayedTimeTokens();
		float num2 = GameUtility.AsTruncatedFloat(num * 60.0);
		float num3 = lastDisplayedSeconds - num2;
		if (displayedTimeMode > 0 && num3 <= 0f)
		{
			return;
		}
		lastDisplayedSeconds = num2;
		if (GameUtility.NotEquals(num, displayedTimeTokens))
		{
			displayedTimeTokens = num;
			amountLabel.text = TextDisplay.LocalizedNumber(displayedTimeTokens) + "/" + TextDisplay.LocalizedNumber(MenuPanel.gm.timeTokenState.maxCount);
			timeTokensCapacityRegion.label.text = TextDisplay.FormattedHoursMinutesSeconds(num2);
			if (displayedTimeTokens >= 1.0)
			{
				timeTokensCapacityRegion.slider.value = GameUtility.AsTruncatedFloat(MenuPanel.gm.timeTokenState.currentCount / MenuPanel.gm.timeTokenState.maxCount);
			}
			else
			{
				timeTokensCapacityRegion.slider.value = 0f;
			}
		}
	}

	private void OnButtonStopPressed()
	{
		TimeManager.timeMode = -1;
	}

	private void OnButtonNormalPressed()
	{
		TimeManager.timeMode = 0;
	}

	private void OnButtonFastPressed()
	{
		if (!TimeManager.TrySpeedUp(1))
		{
			TimeManager.ShowNoTokensMessage();
		}
	}

	private void OnButtonUltraPressed()
	{
		if (!TimeManager.TrySpeedUp(2))
		{
			TimeManager.ShowNoTokensMessage();
		}
	}

	public override bool ShouldBeAvailable()
	{
		return true;
	}
}
