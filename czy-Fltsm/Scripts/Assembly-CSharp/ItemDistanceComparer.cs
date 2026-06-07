using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

public class ItemDistanceComparer : IComparer<Item>
{
	private Vector3 _position;

	public ItemDistanceComparer(Vector3 position)
	{
		_position = position;
	}

	public int Compare(Item x, Item y)
	{
		float num = _position.DistanceToLeveledSquared(x.Inventory.transform.position) * 1000f;
		float num2 = _position.DistanceToLeveledSquared(y.Inventory.transform.position) * 1000f;
		return (int)(num - num2);
	}

	public static void SortByShortestDistance(Vector3 start, List<Item> items)
	{
		Vector3 vector = start;
		for (int i = 0; i < items.Count; i++)
		{
			float num = float.MaxValue;
			int index = 0;
			for (int j = i; j < items.Count; j++)
			{
				Item item = items[j];
				float num2 = vector.DistanceToLeveledSquared(item.Owner.transform.position);
				if (num2 < num)
				{
					num = num2;
					index = j;
				}
			}
			Item item2 = items[index];
			items.RemoveAt(index);
			items.Insert(i, item2);
			vector = item2.Owner.transform.position;
		}
	}
}
