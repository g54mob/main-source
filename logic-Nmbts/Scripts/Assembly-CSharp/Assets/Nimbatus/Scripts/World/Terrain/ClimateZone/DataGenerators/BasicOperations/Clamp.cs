using System;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.World.Terrain.ClimateZone.DataGenerators.BasicOperations
{
	public class Clamp : NimbatusDataGenerator
	{
		public NimbatusDataGenerator Value;

		public NimbatusDataGenerator Min;

		public NimbatusDataGenerator Max;

		public override void Init(NimbatusTerrainClimateZone zone, System.Random random, ref VariableSet set)
		{
			base.Init(zone, random, ref set);
			Value.Init(zone, random, ref set);
			Min.Init(zone, random, ref set);
			Max.Init(zone, random, ref set);
		}

		public override float GetValue(Vector2 worldPosition, float previousValue)
		{
			float value = Max.GetValue(worldPosition, previousValue);
			float value2 = Min.GetValue(worldPosition, previousValue);
			return Mathf.Clamp(Value.GetValue(worldPosition, previousValue), value2, value);
		}
	}
}
