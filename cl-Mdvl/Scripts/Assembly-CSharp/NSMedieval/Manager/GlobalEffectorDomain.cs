using System;

namespace NSMedieval.Manager
{
	[Flags]
	public enum GlobalEffectorDomain
	{
		None = 0,
		Worker = 1,
		Enemy = 2,
		PlayersPrisoner = 4,
		EnemyPrisoner = 8,
		Trader = 0x10,
		TraderBodyGuard = 0x20,
		CaptiveLabourer = 0x40,
		Prisoner = 0xC,
		Captive = 0x4C,
		Npc = 0x3E,
		All = 0x3F
	}
}
