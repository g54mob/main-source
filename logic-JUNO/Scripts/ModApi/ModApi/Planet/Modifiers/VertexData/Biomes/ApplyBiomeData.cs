using ModApi.Common;
using ModApi.Planet.CustomData;
using ModApi.Planet.Modifiers.Attributes;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData.Biomes
{
	[PlanetModifierInfo("Apply Biome Data", "A planet modifier required in the final pass that blends and applies biome data based on biome strengths and terrain slope.")]
	public class ApplyBiomeData : VertexDataPlanetModifier
	{
		public override VertexDataPlanetModifierPassType Pass => VertexDataPlanetModifierPassType.Final;

		public override VertexDataType VertexDataType => VertexDataType.Both;

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			if (data.DebugColorsOnly)
			{
				return;
			}
			float num = 1f - (float)Vector3d.Dot(input.Position, input.Normal);
			PlanetVertexBiomeData[] biomes = data.Biomes;
			foreach (PlanetVertexBiomeData planetVertexBiomeData in biomes)
			{
				float primarySubBiomeStrength = planetVertexBiomeData.PrimarySubBiomeStrength;
				if (primarySubBiomeStrength > 0f)
				{
					SubBiomeData primarySubBiome = planetVertexBiomeData.PrimarySubBiome;
					MinMaxValue slopeRange = primarySubBiome.SlopeRange;
					if (num <= slopeRange.MinValue)
					{
						UpdateBiomeData(data, primarySubBiome.PrimaryData, primarySubBiomeStrength);
					}
					else if (num >= slopeRange.MaxValue)
					{
						UpdateBiomeData(data, primarySubBiome.SlopeData, primarySubBiomeStrength);
					}
					else
					{
						float num2 = (num - slopeRange.MinValue) * primarySubBiome.OneOverSlopeBlendRange * primarySubBiomeStrength;
						UpdateBiomeData(data, primarySubBiome.PrimaryData, primarySubBiomeStrength - num2);
						UpdateBiomeData(data, primarySubBiome.SlopeData, num2);
					}
				}
				float secondarySubBiomeStrength = planetVertexBiomeData.SecondarySubBiomeStrength;
				if (secondarySubBiomeStrength > 0f)
				{
					SubBiomeData secondarySubBiome = planetVertexBiomeData.SecondarySubBiome;
					MinMaxValue slopeRange2 = secondarySubBiome.SlopeRange;
					if (num <= slopeRange2.MinValue)
					{
						UpdateBiomeData(data, secondarySubBiome.PrimaryData, secondarySubBiomeStrength);
						continue;
					}
					if (num >= slopeRange2.MaxValue)
					{
						UpdateBiomeData(data, secondarySubBiome.SlopeData, secondarySubBiomeStrength);
						continue;
					}
					float num3 = (num - slopeRange2.MinValue) * secondarySubBiome.OneOverSlopeBlendRange * secondarySubBiomeStrength;
					UpdateBiomeData(data, secondarySubBiome.PrimaryData, secondarySubBiomeStrength - num3);
					UpdateBiomeData(data, secondarySubBiome.SlopeData, num3);
				}
			}
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			if (data.CommonData.DebugColorsOnly)
			{
				return;
			}
			float num = 1f - (float)Vector3d.Dot(input.Position, input.Normal);
			PlanetVertexBiomeData planetVertexBiomeData = data.CommonData.Biomes[data.BiomeIndex];
			float primarySubBiomeStrength = planetVertexBiomeData.PrimarySubBiomeStrength;
			if (primarySubBiomeStrength > 0f)
			{
				SubBiomeData primarySubBiome = planetVertexBiomeData.PrimarySubBiome;
				MinMaxValue slopeRange = primarySubBiome.SlopeRange;
				if (num <= slopeRange.MinValue)
				{
					UpdateBiomeData(data, primarySubBiome.PrimaryData, primarySubBiomeStrength);
				}
				else if (num >= slopeRange.MaxValue)
				{
					UpdateBiomeData(data, primarySubBiome.SlopeData, primarySubBiomeStrength);
				}
				else
				{
					float num2 = (num - slopeRange.MinValue) * primarySubBiome.OneOverSlopeBlendRange * primarySubBiomeStrength;
					UpdateBiomeData(data, primarySubBiome.PrimaryData, primarySubBiomeStrength - num2);
					UpdateBiomeData(data, primarySubBiome.SlopeData, num2);
				}
			}
			float secondarySubBiomeStrength = planetVertexBiomeData.SecondarySubBiomeStrength;
			if (secondarySubBiomeStrength > 0f)
			{
				SubBiomeData secondarySubBiome = planetVertexBiomeData.SecondarySubBiome;
				MinMaxValue slopeRange2 = secondarySubBiome.SlopeRange;
				if (num <= slopeRange2.MinValue)
				{
					UpdateBiomeData(data, secondarySubBiome.PrimaryData, secondarySubBiomeStrength);
					return;
				}
				if (num >= slopeRange2.MaxValue)
				{
					UpdateBiomeData(data, secondarySubBiome.SlopeData, secondarySubBiomeStrength);
					return;
				}
				float num3 = (num - slopeRange2.MinValue) * secondarySubBiome.OneOverSlopeBlendRange * secondarySubBiomeStrength;
				UpdateBiomeData(data, secondarySubBiome.PrimaryData, secondarySubBiomeStrength - num3);
				UpdateBiomeData(data, secondarySubBiome.SlopeData, num3);
			}
		}

		private static void UpdateBiomeData(PlanetVertexData data, SubBiomeTerrainData biomeData, float strength)
		{
			Color colorLinear = biomeData.ColorLinear;
			data.Color.r += colorLinear.r * strength;
			data.Color.g += colorLinear.g * strength;
			data.Color.b += colorLinear.b * strength;
			data.Color.a += colorLinear.a * strength;
			data.Emissiveness += biomeData.Emissiveness * strength;
			data.Metallicness += biomeData.Metallicness * strength;
			data.Smoothness += biomeData.Smoothness * strength;
			data.TireTrackStrength += biomeData.TireTrackStrength * strength;
			data.SplatMapData[biomeData.TextureIndex] += strength;
			CustomSubBiomeTerrainData[] customData = biomeData.CustomData;
			foreach (CustomSubBiomeTerrainData customSubBiomeTerrainData in customData)
			{
				int customPlanetVertexDataIndex = customSubBiomeTerrainData.CustomPlanetVertexDataIndex;
				if (customPlanetVertexDataIndex >= 0)
				{
					customSubBiomeTerrainData.ApplyBiomeData(data.CustomData[customPlanetVertexDataIndex], strength);
				}
			}
		}

		private static void UpdateBiomeData(PlanetBiomeVertexData data, SubBiomeTerrainData biomeData, float strength)
		{
			Color colorLinear = biomeData.ColorLinear;
			data.Color.r += colorLinear.r * strength;
			data.Color.g += colorLinear.g * strength;
			data.Color.b += colorLinear.b * strength;
			data.Color.a += colorLinear.a * strength;
			PlanetVertexData commonData = data.CommonData;
			commonData.Emissiveness += biomeData.Emissiveness * strength;
			commonData.Metallicness += biomeData.Metallicness * strength;
			commonData.Smoothness += biomeData.Smoothness * strength;
			commonData.TireTrackStrength += biomeData.TireTrackStrength * strength;
			commonData.SplatMapData[biomeData.TextureIndex] += strength;
			CustomSubBiomeTerrainData[] customData = biomeData.CustomData;
			foreach (CustomSubBiomeTerrainData customSubBiomeTerrainData in customData)
			{
				int customPlanetVertexDataIndex = customSubBiomeTerrainData.CustomPlanetVertexDataIndex;
				if (customPlanetVertexDataIndex >= 0)
				{
					customSubBiomeTerrainData.ApplyBiomeData(commonData.CustomData[customPlanetVertexDataIndex], strength);
				}
			}
		}
	}
}
