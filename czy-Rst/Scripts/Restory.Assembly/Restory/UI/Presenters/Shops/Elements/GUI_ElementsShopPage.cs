using System.Collections.Generic;
using Restory.Data.Devices;
using Restory.Data.Elements.Condition;
using Restory.Data.Licenses;
using Restory.Gameplay.Delivery;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Inventory;
using Restory.Gameplay.Licenses;
using Restory.Gameplay.Shops.Elements;
using Restory.Gameplay.Statistics;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Restory.UI.Presenters.Shops.Elements
{
	public sealed class GUI_ElementsShopPage : GUI_WebBrowserPageBase
	{
		[SerializeField]
		private GUI_ElementsShopProductsPanel productsPanelPresenter;

		[SerializeField]
		private GUI_ElementsShopCartPanel cartPanelPresenter;

		[SerializeField]
		private ElementConditionBase defaultElementCondition;

		private ElementsShopInteractor shopInteractor;

		private ShopPanelState currentState;

		private LicensesService licensesService;

		private DeviceInfoDatabase deviceDatabase;

		private DeviceCategoriesDatabaseProviderService deviceCategoriesDatabaseProviderService;

		private ShopPanelState CurrentState
		{
			get
			{
				return currentState;
			}
			set
			{
				if (currentState != value)
				{
					HideCurrentWindows();
					currentState = value;
					ShowCurrentWindow();
				}
			}
		}

		[Inject]
		private void Construct(Wallet wallet, LicensesService licensesService, DeliveryService deliveryService, GameStatisticsService gameStatistics, DeviceInfoDatabase deviceDatabase, ElementsShopService elementsShopService, DeviceCategoriesDatabaseProviderService deviceCategoriesDatabaseProviderService)
		{
			this.licensesService = licensesService;
			this.deviceDatabase = deviceDatabase;
			this.deviceCategoriesDatabaseProviderService = deviceCategoriesDatabaseProviderService;
			shopInteractor = new ElementsShopInteractor(licensesService, deliveryService, wallet, gameStatistics, defaultElementCondition, elementsShopService);
			productsPanelPresenter.SetShop(shopInteractor);
			cartPanelPresenter.SetShop(shopInteractor);
		}

		private void OnDisable()
		{
			Hide();
		}

		public override void Show()
		{
			licensesService.OnLicenseAdded += ResolveOnLicenseAdded;
			switch (currentState)
			{
			case ShopPanelState.None:
				CurrentState = ShopPanelState.ProductsSelection;
				break;
			case ShopPanelState.ShoppingCart:
				if (shopInteractor.AllItemsInShoppingCart.Count == 0)
				{
					CurrentState = ShopPanelState.ProductsSelection;
				}
				else
				{
					ShowCurrentWindow();
				}
				break;
			default:
				ShowCurrentWindow();
				break;
			}
		}

		public override void Hide()
		{
			licensesService.OnLicenseAdded -= ResolveOnLicenseAdded;
			HideCurrentWindows();
		}

		private void ShowCurrentWindow()
		{
			switch (currentState)
			{
			case ShopPanelState.ProductsSelection:
				productsPanelPresenter.Show();
				productsPanelPresenter.OnGoToCartButtonClicked += ResolveGoToCartModeButtonClicked;
				break;
			case ShopPanelState.ShoppingCart:
				cartPanelPresenter.Show();
				cartPanelPresenter.OnExitCartButtonClicked += ResolveGoToCartModeButtonClicked;
				break;
			}
		}

		private void HideCurrentWindows()
		{
			switch (currentState)
			{
			case ShopPanelState.None:
				productsPanelPresenter.Hide();
				productsPanelPresenter.OnGoToCartButtonClicked -= ResolveGoToCartModeButtonClicked;
				cartPanelPresenter.Hide();
				cartPanelPresenter.OnExitCartButtonClicked -= ResolveGoToCartModeButtonClicked;
				break;
			case ShopPanelState.ProductsSelection:
				productsPanelPresenter.Hide();
				productsPanelPresenter.OnGoToCartButtonClicked -= ResolveGoToCartModeButtonClicked;
				break;
			case ShopPanelState.ShoppingCart:
				cartPanelPresenter.Hide();
				cartPanelPresenter.OnExitCartButtonClicked -= ResolveGoToCartModeButtonClicked;
				break;
			}
		}

		private void ResolveGoToCartModeButtonClicked()
		{
			CurrentState = ((CurrentState != ShopPanelState.ShoppingCart) ? ShopPanelState.ShoppingCart : ShopPanelState.ProductsSelection);
		}

		private void ResolveOnLicenseAdded(LicensesService service, LicenseInfo license)
		{
			HashSet<IDeviceCategory> value;
			using (CollectionPool<HashSet<IDeviceCategory>, IDeviceCategory>.Get(out value))
			{
				foreach (GUI_ElementsShopProductsPanelFilter.CategoryButton category in productsPanelPresenter.Filter.Categories)
				{
					if (category.Category != null)
					{
						value.Add(category.Category);
					}
				}
				foreach (IDeviceInfo device in deviceDatabase.Devices)
				{
					if (device.License == license && value.Contains(device.Category))
					{
						productsPanelPresenter.Filter.SelectCategory(device.Category);
						break;
					}
				}
			}
		}
	}
}
