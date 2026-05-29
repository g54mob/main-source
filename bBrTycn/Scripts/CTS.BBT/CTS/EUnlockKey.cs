using System;

namespace CTS
{
	[Flags]
	public enum EUnlockKey
	{
		Default = 2,
		CheapBarPackage = 4,
		BloodStorage = 8,
		DarkBarPackage = 0x10,
		Research = 0x20,
		KawaiBarPackage = 0x40,
		Morgue = 0x80,
		Cell = 0x100,
		BasicBarPackage = 0x200,
		VampireBarPackage = 0x400,
		WesternBarPackage = 0x800,
		IndustrialBarPackage = 0x1000,
		CyberpunkBarPackage = 0x2000,
		PirateBarPackage = 0x4000,
		RockDinnerBarPackage = 0x8000,
		TikiBarPackage = 0x10000,
		DiscoBarPackage = 0x20000,
		ArtDecoBarPackage = 0x40000,
		BikerBarPackage = 0x80000,
		UnderwaterBarPackage = 0x100000,
		ResearchLevel3 = 0x200000,
		ResearchLevel4 = 0x400000,
		ResearchLevel5 = 0x800000,
		ResearchLevel6 = 0x1000000
	}
}
