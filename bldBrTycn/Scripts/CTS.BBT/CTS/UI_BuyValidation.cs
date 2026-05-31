using System.Collections.Generic;
using CTS.Core;
using CTS.StockInventory;
using UnityEngine;

namespace CTS
{
	public class UI_BuyValidation : UI_StoreValidation<BuyBasket>
	{
		[SerializeField]
		private GameObject _waitingDelivery;

		private readonly List<StringKey<StockType>> _verifiedStockTypes = new List<StringKey<StockType>>();

		protected override void OnEnabled()
		{
			base.OnEnabled();
			MoneyHandler.MoneyAmountChanged += OnMoneyAmountChanged;
			base.Basket.BasketChanged += OnBuyBasketChanged;
			base.Basket.ValidationPriceChanged += OnBuyPriceChanged;
			Stocks.BarStock.StockChanged += OnStockChanged;
			Stocks.VendorStock.StockChanged += OnStockChanged;
			UpdateValidateButton();
			OnBuyPriceChanged(CTSSingleton<StoreBaskets>.Instance.BuyBasket.CurrentTotalPrice);
			Deliveries.DeliveryCompleted += CheckNumberOfCommand;
		}

		private void CheckNumberOfCommand(Delivery obj)
		{
			Debug.Log(MonoSingleton<Deliveries>.Instance.CurrentDeliveries.Count);
			UpdateValidateButton();
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			MoneyHandler.MoneyAmountChanged -= OnMoneyAmountChanged;
			BuyBasket basket = base.Basket;
			if ((bool)basket)
			{
				basket.BasketChanged -= OnBuyBasketChanged;
				basket.ValidationPriceChanged -= OnBuyPriceChanged;
			}
			Stocks.BarStock.StockChanged -= OnStockChanged;
			Stocks.VendorStock.StockChanged -= OnStockChanged;
			Deliveries.DeliveryCompleted -= CheckNumberOfCommand;
		}

		private void OnMoneyAmountChanged(int amount)
		{
			UpdateValidateButton();
		}

		private void OnBuyBasketChanged()
		{
			UpdateValidateButton();
		}

		private void OnStockChanged(StockInventory<StockStack, CTS.BBT.StockItemSO>.StockChangedData changedData)
		{
			UpdateValidateButton();
		}

		private void OnBuyPriceChanged(int price)
		{
			UpdateValidateButton();
			if (price <= 0)
			{
				EnableInfoText(active: false);
				return;
			}
			EnableInfoText(active: true);
			int fixedBuyPrice = base.Basket.GetFixedBuyPrice();
			price -= fixedBuyPrice;
			if (fixedBuyPrice != 0)
			{
				SetInfoText($"- ${price} (+ ${base.Basket.GetFixedBuyPrice()})");
			}
			else
			{
				SetInfoText($"- ${price}");
			}
		}

		private void UpdateValidateButton()
		{
			if (!CTSSingleton<StoreBaskets>.InstanceExists() || !MonoSingleton<MoneyHandler>.InstanceExists())
			{
				return;
			}
			if (MonoSingleton<Deliveries>.Instance.CurrentDeliveries.Count <= 2)
			{
				_waitingDelivery.SetActive(value: false);
				if (CTSSingleton<StoreBaskets>.Instance.BuyBasket.CurrentTotalPrice > MonoSingleton<MoneyHandler>.Instance.CurrentMoney)
				{
					_buttons.ValidateButton.interactable = false;
					return;
				}
				if (CTSSingleton<StoreBaskets>.Instance.BuyBasket.GetTotalCount() <= 0)
				{
					_buttons.ValidateButton.interactable = false;
					return;
				}
				_verifiedStockTypes.Clear();
				foreach (var (stockItemSO2, _) in CTSSingleton<StoreBaskets>.Instance.BuyBasket)
				{
					if (!_verifiedStockTypes.Contains(stockItemSO2.StockType))
					{
						_verifiedStockTypes.Add(stockItemSO2.StockType);
						int totalCount = CTSSingleton<StoreBaskets>.Instance.BuyBasket.GetTotalCount(stockItemSO2.StockType);
						if (!Stocks.BarStock.GetStockTypeCapacity(stockItemSO2.StockType).HasCapacityFor(totalCount))
						{
							_buttons.ValidateButton.interactable = false;
							return;
						}
					}
				}
				_buttons.ValidateButton.interactable = true;
			}
			else
			{
				_buttons.ValidateButton.interactable = false;
				_waitingDelivery.SetActive(value: true);
			}
		}
	}
}
