using System;
using System.Collections.Generic;
using PajamaLlama.Debugs;
using UnityEngine.Events;

public class CompositionInventory : SubInventory
{
	private List<Item> _items;

	private bool _blocksClearingSlots;

	public event UnityAction<float> UpdatedEvent;

	private void OnUpdate()
	{
		if (this.UpdatedEvent != null)
		{
			this.UpdatedEvent(ReturnProgress());
		}
	}

	public CompositionInventory(IEnumerable<CountedItemProperty> countedItems)
		: base(SubInventoryType.Composition, CountedItemProperty.ReturnTotalAmount(countedItems))
	{
		foreach (CountedItemProperty countedItem in countedItems)
		{
			IInventorySlot inventorySlot = new InventorySlot(countedItem.ItemProperties, countedItem.Amount);
			inventorySlot.OnReservationUpdated += OnSlotReservationUpdate;
			base.Slots.Add(inventorySlot);
		}
		_items = new List<Item>(base.Capacity);
	}

	public CompositionInventory(List<Item> items, bool blocksClearingSlots = false)
		: base(SubInventoryType.Composition, items.Count)
	{
		_items = new List<Item>(items.Count);
		int count = items.Count;
		for (int i = 0; i < count; i++)
		{
			if (!AddItem(items[i]))
			{
				throw new NotSupportedException("Unable to add all composition items to CompositionInventory!");
			}
		}
		_blocksClearingSlots = blocksClearingSlots;
	}

	public override void Clear()
	{
		this.UpdatedEvent = null;
		if (!_blocksClearingSlots)
		{
			int count = base.Slots.Count;
			for (int i = 0; i < count; i++)
			{
				base.Slots[i].OnReservationUpdated -= OnSlotReservationUpdate;
			}
			base.Clear();
		}
	}

	public override bool AddItem(Item item)
	{
		if (TryReturnSlot(item.Properties, out var inventorySlot) && inventorySlot.IsFull)
		{
			return false;
		}
		if (base.AddItem(item))
		{
			_items.Add(item);
			OnUpdate();
			return true;
		}
		return false;
	}

	public override Item TakeItem(Item item)
	{
		if (base.TakeItem(item) == item)
		{
			if (_items == null || _items.Remove(item))
			{
				OnUpdate();
				return item;
			}
			Debugger.Log("Unable to take item from CompositionInventory");
			AddItem(item);
		}
		return null;
	}

	public new Item PeekAtFirstItem()
	{
		if (_items == null)
		{
			throw new NotImplementedException();
		}
		int count = _items.Count;
		if (_items.Count == 0)
		{
			return null;
		}
		return _items[count - 1];
	}

	public void Fill(InventoryBase inventory)
	{
		List<IInventorySlot> slots = base.Slots;
		int count = slots.Count;
		for (int i = 0; i < count; i++)
		{
			IInventorySlot inventorySlot = slots[i];
			int num = inventorySlot.Capacity - inventorySlot.Count;
			for (int j = 0; j < num; j++)
			{
				AddItem(new Item(inventorySlot.ItemProperties, inventory, SubInventoryType.Composition));
			}
		}
		OnUpdate();
	}

	public void Fill(InventoryBase inventory, IEnumerable<CountedItemProperty> countedItems)
	{
		foreach (CountedItemProperty countedItem in countedItems)
		{
			if (TryReturnSlot(countedItem.ItemProperties, out var inventorySlot))
			{
				for (int i = 0; i < countedItem.Amount && i < inventorySlot.Capacity; i++)
				{
					AddItem(new Item(countedItem.ItemProperties, inventory, SubInventoryType.Composition));
				}
			}
		}
	}

	private new void OnSlotReservationUpdate(IInventorySlot slot)
	{
		OnUpdate();
	}

	public List<Item> ReturnAllItems()
	{
		if (_items == null)
		{
			throw new NotSupportedException();
		}
		return _items;
	}

	public bool TryReturnSlot(ItemProperties itemProperties, out IInventorySlot inventorySlot)
	{
		foreach (IInventorySlot slot in base.Slots)
		{
			if (slot.ItemProperties == itemProperties)
			{
				inventorySlot = slot;
				return true;
			}
		}
		inventorySlot = null;
		return false;
	}

	public float ReturnProgress()
	{
		if (base.Capacity == 0)
		{
			return 1f;
		}
		int count = base.Slots.Count;
		float num = 0f;
		float num2 = base.Capacity;
		for (int i = 0; i < count; i++)
		{
			num += (float)base.Slots[i].Count;
		}
		return num / num2;
	}
}
