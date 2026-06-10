using System;

namespace NSMedieval.Types
{
	[Flags]
	public enum GridDataType
	{
		None = 0,
		BuildingBlueprint = 1,
		BuildingUnfinished = 2,
		BuildingFinished = 4,
		DigMarkerResource = 8,
		DigMarkerResourceToMine = 0x10,
		ResourcePile = 0x20,
		Stockpile = 0x40,
		Slope = 0x80,
		PlantMapResource = 0x100,
		OthersBlueprint = 0x200,
		OthersUnfinished = 0x400,
		Furniture = 0x800,
		ProductionBuilding = 0x1000,
		Stairs = 0x2000,
		Cropfield = 0x4000,
		BeamBlueprint = 0x8000,
		BeamUnfinished = 0x10000,
		BeamFinished = 0x20000,
		Roof = 0x40000,
		SocketableItem = 0x80000,
		SocketableBlueprint = 0x100000,
		SocketableUnfinished = 0x200000,
		Trap = 0x400000,
		Grave = 0x800000,
		FurnitureGate = 0x1000000,
		RugBlueprint = 0x2000000,
		RugFoundation = 0x4000000,
		RugFinished = 0x8000000,
		FishMapResource = 0x10000000,
		ForbiddenByBuilding = 0x20000000,
		PathfindingPoint = 0x40000000,
		Drawbridge = int.MinValue,
		All = -1,
		SlopeOrStairs = 0x2080,
		AnyBuildPhase = 7
	}
}
