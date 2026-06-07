using System;
using System.Collections.Generic;
using DV.CabControls;
using DV.ThingTypes;
using UnityEngine;

public class StorageBase : MonoBehaviour
{
	public StorageType storageType;

	public bool acceptsNonEssential = true;

	public bool itemsActiveOrActivating;

	private readonly List<ItemBase> itemList = new List<ItemBase>();

	public event Action<ItemBase> ItemAdded;

	public event Action<ItemBase> ItemRemoved;

	public bool ContainsItem(ItemBase item)
	{
		return itemList.Contains(item);
	}

	public bool HasAnyItem()
	{
		return itemList.Count > 0;
	}

	public void AddItem(ItemBase item)
	{
		itemList.Add(item);
		if (item != null)
		{
			this.ItemAdded?.Invoke(item);
		}
	}

	public void RemoveItem(ItemBase item)
	{
		itemList.Remove(item);
		if (item != null)
		{
			this.ItemRemoved?.Invoke(item);
		}
	}

	public List<ItemBase> GetStorageItemList()
	{
		return itemList;
	}

	public void RemovePotentialNulls()
	{
		int num = itemList.RemoveAll((ItemBase item) => item == null);
		if (num > 0)
		{
			Debug.LogWarning($"Removed {num} null entries from storage {base.name}", this);
		}
	}
}
