using System;

namespace Brewery.Core
{
	[Flags]
	public enum BrewTag
	{
		None = 0,
		Hoppy = 1,
		Fruity = 2,
		Spiced = 4,
		Smooth = 8,
		Bitter = 0x10,
		Sweet = 0x20,
		Strong = 0x40,
		Premium = 0x80,
		Fresh = 0x100,
		Aged = 0x200,
		Herbal = 0x400,
		Rich = 0x800,
		Laced = 0x1000,
		Weed = 0x2000,
		Sketchy = 0x4000,
		Vulgar = 0x8000,
		Blessed = 0x10000,
		Toxic = 0x20000,
		Medicinal = 0x40000,
		Energizing = 0x80000
	}
}
