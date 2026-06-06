using System;
using PajamaLlama.Debugs;

[Serializable]
public class InventorySlotPersistentData
{
	public int ItemPropertiesIndex;

	public int Count;

	public InventorySlotPersistentData(InventorySlot inventorySlot)
	{
		if (inventorySlot.ItemProperties == null || inventorySlot.Count == 0)
		{
			ItemPropertiesIndex = -1;
			Count = 0;
		}
		else
		{
			ItemPropertiesIndex = GameManager.PersistenceManager.ReturnPropertiesIndex(inventorySlot.ItemProperties);
			Count = inventorySlot.Count;
		}
	}

	public void Restore(InventorySlot inventorySlot)
	{
		if (ItemPropertiesIndex == -1)
		{
			return;
		}
		if (!GameManager.PersistenceManager.TryReturnPropertiesReference<ItemProperties>(ItemPropertiesIndex, out var reference))
		{
			Debugger.Warning("ItemPropertiesIndex is out of bounds. Save game mismatch!");
			return;
		}
		for (int i = 0; i < Count; i++)
		{
			if (!inventorySlot.AddItem(new Item(reference)))
			{
				Debugger.Warning("Item could not be added to InventorySlot!");
			}
		}
	}
}
