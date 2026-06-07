using System;

[Flags]
public enum Tag
{
	Buildings = 1,
	Operators = 2,
	Logistics = 4,
	SpeedUpgrades = 8,
	Cranes = 0x10,
	Drones = 0x20,
	Recipes = 0x40,
	All = 0x7F
}
