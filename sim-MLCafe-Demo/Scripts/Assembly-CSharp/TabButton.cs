using System;
using UnityEngine;

[Serializable]
public class TabButton
{
	public ButtonField buttonField;

	public GameObject selectedButtonView;

	public void Select()
	{
		buttonField.Select();
	}

	public void Deselect()
	{
		buttonField.Deselect();
	}
}
