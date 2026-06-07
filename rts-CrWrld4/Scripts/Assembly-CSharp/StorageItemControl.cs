using System;
using UnityEngine;
using UnityEngine.UI;

public class StorageItemControl : MonoBehaviour
{
	public Text countText;

	public Text nameText;

	[NonSerialized]
	public FabPane fabPane;

	private int wareType;

	public void SetCount(int count, int wareType)
	{
	}

	public void OnDeleteOne()
	{
	}

	public void OnDeletaAll()
	{
	}
}
