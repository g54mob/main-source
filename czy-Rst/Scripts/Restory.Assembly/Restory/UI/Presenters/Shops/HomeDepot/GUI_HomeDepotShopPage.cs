using Restory.Gameplay.Shops.HomeDepot;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.Shops.HomeDepot
{
	public sealed class GUI_HomeDepotShopPage : GUI_WebBrowserPageBase
	{
		[SerializeField]
		private GUI_HomeDepotShopProductsPanel productsPanel;

		[SerializeField]
		private GUI_HomeDepotShopCartPanel cartPanel;

		private HomeDepotShopInteractor shopInteractor;

		private ShopPanelState currentState;

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
		private void Construct(HomeDepotShopInteractor shopInteractor)
		{
			this.shopInteractor = shopInteractor;
		}

		private void OnDisable()
		{
			Hide();
		}

		public override void Show()
		{
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
			HideCurrentWindows();
		}

		private void ShowCurrentWindow()
		{
			switch (currentState)
			{
			case ShopPanelState.ProductsSelection:
				productsPanel.Show();
				productsPanel.OnGoToCartButtonClicked += ResolveGoToCartModeButtonClicked;
				break;
			case ShopPanelState.ShoppingCart:
				cartPanel.Show();
				cartPanel.OnExitCartButtonClicked += ResolveGoToCartModeButtonClicked;
				break;
			}
		}

		private void HideCurrentWindows()
		{
			switch (currentState)
			{
			case ShopPanelState.None:
				productsPanel.Hide();
				productsPanel.OnGoToCartButtonClicked -= ResolveGoToCartModeButtonClicked;
				cartPanel.Hide();
				cartPanel.OnExitCartButtonClicked -= ResolveGoToCartModeButtonClicked;
				break;
			case ShopPanelState.ProductsSelection:
				productsPanel.Hide();
				productsPanel.OnGoToCartButtonClicked -= ResolveGoToCartModeButtonClicked;
				break;
			case ShopPanelState.ShoppingCart:
				cartPanel.Hide();
				cartPanel.OnExitCartButtonClicked -= ResolveGoToCartModeButtonClicked;
				break;
			}
		}

		private void ResolveGoToCartModeButtonClicked()
		{
			CurrentState = ((CurrentState != ShopPanelState.ShoppingCart) ? ShopPanelState.ShoppingCart : ShopPanelState.ProductsSelection);
		}
	}
}
