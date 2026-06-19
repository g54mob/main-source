using System.Collections.Generic;
using Aggro.Core;
using Unity.Collections;
using Unity.Mathematics;

public class Inventory
{
	public struct Item
	{
		public ShiftOrderObject order;

		public int count;
	}

	private List<Item> _items = new List<Item>();

	private Dictionary<ShiftOrderObject, int> _orderToIndex = new Dictionary<ShiftOrderObject, int>();

	private Random _random;

	public int itemCount { get; private set; }

	public Inventory(int seed)
	{
		_random = MathUtil.GetRandom(seed);
	}

	private Inventory()
	{
	}

	public Inventory CreateCopy()
	{
		Inventory inventory = new Inventory();
		inventory._items.AddRangeNoGarbage(_items);
		inventory._orderToIndex = new Dictionary<ShiftOrderObject, int>(_orderToIndex);
		inventory._random = _random;
		inventory.itemCount = itemCount;
		return inventory;
	}

	public void Add(ShiftOrderObject order)
	{
		if (!_orderToIndex.TryGetValue(order, out var value))
		{
			value = _items.Count;
			_orderToIndex[order] = value;
			Item item = new Item
			{
				order = order,
				count = 0
			};
			_items.Add(item);
		}
		Item value2 = _items[value];
		value2.count++;
		_items[value] = value2;
		itemCount++;
	}

	public void Remove(ShiftOrderObject order)
	{
		int num = _orderToIndex[order];
		Item value = _items[num];
		if (value.count > 1)
		{
			value.count--;
			_items[num] = value;
		}
		else
		{
			_orderToIndex[_items[_items.Count - 1].order] = num;
			_items.RemoveAtSwapBack(num);
			_orderToIndex.Remove(order);
		}
		itemCount--;
	}

	public ShiftOrderObject RemoveRandom()
	{
		int num = _random.NextInt(0, itemCount);
		int num2 = 0;
		ShiftOrderObject shiftOrderObject = null;
		for (int i = 0; i < _items.Count; i++)
		{
			Item item = _items[i];
			num2 += item.count;
			if (num < num2)
			{
				shiftOrderObject = item.order;
				break;
			}
		}
		Remove(shiftOrderObject);
		return shiftOrderObject;
	}

	public bool TryGetCount(ShiftOrderObject order, out int count)
	{
		if (_orderToIndex.TryGetValue(order, out var value))
		{
			count = _items[value].count;
			return true;
		}
		count = 0;
		return false;
	}

	public bool Has(ShiftOrderObject order)
	{
		return _orderToIndex.ContainsKey(order);
	}

	public void ClearOrder(ShiftOrderObject order)
	{
		int num = _orderToIndex[order];
		_orderToIndex[_items[_items.Count - 1].order] = num;
		itemCount -= _items[num].count;
		_items.RemoveAtSwapBack(num);
		_orderToIndex.Remove(order);
	}

	public Item[] GetItems()
	{
		return _items.ToArray();
	}

	public void GetItems(List<Item> items)
	{
		items.AddRangeNoGarbage(_items);
	}
}
