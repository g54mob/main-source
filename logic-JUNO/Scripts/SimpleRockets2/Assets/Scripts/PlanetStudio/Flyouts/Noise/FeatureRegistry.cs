using System;
using System.Collections.Generic;
using ModApi.Planet.Modifiers;
using ModApi.Planet.Modifiers.VertexData;

namespace Assets.Scripts.PlanetStudio.Flyouts.Noise
{
	public static class FeatureRegistry
	{
		private static Dictionary<Type, Func<PlanetModifier, TerrainFeature>> _registry;

		static FeatureRegistry()
		{
			_registry = new Dictionary<Type, Func<PlanetModifier, TerrainFeature>>();
			_registry[typeof(VertexDataNoise)] = (PlanetModifier m) => new VertexDataNoiseFeature(m as VertexDataNoise);
			_registry[typeof(CratersFast)] = (PlanetModifier m) => new CratersFastFeature(m as CratersFast);
			_registry[typeof(GenerateHeight)] = (PlanetModifier m) => new GenerateHeightFeature(m as GenerateHeight);
			_registry[typeof(ColorBands)] = (PlanetModifier m) => new ColorBandsFeature(m as ColorBands);
		}

		public static TerrainFeature CreateFeatureForModifier(VertexDataPlanetModifier modifier)
		{
			Func<PlanetModifier, TerrainFeature> value = null;
			if (_registry.TryGetValue(modifier.GetType(), out value))
			{
				return value(modifier);
			}
			return null;
		}

		public static bool IsFeatureAvailable(VertexDataPlanetModifier modifier)
		{
			return _registry.ContainsKey(modifier.GetType());
		}
	}
}
