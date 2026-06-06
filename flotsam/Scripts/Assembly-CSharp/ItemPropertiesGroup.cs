using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemPropertiesGroup
{
	[SerializeField]
	private ItemProperties[] _properties;

	[SerializeField]
	[Tooltip("Do you want to customize the Item Properties used in the UI for this group? (by default the first entry in the properties list is used)")]
	private bool _customUIProperties;

	[SerializeField]
	[ConditionalHide("_customUIProperties")]
	private ItemProperties _uiProperties;

	public ItemProperties UIProperties
	{
		get
		{
			if (_uiProperties == null && _properties.Length != 0)
			{
				return _properties[0];
			}
			return _uiProperties;
		}
	}

	public bool Enabled { get; set; } = true;

	public List<Item> Items { get; private set; } = new List<Item>();

	public void ClearItems()
	{
		Items.Clear();
	}

	public bool TryAddItem(Item item)
	{
		if (Contains(item.Properties))
		{
			Items.Add(item);
			return true;
		}
		return false;
	}

	public bool Contains(ItemProperties properties)
	{
		ItemProperties[] properties2 = _properties;
		for (int i = 0; i < properties2.Length; i++)
		{
			if (properties2[i] == properties)
			{
				return true;
			}
		}
		return false;
	}
}
