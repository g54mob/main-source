using System;
using System.Collections.Generic;
using UnityEngine;

public class BuildingState : CountableState
{
	public readonly AssignableState settings = new AssignableState();

	public readonly BuildingDef buildingDef;

	public readonly BuildingType type;

	public ItemList dynamicCost = new ItemList(4);

	public BuildObjectAvailability availability;

	public readonly ItemList tempCost = new ItemList();

	public readonly RequirementGroup unlockRequirements = new RequirementGroup();

	public ConstructionState constructionState;

	public int pendingConstructions;

	[NonSerialized]
	public bool cachedCanRemoveState;

	[NonSerialized]
	public bool hasUpgradeAvailable;

	public readonly List<StateManager> dependentStates = new List<StateManager>();

	private readonly List<Upgrade> storageUpgrades = new List<Upgrade>();

	private Upgrade workersPerBuildingUpgrade;

	private Upgrade omniCapacityUpgrade;

	[NonSerialized]
	public double happinessTotal;

	[NonSerialized]
	public double happinessCount;

	[NonSerialized]
	public List<Upgrade> linkedUpgrades = new List<Upgrade>();

	[NonSerialized]
	public bool isUpgradeAvailabilityStale;

	public double totalProductionCapacity;

	public BuildingState(BuildingDef def, Town parent)
	{
		type = def.type;
		buildingDef = def;
		parentTown = parent;
		settings.productionLimit.parentBuilding = this;
	}

	public override void Reset()
	{
		base.Reset();
		settings.Reset();
		availability = BuildObjectAvailability.Locked;
		constructionState.Reset();
		pendingConstructions = 0;
		settings.productionLimit.Reset();
	}

	public bool AllowGradualBuilding()
	{
		return true;
	}

	public void StoreItemStateCache()
	{
		GameManager.Instance.StoreRequirementCacheInTarget(buildingDef.requirements, parentTown, unlockRequirements.requirements);
		foreach (UpgradeType storageCapacityUpgrade in buildingDef.storageCapacityUpgrades)
		{
			if (parentTown.upgrades.TryGetValue(storageCapacityUpgrade, out var value))
			{
				storageUpgrades.Add(value);
			}
		}
		if (Data.Instance.marketCapacityUpgrades.TryGetValue(type, out var value2) && parentTown.upgrades.TryGetValue(value2, out var value3))
		{
			workersPerBuildingUpgrade = value3;
		}
		if (Data.Instance.productionCapacityUpgrades.TryGetValue(type, out var value4) && parentTown.upgrades.TryGetValue(value4, out var value5))
		{
			workersPerBuildingUpgrade = value5;
		}
		UpgradeType omniCapacityUpgradeType = GetOmniCapacityUpgradeType(type);
		if (omniCapacityUpgradeType != UpgradeType.None && parentTown.upgrades.TryGetValue(omniCapacityUpgradeType, out var value6))
		{
			omniCapacityUpgrade = value6;
		}
		EntityId entityId = AsEntity();
		foreach (Upgrade value7 in parentTown.upgrades.Values)
		{
			if (value7.def.linkedEntity.Equals(entityId) || value7.def.popupParentEntity.Contains(entityId))
			{
				linkedUpgrades.Add(value7);
			}
		}
	}

	public bool HasLandCapacityForSingleBuilding()
	{
		if (buildingDef.landRequired <= 0)
		{
			return true;
		}
		return parentTown.unusedHousingPlots >= (double)buildingDef.landRequired;
	}

	public bool HasWorkerCapacityForSingleBuilding()
	{
		if (buildingDef.workersRequired <= 0)
		{
			return true;
		}
		return parentTown.workerState.numAvailable >= (double)buildingDef.workersRequired;
	}

	public bool CanCreateBuilding()
	{
		if (GameManager.freeMode)
		{
			return true;
		}
		return availability == BuildObjectAvailability.Available;
	}

