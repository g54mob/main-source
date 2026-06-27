using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.Shops.Elements;
using Restory.Gameplay.Inventory;
using Restory.Gameplay.Shops.Elements;
using Restory.ObjectPools;
using Restory.TimeSystems;
using Restory.UI.Pools.Shops.Elements;
using Restory.UI.Views.Shops.Elements;
using Sirenix.Utilities;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.Shops.Elements
{
	public sealed class GUI_ElementsShopCartPanel : MonoBehaviour
	{
		[SerializeField]
		private GUI_ElementsShopCartPanelView view;

		private ElementsShopCartPanelElementsUiPool cartPanelElementsUiPool;

		private GUI_LicenseShopElementCustomPool licenseShopElementPool;

		private Wallet wallet;

		private MainDayTimeSwitchingService mainDayTimeSwitchingService;

		private ElementsShopInteractor shopInteractor;

		private readonly List<GUI_ElementsShopCartPanelElement> productsPresenters = new List<GUI_ElementsShopCartPanelElement>();

		private readonly List<GUI_LicenseShopItem> licenseShopItems = new List<GUI_LicenseShopItem>();

		public event Action OnExitCartButtonClicked;

		[Inject]
		public void Construct(ElementsShopCartPanelElementsUiPool cartPanelElementsUiPool, GUI_LicenseShopElementCustomPool licenseShopElementPool, Wallet wallet, MainDayTimeSwitchingService mainDayTimeSwitchingService)
		{
			this.cartPanelElementsUiPool = cartPanelElementsUiPool;
			this.licenseShopElementPool = licenseShopElementPool;
			this.wallet = wallet;
			this.mainDayTimeSwitchingService = mainDayTimeSwitchingService;
		}

		public void SetShop(ElementsShopInteractor shop)
		{
			shopInteractor = shop;
		}

		public void Show()
		{
			foreach (ElementsShopItemData item2 in shopInteractor.AllItemsInShoppingCart)
			{
				GUI_ElementsShopCartPanelElement gUI_ElementsShopCartPanelElement = cartPanelElementsUiPool.Get<GUI_ElementsShopCartPanelElement>();
				gUI_ElementsShopCartPanelElement.Init(item2, shopInteractor.GetItemCountInShoppingCart(item2));
				gUI_ElementsShopCartPanelElement.OnIncreaseCountInCartButtonClicked += ResolveIncreaseCountInCartButtonClicked;
				gUI_ElementsShopCartPanelElement.OnDecreaseCountInCartButtonClicked += ResolveDecreaseCountInCartButtonClicked;
				gUI_ElementsShopCartPanelElement.OnRemoveFromCartButtonClicked += ResolveRemoveFromCartButtonClicked;
				gUI_ElementsShopCartPanelElement.OnInputValueChanged += ResolveInputValueChanged;
				gUI_ElementsShopCartPanelElement.OnIsInStockChanged += ResolveOnIsInStockChanged;
				productsPresenters.Add(gUI_ElementsShopCartPanelElement);
			}
			foreach (LicenseShopItemData item3 in shopInteractor.AllLicensesInShoppingCart)
			{
				GUI_LicenseShopItem item = licenseShopElementPool.GetItem(item3.License);
				item.Init(item3, isSelected: true, insufficientFunds: false);
				item.OnRemoveFromCartButtonClicked += ResolveRemoveLicenseFromCartButtonClicked;
				licenseShopItems.Add(item);
			}
			view.SetProductsUiObjects(productsPresenters.Select((GUI_ElementsShopCartPanelElement presenter) => presenter.transform).AppendWith(licenseShopItems.Select((GUI_LicenseShopItem gUI_LicenseShopItem) => gUI_LicenseShopItem.transform)));
			UpdateCartInfo();
			wallet.OnMoneyAmountChanged += ResolveMoneyAmountChanged;
			view.Show();
			view.OnBuyButtonClicked += ResolveBuyButtonClicked;
			view.OnExitCartPanelButtonClicked += ResolveExitCartPanelButtonClicked;
		}

		public void Hide()
		{
			view.OnBuyButtonClicked -= ResolveBuyButtonClicked;
			view.OnExitCartPanelButtonClicked -= ResolveExitCartPanelButtonClicked;
			wallet.OnMoneyAmountChanged -= ResolveMoneyAmountChanged;
			foreach (GUI_ElementsShopCartPanelElement productsPresenter in productsPresenters)
			{
				productsPresenter.OnIncreaseCountInCartButtonClicked -= ResolveIncreaseCountInCartButtonClicked;
				productsPresenter.OnDecreaseCountInCartButtonClicked -= ResolveDecreaseCountInCartButtonClicked;
				productsPresenter.OnRemoveFromCartButtonClicked -= ResolveRemoveFromCartButtonClicked;
				productsPresenter.OnInputValueChanged -= ResolveInputValueChanged;
				productsPresenter.OnIsInStockChanged -= ResolveOnIsInStockChanged;
				cartPanelElementsUiPool.Release(productsPresenter);
			}
			productsPresenters.Clear();
			foreach (GUI_LicenseShopItem licenseShopItem in licenseShopItems)
			{
				licenseShopItem.OnRemoveFromCartButtonClicked -= ResolveRemoveLicenseFromCartButtonClicked;
				licenseShopElementPool.Release(licenseShopItem);
			}
			licenseShopItems.Clear();
			view.Hide();
		}

		private void ResolveBuyButtonClicked()
		{
			if (shopInteractor.TryToBuyAllItemsFromShoppingCart())
			{
				view.DetachProductsUiObjects();
				UpdateCartInfo();
			}
		}

		private void ResolveMoneyAmountChanged()
		{
			UpdateCartInfo();
		}

		private void ResolveExitCartPanelButtonClicked()
		{
			this.OnExitCartButtonClicked?.Invoke();
		}

		private void ResolveIncreaseCountInCartButtonClicked(GUI_ElementsShopCartPanelElement productPresenter)
		{
			ChangeCountInCart(productPresenter, 1);
		}

		private void ResolveDecreaseCountInCartButtonClicked(GUI_ElementsShopCartPanelElement productPresenter)
		{
			ChangeCountInCart(productPresenter, -1);
		}

		private void ResolveInputValueChanged(GUI_ElementsShopCartPanelElement productPresenter, int value)
		{
			SetCountInCart(productPresenter, value);
		}

		private void ResolveRemoveFromCartButtonClicked(GUI_ElementsShopCartPanelElement productPresenter)
		{
			shopInteractor.RemoveWholeItemFromShoppingCart(productPresenter.ShopItemData);
			UpdateCartInfo();
			productPresenter.OnIncreaseCountInCartButtonClicked -= ResolveIncreaseCountInCartButtonClicked;
			productPresenter.OnDecreaseCountInCartButtonClicked -= ResolveDecreaseCountInCartButtonClicked;
			productPresenter.OnRemoveFromCartButtonClicked -= ResolveRemoveFromCartButtonClicked;
			productPresenter.OnInputValueChanged -= ResolveInputValueChanged;
			productPresenter.OnIsInStockChanged -= ResolveOnIsInStockChanged;
			cartPanelElementsUiPool.Release(productPresenter);
			productsPresenters.Remove(productPresenter);
		}

		private void ResolveOnIsInStockChanged(GUI_ElementsShopCartPanelElement item)
		{
			UpdateCartInfo();
		}

		private void ResolveRemoveLicenseFromCartButtonClicked(GUI_LicenseShopItem item)
		{
			shopInteractor.TryToRemoveLicenseFromShoppingCart(item.Item);
			UpdateCartInfo();
			item.OnRemoveFromCartButtonClicked -= ResolveRemoveLicenseFromCartButtonClicked;
			licenseShopElementPool.Release(item);
			licenseShopItems.Remove(item);
		}

		private void ChangeCountInCart(GUI_ElementsShopCartPanelElement productPresenter, int addendum)
		{
			int num = shopInteractor.GetItemCountInShoppingCart(productPresenter.ShopItemData) + addendum;
			if (num < productPresenter.ShopItemData.MinCount)
			{
				num = ((addendum >= 0) ? productPresenter.ShopItemData.MinCount : 0);
			}
			SetItemCount(productPresenter, num);
		}

		private void SetCountInCart(GUI_ElementsShopCartPanelElement productPresenter, int requestedCount)
		{
			if (requestedCount < productPresenter.ShopItemData.MinCount)
			{
				requestedCount = ((requestedCount >= 1) ? productPresenter.ShopItemData.MinCount : 0);
			}
			SetItemCount(productPresenter, requestedCount);
		}

		private void SetItemCount(GUI_ElementsShopCartPanelElement productPresenter, int requestedCount)
		{
			int countToSet = productPresenter.UpdateCartInfo(requestedCount);
			shopInteractor.SetItemCountInShoppingCart(productPresenter.ShopItemData, countToSet);
			UpdateCartInfo();
		}

		private void UpdateCartInfo()
		{
			view.SetCartInfo(shopInteractor.GetAvailableTotalItemsCountInShoppingCart(), shopInteractor.GetAvailableTotalItemsCostInShoppingCart(), wallet.MoneyAvailable, mainDayTimeSwitchingService.CurrentDayTime);
		}
	}
}
