using System.Collections.Generic;

public class ItemEqualityComparer : IEqualityComparer<ItemType>
{
	public bool Equals(ItemType a, ItemType b)
	{
		return a == b;
	}

	public int GetHashCode(ItemType obj)
	{
		return (int)obj;
	}
}
