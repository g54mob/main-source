using System;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.World.Terrain.ClimateZone.DataGenerators.BasicOperations
{
	[Serializable]
	public class Lerp : NimbatusDataGenerator
	{
		public NimbatusDataGenerator Value;

		public NimbatusDataGenerator Min;

		public NimbatusDataGenerator Max;

		public NimbatusDataGenerator From;

		public NimbatusDataGenerator To;

		public override void Init(NimbatusTerrainClimateZone zone, System.Random random, ref VariableSet set)
		{
			base.Init(zone, random, ref set);
			Value.Init(zone, random, ref set);
			Min.Init(zone, random, ref set);
			Max.Init(zone, random, ref set);
			From.Init(zone, random, ref set);
			To.Init(zone, random, ref set);
		}

		public override float GetValue(Vector2 worldPosition, float previousValue)
		{
			float value = Max.GetValue(worldPosition, previousValue);
			float value2 = Min.GetValue(worldPosition, previousValue);
			float value3 = From.GetValue(worldPosition, previousValue);
			float value4 = To.GetValue(worldPosition, previousValue);
			float value5 = Mathf.InverseLerp(value2, value, Value.GetValue(worldPosition, previousValue));
			value5 = Mathf.Clamp01(value5);
			return Mathf.Lerp(value3, value4, value5);
		}
	}
}
