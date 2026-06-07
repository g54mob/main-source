using System;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SingleBuildingHeader : MonoBehaviour
{
	public Image iconImage;

	public PriorityRegion priorityRegion;

	public AutoAssignRegion autoAssignRegion;

	public AutoClaimRegion autoClaimRegion;

	public PauseRegion pauseRegion;

	public MenuButton numBuildingsButton;

	public TextMeshProUGUI numBuildingsLabel;

	public TextMeshProUGUI availableLabel;

	public TextMeshProUGUI capacityLabel;

	public MenuButton productionCapacityRegion;

	public MenuButton addBuildingButton;

	public MenuButton removeBuildingButton;

	public TextMeshProUGUI decreaseLabel;

	public TextMeshProUGUI increaseLabel;

	public ProgressBar addBuildingProgressBar;

	private TextFlashAnimation buildingCountFlashAnimation;

	private TextFlashAnimation numAvailableFlashAnimation;

	private BuildingState loadedBuildingState;

	private AssignableState loadedSettings;

	private MenuPanel parentPanel;

	private IncrementDisplayManager incrementDisplayManager;

	public ProductionTargetRegion productionTargetRegion;

	private int lastDisplayedProductionCapacityHash;

	[NonSerialized]
	public Town displayedTown;

	public void Initialize(MenuPanel sourcePanel)
	{
		parentPanel = sourcePanel;
		numBuildingsButton.AddPointerClickTrigger(OnNumBuildingsClicked);
		priorityRegion.Initialize(OnPriorityChanged);
		buildingCountFlashAnimation = new TextFlashAnimation(numBuildingsLabel);
		numAvailableFlashAnimation = new TextFlashAnimation(availableLabel);
		autoAssignRegion.Initialize(OnAutoAssignClicked, OnAutoAssignChanged);
		if (null != autoClaimRegion)
		{
			autoClaimRegion.settingButton.AddPointerClickTrigger(OnAutoClaimClicked);
			autoClaimRegion.settingButton.buttonState = CustomButtonState.Background;
			autoClaimRegion.settingButton.highlightTextDelegate = HighlightTextAutoRestart;
		}
		addBuildingButton.AddPointerClickTrigger(OnAddButtonPressed);
		removeBuildingButton.AddPointerClickTrigger(OnRemoveButtonPressed);
		incrementDisplayManager = new IncrementDisplayManager(increaseLabel, decreaseLabel);
		productionCapacityRegion.highlightTextDelegate = ProductionHighlightText;
		productionCapacityRegion.AddRightClickTrigger(OnProductionCapacityRightClicked);
		if (null != pauseRegion)
		{
			pauseRegion.Initialize(OnPauseClicked);
		}
		if (null != productionTargetRegion)
		{
			productionTargetRegion.InitializeAsStandaloneButton();
			productionTargetRegion.onLimitChangedDelegate = OnProductionLimitChanged;
			productionTargetRegion.onPauseChangedDelegate = OnPauseClicked;
			if (sourcePanel.panelType == MenuPanelType.Research)
			{
				productionTargetRegion.gameObject.SetActive(value: false);
			}
		}
	}

	public void LoadState(BuildingState buildingState)
	{
		loadedBuildingState = buildingState;
		loadedSettings = buildingState.settings;
		iconImage.sprite = IconManager.SpriteForEntity(buildingState.AsEntity());
		priorityRegion.displayedSettings = loadedSettings;
		pauseRegion.displayedSettings = loadedSettings;
		autoAssignRegion.displayedSettings = loadedSettings;
		if (null != productionTargetRegion)
		{
			productionTargetRegion.displayedSettings = buildingState.settings;
		}
	}

	public void UpdateConstructionDisplay()
	{
		BuildingState buildingState = loadedBuildingState;
		if (buildingState != null && buildingState.pendingConstructions > 0)
		{
			if (!addBuildingProgressBar.gameObject.activeSelf)
			{
				addBuildingProgressBar.gameObject.SetActive(value: true);
			}
			addBuildingProgressBar.slider.value = GameUtility.AsFloat(buildingState.constructionState.unitProgress);
		}
		else if (addBuildingProgressBar.gameObject.activeSelf)
		{
			addBuildingProgressBar.gameObject.SetActive(value: false);
		}
	}

	public void UpdatePauseDisplay()
	{
		pauseRegion.gameObject.SetActive(value: true);
		pauseRegion.SetPauseDisplay(loadedSettings.pause.value == OverrideState.On);
	}

	public void UpdateAutoAssignDisplay()
	{
		bool active = false;
		switch (parentPanel.panelType)
		{
		case MenuPanelType.Research:
			active = GameManager.IsGlobalQuestComplete(Quest.UnlockAutoBalance);
			break;
		case MenuPanelType.Harvesting:
			active = GameManager.IsGlobalQuestComplete(Quest.UnlockAutoBalance);
			break;
		case MenuPanelType.Trading:
			active = GameManager.IsGlobalQuestComplete(Quest.UnlockAutoBalance);
			break;
		}
		autoAssignRegion.gameObject.SetActive(active);
		autoAssignRegion.SetDisplayedState(loadedSettings.autoAssign.value == OverrideState.On);
	}

	public void UpdateAutoClaimDisplay()
	{
		if (null != autoClaimRegion)
		{
			bool active = GameManager.IsGlobalQuestComplete(QuestType.OmnitempleForAutoClaim);
			autoClaimRegion.gameObject.SetActive(active);
			autoClaimRegion.SetDisplayedState(loadedSettings.autoClaim.value == OverrideState.On);
		}
	}

	public void UpdateProductionLimitDisplay()
	{
		productionTargetRegion.SetTargetImage(loadedSettings.productionLimit.type);
	}

	public void UpdatePriorityDisplay()
	{
		priorityRegion.gameObject.SetActive(displayedTown.AllowPriority());
		priorityRegion.SetPriorityImage(loadedSettings.craftingGroupPriority);
	}

	private void OnAutoAssignClicked()
	{
		loadedSettings.CycleAutoAssign();
		autoAssignRegion.SetDisplayedState(loadedSettings.autoAssign.value == OverrideState.On);
		OnAutoAssignChanged();
	}

	private void OnAutoAssignChanged()
	{
		loadedBuildingState.parentTown.CalcAllAutoAssign();
		parentPanel.isAutoAssignStale = true;
		MenuManager.Instance.isTooltipStale = true;
	}

	private void OnAutoClaimClicked()
	{
		loadedSettings.CycleAutoClaim();
		autoClaimRegion.SetDisplayedState(loadedSettings.autoClaim.value == OverrideState.On);
		loadedBuildingState.parentTown.CalcAllAutoClaim();
		parentPanel.isAutoClaimStale = true;
		MenuManager.Instance.isTooltipStale = true;
	}

	private void OnNumBuildingsClicked()
	{
		MenuManager.Instance.NavigateToCountableState(loadedBuildingState);
	}

	private void OnPauseClicked()
	{
		displayedTown.CalcAllPause();
		parentPanel.isPauseStale = true;
		MenuManager.Instance.isTooltipStale = true;
	}

	private void OnPriorityChanged()
	{
		displayedTown.OnPriorityChanged(loadedBuildingState);
		parentPanel.isPriorityStale = true;
		MenuManager.Instance.isTooltipStale = true;
	}

	public void OnAddButtonPressed()
	{
		BuildingState buildingState = loadedBuildingState;
		if (buildingState != null)
		{
			bool flag = false;
			for (int i = 0; i < UserInput.activeGlobalIncrement; i++)
			{
				flag |= buildingState.TryConstruct();
			}
			if (flag)
			{
				UpdateBuildingData();
			}
		}
	}

	public void OnRemoveButtonPressed()
	{
		if (removeBuildingButton.invalidReason != InvalidReason.None)
		{
			MenuManager.Instance.ShowMessage(removeBuildingButton.invalidReason);
			return;
		}
		BuildingState buildingState = loadedBuildingState;
		if (buildingState != null)
		{
			buildingState.TryRemoveConstruction();
			ReloadLabels();
		}
	}

	public void UpdateDynamicDisplay()
	{
		numAvailableFlashAnimation.UpdateAnimation();
		buildingCountFlashAnimation?.UpdateAnimation();
		incrementDisplayManager.UpdateDynamicDisplay(UserInput.activeGlobalIncrement);
		UpdateConstructionDisplay();
		if (CalcProductionCapacityHashChange())
		{
			UpdateProductionCapacityLabel();
		}
	}

	public void ReloadLabels()
	{
		if (loadedBuildingState != null)
		{
			string arg = TextDisplay.LabelForEntity(loadedBuildingState.AsEntity(), tryPlural: true);
			string format = TextDisplay.CurrentLanguageKeyValueFormat();
			BuildingState buildingState = loadedBuildingState;
			if (buildingState != null && buildingState.pendingConstructions > 0)
			{
				numBuildingsLabel.text = string.Format(TextDisplay.KeyValueFormatSpaced, arg, TextDisplay.LocalizedNumber(loadedBuildingState.currentCount) + " +" + TextDisplay.LocalizedNumber(buildingState.pendingConstructions));
			}
			else
			{
				numBuildingsLabel.text = string.Format(TextDisplay.KeyValueFormatSpaced, arg, TextDisplay.LocalizedNumber(loadedBuildingState.currentCount));
			}
			if (parentPanel.panelType == MenuPanelType.Harvesting)
			{
				capacityLabel.transform.parent.gameObject.SetActive(value: false);
			}
			else if (LocalizationManager.IsEnglish())
			{
				capacityLabel.transform.parent.gameObject.SetActive(value: true);
				double value = loadedBuildingState.Capacity();
				capacityLabel.text = string.Format(format, "Capacity", TextDisplay.LocalizedNumber(value));
			}
			else
			{
				capacityLabel.transform.parent.gameObject.SetActive(value: false);
			}
			UpdateProductionCapacityLabel();
		}
	}

	private bool CalcProductionCapacityHashChange()
	{
		int num = 0;
		if (loadedBuildingState != null)
		{
			num = loadedBuildingState.GetProductionCapacityHash();
		}
		if (num != lastDisplayedProductionCapacityHash)
		{
			lastDisplayedProductionCapacityHash = num;
			return true;
		}
		return false;
	}

	public void UpdateBuildingData()
	{
		if (loadedBuildingState != null)
		{
			UpdateConstructionDisplay();
			if (parentPanel.panelType == MenuPanelType.Harvesting)
			{
				capacityLabel.transform.parent.gameObject.SetActive(value: false);
				addBuildingButton.gameObject.SetActive(value: false);
				addBuildingProgressBar.gameObject.SetActive(value: false);
				removeBuildingButton.gameObject.SetActive(value: false);
			}
			ReloadLabels();
			BuildingState buildingState = loadedBuildingState;
			if (buildingState != null)
			{
				buildingState.CacheRemovalState(UserInput.activeGlobalIncrement);
				buildingState.FormatAddButton(addBuildingButton);
				buildingState.FormatRemoveButton(removeBuildingButton);
			}
		}
	}

	public void UpdateProductionCapacityLabel()
	{
		if (loadedBuildingState != null)
		{
			double numAvailable = loadedBuildingState.numAvailable;
			double totalProductionCapacity = loadedBuildingState.totalProductionCapacity;
			lastDisplayedProductionCapacityHash = loadedBuildingState.GetProductionCapacityHash();
			if (numAvailable <= 0.0)
			{
				availableLabel.color = Color.yellow;
			}
			else
			{
				availableLabel.color = Color.white;
			}
			TextDisplay.SetNumber(availableLabel, numAvailable);
			StringBuilder pooledStringBuilder = GameUtility.GetPooledStringBuilder();
			pooledStringBuilder.Append('/');
			pooledStringBuilder.Append(' ');
			pooledStringBuilder.Append(TextDisplay.LocalizedNumber(totalProductionCapacity));
			capacityLabel.SetText(pooledStringBuilder);
			GameUtility.ReturnToPool(pooledStringBuilder);
		}
		else
		{
			lastDisplayedProductionCapacityHash = 0;
			availableLabel.text = string.Empty;
			capacityLabel.text = string.Empty;
		}
	}

	public void AnimateWorkerStat()
	{
		buildingCountFlashAnimation.Run();
		numAvailableFlashAnimation.Run();
	}

	private string HighlightTextAutoRestart()
	{
		string localizedValue = ((loadedSettings.autoClaim.value == OverrideState.On) ? "On".Localized() : "Off".Localized());
		return TextDisplay.FormattedKeyValue("ClaimAutomatically", localizedValue);
	}

	private void OnProductionLimitChanged()
	{
		displayedTown.CalcAllProductionLimits();
		parentPanel.isProductionLimitStale = true;
	}

	private void OnProductionCapacityRightClicked()
	{
		PopupMenu popupMenu = MenuManager.Instance.ShowPopupMenu((RectTransform)productionCapacityRegion.transform);
		string text = "RemoveAll".Localized();
		popupMenu.AddLabelButton(text, null, OnRemoveCapacityClicked);
		popupMenu.ResizeHeight();
	}

	private string ProductionHighlightText()
	{
		return TextDisplay.ProductionHighlightText(useWorkers: false);
	}

	private void OnRemoveCapacityClicked(PopupMenuItem sender)
	{
		if (loadedBuildingState.settings.autoAssign.value == OverrideState.On)
		{
			loadedBuildingState.settings.autoAssign.ChangeValue(OverrideState.None);
			OnAutoAssignChanged();
		}
		foreach (StateManager dependentState in loadedBuildingState.dependentStates)
		{
			dependentState.OnNumWorkersChanged(0f);
		}
		MenuManager.Instance.popupMenu.Hide();
	}
}
