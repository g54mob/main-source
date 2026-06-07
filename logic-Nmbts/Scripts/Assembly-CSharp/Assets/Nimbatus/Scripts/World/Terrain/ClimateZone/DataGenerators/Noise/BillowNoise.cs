using LibNoise;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.World.Terrain.ClimateZone.DataGenerators.Noise
{
	public class BillowNoise : NimbatusDataGenerator
	{
		private Billow _billowNoise;

		public float Frequency = 0.2f;

		public float Lacunarity = 10f;

		public int OctaveCount = 1;

		public float Scale;

		public NoiseQuality Quality;

		public override void SimpleInit()
		{
			_billowNoise = new Billow
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
			return Mathf.Clamp01((float)_billowNoise.GetValue(worldPosition.x * Scale, worldPosition.y * Scale, 0.0));
		}
	}
}
