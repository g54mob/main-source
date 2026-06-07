public class RequiredUpgradeCount : Requirement
{
	public int targetCount;

	private Town cachedTown;

	public RequiredUpgradeCount(int amount)
	{
		targetCount = amount;
		cachedTown = GameManager.TownBeingLoaded;
	}

	public override Requirement GetCopy()
	{
		return new RequiredUpgradeCount(targetCount);
	}

	public override bool IsMet()
	{
		return CurrentCount() >= (float)targetCount;
	}

	public float CurrentCount()
	{
		if (cachedTown != null)
		{
			return cachedTown.cachedTotalUpgradeLevels;
		}
		return GameManager.Instance.activeTown.cachedTotalUpgradeLevels;
	}
}
