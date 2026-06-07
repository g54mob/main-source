using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectionHelper
{
	private static Selectable cachedSelectable;

	public static void SwitchToLegal(IEnumerable<Selectable> selectables, bool forceReselect = false)
	{
		if (RInput.mouseIsActive)
		{
			return;
		}
		GameObject currentSelectedGameObject = EventSystem.current.currentSelectedGameObject;
		if (!forceReselect && currentSelectedGameObject != null && currentSelectedGameObject.activeInHierarchy)
		{
			if (cachedSelectable == null || cachedSelectable.gameObject != currentSelectedGameObject)
			{
				cachedSelectable = currentSelectedGameObject.GetComponent<Selectable>();
			}
			if (cachedSelectable != null && cachedSelectable.interactable && cachedSelectable.isActiveAndEnabled)
			{
				return;
			}
		}
		Selectable selectable = null;
		foreach (Selectable selectable2 in selectables)
		{
			if (selectable2.isActiveAndEnabled && selectable2.interactable)
			{
				selectable = selectable2;
				break;
			}
		}
		if (selectable != null)
		{
			EventSystem.current.SetSelectedGameObject(null);
			EventSystem.current.SetSelectedGameObject(selectable.gameObject);
		}
	}

	public static bool CanSelect(Selectable selectable)
	{
		return selectable != null && selectable.interactable && selectable.isActiveAndEnabled;
	}

	public static Selectable GetCurrentSelectable()
	{
		GameObject currentSelectedGameObject = EventSystem.current.currentSelectedGameObject;
		if (currentSelectedGameObject != null && currentSelectedGameObject.activeInHierarchy)
		{
			Selectable component = currentSelectedGameObject.GetComponent<Selectable>();
			if (component != null && component.interactable)
			{
				return component;
			}
		}
		return null;
	}

	public static GameObject GetCurrentGameObject()
	{
		return EventSystem.current.currentSelectedGameObject;
	}

	public static void ClearSelection()
	{
		EventSystem.current.SetSelectedGameObject(null);
	}

	public static void SetCurrent(GameObject go)
	{
		ClearSelection();
		EventSystem.current.SetSelectedGameObject(go);
	}

	public static void SetCurrent(Selectable selectable)
	{
		if (selectable != null)
		{
			SetCurrent(selectable.gameObject);
		}
		else
		{
			ClearSelection();
		}
	}

	public static Selectable GetFirstSelectableNeighbor(Navigation nav, MoveDirection dir)
	{
		for (int i = 0; i < 10; i++)
		{
			Selectable neighbor = GetNeighbor(nav, dir);
			if (neighbor == null)
			{
				break;
			}
			if (CanSelect(neighbor))
			{
				return neighbor;
			}
			nav = neighbor.navigation;
		}
		return null;
	}

	public static Selectable GetNextSelectableNeighbor(Selectable sel, MoveDirection dir, int steps)
	{
		Selectable firstSelectableNeighbor = GetFirstSelectableNeighbor(sel.navigation, dir);
		if (firstSelectableNeighbor == null)
		{
			return sel;
		}
		if (steps > 1)
		{
			return GetNextSelectableNeighbor(firstSelectableNeighbor, dir, steps - 1);
		}
		return firstSelectableNeighbor;
	}

	public static Selectable GetNeighbor(Navigation nav, MoveDirection dir)
	{
		switch (dir)
		{
		case MoveDirection.Up:
			return nav.selectOnUp;
		case MoveDirection.Down:
			return nav.selectOnDown;
		case MoveDirection.Left:
			return nav.selectOnLeft;
		case MoveDirection.Right:
			return nav.selectOnRight;
		default:
			return null;
		}
	}
}
