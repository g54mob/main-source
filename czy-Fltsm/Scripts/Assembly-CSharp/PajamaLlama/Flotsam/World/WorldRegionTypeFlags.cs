using System;

namespace PajamaLlama.Flotsam.World
{
	[Flags]
	public enum WorldRegionTypeFlags
	{
		None = 0,
		Forest = 1,
		Rural = 2,
		City = 4,
		PollutedWoods = 8,
		Farmland = 0x10,
		Shallow = 0x20,
		Industry = 0x40,
		Utopia = 0x80,
		PollutionBelt = 0x100
	}
}
