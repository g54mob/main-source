using System.Collections.Generic;
using System.Linq;
using Restory.Data.Shops.HomeDepot;

namespace Restory.Gameplay.Shops.HomeDepot
{
	public class HomeDepotShoppingCart
	{
		private readonly Dictionary<HomeDepotShopItemData, int> productsCountInCart = new Dictionary<HomeDepotShopItemData, int>();

		public IReadOnlyCollection<HomeDepotShopItemData> AllItemsInCart => productsCountInCart.Keys;

		public IReadOnlyDictionary<HomeDepotShopItemData, int> CartContents => productsCountInCart;

		public void SetItemCountInCart(HomeDepotShopItemData shopDecorItem, int countToSet)
		{
			if (countToSet <= 0)
			{
				productsCountInCart.Remove(shopDecorItem);
			}
			else if (!productsCountInCart.TryAdd(shopDecorItem, countToSet))
			{
				productsCountInCart[shopDecorItem] = countToSet;
			}
		}

		public void AddToCart(HomeDepotShopItemData shopDecorItem, int countToAdd = 1)
		{
			if (!productsCountInCart.TryAdd(shopDecorItem, countToAdd))
			{
				productsCountInCart[shopDecorItem] += countToAdd;
			}
		}

		public void RemoveFromCart(HomeDepotShopItemData shopDecorItem, int countToRemove = 1)
		{
			if (productsCountInCart.TryGetValue(shopDecorItem, out var value))
			{
				productsCountInCart[shopDecorItem] = value - countToRemove;
				if (productsCountInCart[shopDecorItem] <= 0)
				{
					productsCountInCart.Remove(shopDecorItem);
				}
			}
		}

		public void RemoveWholeItemFromCart(HomeDepotShopItemData shopDecorItem)
		{
			productsCountInCart.Remove(shopDecorItem);
		}

		public int GetCountInCart(HomeDepotShopItemData shopDecorItem)
		{
			return productsCountInCart.GetValueOrDefault(shopDecorItem, 0);
		}

		public int GetTotalCountInCart()
		{
			return productsCountInCart.Values.Sum();
		}

		public int GetTotalCost()
		{
			return productsCountInCart.Sum((KeyValuePair<HomeDepotShopItemData, int> keyValuePair) => keyValuePair.Key.Price * keyValuePair.Value);
		}

		public void Clear()
		{
			productsCountInCart.Clear();
		}
	}
}
