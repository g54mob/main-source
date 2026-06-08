using System;
using System.Collections.Generic;
using System.Linq;

public class PriorityQueue<T, TPriorityValue>
{
	private Dictionary<T, TPriorityValue> _itemsToPriority;

	private SortedDictionary<TPriorityValue, List<T>> _priorityToItems;

	public PriorityQueue()
	{
		_itemsToPriority = new Dictionary<T, TPriorityValue>();
		_priorityToItems = new SortedDictionary<TPriorityValue, List<T>>();
	}

	public void Clear()
	{
		_itemsToPriority.Clear();
		foreach (KeyValuePair<TPriorityValue, List<T>> priorityToItem in _priorityToItems)
		{
			priorityToItem.Value.Clear();
		}
		_priorityToItems.Clear();
	}

	public T Peek()
	{
		if (IsEmpty())
		{
			throw new Exception("Nothing in the priority queue!");
		}
		return _priorityToItems.First().Value.First();
	}

	public T Dequeue()
	{
		T val = Peek();
		Remove(val);
		return val;
	}

	public void Enqueue(T item, TPriorityValue priority)
	{
		if (_itemsToPriority != null && _itemsToPriority.ContainsKey(item))
		{
			throw new Exception("Item already exists in priority queue");
		}
		_itemsToPriority[item] = priority;
		List<T> list = null;
		if (_priorityToItems.ContainsKey(priority))
		{
			list = _priorityToItems[priority];
		}
		else
		{
			list = new List<T>();
			_priorityToItems[priority] = list;
		}
		list.Add(item);
	}

	public TPriorityValue GetItemPriority(T item)
	{
		return _itemsToPriority[item];
	}

	public void UpdatePriority(T item, TPriorityValue newPriority)
	{
		if (!_itemsToPriority[item].Equals(newPriority))
		{
			Remove(item);
			Enqueue(item, newPriority);
		}
	}

	public int Count()
	{
		return _itemsToPriority.Count;
	}

	public bool IsEmpty()
	{
		return Count() == 0;
	}

	private void Remove(T item)
	{
		TPriorityValue key = _itemsToPriority[item];
		_itemsToPriority.Remove(item);
		List<T> list = _priorityToItems[key];
		list.Remove(item);
		if (list.Count == 0)
		{
			_priorityToItems.Remove(key);
		}
	}

	public override string ToString()
	{
		return string.Format("[PriorityQueue: {0} items]", Count());
	}
}
