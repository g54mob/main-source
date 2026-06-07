using System;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.World.Terrain.ClimateZone.DataGenerators.BasicOperations
{
	public class Multiply : NimbatusDataGenerator
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
			return A.GetValue(worldPosition, previousValue) * B.GetValue(worldPosition, previousValue);
		}
	}
}
