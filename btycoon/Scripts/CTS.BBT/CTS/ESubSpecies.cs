using System;

namespace CTS
{
	[Flags]
	public enum ESubSpecies
	{
		Aristocrat = 1,
		Beggar = 2,
		Builder = 4,
		Business = 8,
		Commoner = 0x10,
		Country = 0x20,
		Goth = 0x40,
		Kawaii = 0x80,
		Loony = 0x100,
		SewerDweller = 0x200,
		Townie = 0x400,
		Waiter = 0x800,
		Cyberfan = 0x1000,
		Investigateur = 0x2000,
		Cryptkin = 0x4000,
		Siren = 0x8000,
		Gobbler = 0x10000,
		Rocker = 0x20000,
		SeaRover = 0x40000,
		BeachGoer = 0x80000,
		Discomaniac = 0x100000,
		MetalRider = 0x200000,
		Hunter = 0x400000
	}
}
