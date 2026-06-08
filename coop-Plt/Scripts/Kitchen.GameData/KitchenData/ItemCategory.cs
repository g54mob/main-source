using System;

namespace KitchenData
{
	[Flags]
	public enum ItemCategory
	{
		Generic = 0,
		Crates = 1,
		Documents = 2,
		MenuChoice = 4,
		LayoutChoice = 8,
		ProviderOnly = 0x10,
		Plant = 0x20,
		Contract = 0x40,
		NonLoadoutCrate = 0x80
	}
}
