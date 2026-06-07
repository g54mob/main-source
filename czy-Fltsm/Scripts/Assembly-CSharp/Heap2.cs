using System.Collections.Generic;
using PajamaLlama.Debugs;

public class Heap2<HEAP_ITEM_TYPE, HEAP_ITEM_GENERIC_TYPE> where HEAP_ITEM_TYPE : HeapItem<HEAP_ITEM_GENERIC_TYPE>, new()
{
	private List<HEAP_ITEM_TYPE> _items;

	private int _currentItemCount;

	public int Count => _currentItemCount;

	public List<HEAP_ITEM_TYPE> Items => _items;

	public Heap2(int capacity = 0)
	{
		_items = new List<HEAP_ITEM_TYPE>(capacity);
	}

	public HEAP_ITEM_TYPE Add(HEAP_ITEM_GENERIC_TYPE item)
	{
		HEAP_ITEM_TYPE val = new HEAP_ITEM_TYPE
		{
			Reference = item,
			Index = _currentItemCount
		};
		if (_items.Count == _currentItemCount)
		{
			_items.Add(val);
			_currentItemCount++;
		}
		else
		{
			_items[_currentItemCount++] = val;
		}
		SortUp(val);
		return val;
	}

	public HEAP_ITEM_TYPE RemoveFirst()
	{
		HEAP_ITEM_TYPE result = _items[0];
		_currentItemCount--;
		HEAP_ITEM_TYPE val = _items[_currentItemCount];
		val.Index = 0;
		_items[0] = val;
		_items[_currentItemCount] = null;
		SortDown(val);
		return result;
	}

	public void Remove(HEAP_ITEM_TYPE item)
	{
		for (int i = 0; i < _currentItemCount; i++)
		{
			if (_items[i].Equals(item))
			{
				_currentItemCount--;
				_items[i] = _items[_currentItemCount];
				_items[i].Index = i;
				SortDown(_items[i]);
				break;
			}
		}
	}

	public void Clear()
	{
		for (int i = 0; i < _currentItemCount; i++)
		{
			_items[i] = null;
		}
		_currentItemCount = 0;
	}

	private void SortDown(HEAP_ITEM_TYPE item)
	{
		while (true)
		{
			int num = item.Index * 2 + 1;
			if (num >= _currentItemCount)
			{
				break;
			}
			HEAP_ITEM_TYPE val = _items[num];
			int num2 = item.Index * 2 + 2;
			if (num2 < _currentItemCount)
			{
				HEAP_ITEM_TYPE val2 = _items[num2];
				if (val.CompareTo(val2) < 0)
				{
					num = num2;
					val = val2;
				}
			}
			if (item.CompareTo(val) < 0)
			{
				Swap(item, val, num);
				continue;
			}
			break;
		}
	}

	private void SortUp(HEAP_ITEM_TYPE item)
	{
		int num = item.Index;
		while (true)
		{
			num = (num - 1) / 2;
			HEAP_ITEM_TYPE val = _items[num];
			if (0 < item.CompareTo(val))
			{
				Swap(item, val, num);
				continue;
			}
			break;
		}
	}

	private void ValidateItem(HEAP_ITEM_TYPE item)
	{
		if (_items[item.Index].CompareTo(item) != 0)
		{
			Debugger.Warning("Invalid heap item! Heap index mismatch");
		}
	}

	private void ValidateSorting(int parentIndex = 0)
	{
		HEAP_ITEM_TYPE parent = _items[parentIndex];
		int num = parentIndex * 2 + 1;
		if (TryReturnCorrectlySortedChild(parent, num, out var _))
		{
			int num2 = parentIndex * 2 + 2;
			if (TryReturnCorrectlySortedChild(parent, num2, out var _))
			{
				ValidateSorting(num);
				ValidateSorting(num2);
			}
			else if (num2 < _currentItemCount)
			{
				Debugger.Warning("Heap not correctly sorted!");
			}
		}
		else if (num < _currentItemCount)
		{
			Debugger.Warning("Heap not correctly sorted!");
		}
	}

	private bool TryReturnCorrectlySortedChild(HEAP_ITEM_TYPE parent, int childIndex, out HEAP_ITEM_TYPE child)
	{
		if (childIndex < _currentItemCount)
		{
			child = _items[childIndex];
			return 0 <= parent.CompareTo(child);
		}
		child = null;
		return false;
	}

	private void Swap(HEAP_ITEM_TYPE firstItem, HEAP_ITEM_TYPE secondItem, int secondIndex)
	{
		int index = firstItem.Index;
		firstItem.Index = secondIndex;
		secondItem.Index = index;
		_items[index] = secondItem;
		_items[secondIndex] = firstItem;
	}

	public void UpdateItem(HEAP_ITEM_TYPE item)
	{
		SortUp(item);
	}

	public bool Contains(HEAP_ITEM_TYPE item)
	{
		return object.Equals(_items[item.Index], item);
	}

	public bool Contains(HEAP_ITEM_GENERIC_TYPE item)
	{
		for (int i = 0; i < _currentItemCount; i++)
		{
			if (_items[i].Reference.Equals(item))
			{
				return true;
			}
		}
		return false;
	}

	public bool TryReturnExistingHeapItem(HEAP_ITEM_GENERIC_TYPE item, out HEAP_ITEM_TYPE heapItem)
	{
		for (int i = 0; i < _currentItemCount; i++)
		{
			heapItem = _items[i];
			if (heapItem.Reference.Equals(item))
			{
				return true;
			}
		}
		heapItem = null;
		return false;
	}
}
