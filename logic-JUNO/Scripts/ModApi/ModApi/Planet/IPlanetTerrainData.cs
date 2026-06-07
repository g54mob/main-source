using System.Collections.Generic;
using System.Collections.ObjectModel;
using ModApi.Planet.Modifiers;

namespace ModApi.Planet
{
	public interface IPlanetTerrainData
	{
		ReadOnlyCollection<PlanetBiome> Biomes { get; }

		IReadOnlyList<string> ConditionalSymbols { get; }

		PlanetMapSet MapSet { get; }

		ReadOnlyCollection<PlanetModifier> Modifiers { get; }

		IPlanetData PlanetData { get; }

		IPlanetTerrainQuality Quality { get; }

		int UVSizeExponent { get; }

		PlanetWaterConfig WaterConfigDefault { get; }

		void Initialize();
	}
}
