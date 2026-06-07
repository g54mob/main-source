using System;
using LibNoise;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.World.Terrain.ClimateZone.DataGenerators.BasicOperations
{
	public class Tunnels : NimbatusDataGenerator
	{
		private LibNoise.Perlin _perlinNoise;

		private LibNoise.Perlin _displacementNoise;

		private const float Lacunarity = 1.5f;

		private const int OctaveCount = 1;

		private const float displacementStrength = 120f;

		private const float displacementSize = 0.008f;

		private int currentTunnelCount;

		private float[] tunnelAngle;

		[MinMaxSlider(0f, 8f, false)]
		public Vector2Int tunnelCount;

		public float tunnelThickness = 100f;

		public float noiseModificatorSize = 0.5f;

		public float noiseModificatorStrength = 0.5f;

		public override void Init(NimbatusTerrainClimateZone zone, System.Random random, ref VariableSet set)
		{
			base.Init(zone, random, ref set);
			currentTunnelCount = RandomGenerator.Next(tunnelCount.x, tunnelCount.y + 1);
			tunnelAngle = new float[currentTunnelCount];
			for (int i = 0; i < currentTunnelCount; i++)
			{
				tunnelAngle[i] = (float)RandomGenerator.Next(0, 360) * ((float)System.Math.PI / 180f);
			}
			_displacementNoise = new LibNoise.Perlin
			{
				Seed = RandomGenerator.Next(),
				Frequency = 0.00800000037997961,
				Lacunarity = 1.5,
				OctaveCount = 1,
				NoiseQuality = NoiseQuality.Standard
			};
			_perlinNoise = new LibNoise.Perlin
			{
				Seed = RandomGenerator.Next(),
				Frequency = noiseModificatorSize,
				Lacunarity = 1.5,
				OctaveCount = 1,
				NoiseQuality = NoiseQuality.Low
			};
		}

		public override float GetValue(Vector2 worldPosition, float previousValue)
		{
			if (currentTunnelCount > 0)
			{
				Vector2 zero = Vector2.zero;
				zero = new Vector2((float)_displacementNoise.GetValue(worldPosition.x, worldPosition.y, 0.0), (float)_displacementNoise.GetValue(worldPosition.y + 1000f, worldPosition.x + 1000f, 0.0));
				int planetSize = Zone.SelectedSettings.PlanetSize;
				float magnitude = worldPosition.magnitude;
				float num = Mathf.InverseLerp((float)planetSize + (float)planetSize / 10f, (float)planetSize - (float)planetSize / 10f, magnitude);
				zero *= num;
				zero *= 120f;
				if (noiseModificatorSize > 0f && noiseModificatorStrength > 0f)
				{
					zero += new Vector2((float)_perlinNoise.GetValue(worldPosition.x, worldPosition.y, 0.0), (float)_perlinNoise.GetValue(worldPosition.y + 1000f, worldPosition.x + 1000f, 0.0)) * noiseModificatorStrength;
				}
				Vector2 worldPosition2 = worldPosition + zero;
				float[] array = new float[currentTunnelCount];
				for (int i = 0; i < currentTunnelCount; i++)
				{
					array[i] = GetNewValue(worldPosition2, tunnelAngle[i]);
				}
				return Mathf.Max(array);
			}
			return 0f;
		}

		private float GetNewValue(Vector2 worldPosition, float inReferenceAngle)
		{
			Vector2 a = worldPosition;
			float magnitude = a.magnitude;
			float num = inReferenceAngle;
			num = Mathf.Repeat(num + (float)System.Math.PI * 2f, (float)System.Math.PI * 2f);
			Vector2 vector = new Vector2(Mathf.Cos(num) * magnitude, Mathf.Sin(num) * magnitude);
			Vector2 b = Mathf.Clamp01(Vector2.Dot(a.normalized, vector.normalized)) * vector;
			float value = Vector2.Distance(a, b);
			value = Mathf.InverseLerp(tunnelThickness, 0f, value);
			return Mathf.Clamp01(value);
		}
	}
}
