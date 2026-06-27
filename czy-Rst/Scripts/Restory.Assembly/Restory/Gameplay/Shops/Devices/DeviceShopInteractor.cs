using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.Devices.Condition;
using Restory.Gameplay.Delivery;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.Inventory;
using Restory.Gameplay.Statistics;
using Restory.Gameplay.WorkOrders.EmailOrders;
using Zenject;

namespace Restory.Gameplay.Shops.Devices
{
	public class DeviceShopInteractor : IDisposable
	{
		private readonly DeviceShoppingCart shoppingCart = new DeviceShoppingCart();

		private readonly Wallet wallet;

		private readonly DeliveryService deliveryService;

		private readonly ShopsService shopsService;

		private readonly GameStatisticsService gameStatistics;

		public IReadOnlyList<ILot> LotsInShoppingCart => shoppingCart.LotsInCart;

		[Inject]
		public DeviceShopInteractor(Wallet wallet, DeliveryService deliveryService, GameStatisticsService gameStatistics, ShopsService shopsService)
		{
			this.wallet = wallet;
			this.deliveryService = deliveryService;
			this.gameStatistics = gameStatistics;
			this.shopsService = shopsService;
		}

		public bool TryToAddLotToShoppingCart(ILot lot)
		{
			return shoppingCart.TryAddToCart(lot);
		}

		public bool TryToRemoveLotFromShoppingCart(ILot lot)
		{
			return shoppingCart.TryRemoveFromCart(lot);
		}

		public bool ContainsLotInShoppingCart(ILot lot)
		{
			return shoppingCart.LotsInCart.Contains(lot);
		}

		public int GetTotalCostOfLotsInShoppingCart()
		{
			return shoppingCart.GetTotalCost();
		}

		public bool TryToBuyAllLotsFromShoppingCart()
		{
			int totalCost = shoppingCart.GetTotalCost();
			if (!wallet.TryToRemove(totalCost))
			{
				return false;
			}
			foreach (ILot item in shoppingCart.LotsInCart)
			{
				if (!(item is IDeviceShopLot { Device: var device }))
				{
					if (!(item is IElementsBoxLot elementsBoxLot))
					{
						throw new NotImplementedException();
					}
					if (elementsBoxLot.BoxData?.Elements != null)
					{
						deliveryService.SendToDelivery(elementsBoxLot.BoxData);
					}
				}
				else if (!(device is DeviceCondition objectInfo))
				{
					if (!(device is RandomlyGeneratedDeviceCondition randomlyGeneratedDeviceCondition))
					{
						throw new NotImplementedException();
					}
					deliveryService.SendToDelivery(randomlyGeneratedDeviceCondition, new GeneratedDeviceProperty(randomlyGeneratedDeviceCondition.ID, randomlyGeneratedDeviceCondition.DeviceInfo.DefaultPrice));
				}
				else
				{
					deliveryService.SendToDelivery(objectInfo);
				}
				shopsService.RemoveDeviceFromShop(item);
			}
			shoppingCart.Clear();
			gameStatistics.ProcessDevicesPurchasedInShop(totalCost);
			return true;
		}

		public void ClearShoppingCart()
		{
			shoppingCart.Clear();
		}

		public void Dispose()
		{
			ClearShoppingCart();
		}
	}
}
