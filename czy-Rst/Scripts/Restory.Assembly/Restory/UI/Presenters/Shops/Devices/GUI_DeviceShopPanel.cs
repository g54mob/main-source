using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.GameConfigs;
using Restory.Gameplay.Shops;
using Restory.Gameplay.Shops.Devices;
using Restory.Gameplay.TimeSystems;
using Restory.ObjectPools;
using Restory.UI.Pools.Shops.Devices;
using Restory.UI.Views.Shops.Devices;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Restory.UI.Presenters.Shops.Devices
{
	public sealed class GUI_DeviceShopPanel : MonoBehaviour
	{
		[SerializeField]
		private GUI_DeviceShopPanelView view;

		[SerializeField]
		private GUI_DeviceShopFilter filter;

		[SerializeField]
		private GUI_DeviceShopOpenedCard openedCard;

		private ShopsService shopsService;

		private DeviceShopItemsUiPool deviceShopItemsPool;

		private DeviceShopInteractor shopInteractor;

		private GameCalendar gameCalendar;

		private GameConfig gameConfig;

		private readonly List<GUI_DeviceShopItem> items = new List<GUI_DeviceShopItem>();

		private bool isSubscribed;

		public event Action OnOpenCartButtonClicked;

		[Inject]
		public void Construct(ShopsService shopsService, DeviceShopItemsUiPool deviceShopItemsPool, DeviceShopInteractor shopInteractor, GameCalendar gameCalendar, GameConfig gameConfig)
		{
			this.shopsService = shopsService;
			this.deviceShopItemsPool = deviceShopItemsPool;
			this.shopInteractor = shopInteractor;
			this.gameCalendar = gameCalendar;
			this.gameConfig = gameConfig;
		}

		private void OnDisable()
		{
			Unsubscribe();
			ClearItems();
		}

		public void Show()
		{
			Subscribe();
			filter.SetUpFilters(shopsService.Lots);
			UpdateShownItems();
			view.SetLotsInCartCount(shopInteractor.LotsInShoppingCart.Count, shopsService.Lots.Count);
			view.Show();
			filter.Activate();
		}

		public void Hide()
		{
			Unsubscribe();
			view.Hide();
			filter.Deactivate();
			openedCard.Hide();
			ClearItems();
		}

		private void Subscribe()
		{
			if (!isSubscribed)
			{
				isSubscribed = true;
				view.OnOpenCartButtonClicked += ResolveOpenCartButtonClicked;
				filter.OnFiltersValueChanged += ResolveFiltersValueChanged;
				openedCard.OnCloseButtonClicked += ResolveOpenedCardCloseButtonClicked;
				openedCard.OnAddToCartButtonClicked += ResolveAddToCartButtonClicked;
				openedCard.OnRemoveFromCartButtonClicked += ResolveRemoveFromCartButtonClicked;
			}
		}

		private void Unsubscribe()
		{
			if (isSubscribed)
			{
				isSubscribed = false;
				view.OnOpenCartButtonClicked -= ResolveOpenCartButtonClicked;
				filter.OnFiltersValueChanged -= ResolveFiltersValueChanged;
				openedCard.OnCloseButtonClicked -= ResolveOpenedCardCloseButtonClicked;
				openedCard.OnAddToCartButtonClicked -= ResolveAddToCartButtonClicked;
				openedCard.OnRemoveFromCartButtonClicked -= ResolveRemoveFromCartButtonClicked;
			}
		}

		private void UpdateShownItems()
		{
			ClearItems();
			view.ToggleLicenseBanner(filter.IsAllCategorySelected);
			List<ILot> value;
			using (CollectionPool<List<ILot>, ILot>.Get(out value))
			{
				foreach (ILot lot in shopsService.Lots)
				{
					if (filter.IsAllCategorySelected)
					{
						value.Add(lot);
					}
					else if (lot is IDeviceShopLot deviceShopLot && deviceShopLot.Device.DeviceInfo.Category == filter.SelectedCategory)
					{
						value.Add(lot);
					}
				}
				foreach (ILot item in value)
				{
					if (!item.HasRestriction || gameConfig.VersionType == VersionType.Release)
					{
						GUI_DeviceShopItem gUI_DeviceShopItem = deviceShopItemsPool.Get<GUI_DeviceShopItem>();
						gUI_DeviceShopItem.Init(item);
						gUI_DeviceShopItem.OnItemButtonClicked += ResolveItemButtonClicked;
						gUI_DeviceShopItem.OnAddToCartButtonClicked += ResolveAddToCartButtonClicked;
						gUI_DeviceShopItem.OnRemoveFromCartButtonClicked += ResolveRemoveFromCartButtonClicked;
						items.Add(gUI_DeviceShopItem);
					}
				}
			}
			IOrderedEnumerable<GUI_DeviceShopItem> source = items.OrderByDescending((GUI_DeviceShopItem item) => gameCalendar.StartingTime.AddDays(item.ShopLot.Day));
			view.AttachItemsUiObjects(source.Select((GUI_DeviceShopItem item) => item.transform));
		}

		private void ResolveOpenCartButtonClicked()
		{
			if (shopInteractor.LotsInShoppingCart.Count != 0)
			{
				this.OnOpenCartButtonClicked?.Invoke();
			}
		}

		private void ResolveFiltersValueChanged()
		{
			openedCard.Hide();
			UpdateShownItems();
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

		private void ResolveAddToCartButtonClicked(GUI_DeviceShopItem item)
		{
			if (shopInteractor.TryToAddLotToShoppingCart(item.ShopLot))
			{
				item.UpdateState();
				view.SetLotsInCartCount(shopInteractor.LotsInShoppingCart.Count, shopsService.Lots.Count);
				if (openedCard.Item == item)
				{
					openedCard.UpdateState();
				}
			}
		}

		private void ResolveRemoveFromCartButtonClicked(GUI_DeviceShopItem item)
		{
			if (shopInteractor.TryToRemoveLotFromShoppingCart(item.ShopLot))
			{
				item.UpdateState();
				view.SetLotsInCartCount(shopInteractor.LotsInShoppingCart.Count, shopsService.Lots.Count);
				if (openedCard.Item == item)
				{
					openedCard.UpdateState();
				}
			}
		}

		private void ClearItems()
		{
			foreach (GUI_DeviceShopItem item in items)
			{
				item.OnItemButtonClicked -= ResolveItemButtonClicked;
				item.OnAddToCartButtonClicked -= ResolveAddToCartButtonClicked;
				item.OnRemoveFromCartButtonClicked -= ResolveRemoveFromCartButtonClicked;
				deviceShopItemsPool.Release(item);
			}
			items.Clear();
		}
	}
}
