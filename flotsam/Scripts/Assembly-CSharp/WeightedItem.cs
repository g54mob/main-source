using System;
using System.Collections.Generic;
using PajamaLlama.Debugs;
using UnityEngine;

public class WeightedItem : IComparable<WeightedItem>
{
	[Tooltip("Composited flotsam properties to use for this flotsam object.")]
	public CompositedFlotsamProperties CompositedFlotsamProperties;

	[Tooltip("Item properties to use for this flotsam object.")]
	public ItemProperties ItemProperties;

	[Tooltip("This item is guaranteed to be in the final list.")]
	public bool Guaranteed;

	[Tooltip("Exclude this item from respawning in the world.")]
	public bool ExcludeFromRespawning;

	[Tooltip("Weighted chance to get this item.")]
	public float WeightedChance = 1f;

	private static float ReturnTotalWeight<T>(IEnumerable<T> weightedItems) where T : WeightedItem
	{
		float num = 0f;
		foreach (T weightedItem in weightedItems)
		{
			num += weightedItem.WeightedChance;
		}
		return num;
	}

	private static ListPool<WeightedItem>.List ReturnItems<T>(List<T> weightedItems, float amount, bool includeAllGuaranteedItems, bool excludeGuaranteedItemsFromGeneralItems) where T : WeightedItem
	{
		ListPool<WeightedItem>.List list = ListPool<WeightedItem>.Get();
		ListPool<WeightedItem>.List list2 = ListPool<WeightedItem>.Get(weightedItems);
		ListPool<WeightedItem>.List list3 = ListPool<WeightedItem>.Get(weightedItems.Count);
		ListPool<WeightedItem>.List list4 = ListPool<WeightedItem>.Get(weightedItems.Count);
		Sorting.SlowSort(list2);
		foreach (WeightedItem item in list2)
		{
			if (item.Guaranteed)
			{
				list3.Add(item);
			}
			else
			{
				list4.Add(item);
			}
		}
		if (0 < list3.Count)
		{
			if (includeAllGuaranteedItems)
			{
				for (int i = 0; i < list3.Count; i++)
				{
					list.Add(list3[i]);
					amount -= 1f;
				}
			}
			else
			{
				WeightedItem weightedItem = ReturnRandomItem(list3);
				if (weightedItem != null)
				{
					list.Add(weightedItem);
					amount -= 1f;
				}
			}
		}
		float totalWeight = ReturnTotalWeight(list4);
		for (int j = 0; (float)j < amount; j++)
		{
			WeightedItem weightedItem2 = ReturnRandomItem(list4, totalWeight);
			if (weightedItem2 != null)
			{
				list.Add(weightedItem2);
			}
		}
		list2.Dispose();
		list3.Dispose();
		list4.Dispose();
		return list;
	}

	public static T ReturnRandomItem<T>(IEnumerable<T> items, float totalWeight = 0f) where T : WeightedItem
	{
		if (totalWeight == 0f)
		{
			totalWeight = ReturnTotalWeight(items);
		}
		float num = UnityEngine.Random.Range(0f, totalWeight);
		float num2 = 0f;
		foreach (T item in items)
		{
			num2 += item.WeightedChance;
			if (num <= num2)
			{
				return item;
			}
		}
		Debugger.Warning($"No random item found.");
		return null;
	}

	public static ListPool<CompositedFlotsamProperties>.List ReturnCompositedFlotsamProperties<T>(List<T> weightedItems, float amount, bool includeAllGuaranteedItems, bool excludeGuaranteedItemsFromGeneralItems) where T : WeightedItem
	{
		if (weightedItems.Count == 0)
		{
			return ListPool<CompositedFlotsamProperties>.Get();
		}
		ListPool<WeightedItem>.List list = ReturnItems(weightedItems, amount, includeAllGuaranteedItems, excludeGuaranteedItemsFromGeneralItems);
		ListPool<CompositedFlotsamProperties>.List list2 = ListPool<CompositedFlotsamProperties>.Get();
		for (int i = 0; i < list.Count; i++)
		{
			list2.Add(list[i].CompositedFlotsamProperties);
		}
		list.Dispose();
		return list2;
	}

	public static ListPool<ItemProperties>.List ReturnItemProperties<T>(List<T> weightedItems, float amount, bool includeAllGuaranteedItems, bool excludeGuaranteedItemsFromGeneralItems, bool initialSpawn = false) where T : WeightedItem
	{
		if (weightedItems.Count == 0)
		{
			return ListPool<ItemProperties>.Get();
		}
		List<WeightedItem> list = ReturnItems(weightedItems, amount, includeAllGuaranteedItems, excludeGuaranteedItemsFromGeneralItems);
		ListPool<ItemProperties>.List list2 = ListPool<ItemProperties>.Get();
		foreach (WeightedItem item in list)
		{
			if (initialSpawn || !item.ExcludeFromRespawning)
			{
				list2.Add(item.ItemProperties);
			}
		}
		list.Dispose();
		return list2;
	}

	public int CompareTo(WeightedItem other)
	{
		if (other.WeightedChance == WeightedChance)
		{
			return 0;
		}
		if (other.WeightedChance < WeightedChance)
		{
			return -1;
		}
		return 1;
	}
}
