using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

public class CommonListItem : SelectableButton, IPooledListItem
{
	protected StateManager state;

	public WorkerAssignmentRegion workerAssignmentRegion;

	public SkillDisplayRegion skillDisplayRegion;

	public RateDisplayRegion rateDisplayRegion;

	public PriorityRegion priorityRegion;

	public PauseRegion pauseRegion;

	public AutoClaimRegion autoClaimRegion;

	public ProductionTargetRegion productionTargetRegion;

	[NonSerialized]
	public SectionHeader parentHeader;

	public CanvasGroup canvas;

	[NonSerialized]
	public IObjectPool<MonoBehaviour> parentPool;

	private Tweener rotationTween;

	private Tweener scaleTween;

	private bool lastPointerState;

	public float autoAssignAnimationCountdown;

	protected static GameManager gm => GameManager.Instance;

	public virtual void Initialize()
	{
		base.buttonState = CustomButtonState.Background;
		useOutlineHighlight = true;
		canvas = base.gameObject.AddComponent<CanvasGroup>();
		if (null != rateDisplayRegion)
		{
			rateDisplayRegion.Initialize(embedded: true);
			rateDisplayRegion.highlightTextDelegate = rateDisplayRegion.RateHighlightText;
			rateDisplayRegion.isTooltipUpdatedEverySimulationStep = true;
			rateDisplayRegion.buttonState = CustomButtonState.Background;
		}
		if (null != productionTargetRegion)
		{
			if (IsProductionLimitEmbedded())
			{
				productionTargetRegion.InitializeAsEmbeddedButton();
				productionTargetRegion.hideWhenInactive = true;
				productionTargetRegion.priorityImage.raycastTarget = false;
				rateDisplayRegion.AddPointerClickTrigger(productionTargetRegion.OnRegionClicked);
				rateDisplayRegion.AddRightClickTrigger(productionTargetRegion.OnRegionRightClicked);
			}
			else
			{
				productionTargetRegion.InitializeAsStandaloneButton();
			}
			productionTargetRegion.onLimitChangedDelegate = OnProductionLimitChanged;
			productionTargetRegion.onPauseChangedDelegate = OnPauseChanged;
		}
		if (null != priorityRegion)
		{
			priorityRegion.Initialize(OnPriorityChanged);
			priorityRegion.hideWhenInactive = false;
		}
		if (null != pauseRegion)
		{
			pauseRegion.Initialize(OnPauseChanged);
			if (IsProductionLimitEmbedded())
			{
				pauseRegion.hideWhenInactive = true;
			}
		}
		if (null != workerAssignmentRegion)
		{
			workerAssignmentRegion.Initialize();
			workerAssignmentRegion.automaticAssignButton.AddRightClickTrigger(OnAutoAssignRightClicked);
			workerAssignmentRegion.automaticAssignButton.highlightTextDelegate = HighlightTextAutomaticAssign;
		}
		if (null != autoClaimRegion)
		{
			autoClaimRegion.settingButton.AddPointerClickTrigger(OnAutoClaimClicked);
			autoClaimRegion.settingButton.buttonState = CustomButtonState.Background;
			autoClaimRegion.settingButton.highlightTextDelegate = HighlightTextAutoClaim;
		}
		if (null != skillDisplayRegion)
		{
			skillDisplayRegion.isTooltipUpdatedEverySimulationStep = true;
		}
		AddPointerClickTrigger(base.Toggle);
		AddRightClickTrigger(OnRowClicked);
	}

	private void OnProductionLimitChanged()
	{
		state.CalcAppliedProductionLimit();
		ReloadProductionLimitState();
		ReloadPauseState();
		MenuManager.Instance.isTooltipStale = true;
	}

	private bool IsProductionLimitEmbedded()
	{
		if (!(this is ProductionListItem) && !(this is MarketListItem))
		{
			return this is TradingListItem;
		}
		return true;
	}

	protected void OnTitleLabelClicked()
	{
		MenuManager.Instance.tooltipPanel.ToggleEntityPinState(state.AsEntity());
	}

	private string HighlightTextAutoClaim()
	{
		if (LocalizationManager.IsEnglish())
		{
			if (state.localAutoClaim == OverrideState.On)
			{
				return TextDisplay.FormattedKeyValue("ClaimAutomatically", "On".Localized());
			}
			if (state.localAutoClaim == OverrideState.Off)
			{
				return TextDisplay.FormattedKeyValue("ClaimAutomatically", "Off".Localized());
			}
			if (state.appliedAutoClaim)
			{
				return TextDisplay.FormattedKeyValue("ClaimAutomatically", "On".Localized()) + "\n(This setting is inherited from the recipe's building)";
			}
			return TextDisplay.FormattedKeyValue("ClaimAutomatically", "ItemLabelNone".Localized()) + "\n(Will inherit setting from the recipe's building)";
		}
		return null;
	}

