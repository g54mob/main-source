using System;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using Assets.Nimbatus.Scripts.GalaxyMap.Sectors;
using Assets.Nimbatus.Scripts.GalaxyMap.Shops;
using Assets.Nimbatus.Scripts.Missions;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.LocationSettings
{
	public class ShopLocationSetting : LocationSetting
	{
		public class InventoryProbability
		{
			public ShopInventory Inventory;

			public float Probability = 1f;
		}

		[Header("Buy")]
		public List<InventoryProbability> PossibleInventories = new List<InventoryProbability>();

		public int ItemCount;

		public override LocationData CreateLocation(System.Random randomGenerator, GalaxyMapSector sector, EMissionDifficulty difficulty, EMissionComplexity complexity)
		{
			ShopLocationData shopLocationData = new ShopLocationData();
			shopLocationData.Init(this, randomGenerator, sector, difficulty, complexity);
			return shopLocationData;
		}

		public ShopInventoryItem GetInventoryItem(int poolSeed, int itemSeed, EMissionComplexity difficulty)
		{
			return PossibleInventories.RandomItemProbability((InventoryProbability p) => p.Probability, poolSeed).Inventory.GetItem(itemSeed, difficulty);
		}
	}
}
