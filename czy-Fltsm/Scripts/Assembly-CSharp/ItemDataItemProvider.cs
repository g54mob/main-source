using System.Collections.Generic;
using UnityEngine.Events;

public class ItemDataItemProvider : ItemDataInventory
{
	public SubInventory SubInventory { get; private set; }

	public event UnityAction<ItemDataItemProvider> InventoryUpdated;

	public event UnityAction<ItemDataItemProvider> InventoryLateUpdated;

	public ItemDataItemProvider(Inventory inventory, SubInventoryType subInventory)
		: base(inventory)
	{
		inventory.InventoryUpdatedEvent.AddListener(OnInventoryLateUpdate);
		SubInventory = inventory.ReturnInventory(subInventory);
	}

	public void ReserveItems(ItemProperties itemProperties, int amount, List<Item> reservedItems)
	{
		SubInventory.ReserveItems(itemProperties, amount, reservedItems);
	}

	public bool ReserveItems(IEnumerable<CountedItemProperty> countedItems, List<Item> reservedItems)
	{
		int num = 0;
		int num2 = 0;
		foreach (CountedItemProperty countedItem in countedItems)
		{
			num++;
			if (countedItem.ReservedAmount == countedItem.Amount)
			{
				num2++;
				continue;
			}
			SubInventory.ReserveItems(countedItem, reservedItems);
			if (countedItem.ReservedAmount == countedItem.Amount)
			{
				num2++;
			}
		}
		return num2 == num;
	}

	protected virtual void OnInventoryUpdate()
	{
		this.InventoryUpdated?.Invoke(this);
	}

	protected virtual void OnInventoryLateUpdate()
	{
		this.InventoryLateUpdated?.Invoke(this);
	}

	public bool ContainsUnreservedItem(ItemProperties itemProperties)
	{
		foreach (IInventorySlot slot in SubInventory.Slots)
		{
			if (slot.ItemProperties == itemProperties)
			{
				return 0 < slot.UnreservedCount;
			}
		}
		return false;
	}

	public int ReturnItemCount(ItemProperties itemProperties, bool includeReserved = false)
	{
		return SubInventory.ReturnItemCount(itemProperties, includeReserved);
	}

	public int ReturnStoredAndIncomingItemCount(ItemProperties itemProperties, bool includeReserved = false)
	{
		int num = SubInventory.ReturnItemCount(itemProperties, includeReserved);
		foreach (Item incomingItem in SubInventory.IncomingItems)
		{
			if (incomingItem.Properties == itemProperties && incomingItem.Inventory.Type == InventoryType.Agent)
			{
				num++;
			}
		}
		return num;
	}
}
