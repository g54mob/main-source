using UnityEngine;

public class RequiredCoinSpendCount : Requirement
{
	public ItemType coinType;

	public double targetCount;

	private FloatProperty cachedStat;

	public RequiredCoinSpendCount(ItemType coin, double amount)
	{
		coinType = coin;
		targetCount = amount;
		TryAddToProcessingQueue();
	}

	public override Requirement GetCopy()
	{
		return new RequiredCoinSpendCount(coinType, targetCount);
	}

	public override void StoreItemStateCache(Town town)
	{
		base.StoreItemStateCache(town);
		cachedStat = town.coinSpendCounts[coinType];
	}

	public double CurrentCount()
	{
		FloatProperty floatProperty = cachedStat;
		if (floatProperty == null)
		{
			floatProperty = GameManager.Instance.activeTown.coinSpendCounts[coinType];
		}
		if (floatProperty != null)
		{
			double value = floatProperty.value;
			if (value < 2147483647.0)
			{
				return Mathf.FloorToInt((float)value);
			}
			return value;
		}
		return 0.0;
	}

	public override bool IsMet()
	{
		return CurrentCount() >= targetCount;
	}
}