	public bool CanAffordBuilding()
	{
		foreach (ItemRateData item in constructionState.input)
		{
			if (item.totalAmount > item.state.currentCount)
			{
				return false;
			}
		}
		return true;
	}

	public void CompleteConstructionGradual()
	{
		pendingConstructions--;
		constructionState.isUnitProgressHardCapped = (float)pendingConstructions <= 1f;
		Build();
		if (pendingConstructions == 0)
		{
			constructionState.cumulativeUnitProgress = currentCount;
		}
		parentTown.OnBuildingCreated(type, isGradual: true);
	}

	public void CompleteConstructionInstant()
	{
		Build();
		parentTown.OnBuildingCreated(type, isGradual: false);
	}

	public void CacheRemovalState(int num)
	{
		cachedCanRemoveState = CanRemove(num);
	}

	public int WorkerCapacityPerBuilding()
	{
		float num = 1f;
		if (type == BuildingType.Market)
		{
			num = 2f;
		}
		else if (type == BuildingType.GeneralGoods)
		{
			num = 2f;
		}
		else if (type == BuildingType.TradingPost)
		{
			num = 5f;
		}
		else if (type == BuildingType.House)
		{
			float num2 = parentTown.MultiplierForUpgrade(UpgradeType.HouseCapacity);
			float num3 = parentTown.MultiplierForPerk(PerkType.HousingCapacity);
			num = num2 * num3;
		}
		else if (type == BuildingType.HarvesterHut)
		{
			num = Data.DefaultHarvesterHutCapacity;
			num += workersPerBuildingUpgrade.GetMultiplier();
		}
		if (workersPerBuildingUpgrade != null)
		{
			num += workersPerBuildingUpgrade.GetMultiplier();
		}
		if (omniCapacityUpgrade != null)
		{
			num += omniCapacityUpgrade.GetMultiplier();
		}
		return Mathf.RoundToInt(num);
	}

	public bool CanRemove(int num)
	{
		if (pendingConstructions > 0)
		{
			return true;
		}
		float num2 = GameUtility.AsFloat(currentCount - (double)num);
		if (buildingDef.workerHousingProvided > 0)
		{
			int housingPerkLevel = parentTown.LevelOfPerk(PerkType.HousingCapacity);
			float num3 = HousingProvidedAtCount(GameUtility.AsFloat(currentCount), housingPerkLevel);
			float num4 = HousingProvidedAtCount(num2, housingPerkLevel);
			if ((double)(num3 - num4) > parentTown.workerState.numAvailable)
			{
				return false;
			}
		}
		if (buildingDef.type == BuildingType.FloatingIsland)
		{
			float num5 = parentTown.BonusForBuilding(BuildingType.FloatingIsland);
			if (parentTown.landState.numAvailable < (double)num5)
			{
				return false;
			}
		}
		if (buildingDef.category == BuildingCategory.Storage)
		{
			return true;
		}
		int num6 = WorkerCapacityPerBuilding();
		double num7 = currentCount * (double)num6;
		float num8 = num2 * (float)num6;
		if (num7 - (double)num8 > numAvailable)
		{
			return false;
		}
		return true;
	}

	public float HousingProvidedPerBuilding(int housingPerkLevel)
	{
		int workerHousingProvided = buildingDef.workerHousingProvided;
		if ((float)workerHousingProvided <= 0f)
		{
			return 0f;
		}
		float num = parentTown.MultiplierForUpgrade(UpgradeType.HouseCapacity);
		float num2 = CountableState.gm.AdjustedMultiplierForPerkLevel(PerkType.HousingCapacity, housingPerkLevel);
		return (float)workerHousingProvided * num * num2;
	}

	public float HousingProvidedAtCount(float count, int housingPerkLevel)
	{
		return Mathf.Floor(HousingProvidedPerBuilding(housingPerkLevel) * count);
	}

	public void Build()
	{
		currentCount += 1.0;
		constructionState.isCostAlreadyPaid = false;
		SetDisplayedCostStale();
		StoreNextConstructionCost();
	}

