public class RequiredNaturalResource : Requirement
{
	public readonly NaturalResource resourceType;

	private PropertyItem<bool> cachedUnlockState;

	public RequiredNaturalResource(NaturalResource type)
	{
		resourceType = type;
		cachedUnlockState = GameManager.Instance.globalResourceUnlockStates[type];
	}

	public override Requirement GetCopy()
	{
		return new RequiredNaturalResource(resourceType);
	}

	public override void StoreItemStateCacheGlobal()
	{
		base.StoreItemStateCacheGlobal();
	}

	public override bool IsMet()
	{
		return cachedUnlockState.value;
	}

	public override string ToString()
	{
		return "Required Resource " + resourceType;
	}
}
