using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class InventorySlot : IInventorySlot
{
	private List<Item> _unreservedItems;

	private List<Item> _reservedItems;

	private int _simulationCount;

	public ItemProperties ItemProperties { get; private set; }

	public bool IsEmpty => Count == 0;

	public bool HasCapacity => Count < Capacity;

	public bool IsFull => Count == Capacity;

	public int Capacity { get; private set; }

	public int Count => _unreservedItems.Count + _reservedItems.Count;

	public int UnreservedCount => _unreservedItems.Count;

	public int ReservedCount => _reservedItems.Count;

	public event UnityAction<IInventorySlot> OnReservationUpdated;

	private void OnReservationUpdate()
	{
		if (this.OnReservationUpdated != null)
		{
			this.OnReservationUpdated(this);
		}
	}

	public InventorySlot(ItemProperties itemProperties, int capacity)
	{
		ItemProperties = itemProperties;
		_unreservedItems = new List<Item>();
		_reservedItems = new List<Item>();
		Capacity = capacity;
	}

	public InventorySlot(Item item)
		: this(item.Properties, item.Properties.StackLimit)
	{
		_unreservedItems.Capacity = Capacity;
		_unreservedItems.Add(item);
	}

	public InventorySlot(InventorySlot inventorySlot)
	{
		ItemProperties = inventorySlot.ItemProperties;
		_reservedItems = new List<Item>(inventorySlot._reservedItems);
		_unreservedItems = new List<Item>(inventorySlot._unreservedItems);
		Capacity = inventorySlot.Capacity;
	}

	public void Clear()
	{
		int count = _unreservedItems.Count;
		for (int i = 0; i < count; i++)
		{
			_unreservedItems[i].OnReserved -= ReserveItem;
		}
		_unreservedItems.Clear();
		count = _reservedItems.Count;
		for (int j = 0; j < count; j++)
		{
			Item item = _reservedItems[j];
			item.OnReservationCanceled -= CancelItemReservation;
			item.CancelReservation();
		}
		_reservedItems.Clear();
	}

	public bool AddItem(Item item)
	{
		if (ItemProperties != item.Properties || IsFull)
		{
			return false;
		}
		_unreservedItems.Add(item);
		item.OnReserved += ReserveItem;
		if (item.IsReserved)
		{
			ReserveItem(item);
		}
		return true;
	}

	public bool SimulateAddItem(Item item)
	{
		if (item.Properties == ItemProperties && Count + _simulationCount < Capacity)
		{
			_simulationCount++;
			return true;
		}
		return false;
	}

	public bool CanAddItem(Item item)
	{
		if (HasCapacity)
		{
			return item.Properties == ItemProperties;
		}
		return false;
	}

	public bool CanAddCountedItemProperty(CountedItemProperty countedItemProperty)
	{
		if (Count + countedItemProperty.Amount <= Capacity)
		{
			return countedItemProperty.ItemProperties == ItemProperties;
		}
		return false;
	}

	public Item PeekItem()
	{
		int count = _unreservedItems.Count;
		if (count == 0)
		{
			return null;
		}
		return _unreservedItems[count - 1];
	}

	public Item TakeItem(Item item)
	{
		if (item.IsReserved)
		{
			if (_reservedItems.Contains(item))
			{
				item.CancelReservation();
			}
			else
			{
				Debug.LogError("Trying to take reserved item that is not in the _reservedItems list.");
			}
		}
		if (_unreservedItems.Remove(item))
		{
			item.OnReserved -= ReserveItem;
			return item;
		}
		Debug.LogException(new Exception("Unable to take item!"));
		return null;
	}

	public bool TryTakeItem(out Item item, bool allowReserved = false)
	{
		if (TryTakeItem(_unreservedItems, out item))
		{
			item.OnReserved -= ReserveItem;
			return true;
		}
		if (allowReserved && TryTakeItem(_reservedItems, out item))
		{
			return true;
		}
		return false;
	}

	private bool TryTakeItem(List<Item> items, out Item item)
	{
		int count = items.Count;
		if (count == 0)
		{
			item = null;
			return false;
		}
		int index = count - 1;
		item = items[index];
		items.RemoveAt(index);
		if (item.IsReserved)
		{
			item.OnReservationCanceled -= CancelItemReservation;
			item.CancelReservation();
		}
		else
		{
			item.OnReserved -= ReserveItem;
		}
		return true;
	}

	public bool ReserveItem(ItemProperties itemProperties, List<Item> reservedItems)
	{
		int count = _unreservedItems.Count;
		if (count == 0 || ItemProperties != itemProperties)
		{
			return false;
		}
		int index = count - 1;
		Item item = _unreservedItems[index];
		item.Reserve();
		reservedItems.Add(item);
		return true;
	}

	public bool ContainsTag(Item.Tags tag)
	{
		return (ItemProperties.Tags & tag) == tag;
	}

	public Item ReturnFirstItem()
	{
		if (_unreservedItems.Count == 0)
		{
			return null;
		}
		return _unreservedItems[0];
	}

	public float ReturnFilling()
	{
		if (ItemProperties.StackLimit == 0)
		{
			return 0f;
		}
		return (float)Count / (float)ItemProperties.StackLimit;
	}

	public void PopulateItemList(List<Item> itemList, bool includeReserved)
	{
		itemList.AddRange(_unreservedItems);
		if (includeReserved)
		{
			itemList.AddRange(_reservedItems);
		}
	}

	public void Trim()
	{
		Capacity = Count;
	}

	public void StartSimulation()
	{
		_simulationCount = 0;
	}

	private void ReserveItem(Item item)
	{
		if (_unreservedItems.Remove(item))
		{
			_reservedItems.Add(item);
			item.OnReserved -= ReserveItem;
			item.OnReservationCanceled += CancelItemReservation;
			OnReservationUpdate();
			return;
		}
		throw new NotSupportedException("Trying to reserve an item that is not held by this slot!");
	}

	private void CancelItemReservation(Item item)
	{
		if (_reservedItems.Remove(item))
		{
			_unreservedItems.Add(item);
			item.OnReservationCanceled -= CancelItemReservation;
			item.OnReserved += ReserveItem;
			OnReservationUpdate();
			return;
		}
		throw new NotSupportedException("Canceling reservation of item that is not reserved!");
	}

	public bool TryReturnFirstAvailableItem(SubInventoryType subInventory, out Item item, IInventorySpaceLimiter limiter = null)
	{
		bool flag = limiter == null;
		int count = _unreservedItems.Count;
		for (int i = 0; i < count; i++)
		{
			item = _unreservedItems[i];
			if (item.Project == null)
			{
				if (!flag)
				{
					return limiter.FitsItem(item);
				}
				return true;
			}
		}
		item = null;
		return false;
	}

	public bool ReturnHasUnreservedItem()
	{
		if (IsEmpty)
		{
			return false;
		}
		int count = _unreservedItems.Count;
		for (int i = 0; i < count; i++)
		{
			Item item = _unreservedItems[i];
			if (item.Project == null && item.MoveToInventory == null)
			{
				return true;
			}
		}
		return false;
	}
}
