using System;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainResources;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Shops
{
	[Serializable]
	public class ItemPrice
	{
		public ETerrainMaterial Resource;

		public int Amount;

		public ItemPrice()
		{
		}

		public ItemPrice(ETerrainMaterial mat, int amount)
		{
			Resource = mat;
			Amount = amount;
		}

		public bool AffordsPrice()
		{
			return SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.HasResources(Resource, Amount);
		}
	}
}
