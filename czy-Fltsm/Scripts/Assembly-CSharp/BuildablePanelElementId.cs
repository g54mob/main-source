using System;

[Flags]
public enum BuildablePanelElementId
{
	None = 0,
	Activation = 1,
	Durability = 2,
	Malfunction = 4,
	Storage = 8,
	LiquidStorage = 0x10,
	MooringPoint = 0x20,
	Boat = 0x40,
	Workshop = 0x80,
	Farm = 0x100,
	House = 0x200,
	Research = 0x400,
	Birdhouse = 0x800,
	SmallStorage = 0x1000,
	EnergyItemProducer = 0x2000,
	EnergyManualProducer = 0x4000,
	EnergyGridLink = 0x8000,
	EnergyStorage = 0x10000,
	EnergyGridInformation = 0x20000,
	Fisher = 0x40000,
	School = 0x80000,
	Radio = 0x100000,
	MedPod = 0x200000,
	ArchitectStation = 0x400000,
	TownMovement = 0x800000,
	Watchtower = 0x1000000,
	TownTugger = 0x2000000,
	FishFarm = 0x4000000,
	StorageFilter = 0x8000000,
	WaterDistribution = 0x10000000,
	Field = 0x20000000,
	WeightInformation = 0x40000000
}
