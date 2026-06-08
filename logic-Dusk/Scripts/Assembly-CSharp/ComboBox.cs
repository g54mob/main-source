using System;
using UnityEngine;

public class ComboBox
{
	private static bool forceToUnShow;

	private static int useControlID = -1;

	private bool isClickedComboButton;

	private int selectedItemIndex;

	private Rect rect;

	private GUIContent buttonContent;

	private GUIContent[] listContent;

	private string buttonStyle;

	private string boxStyle;

	private GUIStyle listStyle;

	private Vector2 scrollPosition = Vector2.zero;

	private int maxDropHeight = 250;

	public int SelectedItemIndex
	{
		get
		{
			return selectedItemIndex;
		}
		set
		{
			if (value != selectedItemIndex && listContent.Length > value && value >= 0)
			{
				selectedItemIndex = value;
				buttonContent = listContent[selectedItemIndex];
			}
		}
	}

	public string SelectedItemText
	{
		get
		{
			if (listContent != null && selectedItemIndex >= 0 && selectedItemIndex < listContent.Length)
			{
				return listContent[selectedItemIndex].text;
			}
			return string.Empty;
		}
	}

	public ComboBox(Rect rect, GUIContent buttonContent, GUIContent[] listContent, GUIStyle listStyle, int dropHeight)
	{
		this.rect = rect;
		this.buttonContent = buttonContent;
		this.listContent = listContent;
		buttonStyle = "button";
		boxStyle = "box";
		this.listStyle = listStyle;
		maxDropHeight = dropHeight;
	}

	public ComboBox(Rect rect, GUIContent buttonContent, GUIContent[] listContent, string buttonStyle, string boxStyle, GUIStyle listStyle, int dropHeight)
	{
		this.rect = rect;
		this.buttonContent = buttonContent;
		this.listContent = listContent;
		this.buttonStyle = buttonStyle;
		this.boxStyle = boxStyle;
		this.listStyle = listStyle;
		maxDropHeight = dropHeight;
		for (int i = 0; i < listContent.Length; i++)
		{
			if (buttonContent == listContent[i])
			{
				selectedItemIndex = i;
				break;
			}
		}
	}

	public int Show()
	{
		if (forceToUnShow)
		{
			forceToUnShow = false;
			isClickedComboButton = false;
		}
		bool flag = false;
		int controlID = GUIUtility.GetControlID(FocusType.Passive);
		EventType typeForControl = Event.current.GetTypeForControl(controlID);
		if (typeForControl == EventType.MouseUp && isClickedComboButton)
		{
			flag = true;
		}
		if (GUI.Button(this.rect, buttonContent, buttonStyle))
		{
			if (useControlID == -1)
			{
				useControlID = controlID;
				isClickedComboButton = false;
			}
			if (useControlID != controlID)
			{
				forceToUnShow = true;
				useControlID = controlID;
			}
			isClickedComboButton = true;
		}
		if (isClickedComboButton)
		{
			Rect rect = new Rect(this.rect.x, this.rect.y + listStyle.CalcHeight(listContent[0], 1f), this.rect.width, listStyle.CalcHeight(listContent[0], 1f) * (float)listContent.Length);
			Rect position = new Rect(rect.x, rect.y, rect.width + 15f, Math.Min(maxDropHeight, rect.height));
			scrollPosition = GUI.BeginScrollView(position, scrollPosition, rect);
			GUI.Box(rect, string.Empty, boxStyle);
			int num = GUI.SelectionGrid(rect, selectedItemIndex, listContent, 1, listStyle);
			GUI.EndScrollView();
			if (num != selectedItemIndex)
			{
				selectedItemIndex = num;
				buttonContent = listContent[selectedItemIndex];
			}
		}
		if (flag)
		{
			isClickedComboButton = false;
		}
		return selectedItemIndex;
	}
}
