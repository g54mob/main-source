using System;

[Flags]
public enum ProjectFlags
{
	Success = 0,
	Finished = 1,
	Cancelled = 2,
	InValid = 4,
	NonInteractable = 8,
	OutOfBounds = 0x10,
	StuckOnLandmark = 0x20,
	BuildableRemoved = 0x40,
	BoatAbandoned = 0x80,
	Priority = 0x100,
	Exception = 0x2000,
	BugFix = 0x4000,
	DoNotTryGoToTown = 0x8000,
	InventoryMustBeEmpty = 0x10000
}
