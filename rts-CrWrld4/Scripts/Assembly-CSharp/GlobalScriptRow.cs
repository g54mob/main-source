using System;
using UnityEngine;
using UnityEngine.UI;

public class GlobalScriptRow : MonoBehaviour
{
	public Color color;

	public Color overColor;

	public Color selectedColor;

	public Text nameText;

	public Image background;

	[NonSerialized]
	public CPack.GlobalScript globalScript;

	[NonSerialized]
	public bool pre;

	private bool _selected;

	public bool selected
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public void OnDelete()
	{
	}

	public void OnMoveUp()
	{
	}

	public void OnMoveDown()
	{
	}

	public void OnPointerOver()
	{
	}

	public void OnPointerOut()
	{
	}

	public void OnPointerDown()
	{
	}
}
