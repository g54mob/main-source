using UnityEngine;

public class SellState : StateManager
{
	public ItemType itemType;

	public HouseSellData sellData;

	public FloatProperty marketSellStat;

	private ItemDef itemDef;

	public float happinessRate;

	private float marketDemandMultiplier;

	private float marketDemandBaseline;

	public float fulfillmentRatio;

	public int happinessQuintile;

	public int fulfillmentScore;

	public double actualSalesPerSecond;

	public float biomeModifierDemand;

	public bool isSpecialty;

	public PerkState cachedDemandPerk { get; private set; }

	public float satisfactionSupplyRate => base.displayedRecipeUnitRate;

	public SellState()
	{
		Initialize();
	}

	public override void Reset()
	{
		base.Reset();
		if (isSpecialty && parentTown != null)
		{
			parentTown.numSpecialtiesActive--;
		}
		isSpecialty = false;
	}

	public override EntityId AsEntity()
	{
		return EntityId.FromItem(itemType);
	}

	public override EntityId SkillEntity()
	{
		return EntityId.FromItem(itemType);
	}

	public override void LoadModifiers()
	{
		base.LoadModifiers();
		switch (base.producingBuilding.type)
		{
		case BuildingType.Market:
			AddModifier(UpgradeType.Supermarket);
			break;
		case BuildingType.FancyFoods:
			AddModifier(PerkType.GourmetFoodsStoreSpeed);
			break;
		case BuildingType.Bookstore:
			AddModifier(PerkType.BookStoreSpeed);
			break;
		case BuildingType.ClothingStore:
			AddModifier(PerkType.ClothingStoreSpeed);
			break;
		case BuildingType.HardwareStore:
			AddModifier(PerkType.HardwareStoreSpeed);
			break;
		case BuildingType.JewelryStore:
			AddModifier(PerkType.JewelryStoreSpeed);
			break;
		case BuildingType.ArcaneStore:
			AddModifier(PerkType.MagicStoreSpeed);
			break;
		case BuildingType.Apothecary:
			AddModifier(PerkType.MedicineStoreSpeed);
			break;
		case BuildingType.GeneralGoods:
			AddModifier(PerkType.ConstructionStoreSpeed);
			break;
		}
		AddModifier(PerkType.GlobalMarketSpeed);
		if (sellData.coinType == ItemType.YellowCoin)
		{
			AddModifier(UpgradeType.SellSpeedYellowCoin);
			AddModifier(UpgradeType.YellowCoinXP, ModifierType.XP);
		}
		else if (sellData.coinType == ItemType.RedCoin)
		{
			AddModifier(UpgradeType.SellSpeedRedCoin);
			AddModifier(UpgradeType.RedCoinXP, ModifierType.XP);
		}
		else if (sellData.coinType == ItemType.BlueCoin)
		{
			AddModifier(UpgradeType.SellSpeedBlueCoin);
			AddModifier(UpgradeType.BlueCoinXP, ModifierType.XP);
		}
		else if (sellData.coinType == ItemType.PurpleCoin)
		{
			AddModifier(UpgradeType.SellSpeedPurpleCoin);
			AddModifier(UpgradeType.PurpleCoinXP, ModifierType.XP);
		}
		else if (sellData.coinType == ItemType.OmniCoin)
		{
			AddModifier(UpgradeType.SellSpeedOmniCoin);
			AddModifier(UpgradeType.OmniCoinXP, ModifierType.XP);
		}
		if (GameManager.Instance.gameModifierDifficulty == GameModifier.EasyMode)
		{
			AddModifier(GameModifier.EasyMode, 2f, ModifierType.OutputAmount);
		}
		else if (GameManager.Instance.gameModifierDifficulty == GameModifier.HardMode)
		{
			AddModifier(GameModifier.HardMode, 0.5f, ModifierType.OutputAmount);
		}
		if (sellData.itemType == ItemType.Omnistone)
		{
			AddOutputAmountModifier(new ProductionModifierResearch(parentTown.research[ResearchType.InfiniteOmnistoneValue]));
		}
		AddModifier(BuildingType.DesertBazaar, ModifierType.Speed);
		AddModifier(BuildingType.SnowTreasureVault, ModifierType.OutputAmount);
		AddModifier(ResearchType.InfiniteMarketSellSpeed, ModifierType.Speed);
	}

