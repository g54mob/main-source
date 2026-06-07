using System;
using TMPro;
using UnityEngine;

public class ADAMessageRow : MonoBehaviour
{
	public GameObject selectedBackground;

	public TMP_Text text;

	[NonSerialized]
	public ADAMessageEditor messageEditor;

	private string _key;

	private bool _selected;

	public string key
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

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

	public void OnClick()
	{
	}

	public void OnDelete()
	{
	}

	public void OnEdit()
	{
	}
}