	public void CalcAvailability()
	{
		if (availability == BuildObjectAvailability.Locked && unlockRequirements.IsMet())
		{
			availability = BuildObjectAvailability.Available;
			constructionState.Unlock();
		}
	}

	public void LoadIntoTempCost(double growthCount)
	{
		float costGrowthFactor = Crafting.GetCachedBuildingDef(type).costGrowthFactor;
		int num = GameUtility.RoundToInt(growthCount);
		ItemList freshItemList = GameUtility.GetFreshItemList();
		freshItemList.AddList(Crafting.GetCachedBuildingCost(type));
		switch (type)
		{
		case BuildingType.House:
			freshItemList.Clear();
			freshItemList.AddItem(ItemType.UtilityLand, 1.0);
			if (num < 10)
			{
				freshItemList.AddItem(ItemType.Wood, 4.0);
			}
			else if (num <= 15)
			{
				freshItemList.AddItem(ItemType.Plank, 3.0);
				freshItemList.AddItem(ItemType.YellowCoin, 3.0);
			}
			else if (growthCount < 20.0)
			{
				freshItemList.AddItem(ItemType.Plank, 3.0);
				freshItemList.AddItem(ItemType.Stone, 3.0);
				freshItemList.AddItem(ItemType.YellowCoin, 3.0);
			}
			else if (growthCount < 25.0)
			{
				freshItemList.AddItem(ItemType.Plank, 3.0);
				freshItemList.AddItem(ItemType.StoneSlab, 3.0);
				freshItemList.AddItem(ItemType.YellowCoin, 3.0);
			}
			else if (growthCount < 30.0)
			{
				freshItemList.AddItem(ItemType.RefinedPlank, 2.0);
				freshItemList.AddItem(ItemType.StoneSlab, 3.0);
				freshItemList.AddItem(ItemType.YellowCoin, 4.0);
			}
			else if (growthCount < 40.0)
			{
				freshItemList.AddItem(ItemType.RefinedPlank, 2.0);
				freshItemList.AddItem(ItemType.RefinedStoneBrick, 2.0);
				freshItemList.AddItem(ItemType.YellowCoin, 5.0);
			}
			else if (growthCount < 50.0)
			{
				freshItemList.AddItem(ItemType.RefinedPlank, 2.0);
				freshItemList.AddItem(ItemType.RefinedStoneBrick, 2.0);
				freshItemList.AddItem(ItemType.GlassPanel, 0.1);
				freshItemList.AddItem(ItemType.YellowCoin, 6.0);
			}
			else if (growthCount < 60.0)
			{
				freshItemList.AddItem(ItemType.ReinforcedPlank, 1.0);
				freshItemList.AddItem(ItemType.RefinedStoneBrick, 1.0);
				freshItemList.AddItem(ItemType.GlassPanel, 0.1);
				freshItemList.AddItem(ItemType.YellowCoin, 7.0);
			}
			else
			{
				freshItemList.AddItem(ItemType.Steel, 1.0);
				freshItemList.AddItem(ItemType.GlassPanel, 0.1);
				freshItemList.AddItem(ItemType.YellowCoin, 8.0);
			}
			break;
		case BuildingType.GeneralGoods:
			freshItemList.Clear();
			if (growthCount < 10.0)
			{
				freshItemList.AddItem(ItemType.Wood, 10.0);
				break;
			}
			if (growthCount < 20.0)
			{
				freshItemList.AddItem(ItemType.Plank, 10.0);
				break;
			}
			freshItemList.AddItem(ItemType.Plank, 10.0);
			freshItemList.AddItem(ItemType.Stone, 10.0);
			freshItemList.AddItem(ItemType.YellowCoin, 10.0);
			break;
		case BuildingType.School:
			if (growthCount < 3.0)
			{
				freshItemList.RemoveAll(ItemType.StoneSlab);
			}
			break;
		case BuildingType.LumberMill:
			if (growthCount < 20.0)
			{
				freshItemList.RemoveAll(ItemType.Stone);
			}
			else
			{
				freshItemList.RemoveAll(ItemType.Wood);
			}
			break;
		case BuildingType.HarvesterHut:
			if (growthCount < 10.0)
			{
				freshItemList.RemoveAll(ItemType.YellowCoin);
			}
			if (growthCount >= 20.0)
			{
				double num2 = freshItemList.Count(ItemType.Wood);
				freshItemList.RemoveAll(ItemType.Wood);
				freshItemList.AddItem(ItemType.Plank, num2 / 2.0);
			}
			break;
		case BuildingType.Market:
			if (growthCount < 3.0)
			{
				freshItemList.RemoveAll(ItemType.YellowCoin);
			}
			break;
		case BuildingType.FishingBoat:
			if (growthCount < 10.0)
			{
				freshItemList.Clear();
				freshItemList.AddItem(ItemType.Plank, 10.0);
			}
			break;
		}
		foreach (KeyValuePair<ItemType, double> item in freshItemList.items)
		{
			if (Item.IsUtility(item.Key))
			{
				tempCost.AddItem(item.Key, item.Value);
				continue;
			}
			double value = item.Value;
			float num3 = parentTown.MultiplierForUpgrade(UpgradeType.ConstructionEfficiency) * costGrowthFactor;
			float num4 = 1f;
			foreach (UpgradeType growthCostUpgrade in buildingDef.growthCostUpgrades)
			{
				num4 *= parentTown.MultiplierForUpgrade(growthCostUpgrade);
			}
			num3 *= num4;
			double num5 = 300.0 / (growthCount + 250.0) + 1.0;
			if (num5 < 1.0499999523162842)
			{
				num5 = 1.05;
			}
			double x = num5;
			if (!Item.IsCurrency(item.Key))
			{
				num3 *= 0.8f;
			}
			double num6 = Math.Pow(x, growthCount * (double)num3);
			double num7 = value * num6;
			num7 *= (double)parentTown.MultiplierForPerk(PerkType.ConstructionCost);
			num7 *= CountableState.gm.wonderMultiplierPyramid;
			foreach (UpgradeType flatCostUpgrade in buildingDef.flatCostUpgrades)
			{
				num7 *= (double)parentTown.MultiplierForUpgrade(flatCostUpgrade);
			}
			if (!Item.IsCurrency(item.Key))
			{
				float num8 = CountableState.gm.MultiplierForGlobalPerk(PerkType.ConstructionEfficiency);
				num7 = ((!(num8 <= 0f)) ? (num7 * (double)num8) : 0.0);
			}
			ItemType key = item.Key;
			if (num7 <= 0.0)
			{
				continue;
			}
			if (num7 < 3.4028234663852886E+38)
			{
				float num9 = GameUtility.RoundToFloat(num7);
				if (num9 <= 1f)
				{
					num9 = 1f;
				}
				tempCost.AddItem(key, num9);
			}
			else
			{
				tempCost.AddItem(key, GameUtility.CappedDouble(num7));
			}
		}
		if (type == BuildingType.Quarry)
		{
			if (growthCount >= 20.0)
			{
				SwapCost(ItemType.Plank, ItemType.RefinedPlank, 0.5f);
			}
			if (growthCount >= 40.0)
			{
				SwapCost(ItemType.RefinedPlank, ItemType.ReinforcedPlank, 0.25f);
			}
			if (growthCount >= 60.0)
			{
				SwapCost(ItemType.ReinforcedPlank, ItemType.Steel, 0.25f);
			}
		}
		if (type == BuildingType.Mine)
		{
			if (growthCount >= 5.0)
			{
				SwapCost(ItemType.Plank, ItemType.RefinedPlank, 0.5f);
			}
			if (growthCount >= 20.0)
			{
				SwapCost(ItemType.RefinedPlank, ItemType.ReinforcedPlank, 0.25f);
			}
			if (growthCount >= 30.0)
			{
				SwapCost(ItemType.ReinforcedPlank, ItemType.Steel, 0.25f);
			}
		}
		else if (type == BuildingType.LumberMill || type == BuildingType.GrainMill || type == BuildingType.Workshop || type == BuildingType.Market || type == BuildingType.GeneralGoods || type == BuildingType.HardwareStore || type == BuildingType.ClothingStore || type == BuildingType.Apothecary || type == BuildingType.School || type == BuildingType.Tailor || type == BuildingType.StoneMason || type == BuildingType.Pasture || type == BuildingType.Forester || type == BuildingType.Farm || type == BuildingType.Fishery || type == BuildingType.Forge || type == BuildingType.MedicineHut || type == BuildingType.Well)
		{
			if (growthCount >= 20.0)
			{
				SwapCost(ItemType.Wood, ItemType.Plank, 0.5f);
				SwapCost(ItemType.Stone, ItemType.StoneSlab, 0.5f);
			}
			if (growthCount >= 25.0 && type != BuildingType.StoneMason)
			{
				SwapCost(ItemType.Plank, ItemType.RefinedPlank, 0.5f);
				SwapCost(ItemType.StoneSlab, ItemType.RefinedStoneBrick, 0.5f);
			}
		}
		else if (type == BuildingType.MachineShop && growthCount >= 10.0)
		{
			SwapCost(ItemType.ReinforcedPlank, ItemType.Steel, 0.25f);
		}
		if (type == BuildingType.MagicLab)
		{
			if (growthCount >= 10.0)
			{
				SwapCost(ItemType.RefinedStoneBrick, ItemType.MagicStoneBrick, 0.25f);
				SwapCost(ItemType.RefinedPlank, ItemType.MagicPlank, 0.25f);
			}
		}
		else if (type == BuildingType.Furnace && growthCount >= 20.0)
		{
			SwapCost(ItemType.IronIngot, ItemType.Steel, 0.25f);
		}
	}

