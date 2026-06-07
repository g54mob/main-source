public class RequiredItem : Requirement
{
	public readonly ItemType itemType;

	private ItemState cachedItemState;

	public RequiredItem(ItemType type)
	{
		itemType = type;
		TryAddToProcessingQueue();
	}

	public override Requirement GetCopy()
	{
		return new RequiredItem(itemType);
	}

	public override void StoreItemStateCacheGlobal()
	{
		base.StoreItemStateCacheGlobal();
		cachedItemState = GameManager.Instance.globalInventory[itemType];
	}

	public override bool IsMet()
	{
		if (cachedItemState != null)
		{
			return !cachedItemState.isLocked;
		}
		return false;
	}

	public override string ToString()
	{
		return "Required Item " + itemType;
	}
}
