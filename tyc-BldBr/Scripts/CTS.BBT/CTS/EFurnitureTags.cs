using System;

namespace CTS
{
	[Flags]
	public enum EFurnitureTags
	{
		None = 0,
		HighTable = 1,
		HighChair = 2,
		Pump = 4,
		BarItem = 8,
		Item = 0x10,
		NotUsed = 0x20,
		Shelve = 0x40,
		Bloodwork = 0x80,
		LowerChair = 0x100,
		LowerTable = 0x200,
		Decorative = 0x400,
		Restroom = 0x800,
		Fridge = 0x1000,
		WallPlacement = 0x2000,
		Rug = 0x4000,
		FunObject = 0x8000
	}
}
