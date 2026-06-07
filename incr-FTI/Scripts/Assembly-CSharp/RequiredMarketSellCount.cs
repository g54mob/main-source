public class RequiredMarketSellCount : Requirement
{
	public BuildingType buildingType;

	public double targetCount;

	public FloatProperty cachedProperty;

	public RequiredMarketSellCount(BuildingType t, double target)
	{
		buildingType = t;
		targetCount = target;
		TryAddToProcessingQueue();
	}

	public override Requirement GetCopy()
	{
		return new RequiredMarketSellCount(buildingType, targetCount);
	}

	public override void StoreItemStateCache(Town town)
	{
		base.StoreItemStateCache(town);
		cachedProperty = town.marketSellCounts[buildingType];
	}

	public override bool IsMet()
	{
		return CurrentCount() >= targetCount;
	}

	public double CurrentCount()
	{
		if (cachedProperty != null)
		{
			return cachedProperty.value;
		}
		return GameManager.Instance.ActiveTownMarketSellCount(buildingType);
	}

	public override string ToString()
	{
		return "Required Market Sell Count " + buildingType.ToString() + " " + targetCount;
	}
}
