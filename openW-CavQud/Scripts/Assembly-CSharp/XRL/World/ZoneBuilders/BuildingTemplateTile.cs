using System;

namespace XRL.World.ZoneBuilders
{
	[Serializable]
	public enum BuildingTemplateTile
	{
		Void = 0,
		Outside = 1,
		OutsideWall = 2,
		Wall = 3,
		Door = 4,
		StairsUp = 5,
		StairsDown = 6,
		Inside = 7
	}
}
