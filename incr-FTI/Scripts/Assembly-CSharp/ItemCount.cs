using System;

[Serializable]
public struct ItemCount : IComparable
{
	public ItemType itemType;

	public double count;

	public static ItemCount zero => new ItemCount(ItemType.None, 0.0);

	public ItemCount(ItemType type, double amount)
	{
		itemType = type;
		count = amount;
	}

	public override string ToString()
	{
		return itemType.ToString() + " " + count;
	}

	public int CompareTo(object other)
	{
		if (other == null)
		{
			return 1;
		}
		if (other is ItemCount other2)
		{
			return CompareTo(other2);
		}
		throw new ArgumentException("Object is not an ItemCount");
	}

	public int CompareTo(ItemCount other)
	{
		return count.CompareTo(other.count);
	}
}
