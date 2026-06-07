using System.Collections.Generic;

namespace ModApi.Planet.Modifiers.VertexData.Biomes
{
	public interface ISubBiomePlanetModifier
	{
		void GetSubBiomes(List<SubBiomeData> list);
	}
}
