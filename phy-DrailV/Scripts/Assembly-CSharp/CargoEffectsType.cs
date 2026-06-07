using System;

[Flags]
public enum CargoEffectsType
{
	None = 0,
	Liquid = 1,
	Gas = 2,
	Solid = 4,
	Flammable = 8,
	Explosive = 0x10,
	BioHazard = 0x20,
	Oil = 0x40,
	Radioactive = 0x80,
	BioHazardLiquid = 0x21,
	FlammableAndExplosiveLiquid = 0x19,
	FlammableOil = 0x49,
	FlammableAndExplosiveOil = 0x59,
	FlammableAndExplosiveGas = 0x1A,
	FlammableAndExplosiveSolid = 0x1C,
	FlammableSolid = 0xC,
	ExplosiveSolid = 0x14,
	RadioactiveSolid = 0x84
}
