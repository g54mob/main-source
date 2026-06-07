using System;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.World.Terrain.ClimateZone.DataGenerators.BasicOperations
{
	public class PlanetRound : NimbatusDataGenerator
	{
		public NimbatusDataGenerator radius;

		public override void Init(NimbatusTerrainClimateZone zone, System.Random random, ref VariableSet set)
		{
			base.Init(zone, random, ref set);
			radius.Init(zone, random, ref set);
		}

		public override float GetValue(Vector2 worldPosition, float previousValue)
		{
			float magnitude = worldPosition.magnitude;
			return Mathf.Clamp01(Mathf.InverseLerp(radius.GetValue(worldPosition, previousValue) * 2f, 0f, magnitude));
		}
	}
}
