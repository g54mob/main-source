using System;

public class RequiredProductionCount : Requirement
{
	public ItemType itemType;

	public double targetCount;

	public FloatProperty cachedStat;

	public RequiredProductionCount(ItemType t, double count, bool global)
	{
		itemType = t;
		targetCount = count;
		isTargetingGlobalStat = global;
		TryAddToProcessingQueue();
	}

	public override void StoreItemStateCache(Town town)
	{
		base.StoreItemStateCache(town);
		if (isTargetingGlobalStat)
		{
			cachedStat = GameManager.Instance.globalProductionStats[itemType];
		}
		else
		{
			cachedStat = town.inventory[itemType].townProductionStat;
		}
	}

	public override void StoreItemStateCacheGlobal()
	{
		base.StoreItemStateCacheGlobal();
		if (isTargetingGlobalStat)
		{
			cachedStat = GameManager.Instance.globalProductionStats[itemType];
		}
	}

	public double CurrentCount()
	{
		double num = ((cachedStat == null) ? GameManager.Instance.ActiveTownProductionCount(itemType) : cachedStat.value);
		if (num < 2147483647.0)
		{
			return Math.Floor(num);
		}
		return num;
	}

	public override bool IsMet()
	{
		return CurrentCount() >= targetCount;
	}

	public override string ToString()
	{
		return "Required Production Count " + itemType.ToString() + "=" + targetCount;
	}
}