	private string HighlightTextAutomaticAssign()
	{
		_ = state.localAutoAssign;
		if (LocalizationManager.IsEnglish())
		{
			if (state.localAutoAssign == OverrideState.On)
			{
				return TextDisplay.FormattedKeyValue("AutomaticAssignment", "On".Localized());
			}
			if (state.localAutoAssign == OverrideState.Off)
			{
				return TextDisplay.FormattedKeyValue("AutomaticAssignment", "Off".Localized());
			}
			if (state.appliedAutoAssign)
			{
				return string.Concat(TextDisplay.FormattedKeyValue("AutomaticAssignment", "On".Localized()) + "\nRecipe production capacity will be automatically assigned", "\n(This setting is inherited from the recipe's building)");
			}
			return string.Concat(TextDisplay.FormattedKeyValue("AutomaticAssignment", "ItemLabelNone".Localized()) + "\nRecipe production capacity must be manually assigned", "\n(Will inherit setting from the recipe's building)");
		}
		return null;
	}

	public virtual void ReloadLabelParent()
	{
		if (null != skillDisplayRegion)
		{
			skillDisplayRegion.ReloadLabelParent();
		}
	}

	public virtual void OnStateAssignmentChanged()
	{
		rotationTween?.Kill(complete: true);
		scaleTween?.Kill(complete: true);
		autoAssignAnimationCountdown = 0f;
		if (state != null)
		{
			state.didAutoAssign = false;
		}
		UpdateStaticDisplay();
		LoadCost();
		ReloadLabelParent();
		UpdateIndividualAvailability();
		UpdateSelectionState();
		AnimateInstant();
		if (null != pauseRegion)
		{
			pauseRegion.pauseButton.AnimateInstant();
		}
		if (null != rateDisplayRegion)
		{
			rateDisplayRegion.ResetDisplay();
			if (null != rateDisplayRegion.progressButton)
			{
				rateDisplayRegion.progressButton.AnimateInstant();
			}
		}
		if (null != productionTargetRegion && null != productionTargetRegion.productionTargetButton)
		{
			productionTargetRegion.productionTargetButton.AnimateInstant();
		}
		if (null != workerAssignmentRegion)
		{
			workerAssignmentRegion.AnimateInstant();
		}
		ReloadRepeatState();
		UpdateSimulationDisplay();
		UpdateDynamicDisplay();
	}

	public virtual void UpdateIndividualAvailability()
	{
		UpdateAlertState();
		UpdateRegionAvailability();
	}

	public void LoadCommonState(StateManager stateToLoad)
	{
		state = stateToLoad;
		priorityRegion.displayedSettings = stateToLoad.localSettings;
		if (null != pauseRegion)
		{
			pauseRegion.displayedSettings = stateToLoad.localSettings;
		}
		if (state.skill != null && null != skillDisplayRegion)
		{
			skillDisplayRegion.LoadSkill(state);
		}
		if (null != workerAssignmentRegion)
		{
			workerAssignmentRegion.LinkStateManager(state);
			_ = stateToLoad is ResearchState;
			workerAssignmentRegion.onManuallyChanged = OnNumWorkersManuallyChanged;
			workerAssignmentRegion.onRepeatChanged = OnAutoAssignChanged;
			workerAssignmentRegion.invalidButtonDelegate = OnInvalidButtonPressed;
		}
		if (null != rateDisplayRegion)
		{
			rateDisplayRegion.state = state;
			if (null != rateDisplayRegion.progressButton)
			{
				rateDisplayRegion.progressButton.stateManager = state;
			}
		}
		if (null != productionTargetRegion)
		{
			productionTargetRegion.displayedSettings = state.localSettings;
		}
		EntityId entityId = state.AsEntity();
		selectionHandle = entityId;
	}

	private void OnPauseChanged()
	{
		state.CalcAppliedPauseState();
		ReloadProductionLimitState();
		ReloadPauseState();
		MenuManager.Instance.isTooltipStale = true;
	}

