using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListSelectableGroup<T> : SelectableGroup where T : Selectable
{
	public enum Orientation
	{
		Horizontal = 0,
		Vertical = 1
	}

	[Header("List Selectable Group")]
	[SerializeField]
	private Orientation _orientation = Orientation.Vertical;

	[SerializeField]
	private bool _invert;

	public List<T> List { get; private set; }

	public void Initialize(List<T> list)
	{
		List = list;
		base.Initialize();
	}

	public override void Initialize(bool clearSelected = false)
	{
		Debug.LogException(new NotSupportedException("Use Initialize(List<T>) instead."));
	}

	protected override void SetFirstSelected()
	{
		if (!List.IsNullOrEmpty())
		{
			if (_invert)
			{
				Select(List[List.Count - 1]);
			}
			else
			{
				Select(List[0]);
			}
		}
	}

	protected override Selectable FindSelectableOnUp()
	{
		if (_orientation == Orientation.Vertical)
		{
			return FindSelectable(_invert ? 1 : (-1));
		}
		return null;
	}

	protected override Selectable FindSelectableOnRight()
	{
		if (_orientation == Orientation.Horizontal)
		{
			return FindSelectable((!_invert) ? 1 : (-1));
		}
		return null;
	}

	protected override Selectable FindSelectableOnDown()
	{
		if (_orientation == Orientation.Vertical)
		{
			return FindSelectable((!_invert) ? 1 : (-1));
		}
		return null;
	}

	protected override Selectable FindSelectableOnLeft()
	{
		if (_orientation == Orientation.Horizontal)
		{
			return FindSelectable(_invert ? 1 : (-1));
		}
		return null;
	}

	private Selectable FindSelectable(int direction)
	{
		if (List.IsNullOrEmpty() || !(base.Selected is T item))
		{
			return null;
		}
		int num = List.IndexOf(item) + direction;
		if (num < 0 || List.Count <= num)
		{
			return null;
		}
		return List[num];
	}
}
