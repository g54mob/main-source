using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
	public List<Inventory> inventories = new List<Inventory>();

	public ItemLibrary itemLibrary;

	private static InventorySystem instance;

	public static InventorySystem GetInstance()
	{
		return instance;
	}

	public void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Object.Destroy(this);
		}
		Object.DontDestroyOnLoad(instance);
	}

	private void Start()
	{
	}

	public static IEnumerator SpawnStartItems(int inventory)
	{
		yield return new WaitUntil(() => instance.inventories.Count > 1);
		instance.ApplyStartItems(inventory);
	}

	public void ApplyStartItems(int inventory)
	{
		AddItemToInventory(itemLibrary.GetItemByName("Axe"), inventory);
		AddItemToInventory(itemLibrary.GetItemByName("Pickaxe"), inventory);
		AddItemToInventory(itemLibrary.GetItemByName("Hammer"), inventory);
	}

	public static int AddInventory(Inventory inventory)
	{
		instance.inventories.Add(inventory);
		return instance.inventories.Count - 1;
	}

	public static ItemLibrary GetItemLibrary()
	{
		return instance.itemLibrary;
	}

	public static Inventory GetInventory(int inventoryId)
	{
		if (!ValidInventoryId(inventoryId))
		{
			return null;
		}
		return instance.inventories[inventoryId];
	}

	public static bool ValidInventoryId(int id)
	{
		if (instance == null)
		{
			return false;
		}
		if (instance.inventories == null)
		{
			return false;
		}
		if (id < instance.inventories.Count && id > -1)
		{
			if (instance.inventories[id] == null)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public static bool IsSlotEmpty(int slotId, int inventoryId)
	{
		return instance.inventories[inventoryId].items[slotId].id == -1;
	}

	public static bool HasItem(int itemId, int inventoryId)
	{
		int itemIndex = instance.inventories[inventoryId].GetItemIndex(itemId);
		return instance.inventories[inventoryId].ValidItem(itemIndex);
	}

	public static bool HasStackableItem(Item inputItem, int inventoryId, ItemSlot slot)
	{
		Item stackableItem = instance.inventories[inventoryId].items[slot.slotId];
		if (stackableItem.id == -1 || stackableItem.id != inputItem.id)
		{
			return false;
		}
		return instance.inventories[inventoryId].ValidStackableItem(inputItem, stackableItem);
	}

	public static bool HasItemWithAmount(int itemId, int inventoryId, int amount)
	{
		int itemIndexWithMinimumAmount = instance.inventories[inventoryId].GetItemIndexWithMinimumAmount(itemId, amount);
		return instance.inventories[inventoryId].ValidItem(itemIndexWithMinimumAmount);
	}

	public static int ClampItemAmount(int itemId, int inventoryId, int requestedAmount)
	{
		Item item = instance.inventories[inventoryId].items[itemId];
		if (requestedAmount > item.amount)
		{
			return item.amount;
		}
		return requestedAmount;
	}

	public static void AddItemToInventory(int itemId, int targetInventoryId, int amount = 1, int indexInInventory = -1)
	{
		if (ValidInventoryId(targetInventoryId))
		{
			if (indexInInventory == -1)
			{
				instance.inventories[targetInventoryId].AddItem(itemId, amount);
			}
			else
			{
				instance.inventories[targetInventoryId].AddItem(itemId, amount, indexInInventory);
			}
		}
	}

	public static void AddItemsToInventory(Item[] items, int targetInventoryId)
	{
		if (ValidInventoryId(targetInventoryId))
		{
			for (int i = 0; i < items.Length; i++)
			{
				instance.inventories[targetInventoryId].AddItem(items[i].id, items[i].amount);
			}
		}
	}

	public static bool RemoveItemToInventory(int itemId, int targetInventoryId, int amount = 1)
	{
		if (!ValidInventoryId(targetInventoryId))
		{
			return false;
		}
		if (!HasItem(itemId, targetInventoryId))
		{
			return false;
		}
		return instance.inventories[targetInventoryId].RemoveItem(itemId, amount);
	}

	public static bool RemoveItemFromInventorySlot(int itemId, int fromInventory, int fromSlotId)
	{
		if (!ValidInventoryId(fromInventory))
		{
			return false;
		}
		if (!HasItem(itemId, fromInventory))
		{
			return false;
		}
		return instance.inventories[fromInventory].RemoveItemAtSlot(itemId, fromSlotId);
	}

	public static bool RemoveItemAmountFromInventorySlotWith(int itemId, int fromInventory, int fromSlotId, int amount = 1)
	{
		if (!ValidInventoryId(fromInventory))
		{
			return false;
		}
		if (!HasItem(itemId, fromInventory))
		{
			return false;
		}
		return instance.inventories[fromInventory].RemoveItemAmountAtSlot(itemId, amount, fromSlotId);
	}

	public static void TransferItemsToAnotherInventory(ref Item[] items, int fromInventoryId, int toInventoryId)
	{
		Item[] array = items;
		for (int i = 0; i < array.Length; i++)
		{
			Item item = array[i];
			TransferItemToAnotherInventory(item.id, fromInventoryId, toInventoryId, item.amount);
		}
	}

	public static void TransferItemsToAnotherInventoryByOrder(Item[] items, ref Item[] order, int fromInventoryId, int toInventoryId)
	{
		List<Item> list = order.ToList();
		int i;
		for (i = 0; i < items.Length; i++)
		{
			int num = list.FindIndex(0, items.Length, (Item x) => x.id == items[i].id);
			TransferItemToAnotherInventoryWithIndex(items[num].id, fromInventoryId, toInventoryId, items[num].amount, num);
		}
	}

	public static void TransferItemsToAnotherInventoryByOrder(Item[] items, ref List<Item> order, int fromInventoryId, int toInventoryId)
	{
		int i;
		for (i = 0; i < items.Length; i++)
		{
			Item item = order.Find((Item x) => x.id == items[i].id);
			int inventoryPosition = order.IndexOf(item);
			TransferItemToAnotherInventoryWithIndex(item.id, fromInventoryId, toInventoryId, items[i].amount, inventoryPosition);
		}
	}

	public static void TransferItemToAnotherInventoryWithIndex(int itemId, int fromInventoryId, int toInventoryId, int amount, int inventoryPosition)
	{
		if (ValidInventoryId(fromInventoryId) && ValidInventoryId(toInventoryId) && HasItem(itemId, fromInventoryId))
		{
			RemoveItemToInventory(itemId, fromInventoryId, amount);
			AddItemToInventory(itemId, toInventoryId, amount, inventoryPosition);
		}
	}

	public static void TransferItemToAnotherInventory(int itemId, int fromInventoryId, int toInventoryId, int amount)
	{
		if (ValidInventoryId(fromInventoryId) && ValidInventoryId(toInventoryId) && HasItem(itemId, fromInventoryId))
		{
			RemoveItemToInventory(itemId, fromInventoryId, amount);
			AddItemToInventory(itemId, toInventoryId, amount);
		}
	}

	public static void TransferItemToAnotherInventorySlot(int itemId, int toInventoryId, ItemSlot targetDropItemSlot, AnomalyTag tags, int transferAmount = 1)
	{
		if (!ValidInventoryId(toInventoryId))
		{
			return;
		}
		Item item = Item.Create(itemId, transferAmount, tags);
		item.maxAmount = GetItemLibrary().itemInfos[itemId].maxStack;
		if (HasStackableItem(item, toInventoryId, targetDropItemSlot))
		{
			Debug.Log("Stackable Item");
			if (instance.inventories[toInventoryId].StackItem(targetDropItemSlot, itemId, transferAmount, tags))
			{
				targetDropItemSlot.assignedItem = instance.inventories[toInventoryId].items[targetDropItemSlot.slotId];
				targetDropItemSlot.UpdateSlotItem();
			}
			else
			{
				targetDropItemSlot.SetSlotItem(item);
			}
		}
		else
		{
			Debug.Log("No Stackable Item");
			instance.inventories[toInventoryId].SetSlotToItem(targetDropItemSlot, itemId, transferAmount);
			targetDropItemSlot.SetSlotItem(item);
			GetInventory(toInventoryId).OnInventoryItemsChangeEvent.Invoke();
		}
	}

	public static void TransferToEmptySlot(Item item, int toInventoryId, ItemSlot targetDropItemSlot)
	{
		if (ValidInventoryId(toInventoryId))
		{
			instance.inventories[toInventoryId].SetSlotToItem(targetDropItemSlot, item.id, item.amount);
			targetDropItemSlot.SetSlotItem(item);
		}
	}

	public static void TransferToEmptySlot(Item item, int toInventoryId, int slotId)
	{
		if (ValidInventoryId(toInventoryId))
		{
			instance.inventories[toInventoryId].SetEmptySlotToItem(slotId, item.id, item.amount);
		}
	}

	public static void TransferItemAmountToStack(int toInventoryId, ItemSlot targetDropItemSlot, int transferAmount)
	{
		if (ValidInventoryId(toInventoryId))
		{
			instance.inventories[toInventoryId].items[targetDropItemSlot.slotId].amount += transferAmount;
			targetDropItemSlot.assignedItem.amount += transferAmount;
			targetDropItemSlot.UpdateSlotItem();
			GetInventory(toInventoryId).OnInventoryItemsChangeEvent.Invoke();
		}
	}

	public static bool IsValidated()
	{
		return instance != null;
	}
}
