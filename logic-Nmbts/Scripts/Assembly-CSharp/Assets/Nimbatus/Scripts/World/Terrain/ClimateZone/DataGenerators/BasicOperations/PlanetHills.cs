using System;
using LibNoise;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.World.Terrain.ClimateZone.DataGenerators.BasicOperations
{
	public class PlanetHills : NimbatusDataGenerator
	{
		private LibNoise.Perlin _perlinNoise;

		private LibNoise.Perlin _displacementNoise;

		private const float Lacunarity = 1.5f;

		private const int OctaveCount = 1;

		[MinMaxSlider(0f, 10f, false)]
		public Vector2Int HillHeight;

		[MinMaxSlider(0f, 40f, false)]
		public Vector2Int HillAmount;

		public float HillAmountMultiplicator = 1f;

		[MinMaxSlider(0f, 40f, false)]
		public Vector2Int WobbleSize;

		[MinMaxSlider(0f, 100f, false)]
		public Vector2Int WobbleStrength;

		private float currentWobbleSize;

		private float currentWobbleStrength;

		private float currentHillness;

		private float normalizedHillHeight;

		public float RadiusMultiplicator = 1f;

		public override void Init(NimbatusTerrainClimateZone zone, System.Random random, ref VariableSet set)
		{
			base.Init(zone, random, ref set);
			currentHillness = (float)RandomGenerator.Next(HillAmount.x, HillAmount.y) / 40f;
			currentHillness = Mathf.Lerp(0.5f, 5f, currentHillness);
			currentHillness *= HillAmountMultiplicator;
			currentWobbleSize = (float)RandomGenerator.Next(WobbleSize.x, WobbleSize.y) / 40f;
			currentWobbleSize = Mathf.Lerp(0.2f, 0.002f, currentWobbleSize);
			_perlinNoise = new LibNoise.Perlin
			{
				Seed = RandomGenerator.Next(),
				Frequency = currentHillness,
				Lacunarity = 1.5,
				OctaveCount = 1,
				NoiseQuality = NoiseQuality.Low
			};
			_displacementNoise = new LibNoise.Perlin
			{
				Seed = RandomGenerator.Next(),
				Frequency = currentWobbleSize,
				Lacunarity = 1.5,
				OctaveCount = 1,
				NoiseQuality = NoiseQuality.Low
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
			float num = Mathf.Atan2(vector2.y, vector2.x);
			num = Mathf.Repeat(num + (float)System.Math.PI * 2f, (float)System.Math.PI * 2f);
			float num2 = GetGradient(num, magnitude);
			if (num <= (float)System.Math.PI / 50f || num >= 6.2203536f)
			{
				float gradient = GetGradient(0f, magnitude);
				float gradient2 = GetGradient((float)System.Math.PI * 2f, magnitude);
				float num3 = (gradient + gradient2) / 2f;
				if (num <= (float)System.Math.PI / 50f)
				{
					float value = Mathf.InverseLerp(0f, (float)System.Math.PI / 50f, num);
					value = Mathf.Clamp01(value);
					num2 = Mathf.Lerp(num3, num2, value);
				}
				if (num >= 6.2203536f)
				{
					float value2 = Mathf.InverseLerp(6.2203536f, (float)System.Math.PI * 2f, num);
					value2 = Mathf.Clamp01(value2);
					num2 = Mathf.Lerp(num2, num3, value2);
				}
			}
			return num2;
		}

		private float GetGradient(float inAngle, float inDistance)
		{
			float num = (float)Zone.SelectedSettings.PlanetSize * RadiusMultiplicator;
			float num2 = (float)_perlinNoise.GetValue(inAngle, 0.0, 0.0);
			num2 = Mathf.Clamp01(0.5f * (num2 + 1f));
			float num3 = num + num2 * normalizedHillHeight * (num / 2f);
			float num4 = 0f;
			if (inDistance >= num3)
			{
				num4 = Mathf.InverseLerp(num * 1.5f, num3, inDistance);
				num4 = Mathf.Clamp01(num4);
				return num4 * 0.5f;
			}
			num4 = Mathf.InverseLerp(num3, num, inDistance);
			num4 = Mathf.Clamp01(num4);
			num4 *= 0.5f;
			return num4 + 0.5f;
		}
	}
}