	public void StoreNextConstructionCost()
	{
		constructionState.StoreItemStateCache();
		constructionState.PerformCalcSpeed();
	}

	public void SetDisplayedCostStale()
	{
		dynamicCost.FlagHashStale();
	}

	public void CalcDisplayedCost()
	{
		double num = currentCount + (double)pendingConstructions;
		dynamicCost.Clear();
		tempCost.Clear();
		for (int i = 0; i < UserInput.activeGlobalIncrement; i++)
		{
			LoadIntoTempCost(num + (double)i);
		}
		foreach (KeyValuePair<ItemType, double> item in tempCost.items)
		{
			dynamicCost.AddItem(item.Key, item.Value);
		}
		dynamicCost.CalcHashCode();
	}

	private void SwapCost(ItemType from, ItemType to, float ratio)
	{
		if (tempCost.items.TryGetValue(from, out var value))
		{
			tempCost.RemoveAll(from);
			tempCost.AddItem(to, value * (double)ratio);
		}
	}

	public override EntityId AsEntity()
	{
		return EntityId.FromBuilding(type);
	}

	public override string ToString()
	{
		return "Building " + type;
	}

	public void CalcCapacity()
	{
		totalProductionCapacity = Capacity();
	}

	public override double DefaultCapacity()
	{
		if (buildingDef.isWonder && parentTown != null)
		{
			return parentTown.WonderCapacity();
		}
		return double.MaxValue;
	}

