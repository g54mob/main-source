using ModApi.Planet.CustomData;
using UnityEngine;

namespace ModApi.Planet
{
	public class PlanetVertexData
	{
		public const int DataSlotCount = 10;

		public PlanetVertexBiomeData[] Biomes;

		public TerrainGeneratorCacheData CacheData;

		public Color Color;

		public CustomPlanetVertexData[] CustomData;

		public double[] Data;

		public bool DebugColorsOnly;

		public float Emissiveness;

		public byte FoamStrength;

		public double Height;

		public float Metallicness;

		public bool OnPaddedQuadEdge;

		public byte ReflectionStrength;

		public float Smoothness;

		public float[] SplatMapData;

		public byte TextureStrength;

		public float TireTrackStrength;

		public byte TransparencyDepthScale;

		public byte TransparencyStrength;

		public byte WaveAmplitudeScale;

		public PlanetVertexData(TerrainGeneratorCacheData terrainGeneratorCacheData)
		{
			CacheData = terrainGeneratorCacheData;
			Data = new double[10];
			SplatMapData = new float[9];
			OnPaddedQuadEdge = false;
			CustomData = CustomPlanetVertexData.Create();
			Biomes = new PlanetVertexBiomeData[terrainGeneratorCacheData.BiomeCount];
			for (int i = 0; i < Biomes.Length; i++)
			{
				Biomes[i] = new PlanetVertexBiomeData
				{
					BiomeIndex = i
				};
			}
		}

		public void ApplyCustomDataBiomeResults(PlanetBiomeVertexData planetBiomeVertexData)
		{
			int num = CustomData.Length;
			for (int i = 0; i < num; i++)
			{
				CustomData[i].ApplyBiomeResults(planetBiomeVertexData.CustomData[i], planetBiomeVertexData.BiomeStrength);
			}
		}

		public void Reset()
		{
			Height = 0.0;
			Color = Color.clear;
			Emissiveness = 0f;
			Metallicness = 0f;
			Smoothness = 0f;
			TireTrackStrength = 0f;
			DebugColorsOnly = false;
			for (int i = 0; i < Biomes.Length; i++)
			{
				PlanetVertexBiomeData obj = Biomes[i];
				obj.Strength = 0f;
				obj.PrimarySubBiomeStrength = 0f;
				obj.SecondarySubBiomeStrength = 0f;
			}
			SplatMapData[0] = 0f;
			SplatMapData[1] = 0f;
			SplatMapData[2] = 0f;
			SplatMapData[3] = 0f;
			SplatMapData[4] = 0f;
			SplatMapData[5] = 0f;
			SplatMapData[6] = 0f;
			SplatMapData[7] = 0f;
			ResetCustomData();
		}

		public void ResetCustomData()
		{
			CustomPlanetVertexData[] customData = CustomData;
			for (int i = 0; i < customData.Length; i++)
			{
				customData[i].Reset();
			}
		}
	}
}
