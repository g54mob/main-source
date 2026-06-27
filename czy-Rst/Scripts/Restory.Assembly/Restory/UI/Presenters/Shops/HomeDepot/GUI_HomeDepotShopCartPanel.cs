using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.Shops.HomeDepot;
using Restory.Gameplay.Inventory;
using Restory.Gameplay.Shops.HomeDepot;
using Restory.ObjectPools;
using Restory.TimeSystems;
using Restory.UI.Pools.Shops.Decors;
using Restory.UI.Views.Shops.HomeDepot;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.Shops.HomeDepot
{
	public sealed class GUI_HomeDepotShopCartPanel : MonoBehaviour
	{
		[SerializeField]
		private GUI_HomeDepotShopCartPanelView view;

		private Wallet wallet;

		private GUI_HomeDepotShopCartPanelDecorItemPool decorItemsPool;

		private GUI_HomeDepotShopCartPanelToolSingleUnitItemPool toolSingleUnitItemsPool;

		private GUI_HomeDepotShopCartPanelToolMultipleUnitItemPool toolMultipleUnitItemsPool;

		private GUI_HomeDepotShopCartPanelPaintingPaletteItemsPool paintingPaletteItemsPool;

		private GUI_HomeDepotShopCartPanelPcAppItemsPool pcAppItemsPool;

		private HomeDepotShopInteractor shopInteractor;

		private MainDayTimeSwitchingService mainDayTimeSwitchingService;

		private readonly List<GUI_HomeDepotShopCartPanelDecorItem> decorItems = new List<GUI_HomeDepotShopCartPanelDecorItem>();

		private readonly List<GUI_HomeDepotShopCartPanelItem> cleaningToolItems = new List<GUI_HomeDepotShopCartPanelItem>();

		private readonly List<GUI_HomeDepotShopCartPanelPaintingPaletteItem> paintingPaletteItems = new List<GUI_HomeDepotShopCartPanelPaintingPaletteItem>();

		private readonly List<GUI_HomeDepotShopCartPanelPcAppItem> pcAppItems = new List<GUI_HomeDepotShopCartPanelPcAppItem>();

		public event Action OnExitCartButtonClicked;

		[Inject]
		public void Construct(Wallet wallet, GUI_HomeDepotShopCartPanelDecorItemPool decorItemsPool, GUI_HomeDepotShopCartPanelToolSingleUnitItemPool toolSingleUnitItemsPool, GUI_HomeDepotShopCartPanelToolMultipleUnitItemPool toolMultipleUnitItemsPool, GUI_HomeDepotShopCartPanelPaintingPaletteItemsPool paintingPaletteItemsPool, GUI_HomeDepotShopCartPanelPcAppItemsPool pcAppItemsPool, HomeDepotShopInteractor shopInteractor, MainDayTimeSwitchingService mainDayTimeSwitchingService)
		{
			this.wallet = wallet;
			this.decorItemsPool = decorItemsPool;
			this.toolSingleUnitItemsPool = toolSingleUnitItemsPool;
			this.toolMultipleUnitItemsPool = toolMultipleUnitItemsPool;
			this.paintingPaletteItemsPool = paintingPaletteItemsPool;
			this.pcAppItemsPool = pcAppItemsPool;
			this.shopInteractor = shopInteractor;
			this.mainDayTimeSwitchingService = mainDayTimeSwitchingService;
		}

		private void OnEnable()
		{
			view.OnExitCartPanelButtonClicked += ResolveExitCartPanelButtonClicked;
			view.OnBuyButtonClicked += ResolveBuyButtonClicked;
		}

		private void OnDisable()
		{
			view.OnExitCartPanelButtonClicked -= ResolveExitCartPanelButtonClicked;
			view.OnBuyButtonClicked -= ResolveBuyButtonClicked;
		}

		public void Show()
		{
			foreach (HomeDepotShopItemData item in shopInteractor.AllItemsInShoppingCart)
			{
				if (!(item is HomeDepotShopDecorItemData shopItem))
				{
					if (!(item is HomeDepotShopCleaningToolItemData homeDepotShopCleaningToolItemData))
					{
						if (!(item is HomeDepotShopPaintingPaletteItemData shopItem2))
						{
							if (!(item is HomeDepotShopPcAppItemData shopItem3))
							{
								throw new NotImplementedException();
							}
							GUI_HomeDepotShopCartPanelPcAppItem gUI_HomeDepotShopCartPanelPcAppItem = pcAppItemsPool.Get<GUI_HomeDepotShopCartPanelPcAppItem>();
							gUI_HomeDepotShopCartPanelPcAppItem.Init(shopItem3);
							gUI_HomeDepotShopCartPanelPcAppItem.OnRemoveFromCartButtonClicked += ResolveRemoveFromCartButtonClicked;
							pcAppItems.Add(gUI_HomeDepotShopCartPanelPcAppItem);
						}
						else
						{
							GUI_HomeDepotShopCartPanelPaintingPaletteItem gUI_HomeDepotShopCartPanelPaintingPaletteItem = paintingPaletteItemsPool.Get<GUI_HomeDepotShopCartPanelPaintingPaletteItem>();
							gUI_HomeDepotShopCartPanelPaintingPaletteItem.Init(shopItem2);
							gUI_HomeDepotShopCartPanelPaintingPaletteItem.OnRemoveFromCartButtonClicked += ResolveRemoveFromCartButtonClicked;
							paintingPaletteItems.Add(gUI_HomeDepotShopCartPanelPaintingPaletteItem);
						}
					}
					else if (homeDepotShopCleaningToolItemData.ToolInfo.CanStoreMultipleCopies)
					{
						GUI_HomeDepotShopCartPanelToolMultipleUnitItem gUI_HomeDepotShopCartPanelToolMultipleUnitItem = toolMultipleUnitItemsPool.Get<GUI_HomeDepotShopCartPanelToolMultipleUnitItem>();
						gUI_HomeDepotShopCartPanelToolMultipleUnitItem.Init(homeDepotShopCleaningToolItemData);
						gUI_HomeDepotShopCartPanelToolMultipleUnitItem.UpdateCountInCart(shopInteractor.GetItemCountInShoppingCart(item));
						gUI_HomeDepotShopCartPanelToolMultipleUnitItem.OnIncreaseCountInCartButtonClicked += ResolveIncreaseCountInCartButtonClicked;
						gUI_HomeDepotShopCartPanelToolMultipleUnitItem.OnDecreaseCountInCartButtonClicked += ResolveDecreaseCountInCartButtonClicked;
						gUI_HomeDepotShopCartPanelToolMultipleUnitItem.OnRemoveFromCartButtonClicked += ResolveRemoveFromCartButtonClicked;
						gUI_HomeDepotShopCartPanelToolMultipleUnitItem.OnInputValueChanged += ResolveInputValueChanged;
						cleaningToolItems.Add(gUI_HomeDepotShopCartPanelToolMultipleUnitItem);
					}
					else
					{
						GUI_HomeDepotShopCartPanelToolSingleUnitItem gUI_HomeDepotShopCartPanelToolSingleUnitItem = toolSingleUnitItemsPool.Get<GUI_HomeDepotShopCartPanelToolSingleUnitItem>();
						gUI_HomeDepotShopCartPanelToolSingleUnitItem.Init(homeDepotShopCleaningToolItemData);
						gUI_HomeDepotShopCartPanelToolSingleUnitItem.OnRemoveFromCartButtonClicked += ResolveRemoveFromCartButtonClicked;
						cleaningToolItems.Add(gUI_HomeDepotShopCartPanelToolSingleUnitItem);
					}
				}
				else
				{
					GUI_HomeDepotShopCartPanelDecorItem gUI_HomeDepotShopCartPanelDecorItem = decorItemsPool.Get<GUI_HomeDepotShopCartPanelDecorItem>();
					gUI_HomeDepotShopCartPanelDecorItem.Init(shopItem);
					gUI_HomeDepotShopCartPanelDecorItem.UpdateCountInCart(shopInteractor.GetItemCountInShoppingCart(item));
					gUI_HomeDepotShopCartPanelDecorItem.OnIncreaseCountInCartButtonClicked += ResolveIncreaseCountInCartButtonClicked;
					gUI_HomeDepotShopCartPanelDecorItem.OnDecreaseCountInCartButtonClicked += ResolveDecreaseCountInCartButtonClicked;
					gUI_HomeDepotShopCartPanelDecorItem.OnRemoveFromCartButtonClicked += ResolveRemoveFromCartButtonClicked;
					gUI_HomeDepotShopCartPanelDecorItem.OnInputValueChanged += ResolveInputValueChanged;
					decorItems.Add(gUI_HomeDepotShopCartPanelDecorItem);
				}
			}
			view.SetProductsUiObjects(cleaningToolItems.Select((GUI_HomeDepotShopCartPanelItem presenter) => presenter.transform).Concat(decorItems.Select((GUI_HomeDepotShopCartPanelDecorItem presenter) => presenter.transform)).Concat(paintingPaletteItems.Select((GUI_HomeDepotShopCartPanelPaintingPaletteItem presenter) => presenter.transform))
				.Concat(pcAppItems.Select((GUI_HomeDepotShopCartPanelPcAppItem presenter) => presenter.transform)));
			UpdateCartInfo();
			wallet.OnMoneyAmountChanged += ResolveMoneyAmountChanged;
			view.Show();
		}

		public void Hide()
		{
			wallet.OnMoneyAmountChanged -= ResolveMoneyAmountChanged;
			foreach (GUI_HomeDepotShopCartPanelDecorItem decorItem in decorItems)
			{
				if (decorItem.MonoShellExists())
				{
					decorItem.OnIncreaseCountInCartButtonClicked -= ResolveIncreaseCountInCartButtonClicked;
					decorItem.OnDecreaseCountInCartButtonClicked -= ResolveDecreaseCountInCartButtonClicked;
					decorItem.OnRemoveFromCartButtonClicked -= ResolveRemoveFromCartButtonClicked;
					decorItem.OnInputValueChanged -= ResolveInputValueChanged;
					decorItemsPool.Release(decorItem);
				}
			}
			foreach (GUI_HomeDepotShopCartPanelItem cleaningToolItem in cleaningToolItems)
			{
				if (!cleaningToolItem.MonoShellExists())
				{
					continue;
				}
				if (!(cleaningToolItem is GUI_HomeDepotShopCartPanelToolSingleUnitItem gUI_HomeDepotShopCartPanelToolSingleUnitItem))
				{
					if (cleaningToolItem is GUI_HomeDepotShopCartPanelToolMultipleUnitItem gUI_HomeDepotShopCartPanelToolMultipleUnitItem)
					{
						gUI_HomeDepotShopCartPanelToolMultipleUnitItem.OnIncreaseCountInCartButtonClicked -= ResolveIncreaseCountInCartButtonClicked;
						gUI_HomeDepotShopCartPanelToolMultipleUnitItem.OnDecreaseCountInCartButtonClicked -= ResolveDecreaseCountInCartButtonClicked;
						gUI_HomeDepotShopCartPanelToolMultipleUnitItem.OnRemoveFromCartButtonClicked -= ResolveRemoveFromCartButtonClicked;
						gUI_HomeDepotShopCartPanelToolMultipleUnitItem.OnInputValueChanged -= ResolveInputValueChanged;
						toolMultipleUnitItemsPool.Release(gUI_HomeDepotShopCartPanelToolMultipleUnitItem);
					}
					else
					{
						Debug.LogError("[GUI_HomeDepotShopCartPanel] was unable to release cleaning tool item from pool, " + $"because item presenter [{cleaningToolItem}] was of unexpected type");
						UnityEngine.Object.Destroy(cleaningToolItem.gameObject);
					}
				}
				else
				{
					gUI_HomeDepotShopCartPanelToolSingleUnitItem.OnRemoveFromCartButtonClicked -= ResolveRemoveFromCartButtonClicked;
					toolSingleUnitItemsPool.Release(gUI_HomeDepotShopCartPanelToolSingleUnitItem);
				}
			}
			foreach (GUI_HomeDepotShopCartPanelPaintingPaletteItem paintingPaletteItem in paintingPaletteItems)
			{
				if (paintingPaletteItem.MonoShellExists())
				{
					paintingPaletteItem.OnRemoveFromCartButtonClicked -= ResolveRemoveFromCartButtonClicked;
					paintingPaletteItemsPool.Release(paintingPaletteItem);
				}
			}
			foreach (GUI_HomeDepotShopCartPanelPcAppItem pcAppItem in pcAppItems)
			{
				if (pcAppItem.MonoShellExists())
				{
					pcAppItem.OnRemoveFromCartButtonClicked -= ResolveRemoveFromCartButtonClicked;
					pcAppItemsPool.Release(pcAppItem);
				}
			}
			decorItems.Clear();
			cleaningToolItems.Clear();
			paintingPaletteItems.Clear();
			pcAppItems.Clear();
			view.Hide();
		}

		private void ChangeCountInCart(IShopCartItemGuiMultipleUnits cartItemGui, int addendum)
		{
			if (!(cartItemGui is GUI_HomeDepotShopCartPanelItem gUI_HomeDepotShopCartPanelItem))
			{
				Debug.LogError("[GUI_HomeDepotShopCartPanel] was unable to change count in cart for " + string.Format("[{0}], because the item GUI was not of type [{1}]", cartItemGui, "GUI_HomeDepotShopCartPanelItem"));
				return;
			}
			int itemCountInShoppingCart = shopInteractor.GetItemCountInShoppingCart(gUI_HomeDepotShopCartPanelItem.ShopItemData);
			int count = cartItemGui.UpdateCountInCart(itemCountInShoppingCart + addendum);
			SetItemCount(cartItemGui, count);
		}

		private void SetItemCount(IShopCartItemGuiMultipleUnits cartItemGui, int count)
		{
			if (!(cartItemGui is GUI_HomeDepotShopCartPanelItem gUI_HomeDepotShopCartPanelItem))
			{
				Debug.LogError("[GUI_HomeDepotShopCartPanel] was unable to set count in cart for " + string.Format("[{0}], because the item GUI was not of type [{1}]", cartItemGui, "GUI_HomeDepotShopCartPanelItem"));
				return;
			}
			shopInteractor.SetItemCountInShoppingCart(gUI_HomeDepotShopCartPanelItem.ShopItemData, count);
			UpdateCartInfo();
		}

		private void UpdateCartInfo()
		{
			view.SetCartInfo(shopInteractor.GetTotalItemsCountInShoppingCart(), shopInteractor.GetTotalItemsCostInShoppingCart(), wallet.MoneyAvailable, mainDayTimeSwitchingService.CurrentDayTime);
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

		private void ResolveIncreaseCountInCartButtonClicked(IShopCartItemGuiMultipleUnits item)
		{
			ChangeCountInCart(item, 1);
		}

		private void ResolveDecreaseCountInCartButtonClicked(IShopCartItemGuiMultipleUnits item)
		{
			ChangeCountInCart(item, -1);
		}

		private void ResolveInputValueChanged(IShopCartItemGuiMultipleUnits item, int value)
		{
			SetItemCount(item, value);
		}

		private void ResolveRemoveFromCartButtonClicked(IShopCartItemGui item)
		{
			if (!(item is GUI_HomeDepotShopCartPanelItem gUI_HomeDepotShopCartPanelItem))
			{
				return;
			}
			shopInteractor.RemoveWholeItemFromShoppingCart(gUI_HomeDepotShopCartPanelItem.ShopItemData);
			UpdateCartInfo();
			if (!(item is GUI_HomeDepotShopCartPanelDecorItem gUI_HomeDepotShopCartPanelDecorItem))
			{
				if (!(item is GUI_HomeDepotShopCartPanelToolSingleUnitItem gUI_HomeDepotShopCartPanelToolSingleUnitItem))
				{
					if (!(item is GUI_HomeDepotShopCartPanelToolMultipleUnitItem gUI_HomeDepotShopCartPanelToolMultipleUnitItem))
					{
						if (!(item is GUI_HomeDepotShopCartPanelPaintingPaletteItem gUI_HomeDepotShopCartPanelPaintingPaletteItem))
						{
							if (!(item is GUI_HomeDepotShopCartPanelPcAppItem gUI_HomeDepotShopCartPanelPcAppItem))
							{
								throw new NotImplementedException();
							}
							gUI_HomeDepotShopCartPanelPcAppItem.OnRemoveFromCartButtonClicked -= ResolveRemoveFromCartButtonClicked;
							pcAppItemsPool.Release(gUI_HomeDepotShopCartPanelPcAppItem);
							pcAppItems.Remove(gUI_HomeDepotShopCartPanelPcAppItem);
						}
						else
						{
							gUI_HomeDepotShopCartPanelPaintingPaletteItem.OnRemoveFromCartButtonClicked -= ResolveRemoveFromCartButtonClicked;
							paintingPaletteItemsPool.Release(gUI_HomeDepotShopCartPanelPaintingPaletteItem);
							paintingPaletteItems.Remove(gUI_HomeDepotShopCartPanelPaintingPaletteItem);
						}
					}
					else
					{
						gUI_HomeDepotShopCartPanelToolMultipleUnitItem.OnIncreaseCountInCartButtonClicked -= ResolveIncreaseCountInCartButtonClicked;
						gUI_HomeDepotShopCartPanelToolMultipleUnitItem.OnDecreaseCountInCartButtonClicked -= ResolveDecreaseCountInCartButtonClicked;
						gUI_HomeDepotShopCartPanelToolMultipleUnitItem.OnRemoveFromCartButtonClicked -= ResolveRemoveFromCartButtonClicked;
						gUI_HomeDepotShopCartPanelToolMultipleUnitItem.OnInputValueChanged -= ResolveInputValueChanged;
						toolMultipleUnitItemsPool.Release(gUI_HomeDepotShopCartPanelToolMultipleUnitItem);
						cleaningToolItems.Remove(gUI_HomeDepotShopCartPanelToolMultipleUnitItem);
					}
				}
				else
				{
					gUI_HomeDepotShopCartPanelToolSingleUnitItem.OnRemoveFromCartButtonClicked -= ResolveRemoveFromCartButtonClicked;
					toolSingleUnitItemsPool.Release(gUI_HomeDepotShopCartPanelToolSingleUnitItem);
					cleaningToolItems.Remove(gUI_HomeDepotShopCartPanelToolSingleUnitItem);
				}
			}
			else
			{
				gUI_HomeDepotShopCartPanelDecorItem.OnIncreaseCountInCartButtonClicked -= ResolveIncreaseCountInCartButtonClicked;
				gUI_HomeDepotShopCartPanelDecorItem.OnDecreaseCountInCartButtonClicked -= ResolveDecreaseCountInCartButtonClicked;
				gUI_HomeDepotShopCartPanelDecorItem.OnRemoveFromCartButtonClicked -= ResolveRemoveFromCartButtonClicked;
				gUI_HomeDepotShopCartPanelDecorItem.OnInputValueChanged -= ResolveInputValueChanged;
				decorItemsPool.Release(gUI_HomeDepotShopCartPanelDecorItem);
				decorItems.Remove(gUI_HomeDepotShopCartPanelDecorItem);
			}
		}
	}
}
