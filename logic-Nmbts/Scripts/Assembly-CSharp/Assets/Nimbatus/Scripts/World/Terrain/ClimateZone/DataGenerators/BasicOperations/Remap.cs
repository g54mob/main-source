using System;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.World.Terrain.ClimateZone.DataGenerators.BasicOperations
{
	public class Remap : NimbatusDataGenerator
	{
		public NimbatusDataGenerator Value;

		public NimbatusDataGenerator MinOld;

		public NimbatusDataGenerator MaxOld;

		public NimbatusDataGenerator MinNew;

		public NimbatusDataGenerator MaxNew;

		public override void Init(NimbatusTerrainClimateZone zone, System.Random random, ref VariableSet set)
		{
			base.Init(zone, random, ref set);
			Value.Init(zone, random, ref set);
			MinOld.Init(zone, random, ref set);
			MaxOld.Init(zone, random, ref set);
			MinNew.Init(zone, random, ref set);
			MaxNew.Init(zone, random, ref set);
		}

		public override float GetValue(Vector2 worldPosition, float previousValue)
		{
			float value = Mathf.InverseLerp(MinOld.GetValue(worldPosition, previousValue), MaxOld.GetValue(worldPosition, previousValue), Value.GetValue(worldPosition, previousValue));
			value = Mathf.Clamp01(value);
			return Mathf.Lerp(MinNew.GetValue(worldPosition, previousValue), MaxNew.GetValue(worldPosition, previousValue), value);
		}
	}
}
