using System;

[Flags]
public enum ModificationStorageIdEnum
{
	None = 0,
	IncreaseDroneHealth = 1,
	ShieldRecharge = 2,
	ShieldRadiation = 0x10,
	StealthRecharge = 4,
	DroneSpeed = 8,
	IncreaseProbeHp = 0x10,
	ProbeStealth = 0x20,
	SUSurveyorRadiation = 0x80,
	MagneticMod = 0x100,
	SonicRecharge = 0x200,
	CannonRecharge = 0x300,
	DecontaminateRecharge = 0x400,
	OverloadRecharge = 0x500,
	TeleportMod = 0x1000,
	Uninitialized = 0xFFFF
}
