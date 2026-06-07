using System;
using UnityEngine;
using UnityEngine.UI;

public class CModScriptRow : MonoBehaviour
{
	public Text nameText;

	public Button deleteButton;

	[NonSerialized]
	public int index;

	public void OnDelete()
	{
	}

	public void OnEdit()
	{
	}
}
