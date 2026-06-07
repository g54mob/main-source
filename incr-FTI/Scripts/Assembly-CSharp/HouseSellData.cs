public class HouseSellData
{
	public ItemType coinType;

	public int goldValue;

	public int tier;

	public int happinessValue;

	public float baselineDemand;

	public float demandPerHouse;

	public float townLevelScaling;

	public float oldTierMultiplier;

	public float baselineSellSpeed;

	private float marketDemandMultiplier;

	private float marketDemandBaseline;

	public BuildingType derivedSellBuilding;

	public ItemType itemType { get; private set; }

	public bool isSellable => derivedSellBuilding != BuildingType.None;

	public HouseSellData()
	{
	}

	public HouseSellData(ItemType inCoinType, int inGoldValue, int fulfillmentTier, BuildingType sellBuilding, int inHappinessValue)
	{
		coinType = inCoinType;
		goldValue = inGoldValue;
		derivedSellBuilding = sellBuilding;
		happinessValue = inHappinessValue;
		tier = fulfillmentTier;
	}

	private void CalcDemandPerHouse()
	{
		CalcMarketMultiplier();
		baselineSellSpeed = 0.5f;
		float num = -0.01f;
		switch (this.itemType)
		{
		case ItemType.Wood:
			baselineDemand = 4f;
			demandPerHouse = 0.1f;
			townLevelScaling = num;
			baselineSellSpeed = 1f;
			break;
		case ItemType.Stone:
			baselineDemand = 1f;
			demandPerHouse = 0.05f;
			townLevelScaling = num;
			baselineSellSpeed = 1f;
			break;
		case ItemType.Grain:
			baselineDemand = 1f;
			demandPerHouse = 0.1f;
			townLevelScaling = num;
			baselineSellSpeed = 1f;
			break;
		case ItemType.Plank:
			baselineDemand = 1f;
			demandPerHouse = 0.05f;
			townLevelScaling = 0.01f;
			baselineSellSpeed = 1f;
			break;
		case ItemType.RefinedPlank:
			baselineDemand = 0.5f;
			demandPerHouse = 0.04f;
			townLevelScaling = 0.02f;
			baselineSellSpeed = 1f;
			break;
		case ItemType.StoneSlab:
			baselineDemand = 1f;
			demandPerHouse = 0.05f;
			townLevelScaling = 0.02f;
			baselineSellSpeed = 1f;
			break;
		case ItemType.RefinedStoneBrick:
			baselineDemand = 0.5f;
			demandPerHouse = 0.05f;
			townLevelScaling = 0.025f;
			break;
		case ItemType.WoodWheel:
			baselineDemand = 0.1f;
			demandPerHouse = 0.04f;
			townLevelScaling = 0.01f;
			break;
		case ItemType.OmniPipe:
			baselineDemand = 0.01f;
			demandPerHouse = 0.01f * marketDemandMultiplier;
			townLevelScaling = 0.05f;
			break;
		default:
			if (tier == 0)
			{
				baselineDemand = 0f;
				demandPerHouse = 0f;
				townLevelScaling = 0f;
				oldTierMultiplier = 0f;
			}
			else if (tier == 1)
			{
				baselineDemand = 0.25f;
				demandPerHouse = 0.05f;
				townLevelScaling = 0f;
				baselineSellSpeed = 1f;
				oldTierMultiplier = 0.1f;
			}
			else if (tier == 2)
			{
				baselineDemand = 0.2f;
				demandPerHouse = 0.075f * marketDemandMultiplier;
				townLevelScaling = 0.025f;
				oldTierMultiplier = 0.2f;
			}
			else if (tier == 3)
			{
				baselineDemand = 0.15f;
				demandPerHouse = 0.1f * marketDemandMultiplier;
				townLevelScaling = 0.05f;
				oldTierMultiplier = 0.3f;
			}
			else if (tier == 4)
			{
				baselineDemand = 0.1f;
				demandPerHouse = 0.075f * marketDemandMultiplier;
				townLevelScaling = 0.075f;
				oldTierMultiplier = 0.2f;
			}
			else if (tier == 5)
			{
				baselineDemand = 0.05f;
				demandPerHouse = 0.05f * marketDemandMultiplier;
				townLevelScaling = 0.1f;
				oldTierMultiplier = 0.1f;
			}
			break;
		}
		ItemType itemType = this.itemType;
		if (itemType == ItemType.RawBeef || itemType == ItemType.RawChicken || itemType == ItemType.Paper)
		{
			townLevelScaling = num;
		}
	}

	private void CalcMarketMultiplier()
	{
		marketDemandBaseline = 0.75f;
		switch (derivedSellBuilding)
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

	public HouseSellData DeepCopy()
	{
		return new HouseSellData
		{
			itemType = itemType,
			coinType = coinType,
			goldValue = goldValue,
			derivedSellBuilding = derivedSellBuilding,
			happinessValue = happinessValue,
			tier = tier,
			demandPerHouse = demandPerHouse,
			townLevelScaling = townLevelScaling,
			marketDemandBaseline = marketDemandBaseline,
			marketDemandMultiplier = marketDemandMultiplier,
			baselineDemand = baselineDemand,
			oldTierMultiplier = oldTierMultiplier,
			baselineSellSpeed = baselineSellSpeed
		};
	}

	public int DerivedXpValue()
	{
		if (coinType == ItemType.YellowCoin)
		{
			return goldValue;
		}
		if (coinType == ItemType.RedCoin)
		{
			return (int)((double)goldValue * 1.5);
		}
		if (coinType == ItemType.BlueCoin)
		{
			return goldValue * 2;
		}
		if (coinType == ItemType.PurpleCoin)
		{
			return goldValue * 3;
		}
		if (coinType == ItemType.ResearchPointsIndustry || coinType == ItemType.ResearchPointsGeneral_Disabled || coinType == ItemType.ResearchPointsNature)
		{
			return goldValue;
		}
		if (coinType == ItemType.ResearchPointsAir || coinType == ItemType.ResearchPointsFire || coinType == ItemType.ResearchPointsWater || coinType == ItemType.ResearchPointsEarth || coinType == ItemType.ResearchPointsMagic)
		{
			return goldValue;
		}
		return 0;
	}

	public void AssignItem(ItemType t)
	{
		itemType = t;
		CalcDemandPerHouse();
	}

	public override string ToString()
	{
		return "House sell data " + itemType.ToString() + " " + coinType.ToString() + " " + goldValue + " " + derivedSellBuilding;
	}

	public float GetExchangeValue()
	{
		float num = goldValue;
		if (coinType == ItemType.RedCoin)
		{
			num *= 2f;
		}
		else if (coinType == ItemType.BlueCoin)
		{
			num *= 3f;
		}
		else if (coinType == ItemType.PurpleCoin)
		{
			num *= 4f;
		}
		return num;
	}
}
