using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MenuListPanel
{
	private readonly Dictionary<EntityId, SectionHeader> headers = new Dictionary<EntityId, SectionHeader>();

	public Image collapseButtonImage;

	public GameObject inventoryListItemPrefab;

	public SpecifiedFilter specifiedFilter;

	public SectionHeaderSearch sectionHeaderSearch;

	public RectTransform filterRegion;

	private List<RecipeState> secondaryRecipeFilter = new List<RecipeState>();

	[NonSerialized]
	public float inventoryItemHeight;

	private bool isFilterStale;

	public MenuButton filterDecreasing;

	public MenuButton filterIncreasing;

	public GameObject columnModeRegion;

	public MenuButton columnModeSingle;

	public MenuButton columnModeDouble;

	public MenuButton headerNavigationButton;

	public MenuButton headerButton;

	public const bool ShowCurrenciesWhenMinimized = false;

	public const bool ShowAnyCurrencies = false;

	[NonSerialized]
	public bool isMinimized;

	[NonSerialized]
	public int columnMode;

	private float filterRefreshCooldown;

	public StateManager filter { get; private set; }

	public override void Show()
	{
		base.Show();
		if (panelType == MenuPanelType.InventoryPopup)
		{
			MenuPanel.m.inventoryPanel.headerNavigationButton.isSelected = true;
		}
	}

	public void FormatAsPopup()
	{
		panelBackgroundImage.enabled = true;
	}

	public override void Hide()
	{
		base.Hide();
		if (panelType == MenuPanelType.InventoryPopup)
		{
			MenuPanel.m.inventoryPanel.headerNavigationButton.isSelected = false;
		}
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		sectionHeaderSearch.ReloadLabels();
		sectionHeaderSearch.UpdateSearchDisplay();
		foreach (KeyValuePair<EntityId, SectionHeader> header in headers)
		{
			header.Value.primaryLabel.text = TextDisplay.LabelForEntity(header.Key);
		}
	}

	public string SingleColumnTooltip()
	{
		if (LocalizationManager.IsEnglish())
		{
			return "Single Column";
		}
		return null;
	}

	public string DoubleColumnTooltip()
	{
		if (LocalizationManager.IsEnglish())
		{
			return "Double Column";
		}
		return null;
	}

	public void UpdateFilterHeader()
	{
		if (isMinimized)
		{
			sectionHeaderSearch.gameObject.SetActive(value: false);
		}
		else if (filter != null || specifiedFilter != SpecifiedFilter.None)
		{
			sectionHeaderSearch.gameObject.SetActive(value: true);
			((RectTransform)scrollRect.transform).SetTop(80f);
		}
		else
		{
			sectionHeaderSearch.gameObject.SetActive(value: false);
			((RectTransform)scrollRect.transform).SetTop(36f);
		}
		sectionHeaderSearch.UpdateSearchDisplay();
	}

	public void UpdateHeaderAvailability()
	{
		UpdateFilterHeader();
		foreach (SectionHeader value in headers.Values)
		{
			value.gameObject.SetActive(value.layoutManager.isValid && !value.layoutManager.isSuppressed);
		}
	}

	public override void ExpandAllVisible()
	{
		base.ExpandAllVisible();
		foreach (SectionHeader value in headers.Values)
		{
			TryExpandHeader(value);
		}
	}

	private void GetCategoryHeader(Specialty specialty)
	{
		GetCategoryHeader(EntityId.FromSpecialty(specialty));
	}

	public int NumColumns()
	{
		if (panelType == MenuPanelType.InventoryPopup)
		{
			return 4;
		}
		if (columnMode > 0)
		{
			return columnMode;
		}
		return 2;
	}

	private void GetCategoryHeader(EntityId id)
	{
		SectionHeader sectionHeader = MenuManager.InstantiatedSimpleSectionHeader(layoutGroup.transform, null);
		headers[id] = sectionHeader;
		primaryLayoutManager.AddChildManagerWithHeight(sectionHeader.layoutManager, id, 36f);
		sectionHeader.layoutManager.numColumns = NumColumns();
		sectionHeader.parentPanel = this;
	}

	protected override void UpdateSimulationDisplay()
	{
		base.UpdateSimulationDisplay();
		if (specifiedFilter != SpecifiedFilter.None)
		{
			filterRefreshCooldown -= TimeManager.SimulationDelta;
			if (filterRefreshCooldown <= 0f)
			{
				filterRefreshCooldown = 1f;
				isTownLayoutStale = true;
				isFilterStale = true;
			}
		}
	}

	protected override void UpdateDynamicDisplay()
	{
		base.UpdateDynamicDisplay();
		if (isFilterStale)
		{
			PerformUpdateItemAvailability();
		}
		if (MenuManager.Instance.townStatsPanel.useFrequentQuestUpdates)
		{
			UpdateSimulationDisplay();
		}
	}

	public override void PerformUpdateItemAvailability()
	{
		base.PerformUpdateItemAvailability();
		if (isMinimized)
		{
			filterIncreasing.gameObject.SetActive(value: false);
			filterDecreasing.gameObject.SetActive(value: false);
		}
		else
		{
			filterIncreasing.gameObject.SetActive(value: true);
			filterDecreasing.gameObject.SetActive(value: true);
			filterIncreasing.isSelected = specifiedFilter == SpecifiedFilter.PositiveGrowth;
			filterDecreasing.isSelected = specifiedFilter == SpecifiedFilter.NegativeGrowth;
		}
		isFilterStale = false;
	}

	protected override bool ShouldItemBeValid(object obj)
	{
		return true;
	}

	protected override bool ShouldLayoutGroupBeValid(LayoutManager layoutManager)
	{
		return layoutManager.hasValidChildren;
	}

	public void SetOverrideFilter(BuildingCategory f)
	{
	}

	private bool PassesFilter(ConsumableState testState)
	{
		if (specifiedFilter == SpecifiedFilter.PositiveGrowth && testState.perSecondAttemptedDelta <= 0.0)
		{
			return false;
		}
		if (specifiedFilter == SpecifiedFilter.NegativeGrowth && testState.perSecondAttemptedDelta >= 0.0)
		{
			return false;
		}
		if (filter == null)
		{
			return true;
		}
		if (false)
		{
			foreach (RecipeState item in secondaryRecipeFilter)
			{
				foreach (ItemRateData item2 in item.output)
				{
					if (item2.state == testState)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	public override bool IsFixedPosition()
	{
		return true;
	}

	public override void ResetPanel()
	{
		headerCollapseManager.Reset();
		isMinimized = false;
		if (panelType == MenuPanelType.InventoryPopup && MenuManager.CategoryForMenu(panelType) == PanelCategory.FloatingModal)
		{
			header.SetFixed(nextState: false);
			RectTransform component = GetComponent<RectTransform>();
			component.anchorMin = new Vector2(0.5f, 0.5f);
			component.anchorMax = new Vector2(0.5f, 0.5f);
			component.pivot = new Vector2(0.5f, 0.5f);
			component.SetWidth(800f);
			component.SetHeight(800f);
		}
	}

	public override void Initialize()
	{
		base.Initialize();
		sectionHeaderSearch.Initialize();
		sectionHeaderSearch.isInventory = true;
		primaryLayoutManager.areChildRecordsPersistent = true;
		RemoveAutoLayout();
		columnModeSingle.AddPointerClickTrigger(OnColumnModeSinglePressed);
		columnModeDouble.AddPointerClickTrigger(OnColumnModeDoublePressed);
		columnModeSingle.buttonState = CustomButtonState.Background;
		columnModeDouble.buttonState = CustomButtonState.Background;
		columnModeSingle.highlightTextDelegate = SingleColumnTooltip;
		columnModeDouble.highlightTextDelegate = DoubleColumnTooltip;
		filterDecreasing.AddPointerClickTrigger(OnFilterDecreasingPressed);
		filterIncreasing.AddPointerClickTrigger(OnFilterIncreasingPressed);
		filterDecreasing.buttonState = CustomButtonState.Background;
		filterIncreasing.buttonState = CustomButtonState.Background;
		filterDecreasing.highlightTextDelegate = HighlightTextFilterDecreasing;
		filterIncreasing.highlightTextDelegate = HighlightTextFilterIncreasing;
		headerCollapseManager = new HeaderCollapseManager();
		inventoryItemHeight = 36f;
		if (inventoryListItemPrefab.TryGetComponent<RectTransform>(out var component))
		{
			inventoryItemHeight = component.sizeDelta.y;
		}
		headerNavigationButton.tooltipEntity = EntityId.FromMenuPanel(MenuPanelType.Inventory);
		if (panelType == MenuPanelType.Inventory)
		{
			if (null != headerNavigationButton)
			{
				headerNavigationButton.InitializeButton();
				headerNavigationButton.AddPointerClickTrigger(MenuManager.Instance.OnInventoryNavigationPressed);
			}
			headerButton.InitializeButton();
			headerButton.AddPointerClickTrigger(OnHeaderPressed);
			headerButton.buttonState = CustomButtonState.Background;
			if (header.TryGetComponent<Image>(out var component2))
			{
				component2.raycastTarget = false;
				component2.enabled = false;
			}
		}
		else
		{
			header.SetFixed(nextState: false);
			headerButton.gameObject.SetActive(value: false);
			((RectTransform)header.transform).SetHeight(40f);
			collapseButtonImage.gameObject.SetActive(value: false);
			((RectTransform)headerNavigationButton.transform).SetLeft(3f);
			headerNavigationButton.GetComponent<Image>().enabled = false;
			filterRegion.SetPosX(-40f);
			if (header.TryGetComponent<Image>(out var component3))
			{
				component3.color = Color.black;
			}
		}
	}

	private string HighlightTextFilterDecreasing()
	{
		return "Decreasing".Localized();
	}

	private string HighlightTextFilterIncreasing()
	{
		return "Increasing".Localized();
	}

	private void OnFilterIncreasingPressed()
	{
		if (specifiedFilter == SpecifiedFilter.PositiveGrowth)
		{
			specifiedFilter = SpecifiedFilter.None;
		}
		else
		{
			specifiedFilter = SpecifiedFilter.PositiveGrowth;
			filter = null;
			filterRefreshCooldown = 0f;
		}
		isTownLayoutStale = true;
		isFilterStale = true;
	}

	private void OnFilterDecreasingPressed()
	{
		if (specifiedFilter == SpecifiedFilter.NegativeGrowth)
		{
			specifiedFilter = SpecifiedFilter.None;
		}
		else
		{
			specifiedFilter = SpecifiedFilter.NegativeGrowth;
			filterRefreshCooldown = 0f;
			filter = null;
		}
		isTownLayoutStale = true;
		isFilterStale = true;
	}

	protected override MonoBehaviour CreateListItemForPool()
	{
		InventoryListItem component = MenuManager.GetMenuObject(inventoryListItemPrefab, layoutGroup.transform).GetComponent<InventoryListItem>();
		component.LoadSelectionManager(selectionManager);
		component.Initialize();
		return component;
	}

	public override void CreateItems()
	{
		base.CreateItems();
		GetCategoryHeader(Specialty.Currencies);
		GetCategoryHeader(Specialty.NaturalResources);
		GetCategoryHeader(Specialty.Crops);
		GetCategoryHeader(Specialty.Minerals);
		GetCategoryHeader(Specialty.Construction);
		GetCategoryHeader(Specialty.AnimalProducts);
		GetCategoryHeader(Specialty.PlantProducts);
		GetCategoryHeader(Specialty.Gourmet);
		GetCategoryHeader(Specialty.Clothing);
		GetCategoryHeader(Specialty.Jewelry);
		GetCategoryHeader(Specialty.Metal);
		GetCategoryHeader(Specialty.Energy);
		GetCategoryHeader(Specialty.Knowledge);
		GetCategoryHeader(Specialty.Medicine);
		GetCategoryHeader(Specialty.Tech);
		GetCategoryHeader(Specialty.Magic);
		GetCategoryHeader(Specialty.Enchanting);
		GetCategoryHeader(EntityId.FromItem(ItemType.UtilityInput));
		GetCategoryHeader(EntityId.FromItem(ItemType.UtilityOutput));
		GetCategoryHeader(EntityId.FromItem(ItemType.UtilityStorage));
		GetCategoryHeader(EntityId.FromItem(ItemType.UtilityTradeLocal));
		GetCategoryHeader(EntityId.FromItem(ItemType.UtilityTradeGlobal));
	}

	public override void CreateLayoutForActiveTown()
	{
		base.CreateLayoutForActiveTown();
		UpdateColumnModeSelection();
		_ = isMinimized;
		if (filter == null)
		{
			foreach (KeyValuePair<NaturalResource, ResourceState> naturalResource in displayedTown.naturalResources)
			{
				if (!naturalResource.Value.isLocked && PassesFilter(naturalResource.Value))
				{
					EntityId category = EntityId.FromSpecialty(Specialty.NaturalResources);
					AddInventoryItem(naturalResource.Value, category);
				}
			}
			{
				foreach (KeyValuePair<ItemType, ItemState> item in displayedTown.inventory)
				{
					if (!item.Value.isLocked && PassesFilter(item.Value) && item.Key != ItemType.TownExperiencePoint)
					{
						if (Item.IsCurrency(item.Key))
						{
							AddInventoryItem(item.Value, EntityId.FromSpecialty(Specialty.Currencies));
						}
						if (Crafting.cachedItemDefs.TryGetValue(item.Key, out var value))
						{
							EntityId category2 = EntityId.FromSpecialty(value.specialty);
							AddInventoryItem(item.Value, category2);
						}
					}
				}
				return;
			}
		}
		if (filter is TradingState tradingState)
		{
			AddInventoryItem(tradingState.localItemState, EntityId.FromItem(ItemType.UtilityTradeLocal));
			AddInventoryItem(tradingState.globalWarehouseState, EntityId.FromItem(ItemType.UtilityTradeGlobal));
			return;
		}
		foreach (ItemRateData item2 in filter.input)
		{
			EntityId category3 = EntityId.FromItem(ItemType.UtilityInput);
			AddInventoryItem(item2.state, category3);
		}
		foreach (ItemRateData item3 in filter.output)
		{
			EntityId category4 = EntityId.FromItem(ItemType.UtilityOutput);
			AddInventoryItem(item3.state, category4);
		}
		if (!(filter is ConstructionState { parentBuildingState: not null, parentBuildingState: var parentBuildingState }))
		{
			return;
		}
		if (Crafting.cachedBuildingItemsProduced.TryGetValue(parentBuildingState.type, out var value2))
		{
			foreach (ItemType item4 in value2)
			{
				if (displayedTown.inventory.TryGetValue(item4, out var value3) && !value3.isLocked)
				{
					AddInventoryItem(value3, EntityId.FromItem(ItemType.UtilityOutput));
				}
			}
		}
		if (parentBuildingState.buildingDef.category == BuildingCategory.Storage && Crafting.cachedStorageByBuilding.TryGetValue(parentBuildingState.type, out var value4))
		{
			foreach (EntityId item5 in value4)
			{
				if (item5.TryAsItem(out var i) && displayedTown.inventory.TryGetValue(i, out var value5) && !value5.isLocked)
				{
					AddInventoryItem(value5, EntityId.FromItem(ItemType.UtilityStorage));
				}
			}
		}
		if (parentBuildingState.buildingDef.category == BuildingCategory.Markets)
		{
			foreach (KeyValuePair<ItemType, SellState> marketItem in displayedTown.marketItems)
			{
				if (marketItem.Value.producingBuilding != null && marketItem.Value.producingBuilding == parentBuildingState && displayedTown.inventory.TryGetValue(marketItem.Key, out var value6))
				{
					AddInventoryItem(value6, EntityId.FromItem(ItemType.UtilityOutput));
				}
			}
		}
		if (parentBuildingState.buildingDef.category != BuildingCategory.Trading || parentBuildingState.type == BuildingType.TradingPost || parentBuildingState.type == BuildingType.TradingPost)
		{
			return;
		}
		foreach (KeyValuePair<ItemType, TradingState> item6 in displayedTown.trading)
		{
			if (item6.Value.producingBuilding != null && item6.Value.producingBuilding == parentBuildingState && displayedTown.inventory.TryGetValue(item6.Key, out var value7))
			{
				AddInventoryItem(value7, EntityId.FromItem(ItemType.UtilityOutput));
			}
		}
	}

	protected override void AssignKeyToItem(object key, MonoBehaviour item)
	{
		if (!(key is KeyPair keyPair) || !(item is InventoryListItem inventoryListItem))
		{
			return;
		}
		ItemType i2;
		if (keyPair.key2.TryAsNaturalResource(out var i))
		{
			if (displayedTown.naturalResources.TryGetValue(i, out var value))
			{
				inventoryListItem.LoadState(value);
			}
		}
		else if (keyPair.key2.TryAsItem(out i2))
		{
			ItemState value3;
			if (keyPair.key1.TryAsItem(out var i3) && i3 == ItemType.UtilityTradeGlobal)
			{
				if (MenuPanel.gm.globalInventory.TryGetValue(i2, out var value2))
				{
					inventoryListItem.LoadState(value2);
				}
			}
			else if (displayedTown.inventory.TryGetValue(i2, out value3))
			{
				inventoryListItem.LoadState(value3);
			}
		}
		inventoryListItem.OnStateAssignmentChanged();
	}

	private void AddInventoryItem(CountableState state, EntityId category)
	{
		if (!(state is ItemState itemState) || !Item.IsCurrency(itemState.type))
		{
			KeyPair keyPair = new KeyPair(category, state.AsEntity());
			if (headers.TryGetValue(category, out var value))
			{
				value.layoutManager.AddItemWithHeight(keyPair, inventoryItemHeight);
			}
		}
	}

	public override bool ShouldBeAvailable()
	{
		return true;
	}

	public void SetFilter(StateManager state)
	{
		if (state != null)
		{
			specifiedFilter = SpecifiedFilter.None;
		}
		filter = state;
		isItemAvailabilityStale = true;
		isTownLayoutStale = true;
		if (state != null)
		{
			flagAutoExpandVisible = true;
		}
		secondaryRecipeFilter.Clear();
		if (state == null || state.output == null)
		{
			return;
		}
		foreach (ItemRateData item in state.output)
		{
			foreach (KeyValuePair<RecipeType, RecipeState> recipe in displayedTown.recipes)
			{
				foreach (ItemRateData item2 in recipe.Value.input)
				{
					if (item2.state == item.state)
					{
						secondaryRecipeFilter.Add(recipe.Value);
					}
				}
			}
		}
	}

	public bool TryGetTransform(ItemType t, out Vector3 result)
	{
		result = layoutGroup.transform.position;
		return true;
	}

	public override void OnSelectionChangedByManager(EntityId id, bool nextState)
	{
		base.OnSelectionChangedByManager(id, nextState);
		TooltipPanel tooltipPanel = MenuManager.Instance.tooltipPanel;
		if (nextState)
		{
			tooltipPanel.LoadEntityProduction(id);
			tooltipPanel.Pin();
		}
		else
		{
			tooltipPanel.Unpin();
		}
	}

	public void OnHeaderPressed()
	{
		isMinimized = !isMinimized;
		MenuPanel.m.UpdateLeftPanelLayouts();
	}

	public void UpdateColumnModeSelection()
	{
		columnModeRegion.gameObject.SetActive(panelType == MenuPanelType.Inventory);
		int num = NumColumns();
		columnModeSingle.isSelected = num == 1;
		columnModeDouble.isSelected = num == 2;
		foreach (LayoutItem childItem in primaryLayoutManager.childItems)
		{
			if (childItem is LayoutManager layoutManager)
			{
				layoutManager.numColumns = num;
			}
		}
	}

	public void OnColumnModeSinglePressed()
	{
		columnMode = 1;
		UpdateColumnModeSelection();
		isTownLayoutStale = true;
	}

	public void OnColumnModeDoublePressed()
	{
		columnMode = 2;
		UpdateColumnModeSelection();
		isTownLayoutStale = true;
	}
}