	public void LoadItem(HouseSellData houseSellData)
	{
		sellData = houseSellData;
		itemType = houseSellData.itemType;
		CalcMarketMultiplier();
		if (Crafting.cachedItemDefs.TryGetValue(itemType, out var value))
		{
			itemDef = value;
		}
	}

	public bool IsTradeable()
	{
		if (itemDef != null)
		{
			return itemDef.tradeBuilding != BuildingType.None;
		}
		return false;
	}

	public override void StoreItemStateCache()
	{
		base.StoreItemStateCache();
		biomeModifierDemand = 1f;
		baseProductionRate = sellData.baselineSellSpeed;
		if (parentTown.inventory.TryGetValue(sellData.itemType, out var value))
		{
			AddInput(value, 1.0, baseProductionRate);
		}
		else
		{
			Debug.LogError("Did not find sellable input " + sellData.itemType);
		}
		if (parentTown.inventory.TryGetValue(sellData.coinType, out var value2))
		{
			AddOutput(value2, sellData.goldValue, baseProductionRate);
		}
		else
		{
			Debug.LogError("Did not find sellable output " + sellData.itemType);
		}
		double baseAmount = Crafting.SpecifiedXPValue(itemType);
		ItemState cachedTownXPState = parentTown.cachedTownXPState;
		AddOutput(cachedTownXPState, baseAmount, baseProductionRate, isRounded: true);
		if (parentTown.buildings.TryGetValue(sellData.derivedSellBuilding, out var value3) && value3 != null)
		{
			SetProductionBuilding(value3);
			if (parentTown.marketSellCounts.TryGetValue(base.producingBuilding.type, out var value4))
			{
				marketSellStat = value4;
			}
		}
		else
		{
			Debug.LogError("Did not find sellable building " + sellData.derivedSellBuilding.ToString() + " for item " + sellData.itemType);
		}
		if (sellData.derivedSellBuilding == BuildingType.FancyFoods)
		{
			TryAssignParentPerk(PerkType.GourmetFoodsDemand);
		}
		else if (sellData.derivedSellBuilding == BuildingType.Bookstore)
		{
			TryAssignParentPerk(PerkType.BooksDemand);
		}
		else if (sellData.derivedSellBuilding == BuildingType.GeneralGoods)
		{
			TryAssignParentPerk(PerkType.ConstructionDemand);
		}
		else if (sellData.derivedSellBuilding == BuildingType.HardwareStore)
		{
			TryAssignParentPerk(PerkType.HardwareDemand);
		}
		else if (sellData.derivedSellBuilding == BuildingType.ArcaneStore)
		{
			TryAssignParentPerk(PerkType.MagicDemand);
		}
		else if (sellData.derivedSellBuilding == BuildingType.ClothingStore)
		{
			TryAssignParentPerk(PerkType.ClothingDemand);
		}
		else if (sellData.derivedSellBuilding == BuildingType.Apothecary)
		{
			TryAssignParentPerk(PerkType.MedicineDemand);
		}
		else if (sellData.derivedSellBuilding == BuildingType.JewelryStore)
		{
			TryAssignParentPerk(PerkType.JewelryDemand);
		}
	}

	private void TryAssignParentPerk(PerkType t)
	{
		if (parentTown.townPerks.TryGetValue(t, out var value))
		{
			cachedDemandPerk = value;
		}
		else
		{
			cachedDemandPerk = null;
		}
	}

	protected override void CalcSpeed()
	{
		base.CalcSpeed();
		foreach (ItemRateData item in output)
		{
			if (item.state is ItemState itemState)
			{
				if (itemState.type == ItemType.YellowCoin)
				{
					outputAmountMultiplier *= parentTown.MultiplierForUpgrade(UpgradeType.SellValueYellowCoin);
				}
				else if (itemState.type == ItemType.RedCoin)
				{
					outputAmountMultiplier *= parentTown.MultiplierForUpgrade(UpgradeType.SellValueRedCoin);
				}
				else if (itemState.type == ItemType.BlueCoin)
				{
					outputAmountMultiplier *= parentTown.MultiplierForUpgrade(UpgradeType.SellValueBlueCoin);
				}
				else if (itemState.type == ItemType.PurpleCoin)
				{
					outputAmountMultiplier *= parentTown.MultiplierForUpgrade(UpgradeType.SellValuePurpleCoin);
				}
				else
				{
					_ = itemState.type;
					_ = 50014;
				}
				outputAmountMultiplier *= parentTown.MultiplierForPerk(PerkType.MarketValue);
			}
		}
		if (isSpecialty)
		{
			outputAmountMultiplier *= GameManager.Instance.SpecializationValueBonusPerPerkLevel();
		}
	}

