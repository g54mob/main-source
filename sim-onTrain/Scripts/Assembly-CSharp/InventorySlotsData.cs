using System;

[Serializable]
public class InventorySlotsData
{
	public int slotID;

	public CollectableItemData item;

	public int itemCountInSlot;

	public int currentMagazineCount;

	public float currentDurability;

	public int maxCapacity;

	public void Clear()
	{
		item = null;
		itemCountInSlot = 0;
		currentMagazineCount = 0;
		currentDurability = 0f;
	}

	public float GetDurabilityRatio()
	{
		if (item == null || !item.hasDurability || item.maxDurabilityCapacity <= 0f)
		{
			return 0f;
		}
		return currentDurability / item.maxDurabilityCapacity;
	}

	public void SetDurabilityToMax()
	{
		if (item != null && item.hasDurability)
		{
			currentDurability = item.maxDurabilityCapacity;
		}
	}

	public void InitializeDurability()
	{
		if (item != null && item.hasDurability && currentDurability <= 0f)
		{
			currentDurability = item.maxDurabilityCapacity;
		}
	}
}
