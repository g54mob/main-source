using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ToolbarMenu : MonoBehaviour
{
	[SerializeField]
	private GameObject slotPrefab;

	[SerializeField]
	private RectTransform content;

	private Inventory characterInventory;

	private List<ItemSlot> slots = new List<ItemSlot>();

	private void Start()
	{
		characterInventory = InventorySystem.GetInventory(0);
		for (int i = 0; i < characterInventory.items.Length; i++)
		{
			ItemSlot component = Object.Instantiate(slotPrefab, content).GetComponent<ItemSlot>();
			component.name = "Slot_" + i;
			slots.Add(component);
		}
		characterInventory.OnAddItemEvent.AddListener(UpdateAddToSlot);
		characterInventory.OnRemoveItemEvent.AddListener(UpdateRemoveFromSlot);
	}

	private void UpdateAddToSlot(Item item, int slotIndex)
	{
		ItemSlot itemSlot = slots[slotIndex];
		if (itemSlot == null)
		{
			slots.First((ItemSlot x) => x.assignedItem.id == -1).SetSlotItem(item);
		}
		else
		{
			itemSlot.SetSlotItem(item);
		}
	}

	private void UpdateRemoveFromSlot(Item item, int slotIndex)
	{
		ItemSlot itemSlot = slots[slotIndex];
		if (!(itemSlot == null))
		{
			if (item.id == -1)
			{
				itemSlot.RemoveItem();
			}
			else
			{
				itemSlot.SetSlotItem(item);
			}
		}
	}
}
