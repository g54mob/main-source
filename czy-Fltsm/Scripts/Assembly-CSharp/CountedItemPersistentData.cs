using System;
using System.Collections.Generic;

[Serializable]
public struct CountedItemPersistentData
{
	public int Count;

	private int _propertiesIndex;

	public CountedItemPersistentData(ItemProperties itemProperties, int count)
	{
		Count = count;
		_propertiesIndex = GameManager.PersistenceManager.ReturnPropertiesIndex(itemProperties);
	}

	public CountedItemPersistentData(InventoryAuditor.CountedItem countedItem)
		: this(countedItem.ItemProperties, countedItem.ReturnCount(InventoryAuditor.CountType.All))
	{
	}

	public CountedItemPersistentData(KeyValuePair<ItemProperties, int> countedItem)
		: this(countedItem.Key, countedItem.Value)
	{
	}

	public bool TryRestoreItemProperties(out ItemProperties itemProperties)
	{
		return GameManager.PersistenceManager.TryReturnPropertiesReference<ItemProperties>(_propertiesIndex, out itemProperties);
	}

	public static CountedItemPersistentData[] GenerateFromInventoryAuditor(InventoryAuditor auditor)
	{
		using ListPool<CountedItemPersistentData>.List list = ListPool<CountedItemPersistentData>.Get();
		foreach (InventoryAuditor.CountedItem countedItem in auditor.CountedItems)
		{
			if (countedItem.ReturnCount(InventoryAuditor.CountType.All) != 0)
			{
				list.Add(new CountedItemPersistentData(countedItem));
			}
		}
		return list.ToArray();
	}

	public static CountedItemPersistentData[] FromDictionary(Dictionary<ItemProperties, int> countedItemDictionary)
	{
		if (countedItemDictionary.IsNullOrEmpty())
		{
			return null;
		}
		CountedItemPersistentData[] array = new CountedItemPersistentData[countedItemDictionary.Count];
		int num = 0;
		foreach (KeyValuePair<ItemProperties, int> item in countedItemDictionary)
		{
			array[num++] = new CountedItemPersistentData(item);
		}
		return array;
	}

	public static Dictionary<ItemProperties, int> ToDictionary(CountedItemPersistentData[] persistentData)
	{
		Dictionary<ItemProperties, int> dictionary;
		if (persistentData.IsNullOrEmpty())
		{
			dictionary = new Dictionary<ItemProperties, int>();
		}
		else
		{
			dictionary = new Dictionary<ItemProperties, int>(persistentData.Length);
			for (int i = 0; i < persistentData.Length; i++)
			{
				CountedItemPersistentData countedItemPersistentData = persistentData[i];
				if (countedItemPersistentData.TryRestoreItemProperties(out var itemProperties))
				{
					dictionary.Add(itemProperties, countedItemPersistentData.Count);
				}
			}
		}
		return dictionary;
	}
}