	private void OnAutoClaimClicked()
	{
		state.localSettings.InheritedAutoClaim();
		SetAutoClaimState(GameUtility.CycledOverride(state.localSettings.autoClaim.value, isParentSpecified: true));
		MenuManager.Instance.isTooltipStale = true;
	}

	private void OnAutoAssignChanged()
	{
		bool isParentSpecified = state.localSettings.InheritedAutoAssign() == OverrideState.On;
		SetAutoAssignState(GameUtility.CycledOverride(state.localAutoAssign, isParentSpecified));
		MenuManager.Instance.isTooltipStale = true;
	}

	private void OnAutoRestartChanged()
	{
		bool isParentSpecified = state.localSettings.InheritedAutoClaim() == OverrideState.On;
		SetAutoClaimState(GameUtility.CycledOverride(state.localAutoClaim, isParentSpecified));
		MenuManager.Instance.isTooltipStale = true;
	}

	public void SetAutoAssignState(OverrideState nextState)
	{
		state.parentTown.RemoveFromAllAutoAssignLists(state);
		state.localSettings.autoAssign.ChangeValue(nextState);
		state.CalcAppliedAutoAssign();
		state.parentTown.AddToAutoAssignPriorityList(state);
		ReloadRepeatState();
	}

	public void SetAutoClaimState(OverrideState nextState)
	{
		state.localSettings.autoClaim.ChangeValue(nextState);
		state.CalcAppliedAutoClaim();
		ReloadAutoClaimState();
	}

	private void OnNumWorkersManuallyChanged(float nextValue)
	{
		ClearAlertState();
		state.OnNumWorkersChanged(nextValue);
		bool flag = state.localSettings.InheritedAutoAssign() == OverrideState.On;
		bool flag2 = false;
		if (state.localAutoAssign == OverrideState.On)
		{
			if (flag)
			{
				state.localSettings.autoAssign.ChangeValue(OverrideState.Off);
				flag2 = true;
			}
			else
			{
				state.localSettings.autoAssign.ChangeValue(OverrideState.None);
				flag2 = true;
			}
		}
		else if (state.localAutoAssign == OverrideState.None && flag)
		{
			state.localSettings.autoAssign.ChangeValue(OverrideState.Off);
			flag2 = true;
		}
		if (gm.tutorialQuestType == QuestType.AssignWorkersForGeneralStore)
		{
			MenuManager.Instance.pointerDelayCounter = 0f;
		}
		if (flag2)
		{
			state.parentTown.RemoveFromAllAutoAssignLists(state);
			state.CalcAppliedAutoAssign();
			state.parentTown.AddToAutoAssignPriorityList(state);
			ReloadRepeatState();
		}
	}

	private void OnPriorityChanged()
	{
		if (state != null)
		{
			state.parentTown.OnPriorityChanged(state);
			ReloadPriorityState();
			MenuManager.Instance.isTooltipStale = true;
		}
	}

	public void UpdateAutoAssignDisplay()
	{
		if (null != workerAssignmentRegion)
		{
			ReloadRepeatState();
		}
	}

	protected override void OnSelectionStateChanged()
	{
		if (isSelected)
		{
			ClearAlertState();
			MenuManager.Instance.inventoryPanel.SetFilter(state);
		}
		else
		{
			MenuManager.Instance.inventoryPanel.SetFilter(null);
		}
		base.OnSelectionStateChanged();
	}

	public void UpdateStaticDisplay()
	{
		if (null != workerAssignmentRegion)
		{
			workerAssignmentRegion.UpdateButtonAvailability();
		}
		ReloadRepeatState();
		ReloadPauseState();
		ReloadProductionLimitState();
		ReloadPriorityState();
		ReloadAutoClaimState();
		if (this is TradingListItem tradingListItem)
		{
			tradingListItem.ReloadTradeModeDisplay();
		}
	}

	public virtual void LoadCost()
	{
	}

	public virtual void UpdateSimulationDisplay()
	{
		if (state != null)
		{
			if (null != skillDisplayRegion && skillDisplayRegion.gameObject.activeInHierarchy)
			{
				skillDisplayRegion.UpdateSimulationDisplay();
			}
			if (null != rateDisplayRegion)
			{
				rateDisplayRegion.UpdateSimulationDisplay();
			}
		}
	}

