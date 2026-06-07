using System;

namespace Simulator.GameWorld
{
	public static class ShopExtensionSystem
	{
		public static int ShopExtensionLevel { get; private set; }

		public static int ReserveExtensionLevel { get; private set; }

		public static event Action<int> ShopExtensionBought;

		public static event Action<int> ReserveExtensionBought;

		public static event Action ShopStructureModified;

		public static void BuyNextShopExtension()
		{
			ShopExtensionLevel = ShopExtensionSettings.GetNextShopExtensionLevel(ShopExtensionLevel);
			ShopExtensionSystem.ShopExtensionBought?.Invoke(ShopExtensionLevel);
			OnShopStructureModified();
			switch (ShopExtensionSettings.GetShopExtensionMarketStoreLevel(ShopExtensionLevel))
			{
			case 1:
				ESteamAchievement.SHOP_EXT.Trigger();
				break;
			case 5:
				ESteamAchievement.SHOP_EXT_5.Trigger();
				break;
			case 10:
				ESteamAchievement.SHOP_EXT_10.Trigger();
				break;
			}
		}

		public static void SetShopExtensionLevel(int level, bool triggerCallback = false)
		{
			ShopExtensionLevel = level;
			ShopExtensionSystem.ShopExtensionBought?.Invoke(ShopExtensionLevel);
			if (triggerCallback)
			{
				OnShopStructureModified();
			}
		}

		public static void BuyNextReserveExtension()
		{
			ReserveExtensionLevel = ShopExtensionSettings.GetNextReserveExtensionLevel(ReserveExtensionLevel);
			ShopExtensionSystem.ReserveExtensionBought?.Invoke(ReserveExtensionLevel);
			OnShopStructureModified();
			switch (ShopExtensionSettings.GetReserveExtensionMarketStoreLevel(ReserveExtensionLevel))
			{
			case 1:
				ESteamAchievement.RESERVE_EXT.Trigger();
				break;
			case 5:
				ESteamAchievement.RESERVE_EXT_5.Trigger();
				break;
			case 10:
				ESteamAchievement.RESERVE_EXT_10.Trigger();
				break;
			}
		}

		public static void SetReserveExtensionLevel(int level, bool triggerCallback = false)
		{
			ReserveExtensionLevel = level;
			ShopExtensionSystem.ReserveExtensionBought?.Invoke(ReserveExtensionLevel);
			if (triggerCallback)
			{
				OnShopStructureModified();
			}
		}

		private static void OnShopStructureModified()
		{
			ShopExtensionSystem.ShopStructureModified?.Invoke();
		}

		public static void Load()
		{
			SetShopExtensionLevel(SaveManager.CurrentSave.shop.shopExtensionLevel);
			SetReserveExtensionLevel(SaveManager.CurrentSave.shop.reserveExtensionLevel);
			OnShopStructureModified();
		}

		public static void Save()
		{
			SaveManager.CurrentSave.shop.shopExtensionLevel = ShopExtensionLevel;
			SaveManager.CurrentSave.shop.reserveExtensionLevel = ReserveExtensionLevel;
		}

		public static void SendAnalytics()
		{
			GameAnalytics.NewDesignEvent("id_analytics_shop_extension", ShopExtensionLevel);
			GameAnalytics.NewDesignEvent("id_analytics_shop_reserveextension", ReserveExtensionLevel);
		}
	}
}
