using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
	[SerializeField]
	public new string name = "";

	[SerializeField]
	private int inventorySize = 8;

	[SerializeField]
	public int selectedSlot = -1;

	private int lastAddedSlot = -1;

	public Item[] items = new Item[8];

	public StartItem[] startItems;

	public UnityEvent OnStart = new UnityEvent();

	public UnityEvent OnInventoryItemsChangeEvent = new UnityEvent();

	public UnityEvent<Item, int> OnAddItemEvent;

	public UnityEvent<Item, int> OnRemoveItemEvent;

	public UnityEvent OnSelectedSlotChanged = new UnityEvent();

	[SerializeField]
	private bool runtimeInventory = true;

	[SerializeField]
	private int inventoryId;

	public bool IsInventoryEmpty()
	{
		Item[] array = items;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].id > -1)
			{
				return false;
			}
		}
		return true;
	}

	public void Clear()
	{
		Array.Fill(items, Item.Empty());
	}

	public Item GetLastAddedItem()
	{
		return items[lastAddedSlot];
	}

	public Item GetFirstValidItem()
	{
		return items.First((Item x) => x.id != -1);
	}

	public void IncreaseSelection(int value = 1)
	{
		selectedSlot += value;
		if (selectedSlot >= items.Length)
		{
			selectedSlot = 0;
		}
		OnSelectedSlotChanged.Invoke();
	}

	public void DecreaseSelection(int value = 1)
	{
		selectedSlot -= value;
		if (selectedSlot < 0)
		{
			selectedSlot = items.Length - 1;
		}
		OnSelectedSlotChanged.Invoke();
	}

	public void SelectItem(int slotId)
	{
		selectedSlot = slotId;
		OnSelectedSlotChanged.Invoke();
	}

	public bool IsItemSelected(int itemId)
	{
		if (selectedSlot == -1)
		{
			return false;
		}
		return items[selectedSlot].id == itemId;
	}

	private void Start()
	{
		Init();
	}

	public void Init(int customSize = -1)
	{
		_ = inventorySize;
		_ = -1;
		if (items.Length != inventorySize)
		{
			items = new Item[inventorySize];
		}
		items.AsSpan().Fill(Item.Empty());
		if (runtimeInventory)
		{
			inventoryId = InventorySystem.AddInventory(this);
		}
		for (int i = 0; i < startItems.Length; i++)
		{
			if (startItems[i].useStartItem)
			{
				items[i] = startItems[i].item;
			}
		}
		OnStart.Invoke();
	}

	public int GetInventoryId()
	{
		return inventoryId;
	}

	public int GetEmptySlot()
	{
		for (int i = 0; i < inventorySize; i++)
		{
			if (items[i].id == -1)
			{
				return i;
			}
		}
		return -1;
	}

	public bool IsFull()
	{
		bool result = true;
		for (int i = 0; i < inventorySize; i++)
		{
			if (items[i].id == -1)
			{
				result = false;
			}
		}
		return result;
	}

	public int GetItemIndex(int itemId)
	{
		for (int i = 0; i < inventorySize; i++)
		{
			if (items[i].id == itemId)
			{
				return i;
			}
		}
		return -1;
	}

	public Item GetItem(int itemId)
	{
		for (int i = 0; i < inventorySize; i++)
		{
			if (items[i].id == itemId)
			{
				return items[i];
			}
		}
		return Item.Empty();
	}

	public int GetItemCount()
	{
		int num = 0;
		for (int i = 0; i < inventorySize; i++)
		{
			if (items[i].id != -1)
			{
				num++;
			}
		}
		return num;
	}

	public int GetItemIndexWithMinimumAmount(int itemId, int minAmount)
	{
		for (int i = 0; i < inventorySize; i++)
		{
			if (items[i].id == itemId && items[i].amount >= minAmount)
			{
				return i;
			}
		}
		return -1;
	}

	public bool HasItemsAndAmount(Item[] inputItems)
	{
		bool result = true;
		int i;
		for (i = 0; i < inputItems.Length; i++)
		{
			if (!items.ToList().Exists((Item x) => x.id == inputItems[i].id && x.amount >= inputItems[i].amount))
			{
				result = false;
			}
		}
		return result;
	}

	public bool HasAnyItemsWithAmount(Item[] inputItems)
	{
		bool result = false;
		int i;
		for (i = 0; i < inputItems.Length; i++)
		{
			if (items.ToList().Exists((Item x) => x.id == inputItems[i].id && x.amount >= inputItems[i].amount))
			{
				result = true;
			}
		}
		return result;
	}

	public bool HasAnyItems(Item[] inputItems)
	{
		bool result = false;
		int i;
		for (i = 0; i < inputItems.Length; i++)
		{
			if (items.ToList().Exists((Item x) => x.id == inputItems[i].id))
			{
				result = true;
			}
		}
		return result;
	}

	public bool ValidItem(int item)
	{
		if (item == -1)
		{
			return false;
		}
		return true;
	}

	public bool ValidStackableItem(Item inputItem, Item stackableItem)
	{
		if (inputItem.id == stackableItem.id)
		{
			return stackableItem.amount + inputItem.amount <= stackableItem.maxAmount;
		}
		return false;
	}

	public int GetItemAmount(int itemId)
	{
		int num = 0;
		Item[] array = items;
		for (int i = 0; i < array.Length; i++)
		{
			Item item = array[i];
			if (item.id == itemId)
			{
				num += item.amount;
			}
		}
		return num;
	}

	public void AddItem(int itemId, int amount, int prefferedSlot = -1)
	{
		int itemIndex = GetItemIndex(itemId);
		if (!ValidItem(itemIndex))
		{
			int num = ((prefferedSlot == -1) ? GetEmptySlot() : prefferedSlot);
			if (num == -1)
			{
				return;
			}
			items[num].id = itemId;
			items[num].amount = amount;
			lastAddedSlot = num;
			OnAddItemEvent.Invoke(items[num], num);
		}
		else
		{
			items[itemIndex].id = itemId;
			items[itemIndex].amount += amount;
			lastAddedSlot = itemIndex;
			OnAddItemEvent.Invoke(items[itemIndex], itemIndex);
		}
		OnInventoryItemsChangeEvent.Invoke();
	}

	public bool RemoveItem(int itemId, int amount)
	{
		int itemIndex = GetItemIndex(itemId);
		if (ValidItem(itemIndex))
		{
			if (amount >= items[itemIndex].amount)
			{
				items[itemIndex].id = -1;
				items[itemIndex].amount = 0;
			}
			else
			{
				items[itemIndex].amount -= amount;
			}
			OnRemoveItemEvent.Invoke(items[itemIndex], itemIndex);
			OnInventoryItemsChangeEvent.Invoke();
			return true;
		}
		return false;
	}

	public bool RemoveItemAtSlot(int itemId, int slot)
	{
		if (ValidItem(slot))
		{
			if (itemId == items[slot].id)
			{
				items[slot] = Item.Empty();
				OnRemoveItemEvent.Invoke(items[slot], slot);
				OnInventoryItemsChangeEvent.Invoke();
				return true;
			}
			return false;
		}
		return false;
	}

	public bool RemoveItemAmountAtSlot(int itemId, int amount, int slot)
	{
		if (ValidItem(slot))
		{
			if (itemId == items[slot].id)
			{
				items[slot].amount -= amount;
				if (items[slot].amount <= 0)
				{
					items[slot] = Item.Empty();
				}
				OnRemoveItemEvent.Invoke(items[slot], slot);
				OnInventoryItemsChangeEvent.Invoke();
				return true;
			}
			return false;
		}
		return false;
	}

	public bool StackItem(ItemSlot slot, int itemId, int amount, AnomalyTag tags)
	{
		if (items[slot.slotId].amount >= items[slot.slotId].maxAmount)
		{
			return false;
		}
		items[slot.slotId].amount += amount;
		if (items[slot.slotId].amount > items[slot.slotId].maxAmount)
		{
			int amount2 = items[slot.slotId].maxAmount - items[slot.slotId].amount;
			DragDropPointer.BeginDragItem(Item.Create(itemId, amount2, tags), slot, inventoryId);
		}
		OnInventoryItemsChangeEvent.Invoke();
		return true;
	}

	public void SetSlotToItem(ItemSlot slot, int itemId, int amount)
	{
		if (ValidItem(items[slot.slotId].id))
		{
			DragDropPointer.BeginDragItem(items[slot.slotId], slot, inventoryId);
			items[slot.slotId].id = itemId;
			items[slot.slotId].amount = amount;
		}
		else
		{
			items[slot.slotId].id = itemId;
			items[slot.slotId].amount = amount;
		}
		OnInventoryItemsChangeEvent.Invoke();
	}

	public void SetEmptySlotToItem(int slotId, int itemId, int amount)
	{
		if (!ValidItem(items[slotId].id))
		{
			items[slotId].id = itemId;
			items[slotId].amount = amount;
		}
		OnInventoryItemsChangeEvent.Invoke();
	}

	public void ChangeInventorySize(int newSize)
	{
		inventorySize = newSize;
		items = new Item[inventorySize];
		for (int i = 0; i < items.Length; i++)
		{
			items[i] = Item.Empty();
		}
		if (selectedSlot > newSize)
		{
			selectedSlot = newSize;
		}
	}

	public void ChangeMaxStackForSlot(int index, int max)
	{
		items[index].maxAmount = max;
	}

	[ContextMenu("DEBUG ITEMS")]
	public void DebugItems()
	{
		DebugGiveWood();
		DebugGiveChest();
		DebugGiveWorkstation();
	}

	[ContextMenu("Give 100x Wood ")]
	public void DebugGiveWood()
	{
		InventorySystem.AddItemToInventory(InventorySystem.GetItemLibrary().GetItemByName("Wood"), 0, 100);
	}

	[ContextMenu("Give 1x Sawmill ")]
	public void DebugGiveWorkstation()
	{
		InventorySystem.AddItemToInventory(InventorySystem.GetItemLibrary().GetItemByName("Sawmill"), 0);
	}

	[ContextMenu("Give 3x Chests ")]
	public void DebugGiveChest()
	{
		InventorySystem.AddItemToInventory(InventorySystem.GetItemLibrary().GetItemByName("Chest"), 0, 3);
	}
}
