using System.Collections.Generic;
using UnityEngine;

public class ComboBoxPropertyModel : OverridablePropertyModel
{
	public class Item
	{
		public string ItemKey { get; set; }

		public string ItemLabel { get; set; }

		public Sprite ItemIcon { get; set; }
	}

	private readonly List<Item> items;

	public bool ShouldUseIndexAsItemKey { get; set; }

	public bool IsUsingIcons { get; set; }

	public ComboBoxPropertyModel(string key, string value, bool isIndexAsKey = false)
		: base(key, value)
	{
		items = new List<Item>();
		ShouldUseIndexAsItemKey = isIndexAsKey;
		IsUsingIcons = false;
	}

	public void AddItem(string itemLabel)
	{
		items.Add(new Item
		{
			ItemKey = null,
			ItemLabel = itemLabel
		});
	}

	public void AddItem(string itemKey, string itemLabel)
	{
		items.Add(new Item
		{
			ItemKey = itemKey,
			ItemLabel = itemLabel
		});
	}

	public void AddItem(string itemKey, string itemLabel, Sprite itemIcon)
	{
		items.Add(new Item
		{
			ItemKey = itemKey,
			ItemLabel = itemLabel,
			ItemIcon = itemIcon
		});
	}

	public Item GetItem(int index)
	{
		if (index < 0 || index >= items.Count)
		{
			return null;
		}
		return items[index];
	}

	public Item[] GetAllItems()
	{
		return items.ToArray();
	}

	public int GetItemIndex(string itemKey)
	{
		for (int i = 0; i < items.Count; i++)
		{
			if (items[i].ItemKey == itemKey)
			{
				return i;
			}
		}
		return -1;
	}

	public void Clear()
	{
		items.Clear();
	}
}