	public float StorageProvidedPerBuilding()
	{
		int storageAmount = buildingDef.storageAmount;
		if ((float)storageAmount <= 0f)
		{
			return 0f;
		}
		float num = MultiplierForBuildingStorage();
		return (float)storageAmount * num;
	}

	public static UpgradeType GetOmniCapacityUpgradeType(BuildingType t)
	{
		return t switch
		{
			BuildingType.Market => UpgradeType.OmniCapacityFoodMarket, 
			BuildingType.GeneralGoods => UpgradeType.OmniCapacityGeneralStore, 
			BuildingType.HardwareStore => UpgradeType.OmniCapacityHardwareStore, 
			BuildingType.Bookstore => UpgradeType.OmniCapacityBookstore, 
			BuildingType.ClothingStore => UpgradeType.OmniCapacityClothingStore, 
			BuildingType.FancyFoods => UpgradeType.OmniCapacityGourmetFoods, 
			BuildingType.Apothecary => UpgradeType.OmniCapacityApothecary, 
			BuildingType.JewelryStore => UpgradeType.OmniCapacityJewelryStore, 
			BuildingType.ArcaneStore => UpgradeType.OmniCapacityArcaneStore, 
			_ => UpgradeType.None, 
		};
	}

	private float MultiplierForBuildingStorage()
	{
		float num = 1f;
		if (storageUpgrades != null)
		{
			foreach (Upgrade storageUpgrade in storageUpgrades)
			{
				num *= storageUpgrade.GetMultiplier();
			}
		}
		return num;
	}

