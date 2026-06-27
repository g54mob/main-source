using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Gameplay.Inventory;
using Restory.Gameplay.Shops.Devices;
using Restory.ObjectPools;
using Restory.TimeSystems;
using Restory.UI.Pools.Shops.Devices;
using Restory.UI.Views.Shops.Devices;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.Shops.Devices
{
	public sealed class GUI_DeviceShopCartPanel : MonoBehaviour
	{
		[SerializeField]
		private GUI_DeviceShopCartPanelView view;

		[SerializeField]
		private GUI_DeviceShopOpenedCard openedCard;

		private Wallet wallet;

		private DeviceShopItemsUiPool deviceShopItemsPool;

		private DeviceShopInteractor shopInteractor;

		private MainDayTimeSwitchingService mainDayTimeSwitchingService;

		private readonly List<GUI_DeviceShopItem> items = new List<GUI_DeviceShopItem>();

		private bool isSubscribed;

		public event Action OnExitCartButtonClicked;

		[Inject]
		public void Construct(Wallet wallet, DeviceShopItemsUiPool deviceShopItemsPool, DeviceShopInteractor shopInteractor, MainDayTimeSwitchingService mainDayTimeSwitchingService)
		{
			this.wallet = wallet;
			this.deviceShopItemsPool = deviceShopItemsPool;
			this.shopInteractor = shopInteractor;
			this.mainDayTimeSwitchingService = mainDayTimeSwitchingService;
		}

		private void OnDisable()
		{
			Unsubscribe();
		}

		public void Show()
		{
			Subscribe();
			foreach (ILot item in shopInteractor.LotsInShoppingCart)
			{
				GUI_DeviceShopItem gUI_DeviceShopItem = deviceShopItemsPool.Get<GUI_DeviceShopItem>();
				gUI_DeviceShopItem.Init(item);
				gUI_DeviceShopItem.OnRemoveFromCartButtonClicked += ResolveRemoveFromCartButtonClicked;
				gUI_DeviceShopItem.OnItemButtonClicked += ResolveItemButtonClicked;
				items.Add(gUI_DeviceShopItem);
			}
			view.SetProductsUiObjects(items.Select((GUI_DeviceShopItem item) => item.transform));
			UpdateCartInfo();
			wallet.OnMoneyAmountChanged += ResolveMoneyAmountChanged;
			view.Show();
		}

		public void Hide()
		{
			Unsubscribe();
			wallet.OnMoneyAmountChanged -= ResolveMoneyAmountChanged;
			foreach (GUI_DeviceShopItem item in items)
			{
				if (item.MonoShellExists())
				{
					item.OnRemoveFromCartButtonClicked -= ResolveRemoveFromCartButtonClicked;
					item.OnItemButtonClicked -= ResolveItemButtonClicked;
					deviceShopItemsPool.Release(item);
				}
			}
			items.Clear();
			view.Hide();
			openedCard.Hide();
		}

		private void Subscribe()
		{
			if (!isSubscribed)
			{
				isSubscribed = true;
				view.OnExitCartButtonClicked += ResolveExitCartButtonClicked;
				view.OnBuyButtonClicked += ResolveBuyButtonClicked;
				openedCard.OnCloseButtonClicked += ResolveOpenedCardCloseButtonClicked;
				openedCard.OnRemoveFromCartButtonClicked += ResolveRemoveFromCartButtonClicked;
			}
		}

		private void Unsubscribe()
		{
			if (isSubscribed)
			{
				isSubscribed = false;
				view.OnExitCartButtonClicked -= ResolveExitCartButtonClicked;
				view.OnBuyButtonClicked -= ResolveBuyButtonClicked;
				openedCard.OnCloseButtonClicked -= ResolveOpenedCardCloseButtonClicked;
				openedCard.OnRemoveFromCartButtonClicked -= ResolveRemoveFromCartButtonClicked;
			}
		}

		private void ResolveBuyButtonClicked()
		{
			if (shopInteractor.TryToBuyAllLotsFromShoppingCart())
			{
				view.DetachProductsUiObjects();
				UpdateCartInfo();
			}
		}

		private void ResolveMoneyAmountChanged()
		{
			UpdateCartInfo();
		}

		private void ResolveExitCartButtonClicked()
		{
			this.OnExitCartButtonClicked?.Invoke();
		}

		private void ResolveRemoveFromCartButtonClicked(GUI_DeviceShopItem item)
		{
			if (shopInteractor.TryToRemoveLotFromShoppingCart(item.ShopLot))
			{
				UpdateCartInfo();
				item.OnRemoveFromCartButtonClicked -= ResolveRemoveFromCartButtonClicked;
				item.OnItemButtonClicked -= ResolveItemButtonClicked;
				deviceShopItemsPool.Release(item);
				items.Remove(item);
				openedCard.Hide();
			}
		}

		private void ResolveOpenedCardCloseButtonClicked()
		{
			openedCard.Hide();
		}

		private void ResolveItemButtonClicked(GUI_DeviceShopItem item)
		{
			openedCard.Init(item);
			openedCard.Show();
		}

		private void UpdateCartInfo()
		{
			view.SetCartInfo(shopInteractor.LotsInShoppingCart.Count(), shopInteractor.GetTotalCostOfLotsInShoppingCart(), wallet.MoneyAvailable, mainDayTimeSwitchingService.CurrentDayTime);
		}
	}
}
