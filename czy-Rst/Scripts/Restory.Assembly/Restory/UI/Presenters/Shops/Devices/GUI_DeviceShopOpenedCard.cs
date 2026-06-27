using System;
using Restory.Data.Localization;
using Restory.Gameplay.Inventory;
using Restory.Gameplay.Licenses;
using Restory.Gameplay.Shops.Devices;
using Restory.ObjectPools;
using Restory.UI.Views.Shops.Devices;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.Shops.Devices
{
	public sealed class GUI_DeviceShopOpenedCard : MonoBehaviour, ICleanableComponent
	{
		[SerializeField]
		private GUI_DeviceShopOpenedCardView view;

		private GUI_DeviceShopItem item;

		private LocalizationSystem localizationSystem;

		private Wallet wallet;

		private LicensesService licensesService;

		private DeviceShopInteractor shopInteractor;

		public GUI_DeviceShopItem Item => item;

		public event Action OnCloseButtonClicked;

		public event Action<GUI_DeviceShopItem> OnAddToCartButtonClicked;

		public event Action<GUI_DeviceShopItem> OnRemoveFromCartButtonClicked;

		[Inject]
		private void Construct(LocalizationSystem localizationSystem, Wallet wallet, LicensesService licensesService, DeviceShopInteractor shopInteractor)
		{
			this.localizationSystem = localizationSystem;
			this.wallet = wallet;
			this.licensesService = licensesService;
			this.shopInteractor = shopInteractor;
		}

		private void OnEnable()
		{
			view.OnCloseButtonClicked += this.OnCloseButtonClicked;
			view.OnAddToCartButtonClicked += ResolveAddToCartButtonClicked;
			view.OnRemoveFromCartButtonClicked += ResolveRemoveFromCartButtonClicked;
		}

		private void OnDisable()
		{
			view.OnCloseButtonClicked -= this.OnCloseButtonClicked;
			view.OnAddToCartButtonClicked -= ResolveAddToCartButtonClicked;
			view.OnRemoveFromCartButtonClicked -= ResolveRemoveFromCartButtonClicked;
		}

		public void Init(GUI_DeviceShopItem item)
		{
			this.item = item;
			view.Init(item.ShopLot.Icon, localizationSystem.GetTranslation(item.ShopLot.NameKey), GetLotDescriptionTranslation(item), item.ShopLot.Price, item.ShopLot.MarketPrice, localizationSystem.GetTranslation(item.ShopLot.SellerNameKey), item.ShopLot.SellerRating, item.ShopLot.BackgroundIcon);
			if (item.ShopLot is IDeviceShopLot deviceShopLot)
			{
				view.ShowQuality(deviceShopLot.Quality, localizationSystem.GetTranslation(deviceShopLot.Quality.LocalizationKey));
			}
			else
			{
				view.HideQuality();
			}
			UpdateState();
		}

		public void Show()
		{
			view.gameObject.SetActive(value: true);
		}

		public void Hide()
		{
			view.gameObject.SetActive(value: false);
			item = null;
		}

		public void UpdateState()
		{
			bool num = shopInteractor.ContainsLotInShoppingCart(item.ShopLot);
			bool flag = wallet.MoneyAvailable < item.ShopLot.Price;
			bool flag2 = true;
			if (item.ShopLot is IDeviceShopLot deviceShopLot)
			{
				flag2 = deviceShopLot.Device.DeviceInfo.License == null || licensesService.Contains(deviceShopLot.Device.DeviceInfo.License);
			}
			if (num)
			{
				view.SetSelectedState();
			}
			else if (!flag2)
			{
				view.SetLicenseRequiredState();
			}
			else if (flag)
			{
				view.SetInsufficientFundsState();
			}
			else
			{
				view.SetNormalState();
			}
		}

		public void Clean()
		{
			item = null;
			view.gameObject.SetActive(value: false);
		}

		private string GetLotDescriptionTranslation(GUI_DeviceShopItem shopItem)
		{
			if (!string.IsNullOrEmpty(shopItem.ShopLot.DescriptionKey))
			{
				return localizationSystem.GetTranslation(shopItem.ShopLot.DescriptionKey);
			}
			if (shopItem.ShopLot is RandomlyGeneratedDeviceShopLot randomlyGeneratedDeviceShopLot)
			{
				return randomlyGeneratedDeviceShopLot.DescriptionKeys.GetTranslatedDescription(localizationSystem);
			}
			return string.Empty;
		}

		private void ResolveAddToCartButtonClicked()
		{
			this.OnAddToCartButtonClicked?.Invoke(item);
		}

		private void ResolveRemoveFromCartButtonClicked()
		{
			this.OnRemoveFromCartButtonClicked?.Invoke(item);
		}
	}
}
