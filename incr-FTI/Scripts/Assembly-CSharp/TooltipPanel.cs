using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TooltipPanel : MenuListPanel
{
	public RectTransform panelRect;

	public Image itemIcon;

	public TextMeshProUGUI itemLabel;

	public GameObject tooltipAttributeListItemPrefab;

	public GameObject tooltipDescriptionListItemPrefab;

	public GameObject tooltipIconGridListItemPrefab;

	public GameObject tooltipCapacityListItemPrefab;

	public GameObject tooltipIconLabelListItemPrefab;

	public GameObject tooltipIndentedIconItemPrefab;

	public GameObject tooltipRequirementListItemPrefab;

	public GameObject tooltipCostGridItemPrefab;

	public GameObject tooltipLayoutGroupPrefab;

	public GameObject gridIconPrefab;

	public GameObject stateModifierListItemPrefab;

	private List<TooltipAttributeListItem> unusedTooltips = new List<TooltipAttributeListItem>();

	private readonly Dictionary<ItemRateData, TooltipAttributeListItem> inputItems = new Dictionary<ItemRateData, TooltipAttributeListItem>();

	private readonly Dictionary<ItemRateData, TooltipAttributeListItem> outputItems = new Dictionary<ItemRateData, TooltipAttributeListItem>();

	private ListItemPool<TooltipAttributeListItem> tooltipAttributePoolGeneral;

	private ListItemPool<TooltipCapacityListItem> tooltipCapacityItemPool;

	private ListItemPool<TooltipIconLabelListItem> tooltipIconLabelItemPool;

	private ListItemPool<TooltipIconLabelListItem> tooltipIndentedItemPool;

	private ListItemPool<TooltipRequirementListItem> tooltipRequirmentItemPool;

	private ListItemPool<TooltipCostGrid> tooltipCostGridItemPool;

	private ListItemPool<TooltipIndentedLayoutGroup> tooltipLayoutGroupPool;

	private ListItemPool<TextLabel> descriptionItemPool;

	private ListItemPool<TextLabel> indentedDescriptionItemPool;

	private List<TooltipAttributeListItem> activeAttributes = new List<TooltipAttributeListItem>();

	private List<TooltipAttributeListItem> relevantAttributes = new List<TooltipAttributeListItem>();

	private List<GameObject> gridItemPool = new List<GameObject>();

	private int gridItemIndex;

	private int placementIndex;

	private List<BuildingType> reusableBuildingList = new List<BuildingType>();

	private readonly List<Requirement> requirementsToDisplay = new List<Requirement>();

	private readonly List<EntityLevel> rewardsToDisplay = new List<EntityLevel>();

	private readonly List<EntityId> tempEntityList = new List<EntityId>();

	private readonly List<ItemRateData> reusableUnsortedList = new List<ItemRateData>();

	private readonly List<ItemRateData> reusableSortedList = new List<ItemRateData>();

	private bool isInventoryRegionExpanded;

	private bool isProductionRegionExpanded;

	private bool isConsumptionRegionExpanded;

	private ConsumableState displayedState;

	[NonSerialized]
	public EntityId displayedEntity;

	public TooltipAttributeListItem productionHeader;

	public TooltipAttributeListItem productionTotal;

	public TooltipAttributeListItem consumptionHeader;

	public TooltipAttributeListItem consumptionTotal;

	public TooltipAttributeListItem rateChangeRow;

	[NonSerialized]
	public SortColumn sortColumn;

	private bool isInProductionMode;

	private int sortOrder;

	public bool useOverridePlacement;

	private MenuButton lastSource;

	private TooltipOptions lastOptions;

	public TextAnchor anchorPlacement;

	public TextAnchor displayPlacement;

	public float tooltipOffset;

	public bool centerY;

	public bool centerX;

	public bool allowHorizontalFlip;

	private bool isInGuideMode => !isInProductionMode;

	public override void Initialize()
	{
		useOverridePlacement = false;
		tooltipAttributePoolGeneral = new ListItemPool<TooltipAttributeListItem>(tooltipAttributeListItemPrefab);
		tooltipCapacityItemPool = new ListItemPool<TooltipCapacityListItem>(tooltipCapacityListItemPrefab);
		descriptionItemPool = new ListItemPool<TextLabel>(tooltipDescriptionListItemPrefab);
		indentedDescriptionItemPool = new ListItemPool<TextLabel>(tooltipDescriptionListItemPrefab);
		tooltipIconLabelItemPool = new ListItemPool<TooltipIconLabelListItem>(tooltipIconLabelListItemPrefab);
		tooltipRequirmentItemPool = new ListItemPool<TooltipRequirementListItem>(tooltipRequirementListItemPrefab);
		tooltipIndentedItemPool = new ListItemPool<TooltipIconLabelListItem>(tooltipIndentedIconItemPrefab);
		tooltipCostGridItemPool = new ListItemPool<TooltipCostGrid>(tooltipCostGridItemPrefab);
		tooltipLayoutGroupPool = new ListItemPool<TooltipIndentedLayoutGroup>(tooltipLayoutGroupPrefab);
		base.Initialize();
		isConsumptionRegionExpanded = true;
		isProductionRegionExpanded = true;
		sortColumn = SortColumn.Contribution;
		sortOrder = 1;
	}

	public override void Show()
	{
		UpdatePinnedDisplay();
		base.Show();
	}

	public void ShowWarehouse(ItemState s)
	{
		Pin();
		ResetTooltipState();
		UpdateDisplayForState(s);
		ManuallyOpen();
	}

	public override void Unpin()
	{
		base.Unpin();
		if (displayedState is ResourceState resourceState)
		{
			if (MenuPanel.m.inventoryPanel.selectionManager.singleSelectedElement.Equals(resourceState.AsEntity()))
			{
				MenuPanel.m.inventoryPanel.selectionManager.ClearSelection();
			}
			else if (MenuPanel.m.inventoryPanelPopup.selectionManager.singleSelectedElement.Equals(resourceState.AsEntity()))
			{
				MenuPanel.m.inventoryPanelPopup.selectionManager.ClearSelection();
			}
		}
		else if (displayedState is ItemState { parentTown: not null } itemState)
		{
			if (MenuPanel.m.inventoryPanel.selectionManager.singleSelectedElement.Equals(itemState.AsEntity()))
			{
				MenuPanel.m.inventoryPanel.selectionManager.ClearSelection();
			}
			else if (MenuPanel.m.inventoryPanelPopup.selectionManager.singleSelectedElement.Equals(itemState.AsEntity()))
			{
				MenuPanel.m.inventoryPanelPopup.selectionManager.ClearSelection();
			}
			else if (MenuPanel.m.townStatsPanel.singleSelectionManager.singleSelectedElement.Equals(itemState.AsEntity()))
			{
				MenuPanel.m.townStatsPanel.singleSelectionManager.ClearSelection();
			}
			if (MenuPanel.m.coinPanel.selectionManager.singleSelectedElement.Equals(itemState.AsEntity()))
			{
				MenuPanel.m.coinPanel.selectionManager.ClearSelection();
			}
		}
	}

	private bool IsShowingGlobalWarehouse()
	{
		if (displayedState != null)
		{
			return displayedState.parentTown == null;
		}
		return false;
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		foreach (TooltipCapacityListItem item in tooltipCapacityItemPool.pool)
		{
			item.ReloadLabel();
		}
		bool flag = IsShowingGlobalWarehouse();
		if (null != productionHeader)
		{
			if (flag)
			{
				productionHeader.keyLabel.text = "Exports".Localized();
			}
			else
			{
				productionHeader.keyLabel.text = "ItemProduction".Localized();
			}
		}
		if (null != consumptionHeader)
		{
			if (flag)
			{
				consumptionHeader.keyLabel.text = "Imports".Localized();
			}
			else
			{
				consumptionHeader.keyLabel.text = "ItemConsumption".Localized();
			}
		}
		if (null != productionTotal)
		{
			productionTotal.keyLabel.text = "Total".Localized();
		}
		if (null != consumptionTotal)
		{
			consumptionTotal.keyLabel.text = "Total".Localized();
		}
	}

	public override bool IsFixedPosition()
	{
		return true;
	}

	public void LoadObject(object obj)
	{
		if (!(obj is StateManager))
		{
			_ = obj is ConsumableState;
		}
	}

	public void ShowRewardEntityTypes(List<EntityLevel> rewards, EntityType searchType, bool showImpossible)
	{
		foreach (EntityLevel reward in rewards)
		{
			if (reward.entityId.type != searchType)
			{
				continue;
			}
			List<RequirementId> requirements = Crafting.RequirementsForEntity(reward.entityId);
			if (displayedTown.IsImpossibleInTown(requirements) == showImpossible)
			{
				TooltipIndentedLayoutGroup parentGroup = AddIndentedEntity(reward.entityId, showTypeLabel: true, reward.level);
				if (reward.entityId.TryAsBuilding(out var b))
				{
					LoadBuilding(b, parentGroup);
				}
			}
		}
	}

	private void ResetTooltipState()
	{
		_ = scrollRect.verticalScrollbar.value;
		gridItemIndex = 0;
		placementIndex = 0;
		productionHeader = null;
		consumptionHeader = null;
		productionTotal = null;
		consumptionTotal = null;
		rateChangeRow = null;
		tooltipCapacityItemPool.Reset();
		tooltipAttributePoolGeneral.Reset();
		tooltipIconLabelItemPool.Reset();
		tooltipIndentedItemPool.Reset();
		tooltipCostGridItemPool.Reset();
		tooltipLayoutGroupPool.Reset();
		tooltipRequirmentItemPool.Reset();
		descriptionItemPool.Reset();
		indentedDescriptionItemPool.Reset();
		foreach (GameObject item in gridItemPool)
		{
			item.gameObject.SetActive(value: false);
		}
	}

	public void SetPosition(MenuButton source)
	{
		TooltipOptions tooltipOptions = source.tooltipOptions;
		if (tooltipOptions == null)
		{
			tooltipOptions = MenuManager.Instance.defaultTooltipOptions;
		}
		lastSource = source;
		lastOptions = tooltipOptions;
		if (!useOverridePlacement)
		{
			anchorPlacement = tooltipOptions.tooltipAnchorPlacement;
			displayPlacement = tooltipOptions.tooltipDisplayPlacement;
			centerX = tooltipOptions.tooltipCenterX;
			centerY = tooltipOptions.tooltipCenterY;
			tooltipOffset = tooltipOptions.tooltipOffset;
			allowHorizontalFlip = tooltipOptions.allowHorizontalFlip;
		}
		RectTransform source2 = (RectTransform)source.transform;
		if (tooltipOptions.panelSize.sqrMagnitude > 0f)
		{
			panelRect.SetWidth(tooltipOptions.panelSize.x);
			if (tooltipOptions.autoHeight)
			{
				float num = 92f;
				float num2 = 40f;
				int num3 = 0;
				foreach (Transform item in layoutGroup.transform)
				{
					if (item.gameObject.activeInHierarchy)
					{
						num3++;
					}
				}
				float height = num + num2 * (float)num3;
				panelRect.SetHeight(height);
			}
			else
			{
				panelRect.SetHeight(tooltipOptions.panelSize.y);
			}
		}
		else
		{
			panelRect.SetWidth(1000f);
			panelRect.SetHeight(600f);
		}
		MenuPanel.m.SetTooltipPosition(source2, panelRect, anchorPlacement, displayPlacement, tooltipOffset, centerX, centerY, allowHorizontalFlip);
	}

	public void LoadRequirements(EntityId id)
	{
		displayedState = null;
		displayedEntity = id;
		ResetTooltipState();
		if (!id.TryAsBiome(out var t))
		{
			return;
		}
		itemIcon.sprite = IconManager.SpriteForBiome(t);
		itemLabel.text = TextDisplay.FormattedEntityWithType(id);
		if (MenuPanel.gm.biomeStates.TryGetValue(t, out var value))
		{
			foreach (Requirement requirement in value.requirements)
			{
				if (!requirement.IsVisible())
				{
					continue;
				}
				if (requirement is RequiredQuest requiredQuest && MenuPanel.gm.globalQuests.TryGetValue(requiredQuest.questType, out var value2))
				{
					foreach (Requirement requirement2 in value2.completionRequirement.requirements)
					{
						GetRequirementItem().DisplayRequirement(requirement2);
					}
				}
				else
				{
					GetRequirementItem().DisplayRequirement(requirement);
				}
			}
		}
		ManuallyOpen();
	}

	public void LoadState(ConsumableState state)
	{
		ResetTooltipState();
		UpdateDisplayForState(state);
		ManuallyOpen();
	}

	public void LoadItem(ItemType itemType)
	{
		switch (itemType)
		{
		case ItemType.Worker:
		{
			itemLabel.text = TextDisplay.LabelForItem(itemType);
			GetDescriptionItem().label.text = "TooltipWorkers".Localized();
			GetDescriptionItem().label.text = string.Format(TextDisplay.LocalizedKeyValueFormat(), "Available".Localized(), TextDisplay.LocalizedNumber(displayedTown.workerState.numAvailable) + "/" + TextDisplay.LocalizedNumber(displayedTown.workerState.currentCount));
			double num5 = displayedTown.PopulationForCurrentTownLevel(displayedTown.townLevel);
			if (num5 > 0.0)
			{
				TooltipIconLabelListItem iconLabelItem10 = GetIconLabelItem();
				iconLabelItem10.iconImage.sprite = IconManager.Instance.townLevel;
				iconLabelItem10.primaryLabel.text = string.Format(TextDisplay.LocalizedKeyValueFormat(), string.Format(TextDisplay.LocalizedTwoValueFormat(), "TownLevel".Localized(), TextDisplay.LocalizedNumber(displayedTown.townLevel)), "+" + TextDisplay.LocalizedNumber(num5));
			}
			TooltipIconLabelListItem iconLabelItem11 = GetIconLabelItem();
			iconLabelItem11.iconImage.sprite = IconManager.SpriteForBuilding(BuildingType.House);
			iconLabelItem11.primaryLabel.text = string.Format(TextDisplay.LocalizedKeyValueFormat(), TextDisplay.LabelForBuilding(BuildingType.House), TextDisplay.LocalizedNumber(displayedTown.NumBuildingsOfType(BuildingType.House)));
			TooltipIconLabelListItem iconLabelItem12 = GetIconLabelItem();
			iconLabelItem12.iconImage.sprite = IconManager.SpriteForItem(ItemType.Worker);
			iconLabelItem12.primaryLabel.text = string.Format(TextDisplay.LocalizedKeyValueFormat(), TextDisplay.LabelForPerk(PerkType.HousingCapacity), TextDisplay.LocalizedNumber(displayedTown.buildings[BuildingType.House].buildingDef.workerHousingProvided));
			int num6 = displayedTown.LevelOfTownUpgrade(UpgradeType.HouseCapacity);
			if (num6 > 0)
			{
				string arg = TextDisplay.FormattedRewardEntityWithType(EntityId.FromUpgrade(UpgradeType.HouseCapacity), num6);
				float num7 = displayedTown.MultiplierForUpgrade(UpgradeType.HouseCapacity);
				TooltipIconLabelListItem iconLabelItem13 = GetIconLabelItem();
				iconLabelItem13.iconImage.sprite = IconManager.SpriteForMenuPanel(MenuPanelType.Upgrades);
				iconLabelItem13.primaryLabel.text = string.Format(TextDisplay.LocalizedKeyValueFormat(), arg, "x" + num7);
			}
			int num8 = MenuPanel.gm.LevelOfGlobalPerk(PerkType.HousingCapacity);
			if (num8 > 0)
			{
				string arg2 = TextDisplay.FormattedRewardEntityWithType(EntityId.FromPerk(PerkType.HousingCapacity), num8);
				float num9 = GameManager.Instance.AdjustedMultiplierForPerkLevel(PerkType.HousingCapacity, num8);
				TooltipIconLabelListItem iconLabelItem14 = GetIconLabelItem();
				iconLabelItem14.iconImage.sprite = IconManager.SpriteForMenuPanel(MenuPanelType.Perks);
				iconLabelItem14.primaryLabel.text = string.Format(TextDisplay.LocalizedKeyValueFormat(), arg2, "x" + num9);
			}
			break;
		}
		case ItemType.UtilityAutoAssign:
			itemLabel.text = TextDisplay.LabelForItem(itemType);
			GetDescriptionItem().label.text = "TooltipAutomaticAssignment".Localized();
			requirementsToDisplay.Clear();
			requirementsToDisplay.Add(MenuPanel.gm.GetCachedWorldRequirement(new RequirementId(Quest.UnlockAutoBalance)));
			ShowQueuedRequirements("Requirements");
			break;
		case ItemType.UtilityAutoClaim:
			itemLabel.text = TextDisplay.LabelForItem(itemType);
			if (LocalizationManager.HasLocalizedValueForKey("TooltipAutoClaim"))
			{
				GetDescriptionItem().label.text = "TooltipAutoClaim".Localized();
			}
			requirementsToDisplay.Clear();
			requirementsToDisplay.Add(MenuPanel.gm.GetCachedWorldRequirement(new RequirementId(QuestType.OmnitempleForAutoClaim)));
			ShowQueuedRequirements("Requirements");
			break;
		case ItemType.UtilityIdleRewardBoost:
			itemLabel.text = TextDisplay.LabelForItem(itemType);
			GetDescriptionItem().label.text = "TooltipRewardBoost".Localized();
			break;
		case ItemType.UtilityPrioritization:
			itemLabel.text = TextDisplay.LabelForItem(itemType);
			GetDescriptionItem().label.text = "TooltipPrioritization".Localized();
			requirementsToDisplay.Clear();
			requirementsToDisplay.Add(MenuPanel.gm.GetCachedWorldRequirement(new RequirementId(Quest.UnlockPrioritization)));
			ShowQueuedRequirements("Requirements");
			break;
		case ItemType.TimeToken:
			GetDescriptionItem().label.text = "TooltipTimeTokens".Localized();
			GetDescriptionItem().label.text = TextDisplay.FormattedTimeTokenValue();
			break;
		case ItemType.UtilityLand:
		{
			itemLabel.text = TextDisplay.LabelForItem(itemType);
			GetDescriptionItem().label.text = "TooltipLand".Localized();
			if (MenuPanel.gm.isLandInfinite)
			{
				GetDescriptionItem().label.text = string.Format(TextDisplay.LocalizedKeyValueFormat(), "Available".Localized(), "∞");
				break;
			}
			GetDescriptionItem().label.text = string.Format(TextDisplay.LocalizedKeyValueFormat(), "Available".Localized(), TextDisplay.LocalizedNumber(displayedTown.landState.numAvailable) + "/" + TextDisplay.LocalizedNumber(displayedTown.landState.maxCount));
			TooltipIconLabelListItem iconLabelItem = GetIconLabelItem();
			iconLabelItem.iconImage.sprite = IconManager.Instance.panelWorld;
			iconLabelItem.primaryLabel.text = TextDisplay.FormattedKeyValue("Default", TextDisplay.LocalizedNumber(displayedTown.DefaultStartingLand()));
			float num = displayedTown.MultiplierForPerk(PerkType.MoreStartingLand);
			if (num > 0f)
			{
				TooltipIconLabelListItem iconLabelItem2 = GetIconLabelItem();
				iconLabelItem2.iconImage.sprite = IconManager.Instance.questCoin;
				iconLabelItem2.primaryLabel.text = string.Format(TextDisplay.LocalizedKeyValueFormat(), TextDisplay.FormattedRewardEntityWithType(EntityId.FromPerk(PerkType.MoreStartingLand)), "+" + TextDisplay.LocalizedNumber(num));
			}
			float num2 = displayedTown.MultiplierForUpgrade(UpgradeType.Exploration);
			if (num2 > 0f)
			{
				TooltipIconLabelListItem iconLabelItem3 = GetIconLabelItem();
				iconLabelItem3.iconImage.sprite = IconManager.SpriteForUpgrade(UpgradeType.Exploration);
				iconLabelItem3.primaryLabel.text = string.Format(TextDisplay.LocalizedKeyValueFormat(), TextDisplay.LabelForUpgradeLevel(UpgradeType.Exploration, displayedTown.LevelOfTownUpgrade(UpgradeType.Exploration)), "+" + TextDisplay.LocalizedNumber(num2));
			}
			float value2 = Town.LandMultiplierForTownLevel(displayedTown.townLevel);
			TooltipIconLabelListItem iconLabelItem4 = GetIconLabelItem();
			iconLabelItem4.iconImage.sprite = IconManager.Instance.townLevel;
			iconLabelItem4.primaryLabel.text = string.Format(TextDisplay.LocalizedKeyValueFormat(), string.Format(TextDisplay.LocalizedTwoValueFormat(), "TownLevel".Localized(), TextDisplay.LocalizedNumber(displayedTown.townLevel)), "x" + TextDisplay.LocalizedNumber(value2));
			float num3 = displayedTown.MultiplierForPerk(PerkType.LandCapacity);
			if (GameUtility.NotEquals(num3, 1f))
			{
				TooltipIconLabelListItem iconLabelItem5 = GetIconLabelItem();
				iconLabelItem5.iconImage.sprite = IconManager.Instance.experiencePointPurple;
				iconLabelItem5.primaryLabel.text = string.Format(TextDisplay.LocalizedKeyValueFormat(), TextDisplay.FormattedRewardEntityWithType(EntityId.FromPerk(PerkType.LandCapacity)), "x" + TextDisplay.LocalizedNumber(num3));
			}
			if (GameUtility.NotEquals(displayedTown.biomeLandMultiplier, 1f))
			{
				TooltipIconLabelListItem iconLabelItem6 = GetIconLabelItem();
				iconLabelItem6.iconImage.sprite = IconManager.SpriteForBiome(displayedTown.biomeType);
				iconLabelItem6.primaryLabel.text = string.Format(TextDisplay.LocalizedKeyValueFormat(), TextDisplay.FormattedRewardEntityWithType(EntityId.FromBiome(displayedTown.biomeType)), "x" + TextDisplay.LocalizedNumber(displayedTown.biomeLandMultiplier));
			}
			if (GameUtility.NotEquals(MenuPanel.gm.wonderMultiplierObservatory, 1f))
			{
				TooltipIconLabelListItem iconLabelItem7 = GetIconLabelItem();
				iconLabelItem7.iconImage.sprite = IconManager.SpriteForBuilding(BuildingType.MountainObservatory);
				iconLabelItem7.primaryLabel.text = string.Format(TextDisplay.LocalizedKeyValueFormat(), TextDisplay.FormattedRewardEntityWithType(EntityId.FromBuilding(BuildingType.MountainObservatory)), "x" + TextDisplay.LocalizedNumber(MenuPanel.gm.wonderMultiplierObservatory));
			}
			float num4 = displayedTown.ValueForBuilding(BuildingType.FloatingIsland);
			if (num4 > 0f)
			{
				TooltipIconLabelListItem iconLabelItem8 = GetIconLabelItem();
				iconLabelItem8.iconImage.sprite = IconManager.SpriteForBuilding(BuildingType.FloatingIsland);
				iconLabelItem8.primaryLabel.text = string.Format(TextDisplay.LocalizedKeyValueFormat(), TextDisplay.LabelForBuilding(BuildingType.FloatingIsland), "+" + TextDisplay.LocalizedNumber(num4));
			}
			double bonusLand = displayedTown.bonusLand;
			if (bonusLand > 0.0)
			{
				TooltipIconLabelListItem iconLabelItem9 = GetIconLabelItem();
				iconLabelItem9.iconImage.sprite = IconManager.Instance.land;
				iconLabelItem9.primaryLabel.text = string.Format(TextDisplay.LocalizedKeyValueFormat(), "BonusLand".Localized(), "+" + TextDisplay.LocalizedNumber(bonusLand));
			}
			break;
		}
		default:
		{
			if (isInProductionMode && displayedTown.inventory.TryGetValue(itemType, out var value))
			{
				UpdateDisplayForState(value);
			}
			else
			{
				ShowGuideForItem(itemType);
			}
			break;
		}
		}
	}

	public void LoadRecipe(RecipeType t)
	{
		if (!Crafting.recipeCache.TryGetValue(t, out var value))
		{
			return;
		}
		TryShowInputs(value.inputs);
		TryShowOutputs(value.outputs);
		tempEntityList.Clear();
		foreach (KeyValuePair<BuildingType, List<RecipeType>> cachedBuildingRecipe in Crafting.cachedBuildingRecipes)
		{
			foreach (RecipeType item in cachedBuildingRecipe.Value)
			{
				if (item == t)
				{
					tempEntityList.Add(EntityId.FromBuilding(cachedBuildingRecipe.Key));
				}
			}
		}
		if (tempEntityList.Count > 0)
		{
			TooltipIconLabelListItem iconLabelItem = GetIconLabelItem();
			iconLabelItem.primaryLabel.text = "ProducedBy".Localized() + ":";
			iconLabelItem.iconImage.sprite = IconManager.SpriteForMenuPanel(MenuPanelType.Recipes);
			foreach (EntityId tempEntity in tempEntityList)
			{
				AddIndentedEntity(tempEntity, showTypeLabel: false);
			}
		}
		requirementsToDisplay.Clear();
		CalcRequirementsToDisplay(value.requirements, displayedTown);
		ShowQueuedRequirements("Requirements");
	}

	public void LoadResearch(Research researchDef)
	{
		ResearchType type = researchDef.type;
		string text = TextDisplay.DescriptionForResearch(type);
		if (text != null)
		{
			GetDescriptionItem().label.text = text;
		}
		if ((uint)(type - 311) <= 3u)
		{
			tempEntityList.Clear();
			foreach (KeyValuePair<RecipeType, RecipeState> recipe in displayedTown.recipes)
			{
				foreach (ProductionModifier productionSpeedModifier in recipe.Value.productionSpeedModifiers)
				{
					if (productionSpeedModifier is ProductionModifierResearch productionModifierResearch && productionModifierResearch.researchState.type == type)
					{
						tempEntityList.Add(EntityId.FromRecipe(recipe.Key));
						break;
					}
				}
			}
			LoadEntitiesIntoGrid(tempEntityList);
		}
		if (displayedTown.research.TryGetValue(type, out var value))
		{
			List<RequirementId> levelReqs = value.recipe.RequirementsForLevel(value.numCompleted);
			requirementsToDisplay.Clear();
			CalcRequirementsToDisplay(levelReqs, value.parentTown);
			ShowQueuedRequirements("Requirements");
		}
		else
		{
			List<RequirementId> levelReqs2 = researchDef.RequirementsForLevel(0);
			requirementsToDisplay.Clear();
			CalcRequirementsToDisplay(levelReqs2, displayedTown);
			ShowQueuedRequirements("Requirements");
		}
		TryShowRewards(researchDef.reward);
	}

	public void TryShowRewards(List<EntityLevel> rewardList)
	{
		rewardsToDisplay.Clear();
		rewardsToDisplay.AddRange(rewardList);
		if (rewardsToDisplay.Count <= 0)
		{
			return;
		}
		TooltipIconLabelListItem iconLabelItem = GetIconLabelItem();
		iconLabelItem.primaryLabel.text = "RequiredFor".Localized() + ":";
		iconLabelItem.iconImage.sprite = IconManager.Instance.unlock;
		for (int i = 0; i <= 1; i++)
		{
			bool showImpossible = i == 1;
			foreach (EntityType item in Data.Instance.entityTypeHierarchy)
			{
				ShowRewardEntityTypes(rewardsToDisplay, item, showImpossible);
			}
		}
	}

	private void AddIndentedDescription(string desc)
	{
		GetIndentedDescription().label.text = desc;
	}

	private TooltipIndentedLayoutGroup AddIndentedEntity(EntityId id, bool showTypeLabel = true, int level = 0, bool useSubgroup = false)
	{
		TooltipIndentedLayoutGroup indentedLayoutGroup = GetIndentedLayoutGroup();
		TooltipIconLabelListItem indentedItem = GetIndentedItem(indentedLayoutGroup.layoutGroup.transform, indentedLayoutGroup);
		indentedItem.LoadEntity(id, showTypeLabel);
		if (level > 0)
		{
			indentedItem.primaryLabel.text = string.Format(TextDisplay.LocalizedTwoValueFormat(), indentedItem.primaryLabel.text, TextDisplay.GetFormattedLevelAbbreviation(level + 1));
		}
		List<RequirementId> reqs = Crafting.RequirementsForEntity(id);
		BiomeType biomeType = ExclusiveBiomeFromRequirements(reqs);
		if (biomeType != BiomeType.None)
		{
			indentedItem.LoadRightHandEntity(EntityId.FromBiome(biomeType));
			if (biomeType != displayedTown.biomeType)
			{
				indentedItem.FormatImpossibleState(isImpossible: true);
			}
		}
		if (id.TryAsHarvestRecipe(out var i) && Crafting.harvestRecipeCache.TryGetValue(i, out var value) && (!displayedEntity.TryAsBuilding(out var b) || b != value.producingBuildingType))
		{
			indentedItem.iconImage.sprite = IconManager.SpriteForBuilding(value.producingBuildingType);
		}
		return indentedLayoutGroup;
	}

	private BiomeType ExclusiveBiomeFromRequirements(List<RequirementId> reqs)
	{
		if (reqs == null)
		{
			return BiomeType.None;
		}
		foreach (RequirementId req in reqs)
		{
			if (req.type == RequirementType.Biome && req.entityId.TryAsBiome(out var t))
			{
				return t;
			}
		}
		return BiomeType.None;
	}

	private void TryShowCultivationBuilding(NaturalResource r, bool alsoShowRecipes = false)
	{
		if (!Crafting.naturalResourceCache.TryGetValue(r, out var value) || value.cultivationBuilding == BuildingType.None)
		{
			return;
		}
		if (Crafting.farmingRecipeCache.ContainsKey(r))
		{
			TooltipIconLabelListItem iconLabelItem = GetIconLabelItem();
			iconLabelItem.primaryLabel.text = "Cultivation".Localized() + ":";
			iconLabelItem.iconImage.sprite = IconManager.SpriteForMenuPanel(MenuPanelType.Cultivation);
		}
		else
		{
			TooltipIconLabelListItem iconLabelItem2 = GetIconLabelItem();
			iconLabelItem2.primaryLabel.text = "Prospecting".Localized() + ":";
			iconLabelItem2.iconImage.sprite = IconManager.SpriteForMenuPanel(MenuPanelType.Prospecting);
		}
		AddIndentedEntity(EntityId.FromBuilding(value.cultivationBuilding));
		if (alsoShowRecipes)
		{
			if (Crafting.farmingRecipeCache.TryGetValue(r, out var value2))
			{
				LoadFarmingRecipeCostGrid(value2, 2);
			}
			if (Crafting.prospectingRecipeCache.TryGetValue(r, out var value3))
			{
				LoadFarmingRecipeCostGrid(value3, 2);
			}
		}
	}

	private void TryShowOutputEntity(EntityId outputEntity)
	{
		TooltipIconLabelListItem iconLabelItem = GetIconLabelItem();
		iconLabelItem.primaryLabel.text = "SlotTypeOutput".Localized() + ":";
		iconLabelItem.iconImage.sprite = IconManager.Instance.accessOut;
		AddIndentedEntity(outputEntity);
	}

	private void TryShowInputs(ItemList inputs)
	{
		if (!((double)inputs.items.Count > 0.0))
		{
			return;
		}
		TooltipIconLabelListItem iconLabelItem = GetIconLabelItem();
		iconLabelItem.primaryLabel.text = "SlotTypeInput".Localized() + ":";
		iconLabelItem.iconImage.sprite = IconManager.Instance.accessIn;
		foreach (KeyValuePair<ItemType, double> item in inputs.items)
		{
			AddIndentedEntity(EntityId.FromItem(item.Key), showTypeLabel: false);
		}
	}

	private void TryShowOutputs(ItemList outputs)
	{
		if (!((double)outputs.items.Count > 0.0))
		{
			return;
		}
		TooltipIconLabelListItem iconLabelItem = GetIconLabelItem();
		iconLabelItem.primaryLabel.text = "SlotTypeOutput".Localized() + ":";
		iconLabelItem.iconImage.sprite = IconManager.Instance.accessOut;
		foreach (KeyValuePair<ItemType, double> item in outputs.items)
		{
			AddIndentedEntity(EntityId.FromItem(item.Key), showTypeLabel: false);
		}
	}

	private void LoadProspecting(NaturalResource miningResource)
	{
		EntityId.FromMining(miningResource);
		TryShowCultivationBuilding(miningResource);
		if (Crafting.prospectingRecipeCache.TryGetValue(miningResource, out var value))
		{
			TryShowInputs(value.inputs);
			TryShowOutputEntity(EntityId.FromNaturalResource(miningResource));
			requirementsToDisplay.Clear();
			CalcRequirementsToDisplay(value.requirements, displayedTown);
			ShowQueuedRequirements("Requirements");
		}
	}

	private void LoadHarvestRecipe(HarvestRecipeType harvestRecipeType)
	{
		EntityId.FromHarvestRecipe(harvestRecipeType);
		if (!Crafting.harvestRecipeCache.TryGetValue(harvestRecipeType, out var value))
		{
			return;
		}
		TooltipIconLabelListItem iconLabelItem = GetIconLabelItem();
		iconLabelItem.primaryLabel.text = "ProducedBy".Localized() + ":";
		iconLabelItem.iconImage.sprite = IconManager.SpriteForMenuPanel(MenuPanelType.Harvesting);
		AddIndentedEntity(EntityId.FromBuilding(value.producingBuildingType));
		TooltipIconLabelListItem iconLabelItem2 = GetIconLabelItem();
		iconLabelItem2.primaryLabel.text = "SlotTypeInput".Localized() + ":";
		iconLabelItem2.iconImage.sprite = IconManager.Instance.accessIn;
		AddIndentedEntity(EntityId.FromNaturalResource(value.resourceType));
		if ((double)value.recipe.inputs.items.Count > 0.0)
		{
			foreach (KeyValuePair<ItemType, double> item in value.recipe.inputs.items)
			{
				AddIndentedEntity(EntityId.FromItem(item.Key), showTypeLabel: false);
			}
		}
		TryShowOutputs(value.recipe.outputs);
		requirementsToDisplay.Clear();
		CalcRequirementsToDisplay(value.requirements, displayedTown);
		ShowQueuedRequirements("Requirements");
	}

	private void LoadFarming(NaturalResource resource)
	{
		EntityId.FromFarming(resource);
		if (!Crafting.farmingRecipeCache.TryGetValue(resource, out var value))
		{
			return;
		}
		TryShowCultivationBuilding(resource);
		if ((double)value.inputs.items.Count > 0.0)
		{
			TooltipIconLabelListItem iconLabelItem = GetIconLabelItem();
			iconLabelItem.primaryLabel.text = "SlotTypeInput".Localized() + ":";
			iconLabelItem.iconImage.sprite = IconManager.Instance.accessIn;
			foreach (KeyValuePair<ItemType, double> item in value.inputs.items)
			{
				AddIndentedEntity(EntityId.FromItem(item.Key), showTypeLabel: false);
			}
		}
		TryShowOutputEntity(EntityId.FromNaturalResource(resource));
		requirementsToDisplay.Clear();
		CalcRequirementsToDisplay(value.requirements, displayedTown);
		ShowQueuedRequirements("Requirements");
	}

	private void LoadUpgrade(UpgradeType upgradeType)
	{
		if (!Crafting.upgradeCache.TryGetValue(upgradeType, out var value))
		{
			return;
		}
		EntityId id = EntityId.FromUpgrade(upgradeType);
		Upgrade value2;
		if (isInProductionMode)
		{
			displayedTown.upgrades.TryGetValue(upgradeType, out value2);
		}
		else
		{
			value2 = null;
		}
		if (value2 != null)
		{
			if (value2.numCompleted > 0)
			{
				itemLabel.text = TextDisplay.FormattedRewardEntityWithType(id, value2.numCompleted + 1);
			}
			else
			{
				itemLabel.text = TextDisplay.FormattedRewardEntityWithType(id);
			}
		}
		else
		{
			itemLabel.text = TextDisplay.FormattedRewardEntityWithType(id);
		}
		string text = TextDisplay.DescriptionForUpgrade(upgradeType);
		if (text != null)
		{
			GetDescriptionItem().label.text = text;
		}
		requirementsToDisplay.Clear();
		CalcRequirementsToDisplay(value.displayRequirements, displayedTown);
		ShowQueuedRequirements("DisplayRequirements");
		requirementsToDisplay.Clear();
		foreach (UpgradeLevelDef level in value.levels)
		{
			List<RequirementId> unlockRequirements = level.unlockRequirements;
			CalcRequirementsToDisplay(unlockRequirements, displayedTown);
		}
		ShowQueuedRequirements("Requirements");
	}

	public void LoadEntityProduction(EntityId id)
	{
		isInProductionMode = true;
		LoadEntity(id);
	}

	public void LoadEntityDescription(EntityId id)
	{
		isInProductionMode = false;
		LoadEntity(id);
	}

	public void LoadPerk(PerkType t)
	{
		GetDescriptionItem().label.text = TextDisplay.DescriptionForPerkTypeNew(t, 1, useNextFormatting: false);
	}

	public void LoadNaturalResource(NaturalResource naturalResource)
	{
		if (isInProductionMode && displayedTown.naturalResources.TryGetValue(naturalResource, out var value))
		{
			UpdateDisplayForState(value);
		}
		else
		{
			ShowGuideForNaturalResource(naturalResource);
		}
	}

	public void LoadEntity(EntityId id)
	{
		displayedState = null;
		displayedEntity = id;
		ResetTooltipState();
		itemIcon.sprite = IconManager.SpriteForEntity(id);
		if (isInProductionMode)
		{
			itemLabel.text = TextDisplay.LabelForEntity(id);
		}
		else
		{
			itemLabel.text = TextDisplay.FormattedEntityWithType(id);
		}
		if (isInGuideMode)
		{
			List<RequirementId> reqs = Crafting.RequirementsForEntity(id);
			TryShowUniqueBiomeWarning(reqs);
		}
		ResearchType i2;
		Research value;
		RecipeType r;
		HarvestRecipeType i3;
		BuildingType b;
		QuestType i4;
		UpgradeType i5;
		NaturalResource i6;
		NaturalResource i7;
		NaturalResource i8;
		BiomeType t;
		PerkType i9;
		if (id.TryAsItem(out var i))
		{
			LoadItem(i);
		}
		else if (id.TryAsResearch(out i2) && Crafting.researchCache.TryGetValue(i2, out value))
		{
			LoadResearch(value);
		}
		else if (id.TryAsRecipe(out r))
		{
			LoadRecipe(r);
		}
		else if (id.TryAsHarvestRecipe(out i3))
		{
			LoadHarvestRecipe(i3);
		}
		else if (id.TryAsBuilding(out b))
		{
			LoadBuilding(b);
			if (isInGuideMode && Crafting.buildingCache.TryGetValue(b, out var value2))
			{
				requirementsToDisplay.Clear();
				CalcRequirementsToDisplay(value2.requirements, displayedTown);
				ShowQueuedRequirements("Requirements");
			}
		}
		else if (id.TryAsQuest(out i4))
		{
			LoadQuest(i4);
		}
		else if (id.TryAsUpgrade(out i5))
		{
			LoadUpgrade(i5);
		}
		else if (id.TryAsMining(out i6))
		{
			LoadProspecting(i6);
		}
		else if (id.TryAsFarming(out i7))
		{
			LoadFarming(i7);
		}
		else if (id.TryAsNaturalResource(out i8))
		{
			LoadNaturalResource(i8);
		}
		else if (id.TryAsBiome(out t))
		{
			if (Crafting.biomeCache.TryGetValue(t, out var value3))
			{
				foreach (BiomeModifier entityModifier in value3.entityModifiers)
				{
					GetIconLabelItem().LoadBiomeModifier(entityModifier, panelStringBuilder);
				}
			}
		}
		else if (id.TryAsPerk(out i9))
		{
			LoadPerk(i9);
		}
		ManuallyOpen();
	}

	private void CalcRequirementsToDisplay(List<RequirementId> levelReqs, Town parentTown)
	{
		bool flag = false;
		if (levelReqs == null)
		{
			return;
		}
		foreach (RequirementId levelReq in levelReqs)
		{
			Requirement cachedRequirement = parentTown.GetCachedRequirement(levelReq);
			if (cachedRequirement == null || !cachedRequirement.IsVisible())
			{
				continue;
			}
			requirementsToDisplay.Add(cachedRequirement);
			if (!flag || !(cachedRequirement is RequiredQuest { cachedQuest: not null } requiredQuest))
			{
				continue;
			}
			foreach (Requirement requirement in requiredQuest.cachedQuest.displayRequirement.requirements)
			{
				if (!(requirement is RequiredQuest { questType: QuestType.ResearchForUpgrades }) && !(requirement is RequiredMinBuildingCount) && !requirementsToDisplay.Contains(requirement))
				{
					requirementsToDisplay.Add(requirement);
				}
			}
		}
	}

	private void ShowQueuedRequirements(string requirementTypeLocalizationKey)
	{
		if (requirementsToDisplay.Count <= 0)
		{
			return;
		}
		TooltipIconLabelListItem iconLabelItem = GetIconLabelItem();
		iconLabelItem.primaryLabel.text = requirementTypeLocalizationKey.Localized() + ":";
		if (requirementTypeLocalizationKey == "DisplayRequirements")
		{
			iconLabelItem.iconImage.sprite = IconManager.Instance.unlock;
		}
		else if (requirementTypeLocalizationKey == "CompletionRequirements")
		{
			iconLabelItem.iconImage.sprite = IconManager.Instance.satisfactionCheckmark;
		}
		else
		{
			iconLabelItem.iconImage.sprite = IconManager.Instance.locked;
		}
		int num = 1;
		foreach (Requirement item in requirementsToDisplay)
		{
			TooltipRequirementListItem requirementItem = GetRequirementItem();
			requirementItem.DisplayRequirement(item);
			if (displayedEntity.type == EntityType.Upgrade && requirementTypeLocalizationKey == "Requirements")
			{
				requirementItem.primaryLabel.text = string.Format(TextDisplay.LocalizedKeyValueFormat(), TextDisplay.GetFormattedLevel(num), requirementItem.primaryLabel.text);
			}
			num++;
		}
	}

	private void LoadQuest(QuestType t)
	{
		if (Crafting.questCache.TryGetValue(t, out var value))
		{
			itemIcon.sprite = IconManager.SpriteForMenuPanel(MenuPanelType.Quests);
			requirementsToDisplay.Clear();
			CalcRequirementsToDisplay(value.displayRequirement, displayedTown);
			ShowQueuedRequirements("DisplayRequirements");
			requirementsToDisplay.Clear();
			CalcRequirementsToDisplay(value.completionRequirement, displayedTown);
			ShowQueuedRequirements("CompletionRequirements");
			TryShowRewards(value.derivedRewards);
		}
	}

	private void LoadBuilding(BuildingType buildingType, TooltipIndentedLayoutGroup parentGroup = null)
	{
		if (!Crafting.buildingCache.TryGetValue(buildingType, out var _))
		{
			return;
		}
		BuildingCategory category = Building.GetCategory(buildingType);
		switch (buildingType)
		{
		case BuildingType.ManaPipeline:
		case BuildingType.PowerLine:
		case BuildingType.SteamPipeline:
		case BuildingType.OmniPipeline:
		case BuildingType.MagmaPipeline:
			GetDescriptionItem(parentGroup).label.text = "BuildingDescriptionTradingPost".Localized() + ":";
			tempEntityList.Clear();
			foreach (ItemDef value10 in Crafting.cachedItemDefs.Values)
			{
				if (value10.tradeBuilding == buildingType)
				{
					tempEntityList.Add(EntityId.FromItem(value10.type));
				}
			}
			LoadEntitiesIntoGrid(tempEntityList, parentGroup);
			break;
		case BuildingType.RailDepot:
		{
			if (displayedTown.buildings.TryGetValue(buildingType, out var value4))
			{
				string text2 = TextDisplay.LocalizedNumber(value4.StorageProvidedPerBuilding());
				if (LocalizationManager.IsEnglish())
				{
					text2 += " per Rail Depot";
				}
				GetDescriptionItem(parentGroup).label.text = string.Format("TooltipStorageBooster".Localized(), "Trading".Localized(), text2);
			}
			break;
		}
		case BuildingType.SteamTrain:
			GetDescriptionItem(parentGroup).label.text = string.Format("TooltipTradingBooster".Localized(), TextDisplay.Percent(displayedTown.BonusForBuilding(buildingType)));
			break;
		case BuildingType.Caravan:
			GetDescriptionItem(parentGroup).label.text = string.Format("TooltipTradingBooster".Localized(), TextDisplay.Percent(displayedTown.BonusForBuilding(buildingType)));
			break;
		case BuildingType.Packager:
			GetDescriptionItem(parentGroup).label.text = string.Format("TooltipTradingProductivity".Localized(), TextDisplay.Percent(displayedTown.BonusForBuilding(buildingType)));
			break;
		case BuildingType.Tractor:
			GetDescriptionItem(parentGroup).label.text = string.Format("TooltipCultivationBooster".Localized(), TextDisplay.Percent(displayedTown.BonusForBuilding(buildingType)));
			tempEntityList.Clear();
			foreach (KeyValuePair<NaturalResource, FarmingState> farmingItem in displayedTown.farmingItems)
			{
				foreach (ProductionModifier productionSpeedModifier in farmingItem.Value.productionSpeedModifiers)
				{
					if (productionSpeedModifier is ProductionModifierBuildingCount productionModifierBuildingCount3 && productionModifierBuildingCount3.buildingType == buildingType)
					{
						tempEntityList.Add(EntityId.FromNaturalResource(farmingItem.Key));
						break;
					}
				}
			}
			LoadEntitiesIntoGrid(tempEntityList, parentGroup);
			break;
		case BuildingType.Minecart:
			GetDescriptionItem(parentGroup).label.text = string.Format("TooltipProspectingBooster".Localized(), TextDisplay.Percent(displayedTown.BonusForBuilding(buildingType)));
			tempEntityList.Clear();
			foreach (KeyValuePair<NaturalResource, MiningState> miningItem in displayedTown.miningItems)
			{
				foreach (ProductionModifier productionSpeedModifier2 in miningItem.Value.productionSpeedModifiers)
				{
					if (productionSpeedModifier2 is ProductionModifierBuildingCount productionModifierBuildingCount2 && productionModifierBuildingCount2.buildingType == buildingType)
					{
						tempEntityList.Add(EntityId.FromNaturalResource(miningItem.Key));
						break;
					}
				}
			}
			LoadEntitiesIntoGrid(tempEntityList, parentGroup);
			break;
		case BuildingType.PlainsUniversity:
		{
			TextLabel descriptionItem9 = GetDescriptionItem(parentGroup);
			if (LocalizationManager.IsEnglish())
			{
				descriptionItem9.label.text = "Lowers upgrade costs globally by " + TextDisplay.Percent(0.1f) + " per building";
			}
			else
			{
				descriptionItem9.label.text = string.Format("PerkDescriptionUpgradeEfficiency".Localized(), TextDisplay.Percent(0.1f));
			}
			break;
		}
		case BuildingType.RiverHarbor:
		{
			TextLabel descriptionItem6 = GetDescriptionItem(parentGroup);
			if (LocalizationManager.IsEnglish())
			{
				descriptionItem6.label.text = "Globally increases trading speed by " + TextDisplay.Percent(0.25f) + " per building";
			}
			else
			{
				descriptionItem6.label.text = string.Format("PerkDescriptionTradingSpeed".Localized(), TextDisplay.Percent(0.25f));
			}
			break;
		}
		case BuildingType.ForestMonastery:
		{
			TextLabel descriptionItem4 = GetDescriptionItem(parentGroup);
			if (LocalizationManager.IsEnglish())
			{
				descriptionItem4.label.text = "Globally reduces research costs by " + TextDisplay.Percent(0.1f) + " per building";
			}
			else
			{
				descriptionItem4.label.text = string.Format("PerkDescriptionResearchEfficiency".Localized(), TextDisplay.Percent(0.1f));
			}
			break;
		}
		case BuildingType.MountainObservatory:
		{
			TextLabel descriptionItem = GetDescriptionItem(parentGroup);
			if (LocalizationManager.IsEnglish())
			{
				descriptionItem.label.text = "Globally increases available Land by " + TextDisplay.Percent(0.02f) + " per building";
			}
			else
			{
				descriptionItem.label.text = string.Format("PerkDescriptionLandCapacity".Localized(), TextDisplay.Percent(0.02f));
			}
			break;
		}
		case BuildingType.JunglePyramid:
		{
			TextLabel descriptionItem8 = GetDescriptionItem(parentGroup);
			if (LocalizationManager.IsEnglish())
			{
				descriptionItem8.label.text = "Globally reduces building costs by " + TextDisplay.Percent(0.05f) + " per building";
			}
			else
			{
				descriptionItem8.label.text = string.Format("PerkDescriptionConstructionEfficiency".Localized(), TextDisplay.Percent(0.05f));
			}
			break;
		}
		case BuildingType.DesertBazaar:
		{
			TextLabel descriptionItem7 = GetDescriptionItem(parentGroup);
			if (LocalizationManager.IsEnglish())
			{
				descriptionItem7.label.text = "Globally increases all Market selling speed by " + TextDisplay.Percent(0.1f) + " per building";
			}
			else
			{
				descriptionItem7.label.text = string.Format("ResearchDescMarketSellSpeed".Localized(), TextDisplay.Percent(0.1f));
			}
			break;
		}
		case BuildingType.SnowTreasureVault:
		{
			TextLabel descriptionItem5 = GetDescriptionItem(parentGroup);
			if (LocalizationManager.IsEnglish())
			{
				descriptionItem5.label.text = "Globally increases coin value for all sold items by " + TextDisplay.Percent(0.1f) + " per building";
			}
			else
			{
				descriptionItem5.label.text = string.Format("SellValue".Localized() + " +" + TextDisplay.Percent(0.1f));
			}
			break;
		}
		case BuildingType.MagicObelisk:
		{
			TextLabel descriptionItem3 = GetDescriptionItem(parentGroup);
			if (LocalizationManager.IsEnglish())
			{
				descriptionItem3.label.text = "Globally increases all XP earnings by " + TextDisplay.Percent(0.1f) + " per building";
			}
			else
			{
				descriptionItem3.label.text = string.Format("TownXPMultiplier".Localized() + " +" + TextDisplay.Percent(0.1f));
			}
			break;
		}
		case BuildingType.FloatingIsland:
		{
			TooltipIconLabelListItem iconLabelItem4 = GetIconLabelItem(parentGroup);
			iconLabelItem4.iconImage.sprite = IconManager.Instance.land;
			iconLabelItem4.primaryLabel.text = string.Format("UpgradeDescriptionBonusLand".Localized(), TextDisplay.LocalizedNumber(displayedTown.ValueForBuilding(buildingType)));
			break;
		}
		case BuildingType.Chute:
		{
			TextLabel descriptionItem2 = GetDescriptionItem(parentGroup);
			string value3 = "PerkDescriptionHarvestingSpeed";
			descriptionItem2.label.text = string.Format(value3.Localized(), TextDisplay.Percent(displayedTown.BonusForBuilding(buildingType)));
			break;
		}
		case BuildingType.Factory:
		case BuildingType.Airship:
		case BuildingType.MagicBoat:
		case BuildingType.Foundry:
			GetDescriptionItem(parentGroup).label.text = string.Format("TooltipProductionBooster".Localized(), TextDisplay.Percent(displayedTown.BonusForBuilding(buildingType)));
			tempEntityList.Clear();
			foreach (KeyValuePair<RecipeType, RecipeState> recipe in displayedTown.recipes)
			{
				foreach (ProductionModifier productionSpeedModifier3 in recipe.Value.productionSpeedModifiers)
				{
					if (productionSpeedModifier3 is ProductionModifierBuildingCount productionModifierBuildingCount && productionModifierBuildingCount.buildingType == buildingType)
					{
						tempEntityList.Add(EntityId.FromRecipe(recipe.Key));
						break;
					}
				}
			}
			LoadEntitiesIntoGrid(tempEntityList, parentGroup);
			break;
		case BuildingType.MagicRailTile:
		{
			EntityId entityId2 = EntityId.FromBuilding(BuildingType.SteamTrain);
			TooltipIconLabelListItem iconLabelItem2 = GetIconLabelItem(parentGroup);
			iconLabelItem2.LoadEntity(entityId2, prependEntityCategory: false);
			iconLabelItem2.primaryLabel.text = string.Format("TooltipEffectivenessBooster".Localized(), TextDisplay.LabelForEntity(entityId2), TextDisplay.Percent(displayedTown.BonusForBuilding(BuildingType.SteamTrain)));
			EntityId entityId3 = EntityId.FromBuilding(BuildingType.Minecart);
			TooltipIconLabelListItem iconLabelItem3 = GetIconLabelItem(parentGroup);
			iconLabelItem3.LoadEntity(entityId3, prependEntityCategory: false);
			iconLabelItem3.primaryLabel.text = string.Format("TooltipEffectivenessBooster".Localized(), TextDisplay.LabelForEntity(entityId3), TextDisplay.Percent(displayedTown.BonusForBuilding(BuildingType.Minecart)));
			break;
		}
		case BuildingType.MagicConveyorBelt:
		{
			EntityId entityId = EntityId.FromBuilding(BuildingType.Factory);
			TooltipIconLabelListItem iconLabelItem = GetIconLabelItem(parentGroup);
			iconLabelItem.LoadEntity(entityId, prependEntityCategory: false);
			iconLabelItem.primaryLabel.text = string.Format("TooltipEffectivenessBooster".Localized(), TextDisplay.LabelForEntity(entityId), TextDisplay.Percent(displayedTown.BonusForBuilding(BuildingType.Factory)));
			break;
		}
		case BuildingType.FireTemple:
		case BuildingType.WaterTemple:
		case BuildingType.EarthTemple:
		case BuildingType.AirTemple:
		case BuildingType.ManaTemple:
		{
			float value2 = displayedTown.BonusForBuilding(buildingType);
			GetDescriptionItem(parentGroup).label.text = string.Format("TooltipProductivityBooster".Localized(), TextDisplay.Percent(value2));
			tempEntityList.Clear();
			switch (buildingType)
			{
			case BuildingType.FireTemple:
				tempEntityList.Add(EntityId.FromRecipe(RecipeType.SmeltPurifiedFire));
				break;
			case BuildingType.ManaTemple:
				tempEntityList.Add(EntityId.FromRecipe(RecipeType.SmeltPurifiedMana));
				break;
			case BuildingType.WaterTemple:
				tempEntityList.Add(EntityId.FromRecipe(RecipeType.SmeltPurifiedWater));
				break;
			case BuildingType.EarthTemple:
				tempEntityList.Add(EntityId.FromRecipe(RecipeType.SmeltPurifiedEarth));
				break;
			case BuildingType.AirTemple:
				tempEntityList.Add(EntityId.FromRecipe(RecipeType.SmeltPurifiedAir));
				break;
			}
			foreach (EntityId tempEntity in tempEntityList)
			{
				GetIconLabelItem(parentGroup).LoadEntity(tempEntity, prependEntityCategory: false);
			}
			break;
		}
		default:
		{
			string text = TextDisplay.DescriptionForBuilding(buildingType);
			if (text != null)
			{
				GetDescriptionItem(parentGroup).label.text = text;
			}
			break;
		}
		case BuildingType.Well:
			break;
		}
		if (Building.HasGlobalEffect(buildingType))
		{
			GetDescriptionItem(parentGroup).label.text = "(" + "TooltipGlobalEffect".Localized() + ")";
		}
		if (displayedTown.buildings.TryGetValue(buildingType, out var value5))
		{
			float num = value5.HousingProvidedPerBuilding(value5.parentTown.LevelOfPerk(PerkType.HousingCapacity));
			if (num > 0f)
			{
				GetDescriptionItem(parentGroup).label.text = string.Format("HousingProvidedFormat".Localized(), TextDisplay.LocalizedNumber(num));
			}
			if (buildingType == BuildingType.House && TextDisplay.HasLocalization("TooltipHouseMarketDemand"))
			{
				GetDescriptionItem(parentGroup).label.text = string.Format("TooltipHouseMarketDemand".Localized(), TextDisplay.LocalizedNumber(num));
			}
			tempEntityList.Clear();
			foreach (SellState value11 in displayedTown.marketItems.Values)
			{
				if (value11.sellData.derivedSellBuilding == buildingType)
				{
					EntityId item = EntityId.FromItem(value11.sellData.coinType);
					if (!tempEntityList.Contains(item))
					{
						tempEntityList.Add(item);
					}
				}
			}
			if (tempEntityList.Count > 0)
			{
				GetDescriptionItem(parentGroup).label.text = "BuildingDescriptionProduction".Localized();
				LoadEntitiesIntoGrid(tempEntityList, parentGroup);
			}
			tempEntityList.Clear();
			foreach (SellState value12 in displayedTown.marketItems.Values)
			{
				if (value12.sellData.derivedSellBuilding == buildingType)
				{
					tempEntityList.Add(EntityId.FromItem(value12.sellData.itemType));
				}
			}
			if (tempEntityList.Count > 0)
			{
				GetDescriptionItem(parentGroup).label.text = "MarketTypeTooltip".Localized();
				LoadEntitiesIntoGrid(tempEntityList, parentGroup);
			}
		}
		if (Crafting.cachedBuildingRecipes.TryGetValue(buildingType, out var value6) && value6.Count > 0)
		{
			GetDescriptionItem(parentGroup).label.text = "BuildingDescriptionProduction".Localized();
			if (Crafting.cachedBuildingItemsProduced.TryGetValue(buildingType, out var value7))
			{
				tempEntityList.Clear();
				foreach (ItemType item2 in value7)
				{
					tempEntityList.Add(EntityId.FromItem(item2));
				}
				LoadEntitiesIntoGrid(tempEntityList, parentGroup);
			}
		}
		switch (category)
		{
		case BuildingCategory.Harvesting:
			GetDescriptionItem(parentGroup).label.text = "BuildingDescriptionHarvesting".Localized();
			tempEntityList.Clear();
			foreach (HarvestDef value13 in Crafting.harvestRecipeCache.Values)
			{
				if (value13.producingBuildingType == buildingType && !displayedTown.IsImpossibleInTown(value13.requirements))
				{
					tempEntityList.Add(EntityId.FromHarvestRecipe(value13.type));
				}
			}
			LoadEntitiesIntoGrid(tempEntityList, parentGroup);
			break;
		case BuildingCategory.Cultivation:
		case BuildingCategory.Prospecting:
		{
			_ = null != parentGroup;
			GetDescriptionItem(parentGroup).label.text = "BuildingDescriptionCultivation".Localized();
			_ = null != parentGroup;
			tempEntityList.Clear();
			if (Crafting.cachedBuildingResources.TryGetValue(buildingType, out var value8))
			{
				foreach (NaturalResource item3 in value8)
				{
					if (!displayedTown.IsResourceImpossible(item3))
					{
						tempEntityList.Add(EntityId.FromNaturalResource(item3));
					}
				}
			}
			if (null != parentGroup)
			{
				LoadEntitiesIntoGrid(tempEntityList, parentGroup);
				break;
			}
			foreach (EntityId tempEntity2 in tempEntityList)
			{
				GetIconLabelItem(parentGroup).LoadEntity(tempEntity2, prependEntityCategory: false);
			}
			break;
		}
		}
		if (value5 == null)
		{
			return;
		}
		float num2 = value5.StorageProvidedPerBuilding();
		if (!(num2 > 0f) || !Crafting.cachedStorageByBuilding.TryGetValue(buildingType, out var value9) || value9.Count <= 0)
		{
			return;
		}
		tempEntityList.Clear();
		foreach (EntityId item4 in value9)
		{
			if (!item4.TryAsNaturalResource(out var i) || !displayedTown.IsResourceImpossible(i))
			{
				tempEntityList.Add(item4);
			}
		}
		if (tempEntityList.Count > 0)
		{
			_ = null != parentGroup;
			GetDescriptionItem(parentGroup).label.text = string.Format("StorageProvidedFormat".Localized(), TextDisplay.LocalizedNumber(num2));
			_ = null != parentGroup;
			LoadEntitiesIntoGrid(tempEntityList, parentGroup);
			_ = null != parentGroup;
		}
	}

	private void LoadFarmingRecipeCostGrid(FarmingRecipe recipeDef, int indentAmount)
	{
		TooltipCostGrid costGridItem = GetCostGridItem();
		costGridItem.iconImage.sprite = IconManager.SpriteForNaturalResource(recipeDef.resource);
		costGridItem.label.text = TextDisplay.LabelForNaturalResource(recipeDef.resource);
		costGridItem.navigationTarget = EntityId.FromFarming(recipeDef.resource);
		foreach (KeyValuePair<ItemType, double> item in recipeDef.inputs.items)
		{
			costGridItem.costGrid.AddEntity(EntityId.FromItem(item.Key), item.Value);
		}
		costGridItem.AddDisplayOnlyCraftArrow();
		costGridItem.costGrid.AddEntity(EntityId.FromFarming(recipeDef.resource), recipeDef.primaryOutputAmount);
		costGridItem.costGrid.PerformLayout();
		costGridItem.SetIndentLevel(indentAmount);
	}

	private void LoadSellRecipeCostGrid(HouseSellData sellData, int indentAmount)
	{
		TooltipCostGrid costGridItem = GetCostGridItem();
		costGridItem.iconImage.sprite = IconManager.SpriteForItem(sellData.itemType);
		costGridItem.label.text = TextDisplay.LabelForItem(sellData.itemType);
		costGridItem.navigationTarget = EntityId.FromItem(sellData.itemType);
		costGridItem.costGrid.AddEntity(EntityId.FromItem(sellData.itemType), 1.0);
		costGridItem.AddDisplayOnlyCraftArrow();
		costGridItem.costGrid.AddEntity(EntityId.FromItem(sellData.coinType), sellData.goldValue);
		costGridItem.costGrid.PerformLayout();
		costGridItem.SetIndentLevel(indentAmount);
	}

	private void LoadHarvestRecipeCostGrid(HarvestDef harvestDef, int indentAmount)
	{
		TooltipCostGrid costGridItem = GetCostGridItem();
		costGridItem.iconImage.sprite = IconManager.SpriteForItem(harvestDef.harvestedItemType);
		costGridItem.label.text = TextDisplay.LabelForItem(harvestDef.harvestedItemType);
		costGridItem.navigationTarget = EntityId.FromHarvestRecipe(harvestDef.type);
		foreach (KeyValuePair<ItemType, double> item in harvestDef.recipe.inputs.items)
		{
			costGridItem.costGrid.AddEntity(EntityId.FromItem(item.Key), item.Value);
		}
		costGridItem.costGrid.AddEntity(EntityId.FromNaturalResource(harvestDef.resourceType), harvestDef.primaryInputMultiplier);
		costGridItem.AddDisplayOnlyCraftArrow();
		foreach (KeyValuePair<ItemType, double> item2 in harvestDef.recipe.outputs.items)
		{
			costGridItem.costGrid.AddEntity(EntityId.FromItem(item2.Key), item2.Value);
		}
		costGridItem.costGrid.PerformLayout();
		costGridItem.SetIndentLevel(indentAmount);
	}

	private void LoadRecipeCostGrid(Recipe recipeDef, int indentAmount)
	{
		TooltipCostGrid costGridItem = GetCostGridItem();
		costGridItem.iconImage.sprite = IconManager.SpriteForRecipe(recipeDef);
		costGridItem.label.text = TextDisplay.LabelForRecipeType(recipeDef.type);
		costGridItem.navigationTarget = EntityId.FromRecipe(recipeDef.type);
		foreach (KeyValuePair<ItemType, double> item in recipeDef.inputs.items)
		{
			costGridItem.costGrid.AddEntity(EntityId.FromItem(item.Key), item.Value);
		}
		costGridItem.AddDisplayOnlyCraftArrow();
		foreach (KeyValuePair<ItemType, double> item2 in recipeDef.outputs.items)
		{
			costGridItem.costGrid.AddEntity(EntityId.FromItem(item2.Key), item2.Value);
		}
		costGridItem.costGrid.PerformLayout();
		costGridItem.SetIndentLevel(indentAmount);
	}

	private void LoadEntitiesIntoGrid(List<EntityId> list, TooltipIndentedLayoutGroup parentGroup = null)
	{
		if (list.Count == 0)
		{
			return;
		}
		LayoutGroup componentInChildren = GetIconGridItem(parentGroup).GetComponentInChildren<LayoutGroup>();
		if (!(null != componentInChildren))
		{
			return;
		}
		int childCount = componentInChildren.transform.childCount;
		int i = 0;
		foreach (EntityId item in list)
		{
			CostIcon costIcon = null;
			CostIcon component2;
			if (i < childCount)
			{
				if (componentInChildren.transform.GetChild(i).gameObject.TryGetComponent<CostIcon>(out var component))
				{
					costIcon = component;
				}
			}
			else if (MenuManager.GetMenuObject(gridIconPrefab, componentInChildren.transform).TryGetComponent<CostIcon>(out component2))
			{
				costIcon = component2;
				costIcon.InitializeButton();
			}
			bool flag = true;
			if (null != costIcon)
			{
				costIcon.ResetState();
				costIcon.showGuideWhenClicked = item.UsesTooltipPanel();
				if (MenuPanel.gm.IsGloballyLocked(item) && !flag)
				{
					costIcon.iconImage.sprite = IconManager.Instance.unknownItem;
				}
				else
				{
					costIcon.iconImage.sprite = IconManager.SpriteForEntity(item);
				}
				costIcon.tooltipEntity = item;
				costIcon.gameObject.SetActive(value: true);
				costIcon.label.enabled = false;
				if (displayedTown.IsImpossibleInTown(Crafting.RequirementsForEntity(item)))
				{
					costIcon.iconImage.color = Color.gray;
				}
				else
				{
					costIcon.iconImage.color = Color.white;
				}
			}
			i++;
		}
		for (; i < componentInChildren.transform.childCount; i++)
		{
			componentInChildren.transform.GetChild(i).gameObject.SetActive(value: false);
		}
	}

	private void ShowGuideForNaturalResource(NaturalResource r)
	{
		itemIcon.sprite = IconManager.SpriteForNaturalResource(r);
		itemLabel.text = TextDisplay.FormattedRewardEntityWithType(EntityId.FromNaturalResource(r));
		if (!Crafting.naturalResourceCache.TryGetValue(r, out var value))
		{
			return;
		}
		TryShowCultivationBuilding(r, alsoShowRecipes: true);
		bool flag = false;
		foreach (HarvestDef value2 in Crafting.harvestRecipeCache.Values)
		{
			if (value2.resourceType == r)
			{
				if (!flag)
				{
					TooltipIconLabelListItem iconLabelItem = GetIconLabelItem();
					iconLabelItem.primaryLabel.text = "Harvesting".Localized() + ":";
					iconLabelItem.iconImage.sprite = IconManager.SpriteForMenuPanel(MenuPanelType.Harvesting);
					flag = true;
				}
				AddIndentedEntity(EntityId.FromBuilding(value2.producingBuildingType));
				LoadHarvestRecipeCostGrid(value2, 2);
			}
		}
		requirementsToDisplay.Clear();
		CalcRequirementsToDisplay(value.requirements, displayedTown);
		ShowQueuedRequirements("Requirements");
		TryShowRewards(value.reward);
	}

	private void TryInsertBuildingHeader(BuildingType t)
	{
		if (!reusableBuildingList.Contains(t))
		{
			reusableBuildingList.Add(t);
			AddIndentedEntity(EntityId.FromBuilding(t));
		}
	}

	private void ShowGuideForItem(ItemType itemType)
	{
		inputItems.Clear();
		outputItems.Clear();
		activeAttributes.Clear();
		itemIcon.sprite = IconManager.SpriteForItem(itemType);
		itemLabel.text = TextDisplay.FormattedRewardEntityWithType(EntityId.FromItem(itemType));
		TryShowExclusiveBiome(itemType);
		TooltipIconLabelListItem iconLabelItem = GetIconLabelItem();
		iconLabelItem.primaryLabel.text = "ProducedBy".Localized() + ":";
		iconLabelItem.iconImage.sprite = IconManager.Instance.accessIn;
		reusableBuildingList.Clear();
		foreach (KeyValuePair<HarvestRecipeType, HarvestDef> item in Crafting.harvestRecipeCache)
		{
			if (item.Value.harvestedItemType == itemType)
			{
				TryInsertBuildingHeader(item.Value.producingBuildingType);
				LoadHarvestRecipeCostGrid(item.Value, 2);
			}
		}
		reusableBuildingList.Clear();
		foreach (KeyValuePair<RecipeType, Recipe> item2 in Crafting.recipeCache)
		{
			if (item2.Value.outputs.Contains(itemType))
			{
				TryInsertBuildingHeader(item2.Value.producingBuildingType);
				LoadRecipeCostGrid(item2.Value, 2);
			}
		}
		if (Item.IsCurrency(itemType) && Crafting.derivedItemBuildingSources.TryGetValue(itemType, out var value))
		{
			foreach (BuildingType item3 in value)
			{
				TryInsertBuildingHeader(item3);
			}
		}
		if (Item.IsCurrency(itemType))
		{
			return;
		}
		TooltipIconLabelListItem iconLabelItem2 = GetIconLabelItem();
		iconLabelItem2.primaryLabel.text = "ConsumedBy".Localized() + ":";
		iconLabelItem2.iconImage.sprite = IconManager.Instance.accessOut;
		reusableBuildingList.Clear();
		foreach (KeyValuePair<NaturalResource, FarmingRecipe> item4 in Crafting.prospectingRecipeCache)
		{
			if (item4.Value.inputs.Contains(itemType))
			{
				TryInsertBuildingHeader(item4.Value.producingBuildingType);
				LoadFarmingRecipeCostGrid(item4.Value, 2);
			}
		}
		reusableBuildingList.Clear();
		foreach (KeyValuePair<NaturalResource, FarmingRecipe> item5 in Crafting.farmingRecipeCache)
		{
			if (item5.Value.inputs.Contains(itemType))
			{
				TryInsertBuildingHeader(item5.Value.producingBuildingType);
				LoadFarmingRecipeCostGrid(item5.Value, 2);
			}
		}
		reusableBuildingList.Clear();
		foreach (KeyValuePair<HarvestRecipeType, HarvestDef> item6 in Crafting.harvestRecipeCache)
		{
			if (item6.Value.recipe.inputs.Contains(itemType))
			{
				TryInsertBuildingHeader(item6.Value.producingBuildingType);
				LoadHarvestRecipeCostGrid(item6.Value, 2);
			}
		}
		reusableBuildingList.Clear();
		foreach (KeyValuePair<RecipeType, Recipe> item7 in Crafting.recipeCache)
		{
			if (item7.Value.inputs.Contains(itemType))
			{
				TryInsertBuildingHeader(item7.Value.producingBuildingType);
				LoadRecipeCostGrid(item7.Value, 2);
			}
		}
		reusableBuildingList.Clear();
		if (Crafting.houseSellData.TryGetValue(itemType, out var value2))
		{
			TryInsertBuildingHeader(value2.derivedSellBuilding);
			LoadSellRecipeCostGrid(value2, 2);
		}
	}

	private void UpdateDisplayForState(ConsumableState consumableState)
	{
		displayedState = consumableState;
		displayedEntity = EntityId.None;
		inputItems.Clear();
		outputItems.Clear();
		activeAttributes.Clear();
		if (consumableState is ResourceState resourceState)
		{
			itemIcon.sprite = IconManager.SpriteForNaturalResource(resourceState.type);
			itemLabel.text = TextDisplay.LabelForNaturalResource(resourceState.type);
		}
		else if (consumableState is ItemState itemState)
		{
			itemIcon.sprite = IconManager.SpriteForItem(itemState.type);
			itemLabel.text = TextDisplay.LabelForItem(itemState.type);
		}
		TooltipCapacityListItem capacityItem = GetCapacityItem();
		capacityItem.loadedState = consumableState;
		capacityItem.descriptionLabel.text = "Inventory".Localized();
		if (isInventoryRegionExpanded)
		{
			ShowCapacityDetails();
			capacityItem.expandSectionImage.sprite = IconManager.Instance.caratExpanded;
		}
		else
		{
			capacityItem.expandSectionImage.sprite = IconManager.Instance.caratCollapsed;
		}
		if (IsShowingGlobalWarehouse() && consumableState is ItemState itemState2)
		{
			TryShowExclusiveBiome(itemState2.type, indented: false);
		}
		if (null == rateChangeRow)
		{
			rateChangeRow = GetAttributeItem();
			rateChangeRow.ConfigureRateChange(displayedState);
		}
		activeAttributes.Add(rateChangeRow);
		if (null == productionHeader)
		{
			productionHeader = GetAttributeItem();
			productionHeader.ConfigureProductionHeader(displayedState);
		}
		productionHeader.UpdateSortDisplay();
		productionHeader.iconImage.sprite = (isProductionRegionExpanded ? IconManager.Instance.caratExpanded : IconManager.Instance.caratCollapsed);
		if (null == productionTotal)
		{
			productionTotal = GetAttributeItem();
			productionTotal.ConfigureProductionTotal(displayedState);
		}
		if (null == consumptionHeader)
		{
			consumptionHeader = GetAttributeItem();
			consumptionHeader.ConfigureConsumptionHeader(displayedState);
		}
		consumptionHeader.UpdateSortDisplay();
		consumptionHeader.iconImage.sprite = (isConsumptionRegionExpanded ? IconManager.Instance.caratExpanded : IconManager.Instance.caratCollapsed);
		if (null == consumptionTotal)
		{
			consumptionTotal = GetAttributeItem();
			consumptionTotal.ConfigureConsumptionTotal(displayedState);
		}
		ReloadLabels();
		isSimulationDataStale = true;
	}

	private void TryShowUniqueBiomeWarning(List<RequirementId> reqs)
	{
		if (reqs == null)
		{
			return;
		}
		foreach (RequirementId req in reqs)
		{
			if (req.type == RequirementType.Biome && req.entityId.TryAsBiome(out var t))
			{
				TooltipIconLabelListItem iconLabelItem = GetIconLabelItem();
				iconLabelItem.iconImage.sprite = IconManager.SpriteForBiome(t);
				iconLabelItem.primaryLabel.text = string.Format("TooltipBiomeUnique".Localized(), TextDisplay.LabelForBiome(t));
			}
		}
	}

	private void TryShowExclusiveBiome(ItemType t, bool indented = true)
	{
		NaturalResource naturalResource = Item.NaturalResourceFromItem(t);
		if (naturalResource != NaturalResource.None && Crafting.naturalResourceCache.TryGetValue(naturalResource, out var value) && value.exclusiveBiome != BiomeType.None)
		{
			TooltipIconLabelListItem iconLabelItem = GetIconLabelItem();
			iconLabelItem.LoadEntity(EntityId.FromBiome(value.exclusiveBiome), prependEntityCategory: false);
			iconLabelItem.primaryLabel.text = TextDisplay.FormattedKeyValue("UniqueResource", TextDisplay.LabelForBiome(value.exclusiveBiome));
		}
	}

	protected override void UpdateSimulationDisplay()
	{
		base.UpdateSimulationDisplay();
		ReloadDynamicItems();
		if (null != productionTotal)
		{
			productionTotal.UpdateSimulationDisplay();
		}
		if (null != consumptionTotal)
		{
			consumptionTotal.UpdateSimulationDisplay();
		}
		foreach (TooltipAttributeListItem activeAttribute in activeAttributes)
		{
			activeAttribute.UpdateSimulationDisplay();
		}
	}

	private void ConfirmCachedInput(ItemRateData d)
	{
		if (!inputItems.TryGetValue(d, out var value))
		{
			value = GetAttributeItem();
			AttributeType attributeType = AttributeType.Consumption;
			value.isTrading = IsShowingGlobalWarehouse();
			value.LoadData(d, attributeType);
			inputItems[d] = value;
			activeAttributes.Add(value);
		}
		relevantAttributes.Add(value);
		value.gameObject.SetActive(value: true);
		if (!reusableUnsortedList.Contains(d))
		{
			reusableUnsortedList.Add(d);
		}
	}

	private void ConfirmCachedOutput(ItemRateData d)
	{
		if (!outputItems.TryGetValue(d, out var value))
		{
			value = GetAttributeItem();
			AttributeType attributeType = AttributeType.Production;
			value.isTrading = IsShowingGlobalWarehouse();
			value.LoadData(d, attributeType);
			outputItems[d] = value;
			activeAttributes.Add(value);
		}
		value.gameObject.SetActive(value: true);
		relevantAttributes.Add(value);
		if (!reusableUnsortedList.Contains(d))
		{
			reusableUnsortedList.Add(d);
		}
	}

	private void ReloadDynamicItems()
	{
		bool flag = displayedState is ItemState itemState && Item.IsCurrency(itemState.type);
		bool flag2 = displayedState is ItemState itemState2 && itemState2.type == ItemType.ExchangeToken;
		_ = scrollRect.verticalScrollbar.value;
		if (displayedState == null)
		{
			return;
		}
		if (flag)
		{
			displayedState.parentTown.CalcCombinedProductionData(displayedState);
		}
		if (flag2)
		{
			displayedState.parentTown.CalcCombinedConsumptionData(displayedState);
		}
		bool active = false;
		relevantAttributes.Clear();
		reusableUnsortedList.Clear();
		foreach (ItemRateData outputRequester in displayedState.outputRequesters)
		{
			if (outputRequester.parentState != null && outputRequester.parentState.HideInTooltip())
			{
				continue;
			}
			active = true;
			if (!isProductionRegionExpanded)
			{
				continue;
			}
			if (flag && outputRequester.parentState?.producingBuilding != null)
			{
				if (displayedState.parentTown.combinedBuildingProductionData.TryGetValue(outputRequester.parentState.producingBuilding, out var value))
				{
					ConfirmCachedOutput(value);
				}
			}
			else
			{
				ConfirmCachedOutput(outputRequester);
			}
		}
		if (null != productionTotal)
		{
			PerformSort(sortOrder, AttributeType.Production);
			int num = productionHeader.transform.GetSiblingIndex();
			foreach (ItemRateData reusableSorted in reusableSortedList)
			{
				num++;
				if (outputItems.TryGetValue(reusableSorted, out var value2))
				{
					value2.transform.SetSiblingIndex(num);
				}
			}
		}
		if (null != productionHeader)
		{
			productionHeader.gameObject.SetActive(active);
		}
		if (null != productionTotal)
		{
			productionTotal.gameObject.SetActive(active);
		}
		reusableUnsortedList.Clear();
		bool active2 = false;
		foreach (ItemRateData inputRequester in displayedState.inputRequesters)
		{
			if (inputRequester.parentState != null && inputRequester.parentState.HideInTooltip())
			{
				continue;
			}
			active2 = true;
			if (!isConsumptionRegionExpanded)
			{
				continue;
			}
			if (flag2 && inputRequester.parentState?.producingBuilding != null)
			{
				if (displayedState.parentTown.combinedBuildingConsumptionData.TryGetValue(inputRequester.parentState.producingBuilding, out var value3))
				{
					ConfirmCachedInput(value3);
				}
			}
			else
			{
				ConfirmCachedInput(inputRequester);
			}
		}
		if (null != consumptionTotal)
		{
			PerformSort(-sortOrder, AttributeType.Consumption);
			int num2 = consumptionHeader.transform.GetSiblingIndex();
			foreach (ItemRateData reusableSorted2 in reusableSortedList)
			{
				num2++;
				if (inputItems.TryGetValue(reusableSorted2, out var value4))
				{
					value4.transform.SetSiblingIndex(num2);
				}
			}
		}
		if (null != consumptionHeader)
		{
			consumptionHeader.gameObject.SetActive(active2);
		}
		if (null != consumptionTotal)
		{
			consumptionTotal.gameObject.SetActive(active2);
		}
		foreach (TooltipAttributeListItem value5 in inputItems.Values)
		{
			if (!relevantAttributes.Contains(value5))
			{
				unusedTooltips.Add(value5);
			}
		}
		foreach (KeyValuePair<ItemRateData, TooltipAttributeListItem> outputItem in outputItems)
		{
			bool flag3 = relevantAttributes.Contains(outputItem.Value);
			if (flag)
			{
				if (outputItem.Key.frameRequestAmount > 0.0)
				{
					flag3 = true;
				}
			}
			else if (relevantAttributes.Contains(outputItem.Value))
			{
				flag3 = true;
			}
			if (!flag3)
			{
				unusedTooltips.Add(outputItem.Value);
			}
		}
		foreach (TooltipAttributeListItem unusedTooltip in unusedTooltips)
		{
			unusedTooltip.gameObject.SetActive(value: false);
			activeAttributes.Remove(unusedTooltip);
		}
		unusedTooltips.Clear();
	}

	private void PerformSort(int order, AttributeType attributeType)
	{
		reusableSortedList.Clear();
		if (sortColumn == SortColumn.Label)
		{
			if (sortOrder == 1)
			{
				reusableSortedList.AddRange(reusableUnsortedList.OrderBy((ItemRateData x) => TooltipAttributeListItem.GetLabel(x, attributeType)));
			}
			else
			{
				reusableSortedList.AddRange(reusableUnsortedList.OrderByDescending((ItemRateData x) => TooltipAttributeListItem.GetLabel(x, attributeType)));
			}
		}
		else if (sortColumn == SortColumn.Potential)
		{
			foreach (ItemRateData reusableUnsorted in reusableUnsortedList)
			{
				if (!(reusableUnsorted is BuildingRateData))
				{
					reusableUnsorted.CalcDisplayedRates();
				}
			}
			reusableSortedList.AddRange(reusableUnsortedList.OrderBy((ItemRateData x) => x.displayedPotentialRate * (double)order));
		}
		else if (sortColumn == SortColumn.PercentPotential)
		{
			foreach (ItemRateData reusableUnsorted2 in reusableUnsortedList)
			{
				if (!(reusableUnsorted2 is BuildingRateData))
				{
					reusableUnsorted2.CalcDisplayedRates();
				}
			}
			reusableSortedList.AddRange(reusableUnsortedList.OrderBy((ItemRateData x) => x.displayedPercentPotential * (float)order));
		}
		else
		{
			reusableSortedList.AddRange(reusableUnsortedList.OrderBy((ItemRateData x) => x.actualFrameDelta * (double)order));
		}
	}

	private TooltipCapacityListItem GetCapacityItem()
	{
		TooltipCapacityListItem item = tooltipCapacityItemPool.GetItem(placementIndex, layoutGroup.transform);
		if (!item.isInitialized)
		{
			item.AddPointerClickTrigger(OnCapacityClicked);
			item.isInitialized = true;
		}
		placementIndex++;
		return item;
	}

	private TooltipRequirementListItem GetRequirementItem()
	{
		TooltipRequirementListItem item = tooltipRequirmentItemPool.GetItem(placementIndex, layoutGroup.transform);
		placementIndex++;
		return item;
	}

	private TooltipIndentedLayoutGroup GetIndentedLayoutGroup()
	{
		TooltipIndentedLayoutGroup item = tooltipLayoutGroupPool.GetItem(placementIndex, layoutGroup.transform);
		placementIndex++;
		item.ResetDisplay();
		return item;
	}

	private TooltipCostGrid GetCostGridItem()
	{
		TooltipCostGrid item = tooltipCostGridItemPool.GetItem(placementIndex, layoutGroup.transform);
		placementIndex++;
		item.ResetDisplay();
		return item;
	}

	private TooltipIconLabelListItem GetIndentedItem(Transform targetTransform, TooltipIndentedLayoutGroup parentGroup = null)
	{
		if (null != parentGroup)
		{
			TooltipIconLabelListItem item = tooltipIndentedItemPool.GetItem(parentGroup.placementIndex, targetTransform);
			parentGroup.placementIndex++;
			item.ResetDisplay();
			return item;
		}
		TooltipIconLabelListItem item2 = tooltipIndentedItemPool.GetItem(placementIndex, targetTransform);
		placementIndex++;
		item2.ResetDisplay();
		return item2;
	}

	private TooltipIconLabelListItem GetIconLabelItem(TooltipIndentedLayoutGroup parentGroup = null)
	{
		if (null != parentGroup)
		{
			TooltipIconLabelListItem item = tooltipIconLabelItemPool.GetItem(placementIndex, parentGroup.layoutGroup.transform);
			parentGroup.placementIndex++;
			item.ResetDisplay();
			return item;
		}
		TooltipIconLabelListItem item2 = tooltipIconLabelItemPool.GetItem(placementIndex, layoutGroup.transform);
		placementIndex++;
		item2.ResetDisplay();
		return item2;
	}

	private TooltipAttributeListItem GetAttributeItem()
	{
		TooltipAttributeListItem item = tooltipAttributePoolGeneral.GetItem(placementIndex, layoutGroup.transform);
		item.ResetState();
		item.parentPanel = this;
		placementIndex++;
		return item;
	}

	private TextLabel GetIndentedDescription()
	{
		TextLabel item = indentedDescriptionItemPool.GetItem(placementIndex, layoutGroup.transform);
		placementIndex++;
		((RectTransform)item.gameObject.transform).SetLeft(100f);
		return item;
	}

	private TextLabel GetDescriptionItem(TooltipIndentedLayoutGroup parentGroup = null)
	{
		if (null != parentGroup)
		{
			TextLabel item = descriptionItemPool.GetItem(parentGroup.placementIndex, parentGroup.layoutGroup.transform);
			parentGroup.placementIndex++;
			return item;
		}
		TextLabel item2 = descriptionItemPool.GetItem(placementIndex, layoutGroup.transform);
		placementIndex++;
		return item2;
	}

	private GameObject GetIconGridItem(TooltipIndentedLayoutGroup parentGroup = null)
	{
		Transform transform = layoutGroup.transform;
		if (null != parentGroup)
		{
			transform = parentGroup.layoutGroup.transform;
		}
		GameObject gameObject;
		if (gridItemIndex < gridItemPool.Count)
		{
			gameObject = gridItemPool[gridItemIndex];
			if (gameObject.transform.parent != transform)
			{
				gameObject.transform.SetParent(transform);
			}
		}
		else
		{
			gameObject = MenuManager.GetMenuObject(tooltipIconGridListItemPrefab, transform);
			gridItemPool.Add(gameObject);
		}
		if (null != parentGroup)
		{
			gameObject.transform.SetSiblingIndex(parentGroup.placementIndex);
			parentGroup.placementIndex++;
		}
		else
		{
			gameObject.transform.SetSiblingIndex(placementIndex);
			placementIndex++;
		}
		gameObject.gameObject.SetActive(value: true);
		gridItemIndex++;
		return gameObject;
	}

	public override void ResetPanel()
	{
		base.ResetPanel();
		ResetToCenter();
	}

	protected void ResetToCenter()
	{
	}

	public void ToggleEntityDescriptionState(EntityId next)
	{
		isInProductionMode = false;
		ToggleEntityPinState(next);
	}

	public void ToggleEntityPinState(EntityId next)
	{
		if (IsVisible() && isPinned && displayedEntity.Equals(next))
		{
			Unpin();
			return;
		}
		LoadEntity(next);
		Pin();
		if (!IsVisible())
		{
			Show();
		}
	}

	public void OnLabelSortClicked()
	{
		if (sortColumn == SortColumn.Label)
		{
			sortOrder *= -1;
		}
		else
		{
			sortColumn = SortColumn.Label;
		}
		productionHeader.UpdateSortDisplay();
		consumptionHeader.UpdateSortDisplay();
	}

	public void OnContributionSortClicked()
	{
		if (sortColumn == SortColumn.Contribution)
		{
			sortOrder *= -1;
		}
		else
		{
			sortColumn = SortColumn.Contribution;
		}
		productionHeader.UpdateSortDisplay();
		consumptionHeader.UpdateSortDisplay();
	}

	public void OnPotentialSortClicked()
	{
		if (sortColumn == SortColumn.Potential)
		{
			sortOrder *= -1;
		}
		else
		{
			sortColumn = SortColumn.Potential;
		}
		productionHeader.UpdateSortDisplay();
		consumptionHeader.UpdateSortDisplay();
	}

	public void OnActualSortClicked()
	{
		if (sortColumn == SortColumn.Actual)
		{
			sortOrder *= -1;
		}
		else
		{
			sortColumn = SortColumn.Actual;
		}
		productionHeader.UpdateSortDisplay();
		consumptionHeader.UpdateSortDisplay();
	}

	public void OnPercentPotentialSortClicked()
	{
		if (sortColumn == SortColumn.PercentPotential)
		{
			sortOrder *= -1;
		}
		else
		{
			sortColumn = SortColumn.PercentPotential;
		}
		productionHeader.UpdateSortDisplay();
		consumptionHeader.UpdateSortDisplay();
	}

	public void OnCapacityClicked()
	{
		isInventoryRegionExpanded = !isInventoryRegionExpanded;
		if (displayedState != null)
		{
			ResetTooltipState();
			UpdateDisplayForState(displayedState);
		}
	}

	public void OnProductionClicked()
	{
		isProductionRegionExpanded = !isProductionRegionExpanded;
		if (displayedState != null)
		{
			ResetTooltipState();
			UpdateDisplayForState(displayedState);
		}
	}

	public void OnConsumptionClicked()
	{
		isConsumptionRegionExpanded = !isConsumptionRegionExpanded;
		if (displayedState != null)
		{
			ResetTooltipState();
			UpdateDisplayForState(displayedState);
		}
	}

	public void ShowCapacityDetails()
	{
		if (displayedState is ItemState { type: var type } itemState)
		{
			TooltipIconLabelListItem iconLabelItem = GetIconLabelItem();
			iconLabelItem.iconImage.sprite = IconManager.Instance.inventory;
			if (itemState.isOutputCapacityInfinite)
			{
				iconLabelItem.primaryLabel.text = TextDisplay.FormattedKeyValue("StorageCapacity", "NoLimit".Localized());
			}
			else
			{
				iconLabelItem.primaryLabel.text = TextDisplay.FormattedKeyValue("StorageCapacity", TextDisplay.LocalizedNumber(itemState.maxCount));
			}
			AddBuildingStorageDetails(EntityId.FromItem(type), itemState.parentTown, itemState.maxConsumePerSecond);
		}
		else if (displayedState is ResourceState resourceState)
		{
			double maxCount = resourceState.parentTown.landState.maxCount;
			float capacityPerLand = resourceState.def.capacityPerLand;
			capacityPerLand *= resourceState.biomeCapacityMultiplier;
			double value = maxCount * (double)capacityPerLand;
			_ = resourceState.def;
			TooltipIconLabelListItem iconLabelItem2 = GetIconLabelItem();
			iconLabelItem2.iconImage.sprite = IconManager.Instance.land;
			StringBuilder pooledStringBuilder = GameUtility.GetPooledStringBuilder();
			pooledStringBuilder.Append(TextDisplay.LocalizedNumber(value));
			pooledStringBuilder.Append(' ');
			pooledStringBuilder.Append('(');
			pooledStringBuilder.Append(TextDisplay.LocalizedNumber(capacityPerLand));
			pooledStringBuilder.Append(" x ");
			pooledStringBuilder.AppendFormat(TextDisplay.LocalizedTwoValueFormat(), TextDisplay.LocalizedNumber(maxCount), "Land".Localized());
			pooledStringBuilder.Append(')');
			iconLabelItem2.primaryLabel.text = TextDisplay.FormattedKeyValue("LandCapacity", GameUtility.ResultOfPooledStringBuilder(pooledStringBuilder));
			float num = resourceState.parentTown.MultiplierForPerk(PerkType.NaturalResourceCapacity);
			if (GameUtility.NotEquals(num, 1f))
			{
				TooltipIconLabelListItem iconLabelItem3 = GetIconLabelItem();
				iconLabelItem3.iconImage.sprite = IconManager.Instance.questCoin;
				iconLabelItem3.primaryLabel.text = string.Format(TextDisplay.LocalizedKeyValueFormat(), TextDisplay.LabelForPerk(PerkType.NaturalResourceCapacity), "x" + TextDisplay.LocalizedNumber(num));
			}
			float num2 = resourceState.parentTown.MultiplierForResearch(ResearchType.InfiniteNaturalResourceCapacity);
			if (GameUtility.NotEquals(num2, 1f))
			{
				TooltipIconLabelListItem iconLabelItem4 = GetIconLabelItem();
				iconLabelItem4.iconImage.sprite = IconManager.Instance.experiencePointOrb;
				iconLabelItem4.primaryLabel.text = string.Format(TextDisplay.LocalizedKeyValueFormat(), TextDisplay.LabelForResearchLevel(ResearchType.InfiniteNaturalResourceCapacity, resourceState.parentTown.LevelOfResearch(ResearchType.InfiniteNaturalResourceCapacity)), "x" + TextDisplay.LocalizedNumber(num2));
			}
			AddBuildingStorageDetails(EntityId.FromNaturalResource(resourceState.type), resourceState.parentTown, resourceState.maxConsumePerSecond);
		}
		if (displayedState.parentTown != null && displayedState.parentTown.LevelOfPerk(PerkType.StorageBoost) > 0)
		{
			TooltipIconLabelListItem iconLabelItem5 = GetIconLabelItem();
			iconLabelItem5.iconImage.sprite = IconManager.SpriteForPerk(PerkType.StorageBoost);
			double num3 = MenuPanel.gm.ValuePerStorageBoostPerkLevel() * (double)displayedState.parentTown.LevelOfPerk(PerkType.StorageBoost);
			string arg = TextDisplay.FormattedRewardEntityWithType(EntityId.FromPerk(PerkType.StorageBoost));
			string arg2 = TextDisplay.LocalizedNumber(displayedState.maxConsumePerSecond * num3);
			iconLabelItem5.primaryLabel.text = string.Format(TextDisplay.LocalizedKeyValueFormat(), arg, arg2);
			TextLabel indentedDescription = GetIndentedDescription();
			string text = "PeakDemand".Localized();
			string text2 = "Multiplier".Localized();
			indentedDescription.label.text = "   " + text + " (" + TextDisplay.LocalizedNumber(displayedState.maxConsumePerSecond) + ") x " + text2 + " (" + TextDisplay.Percent(GameUtility.AsTruncatedFloat(num3)) + ") ";
		}
		if (displayedState.parentTown != null && displayedState.parentTown.storageBoostMultiplier > 0f)
		{
			TooltipIconLabelListItem iconLabelItem6 = GetIconLabelItem();
			iconLabelItem6.iconImage.sprite = IconManager.Instance.inventory;
			string arg3 = TextDisplay.LocalizedNumber((double)displayedState.parentTown.storageBoostMultiplier * displayedState.maxCount);
			string arg4 = TextDisplay.FormattedRewardEntityWithType(EntityId.FromPerk(PerkType.StorageBoost));
			iconLabelItem6.primaryLabel.text = string.Format(TextDisplay.LocalizedKeyValueFormat(), arg4, arg3);
		}
	}

	private void AddBuildingStorageDetails(EntityId id, Town town, double maxConsumePerSecond)
	{
		if (town == null)
		{
			double num = 0.0;
			double num2 = GameManager.Instance.ValuePerRailDepot();
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			foreach (Town town2 in MenuPanel.gm.towns)
			{
				if (town2 != null)
				{
					num += town2.StorageByBuildingType(BuildingType.TradingPost);
					num4 += (double)town2.NumBuildingsOfType(BuildingType.TradingPost);
					num3 += (double)town2.NumBuildingsOfType(BuildingType.RailDepot);
					num5 += town2.StorageByBuildingType(BuildingType.RailDepot);
				}
			}
			if (num > 0.0)
			{
				TooltipIconLabelListItem iconLabelItem = GetIconLabelItem();
				iconLabelItem.iconImage.sprite = IconManager.SpriteForBuilding(BuildingType.TradingPost);
				iconLabelItem.primaryLabel.text = string.Format(TextDisplay.LocalizedKeyValueFormat(), TextDisplay.LabelForBuilding(BuildingType.TradingPost) ?? "", "+" + TextDisplay.LocalizedNumber(num));
			}
			if (num5 > 0.0)
			{
				TooltipIconLabelListItem iconLabelItem2 = GetIconLabelItem();
				iconLabelItem2.iconImage.sprite = IconManager.SpriteForBuilding(BuildingType.RailDepot);
				iconLabelItem2.primaryLabel.text = string.Format(TextDisplay.LocalizedKeyValueFormat(), TextDisplay.LabelForBuilding(BuildingType.RailDepot) ?? "", "+" + TextDisplay.LocalizedNumber(num5));
			}
			if (num3 > 0.0 && num2 > 0.0)
			{
				TooltipIconLabelListItem iconLabelItem3 = GetIconLabelItem();
				iconLabelItem3.iconImage.sprite = IconManager.SpriteForBuilding(BuildingType.RailDepot);
				iconLabelItem3.primaryLabel.text = string.Format(TextDisplay.LocalizedKeyValueFormat(), TextDisplay.LabelForBuilding(BuildingType.RailDepot) + " ", "+" + TextDisplay.LocalizedNumber(num2 * maxConsumePerSecond * num3));
				TextLabel indentedDescription = GetIndentedDescription();
				string text = "PeakDemand".Localized();
				string text2 = Strings.Def("Depot Multiplier", "StorageCapacity".Localized());
				string text3 = Strings.Def("Num Depots", "Buildings".Localized());
				indentedDescription.label.text = "   " + text + " (" + TextDisplay.LocalizedNumber(maxConsumePerSecond) + ") x " + text2 + " (" + TextDisplay.LocalizedNumber(num2) + ") x " + text3 + " (" + TextDisplay.LocalizedNumber(num3) + ") ";
			}
			float num6 = MenuPanel.gm.MultiplierForGlobalPerk(PerkType.GlobalTradingCapacity);
			if (num6 > 0f)
			{
				TooltipIconLabelListItem iconLabelItem4 = GetIconLabelItem();
				iconLabelItem4.iconImage.sprite = IconManager.SpriteForPerk(PerkType.GlobalTradingCapacity);
				string arg = TextDisplay.FormattedRewardEntityWithType(EntityId.FromPerk(PerkType.GlobalTradingCapacity));
				string arg2 = TextDisplay.LocalizedNumber(displayedState.maxConsumePerSecond * (double)num6);
				iconLabelItem4.primaryLabel.text = string.Format(TextDisplay.LocalizedKeyValueFormat(), arg, arg2);
				TextLabel indentedDescription2 = GetIndentedDescription();
				string text4 = "PeakDemand".Localized();
				string text5 = "Multiplier".Localized();
				indentedDescription2.label.text = "   " + text4 + " (" + TextDisplay.LocalizedNumber(displayedState.maxConsumePerSecond) + ") x " + text5 + " (" + TextDisplay.Percent(GameUtility.AsTruncatedFloat(num6)) + ") ";
			}
		}
		else
		{
			if (!Crafting.cachedStorageByEntity.TryGetValue(id, out var value))
			{
				return;
			}
			foreach (BuildingType item in value)
			{
				double num7 = 0.0;
				num7 = town.StorageByBuildingType(item);
				if (!(num7 <= 0.0))
				{
					TooltipIconLabelListItem iconLabelItem5 = GetIconLabelItem();
					iconLabelItem5.iconImage.sprite = IconManager.SpriteForBuilding(item);
					iconLabelItem5.primaryLabel.text = string.Format(TextDisplay.LocalizedKeyValueFormat(), TextDisplay.LabelForBuilding(item), "+" + TextDisplay.LocalizedNumber(num7));
				}
			}
		}
	}
}
