using System;

[Serializable]
public enum TaskType
{
	Collectable = 0,
	Research = 1,
	ReachSomewhere = 2,
	Interact = 3,
	Build = 4,
	Combat = 5,
	Loot = 6,
	Craft = 7,
	PlaceObject = 8,
	BuildObject = 9,
	CollectDirtyWater = 10,
	AddFuelOnWaterPurifier = 11,
	CollectCleanWater = 12,
	Cook = 13,
	CollectOre = 14,
	MeltOre = 15,
	CollectIngot = 16,
	OpenBuildCanvas = 17,
	AddWaterToTrain = 18,
	AddFuelToTrain = 19,
	PressGasPedal = 20,
	ReleaseBrake = 21,
	MoveTheTrain = 22
}
