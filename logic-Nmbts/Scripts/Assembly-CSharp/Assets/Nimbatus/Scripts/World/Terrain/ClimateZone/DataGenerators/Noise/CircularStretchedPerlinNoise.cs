using LibNoise;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.World.Terrain.ClimateZone.DataGenerators.Noise
{
	public class CircularStretchedPerlinNoise : NimbatusDataGenerator
	{
		private LibNoise.Perlin _perlinNoise;

		public float Frequency = 1f;

		public float Lacunarity = 1.5f;

		public int OctaveCount = 1;

		public NoiseQuality Quality;

		public float Stretch = 1f;

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
			float f = Mathf.Atan2(worldPosition.y, worldPosition.x);
			float f2 = Mathf.Sqrt(worldPosition.x * worldPosition.x + worldPosition.y * worldPosition.y);
			f2 = Mathf.Pow(f2, Stretch);
			float num = (float)_perlinNoise.GetValue(Mathf.Cos(f) * f2, Mathf.Sin(f) * f2, 0.0);
			return Mathf.Clamp01(0.5f * (num + 1f));
		}
	}
}
