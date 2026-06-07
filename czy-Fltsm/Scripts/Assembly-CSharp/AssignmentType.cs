using System;

[Flags]
public enum AssignmentType
{
	None = 0,
	Constructing = 1,
	BuoySalvaging = 2,
	Deprecated_Rescueing = 4,
	LiquidHandling = 8,
	Fishing = 0x10,
	Hauling = 0x20,
	Crafting = 0x40,
	Cooking = 0x80,
	Deprecated_Sailing = 0x100,
	LandmarkInteraction = 0x200,
	AnimalHandling = 0x400,
	Researching = 0x800,
	EelectricityManagement = 0x1000,
	Medicine = 0x2000,
	Botany = 0x4000,
	Engineering = 0x8000,
	Architect = 0x10000,
	Farming = 0x20000,
	Studying = 0x20000000,
	Idle = 0x40000000
}
