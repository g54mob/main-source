using System;

namespace Factory.FieldObject
{
	[Flags]
	public enum LuggageFlag
	{
		NoCutter = 1,
		NoBlendSource = 2,
		NoCopy = 4,
		UnfitToBeAHero = 8,
		MonoColor = 0x10,
		NoExp = 0x20,
		NoCoating = 0x40,
		Statue = 0x80,
		UnmotivatedHumanSet = 0xA,
		CopiedSet = 0x14,
		StatueSet = 0xEC
	}
}
