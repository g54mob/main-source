public class RequiredProductionCountInstanced : Requirement
{
	public ItemType itemType;

	public double targetCount;

	public double instanceCount;

	public bool isActive;

	public RequiredProductionCountInstanced(ItemType t, double count)
	{
		itemType = t;
		targetCount = count;
	}

	public double CurrentCount()
	{
		return instanceCount;
	}

	public override bool IsMet()
	{
		return CurrentCount() >= targetCount;
	}

	public override void Reset()
	{
		isActive = false;
		instanceCount = 0.0;
	}
}
