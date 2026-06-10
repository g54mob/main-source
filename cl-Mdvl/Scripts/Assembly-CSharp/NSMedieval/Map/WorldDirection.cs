using System;

namespace NSMedieval.Map
{
	[Flags]
	public enum WorldDirection
	{
		None = 0,
		N = 1,
		NE = 2,
		E = 4,
		SE = 8,
		S = 0x10,
		SW = 0x20,
		W = 0x40,
		NW = 0x80,
		C = 0x100,
		AllHorizontal = 0x1FF,
		UN = 0x200,
		UNE = 0x400,
		UE = 0x800,
		USE = 0x1000,
		US = 0x2000,
		USW = 0x4000,
		UW = 0x8000,
		UNW = 0x10000,
		UC = 0x20000,
		AllUpper = 0x3FE00,
		DN = 0x40000,
		DNE = 0x80000,
		DE = 0x100000,
		DSE = 0x200000,
		DS = 0x400000,
		DSW = 0x800000,
		DW = 0x1000000,
		DNW = 0x2000000,
		DC = 0x4000000,
		AllLower = 0x7FC0000
	}
}
