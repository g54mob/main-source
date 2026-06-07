using System;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.World.Terrain.ClimateZone.DataGenerators
{
	[Serializable]
	public abstract class NimbatusDataGenerator
	{
		protected System.Random RandomGenerator;

		protected NimbatusTerrainClimateZone Zone;

		protected VariableSet Variables;

		public virtual void Init(NimbatusTerrainClimateZone zone, System.Random rnd, ref VariableSet set)
		{
			RandomGenerator = rnd;
			Zone = zone;
			Variables = set;
			SimpleInit();
		}

		public virtual void SimpleInit()
		{
		}

		public abstract float GetValue(Vector2 worldPosition, float previousValue);
	}
}
