using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.GalaxyMap.LocationSettings;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Receivables;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Shops
{
	public static class ShopInventoryHelper
	{
		private static ShopLocationData _currentShop;

		public static void SetCurrentShop(ShopLocationData shop)
		{
			_currentShop = shop;
		}

		private static ShopLocationSetting GetRandomShop(Random rnd)
		{
			ShopLocationSetting obj = SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.LocationSettings.Where((LocationSetting l) => l is ShopLocationSetting).ToList().RandomItem(rnd) as ShopLocationSetting;
			if (obj == null)
			{
				throw new Exception("No ShopLocationSetting found");
			}
			return obj;
		}

		public static List<ShopInventoryItem> GetBuyableItems()
		{
			if (_currentShop != null)
			{
				return _currentShop.GetInventory();
			}
			Random rnd = new Random(Guid.NewGuid().GetHashCode());
			return CreateBuyableItems(GetRandomShop(rnd), rnd);
		}

		public static List<ShopInventoryItem> CreateBuyableItems(ShopLocationSetting shop, Random rnd)
		{
			List<ShopInventoryItem> list = new List<ShopInventoryItem>();
			for (int i = 0; i < shop.ItemCount; i++)
			{
				ShopInventoryItem inventoryItem = shop.GetInventoryItem(rnd.Next(), rnd.Next(), SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.GetActiveMissionComplexity());
				if (ReceivableHelper.IsAllowed(inventoryItem.Item))
				{
					list.Add(inventoryItem);
				}
			}
			return list;
		}
	}
}
