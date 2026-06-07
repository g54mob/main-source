public class RequiredPerk : Requirement
{
	private PerkState cachedPerkState;

	public readonly PerkType perkType;

	public readonly int targetLevel;

	private readonly bool isTargetingGlobalPerk;

	public RequiredPerk(PerkType t, int targetLevel)
	{
		perkType = t;
		this.targetLevel = targetLevel;
		isTargetingGlobalPerk = Perk.IsGlobal(perkType);
		TryAddToProcessingQueue();
	}

	public override Requirement GetCopy()
	{
		return new RequiredPerk(perkType, targetLevel);
	}

	public override void StoreItemStateCache(Town town)
	{
		if (isTargetingGlobalPerk)
		{
			cachedPerkState = GameManager.Instance.globalPerks[perkType];
		}
		else
		{
			cachedPerkState = town.townPerks[perkType];
		}
	}

	public override void StoreItemStateCacheGlobal()
	{
		if (isTargetingGlobalPerk)
		{
			cachedPerkState = GameManager.Instance.globalPerks[perkType];
		}
	}

	public override bool IsMet()
	{
		return CurrentCount() >= (float)targetLevel;
	}

	public float CurrentCount()
	{
		if (cachedPerkState == null)
		{
			return 0f;
		}
		return GameUtility.RoundToFloat(cachedPerkState.currentCount);
	}

	public override string ToString()
	{
		return "Required perk " + perkType.ToString() + " lvl " + targetLevel;
	}
}
