using UnityEngine;

namespace Assets.Nimbatus.Scripts.World.Terrain.ClimateZone.DataGenerators.Values
{
	public class SetVariable : NimbatusDataGenerator
	{
		public int Index;

		public NimbatusDataGenerator Value;

		public override float GetValue(Vector2 worldPosition, float previousValue)
		{
			Variables.Variables[Index] = Value.GetValue(worldPosition, previousValue);
			return previousValue;
		}
	}
}
