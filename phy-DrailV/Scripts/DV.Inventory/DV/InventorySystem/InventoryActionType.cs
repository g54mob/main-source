using System;

namespace DV.InventorySystem
{
	[Flags]
	public enum InventoryActionType
	{
		None = 0,
		Add = 1,
		Drop = 2,
		Move = 4,
		Swap = 8,
		Purge = 0x10,
		Equip = 0x20,
		Unequip = 0x40,
		Lock = 0x80,
		Unlock = 0x100,
		Reserve = 0x200,
		Unreserve = 0x400,
		Destroy = 0x800,
		BeltVisible = 0x1000,
		BeltHidden = 0x2000,
		BeltDisabled = 0x4000,
		BeltEnabled = 0x8000
	}
}
