using System;

namespace NSMedieval.Types
{
	[Flags]
	public enum LightningStrikeTargetType
	{
		RandomPosition = 0,
		Animal = 1,
		Plant = 2,
		Worker = 3,
		Enemy = 4,
		Building = 5,
		ResourcePile = 6,
		Trebuchet = 7
	}
}
