using System;
using System.Collections.Generic;
using Simulator.GameWorld;

namespace Simulator
{
	[Serializable]
	public class SaveClass_Products : ISaveClass
	{
		public List<int> licenses;

		public List<int> products;

		public List<float> prices;

		public List<PriceManager.ProductMarketHistory> marketHistories;

		public void StartSaveProcess()
		{
			licenses = new List<int>();
			products = new List<int>();
			prices = new List<float>();
			marketHistories = new List<PriceManager.ProductMarketHistory>();
		}

		public void SaveLicense(int productUID)
		{
			licenses.Add(productUID);
		}

		public void SaveProductPriceAndMarketHistories(int productUID, float price, PriceManager.ProductMarketHistory marketHistory)
		{
			products.Add(productUID);
			prices.Add(price);
			marketHistories.Add(marketHistory);
		}
	}
}
