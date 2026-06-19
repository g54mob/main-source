using System;

namespace Radio
{
	[Flags]
	public enum RadioCondition
	{
		None = 0,
		IsNight = 1,
		IsRaining = 2,
		PlayerInDanger = 4,
		PlayerLowHealth = 8,
		BossNearby = 0x10,
		QuestComplete = 0x20,
		Night = 0x40,
		Morning = 0x80,
		Day = 0x100,
		Evening = 0x200,
		Custom1 = 0x400,
		Custom2 = 0x800
	}
}
