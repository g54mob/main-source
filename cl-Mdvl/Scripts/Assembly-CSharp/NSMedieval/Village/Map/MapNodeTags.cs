using System;

namespace NSMedieval.Village.Map
{
	[Flags]
	public enum MapNodeTags : uint
	{
		None = 0u,
		DoorWorkerWalkable = 1u,
		DoorCompletelyLocked = 2u,
		Enemy = 4u,
		Worker = 8u,
		Fence = 0x10u,
		BarnDoor = 0x20u,
		DoorAlwaysOpen = 0x40u,
		Wall = 0x80u,
		Floor = 0x100u,
		PenMarker = 0x200u,
		Ladder = 0x400u,
		FloorPassthrough = 0x800u,
		IdleTargetForbidden = 0x1000u,
		OpenWindow = 0x2000u,
		ClosedFenceGate = 0x4000u,
		FlowThrough = 0x8000u,
		WaterLevelLow = 0x10000u,
		WaterLevelMedium = 0x20000u,
		WaterLevelHigh = 0x40000u,
		WaterDepthHigh = 0x80000u,
		VerticalFireBlocker = 0x100000u,
		Beam = 0x200000u,
		MaxFlame = 0x400000u,
		Fire = 0x800000u,
		EnemyDoorClosed = 0x1000000u,
		DrawbridgePlatform = 0x2000000u
	}
}
