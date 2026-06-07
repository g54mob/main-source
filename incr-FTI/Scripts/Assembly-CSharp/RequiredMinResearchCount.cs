public class RequiredMinResearchCount : Requirement
{
	public readonly int amount;

	private IntProperty cachedStat;

	public RequiredMinResearchCount(int c, bool global)
	{
		amount = c;
		isTargetingGlobalStat = global;
		TryAddToProcessingQueue();
	}

	public override Requirement GetCopy()
	{
		return new RequiredMinResearchCount(amount, isTargetingGlobalStat);
	}

	public override bool IsMet()
	{
		return CurrentCount() >= (float)amount;
	}

	public override void StoreItemStateCache(Town town)
	{
		base.StoreItemStateCache(town);
		if (isTargetingGlobalStat)
		{
			cachedStat = GameManager.Instance.completedResearchStat;
		}
		else
		{
			cachedStat = town.completedResearchStat;
		}
	}

	public override void StoreItemStateCacheGlobal()
	{
		base.StoreItemStateCacheGlobal();
		if (isTargetingGlobalStat)
		{
			cachedStat = GameManager.Instance.completedResearchStat;
		}
	}

	public float CurrentCount()
	{
		if (cachedStat != null)
		{
			return cachedStat.value;
		}
		if (GameManager.Instance.activeTown != null)
		{
			return GameManager.Instance.activeTown.completedResearchStat.value;
		}
		return 0f;
	}

	public override string ToString()
	{
		return "Required Research Count " + amount;
	}
}
