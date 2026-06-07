using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryItem
{
	[Serializable]
	public class AttributeWithType
	{
		public string Value;

		public string Type;

		public AttributeWithType(string value, string type)
		{
		}
	}

	[Serializable]
	private class InventoryItemListWrapper
	{
		public List<SerializedInventoryItem> items;
	}

	[Serializable]
	private class SerializedInventoryItem
	{
		public string nameItem;

		public string desItem;

		public string uniqueID;

		public AttributeContainer attributes;
	}

	public string nameItem;

	public string desItem;

	public Sprite icon;

	public Color backgroundColor;

	[Header("Item Data")]
	public string uniqueID;

	public AttributeContainer attributes;

	public InventoryItem(string name, Sprite icon)
	{
	}

	public void SetItemData(InventoryItem item)
	{
	}

	public string GenerateUniqueID()
	{
		return null;
	}

	public static string SaveToString(InventoryItem[] inventoryItems)
	{
		return null;
	}

	public static InventoryItem[] LoadFromString(string json)
	{
		return null;
	}

	private static AttributeContainer SerializeAttributes(AttributeContainer attributes)
	{
		return null;
	}

	private static AttributeContainer DeserializeAttributes(AttributeContainer attributes)
	{
		return null;
	}
}
