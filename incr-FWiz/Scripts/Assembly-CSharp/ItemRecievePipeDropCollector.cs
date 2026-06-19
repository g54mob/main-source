public class ItemRecievePipeDropCollector : ItemRecievePipe
{
	public DropCollector DropCollector;

	public override bool CanTakeItem(ItemType type)
	{
		return false;
	}

	public override bool PrefersItem(ItemType type)
	{
		return false;
	}

	public override bool TakeItem(ItemType type)
	{
		return false;
	}
}
