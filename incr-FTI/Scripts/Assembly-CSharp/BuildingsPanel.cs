using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildingsPanel : MenuListPanel
{
	public GameObject buildingListItemPrefab;

	public TextMeshProUGUI headerLabel;

	public PauseRegion pauseRegion;

	public PriorityRegion priorityRegion;

	public PanelHeader panelHeader;

	public bool areCountsStale;

	public bool isHousingPlotDataStale;

	private readonly Dictionary<BuildingCategory, SectionHeader> headers = new Dictionary<BuildingCategory, SectionHeader>(new BuildingCategoryEqualityComparer());

	private TextFlashAnimation landFlashAnimation;

	private int buildingJumpCountdown;

	public override void Initialize()
	{
		base.Initialize();
		panelHeader.Initialize();
		primaryLayoutManager.areChildRecordsPersistent = true;
		headerCollapseManager = new HeaderCollapseManager();
		RemoveAutoLayout();
		landFlashAnimation = new TextFlashAnimation(panelHeader.countLabel);
		panelHeader.iconImage.sprite = IconManager.Instance.land;
		pauseRegion.Initialize(OnPauseChanged);
		priorityRegion.Initialize(OnPriorityChanged);
	}

	public override void Show()
	{
		base.Show();
		MenuPanel.m.navigationPanel.buildingsButton.isSelected = true;
	}

	public override void Hide()
	{
		base.Hide();
		MenuPanel.m.navigationPanel.buildingsButton.isSelected = false;
	}

	private void OnPauseChanged()
	{
		displayedTown.CalcAllPause();
		isPauseStale = true;
		MenuPanel.m.isTooltipStale = true;
	}

	private void OnPriorityChanged()
	{
		displayedTown.OnPriorityChanged(displayedTown.constructionSettings);
		isPriorityStale = true;
		MenuPanel.m.isTooltipStale = true;
	}

	public override void UpdatePauseDisplay()
	{
		base.UpdatePauseDisplay();
		pauseRegion.SetPauseDisplay(displayedTown.constructionSettings.pause.value == OverrideState.On);
	}

	public override void UpdatePriorityDisplay()
	{
		base.UpdatePriorityDisplay();
		priorityRegion.gameObject.SetActive(displayedTown.AllowPriority());
		priorityRegion.SetPriorityImage(displayedTown.constructionSettings.priority.value);
	}

	protected override void ApplyStateAnimations()
	{
		foreach (BuildingListItem value in visibleListItems.Values)
		{
			value.createBuildingButton.AnimateInstant();
		}
	}

	private void UpdateHousingPlotsDisplay()
	{
		TextDisplay.SetNumber(panelHeader.countLabel, displayedTown.unusedHousingPlots);
		isHousingPlotDataStale = false;
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		headerLabel.text = "Buildings".Localized();
		foreach (KeyValuePair<BuildingCategory, SectionHeader> header in headers)
		{
			header.Value.ReloadLabels();
		}
		panelHeader.primaryLabel.text = "AvailableLand".Localized();
	}

	protected override void UpdateDynamicDisplay()
	{
		base.UpdateDynamicDisplay();
		landFlashAnimation.UpdateAnimation();
		if (isHousingPlotDataStale)
		{
			UpdateHousingPlotsDisplay();
		}
		if (areCountsStale)
		{
			UpdateCounts();
		}
	}

	protected override bool ShouldItemBeValid(object obj)
	{
		if (obj is BuildingState buildingState)
		{
			return buildingState.availability == BuildObjectAvailability.Available;
		}
		return false;
	}

	public void UpdateHeaderAvailability()
	{
		foreach (SectionHeader value in headers.Values)
		{
			value.gameObject.SetActive(value.layoutManager.isValid);
		}
	}

	public void UpdateStaticDisplayForListItem(BuildingType t)
	{
		if (displayedTown.buildings.TryGetValue(t, out var value) && visibleListItems.TryGetValue(value, out var value2) && value2 is BuildingListItem buildingListItem)
		{
			buildingListItem.UpdateCountsAndCost();
		}
	}

	public void UpdateCounts()
	{
		foreach (BuildingListItem value in visibleListItems.Values)
		{
			value.UpdateCount();
		}
		areCountsStale = false;
	}

	private void GetCategoryHeader(BuildingCategory category)
	{
		string localizationKey = TextDisplay.LocalizationKeyforBuildingCategory(category);
		SectionHeader sectionHeader = MenuManager.InstantiatedSimpleSectionHeader(layoutGroup.transform, localizationKey);
		headers[category] = sectionHeader;
		primaryLayoutManager.AddChildManagerWithHeight(sectionHeader.layoutManager, EntityId.FromCategory(category), simpleHeaderHeight);
		sectionHeader.parentPanel = this;
	}

	public override void CreateLayoutForActiveTown()
	{
		base.CreateLayoutForActiveTown();
		foreach (KeyValuePair<BuildingType, BuildingState> building in displayedTown.buildings)
		{
			SectionHeader sectionHeader = HeaderForItem(building.Key);
			if (null != sectionHeader)
			{
				sectionHeader.layoutManager.AddItemWithHeight(building.Value, itemHeight);
			}
		}
		pauseRegion.displayedSettings = displayedTown.constructionSettings;
		priorityRegion.displayedSettings = displayedTown.constructionSettings;
	}

	public override void CreateItems()
	{
		GetCategoryHeader(BuildingCategory.Housing);
		GetCategoryHeader(BuildingCategory.Harvesting);
		GetCategoryHeader(BuildingCategory.Markets);
		GetCategoryHeader(BuildingCategory.Trading);
		GetCategoryHeader(BuildingCategory.Production);
		GetCategoryHeader(BuildingCategory.Cultivation);
		GetCategoryHeader(BuildingCategory.Prospecting);
		GetCategoryHeader(BuildingCategory.Storage);
		GetCategoryHeader(BuildingCategory.Research);
		base.CreateItems();
	}

	public SectionHeader HeaderForItem(BuildingType t)
	{
		if (Crafting.buildingCache.TryGetValue(t, out var value) && headers.TryGetValue(value.category, out var value2))
		{
			return value2;
		}
		return headers[BuildingCategory.Production];
	}

	protected override MonoBehaviour CreateListItemForPool()
	{
		return CreateCommonListItemForPool(buildingListItemPrefab);
	}

	protected override void AssignKeyToItem(object key, MonoBehaviour item)
	{
		if (key is BuildingState s && item is BuildingListItem buildingListItem)
		{
			buildingListItem.LoadState(s);
			buildingListItem.OnStateAssignmentChanged();
		}
	}

	protected override void AssignParentHeader(LayoutManager manager, MonoBehaviour item)
	{
		if (!(item is CommonListItem commonListItem))
		{
			return;
		}
		foreach (SectionHeader value in headers.Values)
		{
			if (value.layoutManager == manager)
			{
				commonListItem.parentHeader = value;
				break;
			}
		}
	}

	public override void UpdateStaticDisplay()
	{
		base.UpdateStaticDisplay();
		UpdateHousingPlotsDisplay();
		UpdateCounts();
	}

	public override bool ShouldBeAvailable()
	{
		return true;
	}

	public void QueueJumpToBuilding(BuildingType t)
	{
		if (displayedTown.buildings.TryGetValue(t, out var value))
		{
			QueueJumpToItemWithLinkedObject(value);
		}
	}

	protected override bool ShouldLayoutGroupBeValid(LayoutManager layoutManager)
	{
		return layoutManager.hasValidChildren;
	}

	public void JumpToState(StateManager sm)
	{
		if (sm is ConstructionState constructionState)
		{
			QueueJumpToItemWithLinkedObject(constructionState.parentBuildingState);
		}
	}

	public void AnimateLandCount()
	{
		landFlashAnimation.Run();
	}
}
