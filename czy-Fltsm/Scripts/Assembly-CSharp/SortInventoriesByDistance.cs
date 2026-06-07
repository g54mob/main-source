using System.Collections.Generic;
using UnityEngine;

public class SortInventoriesByDistance : IComparer<Inventory>, IComparer<ItemDataInventory>
{
	public Vector3 Position;

	public int Compare(Inventory x, Inventory y)
	{
		float num = Vector3.Distance(Position, x.transform.position);
		float num2 = Vector3.Distance(Position, y.transform.position);
		if (num < num2)
		{
			return -1;
		}
		return 1;
	}

	public int Compare(ItemDataInventory x, ItemDataInventory y)
	{
		float num = x.Path.ReturnDistance();
		float num2 = y.Path.ReturnDistance();
		if (num < num2)
		{
			return -1;
		}
		return 1;
	}
}