	public bool ShouldBeUnlocked()
	{
		if (base.producingBuilding.availability != BuildObjectAvailability.Available)
		{
			return false;
		}
		if (GameManager.Instance.globalInventory.TryGetValue(itemType, out var value))
		{
			return !value.isLocked;
		}
		foreach (ItemRateData item in input)
		{
			if (item.state.isLocked)
			{
				return false;
			}
		}
		return true;
	}

	public override string ToString()
	{
		return "'Sell " + itemType.ToString() + "'";
	}

	private void CalcMarketMultiplier()
	{
		marketDemandBaseline = 0.75f;
		switch (sellData.derivedSellBuilding)
		{
		case BuildingType.Market:
			marketDemandMultiplier = 1.5f;
			marketDemandBaseline = 1f;
			break;
		case BuildingType.GeneralGoods:
			marketDemandMultiplier = 1.2f;
			marketDemandBaseline = 1f;
			break;
		case BuildingType.ClothingStore:
			marketDemandMultiplier = 1f;
			break;
		case BuildingType.HardwareStore:
			marketDemandMultiplier = 0.8f;
			break;
		case BuildingType.Apothecary:
			marketDemandMultiplier = 0.35f;
			break;
		case BuildingType.FancyFoods:
			marketDemandMultiplier = 0.5f;
			break;
		case BuildingType.JewelryStore:
			marketDemandMultiplier = 0.35f;
			break;
		case BuildingType.ArcaneStore:
			marketDemandMultiplier = 0.35f;
			break;
		case BuildingType.Bookstore:
			marketDemandMultiplier = 0.2f;
			break;
		}
	}

	public void CalcDemand()
	{
		if (parentTown != null)
		{
			float num = GameUtility.AsFloat(parentTown.numHouses);
			float demandPerHouse = sellData.demandPerHouse;
			float num2;
			if ((double)sellData.townLevelScaling >= 0.0)
			{
				num2 = 1f + (float)parentTown.townLevel * sellData.townLevelScaling;
			}
			else
			{
				float num3 = 1f + sellData.townLevelScaling;
				num2 = ((!(num3 <= 0f)) ? Mathf.Pow(num3, parentTown.townLevel) : 0f);
			}
			float num4 = sellData.baselineDemand + demandPerHouse * num * num2;
			_ = itemType;
			_ = 1;
			happinessRate = num4;
			happinessRate *= biomeModifierDemand;
			_ = itemType;
			_ = 1;
			if (cachedDemandPerk != null)
			{
				happinessRate *= parentTown.MultiplierForPerk(cachedDemandPerk.type);
				_ = itemType;
				_ = 1;
			}
			float num5 = parentTown.DemandBonusForBuilding(sellData.derivedSellBuilding);
			float num6 = GameManager.Instance.MultiplierForGlobalPerk(PerkType.GoodsConsumption);
			float num7 = parentTown.MultiplierForResearch(ResearchType.InfiniteGoodsConsumption);
			float num8 = 1f;
			if (isSpecialty)
			{
				num8 = GameManager.Instance.SpecializationDemandBonusPerPerkLevel();
			}
			if (itemType == ItemType.Omnistone)
			{
				happinessRate *= parentTown.MultiplierForPerk(PerkType.TownOmnistoneDemand);
			}
			float num9 = 1f * num6 * num7 * num8 * num5;
			float num10 = happinessRate * num9;
			if (!GameManager.Instance.isConsumptionInfinite)
			{
				recipeMaxRate = happinessRate + num10;
			}
			_ = itemType;
			_ = 1;
			if (itemType == ItemType.Omnistone)
			{
				happinessRate *= 0.1f;
			}
		}
	}

	protected override void ResetMethodB()
	{
		actualSalesPerSecond = 0.0;
	}
}