	public virtual void UpdateDynamicDisplay()
	{
		if (state == null)
		{
			return;
		}
		if (alert.gameObject.activeInHierarchy && !state.isInAlertState)
		{
			alert.gameObject.SetActive(value: false);
		}
		if (null != workerAssignmentRegion && workerAssignmentRegion.gameObject.activeInHierarchy)
		{
			workerAssignmentRegion.UpdateDynamicDisplay();
			if (state.didAutoAssign)
			{
				autoAssignAnimationCountdown = 0f;
			}
			if (state.didAutoAssign || autoAssignAnimationCountdown > 0f)
			{
				float num = Mathf.Clamp01(1f - autoAssignAnimationCountdown * 5f);
				workerAssignmentRegion.automaticAssignmentHighlight.color = new Color(1f, 1f, 1f, num);
				autoAssignAnimationCountdown += TimeManager.MenuDelta;
				state.didAutoAssign = false;
				if (num <= 0f)
				{
					autoAssignAnimationCountdown = 0f;
				}
			}
			if (autoAssignAnimationCountdown <= 0f)
			{
				workerAssignmentRegion.automaticAssignmentHighlight.color = Color.clear;
				autoAssignAnimationCountdown = 0f;
			}
		}
		if (null != rateDisplayRegion)
		{
			rateDisplayRegion.UpdateDynamicDisplay();
		}
		if (lastPointerState != isPointerInsideButton)
		{
			UpdateRegionAvailability();
		}
	}

	private void OnInvalidButtonPressed(InvalidReason r)
	{
		switch (r)
		{
		case InvalidReason.None:
			return;
		case InvalidReason.NotEnoughWorkers:
			MenuManager.Instance.townStatsPanel.AnimateWorkerStat();
			MenuManager.Instance.ShowMessage(r);
			return;
		case InvalidReason.NoExports:
			MenuManager.Instance.ShowMessage(r);
			return;
		case InvalidReason.AlreadyAtZeroWorkers:
		case InvalidReason.MaxProductionCapacity:
			workerAssignmentRegion.textFlashAnimation.Run();
			return;
		}
		if (this is ResearchListItem)
		{
			MenuManager.Instance.researchPanel.singleBuildingHeader.AnimateWorkerStat();
		}
		else if (null != parentHeader)
		{
			if (gm.tutorialQuestType == QuestType.AssignWorkersForGeneralStore && r == InvalidReason.NotEnoughBuildings && LocalizationManager.IsEnglish())
			{
				MenuManager.Instance.ShowMessage("Build more Harvester Huts to increase Harvesting Capacity");
			}
			if (parentHeader is CraftingSectionHeader craftingSectionHeader)
			{
				craftingSectionHeader.AnimateTextFlash();
			}
		}
	}

	public virtual void ClearAlertState()
	{
		if (state != null && state.isInAlertState)
		{
			state.isInAlertState = false;
			alert.SetActive(value: false);
			if (gm.gameState == GameState.InGame)
			{
				MenuManager.Instance.OnStateLostAlertDuringGame(state);
			}
		}
	}

	public void UpdateAlertState()
	{
		if (state != null)
		{
			alert.SetActive(state.isInAlertState);
		}
	}

	public virtual void UpdateRegionAvailability()
	{
		lastPointerState = isPointerInsideButton;
		bool flag = true;
		if (null != workerAssignmentRegion)
		{
			workerAssignmentRegion.gameObject.SetActive(GameManager.IsGlobalQuestComplete(QuestType.HouseForHarvesterHut));
			workerAssignmentRegion.SetAutomaticAssignmentAvailable(IsAutomaticAssignmentAvailable());
		}
		if (null != priorityRegion)
		{
			priorityRegion.gameObject.SetActive(IsPriorityAvailable() && flag);
		}
		if (null != autoClaimRegion)
		{
			autoClaimRegion.gameObject.SetActive(GameManager.IsGlobalQuestComplete(QuestType.OmnitempleForAutoClaim) && flag);
		}
		if (null != rateDisplayRegion)
		{
			rateDisplayRegion.gameObject.SetActive(GameManager.IsGlobalQuestComplete(QuestType.HouseForHarvesterHut));
		}
		if (null != productionTargetRegion)
		{
			productionTargetRegion.gameObject.SetActive(GameManager.IsGlobalQuestComplete(QuestType.HarvesterHutForAssignWorkers));
			rateDisplayRegion.UpdateDynamicDisplay();
		}
		if (null != pauseRegion)
		{
			bool flag2 = true;
			if (IsProductionLimitEmbedded())
			{
				flag2 = false;
			}
			pauseRegion.gameObject.SetActive(GameManager.IsGlobalQuestComplete(Quest.UnlockPause) && flag && flag2);
		}
		if (null != skillDisplayRegion)
		{
			skillDisplayRegion.gameObject.SetActive(value: true);
		}
	}

