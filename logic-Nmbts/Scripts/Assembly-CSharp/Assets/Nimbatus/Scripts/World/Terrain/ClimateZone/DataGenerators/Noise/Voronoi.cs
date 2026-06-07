using LibNoise;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.World.Terrain.ClimateZone.DataGenerators.Noise
{
	public class Voronoi : NimbatusDataGenerator
	{
		private LibNoise.Voronoi _noise;

		public float Frequency = 0.2f;

		public float Displacement = 1f;

		public bool DistanceEnabled;

		public float Scale = 1f;

		public override void SimpleInit()
		{
			_noise = new LibNoise.Voronoi
			{
				Seed = RandomGenerator.Next(),
				Frequency = Frequency,
				Displacement = Displacement,
				DistanceEnabled = DistanceEnabled
			};
		}

		public override float GetValue(Vector2 worldPosition, float previousValue)
		{
			float num = (float)_noise.GetValue(worldPosition.x * Scale, worldPosition.y * Scale, 0.0);
			return Mathf.Clamp01(0.5f * (num + 1f));
		}
	}
}
