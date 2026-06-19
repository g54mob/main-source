using System;
using System.Collections.Generic;
using AssembleSystem;
using UnityEngine;

public class InventoryService : IInventoryService
{
	private readonly List<IInventoryManagable> _items;

	Action<IInventoryManagable> IInventoryService.OnItemPicked { get; set; }

	Action<IInventoryManagable> IInventoryService.OnItemDropped { get; set; }

	List<IInventoryManagable> IInventoryService.Items => _items;

	public InventoryService(int slotsCount)
	{
		_items = new List<IInventoryManagable>();
	}

	void IInventoryService.AddItem(IInventoryManagable item)
	{
		Debug.Log("Adding item from INventory Service");
		item.PickupItem();
		_items.Add(item);
		item.ItemConfig?.PlayEquipSounds();
		((IInventoryService)this).OnItemPicked?.Invoke(item);
	}

	void IInventoryService.RemoveItem(IInventoryManagable item)
	{
		if (item != null)
		{
			Debug.Log("Removing item from Inventory");
			((IInventoryService)this).OnItemDropped?.Invoke(item);
			item.RemoveItem();
			_items.Remove(item);
		}
	}
}
