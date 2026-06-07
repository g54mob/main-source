using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ProductionLimitPanel : MenuPanel, IPointerDownHandler, IEventSystemHandler
{
	public TextMeshProUGUI inheritedKeyLabel;

	public TextMeshProUGUI inheritedValueLabel;

	public TextMeshProUGUI maxOverrideButtonLabel;

	public TextMeshProUGUI maxOverrideButtonPerSecondLabel;

	public TextMeshProUGUI rateButtonLabel;

	public TextMeshProUGUI rateButtonPerSecondLabel;

	public TextMeshProUGUI meetDemandButtonLabel;

	public TextMeshProUGUI meetDemandButtonPerSecondLabel;

	public TextMeshProUGUI passiveSurplusButtonLabel;

	public TextMeshProUGUI headerLabelProductionLimit;

	public TextMeshProUGUI headerLabelPause;

	public SelectableButton maxButton;

	public SelectableButton maxOverrideButton;

	public SelectableButton rateButton;

	public SelectableButton meetDemandButton;

	public SelectableButton passiveSurplusButton;

	public PauseRegion pauseRegion;

	public LabelButton pauseButton;

	private ProductionTargetRegion displayedRegion;

	private AssignableState displayedSettings;

	private ProductionConfig displayedConfig;

	public TMP_InputField rateInputField;

	public TMP_InputField demandPercentInputField;

	private float targetRate;

	private readonly Dictionary<ProductionLimitType, SelectableButton> buttons = new Dictionary<ProductionLimitType, SelectableButton>();

	public override void Initialize()
	{
		base.Initialize();
		maxButton.AddPointerClickTrigger(OnMaxPressed);
		maxOverrideButton.AddPointerClickTrigger(OnMaxOverridePressed);
		rateButton.AddPointerClickTrigger(OnRatePressed);
		meetDemandButton.AddPointerClickTrigger(OnMeetDemandPressed);
		passiveSurplusButton.AddPointerClickTrigger(OnPassiveSurplusPressed);
		buttons[ProductionLimitType.DefaultNone] = maxButton;
		buttons[ProductionLimitType.TargetRate] = rateButton;
		buttons[ProductionLimitType.MeetDemand] = meetDemandButton;
		buttons[ProductionLimitType.PassiveSurplus] = passiveSurplusButton;
		buttons[ProductionLimitType.OverrideNone] = maxOverrideButton;
		rateInputField.characterLimit = 20;
		rateInputField.characterValidation = TMP_InputField.CharacterValidation.Decimal;
		rateInputField.onSubmit.AddListener(OnTextSubmit);
		rateInputField.restoreOriginalTextOnEscape = true;
		demandPercentInputField.characterLimit = 4;
		demandPercentInputField.characterValidation = TMP_InputField.CharacterValidation.Decimal;
		demandPercentInputField.onSubmit.AddListener(OnDemandPercentSubmit);
		demandPercentInputField.restoreOriginalTextOnEscape = true;
		foreach (SelectableButton value in buttons.Values)
		{
			value.InitializeButton();
			value.buttonState = CustomButtonState.Background;
		}
		pauseRegion.Initialize(OnPauseChanged);
		pauseRegion.pauseButton.AnimateInstant();
		inheritedValueLabel.color = Color.grey;
	}

	private void UpdateButtonSelection()
	{
		foreach (KeyValuePair<ProductionLimitType, SelectableButton> button in buttons)
		{
			button.Value.isSelected = displayedConfig.type == button.Key;
		}
	}

	public void DisplayForState(ProductionTargetRegion region)
	{
		displayedSettings = region.displayedSettings;
		displayedRegion = region;
		displayedConfig = displayedSettings.productionLimit;
		pauseRegion.displayedSettings = region.displayedSettings;
		bool restrictOptions = displayedConfig.restrictOptions;
		if (displayedSettings.parentSettings == null)
		{
			maxOverrideButton.gameObject.SetActive(value: false);
		}
		else
		{
			maxOverrideButton.gameObject.SetActive(!restrictOptions);
		}
		rateButton.gameObject.SetActive(!restrictOptions);
		meetDemandButton.gameObject.SetActive(!restrictOptions);
		if (displayedConfig.targetRate < 0.1f)
		{
			rateInputField.text = TextDisplay.LocalizedNumber(1f);
		}
		else
		{
			rateInputField.text = TextDisplay.LocalizedNumber(displayedConfig.targetRate);
		}
		if (displayedConfig.targetDemandPercent <= 0.01f)
		{
			demandPercentInputField.text = TextDisplay.LocalizedNumber(100f);
		}
		else
		{
			demandPercentInputField.text = TextDisplay.LocalizedNumber(displayedConfig.targetDemandPercent * 100f);
		}
		ReloadLabels();
		ReloadPauseState();
		ManuallyOpen();
		UpdateButtonSelection();
		UpdateSimulationDisplay();
	}

	protected override void UpdateSimulationDisplay()
	{
		base.UpdateSimulationDisplay();
		if (displayedConfig == null)
		{
			return;
		}
		if (displayedSettings.parentSettings == null)
		{
			inheritedValueLabel.text = string.Empty;
			meetDemandButtonPerSecondLabel.text = string.Empty;
			return;
		}
		ProductionConfig productionConfig = displayedSettings.InheritedProductionConfig();
		if (productionConfig != null)
		{
			switch (productionConfig.type)
			{
			case ProductionLimitType.DefaultNone:
				inheritedValueLabel.text = "NoLimit".Localized();
				break;
			case ProductionLimitType.MeetDemand:
				inheritedValueLabel.text = "Demand".Localized();
				break;
			case ProductionLimitType.TargetRate:
				inheritedValueLabel.text = TextDisplay.PerSecondRate(productionConfig.targetRate);
				break;
			}
		}
		else
		{
			inheritedValueLabel.text = "NoLimit".Localized();
		}
		StateManager linkedState = displayedConfig.linkedState;
		if (linkedState == null)
		{
			meetDemandButtonPerSecondLabel.text = string.Empty;
			return;
		}
		if (linkedState is SellState sellState)
		{
			meetDemandButtonPerSecondLabel.text = TextDisplay.PerSecondRate(sellState.happinessRate);
			return;
		}
		float value = linkedState.DemandForPrimaryOutput();
		meetDemandButtonPerSecondLabel.text = TextDisplay.PerSecondRate(value);
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		if (displayedSettings != null)
		{
			if (displayedSettings.parentSettings == null)
			{
				inheritedKeyLabel.text = "NoLimit".Localized();
			}
			else
			{
				inheritedKeyLabel.text = "Default".Localized() + "/" + "Inherit".Localized();
				maxOverrideButtonLabel.text = "NoLimit".Localized();
			}
			rateButtonLabel.text = "MaxRate".Localized();
			meetDemandButtonLabel.text = "Demand".Localized();
			passiveSurplusButtonLabel.text = "Surplus".Localized();
			rateButtonPerSecondLabel.text = "/ " + "TimeSecondsAbbreviation".Localized();
			headerLabelPause.text = "Pause".Localized();
			headerLabelProductionLimit.text = "ProductionTarget".Localized();
			ReloadPauseLabel();
		}
	}

	private void ReloadPauseLabel()
	{
		pauseButton.label.text = TextDisplay.LabelforPauseState(displayedSettings.pause.value);
	}

	private void OnMaxPressed()
	{
		displayedConfig.type = ProductionLimitType.DefaultNone;
		OnChanged();
	}

	private void OnMaxOverridePressed()
	{
		displayedConfig.type = ProductionLimitType.OverrideNone;
		OnChanged();
	}

	private void OnPauseChanged()
	{
		ReloadPauseState();
		displayedRegion.OnPauseChanged();
		displayedConfig.OnChanged();
		MenuManager.Instance.isTooltipStale = true;
	}

	private void OnChanged()
	{
		UpdateButtonSelection();
		displayedRegion.OnProductionTargetChanged();
		displayedConfig.OnChanged();
	}

	private void OnRatePressed()
	{
		displayedConfig.type = ProductionLimitType.TargetRate;
		ApplyTextInputRate();
		OnChanged();
	}

	private void OnDemandPercentSubmit(string result)
	{
		OnMeetDemandPressed();
	}

	private void OnTextSubmit(string result)
	{
		OnRatePressed();
	}

	private void ApplyTextInputDemandPercent()
	{
		if (float.TryParse(demandPercentInputField.text, out var result) && result / 100f >= 0.01f)
		{
			displayedConfig.targetDemandPercent = result / 100f;
		}
		else
		{
			displayedConfig.targetDemandPercent = 1f;
		}
	}

	private void ApplyTextInputRate()
	{
		if (float.TryParse(rateInputField.text, out var result) && result >= 0.1f)
		{
			displayedConfig.targetRate = result;
		}
		else
		{
			displayedConfig.targetRate = 1f;
		}
	}

	private void OnMeetDemandPressed()
	{
		displayedConfig.type = ProductionLimitType.MeetDemand;
		ApplyTextInputDemandPercent();
		OnChanged();
	}

	private void OnPassiveSurplusPressed()
	{
		displayedConfig.type = ProductionLimitType.PassiveSurplus;
		OnChanged();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}

	public override void UpdatePauseDisplay()
	{
		base.UpdatePauseDisplay();
		ReloadPauseState();
	}

	public void ReloadPauseState()
	{
		if (null != pauseRegion)
		{
			CommonListItem.ReloadButtonState(pauseRegion.pauseButton, pauseRegion.pauseImage, displayedSettings.pause.value);
			pauseRegion.SetLocalPauseDisplay(displayedSettings.pause.value);
			ReloadPauseLabel();
		}
	}
}
