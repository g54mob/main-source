using UnityEngine;

namespace Assets.Nimbatus.Scripts.World.Terrain.ClimateZone.DataGenerators.Values
{
	public class RandomFloat : NimbatusDataGenerator
	{
		public float Min;

		public float Max;

		public override float GetValue(Vector2 worldPosition, float previousValue)
		{
			Random.InitState(RandomGenerator.Next(int.MinValue, int.MaxValue));
			return Random.Range(Min, Max);
		}
	}
}
