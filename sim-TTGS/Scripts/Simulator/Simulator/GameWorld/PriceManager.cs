using System;
using System.Collections.Generic;
using UnityEngine;

namespace Simulator.GameWorld
{
	public static class PriceManager
	{
		[Serializable]
		public struct ProductMarketHistory
		{
			public float[] pastPrices;

			public ProductMarketHistory(float marketPrice)
			{
				pastPrices = new float[PriceSettings.MarketHistoryPastDaysToDisplay];
				pastPrices[0] = marketPrice;
				for (int i = 1; i < pastPrices.Length; i++)
				{
					pastPrices[i] = GetRandomFluctuatedPrice(marketPrice, pastPrices[i - 1]);
				}
			}

			public ProductMarketHistory(ProductMarketHistory history, float lastPrice)
			{
				pastPrices = new float[history.pastPrices.Length + 1];
				pastPrices[0] = lastPrice;
				for (int i = 0; i < history.pastPrices.Length; i++)
				{
					pastPrices[i + 1] = history.pastPrices[i];
					if (pastPrices.Length == PriceSettings.MarketHistoryPastDaysToDisplay)
					{
						break;
					}
				}
			}

			public static float GetRandomFluctuatedPrice(float referenceMarketPrice, float currentMarketPrice)
			{
				float num = UnityEngine.Random.Range(PriceSettings.MarketFluctuationPerDay.x, PriceSettings.MarketFluctuationPerDay.y);
				return Mathf.Clamp(currentMarketPrice * (1f + num * 0.01f), referenceMarketPrice * (1f + PriceSettings.MarketFluctuationExtremes.x * 0.01f), referenceMarketPrice * (1f + PriceSettings.MarketFluctuationExtremes.y * 0.01f));
			}
		}

		private static HashSet<int> _unlockedLicenses = new HashSet<int>();

		private static Dictionary<int, float> _productPrices = new Dictionary<int, float>();

		private static Dictionary<int, ProductMarketHistory> _productHistories = new Dictionary<int, ProductMarketHistory>();

		private static Dictionary<int, float> _productAveragePrices = new Dictionary<int, float>();

		public static event Action<int> LicenseUnlocked;

		public static event Action<int, float> PriceChanged;

		public static event Action MarketPricesChanged;

		public static void Load()
		{
			_unlockedLicenses.Clear();
			List<int> licenses = SaveManager.CurrentSave.products.licenses;
			if (licenses.IsValid())
			{
				foreach (int item in licenses)
				{
					_unlockedLicenses.Add(item);
				}
			}
			_productPrices.Clear();
			_productHistories.Clear();
			List<int> products = SaveManager.CurrentSave.products.products;
			List<float> prices = SaveManager.CurrentSave.products.prices;
			List<ProductMarketHistory> marketHistories = SaveManager.CurrentSave.products.marketHistories;
			if (products.IsValid() && prices.IsValid())
			{
				for (int i = 0; i < products.Count; i++)
				{
					_productPrices.Add(products[i], prices[i]);
					_productHistories.Add(products[i], marketHistories[i]);
				}
			}
		}

		public static void Save()
		{
			SaveManager.CurrentSave.products.StartSaveProcess();
			foreach (int unlockedLicense in _unlockedLicenses)
			{
				SaveManager.CurrentSave.products.SaveLicense(unlockedLicense);
			}
			foreach (var (productUID, price) in _productPrices)
			{
				SaveManager.CurrentSave.products.SaveProductPriceAndMarketHistories(productUID, price, GetProductMarketHistory(productUID));
			}
		}

		public static bool IsLicenseUnlocked(int productUID)
		{
			return _unlockedLicenses.Contains(productUID);
		}

		public static bool TryGetProductPrice(int productUID, out float price)
		{
			if (_productPrices.TryGetValue(productUID, out price))
			{
				return true;
			}
			price = 0f;
			return false;
		}

		public static float GetProductPrice(int productUID)
		{
			if (_productPrices.TryGetValue(productUID, out var value))
			{
				return value;
			}
			return -1f;
		}

		public static float GetProductMarketPrice(int productUID)
		{
			return GetProductMarketHistory(productUID).pastPrices[0];
		}

		public static float GetProductAveragePrice(int productUID)
		{
			if (_productAveragePrices.TryGetValue(productUID, out var value) && value > 0f)
			{
				return value;
			}
			value = ComputeAverageMarketStorePrice(productUID);
			_productAveragePrices[productUID] = value;
			return value;
		}

		public static ProductMarketHistory GetProductMarketHistory(int productUID)
		{
			if (_productHistories.TryGetValue(productUID, out var value))
			{
				return value;
			}
			if (ProductDatabase.TryGet(productUID, out var productData))
			{
				value = new ProductMarketHistory(productData.MarketPrice);
				_productHistories[productUID] = value;
				return value;
			}
			return new ProductMarketHistory(0f);
		}

		public static void UnlockLicense(int productUID)
		{
			_unlockedLicenses.Add(productUID);
			PriceManager.LicenseUnlocked?.Invoke(productUID);
		}

		public static void SetPrice(int productUID, float price)
		{
			_productPrices[productUID] = price;
			PriceManager.PriceChanged?.Invoke(productUID, price);
		}

		public static float ClampPrice(float marketPrice, float currentPrice)
		{
			float min = marketPrice * PriceSettings.GetMinPriceMultiplier();
			float max = marketPrice * PriceSettings.GetMaxPriceMultiplier();
			return Mathf.Clamp(currentPrice, min, max);
		}

		public static void UpdateMarketPrices()
		{
			foreach (var (num2, history) in new Dictionary<int, ProductMarketHistory>(_productHistories))
			{
				if (ProductDatabase.TryGet(num2, out var productData))
				{
					float randomFluctuatedPrice = ProductMarketHistory.GetRandomFluctuatedPrice(productData.MarketPrice, history.pastPrices[0]);
					ProductMarketHistory value = new ProductMarketHistory(history, randomFluctuatedPrice);
					_productHistories[num2] = value;
				}
			}
			PriceManager.MarketPricesChanged?.Invoke();
		}

		private static float ComputeAverageMarketStorePrice(int productUID)
		{
			float num = 0f;
			int num2 = 0;
			foreach (ProductShopBoxData item in MarketStoreDatabase.Enumerate<ProductShopBoxData>())
			{
				if (item != null)
				{
					ProductData product = item.Product;
					if (product != null && product.UID == productUID)
					{
						num += World.MarketStore.GetDataPrice(item) / (float)item.Quantity;
						num2++;
					}
				}
			}
			if (num2 > 0)
			{
				return num / (float)num2;
			}
			return 0f;
		}

		public static float GetFurnitureMarketStorePrice(int furnitureUID)
		{
			foreach (FurnitureShopBoxData item in MarketStoreDatabase.Enumerate<FurnitureShopBoxData>())
			{
				if (item != null && item.Furniture != null && item.Furniture.UID == furnitureUID)
				{
					return item.Price;
				}
			}
			return 0f;
		}

		public static void Clear()
		{
			_unlockedLicenses.Clear();
			_productPrices.Clear();
			_productAveragePrices.Clear();
			_productHistories.Clear();
		}
	}
}
