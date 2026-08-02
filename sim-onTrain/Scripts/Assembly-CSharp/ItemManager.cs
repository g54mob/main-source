using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
	public List<CollectableItemData> items = new List<CollectableItemData>();

	public List<WaterBottleData> waterBottleDatas = new List<WaterBottleData>();

	private void Start()
	{
		StartCoroutine(LoadItemsFromDataManager());
	}

	private IEnumerator LoadItemsFromDataManager()
	{
		yield return new WaitUntil(() => Singleton<DataManager>.Instance != null && Singleton<DataManager>.Instance.collectableDatas.Count > 0);
		items = new List<CollectableItemData>(Singleton<DataManager>.Instance.collectableDatas);
	}

	public CollectableItemData GetItemFromName(string name)
	{
		return items.Find((CollectableItemData x) => x.name == name);
	}

	public WaterBottleData GetWaterBottleData(CollectableItemData item)
	{
		if (item == null || waterBottleDatas == null)
		{
			return null;
		}
		foreach (WaterBottleData waterBottleData in waterBottleDatas)
		{
			if (waterBottleData.emptyBottle == item || waterBottleData.dirtyWaterBottle == item || waterBottleData.cleanWaterBottle == item)
			{
				return waterBottleData;
			}
		}
		return null;
	}

	public bool TransformBottleToEmpty(InventoryItem inventoryItem, CollectableItemData currentItem)
	{
		if (inventoryItem == null || currentItem == null)
		{
			return false;
		}
		WaterBottleData waterBottleData = GetWaterBottleData(currentItem);
		if (waterBottleData == null || waterBottleData.emptyBottle == null)
		{
			return false;
		}
		if (currentItem != waterBottleData.dirtyWaterBottle && currentItem != waterBottleData.cleanWaterBottle)
		{
			return false;
		}
		inventoryItem.inventoryData.item = waterBottleData.emptyBottle;
		inventoryItem.inventoryData.currentDurability = 0f;
		inventoryItem.UpdateInventoryData(inventoryItem.inventoryData);
		NotifyInventorySaver(inventoryItem);
		Debug.Log("[ItemManager] Bottle transformed to EMPTY: " + waterBottleData.emptyBottle.itemName);
		return true;
	}

	public bool TransformBottleToDirty(InventoryItem inventoryItem, CollectableItemData currentItem)
	{
		if (inventoryItem == null || currentItem == null)
		{
			return false;
		}
		WaterBottleData waterBottleData = GetWaterBottleData(currentItem);
		if (waterBottleData == null || waterBottleData.dirtyWaterBottle == null)
		{
			return false;
		}
		if (currentItem == waterBottleData.dirtyWaterBottle)
		{
			return false;
		}
		inventoryItem.inventoryData.item = waterBottleData.dirtyWaterBottle;
		inventoryItem.UpdateInventoryData(inventoryItem.inventoryData);
		NotifyInventorySaver(inventoryItem);
		Debug.Log("[ItemManager] Bottle transformed to DIRTY: " + waterBottleData.dirtyWaterBottle.itemName);
		return true;
	}

	public bool TransformBottleToClean(InventoryItem inventoryItem, CollectableItemData currentItem)
	{
		if (inventoryItem == null || currentItem == null)
		{
			return false;
		}
		WaterBottleData waterBottleData = GetWaterBottleData(currentItem);
		if (waterBottleData == null || waterBottleData.cleanWaterBottle == null)
		{
			return false;
		}
		if (currentItem == waterBottleData.cleanWaterBottle)
		{
			return false;
		}
		inventoryItem.inventoryData.item = waterBottleData.cleanWaterBottle;
		inventoryItem.UpdateInventoryData(inventoryItem.inventoryData);
		NotifyInventorySaver(inventoryItem);
		Debug.Log("[ItemManager] Bottle transformed to CLEAN: " + waterBottleData.cleanWaterBottle.itemName);
		return true;
	}

	public void CheckAndTransformToEmptyBottle(InventoryItem inventoryItem, CollectableItemData currentItem)
	{
		if (!(inventoryItem == null) && !(currentItem == null) && !(inventoryItem.GetCurrentDurability() > 0f))
		{
			TransformBottleToEmpty(inventoryItem, currentItem);
		}
	}

	public float ConsumeWaterFromBottle(InventoryItem inventoryItem, float amount)
	{
		if (inventoryItem == null || inventoryItem.inventoryData == null)
		{
			return 0f;
		}
		if (!inventoryItem.HasDurability())
		{
			return 0f;
		}
		float currentDurability = inventoryItem.GetCurrentDurability();
		if (currentDurability <= 0f)
		{
			return 0f;
		}
		float num = Mathf.Min(currentDurability, amount);
		CollectableItemData collectableItemData = inventoryItem.collectableItemData;
		inventoryItem.inventoryData.currentDurability = currentDurability - num;
		float maxDurabilityCapacity = inventoryItem.collectableItemData.maxDurabilityCapacity;
		if (maxDurabilityCapacity > 0f && inventoryItem.inventoryData.currentDurability / maxDurabilityCapacity < 0.01f)
		{
			inventoryItem.inventoryData.currentDurability = 0f;
		}
		if (inventoryItem.inventoryData.currentDurability <= 0f)
		{
			TransformBottleToEmpty(inventoryItem, collectableItemData);
		}
		else
		{
			inventoryItem.UpdateInventoryData(inventoryItem.inventoryData);
			NotifyInventorySaver(inventoryItem);
		}
		return num;
	}

	public float FillBottleWithCleanWater(InventoryItem inventoryItem, float amount)
	{
		if (inventoryItem == null || inventoryItem.inventoryData == null)
		{
			return 0f;
		}
		if (!inventoryItem.HasDurability())
		{
			return 0f;
		}
		float currentDurability = inventoryItem.GetCurrentDurability();
		float b = inventoryItem.GetMaxDurability() - currentDurability;
		float num = Mathf.Min(amount, b);
		if (num <= 0f)
		{
			return 0f;
		}
		CollectableItemData collectableItemData = inventoryItem.collectableItemData;
		inventoryItem.IncreaseDurability(num);
		WaterBottleData waterBottleData = GetWaterBottleData(collectableItemData);
		if (waterBottleData != null && (collectableItemData == waterBottleData.emptyBottle || collectableItemData == waterBottleData.dirtyWaterBottle))
		{
			TransformBottleToClean(inventoryItem, collectableItemData);
		}
		return num;
	}

	private void NotifyInventorySaver(InventoryItem inventoryItem)
	{
		if (!(InventorySaver.Instance == null) && inventoryItem.connectedSlot != null)
		{
			PlayerInventory componentInParent = inventoryItem.connectedSlot.GetComponentInParent<PlayerInventory>();
			if (componentInParent != null)
			{
				componentInParent.OnCollectableCollected?.Invoke(inventoryItem.collectableItemData, 0, inventoryItem.GetCurrentDurability());
				Debug.Log("[ItemManager] InventorySaver notified for item: " + inventoryItem.collectableItemData?.itemName);
			}
		}
	}
}
