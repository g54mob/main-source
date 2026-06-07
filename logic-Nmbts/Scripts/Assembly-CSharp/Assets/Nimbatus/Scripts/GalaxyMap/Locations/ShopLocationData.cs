using System;
using System.Collections.Generic;
using Assets.Nimbatus.GUI.MissionControl.Scripts;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.GalaxyMap.LocationSettings;
using Assets.Nimbatus.Scripts.GalaxyMap.Sectors;
using Assets.Nimbatus.Scripts.GalaxyMap.Shops;
using Assets.Nimbatus.Scripts.Missions;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Locations
{
	[Serializable]
	public class ShopLocationData : LocationData
	{
		public List<ShopInventoryItem> InventoryItems = new List<ShopInventoryItem>();

		public EMissionComplexity Difficulty;

		public void Init(ShopLocationSetting settings, Random randomGenerator, GalaxyMapSector sector, EMissionDifficulty difficulty, EMissionComplexity complexity)
		{
			Init((LocationSetting)settings, randomGenerator, sector, difficulty, complexity);
			Difficulty = complexity;
			InitInventory(randomGenerator);
		}

		public List<ShopInventoryItem> GetInventory()
		{
			if (InventoryItems.Count <= 0)
			{
				InitInventory();
			}
			return InventoryItems;
		}

		private void InitInventory(Random rnd = null)
		{
			if (rnd == null)
			{
				rnd = new Random(Guid.NewGuid().GetHashCode());
			}
			InventoryItems = ShopInventoryHelper.CreateBuyableItems((ShopLocationSetting)base.LocationSetting, rnd);
		}

		public override void LaunchDrone()
		{
		}

		public override void ApplyLocationSettings()
		{
			base.ApplyLocationSettings();
			MissionCompleted = true;
			ShopInventoryHelper.SetCurrentShop(this);
			NimbatusSceneManager.SetReturnScene("ShopLocationScene", "MissionControlScene");
			MissionControlNavigator.PageToLoad = EMissionControlPage.Main;
		}
	}
}
