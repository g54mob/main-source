using System;
using UnityEngine;
using UnityEngine.UI;

public class CModUnitManagerScriptRow : MonoBehaviour
{
	public Text nameText;

	public Button deleteButton;

	[NonSerialized]
	public EditUnitPane editUnitPane;

	[NonSerialized]
	public CModUnitManager cmum;

	[NonSerialized]
	public int index;

	[NonSerialized]
	public RplCore core;

	public void OnDelete()
	{
	}

	public void OnReset()
	{
	}

	public void OnEdit()
	{
	}
}
