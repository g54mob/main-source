using System.Collections.Generic;
using System.Linq;
using Restory.Data.Shops.Elements;

namespace Restory.Gameplay.Shops.Elements
{
	public class ElementsShoppingCart
	{
		private readonly Dictionary<ElementsShopItemData, int> productsCountInCart = new Dictionary<ElementsShopItemData, int>();

		private readonly List<LicenseShopItemData> licensesInCart = new List<LicenseShopItemData>();

		private readonly ElementsShopService elementsShopService;

		public IReadOnlyCollection<ElementsShopItemData> AllItemsInCart => productsCountInCart.Keys;

		public IReadOnlyList<LicenseShopItemData> AllLicensesInCart => licensesInCart;

		public IReadOnlyCollection<KeyValuePair<ElementsShopItemData, int>> CartContents => productsCountInCart;

		public ElementsShoppingCart(ElementsShopService elementsShopService)
		{
			this.elementsShopService = elementsShopService;
		}

		public bool TryAddToCart(LicenseShopItemData licenceShopItemData)
		{
			if (licensesInCart.Contains(licenceShopItemData))
			{
				return false;
			}
			licensesInCart.Add(licenceShopItemData);
			return true;
		}

		public bool TryRemoveFromCart(LicenseShopItemData licenceShopItemData)
		{
			return licensesInCart.Remove(licenceShopItemData);
		}

		public void SetItemCountInCart(ElementsShopItemData shopItem, int countToSet)
		{
			if (countToSet <= 0)
			{
				productsCountInCart.Remove(shopItem);
			}
			else if (!productsCountInCart.TryAdd(shopItem, countToSet))
			{
				productsCountInCart[shopItem] = countToSet;
			}
		}

		public void AddToCart(ElementsShopItemData shopItem, int countToAdd = 1)
		{
			if (!productsCountInCart.TryAdd(shopItem, countToAdd))
			{
				productsCountInCart[shopItem] += countToAdd;
			}
		}

		public void RemoveFromCart(ElementsShopItemData shopItem, int countToRemove = 1)
		{
			if (productsCountInCart.TryGetValue(shopItem, out var value))
			{
				productsCountInCart[shopItem] = value - countToRemove;
				if (productsCountInCart[shopItem] <= 0)
				{
					productsCountInCart.Remove(shopItem);
				}
			}
		}

		public void RemoveWholeItemFromCart(ElementsShopItemData shopItem)
		{
			productsCountInCart.Remove(shopItem);
		}

		public int GetCountInCart(ElementsShopItemData shopItem)
		{
			return productsCountInCart.GetValueOrDefault(shopItem, 0);
		}

		public int GetTotalCountInCart()
		{
			return productsCountInCart.Select((KeyValuePair<ElementsShopItemData, int> p) => p.Value).Sum() + licensesInCart.Count;
		}

		public int GetAvailableTotalCountInCart()
		{
			return (from p in productsCountInCart
				where p.Key.IsInStock
				select p.Value).Sum() + licensesInCart.Count;
		}

		public int GetTotalCost()
		{
			return productsCountInCart.Sum((KeyValuePair<ElementsShopItemData, int> keyValuePair) => keyValuePair.Key.Price * keyValuePair.Value) + licensesInCart.Sum((LicenseShopItemData licence) => elementsShopService.CalculatePrice(licence));
		}

		public int GetAvailableTotalCost()
		{
			return productsCountInCart.Where((KeyValuePair<ElementsShopItemData, int> p) => p.Key.IsInStock).Sum((KeyValuePair<ElementsShopItemData, int> keyValuePair) => keyValuePair.Key.Price * keyValuePair.Value) + licensesInCart.Sum((LicenseShopItemData licence) => elementsShopService.CalculatePrice(licence));
		}

		public void Clear()
		{
			productsCountInCart.Clear();
			licensesInCart.Clear();
		}
	}
}
