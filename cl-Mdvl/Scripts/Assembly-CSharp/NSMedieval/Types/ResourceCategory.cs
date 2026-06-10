using System;

namespace NSMedieval.Types
{
	[Flags]
	public enum ResourceCategory
	{
		None = 0,
		CtgVegetable = 1,
		CtgFruit = 2,
		CtgMeal = 4,
		CtgEdible = 8,
		CtgMeat = 0x10,
		CtgAlcoholMat = 0x20,
		CtgRawMeat = 0x40,
		CtgCookingMat = 0x80,
		CtgClothMat = 0x100,
		CtgWaste = 0x200,
		CtgBuildMat = 0x400,
		CtgMetal = 0x800,
		CtgSecondCookingMat = 0x1000,
		CtgHumanCarcass = 0x2000,
		CtgLeatherMat = 0x4000,
		CtgTextileMat = 0x8000,
		CtgItem = 0x10000,
		CtgFuel = 0x20000,
		CtgDestilMat = 0x40000,
		CtgPresMat = 0x80000,
		CtgDesinf = 0x100000,
		CtgResearch = 0x200000,
		CtgCarcass = 0x400000,
		CtgHealPack = 0x800000,
		CtgAlcohol = 0x1000000,
		CtgStructure = 0x2000000,
		CtgSeeds = 0x4000000,
		CtgCandleFuel = 0x8000000,
		CtgFodder = 0x10000000,
		CtgGold = 0x20000000,
		CtgOilSource = 0x40000000,
		CtgAll = -1
	}
}
