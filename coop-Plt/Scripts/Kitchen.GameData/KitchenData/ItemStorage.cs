using System;

namespace KitchenData
{
	[Flags]
	public enum ItemStorage
	{
		None = 0,
		Small = 1,
		StackableFood = 2,
		OutsideRubbish = 4,
		Dish = 8
	}
}
