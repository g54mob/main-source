using System;

namespace NSMedieval.Types
{
	[Flags]
	public enum OrderType
	{
		None = 0,
		Cancel = 1,
		CutAllVegetation = 2,
		Deconstructing = 4,
		Chopping = 8,
		Harvesting = 0x10,
		Hunting = 0x20,
		ReleaseAnimal = 0x40,
		UrgentHaul = 0x80,
		Digging = 0x100,
		Fishing = 0x200,
		AbortGoal = 0x400,
		Allow = 0x800,
		Draft = 0x1000,
		TrainAnimal = 0x2000,
		Forbid = 0x4000,
		Banish = 0x8000,
		ExitTrebuchet = 0x10000,
		Attack = 0x20000,
		UnlockDoor = 0x40000,
		LockDoor = 0x80000,
		AlwaysOpenDoor = 0x100000,
		CopyBuilding = 0x200000,
		ExpandZone = 0x400000,
		ShrinkZone = 0x800000,
		LockItem = 0x1000000,
		UnlockItem = 0x2000000,
		MoveBuilding = 0x4000000,
		UninstallBuilding = 0x8000000,
		InstallBuilding = 0x10000000,
		TameAnimal = 0x20000000,
		SlaughterAnimal = 0x40000000
	}
}
