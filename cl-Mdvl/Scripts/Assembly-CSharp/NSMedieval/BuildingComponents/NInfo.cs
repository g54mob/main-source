using System;

namespace NSMedieval.BuildingComponents
{
	[Flags]
	public enum NInfo : ulong
	{
		None = 0uL,
		NorthCorner = 2uL,
		SouthCorner = 4uL,
		WestCorner = 8uL,
		EastCorner = 0x10uL,
		NorthStraight = 0x20uL,
		SouthStraight = 0x40uL,
		WestStraight = 0x80uL,
		EastStraight = 0x100uL,
		NorthInnerCorner = 0x200uL,
		SouthInnerCorner = 0x400uL,
		WestInnerCorner = 0x800uL,
		EastInnerCorner = 0x1000uL,
		Angle0 = 0x2000uL,
		Angle90 = 0x4000uL,
		Angle180 = 0x8000uL,
		Angle270 = 0x10000uL,
		North = 0x20000uL,
		South = 0x40000uL,
		West = 0x80000uL,
		East = 0x100000uL,
		North0 = 0x200000uL,
		South0 = 0x400000uL,
		West0 = 0x800000uL,
		East0 = 0x1000000uL,
		North90 = 0x2000000uL,
		South90 = 0x4000000uL,
		West90 = 0x8000000uL,
		East90 = 0x10000000uL,
		North180 = 0x20000000uL,
		South180 = 0x40000000uL,
		East180 = 0x80000000uL,
		West180 = 0x100000000uL,
		North270 = 0x200000000uL,
		South270 = 0x400000000uL,
		West270 = 0x800000000uL,
		East270 = 0x1000000000uL,
		ShouldFlip = 0x2000000000uL,
		DontFlip = 0x4000000000uL,
		HalfRoof = 0x8000000000uL,
		WholeRoof = 0x10000000000uL
	}
}
