using System;

namespace NSMedieval.Enums
{
	[Flags]
	public enum BuildingProperty : byte
	{
		None = 0,
		Taken = 1,
		Delete = 2,
		Buildable = 4,
		NextToWall = 8,
		Built = 0x10,
		Door = 0x20,
		Window = 0x40
	}
}
