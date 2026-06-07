using System;
using System.Collections.Generic;

[Serializable]
public class SackData
{
	public List<ItemStackData> items = new List<ItemStackData>();

	public int totalItemCount;

	public SackData()
	{
	}

	public SackData(Dictionary<string, int> itemCounts)
	{
		items = new List<ItemStackData>();
		totalItemCount = 0;
		foreach (KeyValuePair<string, int> itemCount in itemCounts)
		{
			items.Add(new ItemStackData(itemCount.Key, itemCount.Value));
			totalItemCount += itemCount.Value;
		}
	}

	public Dictionary<string, int> ToDictionary()
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		foreach (ItemStackData item in items)
		{
			if (!string.IsNullOrEmpty(item.itemId) && item.count > 0)
			{
				if (dictionary.ContainsKey(item.itemId))
				{
					dictionary[item.itemId] += item.count;
				}
				else
				{
					dictionary[item.itemId] = item.count;
				}
			}
		}
		return dictionary;
	}
}
