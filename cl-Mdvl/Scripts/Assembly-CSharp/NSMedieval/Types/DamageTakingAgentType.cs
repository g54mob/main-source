using System;

namespace NSMedieval.Types
{
	[Flags]
	public enum DamageTakingAgentType
	{
		None = 0,
		Animal = 1,
		Worker = 2,
		NPC = 4,
		Building = 8,
		ResourcePile = 0x10,
		Trebuchet = 0x20,
		Plant = 0x40,
		Point = 0x80,
		All = 0xFF
	}
}
