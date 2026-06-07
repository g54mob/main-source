using System;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.World.Terrain.ClimateZone.DataGenerators.BasicOperations
{
	public class FixedSpiral : NimbatusDataGenerator
	{
		public NimbatusDataGenerator SpiralSize;

		public NimbatusDataGenerator SpiralCutOff;

		public float Offset;

		public override void Init(NimbatusTerrainClimateZone zone, System.Random random, ref VariableSet set)
		{
			base.Init(zone, random, ref set);
			SpiralSize.Init(zone, random, ref set);
			SpiralCutOff.Init(zone, random, ref set);
		}

		public override float GetValue(Vector2 worldPosition, float previousValue)
		{
			float magnitude = worldPosition.magnitude;
			if (magnitude > SpiralCutOff.GetValue(worldPosition, previousValue))
			{
				return 0f;
			}
			float value = SpiralSize.GetValue(worldPosition, previousValue);
			float num = Mathf.Atan2(worldPosition.y, worldPosition.x);
			num = Mathf.Repeat(num + (float)Math.PI * 2f, (float)Math.PI * 2f);
			return 1f - Mathf.Abs(Mathf.Repeat(magnitude / value + num / (float)Math.PI + Mathf.Repeat(Offset * 2f, 2f), 2f) - 1f);
		}
	}
}
