using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AsciiCellProcedural
{
	public Material material;

	public float scaleX;

	public float scaleY;

	private int _value;

	private Color _foregroundColor;

	private Color _backgroundColor;

	private int lastValue;

	private Color lastForegroundColor;

	private Color lastBackgroundColor;

	private int gridPosX;

	private int gridPosY;

	private List<ICellInteractable> interactableObjects = new List<ICellInteractable>();

	private int interactablePriority = int.MinValue;

	private char _unicodeValue;

	public int Value
	{
		get
		{
			return _value;
		}
		set
		{
			_value = value;
		}
	}

	public Color foregroundColor
	{
		get
		{
			return _foregroundColor;
		}
		set
		{
			_foregroundColor = value;
		}
	}

	public Color backgroundColor
	{
		get
		{
			return _backgroundColor;
		}
		set
		{
			_backgroundColor = value;
		}
	}

	public char unicodeValue
	{
		get
		{
			return _unicodeValue;
		}
		set
		{
			_unicodeValue = value;
		}
	}

	public int GetValue()
	{
		return _value;
	}

	public void SetValue(int asciiValue)
	{
		_value = asciiValue;
	}

	public void SetValue(int asciiValue, Color foreground)
	{
		_value = asciiValue;
		_foregroundColor = foreground;
	}

	public void SetValue(int asciiValue, Color foreground, Color background)
	{
		_value = asciiValue;
		_foregroundColor = foreground;
		_backgroundColor = background;
	}

	public Color GetForeground()
	{
		return _foregroundColor;
	}

	public Color GetBackground()
	{
		return _backgroundColor;
	}

	public void SetBackground(Color color)
	{
		_backgroundColor = color;
	}

	public void SetForeground(Color color)
	{
		_foregroundColor = color;
	}

	public void SetGridPosition(int x, int y)
	{
		gridPosX = x;
		gridPosY = y;
	}

	public void SetInteractionLayer(ICellInteractable interactableObject, int priority = 0)
	{
		if (priority == interactablePriority)
		{
			interactableObjects.Add(interactableObject);
		}
		else if (priority > interactablePriority)
		{
			interactableObjects.Clear();
			interactableObjects.Add(interactableObject);
			interactablePriority = priority;
		}
	}

	public ICellInteractable GetInteractionLayer()
	{
		AsciiMouse singleton = AsciiMouse.singleton;
		ICellInteractable cellInteractable = null;
		for (int i = 0; i < interactableObjects.Count; i++)
		{
			ICellInteractable cellInteractable2 = interactableObjects[i];
			if (cellInteractable2 == null)
			{
				Utils.LogError("Null entry appeared in list of interactableObjects");
			}
			else if (cellInteractable == null || (singleton.subCellIsCursorLeft && cellInteractable.GetCenterX() > gridPosX && cellInteractable2.GetCenterX() <= gridPosX) || (singleton.subCellIsCursorRight && cellInteractable.GetCenterX() < gridPosX && cellInteractable2.GetCenterX() >= gridPosX) || (singleton.subCellIsCursorTop && cellInteractable.GetCenterY() > gridPosY && cellInteractable2.GetCenterY() <= gridPosY) || (singleton.subCellIsCursorBottom && cellInteractable.GetCenterY() < gridPosY && cellInteractable2.GetCenterY() >= gridPosY))
			{
				cellInteractable = cellInteractable2;
			}
		}
		return cellInteractable;
	}

	public int GetInteractionPriority()
	{
		return interactablePriority;
	}

	public void ClearInteractionLayer()
	{
		interactableObjects.Clear();
		interactablePriority = int.MinValue;
	}

	public void SetUnicodeValue(char value)
	{
		_unicodeValue = value;
	}

	public char GetUnicodeValue()
	{
		return _unicodeValue;
	}

	public void Push()
	{
	}
}
