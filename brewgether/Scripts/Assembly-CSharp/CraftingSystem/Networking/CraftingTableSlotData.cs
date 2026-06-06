using System;
using InventorySystem;

namespace CraftingSystem.Networking
{
	[Serializable]
	public struct CraftingTableSlotData
	{
		public string itemId;

		public string itemName;

		public int quantity;

		public int slotIndex;

		public static CraftingTableSlotData FromSlot(InventorySlot slot, int index)
		{
			return default(CraftingTableSlotData);
		}
	}
}
