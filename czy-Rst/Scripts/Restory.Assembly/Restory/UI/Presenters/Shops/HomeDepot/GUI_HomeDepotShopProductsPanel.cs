using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.Shops.HomeDepot;
using Restory.Gameplay.Inventory;
using Restory.Gameplay.Shops.HomeDepot;
using Restory.ObjectPools;
using Restory.UI.Pools.Shops.Decors;
using Restory.UI.Views.Shops.HomeDepot;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.Shops.HomeDepot
{
	public sealed class GUI_HomeDepotShopProductsPanel : MonoBehaviour
	{
		[SerializeField]
		private GUI_HomeDepotShopProductsPanelView view;

		[SerializeField]
		private GUI_HomeDepotShopProductsPanelFilter filters;

		private readonly List<GUI_HomeDepotShopDecorItem> decorItems = new List<GUI_HomeDepotShopDecorItem>();

		private readonly List<GUI_HomeDepotShopItem> cleaningToolItems = new List<GUI_HomeDepotShopItem>();

		private readonly List<GUI_HomeDepotShopPaintingPaletteItem> paintingPaletteItems = new List<GUI_HomeDepotShopPaintingPaletteItem>();

		private readonly List<GUI_HomeDepotShopPcAppItem> pcAppItems = new List<GUI_HomeDepotShopPcAppItem>();

		private Wallet wallet;

		private HomeDepotShopService homeDepotShopService;

		private GUI_HomeDepotShopDecorItemsPool decorItemsPool;

		private GUI_HomeDepotShopToolSingleUnitItemsPool toolSingleUnitItemsPool;

		private GUI_HomeDepotShopToolMultipleUnitItemsPool toolMultipleUnitItemsPool;

		private GUI_HomeDepotShopPaintingPaletteItemsPool paintingPaletteItemsPool;

		private GUI_HomeDepotShopPcAppItemsPool pcAppItemsPool;

		private HomeDepotShopInteractor shopInteractor;

		public event Action OnGoToCartButtonClicked;

		[Inject]
		private void Construct(Wallet wallet, HomeDepotShopService homeDepotShopService, GUI_HomeDepotShopDecorItemsPool decorItemsPool, GUI_HomeDepotShopToolSingleUnitItemsPool toolSingleUnitItemsPool, GUI_HomeDepotShopToolMultipleUnitItemsPool toolMultipleUnitItemsPool, GUI_HomeDepotShopPaintingPaletteItemsPool paintingPaletteItemsPool, GUI_HomeDepotShopPcAppItemsPool pcAppItemsPool, HomeDepotShopInteractor shopInteractor)
		{
			this.wallet = wallet;
			this.homeDepotShopService = homeDepotShopService;
			this.decorItemsPool = decorItemsPool;
			this.toolSingleUnitItemsPool = toolSingleUnitItemsPool;
			this.toolMultipleUnitItemsPool = toolMultipleUnitItemsPool;
			this.paintingPaletteItemsPool = paintingPaletteItemsPool;
			this.pcAppItemsPool = pcAppItemsPool;
			this.shopInteractor = shopInteractor;
		}

		private void OnEnable()
		{
			view.OnGoToCartButtonClicked += ResolveGoToCartButtonClicked;
			filters.OnFiltersValueChanged += ResolveFiltersValueChanged;
		}

		private void OnDisable()
		{
			view.OnGoToCartButtonClicked -= ResolveGoToCartButtonClicked;
			filters.OnFiltersValueChanged -= ResolveFiltersValueChanged;
			ClearItems();
		}

		public void Show()
		{
			filters.SetUpFilters(homeDepotShopService.GetAllowedDecorItems(), homeDepotShopService.GetAllowedCleaningTools(), homeDepotShopService.GetAllowedPaintingPalettes(), homeDepotShopService.GetAllowedPcApps());
			UpdateItems();
			view.SetProductsInCartCount(shopInteractor.GetTotalItemsCountInShoppingCart());
			view.Show();
			filters.Activate();
			wallet.OnMoneyAmountChanged += ResolveOnMoneyAmountChanged;
		}

		public void Hide()
		{
			wallet.OnMoneyAmountChanged -= ResolveOnMoneyAmountChanged;
			view.Hide();
			filters.Deactivate();
			ClearItems();
		}

		private void UpdateItems()
		{
			ClearItems();
			foreach (HomeDepotShopCleaningToolItemData filteredCleaningToolItem in filters.FilteredCleaningToolItems)
			{
				if (filteredCleaningToolItem.ToolInfo.CanStoreMultipleCopies)
				{
					GUI_HomeDepotShopToolMultipleUnitItem gUI_HomeDepotShopToolMultipleUnitItem = toolMultipleUnitItemsPool.Get<GUI_HomeDepotShopToolMultipleUnitItem>();
					gUI_HomeDepotShopToolMultipleUnitItem.Init(filteredCleaningToolItem, shopInteractor.GetItemCountInShoppingCart(filteredCleaningToolItem), wallet.MoneyAvailable < filteredCleaningToolItem.Price);
					gUI_HomeDepotShopToolMultipleUnitItem.OnAddToCartButtonClicked += ResolveAddItemToCartButtonClicked;
					gUI_HomeDepotShopToolMultipleUnitItem.OnIncreaseCountInCartButtonClicked += ResolveIncreaseCountInCartButtonClicked;
					gUI_HomeDepotShopToolMultipleUnitItem.OnDecreaseCountInCartButtonClicked += ResolveDecreaseCountInCartButtonClicked;
					gUI_HomeDepotShopToolMultipleUnitItem.OnInputValueChanged += ResolveInputValueChanged;
					cleaningToolItems.Add(gUI_HomeDepotShopToolMultipleUnitItem);
				}
				else
				{
					GUI_HomeDepotShopToolSingleUnitItem gUI_HomeDepotShopToolSingleUnitItem = toolSingleUnitItemsPool.Get<GUI_HomeDepotShopToolSingleUnitItem>();
					gUI_HomeDepotShopToolSingleUnitItem.Init(filteredCleaningToolItem, shopInteractor.GetItemCountInShoppingCart(filteredCleaningToolItem), wallet.MoneyAvailable < filteredCleaningToolItem.Price);
					gUI_HomeDepotShopToolSingleUnitItem.OnAddToCartButtonClicked += ResolveAddItemToCartButtonClicked;
					gUI_HomeDepotShopToolSingleUnitItem.OnRemoveFromCartButtonClicked += ResolveRemoveItemFromCartClicked;
					cleaningToolItems.Add(gUI_HomeDepotShopToolSingleUnitItem);
				}
			}
			foreach (HomeDepotShopDecorItemData filteredDecorItem in filters.FilteredDecorItems)
			{
				GUI_HomeDepotShopDecorItem gUI_HomeDepotShopDecorItem = decorItemsPool.Get<GUI_HomeDepotShopDecorItem>();
				gUI_HomeDepotShopDecorItem.Init(filteredDecorItem, shopInteractor.GetItemCountInShoppingCart(filteredDecorItem), wallet.MoneyAvailable < filteredDecorItem.Price);
				gUI_HomeDepotShopDecorItem.OnAddToCartButtonClicked += ResolveAddItemToCartButtonClicked;
				gUI_HomeDepotShopDecorItem.OnIncreaseCountInCartButtonClicked += ResolveIncreaseCountInCartButtonClicked;
				gUI_HomeDepotShopDecorItem.OnDecreaseCountInCartButtonClicked += ResolveDecreaseCountInCartButtonClicked;
				gUI_HomeDepotShopDecorItem.OnInputValueChanged += ResolveInputValueChanged;
				decorItems.Add(gUI_HomeDepotShopDecorItem);
			}
			foreach (HomeDepotShopPaintingPaletteItemData filteredPaintingPaletteItem in filters.FilteredPaintingPaletteItems)
			{
				GUI_HomeDepotShopPaintingPaletteItem gUI_HomeDepotShopPaintingPaletteItem = paintingPaletteItemsPool.Get<GUI_HomeDepotShopPaintingPaletteItem>();
				gUI_HomeDepotShopPaintingPaletteItem.Init(filteredPaintingPaletteItem, shopInteractor.GetItemCountInShoppingCart(filteredPaintingPaletteItem), wallet.MoneyAvailable < filteredPaintingPaletteItem.Price);
				gUI_HomeDepotShopPaintingPaletteItem.OnAddToCartButtonClicked += ResolveAddItemToCartButtonClicked;
				gUI_HomeDepotShopPaintingPaletteItem.OnRemoveFromCartButtonClicked += ResolveRemoveItemFromCartClicked;
				paintingPaletteItems.Add(gUI_HomeDepotShopPaintingPaletteItem);
			}
			foreach (HomeDepotShopPcAppItemData filteredPcAppItem in filters.FilteredPcAppItems)
			{
				GUI_HomeDepotShopPcAppItem gUI_HomeDepotShopPcAppItem = pcAppItemsPool.Get<GUI_HomeDepotShopPcAppItem>();
				gUI_HomeDepotShopPcAppItem.Init(filteredPcAppItem, shopInteractor.GetItemCountInShoppingCart(filteredPcAppItem), wallet.MoneyAvailable < filteredPcAppItem.Price);
				gUI_HomeDepotShopPcAppItem.OnAddToCartButtonClicked += ResolveAddItemToCartButtonClicked;
				gUI_HomeDepotShopPcAppItem.OnRemoveFromCartButtonClicked += ResolveRemoveItemFromCartClicked;
				pcAppItems.Add(gUI_HomeDepotShopPcAppItem);
			}
			view.AttachProductsUiObjects(cleaningToolItems.Select((GUI_HomeDepotShopItem item) => item.transform).Concat(decorItems.Select((GUI_HomeDepotShopDecorItem item) => item.transform)).Concat(paintingPaletteItems.Select((GUI_HomeDepotShopPaintingPaletteItem item) => item.transform))
				.Concat(pcAppItems.Select((GUI_HomeDepotShopPcAppItem item) => item.transform)));
		}

		private void ClearItems()
		{
			ClearDecorItems();
			ClearCleaningToolItems();
			ClearPaintingPaletteItems();
			ClearPcAppItems();
		}

		private void ClearDecorItems()
		{
			foreach (GUI_HomeDepotShopDecorItem decorItem in decorItems)
			{
				if (decorItem.MonoShellExists())
				{
					decorItem.OnAddToCartButtonClicked -= ResolveAddItemToCartButtonClicked;
					decorItem.OnIncreaseCountInCartButtonClicked -= ResolveIncreaseCountInCartButtonClicked;
					decorItem.OnDecreaseCountInCartButtonClicked -= ResolveDecreaseCountInCartButtonClicked;
					decorItem.OnInputValueChanged -= ResolveInputValueChanged;
					decorItemsPool.Release(decorItem);
				}
			}
			decorItems.Clear();
		}

		private void ClearCleaningToolItems()
		{
			foreach (GUI_HomeDepotShopItem cleaningToolItem in cleaningToolItems)
			{
				if (!cleaningToolItem.MonoShellExists())
				{
					continue;
				}
				if (!(cleaningToolItem is GUI_HomeDepotShopToolSingleUnitItem gUI_HomeDepotShopToolSingleUnitItem))
				{
					if (cleaningToolItem is GUI_HomeDepotShopToolMultipleUnitItem gUI_HomeDepotShopToolMultipleUnitItem)
					{
						gUI_HomeDepotShopToolMultipleUnitItem.OnAddToCartButtonClicked -= ResolveAddItemToCartButtonClicked;
						gUI_HomeDepotShopToolMultipleUnitItem.OnIncreaseCountInCartButtonClicked -= ResolveIncreaseCountInCartButtonClicked;
						gUI_HomeDepotShopToolMultipleUnitItem.OnDecreaseCountInCartButtonClicked -= ResolveDecreaseCountInCartButtonClicked;
						gUI_HomeDepotShopToolMultipleUnitItem.OnInputValueChanged -= ResolveInputValueChanged;
						toolMultipleUnitItemsPool.Release(gUI_HomeDepotShopToolMultipleUnitItem);
					}
					else
					{
						Debug.LogError("[GUI_HomeDepotShopProductsPanel] was unable to clear cleaning tool item, " + $"because it has unsupported type [{cleaningToolItem.GetType()}]");
						UnityEngine.Object.Destroy(cleaningToolItem.gameObject);
					}
				}
				else
				{
					gUI_HomeDepotShopToolSingleUnitItem.OnAddToCartButtonClicked -= ResolveAddItemToCartButtonClicked;
					gUI_HomeDepotShopToolSingleUnitItem.OnRemoveFromCartButtonClicked -= ResolveRemoveItemFromCartClicked;
					toolSingleUnitItemsPool.Release(gUI_HomeDepotShopToolSingleUnitItem);
				}
			}
			cleaningToolItems.Clear();
		}

		private void ClearPaintingPaletteItems()
		{
			foreach (GUI_HomeDepotShopPaintingPaletteItem paintingPaletteItem in paintingPaletteItems)
			{
				if (paintingPaletteItem.MonoShellExists())
				{
					paintingPaletteItem.OnAddToCartButtonClicked -= ResolveAddItemToCartButtonClicked;
					paintingPaletteItem.OnRemoveFromCartButtonClicked -= ResolveRemoveItemFromCartClicked;
					paintingPaletteItemsPool.Release(paintingPaletteItem);
				}
			}
			paintingPaletteItems.Clear();
		}

		private void ClearPcAppItems()
		{
			foreach (GUI_HomeDepotShopPcAppItem pcAppItem in pcAppItems)
			{
				if (pcAppItem.MonoShellExists())
				{
					pcAppItem.OnAddToCartButtonClicked -= ResolveAddItemToCartButtonClicked;
					pcAppItem.OnRemoveFromCartButtonClicked -= ResolveRemoveItemFromCartClicked;
					pcAppItemsPool.Release(pcAppItem);
				}
			}
			pcAppItems.Clear();
		}

		private void ChangeCountInCart(IShopItemGuiMultipleUnits item, int addendum)
		{
			if (!(item is GUI_HomeDepotShopItem gUI_HomeDepotShopItem))
			{
				Debug.LogError("[GUI_HomeDepotShopProductsPanel] was unable to change count for item in cart, " + string.Format("because it has type [{0}], instead of [{1}]", item.GetType(), "GUI_HomeDepotShopItem"));
				return;
			}
			int itemCountInShoppingCart = shopInteractor.GetItemCountInShoppingCart(gUI_HomeDepotShopItem.ShopItemData);
			int count = item.UpdateCountInCart(itemCountInShoppingCart + addendum, wallet.MoneyAvailable < gUI_HomeDepotShopItem.ShopItemData.Price);
			SetItemCount(item, count);
		}

		private void SetItemCount(GUI_HomeDepotShopItem item, int count)
		{
			shopInteractor.SetItemCountInShoppingCart(item.ShopItemData, count);
			view.SetProductsInCartCount(shopInteractor.GetTotalItemsCountInShoppingCart());
		}

		private void SetItemCount(IShopItemGuiMultipleUnits item, int count)
		{
			if (!(item is GUI_HomeDepotShopItem gUI_HomeDepotShopItem))
			{
				Debug.LogError("[GUI_HomeDepotShopProductsPanel] was unable to set count for item in cart, " + string.Format("because it has type [{0}], instead of [{1}]", item.GetType(), "GUI_HomeDepotShopItem"));
			}
			else if ((bool)gUI_HomeDepotShopItem.ContentRestriction)
			{
				Debug.LogError($"Value of restricted item {gUI_HomeDepotShopItem.GetType()} can't be changed in cart");
			}
			else
			{
				SetItemCount(gUI_HomeDepotShopItem, count);
			}
		}

		private void SetItemCount(IShopItemGuiSingleUnit item, int count)
		{
			if (!(item is GUI_HomeDepotShopItem gUI_HomeDepotShopItem))
			{
				Debug.LogError("[GUI_HomeDepotShopProductsPanel] was unable to set count for item in cart, " + string.Format("because it has type [{0}], instead of [{1}]", item.GetType(), "GUI_HomeDepotShopItem"));
			}
			else if ((bool)gUI_HomeDepotShopItem.ContentRestriction)
			{
				Debug.LogError($"Value of restricted item {gUI_HomeDepotShopItem.GetType()} can't be changed in cart");
			}
			else
			{
				SetItemCount(gUI_HomeDepotShopItem, count);
			}
		}

		private void ResolveAddItemToCartButtonClicked(IShopItemGuiMultipleUnits item)
		{
			ChangeCountInCart(item, 1);
		}

		private void ResolveIncreaseCountInCartButtonClicked(IShopItemGuiMultipleUnits item)
		{
			ChangeCountInCart(item, 1);
		}

		private void ResolveDecreaseCountInCartButtonClicked(IShopItemGuiMultipleUnits item)
		{
			ChangeCountInCart(item, -1);
		}

		private void ResolveInputValueChanged(IShopItemGuiMultipleUnits item, int value)
		{
			SetItemCount(item, value);
		}

		private void ResolveAddItemToCartButtonClicked(IShopItemGuiSingleUnit item)
		{
			SetItemCount(item, 1);
		}

		private void ResolveRemoveItemFromCartClicked(IShopItemGuiSingleUnit item)
		{
			SetItemCount(item, 0);
		}

		private void ResolveGoToCartButtonClicked()
		{
			if (shopInteractor.GetTotalItemsCountInShoppingCart() != 0)
			{
				this.OnGoToCartButtonClicked?.Invoke();
			}
		}

		private void ResolveFiltersValueChanged()
		{
			UpdateItems();
		}

		private void ResolveOnMoneyAmountChanged()
		{
			UpdateItems();
		}
	}
}
