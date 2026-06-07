public class RequiredUpgrade : Requirement
{
	private Upgrade cachedUpgrade;

	public readonly UpgradeType upgradeType;

	public readonly int targetLevel;

	public RequiredUpgrade(UpgradeType t, int targetLevel)
	{
		upgradeType = t;
		this.targetLevel = targetLevel;
		TryAddToProcessingQueue();
	}

	public override void StoreItemStateCache(Town town)
	{
		if (town.upgrades.TryGetValue(upgradeType, out var value))
		{
			cachedUpgrade = value;
		}
	}

	public override void StoreItemStateCacheGlobal()
	{
	}

	public override bool IsMet()
	{
		return CurrentCount() >= (float)targetLevel;
	}

	public float CurrentCount()
	{
		if (cachedUpgrade == null)
		{
			return 0f;
		}
		return cachedUpgrade.numCompleted;
	}

	public override string ToString()
	{
		return "Required upgrade " + upgradeType.ToString() + " lvl " + targetLevel;
	}
}
