using System;
using UnityEngine;
using UnityEngine.UI;

public class CModObjRow : MonoBehaviour
{
	[NonSerialized]
	public CMod.CModObj cModObj;

	public Text nameText;

	public GameObject meshImage;

	public Text indentText;

	public Button leftButton;

	public Button rightButton;

	public Button upButton;

	public Button downButton;

	public Button deleteButton;

	public void OnDelete()
	{
	}

	public void RefreshButtons()
	{
	}

	public void OnMoveUp()
	{
	}

	public void OnMoveDown()
	{
	}

	public void OnMoveRight()
	{
	}

	public void OnMoveLeft()
	{
	}

	public void OnEdit()
	{
	}
}
