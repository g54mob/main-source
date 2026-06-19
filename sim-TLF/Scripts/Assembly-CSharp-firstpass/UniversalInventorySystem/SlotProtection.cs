using System;

namespace UniversalInventorySystem
{
	[Serializable]
	[Flags]
	public enum SlotProtection : short
	{
		Locked = 0,
		Add = 1,
		Remove = 2,
		Swap = 4,
		Use = 8
	}
}
