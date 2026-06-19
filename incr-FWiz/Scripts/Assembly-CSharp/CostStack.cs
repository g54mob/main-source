using System;

[Serializable]
public class CostStack : ItemStack
{
	public CostStack(ItemType type, int count)
		: base(null, 0)
	{
	}

	public CostStack(CostStack costStack)
		: base(null, 0)
	{
	}
}
