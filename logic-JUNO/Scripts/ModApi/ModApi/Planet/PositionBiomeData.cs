namespace ModApi.Planet
{
	public class PositionBiomeData
	{
		public string BiomeName { get; private set; }

		public float BiomeStrength { get; private set; }

		public string SubBiomeName { get; private set; }

		public float TireTrackStrength { get; private set; }

		public PlanetWaterConfig WaterConfig { get; private set; }

		public PositionBiomeData()
		{
			WaterConfig = new PlanetWaterConfig();
		}

		public void Clear()
		{
			BiomeName = null;
			SubBiomeName = null;
			BiomeStrength = 0f;
			TireTrackStrength = 0f;
		}

		public void UpdateCameraPositionData(PlanetVertexData vertexData, IPlanetTerrainData terrainData)
		{
			if (vertexData == null)
			{
				Clear();
				return;
			}
			UpdateCommonPositionData(vertexData, terrainData);
			WaterConfig.UpdateCameraPositionData(vertexData, terrainData);
		}

		public void UpdateCraftPositionData(PlanetVertexData vertexData, IPlanetTerrainData terrainData)
		{
			if (vertexData == null)
			{
				Clear();
				return;
			}
			UpdateCommonPositionData(vertexData, terrainData);
			TireTrackStrength = vertexData.TireTrackStrength;
			WaterConfig.UpdateCraftPositionData(vertexData, terrainData);
		}

		private void UpdateCommonPositionData(PlanetVertexData vertexData, IPlanetTerrainData terrainData)
		{
			PlanetVertexBiomeData planetVertexBiomeData = null;
			PlanetVertexBiomeData[] biomes = vertexData.Biomes;
			foreach (PlanetVertexBiomeData planetVertexBiomeData2 in biomes)
			{
				if (planetVertexBiomeData2.Strength > 0f)
				{
					if (planetVertexBiomeData == null)
					{
						planetVertexBiomeData = planetVertexBiomeData2;
					}
					else if (planetVertexBiomeData2.Strength > planetVertexBiomeData.Strength)
					{
						planetVertexBiomeData = planetVertexBiomeData2;
					}
				}
			}
			if (planetVertexBiomeData == null)
			{
				Clear();
				return;
			}
			BiomeName = terrainData.Biomes[planetVertexBiomeData.BiomeIndex].Name;
			SubBiomeName = planetVertexBiomeData.PrimarySubBiome?.Name;
			BiomeStrength = planetVertexBiomeData.Strength;
		}
	}
}
