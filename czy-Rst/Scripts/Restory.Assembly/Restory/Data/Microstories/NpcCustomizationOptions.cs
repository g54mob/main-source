using System;

namespace Restory.Data.Microstories
{
	[Flags]
	public enum NpcCustomizationOptions
	{
		None = 0,
		Glasses = 1,
		Hat = 2,
		Necktie = 4,
		BowTie = 8,
		StuddedCollar = 0x10,
		Choker = 0x20
	}
}
