using System;

[Flags]
public enum PlayerEffectContext
{
	None = 0,
	Fire = 1,
	Ooze = 2,
	Oil = 4,
	Water = 8,
	Egg = 0x10,
	Honey = 0x20,
	Battery = 0x40,
	Anvil = 0x80,
	Bees = 0x100,
	Shield = 0x200
}
