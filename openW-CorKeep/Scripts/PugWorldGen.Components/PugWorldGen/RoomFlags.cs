using System;

namespace PugWorldGen
{
	[Flags]
	public enum RoomFlags
	{
		None = 0,
		Main = 1,
		CustomScene = 2,
		Entrance = 4,
		End = 8,
		Connecting = 0x10,
		Fill = 0x20,
		Custom06 = 0x40,
		Custom07 = 0x80,
		Custom08 = 0x100,
		Custom09 = 0x200,
		Custom10 = 0x400,
		Custom11 = 0x800,
		Custom12 = 0x1000,
		Custom13 = 0x2000,
		Custom14 = 0x4000,
		Custom15 = 0x8000
	}
}