	private bool IsAutomaticAssignmentAvailable()
	{
		if (!workerAssignmentRegion.allowsRepeatAssignment)
		{
			return false;
		}
		if (gm.isAutoAssignDefault)
		{
			return true;
		}
		if (state is TradingState)
		{
			return GameManager.IsGlobalQuestComplete(Quest.UnlockAutoBalance);
		}
		if (state is HarvestState)
		{
			return GameManager.IsGlobalQuestComplete(Quest.UnlockAutoBalance);
		}
		_ = state is ResearchState;
		return GameManager.IsGlobalQuestComplete(Quest.UnlockAutoBalance);
	}

	private bool IsPriorityAvailable()
	{
		if (this is ResearchListItem researchListItem && !researchListItem.researchState.IsAvailable())
		{
			return false;
		}
		if (state == null)
		{
			return false;
		}
		return state.parentTown.AllowPriority();
	}

	public void MaximizeParentHeader()
	{
		if (null != parentHeader && parentHeader.layoutManager != null && parentHeader.parentPanel.TryMaximizeAllParents(parentHeader.layoutManager))
		{
			MenuManager.Instance.combinedProductionPanel.isItemAvailabilityStale = true;
		}
	}

	public void ReloadPauseState()
	{
		if (null != pauseRegion)
		{
			ReloadButtonState(pauseRegion.pauseButton, pauseRegion.pauseImage, state.localSettings.pause.value);
			pauseRegion.SetPauseDisplay(state.localSettings.pause.value, state.appliedPauseState);
		}
	}

	public void ReloadAutoClaimState()
	{
		if (null != autoClaimRegion)
		{
			ReloadButtonState(autoClaimRegion.settingButton, autoClaimRegion.settingImage, state.localSettings.autoClaim.value);
			autoClaimRegion.SetDisplayedState(state.localSettings.autoClaim.value, state.appliedAutoClaim ? OverrideState.On : OverrideState.Off);
		}
	}

	public void ReloadRepeatState()
	{
		if (null != workerAssignmentRegion)
		{
			ReloadButtonState(workerAssignmentRegion.automaticAssignButton, workerAssignmentRegion.automaticAssignmentImage, state.localAutoAssign);
			workerAssignmentRegion.automaticAssignmentImage.sprite = (state.appliedAutoAssign ? IconManager.Instance.automaticAssignmentOn : IconManager.Instance.automaticAssignmentOff);
		}
	}

	public void ReloadProductionLimitState()
	{
		if (null != productionTargetRegion)
		{
			productionTargetRegion.SetTargetImage();
		}
	}

	public void ReloadPriorityState()
	{
		if (null != priorityRegion)
		{
			priorityRegion.SetPriorityImage(state.localSettings.priority.value, state.appliedPriority);
		}
	}

	public static void ReloadButtonState(MenuButton button, Image targetImage, OverrideState localState)
	{
		button.isSelected = localState != OverrideState.None;
		if (localState == OverrideState.None)
		{
			targetImage.color = ColorManager.inheritedStateColor;
		}
		else
		{
			targetImage.color = Color.white;
		}
	}

	private void OnAutoAssignRightClicked()
	{
		SoundManager.PlayButtonClickSmall();
		state.parentTown.RemoveFromAllAutoAssignLists(state);
		state.localSettings.autoAssign.ChangeValue(OverrideState.None);
		state.CalcAppliedAutoAssign();
		state.parentTown.AddToAutoAssignPriorityList(state);
		ReloadRepeatState();
	}

