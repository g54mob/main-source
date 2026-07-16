using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Library", menuName = "Libraries/Item Library", order = 1)]
public class ItemLibrary : ScriptableObject
{
	public List<ItemInfo> itemInfos = new List<ItemInfo>();

	private List<string> names = new List<string>();

	public int GetItemByName(string name)
	{
		return itemInfos.FindIndex((ItemInfo x) => x.name.ToLower() == name.ToLower());
	}

	public List<string> GetItemNames()
	{
		names.Clear();
		if (names.Count != itemInfos.Count)
		{
			foreach (ItemInfo itemInfo in itemInfos)
			{
				names.Add(itemInfo.name);
			}
		}
		return names;
	}

	public List<string> GetItemNamesByType(ItemInfo.ItemType type)
	{
		List<string> list = new List<string>();
		if (list.Count != itemInfos.Count)
		{
			list.Clear();
			foreach (ItemInfo itemInfo in itemInfos)
			{
				if (itemInfo.itemType == type)
				{
					list.Add(itemInfo.name);
				}
			}
		}
		return list;
	}

	public Color GetItemTypeColor(ItemInfo.ItemType type, Color defaultCol)
	{
		return type switch
		{
			ItemInfo.ItemType.Tool => new Color(0.75f, 0.386f, 0.18f), 
			ItemInfo.ItemType.Ingredient => new Color(0.562f, 0.219f, 0.719f), 
			ItemInfo.ItemType.Workstation => new Color(0.719f, 0.019f, 0.341f), 
			ItemInfo.ItemType.Dish => new Color(0.313f, 0.684f, 0.539f), 
			ItemInfo.ItemType.Furniture => new Color(0.7f, 0.5f, 0.8f), 
			ItemInfo.ItemType.Decoration => new Color(0.8f, 0.8f, 0.8f), 
			ItemInfo.ItemType.Other => new Color(0.769f, 0.231f, 0.592f), 
			_ => defaultCol, 
		};
	}
}
