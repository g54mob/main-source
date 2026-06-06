using System;

[Flags]
public enum WorldMapScoutingId
{
	None = 0,
	Drifter = 1,
	Seagull = 2,
	Research = 4,
	Cache = 8,
	Quest = 0x10,
	Food = 0x20,
	Water = 0x40,
	PointOfInterest = 0x80,
	SpecialistDoctor = 0x10000,
	SpecialistBotanist = 0x20000,
	SpecialistEngineer = 0x40000,
	SpecialistArchitect = 0x80000,
	SpecialistChef = 0x100000,
	SpecialistFarmer = 0x200000,
	SpecialistElectrician = 0x400000,
	SpecialistChemist = 0x800000,
	SpecialistBirdkeeper = 0x1000000,
	SpecialistAquaculturist = 0x2000000
}
