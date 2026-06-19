using System;

[Serializable]
public class QuotaItemStack : ItemInputStack
{
	public int Capacity { get; set; }

	public override int Maximum => 0;

	public int Multiples => 0;

	public QuotaItemStack(ItemType type, int minDemand, int maxCapacity = 20, int count = 0)
		: base(null, 0)
	{
	}

	public QuotaItemStack(CostStack costStack, int capacity)
		: base(null, 0)
	{
	}

	public void SetCapacity(int capacity)
	{
	}

	public bool TryRemoveDemand()
	{
		return false;
	}

	public ItemType PeekIfNotEmpty()
	{
		return null;
	}
}
