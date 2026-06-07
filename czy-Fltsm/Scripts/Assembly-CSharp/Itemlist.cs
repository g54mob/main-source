using System.Collections.Generic;
using PajamaLlama.Debugs;
using UnityEngine;

public class Itemlist : MonoBehaviour
{
	[SerializeField]
	private InventoryPanelItemSlot _itemSlotPrefab;

	private List<InventoryPanelItemSlot> _itemSlots;

	public void AddItemSlotAtIndex(int index, ItemProperties itemProperties, int count = -1)
	{
		if (_itemSlots == null)
		{
			_itemSlots = new List<InventoryPanelItemSlot>();
		}
		InventoryPanelItemSlot inventoryPanelItemSlot;
		if (index < _itemSlots.Count)
		{
			inventoryPanelItemSlot = _itemSlots[index];
		}
		else
		{
			inventoryPanelItemSlot = Object.Instantiate(_itemSlotPrefab);
			inventoryPanelItemSlot.transform.SetParent(base.transform, worldPositionStays: false);
			_itemSlots.Add(inventoryPanelItemSlot);
		}
		inventoryPanelItemSlot.Initialize(itemProperties, count, 0 <= count);
	}

	public bool TryAddUniqueItemSlot(int uniqueItemCount, ItemProperties itemProperties)
	{
		if (_itemSlots == null)
		{
			_itemSlots = new List<InventoryPanelItemSlot>();
		}
		int i;
		for (i = 0; i < uniqueItemCount && i < _itemSlots.Count; i++)
		{
			if (_itemSlots[i].ItemProperties == itemProperties)
			{
				return false;
			}
		}
		AddItemSlotAtIndex(i, itemProperties);
		return true;
	}

	public void DeactivateItemSlots(int startingIndex = 0)
	{
		if (_itemSlots == null)
		{
			Debugger.Warning("Item slots in item list is null.", this);
			return;
		}
		for (int i = startingIndex; i < _itemSlots.Count; i++)
		{
			_itemSlots[i].gameObject.SetActive(value: false);
		}
	}
}
