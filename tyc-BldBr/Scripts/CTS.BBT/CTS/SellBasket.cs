using System;
using System.Collections.Generic;
using CTS.BBT;
using CTS.BBT.Handlers.Transactions;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class SellBasket : ShopBasket
	{
		public static event Action<int> StockSold;

		protected override int GetUnitPrice(StockItemSO itemData, float quality)
		{
			return Mathf.FloorToInt((float)base.GetUnitPrice(itemData, quality) * itemData.SellPriceMultiplier);
		}

		public override bool IsAtMaximumCapacity(StockItemSO itemData)
		{
			int count = GetCount(itemData);
			int stockedCount = _stock.GetStockedCount(itemData);
			return count >= stockedCount;
		}

		public override BasketValidation OnValidateBasket()
		{
			EventsManager.ChangeMoney(Currencies.Dollars, base.CurrentTotalPrice);
			MonoSingleton<TransactionsHandlers>.Instance.AddNewData(TransactionType.Income, base.CurrentTotalPrice, TransactionTag.OtherSale);
			SellBasket.StockSold?.Invoke(base.CurrentTotalPrice);
			StockStack[] basketValidationAlloc = ShopBasket.GetBasketValidationAlloc(GetDifferentItemCount());
			BasketValidation result = default(BasketValidation);
			int num = 0;
			using (Dictionary<StockItemSO, int>.Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					var (stockItemSO2, count) = (KeyValuePair<StockItemSO, int>)(ref enumerator.Current);
					_stock.RetrieveStock(stockItemSO2, count, ShopBasket._stackRetriever, canGetLessThanCount: true);
					StockStack stockStack = default(StockStack);
					stockStack.SetupEmptyFrom(stockItemSO2);
					foreach (StockStack item in ShopBasket._stackRetriever)
					{
						StockStack stack = item;
						stockStack.AddStack(ref stack);
					}
					if (stockStack.StackCount > 0)
					{
						basketValidationAlloc[num] = stockStack;
						num++;
					}
				}
			}
			ClearBasket();
			result.StockValidated = new ReadOnlyMemory<StockStack>(basketValidationAlloc, 0, num);
			return result;
		}
	}
}
