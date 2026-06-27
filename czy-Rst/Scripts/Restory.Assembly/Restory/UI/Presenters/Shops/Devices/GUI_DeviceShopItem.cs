using System;
using System.Linq;
using Restory.Data.Localization;
using Restory.Gameplay.Inventory;
using Restory.Gameplay.Licenses;
using Restory.Gameplay.Shops.Devices;
using Restory.Gameplay.TimeSystems;
using Restory.ObjectPools;
using Restory.UI.Views.Shops.Devices;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.Shops.Devices
{
	public sealed class GUI_DeviceShopItem : MonoBehaviour, ICleanableComponent
	{
		[SerializeField]
		private GUI_DeviceShopItemView view;

		private ILot shopLot;

		private LocalizationSystem localizationSystem;

		private GameCalendar gameCalendar;

		private Wallet wallet;

		private LicensesService licensesService;

		private DeviceShopInteractor shopInteractor;

		public ILot ShopLot => shopLot;

		public event Action<GUI_DeviceShopItem> OnItemButtonClicked;

		public event Action<GUI_DeviceShopItem> OnAddToCartButtonClicked;

		public event Action<GUI_DeviceShopItem> OnRemoveFromCartButtonClicked;

		[Inject]
		private void Construct(LocalizationSystem localizationSystem, GameCalendar gameCalendar, Wallet wallet, LicensesService licensesService, DeviceShopInteractor shopInteractor)
		{
			this.localizationSystem = localizationSystem;
			this.gameCalendar = gameCalendar;
			this.wallet = wallet;
			this.licensesService = licensesService;
			this.shopInteractor = shopInteractor;
			if (base.isActiveAndEnabled)
			{
				wallet.OnMoneyAmountChanged += ResolveOnMoneyAmountChanged;
			}
		}

		private void OnEnable()
		{
			view.OnItemButtonClicked += ResolveItemButtonClicked;
			view.OnAddToCartButtonClicked += ResolveAddToCartButtonClicked;
			view.OnRemoveFromCartButtonClicked += ResolveRemoveFromCartButtonClicked;
			if (wallet != null)
			{
				wallet.OnMoneyAmountChanged -= ResolveOnMoneyAmountChanged;
				wallet.OnMoneyAmountChanged += ResolveOnMoneyAmountChanged;
			}
		}

		private void OnDisable()
		{
			view.OnItemButtonClicked -= ResolveItemButtonClicked;
			view.OnAddToCartButtonClicked -= ResolveAddToCartButtonClicked;
			view.OnRemoveFromCartButtonClicked -= ResolveRemoveFromCartButtonClicked;
			if (wallet.MonoShellExists())
			{
				wallet.OnMoneyAmountChanged -= ResolveOnMoneyAmountChanged;
			}
		}

		public void Clean()
		{
		}

		public void Init(ILot shopLot)
		{
			this.shopLot = shopLot;
			view.Init(shopLot.Icon, localizationSystem.GetTranslation(shopLot.NameKey), GetLotDescriptionTranslation(), shopLot.Price, localizationSystem.GetTranslation(shopLot.SellerNameKey), shopLot.SellerRating, backgroundIcon: shopLot.BackgroundIcon, timeSpan: gameCalendar.CurrentDateTime - gameCalendar.StartingTime.AddDays(shopLot.Day));
			if (shopLot is IDeviceShopLot deviceShopLot)
			{
				view.ShowQuality(deviceShopLot.Quality, localizationSystem.GetTranslation(deviceShopLot.Quality.LocalizationKey));
			}
			else
			{
				view.HideQuality();
			}
			UpdateState();
		}

		public void UpdateState()
		{
			if (shopLot != null)
			{
				bool num = shopInteractor.LotsInShoppingCart.Contains(shopLot);
				bool flag = wallet.MoneyAvailable < shopLot.Price;
				bool flag2 = true;
				if (shopLot is IDeviceShopLot deviceShopLot)
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
		}

		private string GetLotDescriptionTranslation()
		{
			if (!string.IsNullOrEmpty(shopLot.DescriptionKey))
			{
				return localizationSystem.GetTranslation(shopLot.DescriptionKey);
			}
			if (shopLot is RandomlyGeneratedDeviceShopLot randomlyGeneratedDeviceShopLot)
			{
				return randomlyGeneratedDeviceShopLot.DescriptionKeys.GetTranslatedDescription(localizationSystem);
			}
			return string.Empty;
		}

		private void ResolveItemButtonClicked()
		{
			this.OnItemButtonClicked?.Invoke(this);
		}

		private void ResolveAddToCartButtonClicked()
		{
			this.OnAddToCartButtonClicked?.Invoke(this);
		}

		private void ResolveRemoveFromCartButtonClicked()
		{
			this.OnRemoveFromCartButtonClicked?.Invoke(this);
		}

		private void ResolveOnMoneyAmountChanged()
		{
			UpdateState();
		}
	}
}
