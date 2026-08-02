using System;
using UnityEngine;

[Serializable]
public struct InventorySlotsDataNetwork
{
	public string itemName;

	public int slotID;

	public int itemCountInSlot;

	public int maxCapacity;

	public int currentMagazineCount;

	public float currentDurability;

	public static InventorySlotsDataNetwork FromInventorySlot(InventorySlotsData inventorySlot)
	{
		string value = "";
		if (inventorySlot != null && inventorySlot.item != null)
		{
			value = inventorySlot.item.itemName;
			if (string.IsNullOrEmpty(value))
			{
				value = inventorySlot.item.name;
			}
		}
		return new InventorySlotsDataNetwork
		{
			itemName = value,
			slotID = (inventorySlot?.slotID ?? 0),
			itemCountInSlot = (inventorySlot?.itemCountInSlot ?? 0),
			maxCapacity = (inventorySlot?.maxCapacity ?? 32),
			currentMagazineCount = (inventorySlot?.currentMagazineCount ?? 0),
			currentDurability = (inventorySlot?.currentDurability ?? 0f)
		};
	}

	public InventorySlotsData ToInventorySlot()
	{
		CollectableItemData collectableItemData = null;
		if (!string.IsNullOrEmpty(itemName))
		{
			try
			{
				CollectableItemData[] array = Resources.LoadAll<CollectableItemData>("CollectableItemsData");
				if (array == null || array.Length == 0)
				{
					array = Resources.LoadAll<CollectableItemData>("");
				}
				if (array != null && array.Length != 0)
				{
					CollectableItemData[] array2 = array;
					foreach (CollectableItemData collectableItemData2 in array2)
					{
						if (!(collectableItemData2 == null))
						{
							string name = collectableItemData2.itemName;
							if (string.IsNullOrEmpty(name))
							{
								name = collectableItemData2.name;
							}
							if (name == itemName)
							{
								collectableItemData = collectableItemData2;
								break;
							}
						}
					}
					if (collectableItemData == null)
					{
						Debug.LogWarning("Item bulunamadı: '" + itemName + "'");
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogError("Item yükleme hatası (" + itemName + "): " + ex.Message);
			}
		}
		return new InventorySlotsData
		{
			item = collectableItemData,
			slotID = slotID,
			itemCountInSlot = itemCountInSlot,
			maxCapacity = maxCapacity,
			currentMagazineCount = currentMagazineCount,
			currentDurability = currentDurability
		};
	}

	public void Clear()
	{
		itemName = "";
		itemCountInSlot = 0;
		currentDurability = 0f;
	}
}
