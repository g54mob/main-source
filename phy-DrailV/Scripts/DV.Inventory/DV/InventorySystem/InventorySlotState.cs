using UnityEngine;

namespace DV.InventorySystem
{
	public readonly struct InventorySlotState
	{
		public static readonly InventorySlotState Empty = new InventorySlotState(-1, null, InventoryItemState.None, isLocked: false, isReserved: false, -1);

		public readonly int slotIndex;

		public readonly GameObject item;

		public readonly InventoryItemState itemState;

		public readonly bool isLocked;

		public readonly bool isReserved;

		public readonly int equipSlot;

		public InventorySlotState(int slotIndex, GameObject item, InventoryItemState itemState, bool isLocked, bool isReserved, int equipSlot)
		{
			this.slotIndex = slotIndex;
			this.item = item;
			this.itemState = itemState;
			this.isLocked = isLocked;
			this.isReserved = isReserved;
			this.equipSlot = equipSlot;
		}
	}
}
