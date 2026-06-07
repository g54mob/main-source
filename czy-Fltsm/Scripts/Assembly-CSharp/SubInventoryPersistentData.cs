using System;
using UnityEngine;

[Serializable]
public class SubInventoryPersistentData
{
	public SubInventoryType SubInventoryType;

	public ItemPersistentData[] Items;

	public int[] IncomingItems;

	[NonSerialized]
	private Inventory _inventory;

	[NonSerialized]
	private SubInventory _subInventory;

	private SubInventoryPersistentData(SubInventory subInventory)
	{
		_subInventory = subInventory;
		SubInventoryType = subInventory.Type;
		using ListPool<Item>.List list = ListPool<Item>.Get(subInventory.Count);
		subInventory.ReturnAllItems(list);
		Items = ItemPersistentData.FromItems(list);
		if (!subInventory.IncomingItems.IsNullOrEmpty())
		{
			InventoryPersistentData.PopulateReferencesEvent.AddListener(PopulateReferences);
		}
	}

	public void Restore(Inventory inventory)
	{
		_inventory = inventory;
		_subInventory = _inventory.GetOrAddSubInventory(SubInventoryType);
		if (_subInventory == null)
		{
			Debug.LogErrorFormat("Unable to restore subInventory '{0}', because it was not initialized.", SubInventoryType);
			return;
		}
		using ListPool<Item>.List list = ItemPersistentData.ToItems(Items);
		if (list != null)
		{
			foreach (Item item in list)
			{
				inventory.AddItem(item, SubInventoryType);
			}
		}
		if (!IncomingItems.IsNullOrEmpty())
		{
			InventoryPersistentData.RestoreReferencesEvent.AddListener(RestoreReferences);
		}
	}

	private void PopulateReferences()
	{
		InventoryPersistentData.PopulateReferencesEvent.RemoveListener(PopulateReferences);
		if (_subInventory != null)
		{
			IncomingItems = ItemPersistentData.ToIndices(_subInventory.IncomingItems);
		}
	}

	private void RestoreReferences()
	{
		InventoryPersistentData.RestoreReferencesEvent.RemoveListener(RestoreReferences);
		if (_inventory == null)
		{
			return;
		}
		using ListPool<Item>.List list = ItemPersistentData.ToItems(IncomingItems);
		if (list == null)
		{
			return;
		}
		foreach (Item item in list)
		{
			_inventory.RestoreIncomingItem(item, SubInventoryType);
		}
	}

	public static SubInventoryPersistentData Get(Inventory inventory, SubInventoryType subInventoryType)
	{
		SubInventory subInventory = inventory.ReturnInventory(subInventoryType);
		if (subInventory == null)
		{
			return null;
		}
		return new SubInventoryPersistentData(subInventory);
	}
}
