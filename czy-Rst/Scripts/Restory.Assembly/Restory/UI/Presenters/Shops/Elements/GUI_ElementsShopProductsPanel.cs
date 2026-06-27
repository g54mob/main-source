using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.Shops.Elements;
using Restory.Gameplay.Inventory;
using Restory.Gameplay.Shops.Elements;
using Restory.ObjectPools;
using Restory.UI.Pools.Shops.Elements;
using Restory.UI.Views.Shops.Elements;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.Shops.Elements
{
	public sealed class GUI_ElementsShopProductsPanel : MonoBehaviour
	{
		[SerializeField]
		private GUI_ElementsShopProductsPanelView view;

		[SerializeField]
		private GUI_ElementsShopProductsPanelFilter filtersPresenter;

		private Wallet wallet;

		private ElementsShopService shopsService;

		private GUI_ElementsShopElementPool elementsShopElementPool;

		private GUI_LicenseShopElementCustomPool licenseShopElementPool;

		private readonly List<GUI_ElementsShopElement> elementItems = new List<GUI_ElementsShopElement>();

		private readonly List<GUI_LicenseShopItem> licenseItems = new List<GUI_LicenseShopItem>();

		private ElementsShopInteractor shopInteractor;

		public GUI_ElementsShopProductsPanelFilter Filter => filtersPresenter;

		public event Action OnBannerClicked;

		public event Action OnGoToCartButtonClicked;

		[Inject]
		private void Construct(GUI_ElementsShopElementPool elementsShopElementsUiPool, GUI_LicenseShopElementCustomPool licenseShopElementPool, ElementsShopService shopsService, Wallet wallet)
		{
			this.shopsService = shopsService;
			elementsShopElementPool = elementsShopElementsUiPool;
			this.licenseShopElementPool = licenseShopElementPool;
			this.wallet = wallet;
		}

		public void SetShop(ElementsShopInteractor shopInteractor)
		{
			this.shopInteractor = shopInteractor;
		}

		private void OnDisable()
		{
			view.OnGoToCartButtonClicked -= ResolveGoToCartButtonClicked;
			view.OnBannerClicked -= ResolveLOnBannerClicked;
			ClearItems();
		}

		public void Show()
		{
			SetUpFilters();
			UpdateShownProductsList();
			view.SetProductsInCartCount(shopInteractor.GetTotalItemsCountInShoppingCart());
			view.Show();
			view.OnGoToCartButtonClicked += ResolveGoToCartButtonClicked;
			view.OnBannerClicked += ResolveLOnBannerClicked;
			filtersPresenter.OnFiltersChanged += ResolveOnFiltersChanged;
			filtersPresenter.Activate();
			if (shopInteractor.PreferableDeviceCategory != null)
			{
				filtersPresenter.SelectCategory(shopInteractor.PreferableDeviceCategory);
				shopInteractor.PreferableDeviceCategory = null;
			}
			wallet.OnMoneyAmountChanged += ResolveOnMoneyAmountChanged;
		}

		public void Hide()
		{
			wallet.OnMoneyAmountChanged -= ResolveOnMoneyAmountChanged;
			view.OnGoToCartButtonClicked -= ResolveGoToCartButtonClicked;
			view.OnBannerClicked -= ResolveLOnBannerClicked;
			filtersPresenter.OnFiltersChanged -= ResolveOnFiltersChanged;
			view.Hide();
			filtersPresenter.Deactivate();
			ClearItems();
		}

		private void SetUpFilters()
		{
			filtersPresenter.SetUpFilters(shopsService.GetAllowedElementItems(), shopsService.GetAllowedLicenses());
			filtersPresenter.UpdateFilteredInfo();
		}

		private void UpdateShownProductsList()
		{
			ClearItems();
			view.ToggleBanner(!filtersPresenter.IsLicensesSelected);
			foreach (LicenseShopItemData filteredLicenceItem in filtersPresenter.FilteredLicenceItems)
			{
				GUI_LicenseShopItem item = licenseShopElementPool.GetItem(filteredLicenceItem.License);
				licenseItems.Add(item);
				item.Init(filteredLicenceItem, shopInteractor.AllLicensesInShoppingCart.Contains(filteredLicenceItem), wallet.MoneyAvailable < filteredLicenceItem.Price, filteredLicenceItem.License.AvailableForSale);
				item.OnAddToCartButtonClicked += ResolveAddToCartButtonClicked;
				item.OnRemoveFromCartButtonClicked += ResolveRemoveFromCartButtonClicked;
			}
			view.AttachProductsUiObjects(licenseItems.Select((GUI_LicenseShopItem licenseItem) => licenseItem.transform));
			foreach (ElementsShopItemData filteredElementInfo in filtersPresenter.FilteredElementInfos)
			{
				GUI_ElementsShopElement gUI_ElementsShopElement = elementsShopElementPool.Get<GUI_ElementsShopElement>();
				elementItems.Add(gUI_ElementsShopElement);
				int itemCountInShoppingCart = shopInteractor.GetItemCountInShoppingCart(filteredElementInfo);
				gUI_ElementsShopElement.Init(filteredElementInfo, itemCountInShoppingCart, wallet.MoneyAvailable < filteredElementInfo.Price);
				gUI_ElementsShopElement.OnIncreaseCountInCartButtonClicked += ResolveIncreaseCountInCartButtonClicked;
				gUI_ElementsShopElement.OnDecreaseCountInCartButtonClicked += ResolveDecreaseCountInCartButtonClicked;
				gUI_ElementsShopElement.OnInputValueChanged += ResolveInputValueChanged;
			}
			view.AttachProductsUiObjects(elementItems.Select((GUI_ElementsShopElement elementItem) => elementItem.transform));
		}

		private void ResolveIncreaseCountInCartButtonClicked(GUI_ElementsShopElement shopItemPresenter)
		{
			ChangeCountInCart(shopItemPresenter, 1);
		}

		private void ResolveDecreaseCountInCartButtonClicked(GUI_ElementsShopElement shopItemPresenter)
		{
			ChangeCountInCart(shopItemPresenter, -1);
		}

		private void ResolveInputValueChanged(GUI_ElementsShopElement shopItemPresenter, int value)
		{
			SetCountInCart(shopItemPresenter, value);
		}

		private void ResolveGoToCartButtonClicked()
		{
			if (shopInteractor.GetTotalItemsCountInShoppingCart() != 0)
			{
				this.OnGoToCartButtonClicked?.Invoke();
			}
		}

		private void ResolveOnFiltersChanged()
		{
			UpdateShownProductsList();
		}

		private void ChangeCountInCart(GUI_ElementsShopElement shopItemPresenter, int addendum)
		{
			int num = shopInteractor.GetItemCountInShoppingCart(shopItemPresenter.ShopItemData) + addendum;
			if (num < shopItemPresenter.ShopItemData.MinCount)
			{
				num = ((addendum >= 0) ? shopItemPresenter.ShopItemData.MinCount : 0);
			}
			SetItemCount(shopItemPresenter, num);
		}

		private void SetCountInCart(GUI_ElementsShopElement shopItemPresenter, int requestedCount)
		{
			if (requestedCount < shopItemPresenter.ShopItemData.MinCount)
			{
				requestedCount = ((requestedCount >= 1) ? shopItemPresenter.ShopItemData.MinCount : 0);
			}
			SetItemCount(shopItemPresenter, requestedCount);
		}

		private void SetItemCount(GUI_ElementsShopElement shopItemPresenter, int requestedCount)
		{
			int countToSet = shopItemPresenter.UpdateCountInCart(requestedCount, wallet.MoneyAvailable < shopItemPresenter.ShopItemData.Price);
			shopInteractor.SetItemCountInShoppingCart(shopItemPresenter.ShopItemData, countToSet);
			view.SetProductsInCartCount(shopInteractor.GetTotalItemsCountInShoppingCart());
		}

		private void ClearItems()
		{
			foreach (GUI_ElementsShopElement elementItem in elementItems)
			{
				elementItem.OnIncreaseCountInCartButtonClicked -= ResolveIncreaseCountInCartButtonClicked;
				elementItem.OnDecreaseCountInCartButtonClicked -= ResolveDecreaseCountInCartButtonClicked;
				elementItem.OnInputValueChanged -= ResolveInputValueChanged;
				elementsShopElementPool.Release(elementItem);
			}
			elementItems.Clear();
			foreach (GUI_LicenseShopItem licenseItem in licenseItems)
			{
				licenseItem.OnAddToCartButtonClicked -= ResolveAddToCartButtonClicked;
				licenseItem.OnRemoveFromCartButtonClicked -= ResolveRemoveFromCartButtonClicked;
			}
			licenseShopElementPool.ReleaseAll();
			licenseItems.Clear();
			view.ClearProductsUiObjects();
		}

		private void ResolveRemoveFromCartButtonClicked(GUI_LicenseShopItem item)
		{
			item.SetState(isSelected: false, wallet.MoneyAvailable < shopsService.CalculatePrice(item.Item));
			shopInteractor.TryToRemoveLicenseFromShoppingCart(item.Item);
			view.SetProductsInCartCount(shopInteractor.GetTotalItemsCountInShoppingCart());
		}

		private void ResolveAddToCartButtonClicked(GUI_LicenseShopItem item)
		{
			if ((bool)item.Item.ContentRestriction)
			{
				Debug.LogError("Restricted item " + item.Item.License.ID + " can't be added to cart");
				return;
			}
			item.SetState(isSelected: true, wallet.MoneyAvailable < shopsService.CalculatePrice(item.Item));
			shopInteractor.TryToAddLicenseToShoppingCart(item.Item);
			view.SetProductsInCartCount(shopInteractor.GetTotalItemsCountInShoppingCart());
		}

		private void ResolveOnMoneyAmountChanged()
		{
			UpdateShownProductsList();
		}

		private void ResolveLOnBannerClicked()
		{
			this.OnBannerClicked?.Invoke();
		}
	}
}
