using System;

namespace NSMedieval.Enums
{
	[Flags]
	public enum BuildingType
	{
		Default = 1,
		Wall = 2,
		Floor = 4,
		Voxel = 8,
		Beam = 0x10,
		Roof = 0x20,
		Ground = 0x40,
		Stairs = 0x80,
		Nothing = 0x100,
		Window = 0x200,
		Door = 0x400,
		ProductionBuilding = 0x800,
		Chair = 0x1000,
		Table = 0x2000,
		Bed = 0x4000,
		Decoration = 0x8000,
		Merlon = 0x10000,
		Shrine = 0x20000,
		Trap = 0x40000,
		Grave = 0x80000,
		Fence = 0x100000,
		BarnDoor = 0x200000,
		FenceGate = 0x400000,
		Rug = 0x800000,
		Ladder = 0x1000000,
		PenMarker = 0x2000000,
		OilBlob = 0x4000000,
		Well = 0x8000000,
		SiegeWeapon = 0x10000000,
		AllBuildings = -2,
		AnyDoor = 0x600400,
		DefensiveStructure = 0x50000,
		PassThroughDamageable = 0x101000,
		SocketableBlocker = 0x12002A2
	}
}
