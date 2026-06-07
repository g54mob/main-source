using System.Collections.Generic;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Ammunitions;

namespace Assets.Nimbatus.Scripts.World.Terrain.ClimateZone
{
	public class TerrainMaterialDestructibility
	{
		public Dictionary<EAmmunitionType, float> AmmunitionModifiers;

		public float GetModifier(EAmmunitionType type)
		{
			if (AmmunitionModifiers.ContainsKey(type))
			{
				return AmmunitionModifiers[type];
			}
			return 1f;
		}
	}
}
