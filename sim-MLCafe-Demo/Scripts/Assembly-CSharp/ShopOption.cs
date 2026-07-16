using System;
using UnityEngine;

[Serializable]
public class ShopOption
{
	public int itemId;

	public bool notForBuy;

	public bool locked;

	public int unlockLevel;

	public int buyPrice;

	public string displayName
	{
		get
		{
			string text = "";
			if (InventorySystem.GetInstance() != null)
			{
				return InventorySystem.GetItemLibrary().itemInfos[itemId].GetLocalizedName();
			}
			return Resources.Load<ItemLibrary>("Libraries/Item Library").itemInfos[itemId].GetLocalizedName();
		}
	}

	public ShopOption(int itemId)
	{
		this.itemId = itemId;
	}

	public AnomalyTag GetAnomalyTag()
	{
		GameObject prefab = InventorySystem.GetItemLibrary().itemInfos[itemId].prefab;
		if (prefab != null && prefab.GetComponent<ItemComponent>() != null)
		{
			return InventorySystem.GetItemLibrary().itemInfos[itemId].prefab.GetComponent<ItemComponent>().item.tag;
		}
		return null;
	}

	public Sprite LoadIcon()
	{
		return InventorySystem.GetItemLibrary().itemInfos[itemId].icon;
	}

	public ItemInfo.ItemType GetItemType()
	{
		return InventorySystem.GetItemLibrary().itemInfos[itemId].itemType;
	}
}
