using System;
using TMPro;

public class TradingPostSectionHeader : SectionHeader
{
	public PauseRegion pauseRegion;

	public PriorityRegion priorityRegion;

	public TradeModeRegion tradeModeRegion;

	public AutoAssignRegion autoAssignRegion;

	public ProductionTargetRegion productionTargetRegion;

	[NonSerialized]
	public TradeSpecialtyConfig specialtyConfig;

	public TextMeshProUGUI tradeModeLabel;

	public override void Initialize()
	{
		base.Initialize();
		tradeModeRegion.Initialize();
		tradeModeRegion.onChangedDelegate = OnTradeModeChanged;
		tradeModeRegion.tradeTypeButton.buttonState = CustomButtonState.Background;
		pauseRegion.Initialize(OnPauseChanged);
		priorityRegion.Initialize(OnPriorityChanged);
		autoAssignRegion.Initialize(OnAutoAssignClicked, OnAutoAssignChanged);
		productionTargetRegion.InitializeAsStandaloneButton();
		productionTargetRegion.onLimitChangedDelegate = OnProductionLimitChanged;
		productionTargetRegion.onPauseChangedDelegate = OnPauseChanged;
	}

	public void LoadSettings(TradeSpecialtyConfig c)
	{
		specialtyConfig = c;
		tradeModeRegion.displayedSettings = c;
		productionTargetRegion.displayedSettings = c;
		priorityRegion.displayedSettings = c;
		autoAssignRegion.displayedSettings = c;
		pauseRegion.displayedSettings = c;
		ReloadLabels();
	}

	public void OnTradeModeChanged()
	{
		specialtyConfig.parentTown.OnTradeModeChangedSpecialty(specialtyConfig.specialty);
		if (parentPanel is ProductionListPanelCombined productionListPanelCombined)
		{
			productionListPanelCombined.isTradeModeStale = true;
		}
		MenuManager.Instance.isTooltipStale = true;
		ReloadTradeModeDisplay();
	}

	private void OnPauseChanged()
	{
		specialtyConfig.parentTown.CalcAllPause();
		UpdatePauseDisplay();
		parentPanel.isPauseStale = true;
		MenuManager.Instance.isTooltipStale = true;
	}

	private void OnProductionLimitChanged()
	{
		specialtyConfig.parentTown.OnProductionLimitChangedSpecialty(specialtyConfig);
		parentPanel.isProductionLimitStale = true;
	}

	private void OnAutoAssignClicked()
	{
		bool isParentSpecified = specialtyConfig.InheritedAutoAssign() == OverrideState.On;
		OverrideState nextValue = GameUtility.CycledOverride(specialtyConfig.autoAssign.value, isParentSpecified);
		specialtyConfig.autoAssign.ChangeValue(nextValue);
		OnAutoAssignChanged();
	}

	private void OnAutoAssignChanged()
	{
		specialtyConfig.parentTown.CalcAllAutoAssign();
		UpdateAutoAssignDisplay();
		parentPanel.isAutoAssignStale = true;
		MenuManager.Instance.isTooltipStale = true;
	}

	private void OnPriorityChanged()
	{
		specialtyConfig.parentTown.OnPriorityChanged(specialtyConfig);
		UpdatePriorityDisplay();
		parentPanel.isPriorityStale = true;
		MenuManager.Instance.isTooltipStale = true;
	}

	public void UpdatePauseDisplay()
	{
		OverrideState appliedState = specialtyConfig.DerivedPause();
		pauseRegion.SetPauseDisplay(specialtyConfig.pause.value, appliedState);
	}

	public void ReloadTradeModeDisplay()
	{
		bool isInherited = specialtyConfig.tradingConfig.value == TradeMode.None;
		tradeModeRegion.SetModeImage(specialtyConfig.tradingConfig.value, isInherited);
		ReloadTradeModeLabel();
	}

	public void ReloadTradeModeLabel()
	{
		if (specialtyConfig != null && specialtyConfig.tradingConfig != null)
		{
			if (specialtyConfig.tradingConfig.value == TradeMode.None)
			{
				tradeModeLabel.text = "ItemLabelNone".Localized();
				return;
			}
			string text = TextDisplay.LabelForTradeMode(specialtyConfig.tradingConfig.value);
			tradeModeLabel.text = text;
		}
	}

	public void UpdateBuildingData()
	{
		UpdatePauseDisplay();
		UpdatePriorityDisplay();
		UpdateAutoAssignDisplay();
		ReloadTradeModeDisplay();
		ReloadLabels();
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		ReloadTradeModeLabel();
		if (specialtyConfig != null)
		{
			if (specialtyConfig.specialty == Specialty.UniqueExport)
			{
				primaryLabel.text = TextDisplay.FormattedKeyValue("UniqueResource", "(" + "Export".Localized() + ")");
			}
			else if (specialtyConfig.specialty == Specialty.UniqueImport)
			{
				primaryLabel.text = TextDisplay.FormattedKeyValue("UniqueResource", "(" + "Import".Localized() + ")");
			}
		}
	}

	public void UpdateDynamicDisplay()
	{
	}

	public void UpdateProductionLimitDisplay()
	{
		productionTargetRegion.SetTargetImage();
	}

	public void UpdatePriorityDisplay()
	{
		StatePriority appliedPriority = specialtyConfig.DerivedPriority();
		priorityRegion.SetPriorityImage(specialtyConfig.priority.value, appliedPriority);
	}

	public void UpdateAutoAssignDisplay()
	{
		OverrideState appliedState = specialtyConfig.DerivedAutoAssign();
		autoAssignRegion.SetDisplayedState(specialtyConfig.autoAssign.value, appliedState);
	}

	public void UpdateRegionAvailability()
	{
		if (null != priorityRegion)
		{
			bool active = GameManager.IsGlobalQuestComplete(Quest.UnlockPrioritization);
			priorityRegion.gameObject.SetActive(active);
		}
		if (null != autoAssignRegion)
		{
			bool active2 = GameManager.IsGlobalQuestComplete(Quest.UnlockAutoBalance);
			autoAssignRegion.gameObject.SetActive(active2);
		}
	}
}