	public bool TryConstruct()
	{
		if (!HasLandCapacityForSingleBuilding())
		{
			MenuManager.Instance.townStatsPanel.AnimateHousingPlotStat();
			MenuManager.Instance.ShowMessage(InvalidReason.NotEnoughLand);
			return false;
		}
		if (!HasWorkerCapacityForSingleBuilding())
		{
			MenuManager.Instance.townStatsPanel.AnimateWorkerStat();
			MenuManager.Instance.ShowMessage(InvalidReason.NotEnoughWorkers);
			return false;
		}
		if (currentCount + (double)pendingConstructions >= maxCount)
		{
			return false;
		}
		if (GameManager.freeMode)
		{
			CompleteConstructionInstant();
			return true;
		}
		if (CanCreateBuilding())
		{
			constructionState.isCostAlreadyPaid = false;
			if (pendingConstructions == 0)
			{
				SoundManager.PlayBuildSound();
			}
			pendingConstructions++;
			constructionState.isUnitProgressHardCapped = pendingConstructions <= 1;
			constructionState.OnNumWorkersChanged(1f);
			constructionState.PerformCalcSpeed();
			parentTown.CalcUnusedHousingPlots();
			parentTown.CalcUnassignedWorkers();
			return true;
		}
		bool flag = false;
		if (LocalizationManager.IsEnglish())
		{
			foreach (ItemRateData item in constructionState.input)
			{
				flag = ((item.totalAmount > item.state.currentCount && item.state is ItemState { type: ItemType.Wood }) ? true : false);
			}
		}
		if (flag)
		{
			MenuManager.Instance.ShowMessage("Need to harvest more Wood! Click to harvest manually or assign the task to workers at the Harvesting Hut");
		}
		else
		{
			MenuManager.Instance.ShowMessage(InvalidReason.NeedMoreItems);
		}
		return false;
	}

	public void TryRemoveConstruction()
	{
		if (pendingConstructions > 0)
		{
			int num = Mathf.Min(pendingConstructions, UserInput.activeGlobalIncrement);
			pendingConstructions -= num;
			constructionState.isUnitProgressHardCapped = pendingConstructions <= 1;
			if (pendingConstructions == 0)
			{
				constructionState.unitProgress = 0.0;
				constructionState.cumulativeUnitProgress = currentCount;
				constructionState.cumulativeUnitProgressPrev = currentCount;
			}
			if (pendingConstructions <= 0)
			{
				constructionState.StopConstruction();
			}
		}
		else if (currentCount > 0.0)
		{
			double num2 = Math.Min(currentCount, UserInput.activeGlobalIncrement);
			currentCount -= num2;
		}
		CalcDisplayedCost();
		StoreNextConstructionCost();
		GameManager.Instance.OnBuildingModified(parentTown, type);
		parentTown.CalcUnassignedBuildings(this);
		GameManager.Instance.ProcessMetadataQueue();
		if (parentTown == CountableState.gm.activeTown)
		{
			parentTown.OnBuildingModifiedInActiveTown(type);
		}
	}

