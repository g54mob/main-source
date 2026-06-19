using System;

namespace UniversalInventorySystem
{
	[Serializable]
	[Flags]
	public enum InventoryProtection
	{
		Locked = 0,
		InventoryToInventory = 1,
		SlotToSlot = 2,
		Add = 4,
		Remove = 8,
		Use = 0x10,
		Drop = 0x20
	}
}
