using UnityEngine;

namespace Assets.Nimbatus.Scripts.World.Terrain.ClimateZone.DataGenerators.Values
{
	public class GetVariable : NimbatusDataGenerator
	{
		public int Index;

		public override float GetValue(Vector2 worldPosition, float previousValue)
		{
			return Variables.Variables[Index];
		}
	}
}
