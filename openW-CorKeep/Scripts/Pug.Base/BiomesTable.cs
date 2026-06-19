using System;
using System.Collections.Generic;
using Pug.UnityExtensions;
using Unity.Mathematics;
using UnityEngine;

[CreateAssetMenu(menuName = "Pug/Tables/BiomesTable", order = 4)]
public class BiomesTable : ScriptableObject
{
	[Serializable]
	public class BiomeLayers
	{
		[ArrayElementTitle("biome")]
		public List<BiomeParameters> biomeParameters;
	}

	[Serializable]
	public struct BiomeParameters
	{
		public Biome biome;

		public float start;

		public float end;

		public float shaderStart;

		public float shaderEnd;

		public float angleWidth;

		public float startAngle;

		public float endAngle;

		public float angleWitdhPerBiome;
	}

	public List<BiomeLayers> biomeLayers;

	private void OnValidate()
	{
		foreach (BiomeLayers biomeLayer in biomeLayers)
		{
			for (int i = 0; i < biomeLayer.biomeParameters.Count; i++)
			{
				BiomeParameters value = biomeLayer.biomeParameters[i];
				value.angleWidth = math.clamp(value.angleWidth, 10f, 360f);
				biomeLayer.biomeParameters[i] = value;
			}
		}
	}

	public static BiomeRanges GetBiomeRangesFromParameters(BiomeParameters param, float angleOffset)
	{
		BiomeRanges result = new BiomeRanges
		{
			biome = param.biome,
			start = param.start,
			shaderStart = param.shaderStart,
			shaderEnd = param.shaderEnd,
			end = param.end,
			startAngle = param.startAngle,
			endAngle = param.endAngle,
			exists = true
		};
		result.startAngle += angleOffset;
		result.endAngle += angleOffset;
		if (result.startAngle > 360f)
		{
			result.startAngle -= 360f;
			result.endAngle -= 360f;
		}
		return result;
	}
}
