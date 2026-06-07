public class RequiredItemSales : Requirement
{
	public ItemType itemType;

	public float count;

	public RequiredItemSales(ItemType t, float count)
	{
		itemType = t;
		this.count = count;
	}

	public override Requirement GetCopy()
	{
		return new RequiredItemSales(itemType, count);
	}

	public float CurrentCount()
	{
		return 0f;
	}

	public override bool IsMet()
	{
		return CurrentCount() >= count;
	}
}
