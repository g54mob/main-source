using UnityEngine;

namespace Assets.Nimbatus.Scripts.World.Terrain.ClimateZone.DataGenerators.Values
{
	public class PosY : NimbatusDataGenerator
	{
		public override float GetValue(Vector2 worldPosition, float previousValue)
		{
			return worldPosition.y;
		}
	}
}
