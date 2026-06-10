using System;

namespace NSMedieval.Model
{
	[Flags]
	public enum IngredientFlags
	{
		None = 0,
		Fruit = 1,
		Vegetables = 2,
		Grain = 4,
		Meat = 8,
		HumanMeat = 0x10,
		Egg = 0x20,
		Fish = 0x40,
		Milk = 0x80,
		Honey = 0x100,
		Cheese = 0x200,
		Rot = 0x400
	}
}
