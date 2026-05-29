using System;
using CTS.BBT;
using CTS.BBT.Handlers.Transactions;
using CTS.Core;
using CTS.StockInventory;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class BuyBasket : ShopBasket
	{
		[SerializeField]
		private BBTStock _barStock;

		[SerializeField]
		private int _fixedBuyPrice = 100;

		[SerializeField]
		[Inject(false)]
		[BoxGroup("References")]
		private Deliveries _deliveries;

		public static event Action<BasketValidation> BasketBought;

		public int GetFixedBuyPrice()
		{
			return _fixedBuyPrice;
		}

		protected override int CalculatePrice()
		{
			int num = base.CalculatePrice();
			if (num > 0)
			{
				num += _fixedBuyPrice;
			}
			return num;
		}

		public override bool IsAtMaximumCapacity(StockItemSO itemData)
		{
			StockCapacity stockTypeCapacity = _barStock.GetStockTypeCapacity(itemData.StockType);
			int count = GetCount(itemData);
			int stockedCount = _stock.GetStockedCount(itemData);
			if (count < 100000 && stockTypeCapacity.HasCapacityFor(count + 1))
			{
				return count >= stockedCount;
			}
			return true;
		}

		public override BasketValidation OnValidateBasket()
		{
			EventsManager.ChangeMoney(Currencies.Dollars, -base.CurrentTotalPrice);
			MonoSingleton<TransactionsHandlers>.Instance.AddNewData(TransactionType.Expense, base.CurrentTotalPrice, TransactionTag.Grocery);
			StockStack[] basketValidationAlloc = ShopBasket.GetBasketValidationAlloc(GetDifferentItemCount());
			BasketValidation basketValidation = default(BasketValidation);
			int num = 0;
			StockItemSO itemData;
			int count;
			while (TryGet(out itemData, out count))
			{
				_stock.RetrieveStock(itemData, count, ShopBasket._stackRetriever);
				StockStack stockStack = default(StockStack);
				stockStack.SetupEmptyFrom(itemData);
				foreach (StockStack item in ShopBasket._stackRetriever)
				{
					StockStack stack = item;
					stockStack.AddStack(ref stack);
				}
				if (stockStack.StackCount > 0)
				{
					basketValidationAlloc[num] = stockStack;
					num++;
					_deliveries.CreateDeliveries(ShopBasket._stackRetriever);
				}
			}
			basketValidation.StockValidated = new ReadOnlyMemory<StockStack>(basketValidationAlloc, 0, num);
			ClearBasket();
			BuyBasket.BasketBought?.Invoke(basketValidation);
			return basketValidation;
		}
	}
}
