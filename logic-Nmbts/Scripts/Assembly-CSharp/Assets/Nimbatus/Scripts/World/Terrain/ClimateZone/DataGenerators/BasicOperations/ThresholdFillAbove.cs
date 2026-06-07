using System;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.World.Terrain.ClimateZone.DataGenerators.BasicOperations
{
	public class ThresholdFillAbove : NimbatusDataGenerator
	{
		public NimbatusDataGenerator Value;

		public NimbatusDataGenerator ThresholdValue;

		public override void Init(NimbatusTerrainClimateZone zone, System.Random random, ref VariableSet set)
		{
			base.Init(zone, random, ref set);
			Value.Init(zone, random, ref set);
			ThresholdValue.Init(zone, random, ref set);
		}

		public override float GetValue(Vector2 worldPosition, float previousValue)
		{
			float value = Value.GetValue(worldPosition, previousValue);
			float value2 = ThresholdValue.GetValue(worldPosition, previousValue);
			if (value < value2)
			{
				return value;
			}
			return 1f;
		}
	}
}
