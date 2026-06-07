using System;

namespace DV.ThingTypes
{
	[Flags]
	public enum StorageType
	{
		None = 0,
		Inventory = 1,
		LostAndFound = 2,
		World = 4,
		InstalledGadgets = 8,
		ItemContainers = 0x10
	}
}
