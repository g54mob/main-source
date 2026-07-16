using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopOptions Library", menuName = "ShopOptions Library")]
public class ShopOptionsLibrary : ScriptableObject
{
	public List<ShopOption> shopOptions = new List<ShopOption>();

	public string loadLibrary;

	public Item[] GetItemList()
	{
		List<Item> list = new List<Item>();
		for (int i = 0; i < shopOptions.Count; i++)
		{
			Item item = Item.Create(shopOptions[i].itemId, 1, shopOptions[i].GetAnomalyTag());
			list.Add(item);
		}
		return list.ToArray();
	}

	[ContextMenu("Reload")]
	public void LoadAllItemsOfType()
	{
		ItemLibrary itemLibrary = Resources.Load<ItemLibrary>("Libraries/Item Library");
		Debug.Log("Loaded: " + itemLibrary.name);
		if (itemLibrary == null)
		{
			return;
		}
		for (int i = 0; i < itemLibrary.itemInfos.Count; i++)
		{
			ItemInfo itemInfo = itemLibrary.itemInfos[i];
			if (i >= shopOptions.Count - 1)
			{
				ShopOption item = new ShopOption(i);
				shopOptions.Add(item);
			}
			else if (shopOptions[i].itemId != i || shopOptions[i].GetAnomalyTag() != itemInfo.dataLayer_2)
			{
				shopOptions[i].itemId = i;
			}
		}
	}

	public List<ShopOption> GetOptionsOfType(ItemInfo.ItemType type)
	{
		List<ShopOption> list = new List<ShopOption>();
		if (InventorySystem.GetItemLibrary() == null)
		{
			return list;
		}
		for (int i = 0; i < shopOptions.Count; i++)
		{
			ShopOption shopOption = shopOptions[i];
			if (shopOption.GetItemType() == type && !shopOption.notForBuy)
			{
				ShopOption shopOption2 = new ShopOption(i);
				shopOption2.buyPrice = shopOption.buyPrice;
				shopOption2.locked = shopOption.locked;
				shopOption2.unlockLevel = shopOption.unlockLevel;
				list.Add(shopOption2);
			}
		}
		return list;
	}
}
