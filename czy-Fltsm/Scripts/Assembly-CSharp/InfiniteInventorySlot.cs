using System.Collections.Generic;

public class InfiniteInventorySlot
{
	public ItemProperties ItemProperties;

	public int Count;

	public bool IsEmpty = true;

	private SubInventory _inventory;

	private List<Item> _items;

	public InfiniteInventorySlot(SubInventory inventory)
	{
		_inventory = inventory;
		_items = new List<Item>();
	}

	public bool AddItem(Item item)
	{
		if (IsEmpty)
		{
			ItemProperties = item.Properties;
			IsEmpty = false;
		}
		_items.Add(item);
		Count++;
		return true;
	}

	public bool AddItems(List<Item> items)
	{
		int count = items.Count;
		if (count == 0)
		{
			return true;
		}
		if (IsEmpty)
		{
			ItemProperties = items[0].Properties;
			IsEmpty = false;
		}
		_items.AddRange(items);
		Count += count;
		return true;
	}

	public bool RemoveItem(Item item)
	{
		if (_items.Remove(item))
		{
			Count--;
			IsEmpty = Count == 0;
			return true;
		}
		return false;
	}

	public Item TakeItem()
	{
		if (IsEmpty)
		{
			return null;
		}
		int index = Count - 1;
		Item result = _items[index];
		_items.RemoveAt(index);
		Count--;
		IsEmpty = Count == 0;
		return result;
	}
}