	public void FormatAddButton(MenuButton b)
	{
		switch (MaxStateFlag())
		{
		case 1:
			b.invalidReason = InvalidReason.NotEnoughLand;
			b.buttonState = CustomButtonState.Disabled;
			return;
		case 2:
			b.invalidReason = InvalidReason.NotEnoughWorkers;
			b.buttonState = CustomButtonState.Disabled;
			return;
		case 3:
			b.invalidReason = InvalidReason.MaxBuildings;
			b.buttonState = CustomButtonState.Disabled;
			return;
		}
		if (CanCreateBuilding())
		{
			b.invalidReason = InvalidReason.None;
			b.buttonState = CustomButtonState.Default;
			if (type == BuildingType.House && CountableState.gm.isPromptingForHouse && constructionState.numWorkersAssigned <= 0f)
			{
				b.buttonState = CustomButtonState.HighlightFlashing;
			}
			if (type == BuildingType.HarvesterHut && CountableState.gm.isPromptingForHarvesterHut && constructionState.numWorkersAssigned <= 0f)
			{
				b.buttonState = CustomButtonState.HighlightFlashing;
			}
		}
		else
		{
			b.invalidReason = InvalidReason.NeedMoreItems;
			b.buttonState = CustomButtonState.Disabled;
		}
	}

	public void FormatRemoveButton(MenuButton b)
	{
		if (pendingConstructions > 0)
		{
			b.buttonState = CustomButtonState.Default;
			b.invalidReason = InvalidReason.None;
		}
		else if (cachedCanRemoveState)
		{
			b.buttonState = CustomButtonState.Default;
			b.invalidReason = InvalidReason.None;
		}
		else if (currentCount <= 0.0 && pendingConstructions == 0)
		{
			b.buttonState = CustomButtonState.Disabled;
			b.invalidReason = InvalidReason.AlreadyAtZeroBuildings;
		}
		else
		{
			b.buttonState = CustomButtonState.Disabled;
			b.invalidReason = InvalidReason.BuildingInUse;
		}
	}

	public int MaxStateFlag()
	{
		if (!HasLandCapacityForSingleBuilding())
		{
			return 1;
		}
		if (!HasWorkerCapacityForSingleBuilding())
		{
			return 2;
		}
		if (currentCount + (double)pendingConstructions >= maxCount)
		{
			return 3;
		}
		return 0;
	}

	public void CalcUpgradeAffordability()
	{
		hasUpgradeAvailable = false;
		foreach (Upgrade linkedUpgrade in linkedUpgrades)
		{
			if (linkedUpgrade.IsReadyToPurchase())
			{
				hasUpgradeAvailable = true;
				break;
			}
		}
	}

	public int GetProductionCapacityHash()
	{
		int num = 0;
		num = 17;
		double value;
		double value2;
		if (type == BuildingType.House)
		{
			value = parentTown.workerState.numAvailable;
			value2 = parentTown.workerState.currentCount;
		}
		else
		{
			value = numAvailable;
			value2 = totalProductionCapacity;
		}
		num = 37 * num + GameUtility.AsTruncatedInt(value);
		return 37 * num + GameUtility.AsTruncatedInt(value2);
	}

	public void AssignDefaultAutoAssign()
	{
		if (GameManager.Instance.isAutoAssignDefault && (buildingDef.category == BuildingCategory.Cultivation || buildingDef.category == BuildingCategory.Harvesting || buildingDef.category == BuildingCategory.Markets || buildingDef.category == BuildingCategory.Research || buildingDef.category == BuildingCategory.Production || buildingDef.category == BuildingCategory.Prospecting))
		{
			settings.autoAssign.InitializeValue(OverrideState.On);
		}
	}
}
