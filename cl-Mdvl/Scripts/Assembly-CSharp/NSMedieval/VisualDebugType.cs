using System;

namespace NSMedieval
{
	[Flags]
	public enum VisualDebugType
	{
		None = 0,
		Reachability = 1,
		Proximity = 2,
		RelocatePileGoal = 4,
		MapRegions = 8,
		GridNode = 0x10,
		Pathfinding = 0x20,
		NodeConnections = 0x40,
		AnimalAttackPriorities = 0x80,
		RoomDetection = 0x100
	}
}
