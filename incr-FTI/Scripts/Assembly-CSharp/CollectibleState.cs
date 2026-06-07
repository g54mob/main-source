public class CollectibleState : CountableState
{
	public readonly ItemType type;

	public CollectibleState(ItemType t)
	{
		type = t;
	}

	public override EntityId AsEntity()
	{
		return EntityId.FromItem(type);
	}

	public override string ToString()
	{
		return "Collectible " + type;
	}
}
