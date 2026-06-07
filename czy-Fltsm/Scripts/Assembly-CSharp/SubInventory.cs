using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SubInventory
{
	public class SubInventoryEvent : UnityEvent<SubInventory>
	{
	}

	private List<IInventorySlot> _slots;

	public SubInventoryEvent OnSlotReservationUpdated { get; private set; }

	public UnityEvent<Item> ItemTakenEvent { get; private set; }

	public SubInventoryType Type { get; private set; }

	public bool IsEmpty { get; private set; }

	public bool HasCapacity { get; private set; }

	public int Capacity { get; private set; }

	public int AvailableCapacity { get; private set; }

	public int Count { get; private set; }

	public float Weight { get; private set; }

	public List<IInventorySlot> Slots => _slots;

	public List<Item> IncomingItems { get; private set; }

	public event UnityAction Updated;

	public SubInventory(SubInventoryType type, int capacity)
	{
		Type = type;
		IsEmpty = true;
		HasCapacity = capacity > 0;
		Capacity = capacity;
		AvailableCapacity = capacity;
		Count = 0;
		Weight = 0f;
		_slots = new List<IInventorySlot>();
		IncomingItems = new List<Item>(Mathf.Min(capacity, 32));
		OnSlotReservationUpdated = new SubInventoryEvent();
		ItemTakenEvent = new UnityEvent<Item>();
	}

	public SubInventory(SubInventory other)
	{
		Type = other.Type;
		IsEmpty = other.IsEmpty;
		HasCapacity = other.HasCapacity;
		Capacity = other.Capacity;
		AvailableCapacity = other.AvailableCapacity;
		Count = other.Count;
		Weight = other.Weight;
		_slots = other._slots;
	}

	public virtual bool AddItem(Item item)
	{
		if (HasCapacity || item.IsQuestItem)
		{
			AddItemIgnoreCapacity(item);
			return true;
		}
		return false;
	}

	public void AddItemIgnoreCapacity(Item item)
	{
		int count = _slots.Count;
		for (int i = 0; i < count; i++)
		{
			if (_slots[i].AddItem(item))
			{
				OnItemAdded(item);
				return;
			}
		}
		IInventorySlot inventorySlot = new InventorySlot(item.Properties, int.MaxValue);
		inventorySlot.AddItem(item);
		inventorySlot.OnReservationUpdated += OnSlotReservationUpdate;
		_slots.Add(inventorySlot);
		OnItemAdded(item);
	}

	private void OnItemAdded(Item item)
	{
		IncreaseItemCount(1);
		Weight += item.Properties.Weight;
		this.Updated?.Invoke();
	}

	public bool CanAddCountedItemProperties(CountedItemProperty countedItemProperties)
	{
		return countedItemProperties.Amount + Count <= Capacity;
	}

	public virtual Item TakeItem(Item item)
	{
		if (TryReturnSlot(item.Properties, out var slot))
		{
			Item item2 = slot.TakeItem(item);
			if (item2 == item)
			{
				OnItemTaken(item2);
				return item2;
			}
		}
		return null;
	}

	public virtual Item TakeItem(ItemProperties itemProperties)
	{
		if (TryReturnSlot(itemProperties, out var slot))
		{
			Item item = slot.PeekItem();
			if (item == null)
			{
				return null;
			}
			slot.TakeItem(item);
			if (item.Properties == itemProperties)
			{
				OnItemTaken(item);
				return item;
			}
		}
		return null;
	}

	private void OnItemTaken(Item item)
	{
		DecreaseItemCount(1);
		Weight -= item.Properties.Weight;
		ItemTakenEvent.Invoke(item);
		this.Updated?.Invoke();
	}

	public virtual Item ReturnItemFromProperties(ItemProperties itemProperties)
	{
		if (TryReturnSlot(itemProperties, out var slot))
		{
			return slot.PeekItem();
		}
		return null;
	}

	public bool TryTakeRandomItem(out Item item, bool allowReserved)
	{
		if (0 < Count)
		{
			int count = _slots.Count;
			int num = UnityEngine.Random.Range(0, count);
			for (int i = 0; i < count; i++)
			{
				if (_slots[(num + i) % count].TryTakeItem(out item, allowReserved))
				{
					DecreaseItemCount(1);
					return true;
				}
			}
		}
		item = null;
		return false;
	}

	public void ReserveItems(ItemProperties itemProperties, int amount, List<Item> reservedItems)
	{
		if (TryReturnSlot(itemProperties, out var slot))
		{
			while (reservedItems.Count < amount && slot.ReserveItem(itemProperties, reservedItems))
			{
			}
		}
	}

	public void ReserveItems(CountedItemProperty countedItem, List<Item> reservedItems)
	{
		if (TryReturnSlot(countedItem.ItemProperties, out var slot))
		{
			while (countedItem.ReservedAmount < countedItem.Amount && slot.ReserveItem(countedItem.ItemProperties, reservedItems))
			{
				countedItem.ReservedAmount++;
			}
		}
	}

	public bool AddIncomingItem(Item item)
	{
		if (IncomingItems.AddUnique(item))
		{
			this.Updated?.Invoke();
			return true;
		}
		return false;
	}

	public bool RemoveIncomingItem(Item item)
	{
		if (IncomingItems.Remove(item))
		{
			this.Updated?.Invoke();
			return true;
		}
		return false;
	}

	public bool HasIncomingItem(Item item)
	{
		return IncomingItems.Contains(item);
	}

	public Item PeekAtFirstItem()
	{
		if (IsEmpty)
		{
			return null;
		}
		int count = _slots.Count;
		for (int i = 0; i < count; i++)
		{
			IInventorySlot inventorySlot = _slots[i];
			if (!inventorySlot.IsEmpty)
			{
				return inventorySlot.PeekItem();
			}
		}
		return null;
	}

	public bool ContainsSlotForItem(Item item)
	{
		IInventorySlot slot;
		return TryReturnSlot(item.Properties, out slot);
	}

	public void StartSimulation()
	{
		int count = _slots.Count;
		for (int i = 0; i < count; i++)
		{
			_slots[i].StartSimulation();
		}
	}

	public virtual void Clear()
	{
		int count = _slots.Count;
		for (int i = 0; i < count; i++)
		{
			_slots[i].Clear();
		}
		_slots.Clear();
		Count = 0;
		AvailableCapacity = Capacity;
		IsEmpty = true;
		HasCapacity = true;
	}

	private bool TryReturnSlot(ItemProperties itemProperties, out IInventorySlot slot)
	{
		int count = _slots.Count;
		for (int i = 0; i < count; i++)
		{
			slot = _slots[i];
			if (slot.ItemProperties == itemProperties)
			{
				return true;
			}
		}
		slot = null;
		return false;
	}

	private void IncreaseItemCount(int amount)
	{
		Count += amount;
		AvailableCapacity -= amount;
		IsEmpty = false;
		HasCapacity = Count < Capacity;
	}

	private void DecreaseItemCount(int amount)
	{
		Count -= amount;
		AvailableCapacity += amount;
		IsEmpty = Count == 0;
		HasCapacity = true;
	}

	protected virtual void OnSlotReservationUpdate(IInventorySlot slot)
	{
		if (OnSlotReservationUpdated != null)
		{
			OnSlotReservationUpdated.Invoke(this);
		}
		this.Updated?.Invoke();
	}

	public void PopulateCountedItemPropertyArray(CountedItemProperty[] countedItems)
	{
		if (countedItems == null)
		{
			throw new NotSupportedException("The counted item property array cannot be null");
		}
		int num = countedItems.Length;
		for (int i = 0; i < num; i++)
		{
			CountedItemProperty countedItemProperty = countedItems[i];
			countedItemProperty.Amount = ReturnItemCount(countedItemProperty.ItemProperties);
		}
	}

	public List<Item> ReturnAllItems(List<Item> listToPopulate = null, bool includeReserved = true)
	{
		int count = _slots.Count;
		List<Item> list = ((listToPopulate == null) ? new List<Item>(Count) : listToPopulate);
		for (int i = 0; i < count; i++)
		{
			_slots[i].PopulateItemList(list, includeReserved);
		}
		return list;
	}

	public List<Item> ReturnItemsWithTags(Item.Tags tags, List<Item> listToPopulate = null, bool includeReserved = true)
	{
		List<Item> list = listToPopulate ?? new List<Item>(Count);
		foreach (IInventorySlot slot in _slots)
		{
			if (slot.ItemProperties.Tags.HasFlag(tags))
			{
				slot.PopulateItemList(list, includeReserved);
			}
		}
		return list;
	}

	public bool TryReturnItemContainingTag(Item.Tags tag, out Item item)
	{
		for (int i = 0; i < _slots.Count; i++)
		{
			IInventorySlot inventorySlot = _slots[i];
			if (!inventorySlot.IsEmpty && (inventorySlot.ItemProperties.Tags & tag) == tag)
			{
				item = inventorySlot.PeekItem();
				return true;
			}
		}
		item = null;
		return false;
	}

	public bool TryReturnItem(ItemProperties itemProperties, out Item item)
	{
		for (int i = 0; i < _slots.Count; i++)
		{
			IInventorySlot inventorySlot = _slots[i];
			if (!inventorySlot.IsEmpty && inventorySlot.ItemProperties == itemProperties)
			{
				item = inventorySlot.PeekItem();
				return true;
			}
		}
		item = null;
		return false;
	}

	public bool ReturnFirstAvailableItem(SubInventoryType subInventory, out Item item, IInventorySpaceLimiter limiter = null)
	{
		for (int i = 0; i < _slots.Count; i++)
		{
			if (_slots[i].TryReturnFirstAvailableItem(subInventory, out item, limiter))
			{
				return true;
			}
		}
		item = null;
		return false;
	}

	public bool ReturnContainsItems(IEnumerable<CountedItemProperty> countedItems)
	{
		foreach (CountedItemProperty countedItem in countedItems)
		{
			if (!ReturnContainsItems(countedItem.ItemProperties, countedItem.Amount))
			{
				return false;
			}
		}
		return true;
	}

	public bool ReturnContainsItems(ItemProperties itemProperties, int amount = 1)
	{
		int count = _slots.Count;
		int num = 0;
		for (int i = 0; i < count; i++)
		{
			IInventorySlot inventorySlot = _slots[i];
			if (inventorySlot.ItemProperties == itemProperties)
			{
				num += inventorySlot.UnreservedCount;
				if (amount <= num)
				{
					return true;
				}
			}
		}
		return false;
	}

	public bool ReturnHasCapacity()
	{
		return 0 < AvailableCapacity - IncomingItems.Count;
	}

	public int ReturnItemCount(bool includeReserved = false)
	{
		int count = _slots.Count;
		int num = 0;
		for (int i = 0; i < count; i++)
		{
			num += _slots[i].UnreservedCount;
			if (includeReserved)
			{
				num += _slots[i].ReservedCount;
			}
		}
		return num;
	}

	public int ReturnItemCount(ItemProperties itemProperties, bool includeReserved = false)
	{
		int count = _slots.Count;
		int num = 0;
		for (int i = 0; i < count; i++)
		{
			IInventorySlot inventorySlot = _slots[i];
			if (inventorySlot.ItemProperties == itemProperties)
			{
				num += inventorySlot.UnreservedCount;
				if (includeReserved)
				{
					num += inventorySlot.ReservedCount;
				}
			}
		}
		return num;
	}

	public int ReturnItemContainingTagCount(Item.Tags tag, bool includeReserved = false)
	{
		int count = _slots.Count;
		int num = 0;
		for (int i = 0; i < count; i++)
		{
			IInventorySlot inventorySlot = _slots[i];
			if ((inventorySlot.ItemProperties.Tags & tag) != Item.Tags.None)
			{
				num += inventorySlot.UnreservedCount;
				if (includeReserved)
				{
					num += inventorySlot.ReservedCount;
				}
			}
		}
		return num;
	}

	public float ReturnItemContainingTagNutritionalValue(Item.Tags tag, bool includeReserved = false)
	{
		int count = _slots.Count;
		float num = 0f;
		for (int i = 0; i < count; i++)
		{
			IInventorySlot inventorySlot = _slots[i];
			if ((inventorySlot.ItemProperties.Tags & tag) != Item.Tags.None)
			{
				num += (float)inventorySlot.UnreservedCount * inventorySlot.ItemProperties.NutritionalValue;
				if (includeReserved)
				{
					num += (float)inventorySlot.ReservedCount * inventorySlot.ItemProperties.NutritionalValue;
				}
			}
		}
		return num;
	}

	public int ReturnItemMatchingTagsCount(Item.Tags tags)
	{
		int count = _slots.Count;
		int num = 0;
		for (int i = 0; i < count; i++)
		{
			IInventorySlot inventorySlot = _slots[i];
			if (inventorySlot.ItemProperties.Tags == tags)
			{
				num += inventorySlot.UnreservedCount;
			}
		}
		return num;
	}

	public CountedItemProperty[] ReturnAsCounteItemPropertyArray()
	{
		int count = Slots.Count;
		CountedItemProperty[] array = new CountedItemProperty[Slots.Count];
		for (int i = 0; i < count; i++)
		{
			IInventorySlot inventorySlot = Slots[i];
			array[i] = new CountedItemProperty(inventorySlot.ItemProperties, inventorySlot.Count);
		}
		return array;
	}

	public float ReturnWeight()
	{
		float num = 0f;
		int count = _slots.Count;
		for (int i = 0; i < count; i++)
		{
			IInventorySlot inventorySlot = _slots[i];
			num += inventorySlot.ItemProperties.Weight * (float)inventorySlot.Count;
		}
		return num;
	}

	public string ReturnFormattedInventorySlotList()
	{
		string text = string.Empty;
		foreach (IInventorySlot slot in _slots)
		{
			text += $"{slot.ItemProperties.name} ({slot.Count}/{slot.Capacity}).{Environment.NewLine}";
		}
		return text;
	}
}
