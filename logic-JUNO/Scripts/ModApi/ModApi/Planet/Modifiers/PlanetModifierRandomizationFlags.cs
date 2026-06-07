using System;

namespace ModApi.Planet.Modifiers
{
	[Flags]
	public enum PlanetModifierRandomizationFlags
	{
		None = 0,
		SeedValues = 1,
		NoiseSettings = 2,
		All = 3
	}
}
