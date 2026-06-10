using System;

namespace NSMedieval.State
{
	[Flags]
	public enum BehaviourType
	{
		None = 0,
		Blank = 2,
		Worker = 4,
		Enemy = 8,
		BardVisitor = 0x10,
		CaptiveLabourer = 0x20,
		Negotiator = 0x80,
		PriestVisitor = 0x100,
		Prisoner = 0x200,
		RoleVisitor = 0x400,
		ShamanVisitor = 0x800,
		Trader = 0x1000,
		TraderBodyguard = 0x2000,
		Beggar = 0x4000,
		PilgrimVisitor = 0x8000,
		NotWorker = -5,
		CaptiveNpc = 0x220
	}
}
