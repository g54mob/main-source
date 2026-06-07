using LibNoise;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.World.Terrain.ClimateZone.DataGenerators.Noise
{
	public class PerlinNoiseUnclamped : NimbatusDataGenerator
	{
		private LibNoise.Perlin _perlinNoise;

		public float Frequency = 0.2f;

		public float Lacunarity = 10f;

		public int OctaveCount = 1;

		public float Scale = 1f;

		public NoiseQuality Quality;

		public override void SimpleInit()
		{
			_perlinNoise = new LibNoise.Perlin
			{
				Seed = RandomGenerator.Next(),
				Frequency = Frequency,
				Lacunarity = Lacunarity,
				OctaveCount = OctaveCount,
				NoiseQuality = Quality
			};
		}

		public override float GetValue(Vector2 worldPosition, float previousValue)
		{
			float num = (float)_perlinNoise.GetValue(worldPosition.x * Scale, worldPosition.y * Scale, 0.0);
			return 0.5f * (num + 1f);
		}
	}
}
