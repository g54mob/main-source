using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NotificationWithStringList<T> : NotificationMessage
{
	[NonSerialized]
	protected HashSet<T> _items = new HashSet<T>();

	protected HashSet<string> _serializedItems = new HashSet<string>();

	[NonSerialized]
	private bool _deserialized;

	public HashSet<T> Items
	{
		get
		{
			Deserialize();
			return _items;
		}
		set
		{
			_items = value;
		}
	}

	public NotificationWithStringList()
	{
	}

	public NotificationWithStringList(string msg, string icon, SDateTime date, NotificationManager.NotificationType type, params T[] items)
		: base(msg, icon, date, type)
	{
		_items.AddRange(items);
		_serializedItems.AddRange(items.Select(GetID));
		_deserialized = true;
	}

	public override int GetCount()
	{
		return Items.Count;
	}

	public override NotificationManager.DropType GetDropType()
	{
		return NotificationManager.DropType.List;
	}

	public override bool HasGoto()
	{
		return true;
	}

	public override void Goto(int idx = -1)
	{
		Debug.Log("Clicked on " + Items.GetAt(idx).ToString());
	}

	public abstract string GetID(T item);

	public abstract IEnumerable<T> GetObjects();

	private void Deserialize()
	{
		if (_deserialized)
		{
			return;
		}
		_deserialized = true;
		foreach (T @object in GetObjects())
		{
			if (_serializedItems.Contains(GetID(@object)))
			{
				_items.Add(@object);
			}
		}
		_serializedItems.Clear();
		foreach (T item in _items)
		{
			_serializedItems.Add(GetID(item));
		}
	}

	public override IEnumerable GetItems()
	{
		foreach (T item in Items)
		{
			yield return item;
		}
	}

	public override bool AddItem(object item)
	{
		T item2 = (T)item;
		if (Items.Add(item2))
		{
			_serializedItems.Add(GetID(item2));
			UIItem.Refresh();
			UIItem.RefreshCount();
			return true;
		}
		return false;
	}

	public override void RemoveItem(object item)
	{
		T item2 = (T)item;
		if (Items.Remove(item2))
		{
			_serializedItems.Remove(GetID(item2));
			UIItem.Refresh();
			UIItem.RefreshCount();
		}
	}
}