	private void OnAutoAssignPopupItemClicked(PopupMenuItem sender)
	{
		MenuManager.Instance.popupMenu.Hide();
		if (sender.loadedObject is OverrideState nextValue)
		{
			state.parentTown.RemoveFromAllAutoAssignLists(state);
			state.localSettings.autoAssign.ChangeValue(nextValue);
			state.CalcAppliedAutoAssign();
			state.parentTown.AddToAutoAssignPriorityList(state);
			ReloadRepeatState();
		}
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

	protected void TryManuallyProduceFromCostGrid(CostGrid grid)
	{
		float num = 1f * GameManager.Instance.MultiplierForGlobalPerk(PerkType.ClickPower);
		if (gm.isExtraActive)
		{
			num *= 3f;
		}
		else if (gm.isExtraIdle)
		{
			num *= 0.5f;
		}
		MenuManager.Instance.pointerDelayCounter = 0f;
		if (state.skill != null)
		{
			float num2 = state.skill.ProductionMultiplier();
			num *= num2;
		}
		rotationTween?.Kill(complete: true);
		scaleTween?.Kill(complete: true);
		float duration = 0.25f;
		float num3 = -0.1f;
		scaleTween = grid.craftArrow.transform.DOPunchScale(new Vector3(num3, num3, num3), duration, 0, 0f);
		rotationTween = grid.craftArrow.transform.DOShakeRotation(duration, new Vector3(0f, 0f, 3f));
		double num4 = 1.0;
		foreach (ItemRateData item in state.output)
		{
			double num5 = item.totalAmount * (double)num;
			double num6 = item.state.maxCount - item.state.currentCount;
			if (!GameUtility.IsNearlyZero(num5))
			{
				double num7 = num6 / num5;
				if (num7 < num4)
				{
					num4 = num7;
				}
			}
		}
		if (num4 <= 0.0)
		{
			RectTransform obj = (RectTransform)grid.craftArrow.transform;
			Vector3 origin = obj.TransformPoint(obj.rect.center);
			MenuManager.Instance.AnimateText("Full".Localized(), origin);
			return;
		}
		foreach (ItemRateData item2 in state.input)
		{
			double num8 = item2.totalAmount * (double)num;
			double currentCount = item2.state.currentCount;
			if (!GameUtility.IsNearlyZero(num8))
			{
				double num9 = currentCount / num8;
				if (num9 < num4)
				{
					num4 = num9;
				}
			}
		}
		if (num4 <= 0.0)
		{
			RectTransform obj2 = (RectTransform)grid.craftArrow.transform;
			Vector3 origin2 = obj2.TransformPoint(obj2.rect.center);
			MenuManager.Instance.AnimateText("LimitedInputAvailable".Localized(), origin2);
			return;
		}
		double num10 = num4 * (double)num;
		foreach (ItemRateData item3 in state.input)
		{
			double num11 = item3.totalAmount * num10;
			item3.state.Subtract(num11);
			if (num11 > item3.state.maxConsumePerSecond)
			{
				item3.state.maxConsumePerSecond = num11;
				item3.state.CalcCapacity();
			}
		}
		foreach (ItemRateData item4 in state.output)
		{
			double num12 = item4.totalAmount * num10;
			item4.state.Add(num12);
			item4.state.townProductionStat?.Add(num12);
			item4.state.globalProductionStat?.Add(num12);
			GameManager.Instance.itemsGainedFromClicking += num12;
		}
		double num13 = (double)num * num4;
		foreach (KeyValuePair<EntityId, CostIcon> inputIcon in grid.inputIcons)
		{
			RectTransform obj3 = (RectTransform)inputIcon.Value.transform;
			Vector3 origin3 = obj3.TransformPoint(obj3.rect.center);
			MenuManager.Instance.AnimateSingleItem(inputIcon.Key, (0.0 - inputIcon.Value.displayedAmount) * num13, origin3);
		}
		EntityId earnedEntity = EntityId.None;
		foreach (KeyValuePair<EntityId, CostIcon> outputIcon in grid.outputIcons)
		{
			RectTransform obj4 = (RectTransform)outputIcon.Value.transform;
			Vector3 origin4 = obj4.TransformPoint(obj4.rect.center);
			MenuManager.Instance.AnimateSingleItem(outputIcon.Key, outputIcon.Value.displayedAmount * num13, origin4);
			if (earnedEntity.type == EntityType.None)
			{
				earnedEntity = outputIcon.Key.GetCopy();
			}
		}
		if (gm.tutorialQuestType == QuestType.WoodForHouse && gm.globalQuests.TryGetValue(gm.tutorialQuestType, out var value) && value.IsReadyToClaim())
		{
			MenuManager.Instance.combinedProductionPanel.ClearFlashingArrows();
		}
		SoundManager.PlayItemGain(earnedEntity);
		Platform.Instance.SetStat(StatType.NumClickables, GameUtility.RoundToInt(GameManager.Instance.itemsGainedFromClicking));
		GameManager.Instance.CheckAchievement(AchievementType.Click1);
		if (state.skill != null)
		{
			double workUnits = 2.0 * num10;
			state.skill.Increment(workUnits);
		}
	}

	private void OnRowClicked()
	{
		MenuManager.Instance.recipeConfigPanel.DisplayForStateManager(state);
	}
}
