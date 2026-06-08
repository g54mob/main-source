using System;

[Flags]
public enum EnemyAiBehaviors
{
	None = 0,
	AttacksWhenHit = 2,
	OpensPoweredDoors = 4,
	ChewsThroughDoors = 8,
	Wanders = 0x10,
	AttacksDroneOnSight = 0x20,
	AttractedToLures = 0x40,
	AttacksProbes = 0x80,
	DetectsEnemyInAdjacentRoom = 0x100,
	ChargesTarget = 0x200,
	CanMove = 0x400,
	AttacksSensors = 0x800,
	DetectsStealth = 0x1000,
	CuriousSeeker = 0x2000,
	ImmuneToSonic = 0x4000
}
