using System;
using LibNoise;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.World.Terrain.ClimateZone.DataGenerators.BasicOperations
{
	public class PlanetHillsV2 : NimbatusDataGenerator
	{
		private LibNoise.Perlin _perlinNoise;

		private LibNoise.Perlin _displacementNoise;

		[MinMaxSlider(0f, 10f, false)]
		public Vector2Int HillHeight;

		[MinMaxSlider(1f, 40f, false)]
		public Vector2Int HillAmount;

		public int HillAmountMultiplicator = 1;

		[MinMaxSlider(0f, 40f, false)]
		public Vector2Int WobbleSize;

		[MinMaxSlider(0f, 100f, false)]
		public Vector2Int WobbleStrength;

		private float currentWobbleSize;

		private float currentWobbleStrength;

		private float currentHillness;

		private float normalizedHillHeight;

		public float Lacunarity = 1.5f;

		public int OctaveCount = 1;

		public float RadiusMultiplicator = 1f;

		public override void Init(NimbatusTerrainClimateZone zone, System.Random random, ref VariableSet set)
		{
			base.Init(zone, random, ref set);
			currentHillness = RandomGenerator.Next(HillAmount.x, HillAmount.y);
			currentHillness *= HillAmountMultiplicator;
			currentWobbleSize = (float)RandomGenerator.Next(WobbleSize.x, WobbleSize.y) / 40f;
			currentWobbleSize = Mathf.Lerp(0.2f, 0.002f, currentWobbleSize);
			_perlinNoise = new LibNoise.Perlin
			{
				Seed = RandomGenerator.Next(),
				Frequency = currentHillness,
				Lacunarity = Lacunarity,
				OctaveCount = OctaveCount,
				NoiseQuality = NoiseQuality.Standard
			};
			_displacementNoise = new LibNoise.Perlin
			{
				Seed = RandomGenerator.Next(),
				Frequency = currentWobbleSize,
				Lacunarity = Lacunarity,
				OctaveCount = OctaveCount,
				NoiseQuality = NoiseQuality.Standard
			};
			normalizedHillHeight = (float)RandomGenerator.Next(HillHeight.x, HillHeight.y) / 10f;
			normalizedHillHeight = Mathf.Clamp(normalizedHillHeight, 0.001f, 0.999f);
			currentWobbleStrength = (float)RandomGenerator.Next(WobbleStrength.x, WobbleStrength.y) / 100f;
			currentWobbleStrength = Mathf.Lerp(0f, 100f, currentWobbleStrength);
		}

		public override float GetValue(Vector2 worldPosition, float previousValue)
		{
			Vector2 vector = Vector2.zero;
			if (currentWobbleStrength > 0f)
			{
				vector = new Vector2((float)_displacementNoise.GetValue(worldPosition.x, worldPosition.y, 0.0), (float)_displacementNoise.GetValue(worldPosition.y + 1000f, worldPosition.x + 1000f, 0.0)) * currentWobbleStrength;
			}
			Vector2 vector2 = worldPosition + vector;
			float magnitude = vector2.magnitude;
			float num = Mathf.Atan2(vector2.y, vector2.x) * 57.29578f;
			num = Mathf.Repeat(num + 720f, 360f);
			num /= 360f;
			return GetGradient(num, magnitude);
		}

		private float GetGradient(float inAngle, float inDistance)
		{
			float num = (float)Zone.SelectedSettings.PlanetSize * RadiusMultiplicator;
			float num2 = (float)_perlinNoise.GetValue(inAngle, 0.0, 0.0);
			num2 = Mathf.Clamp01(0.5f * (num2 + 1f));
			float num3 = num + num2 * normalizedHillHeight * (num / 2f);
			float value;
			if (inDistance >= num3)
			{
				value = Mathf.InverseLerp(num * 1.5f, num3, inDistance);
				value = Mathf.Clamp01(value);
				return value * 0.5f;
			}
			value = Mathf.InverseLerp(num3, num, inDistance);
			value = Mathf.Clamp01(value);
			value *= 0.5f;
			return value + 0.5f;
		}
	}
}
