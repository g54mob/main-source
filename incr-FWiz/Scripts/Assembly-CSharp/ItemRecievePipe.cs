public abstract class ItemRecievePipe : Pipe
{
	public enum RecieveTypeSetting
	{
		Transfer = 0,
		Crafting = 1,
		Fuel = 2,
		Output = 3
	}

	public RecieveTypeSetting RecieveType;

	public override bool CanStartConnection => false;

	public abstract bool CanTakeItem(ItemType type);

	public abstract bool TakeItem(ItemType type);

	public abstract bool PrefersItem(ItemType type);

	protected override bool CanConnect(Pipe pipe)
	{
		return false;
	}
}
