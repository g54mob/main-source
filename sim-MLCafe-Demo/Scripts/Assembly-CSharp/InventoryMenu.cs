using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class InventoryMenu : MonoBehaviour
{
	[SerializeField]
	private GameObject slotPrefab;

	[SerializeField]
	private RectTransform content;

	[SerializeField]
	private TMP_Text labelInventoryName;

	public int inventoryId;

	public UnityEvent OnUpdateSelectedSlotEvent = new UnityEvent();

	private Inventory inventory;

	private List<ItemSlot> slots = new List<ItemSlot>();

	private bool init;

	public void SetInventoryId(int id)
	{
		if (inventory != null)
		{
			inventory.OnAddItemEvent.RemoveListener(UpdateAddToSlot);
			inventory.OnRemoveItemEvent.RemoveListener(UpdateRemoveFromSlot);
		}
		inventoryId = id;
		inventory = InventorySystem.GetInventory(id);
		if (!(inventory == null))
		{
			RefreshSlots();
			inventory.OnAddItemEvent.AddListener(UpdateAddToSlot);
			inventory.OnRemoveItemEvent.AddListener(UpdateRemoveFromSlot);
		}
	}

	private void Start()
	{
		if (inventoryId == -1 || init)
		{
			return;
		}
		inventory = InventorySystem.GetInventory(inventoryId);
		if (!(inventory == null))
		{
			for (int i = 0; i < inventory.items.Length; i++)
			{
				ItemSlot component = Object.Instantiate(slotPrefab, content).GetComponent<ItemSlot>();
				component.name = "Slot_" + i;
				slots.Add(component);
				Item slotItem = new Item
				{
					id = -1
				};
				component.SetInventory(inventoryId);
				component.SetSlotId(i);
				component.SetSlotItem(slotItem);
			}
			inventory.OnAddItemEvent.AddListener(UpdateAddToSlot);
			inventory.OnRemoveItemEvent.AddListener(UpdateRemoveFromSlot);
			inventory.OnSelectedSlotChanged.AddListener(UpdateSelectedSlot);
			UpdateSelectedSlot();
			init = true;
		}
	}

	private void UpdateSelectedSlot()
	{
		if (inventory.selectedSlot > -1)
		{
			slots[inventory.selectedSlot].SelectSlot();
		}
		OnUpdateSelectedSlotEvent.Invoke();
		foreach (ItemSlot slot in slots)
		{
			if (inventory.selectedSlot != slot.SelectSlot())
			{
				slot.DeselectSlot();
			}
		}
	}

	public void UpdateTypeName(bool isPrivateChest)
	{
		if (isPrivateChest)
		{
			labelInventoryName.text = "Private Chest";
		}
		else
		{
			labelInventoryName.text = "Storage";
		}
	}

	private void RefreshSlots()
	{
		if (inventory.items.Length == slots.Count - 1)
		{
			for (int i = 0; i < inventory.items.Length; i++)
			{
				slots[i].SetSlotItem(inventory.items[i]);
			}
			return;
		}
		slots.ForEach(delegate(ItemSlot x)
		{
			Object.Destroy(x.gameObject);
		});
		slots.Clear();
		for (int num = 0; num < inventory.items.Length; num++)
		{
			ItemSlot component = Object.Instantiate(slotPrefab, content).GetComponent<ItemSlot>();
			component.name = "Slot_" + num;
			slots.Add(component);
			component.SetInventory(inventoryId);
			component.SetSlotId(num);
			component.SetSlotItem(inventory.items[num]);
		}
		init = true;
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
