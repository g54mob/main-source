using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ItemList
{
	public readonly Dictionary<ItemType, double> items;

	public bool isLocked;

	public static ItemList Zero = new ItemList();

	public int storedHash { get; private set; }

	public ItemList()
	{
		items = new Dictionary<ItemType, double>(GameUtility.SharedEqualityComparer);
	}

	public ItemList(int capacity)
	{
		items = new Dictionary<ItemType, double>(capacity, GameUtility.SharedEqualityComparer);
	}

	public ItemList(params ItemCount[] counts)
	{
		items = new Dictionary<ItemType, double>(GameUtility.SharedEqualityComparer);
		foreach (ItemCount itemCount in counts)
		{
			AddItemCount(itemCount);
		}
	}

	public void Clear()
	{
		items.Clear();
		storedHash = 0;
	}

	public bool Contains(ItemType testType)
	{
		return items.ContainsKey(testType);
	}

	public double Count(ItemType itemType)
	{
		if (items.TryGetValue(itemType, out var value))
		{
			return value;
		}
		return 0.0;
	}

	public void AddItemCount(ItemCount itemCount)
	{
		AddItem(itemCount.itemType, itemCount.count);
	}

	public void AddItem(ItemType type, double count)
	{
		if (isLocked)
		{
			Debug.LogWarning("Tried to modify locked item list");
			return;
		}
		double num = Count(type);
		items[type] = num + count;
	}

	public void RemoveAll(ItemType type)
	{
		items.Remove(type);
	}

	public void RemoveItem(ItemType type, double count)
	{
		if (GameUtility.IsNearlyZero(count))
		{
			return;
		}
		if (isLocked)
		{
			Debug.LogWarning("Tried to modify locked item list");
			return;
		}
		double num = Count(type);
		if (num >= count)
		{
			double num2 = num - count;
			if (num2 < 0.0)
			{
				num2 = 0.0;
			}
			items[type] = num2;
		}
	}

	public void AddList(List<ItemCount> itemCountList)
	{
		if (itemCountList == null)
		{
			return;
		}
		foreach (ItemCount itemCount in itemCountList)
		{
			AddItemCount(itemCount);
		}
	}

	public void AddList(ItemList cost)
	{
		if (cost == null)
		{
			return;
		}
		foreach (KeyValuePair<ItemType, double> item in cost.items)
		{
			AddItem(item.Key, item.Value);
		}
	}

	public List<ItemCount> ItemCountListCopy()
	{
		List<ItemCount> targetList = new List<ItemCount>();
		return LoadedItemCountList(targetList);
	}

	public List<ItemCount> LoadedItemCountList(List<ItemCount> targetList)
	{
		foreach (KeyValuePair<ItemType, double> item in items)
		{
			if (item.Value > 0.0)
			{
				targetList.Add(new ItemCount(item.Key, item.Value));
			}
		}
		return targetList;
	}

	public void SubtractList(ItemList cost)
	{
		if (cost == null)
		{
			return;
		}
		foreach (KeyValuePair<ItemType, double> item in cost.items)
		{
			RemoveItem(item.Key, item.Value);
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = true;
		foreach (KeyValuePair<ItemType, double> item in items)
		{
			if (!flag)
			{
				stringBuilder.Append(",");
			}
			stringBuilder.Append(new ItemCount(item.Key, item.Value).ToString());
			flag = false;
		}
		return stringBuilder.ToString();
	}

	public bool HasItemInList(ItemList testList)
	{
		if (testList == null)
		{
			return false;
		}
		foreach (KeyValuePair<ItemType, double> item in testList.items)
		{
			if (Count(item.Key) > 0.0)
			{
				return true;
			}
		}
		return false;
	}

	public void FlagHashStale()
	{
		storedHash = 0;
	}

	public void CalcHashCode()
	{
		storedHash = 17;
		foreach (KeyValuePair<ItemType, double> item in items)
		{
			item.Deconstruct(out var key, out var value);
			ItemType itemType = key;
			double num = value;
			storedHash = (int)(storedHash * 23 + itemType);
			storedHash += num.GetHashCode();
		}
	}
}
