using CTS.BBT;
using CTS.Core;
using CTS.StockInventory;
using UnityEngine;

namespace CTS
{
	public class StoreStock : BBTStock
	{
		[SerializeField]
		private StockItemSO[] _infiniteStock;

		[SerializeField]
		private StringKey<StockType>[] _wipeInventories;

		private void Start()
		{
			RefreshInfiniteStock();
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			BuyBasket.BasketBought += OnBasketBought;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			BuyBasket.BasketBought -= OnBasketBought;
		}

		private void OnBasketBought(ShopBasket.BasketValidation basketValidation)
		{
			RefreshInfiniteStock();
		}

		private void RefreshInfiniteStock()
		{
			StringKey<StockType>[] wipeInventories = _wipeInventories;
			foreach (StringKey<StockType> stockType in wipeInventories)
			{
				ClearInventory(stockType);
			}
			StockItemSO[] infiniteStock = _infiniteStock;
			foreach (StockItemSO stockItemSO in infiniteStock)
			{
				StockStack stackToAdd = new StockStack(stockItemSO, 1000000, 10f);
				TryAdd(stockItemSO.StockType, ref stackToAdd);
			}
		}
	}
}
