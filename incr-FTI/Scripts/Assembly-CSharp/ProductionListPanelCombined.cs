using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ProductionListPanelCombined : ProductionListPanel
{
	public GameObject productionListItemPrefab;

	public GameObject marketListItemPrefab;

	public GameObject tradingListItemPrefab;

	private readonly Dictionary<BuildingCategory, SectionHeader> categoryHeaders = new Dictionary<BuildingCategory, SectionHeader>(new BuildingCategoryEqualityComparer());

	private readonly Dictionary<Specialty, TradingPostSectionHeader> tradingPostHeaders = new Dictionary<Specialty, TradingPostSectionHeader>(new SpecialtyEqualityComparer());

	public IObjectPool<MonoBehaviour> productionListItemPool;

	public IObjectPool<MonoBehaviour> marketListItemPool;

	public IObjectPool<MonoBehaviour> tradingListItemPool;

	[NonSerialized]
	public bool isTradeModeStale;

	[SerializeField]
	private LayoutManager _displayedLayoutRoot;

	public BuildingCategory categoryFilter;

	public EntityId entityFilter;

	public object itemFilter;

	public HeaderCollapseManager filteredCollapseManager;

	public SectionHeaderSearch sectionHeaderSearch;

	public bool isHouseCountStale;

	public LayoutManager displayedLayoutRoot
	{
		get
		{
			return _displayedLayoutRoot;
		}
		set
		{
			if (_displayedLayoutRoot != value)
			{
				if (_displayedLayoutRoot != null)
				{
					_displayedLayoutRoot.SetSuppressionRecursively(nextState: false);
					_displayedLayoutRoot.isRoot = false;
				}
				_displayedLayoutRoot = value;
				if (_displayedLayoutRoot != null)
				{
					value.isRoot = true;
					isItemAvailabilityStale = true;
					_displayedLayoutRoot.parentManager?.SetSuppressionRecursively(nextState: true);
				}
			}
		}
	}

	public override void Initialize()
	{
		base.Initialize();
		sectionHeaderSearch.Initialize();
		filteredCollapseManager = new HeaderCollapseManager();
		primaryLayoutManager.areChildRecordsPersistent = true;
		displayedLayoutRoot = primaryLayoutManager;
		productionListItemPool = new ObjectPool<MonoBehaviour>(CreateProductionListItemForPool, base.OnPooledObjectGet, base.OnPooledObjectReleased);
		marketListItemPool = new ObjectPool<MonoBehaviour>(CreateMarketListItemForPool, base.OnPooledObjectGet, base.OnPooledObjectReleased);
		tradingListItemPool = new ObjectPool<MonoBehaviour>(CreateTradingListItemForPool, base.OnPooledObjectGet, base.OnPooledObjectReleased);
	}

	private MonoBehaviour CreateMarketListItemForPool()
	{
		return CreateCommonListItemForPool(marketListItemPrefab);
	}

	private MonoBehaviour CreateTradingListItemForPool()
	{
		return CreateCommonListItemForPool(tradingListItemPrefab);
	}

	private MonoBehaviour CreateProductionListItemForPool()
	{
		return CreateCommonListItemForPool(productionListItemPrefab);
	}

	protected override void UpdateDynamicDisplay()
	{
		base.UpdateDynamicDisplay();
		if (isTradeModeStale)
		{
			UpdateTradeModeDisplay();
		}
		if (isHouseCountStale)
		{
			UpdateHouseCount();
		}
	}

	public void UpdateHouseCount()
	{
		isHouseCountStale = false;
		if (buildingHeaders.TryGetValue(BuildingType.House, out var value))
		{
			value.UpdateProductionCapacityLabel();
		}
	}

	public void SetTopLevelHeadersSuppressed(bool nextState)
	{
		foreach (LayoutItem childItem in primaryLayoutManager.childItems)
		{
			if (childItem is LayoutManager layoutManager)
			{
				layoutManager.SetSuppressedFromRoot(nextState);
			}
		}
	}

	public override void PerformUpdateItemAvailability()
	{
		if (displayedLayoutRoot == primaryLayoutManager && !GameManager.IsGlobalQuestComplete(Quest.DisplayCategoryHeaders))
		{
			displayedLayoutRoot = primaryLayoutManager;
			SetTopLevelHeadersSuppressed(nextState: true);
		}
		base.PerformUpdateItemAvailability();
	}

	public IObjectPool<MonoBehaviour> GetPool(object obj)
	{
		if (obj is SellState)
		{
			return marketListItemPool;
		}
		if (obj is TradingState)
		{
			return tradingListItemPool;
		}
		return productionListItemPool;
	}

	protected override MonoBehaviour GetFromPool(object obj)
	{
		IObjectPool<MonoBehaviour> pool = GetPool(obj);
		MonoBehaviour monoBehaviour = pool.Get();
		if (monoBehaviour is CommonListItem commonListItem)
		{
			commonListItem.parentPool = pool;
		}
		return monoBehaviour;
	}

	protected override bool ShouldLayoutGroupBeValid(LayoutManager layoutManager)
	{
		if (layoutManager.linkedObject == null)
		{
			return false;
		}
		if (layoutManager.linkedObject is BuildingState buildingState)
		{
			if (buildingState.availability != BuildObjectAvailability.Available)
			{
				return false;
			}
			Flag flag = Flag.Unknown;
			if (categoryFilter != BuildingCategory.None && buildingState.buildingDef.category != categoryFilter)
			{
				return false;
			}
			if (MenuManager.isSearchApplied)
			{
				flag = ((itemFilter == null) ? (MenuManager.PassesTextFilter(TextDisplay.LabelForBuilding(buildingState.type)) ? Flag.True : (MenuManager.PassesTextFilter(TextDisplay.LabelforBuildingCategory(buildingState.buildingDef.category)) ? Flag.True : Flag.False)) : Flag.False);
			}
			if (layoutManager == displayedLayoutRoot)
			{
				return true;
			}
			if (displayedLayoutRoot != primaryLayoutManager && !layoutManager.IsChildOf(displayedLayoutRoot))
			{
				return false;
			}
			switch (flag)
			{
			case Flag.True:
				return true;
			case Flag.Unknown:
				return true;
			}
		}
		else if (layoutManager.linkedObject is EntityId { type: EntityType.Specialty } && layoutManager.parentManager.linkedObject is BuildingState { availability: not BuildObjectAvailability.Available })
		{
			return false;
		}
		return layoutManager.hasValidChildren;
	}

	public void ClearFlashingArrows()
	{
		foreach (MonoBehaviour value in visibleListItems.Values)
		{
			if (value is ProductionListItem productionListItem)
			{
				productionListItem.costGrid.SetSpacerFlashing(nextState: false);
			}
		}
	}

	protected override bool ShouldLayoutItemBeValid(LayoutItem layoutItem)
	{
		if (displayedLayoutRoot != primaryLayoutManager && !layoutItem.IsChildOf(displayedLayoutRoot))
		{
			return false;
		}
		if (layoutItem.linkedObject is StateManager stateManager)
		{
			if (stateManager.isLocked)
			{
				return false;
			}
			if (stateManager is TradingState tradingState && tradingState.globalWarehouseState.isLocked)
			{
				return false;
			}
			if (categoryFilter != BuildingCategory.None && stateManager.producingBuilding != null && stateManager.producingBuilding.buildingDef.category != categoryFilter)
			{
				return false;
			}
			return PassesFilter(stateManager);
		}
		return true;
	}

	public override void CreateLayoutForActiveTown()
	{
		base.CreateLayoutForActiveTown();
		foreach (KeyValuePair<BuildingType, CraftingSectionHeader> buildingHeader in buildingHeaders)
		{
			if (buildingHeader.Value.displayedBuilding == null)
			{
				continue;
			}
			LayoutManager layoutManager = buildingHeader.Value.layoutManager;
			for (int i = 0; i < layoutManager.childKeys.Count; i++)
			{
				EntityId entityId = layoutManager.childKeys[i];
				if (entityId.type == EntityType.Generic || entityId.type == EntityType.Specialty)
				{
					continue;
				}
				LayoutItem layoutItem = layoutManager.childItems[i];
				if (buildingHeader.Value.displayedBuilding.buildingDef.isMarket)
				{
					if (displayedTown.marketItems.TryGetValue(entityId.AsItem, out var value))
					{
						layoutItem.linkedObject = value;
					}
				}
				else
				{
					layoutItem.linkedObject = displayedTown.StateForEntity(layoutManager.childKeys[i]);
				}
			}
		}
		foreach (KeyValuePair<Specialty, TradingPostSectionHeader> tradingPostHeader in tradingPostHeaders)
		{
			TradingPostSectionHeader value2 = tradingPostHeader.Value;
			if (displayedTown.tradeSpecialtyConfigs.TryGetValue(tradingPostHeader.Key, out var value3))
			{
				value2.LoadSettings(value3);
			}
			if (value2.layoutManager.childItems.Count > 0)
			{
				continue;
			}
			foreach (TradingState value5 in displayedTown.trading.Values)
			{
				if (value5.cachedTradingSpecialty == tradingPostHeader.Key)
				{
					value2.layoutManager.AddItemWithHeight(value5, itemHeight);
				}
			}
		}
		foreach (KeyValuePair<Specialty, TradingPostSectionHeader> tradingPostHeader2 in tradingPostHeaders)
		{
			LayoutManager layoutManager2 = tradingPostHeader2.Value.layoutManager;
			for (int j = 0; j < layoutManager2.childKeys.Count; j++)
			{
				LayoutItem layoutItem2 = layoutManager2.childItems[j];
				EntityId entityId2 = layoutManager2.childKeys[j];
				if (displayedTown.trading.TryGetValue(entityId2.AsItem, out var value4))
				{
					layoutItem2.linkedObject = value4;
				}
			}
		}
		AddItemsFromTrading(BuildingType.PowerLine);
		AddItemsFromTrading(BuildingType.SteamPipeline);
		AddItemsFromTrading(BuildingType.MagmaPipeline);
		AddItemsFromTrading(BuildingType.OmniPipeline);
	}

	private void AddItemsFromTrading(BuildingType buildingType)
	{
		if (!buildingHeaders.TryGetValue(buildingType, out var value))
		{
			return;
		}
		foreach (TradingState value2 in displayedTown.trading.Values)
		{
			if (value2.producingBuilding == value.displayedBuilding)
			{
				value.layoutManager.AddItemWithHeight(value2, itemHeight);
			}
		}
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		sectionHeaderSearch.ReloadLabels();
		sectionHeaderSearch.UpdateSearchDisplay();
		foreach (KeyValuePair<BuildingCategory, SectionHeader> categoryHeader in categoryHeaders)
		{
			categoryHeader.Value.ReloadLabels();
		}
		foreach (KeyValuePair<Specialty, TradingPostSectionHeader> tradingPostHeader in tradingPostHeaders)
		{
			tradingPostHeader.Value.ReloadLabels();
		}
	}

	public override void CreateItems()
	{
		AddCategoryHeader(BuildingCategory.Housing);
		AddCategoryHeader(BuildingCategory.Cultivation);
		AddCategoryHeader(BuildingCategory.Prospecting);
		AddCategoryHeader(BuildingCategory.Harvesting);
		AddCategoryHeader(BuildingCategory.Production);
		AddCategoryHeader(BuildingCategory.Research);
		AddCategoryHeader(BuildingCategory.Markets);
		AddCategoryHeader(BuildingCategory.Trading);
		AddCategoryHeader(BuildingCategory.Storage);
		foreach (BuildingDef value6 in Crafting.buildingCache.Values)
		{
			AddBuildingHeaderCategorized(value6.type);
		}
		LayoutManager layoutManager = buildingHeaders[BuildingType.TradingPost].layoutManager;
		LayoutManager layoutManager2 = buildingHeaders[BuildingType.ManaPipeline].layoutManager;
		foreach (Specialty tradingSpecialty in Crafting.tradingSpecialties)
		{
			if (tradingSpecialty == Specialty.ElementalCrystals || tradingSpecialty == Specialty.ElementalPower)
			{
				AddTradingCategoryHeader(tradingSpecialty, layoutManager2);
			}
			else
			{
				AddTradingCategoryHeader(tradingSpecialty, layoutManager);
			}
		}
		foreach (KeyValuePair<HarvestRecipeType, HarvestDef> item in Crafting.harvestRecipeCache)
		{
			if (buildingHeaders.TryGetValue(item.Value.producingBuildingType, out var value))
			{
				value.layoutManager.AddEntityWithHeight(EntityId.FromHarvestRecipe(item.Key), itemHeight);
			}
		}
		foreach (KeyValuePair<NaturalResource, FarmingRecipe> item2 in Crafting.prospectingRecipeCache)
		{
			if (buildingHeaders.TryGetValue(item2.Value.producingBuildingType, out var value2))
			{
				value2.layoutManager.AddEntityWithHeight(EntityId.FromMining(item2.Key), itemHeight);
			}
		}
		foreach (KeyValuePair<NaturalResource, FarmingRecipe> item3 in Crafting.farmingRecipeCache)
		{
			if (buildingHeaders.TryGetValue(item3.Value.producingBuildingType, out var value3))
			{
				value3.layoutManager.AddEntityWithHeight(EntityId.FromFarming(item3.Key), itemHeight);
			}
		}
		foreach (KeyValuePair<RecipeType, Recipe> item4 in Crafting.recipeCache)
		{
			if (buildingHeaders.TryGetValue(item4.Value.producingBuildingType, out var value4))
			{
				value4.layoutManager.AddEntityWithHeight(EntityId.FromRecipe(item4.Key), itemHeight);
			}
		}
		foreach (KeyValuePair<ItemType, HouseSellData> houseSellDatum in Crafting.houseSellData)
		{
			if (buildingHeaders.TryGetValue(houseSellDatum.Value.derivedSellBuilding, out var value5))
			{
				value5.layoutManager.AddEntityWithHeight(EntityId.FromItem(houseSellDatum.Key), itemHeight, "Sell " + houseSellDatum.Key);
			}
		}
		base.CreateItems();
	}

	private void AddBuildingHeaderCategorized(BuildingType t)
	{
		if (Crafting.buildingCache.TryGetValue(t, out var value) && categoryHeaders.TryGetValue(value.category, out var value2))
		{
			CraftingSectionHeader craftingSectionHeader = AddBuildingHeader(t, value2.layoutManager);
			craftingSectionHeader.transform.SetSiblingIndex(0);
			craftingSectionHeader.layoutManager.spacing = 0f;
			craftingSectionHeader.layoutManager.childIndent = 52f;
			craftingSectionHeader.layoutManager.areChildRecordsPersistent = true;
			craftingSectionHeader.layoutManager.debug = t == BuildingType.House;
		}
	}

	private void AddTradingCategoryHeader(Specialty specialty, LayoutManager parentLayoutManager)
	{
		string localizationKey = TextDisplay.LocalizationKeyForSpecialty(specialty);
		TradingPostSectionHeader component = MenuManager.GetMenuObject(MenuManager.Instance.tradingPostSectionHeaderPrefab, layoutGroup.transform).GetComponent<TradingPostSectionHeader>();
		component.Initialize();
		component.localizationKey = localizationKey;
		component.transform.SetSiblingIndex(0);
		((RectTransform)component.transform).SetLeft(26f);
		tradingPostHeaders[specialty] = component;
		parentLayoutManager.AddChildManagerWithHeight(component.layoutManager, EntityId.FromSpecialty(specialty), headerHeight);
		component.layoutManager.childIndent = 52f;
		component.layoutManager.areChildRecordsPersistent = specialty != Specialty.UniqueExport && specialty != Specialty.UniqueImport;
		component.parentPanel = this;
	}

	protected override void AssignKeyToItem(object key, MonoBehaviour item)
	{
		if (key is StateManager stateManager)
		{
			if (item is ProductionListItem productionListItem)
			{
				productionListItem.LoadState(stateManager);
				productionListItem.OnStateAssignmentChanged();
			}
			else if (stateManager is SellState state && item is MarketListItem marketListItem)
			{
				marketListItem.LoadState(state);
				marketListItem.OnStateAssignmentChanged();
			}
			else if (stateManager is TradingState state2 && item is TradingListItem tradingListItem)
			{
				tradingListItem.LoadState(state2);
				tradingListItem.OnStateAssignmentChanged();
			}
		}
	}

	public override bool ShouldBeAvailable()
	{
		return true;
	}

	public override void UpdateBuildingData()
	{
		base.UpdateBuildingData();
		foreach (MonoBehaviour value in visibleListItems.Values)
		{
			if (value is ProductionListItem productionListItem)
			{
				productionListItem.UpdateBuildingData();
			}
			else if (value is MarketListItem marketListItem)
			{
				marketListItem.UpdateBuildingData();
			}
			else if (value is TradingListItem tradingListItem)
			{
				tradingListItem.UpdateBuildingData();
			}
		}
	}

	public void QueueJumpToBuilding(BuildingType t)
	{
		if (displayedTown.buildings.TryGetValue(t, out var value))
		{
			QueueJumpToItemWithLinkedObject(value);
		}
	}

	public void JumpToResource(NaturalResource r)
	{
		foreach (HarvestState value in displayedTown.harvesting.Values)
		{
			if (value.def.resourceType == r)
			{
				JumpToState(value);
				return;
			}
		}
		foreach (MiningState value2 in displayedTown.miningItems.Values)
		{
			if (value2.def.resource == r)
			{
				JumpToState(value2);
				return;
			}
		}
		foreach (FarmingState value3 in displayedTown.farmingItems.Values)
		{
			if (value3.recipe.resource == r)
			{
				JumpToState(value3);
				break;
			}
		}
	}

	public override void JumpToState(StateManager sm)
	{
		if (sm.isLocked)
		{
			if (sm is HarvestState harvestState)
			{
				MenuManager.Instance.NavigateToRequirementRecursively(harvestState.resource.unlockRequirements.requirements);
				return;
			}
			if (sm is MiningState miningState)
			{
				MenuManager.Instance.NavigateToRequirementRecursively(miningState.requirements);
				return;
			}
			if (sm is FarmingState farmingState)
			{
				MenuManager.Instance.NavigateToRequirementRecursively(farmingState.requirements);
				return;
			}
			if (sm is RecipeState recipeState)
			{
				MenuManager.Instance.NavigateToRequirementRecursively(recipeState.derivedRequirements);
				return;
			}
		}
		QueueJumpToItemWithLinkedObject(sm);
	}

	public void HighlightRecipesWithOutput(CountableState searchItem)
	{
		foreach (RecipeState value in displayedTown.recipes.Values)
		{
			foreach (ItemRateData item in value.output)
			{
				if (item.state == searchItem)
				{
					QueueJumpToItemWithLinkedObject(value);
					LayoutItem layoutItem = primaryLayoutManager.ChildItemWithLinkedObject(value);
					if (layoutItem != null)
					{
						QueueJumpToItem(layoutItem);
					}
					return;
				}
			}
		}
	}

	public bool TryJumpToOutputItem(ItemType t)
	{
		List<Requirement> list = null;
		foreach (RecipeState value in displayedTown.recipes.Values)
		{
			foreach (ItemRateData item in value.output)
			{
				if (item.state.AsEntity().TryAsItem(out var i) && i == t)
				{
					if (value.producingBuilding != null && value.producingBuilding.availability != BuildObjectAvailability.Available)
					{
						list = value.producingBuilding.unlockRequirements.requirements;
					}
					else if (!value.isLocked)
					{
						QueueJumpToItemWithLinkedObject(value);
						return true;
					}
				}
			}
		}
		if (list != null)
		{
			return MenuManager.Instance.NavigateToRequirementRecursively(list);
		}
		return false;
	}

	private int MinimizationKeyForCategory(BuildingCategory category)
	{
		return (int)(10000 + category);
	}

	private BuildingCategory CategoryForMiniKey(int key)
	{
		return (BuildingCategory)(key - 10000);
	}

	private void AddCategoryHeader(BuildingCategory category)
	{
		string localizationKey = TextDisplay.LocalizationKeyforBuildingCategory(category);
		SectionHeader sectionHeader = MenuManager.InstantiatedSimpleSectionHeaderTall(layoutGroup.transform, localizationKey);
		sectionHeader.transform.SetSiblingIndex(0);
		categoryHeaders[category] = sectionHeader;
		primaryLayoutManager.AddChildManagerWithHeight(sectionHeader.layoutManager, EntityId.FromCategory(category), headerHeight);
		sectionHeader.layoutManager.childIndent = 26f;
		sectionHeader.layoutManager.areChildRecordsPersistent = true;
		sectionHeader.buildingImage.sprite = IconManager.SpriteForBuildingCategory(category);
		sectionHeader.parentPanel = this;
	}

	public void SetTradingHeadersSuppressedFromSearch(bool nextState)
	{
		foreach (TradingPostSectionHeader value in tradingPostHeaders.Values)
		{
			value.layoutManager.SetSuppressedFromSearch(nextState);
		}
	}

	public void SetCategoriesSuppressedFromSearch(bool nextState)
	{
		foreach (SectionHeader value in categoryHeaders.Values)
		{
			value.layoutManager.SetSuppressedFromSearch(nextState);
		}
	}

	public override void UpdateHeaderAvailability()
	{
		if (MenuManager.isSearchApplied)
		{
			sectionHeaderSearch.gameObject.SetActive(value: true);
			((RectTransform)scrollRect.transform).SetTop(45f);
		}
		else
		{
			sectionHeaderSearch.gameObject.SetActive(value: false);
			((RectTransform)scrollRect.transform).SetTop(2f);
		}
		sectionHeaderSearch.UpdateSearchDisplay();
		foreach (TradingPostSectionHeader value in tradingPostHeaders.Values)
		{
			bool flag = value.layoutManager.isValid && !value.layoutManager.isSuppressed && !IsMinimized(value.layoutManager.parentManager);
			value.SetIndentLevel(1.5f);
			value.gameObject.SetActive(flag);
			if (flag)
			{
				value.UpdateMinimizationSprite();
			}
		}
		foreach (SectionHeader value2 in categoryHeaders.Values)
		{
			bool flag2 = value2.layoutManager.isValid && !value2.layoutManager.isSuppressed;
			value2.gameObject.SetActive(flag2);
			if (flag2)
			{
				value2.UpdateMinimizationSprite();
			}
		}
		base.UpdateHeaderAvailability();
		UpdateRootRecursively(primaryLayoutManager);
	}

	private void UpdateRootRecursively(LayoutManager lm)
	{
		_ = displayedLayoutRoot;
	}

	public bool PassesFilter(StateManager sm)
	{
		bool flag = false;
		if (MenuManager.isSearchApplied)
		{
			if (sm == itemFilter)
			{
				return true;
			}
			foreach (ItemRateData item in sm.input)
			{
				if (itemFilter != null)
				{
					if (item.state == itemFilter)
					{
						return true;
					}
					if (itemFilter is StateManager stateManager && flag && stateManager.ContainsInputOrOutput(item.state))
					{
						return true;
					}
				}
				else if (MenuManager.PassesTextFilter(TextDisplay.LabelForState(item.state)))
				{
					return true;
				}
			}
			foreach (ItemRateData item2 in sm.output)
			{
				if (item2.state is ItemState { type: ItemType.TownExperiencePoint })
				{
					continue;
				}
				if (itemFilter != null)
				{
					if (item2.state == itemFilter)
					{
						return true;
					}
					if (itemFilter is StateManager stateManager2 && flag && stateManager2.ContainsInputOrOutput(item2.state))
					{
						return true;
					}
				}
				else if (MenuManager.PassesTextFilter(TextDisplay.LabelForState(item2.state)))
				{
					return true;
				}
			}
			if (sm.producingBuilding != null && itemFilter == null && MenuManager.PassesTextFilter(TextDisplay.LabelForBuilding(sm.producingBuilding.type)))
			{
				return true;
			}
			if (sm is TradingState tradingState && (tradingState.localItemState == itemFilter || tradingState.globalWarehouseState == itemFilter))
			{
				return true;
			}
			return false;
		}
		return true;
	}

	public void SetCategoryFilter(BuildingCategory c)
	{
		isItemAvailabilityStale = true;
		categoryFilter = c;
	}

	public override void UpdatePauseDisplay()
	{
		base.UpdatePauseDisplay();
		foreach (TradingPostSectionHeader value in tradingPostHeaders.Values)
		{
			value.UpdatePauseDisplay();
		}
	}

	public override void UpdateProductionLimitDisplay()
	{
		base.UpdateProductionLimitDisplay();
		foreach (TradingPostSectionHeader value in tradingPostHeaders.Values)
		{
			value.UpdateProductionLimitDisplay();
		}
	}

	public override void UpdatePriorityDisplay()
	{
		base.UpdatePriorityDisplay();
		foreach (TradingPostSectionHeader value in tradingPostHeaders.Values)
		{
			value.UpdatePriorityDisplay();
		}
	}

	public override void UpdateAutoAssignDisplay()
	{
		base.UpdateAutoAssignDisplay();
		foreach (TradingPostSectionHeader value in tradingPostHeaders.Values)
		{
			value.UpdateAutoAssignDisplay();
		}
	}

	public void UpdateTradeModeDisplay()
	{
		foreach (MonoBehaviour value in visibleListItems.Values)
		{
			if (value is TradingListItem tradingListItem)
			{
				tradingListItem.ReloadTradeModeDisplay();
			}
		}
		foreach (TradingPostSectionHeader value2 in tradingPostHeaders.Values)
		{
			value2.ReloadTradeModeDisplay();
		}
		isTradeModeStale = false;
	}

	public void UpdateIfVisible(TradingState ts)
	{
		if (visibleListItems.TryGetValue(ts, out var value) && value is TradingListItem tradingListItem)
		{
			tradingListItem.ReloadTradeModeDisplay();
			tradingListItem.LoadCost();
			tradingListItem.ReloadLabelParent();
		}
	}

	public void ReloadSpecialtyButtons()
	{
		foreach (MonoBehaviour value in visibleListItems.Values)
		{
			if (value is MarketListItem marketListItem)
			{
				marketListItem.UpdateSpecialtyButton();
			}
		}
	}

	public override void AssignHeaderCollapseManager()
	{
		if (categoryFilter != BuildingCategory.None)
		{
			activeHeaderCollapseManager = displayedTown.ConfirmedCollapseManager(categoryFilter);
			if (displayedLayoutRoot != null && activeHeaderCollapseManager.IsMinimized(displayedLayoutRoot.minimizationKey))
			{
				activeHeaderCollapseManager.SetMinimized(displayedLayoutRoot.minimizationKey, next: false);
			}
		}
		else if (MenuManager.isSearchApplied || entityFilter.type != EntityType.None || displayedLayoutRoot != primaryLayoutManager)
		{
			activeHeaderCollapseManager = filteredCollapseManager;
		}
		else
		{
			activeHeaderCollapseManager = headerCollapseManager;
		}
	}

	public void TrySetRootFromBuilding(BuildingType t)
	{
		ClearAllSearchProperties();
		MenuManager.Instance.navigationPanel.SelectBuildingCategory(BuildingCategory.None, sendEvent: false);
		if (buildingHeaders.TryGetValue(t, out var value))
		{
			displayedLayoutRoot = value.layoutManager;
		}
		entityFilter = EntityId.FromBuilding(t);
		MenuManager.Instance.OnSearchPropertiesChanged();
	}

	public void TrySetRootFromCategory(BuildingCategory c)
	{
		if (categoryHeaders.TryGetValue(c, out var value))
		{
			displayedLayoutRoot = value.layoutManager;
			entityFilter = EntityId.FromCategory(c);
		}
	}

	public void ClearAllSearchProperties()
	{
		itemFilter = null;
		categoryFilter = BuildingCategory.None;
		entityFilter = EntityId.None;
		displayedLayoutRoot = primaryLayoutManager;
	}

	public bool TryAddPointerToExpandBuilding(BuildingType t)
	{
		if (buildingHeaders.TryGetValue(t, out var value) && IsMinimized(value.layoutManager))
		{
			MenuPanel.m.ShowPointerPanel((RectTransform)value.collapseButtonImage.transform);
			return true;
		}
		return false;
	}

	public bool TryAddPointerToAddBuilding(BuildingType t)
	{
		if (buildingHeaders.TryGetValue(t, out var value))
		{
			if (value.gameObject.activeInHierarchy)
			{
				MenuPanel.m.ShowPointerPanel((RectTransform)value.addBuildingButton.transform);
				return true;
			}
			if (sectionHeaderSearch.gameObject.activeInHierarchy && sectionHeaderSearch.TryAddPointerToSearch())
			{
				return true;
			}
		}
		return false;
	}

	public void ReloadItemFiltersForActiveTown()
	{
		ResourceState value3;
		if (itemFilter is StateManager stateManager)
		{
			EntityId id = stateManager.AsEntity();
			StateManager stateManager2 = displayedTown.StateForEntity(id);
			if (stateManager2 != null)
			{
				itemFilter = stateManager2;
				MenuManager.Instance.OnSearchPropertiesChanged();
			}
		}
		else if (itemFilter is BuildingState buildingState)
		{
			if (displayedTown.buildings.TryGetValue(buildingState.type, out var value))
			{
				itemFilter = value;
				MenuManager.Instance.OnSearchPropertiesChanged();
			}
		}
		else if (itemFilter is ItemState itemState)
		{
			if (displayedTown.inventory.TryGetValue(itemState.type, out var value2))
			{
				itemFilter = value2;
				MenuManager.Instance.OnSearchPropertiesChanged();
			}
		}
		else if (itemFilter is ResourceState resourceState && displayedTown.naturalResources.TryGetValue(resourceState.type, out value3))
		{
			itemFilter = value3;
			MenuManager.Instance.OnSearchPropertiesChanged();
		}
	}
}
