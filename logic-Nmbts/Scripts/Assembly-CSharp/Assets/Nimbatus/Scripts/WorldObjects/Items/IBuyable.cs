using System.Collections.Generic;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items
{
	public interface IBuyable
	{
		Dictionary<ETerrainMaterial, int> GetPrice();

		void Buy();

		bool HasResourcesToBuy();
	}
}
