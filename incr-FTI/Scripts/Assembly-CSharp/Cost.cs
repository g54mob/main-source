using System.Collections.Generic;

public class Cost
{
	public readonly List<(ConsumableState state, double amount)> entries = new List<(ConsumableState, double)>();

	public void Clear()
	{
		entries.Clear();
	}

	public void AddList(Town parentTown, ItemList list)
	{
		foreach (KeyValuePair<ItemType, double> item in list.items)
		{
			if (parentTown.inventory.TryGetValue(item.Key, out var value))
			{
				entries.Add((value, item.Value));
			}
		}
	}

	public bool CanAfford()
	{
		foreach (var (consumableState, num) in entries)
		{
			if (consumableState.currentCount < num)
			{
				return false;
			}
		}
		return true;
	}
}
