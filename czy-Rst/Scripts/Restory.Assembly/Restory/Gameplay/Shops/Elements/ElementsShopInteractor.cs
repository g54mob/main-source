using System.Collections.Generic;
using Restory.Data.Devices;
using Restory.Data.Elements.Condition;
using Restory.Data.Shops.Elements;
using Restory.Gameplay.Delivery;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Inventory;
using Restory.Gameplay.Licenses;
using Restory.Gameplay.Statistics;
using UnityEngine;

namespace Restory.Gameplay.Shops.Elements
{
	public class ElementsShopInteractor
	{
		private readonly ElementsShoppingCart shoppingCart;

		private readonly LicensesService licensesService;

		private readonly Wallet wallet;

		private readonly ElementConditionBase defaultElementCondition;

		private readonly GameStatisticsService gameStatistics;

		private readonly DeliveryService deliveryService;

		private readonly ElementsShopService elementsShopService;

		public IDeviceCategory PreferableDeviceCategory { get; set; }

		public IReadOnlyCollection<ElementsShopItemData> AllItemsInShoppingCart => shoppingCart.AllItemsInCart;

		public IReadOnlyCollection<LicenseShopItemData> AllLicensesInShoppingCart => shoppingCart.AllLicensesInCart;

		public ElementsShopInteractor(LicensesService licensesService, DeliveryService deliveryService, Wallet wallet, GameStatisticsService gameStatistics, ElementConditionBase defaultElementCondition, ElementsShopService elementsShopService)
		{
			this.wallet = wallet;
			this.licensesService = licensesService;
			this.defaultElementCondition = defaultElementCondition;
			this.gameStatistics = gameStatistics;
			this.deliveryService = deliveryService;
			this.elementsShopService = elementsShopService;
			shoppingCart = new ElementsShoppingCart(elementsShopService);
		}

		public bool TryToAddLicenseToShoppingCart(LicenseShopItemData licenseShopItemData)
		{
			return shoppingCart.TryAddToCart(licenseShopItemData);
		}

		public bool TryToRemoveLicenseFromShoppingCart(LicenseShopItemData licenseShopItemData)
		{
			return shoppingCart.TryRemoveFromCart(licenseShopItemData);
		}

		public void SetItemCountInShoppingCart(ElementsShopItemData shopItem, int countToSet)
		{
			shoppingCart.SetItemCountInCart(shopItem, countToSet);
		}

		public void RemoveWholeItemFromShoppingCart(ElementsShopItemData shopItem)
		{
			shoppingCart.RemoveWholeItemFromCart(shopItem);
		}

		public int GetItemCountInShoppingCart(ElementsShopItemData shopItem)
		{
			return shoppingCart.GetCountInCart(shopItem);
		}

		public int GetTotalItemsCountInShoppingCart()
		{
			return shoppingCart.GetTotalCountInCart();
		}

		public int GetAvailableTotalItemsCountInShoppingCart()
		{
			return shoppingCart.GetAvailableTotalCountInCart();
		}

		public int GetTotalItemsCostInShoppingCart()
		{
			return shoppingCart.GetTotalCost();
		}

		public int GetAvailableTotalItemsCostInShoppingCart()
		{
			return shoppingCart.GetAvailableTotalCost();
		}

		public void ClearShoppingCart()
		{
			shoppingCart.Clear();
		}

		public bool TryToBuyAllItemsFromShoppingCart()
		{
			int availableTotalCost = shoppingCart.GetAvailableTotalCost();
			if (!wallet.TryToRemove(availableTotalCost))
			{
				return false;
			}
			int num = 0;
			int num2 = 0;
			foreach (var (elementsShopItemData2, num4) in shoppingCart.CartContents)
			{
				if (!elementsShopItemData2.IsInStock)
				{
					Debug.LogWarning(elementsShopItemData2.Element.ID + " cannot be bought - out of stock!");
					continue;
				}
				ElementData elementData = new ElementData
				{
					Info = elementsShopItemData2.Element,
					Condition = defaultElementCondition
				};
				deliveryService.SendToDelivery(elementData, num4);
				num += elementsShopItemData2.Price * num4;
			}
			foreach (LicenseShopItemData item in shoppingCart.AllLicensesInCart)
			{
				if (!licensesService.Contains(item.License))
				{
					deliveryService.SendToDelivery(item.License);
					licensesService.Add(item.License);
					num2 += elementsShopService.CalculatePrice(item);
					PreferableDeviceCategory = item.License.DeviceInfo.Category;
				}
			}
			shoppingCart.Clear();
			gameStatistics.ProcessElementsPurchasedInShop(num);
			gameStatistics.ProcessLicensesPurchasedInShop(num2);
			return true;
		}
	}
}
