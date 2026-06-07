using System;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.World.Terrain.ClimateZone.DataGenerators.BasicOperations
{
	public class Min : NimbatusDataGenerator
	{
		public NimbatusDataGenerator A;

		public NimbatusDataGenerator B;

		public override void Init(NimbatusTerrainClimateZone zone, System.Random random, ref VariableSet set)
		{
			base.Init(zone, random, ref set);
			A.Init(zone, random, ref set);
			B.Init(zone, random, ref set);
		}

		public override float GetValue(Vector2 worldPosition, float previousValue)
		{
			float value = A.GetValue(worldPosition, previousValue);
			float value2 = B.GetValue(worldPosition, previousValue);
			return Mathf.Min(value, value2);
		}
	}
}
