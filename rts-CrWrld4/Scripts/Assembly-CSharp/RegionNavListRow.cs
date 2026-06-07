using System;
using TMPro;
using UnityEngine;

public class RegionNavListRow : MonoBehaviour
{
	public TextMeshProUGUI mapNameText;

	[NonSerialized]
	public RegionNav regionNav;

	[NonSerialized]
	public RegionNav.MapEntry mapEntry;

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

	public void SetMapEntry(RegionNav.MapEntry mapEntry)
	{
	}

	public void OnClick()
	{
	}
}
