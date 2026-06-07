using System;
using System.Collections.Generic;
using UnityEngine.Scripting;

namespace Gh.Tk
{
	[PersistenceIgnoreParent]
	[PersistenceOptIn]
	[InitializeOnGameStarted]
	public class EconomyController : SingletonMonoBehaviour<EconomyController>, IPersistable
	{
		public float travelDistanceBeforeGoodsBecomeExpensive;

		private const int _marketChangesEveryNthDay = 6;

		[PersistenceOptIn]
		private Dictionary<string, ShopItemDemand>[] _cachedMarketStatus;

		[PersistenceOptIn]
		private int _dayWhenMarketChanges;

		[PersistenceOptIn]
		private Dictionary<string, Dictionary<string, int>> _currentShopStock;

		[PersistenceOptIn]
		private int CurrentSeed { get; set; }

		private int NextSeed => 0;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void OnItemPurchased(object sender, EventArgs<(GameItemTemplate template, int amount)> e)
		{
		}

		private static void OnDayChanged(object sender, EventArgs e)
		{
		}

		private void OnDayChanged()
		{
		}

		public void InvalidateMarket()
		{
		}

		private void Start()
		{
		}

		public void Reset()
		{
		}

		private Dictionary<string, ShopItemDemand> GenerateDemand(int cyclesFromNow = 0)
		{
			return null;
		}

		public IEnumerable<GameItemTemplate> GetAllAvailableShopItems()
		{
			return null;
		}

		public Dictionary<string, ShopItemDemand> GetMarketStatus(int cyclesFromNow = 0)
		{
			return null;
		}

		public ShopItemDemand GetDemand(GameItemTemplate template, bool returnFutureDemand = false)
		{
			return default(ShopItemDemand);
		}

		public (ShopItemDemand, MarketTrend) GetDemandAndTrend(GameItemTemplate template)
		{
			return default((ShopItemDemand, MarketTrend));
		}

		public MarketTrend GetTrend(GameItemTemplate template)
		{
			return default(MarketTrend);
		}

		private void RecordItemPurchased(ShopMapMarker marker, GameItemTemplate template, int amount)
		{
		}

		public Dictionary<string, int> GetAvailableStock(ShopMapMarker marker)
		{
			return null;
		}

		public int GetFutureStockAmount(ShopMapMarker shop, GameItemTemplate template)
		{
			return 0;
		}

		private int GetStockAmountBeforePurchases(ShopMapMarker shop, GameItemTemplate template, bool returnFutureValue = false)
		{
			return 0;
		}

		public int GetPrice(ShopMapMarker shop, GameItemTemplate template, bool returnFuturePrice = false)
		{
			return 0;
		}

		private ShopItemPriceVariation ApplyMarketDemandToShopItemPriceVariation(ShopItemPriceVariation variation, GameItemTemplate template, bool returnFuturePriceVariation = false)
		{
			return default(ShopItemPriceVariation);
		}

		public ShopItemPriceVariation GetEffectivePriceVariation(ShopMapMarker shop, GameItemTemplate template, bool returnFuturePriceVariation = false)
		{
			return default(ShopItemPriceVariation);
		}

		private ShopItemPriceVariation GetPriceVariationWithoutDemand(ShopMapMarker shop, GameItemTemplate template)
		{
			return default(ShopItemPriceVariation);
		}

		public IEnumerable<GameItemTemplate> GetAvailableItems(ShopMapMarker shop)
		{
			return null;
		}

		public int GetDaysUntilMarketCycleStarts(int cycle)
		{
			return 0;
		}

		public int GetTargetMarketCycle(int xHoursFromNow)
		{
			return 0;
		}
	}
}
