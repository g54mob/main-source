using System;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.World.Terrain.ClimateZone.DataGenerators.BasicOperations
{
	public class BoundToOne : NimbatusDataGenerator
	{
		public NimbatusDataGenerator A;

		public override void Init(NimbatusTerrainClimateZone zone, System.Random random, ref VariableSet set)
		{
			base.Init(zone, random, ref set);
			A.Init(zone, random, ref set);
		}

		public override float GetValue(Vector2 worldPosition, float previousValue)
		{
			float value = A.GetValue(worldPosition, previousValue);
			return 1f - 1f / (value * value + 1f);
		}
	}
}
