using System;
using ModApi.Planet.Modifiers.Attributes;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData
{
	[PlanetModifierInfo("Legacy Modifier - Do Not Use", IsHidden = true)]
	public class ApplyStandardMapSet : VertexDataPlanetModifier
	{
		public override VertexDataPlanetModifierPassType Pass => VertexDataPlanetModifierPassType.Biome;

		public override VertexDataType VertexDataType => VertexDataType.Common;

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			PlanetMapSet.MapSampleResult mapSampleResult = data.CacheData.MapSampleResult;
			if (base.TerrainData.MapSet != null)
			{
				base.TerrainData.MapSet.SampleMaps(input.Position, mapSampleResult, data.CacheData.MapSampleArray);
			}
			else
			{
				mapSampleResult.SetDefaultValues();
			}
			data.Height += mapSampleResult.Height;
			PlanetVertexBiomeData[] biomes = data.Biomes;
			int num = System.Math.Min(biomes.Length, mapSampleResult.NumBiomes);
			for (int i = 0; i < num; i++)
			{
				biomes[i].Strength = mapSampleResult.GetBiomeStrength(i);
			}
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			throw new NotSupportedException("Modifier '" + GetType().FullName + "' does not support biome-specific vertex data.");
		}

		public override Vector2d LegacyGetMinMaxHeight(Vector2d minMaxHeight)
		{
			return minMaxHeight;
		}
	}
}
