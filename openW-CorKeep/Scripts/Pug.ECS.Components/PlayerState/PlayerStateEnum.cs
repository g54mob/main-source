using System;

namespace PlayerState
{
	[Flags]
	public enum PlayerStateEnum
	{
		Null = 0,
		SpawningFromCore = 1,
		Inactive = 2,
		Walk = 4,
		Release = 8,
		Anticipation = 0x10,
		NoClip = 0x20,
		Death = 0x40,
		PlaceObject = 0x80,
		Dig = 0x100,
		Flatten = 0x200,
		RefillWater = 0x400,
		PlaceWater = 0x800,
		Sleep = 0x1000,
		Casting = 0x2000,
		MinecartRiding = 0x4000,
		Fishing = 0x8000,
		BoatRiding = 0x10000,
		VehicleRiding = 0x20000,
		UseOffHand = 0x40000,
		Teleporting = 0x80000,
		Sitting = 0x100000,
		PlayingInstrument = 0x200000,
		IgnoreAllInput = 0x400000
	}
}
