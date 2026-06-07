using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResearchListItem : CommonListItem
{
	public TextMeshProUGUI label;

	public Image iconImage;

	public ResearchState researchState;

	public Slider researchProgressBar;

	public CostGrid costGrid;

	public LabelButton manualResearchButton;

	public MenuButton titleButton;

	public Image researchButtonBackground;

	private float lastDisplayedProgress = float.MinValue;

	private float lastDisplayedNumWorkers = float.MinValue;

	private bool lastDisplayedClaimState;

	private BuildObjectAvailability lastDisplayedAvailability;

	private bool hasHiddenControls;

	public override void UpdateSimulationDisplay()
	{
		if (researchState.isReadyToClaim || researchState.availability == BuildObjectAvailability.Locked || researchState.availability == BuildObjectAvailability.Completed)
		{
			rateDisplayRegion.rateDisplayMode = RateDisplayMode.Off;
			rateDisplayRegion.ratioDisplayMode = RatioDisplayMode.Off;
		}
		else
		{
			rateDisplayRegion.rateDisplayMode = RateDisplayMode.TimeRemaining;
			rateDisplayRegion.ratioDisplayMode = RatioDisplayMode.RelativeToBaseline;
		}
		base.UpdateSimulationDisplay();
	}

	public override void UpdateDynamicDisplay()
	{
		base.UpdateDynamicDisplay();
		if (researchState.isCostGridStale)
		{
			ReloadLabelParent();
			LoadCost();
		}
		if (researchState == null)
		{
			return;
		}
		researchProgressBar.value = GameUtility.AsFloat(state.unitProgress);
		float num = Mathf.Clamp01(1f - GameUtility.AsFloat(researchState.unitProgress));
		foreach (ItemRateData item in researchState.input)
		{
			costGrid.SetAmount(item.state.AsEntity(), item.totalAmount * (double)num);
		}
		costGrid.UpdateDynamicAffordability();
		if (GameUtility.NotEquals(GameUtility.AsFloat(researchState.unitProgress), lastDisplayedProgress) || GameUtility.NotEquals(researchState.numWorkersAssigned, lastDisplayedNumWorkers) || researchState.availability != lastDisplayedAvailability || researchState.isReadyToClaim != lastDisplayedClaimState)
		{
			RefreshButtonDisplay();
		}
	}

	private void RefreshButtonDisplay()
	{
		UpdateRegionAvailability();
		lastDisplayedAvailability = researchState.availability;
		lastDisplayedProgress = GameUtility.AsFloat(researchState.unitProgress);
		lastDisplayedNumWorkers = researchState.numWorkersAssigned;
		lastDisplayedClaimState = researchState.isReadyToClaim;
		if (researchState.availability == BuildObjectAvailability.Available && researchState.isReadyToClaim)
		{
			researchButtonBackground.enabled = true;
		}
		else
		{
			researchButtonBackground.enabled = false;
		}
		if (researchState.availability == BuildObjectAvailability.Locked)
		{
			manualResearchButton.label.text = "Locked".Localized();
			manualResearchButton.invalidReason = InvalidReason.LockedByRequirements;
			manualResearchButton.buttonState = CustomButtonState.Disabled;
		}
		else if (researchState.availability == BuildObjectAvailability.Completed)
		{
			manualResearchButton.label.text = "Completed".Localized();
			manualResearchButton.invalidReason = InvalidReason.ResearchAlreadyCompleted;
			manualResearchButton.buttonState = CustomButtonState.Disabled;
		}
		else if (researchState.isReadyToClaim)
		{
			manualResearchButton.label.text = "Complete".Localized();
			manualResearchButton.invalidReason = InvalidReason.None;
			manualResearchButton.buttonState = CustomButtonState.HighlightFlashing;
		}
		else
		{
			TextDisplay.SetPercent(manualResearchButton.label, state.UnitProgressPercent());
			manualResearchButton.invalidReason = InvalidReason.ResearchNotCompleteYet;
			manualResearchButton.buttonState = CustomButtonState.Default;
		}
		if (GameUtility.IsNearlyZero(lastDisplayedProgress))
		{
			researchProgressBar.gameObject.SetActive(value: false);
		}
		else if (researchState.isReadyToClaim)
		{
			researchProgressBar.gameObject.SetActive(value: false);
		}
		else
		{
			researchProgressBar.gameObject.SetActive(value: true);
		}
	}

	public override void UpdateRegionAvailability()
	{
		base.UpdateRegionAvailability();
		CalcDisableControls();
		bool flag = researchState.availability == BuildObjectAvailability.Available;
		bool flag2 = researchState.availability == BuildObjectAvailability.Available && !researchState.isReadyToClaim;
		bool flag3 = researchState.availability == BuildObjectAvailability.Completed || researchState.isReadyToClaim;
		bool flag4 = researchState.availability == BuildObjectAvailability.Completed;
		if (true)
		{
			workerAssignmentRegion.gameObject.SetActive(flag2);
			costGrid.gameObject.SetActive(researchState.availability == BuildObjectAvailability.Locked || !flag3);
			rateDisplayRegion.gameObject.SetActive(flag2);
			pauseRegion.gameObject.SetActive(flag2);
			if (!flag2 && null != priorityRegion)
			{
				priorityRegion.gameObject.SetActive(value: false);
			}
		}
		else
		{
			workerAssignmentRegion.gameObject.SetActive(flag);
			costGrid.gameObject.SetActive(!flag4);
			rateDisplayRegion.gameObject.SetActive(flag);
			if (!flag && null != priorityRegion)
			{
				priorityRegion.gameObject.SetActive(value: false);
			}
		}
	}

	public override void ResetPointerAndHighlightState()
	{
		base.ResetPointerAndHighlightState();
		manualResearchButton.ResetPointerAndHighlightState();
	}

	public override void OnStateAssignmentChanged()
	{
		rateDisplayRegion.forceRefresh = true;
		base.OnStateAssignmentChanged();
		RefreshButtonDisplay();
		ResetPointerAndHighlightState();
		manualResearchButton.AnimateInstant();
	}

	public void OnManualResearchPressed()
	{
		ClearAlertState();
		if (researchState.IsAvailable() && (researchState.isReadyToClaim || GameManager.freeMode) && (manualResearchButton.invalidReason == InvalidReason.None || GameManager.freeMode))
		{
			ResetPointerAndHighlightState();
			CommonListItem.gm.BeginTrackingUnlocks();
			researchState.Claim();
			CommonListItem.gm.ProcessMetadataQueue();
			CommonListItem.gm.EndTrackingUnlocks();
		}
	}

	public override void Initialize()
	{
		base.Initialize();
		LoadAlert(label.transform);
		manualResearchButton.AddPointerClickTrigger(OnManualResearchPressed);
		rateDisplayRegion.rateDisplayMode = RateDisplayMode.Off;
		rateDisplayRegion.ratioDisplayMode = RatioDisplayMode.InputRatio;
		rateDisplayRegion.iconDisplayMode = IconDisplayMode.PauseState;
		titleButton.AddPointerClickTrigger(base.OnTitleLabelClicked);
		titleButton.tooltipOptions = MenuManager.Instance.recipeLabelTooltipOptions;
		titleButton.tooltipModifier = TooltipModifier.ShowGuide;
	}

	public override void LoadCost()
	{
		base.LoadCost();
		costGrid.Clear();
		foreach (ItemRateData item in researchState.input)
		{
			costGrid.AddInput(item);
		}
		costGrid.PerformLayout();
		costGrid.UpdateColors();
		researchState.isCostGridStale = false;
		foreach (CostIcon value in costGrid.inputIcons.Values)
		{
			_ = value;
		}
	}

	public void LoadState(ResearchState rs)
	{
		researchState = rs;
		iconImage.sprite = IconManager.SpriteForResearch(researchState.type);
		LoadCommonState(researchState);
		titleButton.tooltipEntity = EntityId.FromResearch(researchState.type);
		CalcDisableControls();
	}

	private void CalcDisableControls()
	{
		workerAssignmentRegion.disableControls = researchState.isReadyToClaim || researchState.availability != BuildObjectAvailability.Available;
	}

	public override void ReloadLabelParent()
	{
		base.ReloadLabelParent();
		label.text = researchState.GetLabel();
		RefreshButtonDisplay();
	}

	public void UpdateBuildingData()
	{
		UpdateStaticDisplay();
	}

	public override void OnRemoveFromList()
	{
		base.OnRemoveFromList();
		manualResearchButton.OnRemoveFromList();
	}
}
