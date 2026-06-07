using UnityEngine;

namespace Assets.Nimbatus.Scripts.World.Terrain.ClimateZone.DataGenerators.Values
{
	public class FloatValue : NimbatusDataGenerator
	{
		public float Value;

		public override float GetValue(Vector2 worldPosition, float previousValue)
		{
			return Value;
		}
	}
}
