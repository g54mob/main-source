using System;
using System.Collections.Generic;
using Restory.Data.Shops.HomeDepot;
using Restory.Gameplay.Delivery;
using Restory.Gameplay.Inventory;
using Restory.Gameplay.Statistics;

namespace Restory.Gameplay.Shops.HomeDepot
{
	public class HomeDepotShopInteractor
	{
		private readonly HomeDepotShoppingCart shoppingCart = new HomeDepotShoppingCart();

		private readonly Wallet wallet;

		private readonly DeliveryService deliveryService;

		private readonly GameStatisticsService gameStatistics;

		public IReadOnlyCollection<HomeDepotShopItemData> AllItemsInShoppingCart => shoppingCart.AllItemsInCart;

		public event Action<HomeDepotShopItemData> OnHomeDepotItemPurchased;

		public HomeDepotShopInteractor(Wallet wallet, DeliveryService deliveryService, GameStatisticsService gameStatistics)
		{
			this.wallet = wallet;
			this.deliveryService = deliveryService;
			this.gameStatistics = gameStatistics;
		}

		public void SetItemCountInShoppingCart(HomeDepotShopItemData shopDecorItem, int countToSet)
		{
			shoppingCart.SetItemCountInCart(shopDecorItem, countToSet);
		}

		public void RemoveWholeItemFromShoppingCart(HomeDepotShopItemData shopDecorItem)
		{
			shoppingCart.RemoveWholeItemFromCart(shopDecorItem);
		}

		public int GetItemCountInShoppingCart(HomeDepotShopItemData shopDecorItem)
		{
			return shoppingCart.GetCountInCart(shopDecorItem);
		}

		public int GetTotalItemsCountInShoppingCart()
		{
			return shoppingCart.GetTotalCountInCart();
		}

		public int GetTotalItemsCostInShoppingCart()
		{
			return shoppingCart.GetTotalCost();
		}

		public void ClearShoppingCart()
		{
			shoppingCart.Clear();
		}

		public bool TryToBuyAllItemsFromShoppingCart()
		{
			int totalCost = shoppingCart.GetTotalCost();
			if (!wallet.TryToRemove(totalCost))
			{
				return false;
			}
			int num = 0;
			int num2 = 0;
			foreach (KeyValuePair<HomeDepotShopItemData, int> cartContent in shoppingCart.CartContents)
			{
				HomeDepotShopItemData key = cartContent.Key;
				if (!(key is HomeDepotShopDecorItemData homeDepotShopDecorItemData))
				{
					if (!(key is HomeDepotShopCleaningToolItemData homeDepotShopCleaningToolItemData))
					{
						if (!(key is HomeDepotShopPcAppItemData homeDepotShopPcAppItemData))
						{
							if (!(key is HomeDepotShopPaintingPaletteItemData homeDepotShopPaintingPaletteItemData))
							{
								throw new NotImplementedException();
							}
							deliveryService.SendToDelivery(homeDepotShopPaintingPaletteItemData.Palette);
							num2 += homeDepotShopPaintingPaletteItemData.Price * cartContent.Value;
						}
						else
						{
							deliveryService.SendToDelivery(homeDepotShopPcAppItemData.Info);
							num += homeDepotShopPcAppItemData.Price;
						}
					}
					else
					{
						for (int i = 0; i < cartContent.Value; i++)
						{
							deliveryService.SendToDelivery(homeDepotShopCleaningToolItemData.ToolInfo);
						}
						num += homeDepotShopCleaningToolItemData.Price * cartContent.Value;
					}
				}
				else
				{
					for (int j = 0; j < cartContent.Value; j++)
					{
						deliveryService.SendToDelivery(homeDepotShopDecorItemData.DecorInfo);
					}
					num2 += homeDepotShopDecorItemData.Price * cartContent.Value;
				}
				this.OnHomeDepotItemPurchased?.Invoke(cartContent.Key);
			}
			shoppingCart.Clear();
			gameStatistics.ProcessCleaningToolsPurchasedInShop(num);
			gameStatistics.ProcessDecorItemsPurchasedInShop(num2);
			return true;
		}
	}
}
