using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class NotificationWithList<T> : NotificationMessage
{
	public HashSet<T> Items = new HashSet<T>();

	public NotificationWithList()
	{
	}

	public NotificationWithList(string msg, string icon, SDateTime date, NotificationManager.NotificationType type, params T[] items)
		: base(msg, icon, date, type)
	{
		Items.AddRange(items);
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

	public override IEnumerable GetItems()
	{
		foreach (T item in Items)
		{
			yield return item;
		}
	}

	public override object AggregateObject()
	{
		return Items.Last();
	}

	public override bool AddItem(object item)
	{
		if (Items.Add((T)item))
		{
			UIItem.Refresh();
			UIItem.RefreshCount();
			return true;
		}
		return false;
	}

	public override void RemoveItem(object item)
	{
		if (Items.Remove((T)item))
		{
			UIItem.Refresh();
			UIItem.RefreshCount();
		}
	}
}
