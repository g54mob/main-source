using System;

[Serializable]
public struct Item
{
	public int id;

	public int amount;

	public int maxAmount;

	public AnomalyTag tag;

	public static Item Empty()
	{
		return new Item
		{
			id = -1,
			amount = 0,
			maxAmount = 999
		};
	}

	public static Item Create(int id, int amount, AnomalyTag tag)
	{
		return new Item
		{
			id = id,
			amount = amount,
			maxAmount = 999,
			tag = tag
		};
	}

	public static Item Create(int id, int amount, int max)
	{
		return new Item
		{
			id = id,
			amount = amount,
			maxAmount = max
		};
	}
}
