using Restory.Gameplay.Shops.Devices;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.Shops.Devices
{
	public sealed class GUI_DeviceShopPage : GUI_WebBrowserPageBase
	{
		[SerializeField]
		private GUI_DeviceShopPanel shopPanel;

		[SerializeField]
		private GUI_DeviceShopCartPanel cartPanel;

		private DeviceShopInteractor shopInteractor;

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
		private void Construct(DeviceShopInteractor shopInteractor)
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
				if (shopInteractor.LotsInShoppingCart.Count == 0)
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
				shopPanel.Show();
				shopPanel.OnOpenCartButtonClicked += ResolveChangeModeButtonClicked;
				break;
			case ShopPanelState.ShoppingCart:
				cartPanel.Show();
				cartPanel.OnExitCartButtonClicked += ResolveChangeModeButtonClicked;
				break;
			}
		}

		private void HideCurrentWindows()
		{
			switch (currentState)
			{
			case ShopPanelState.None:
				shopPanel.Hide();
				shopPanel.OnOpenCartButtonClicked -= ResolveChangeModeButtonClicked;
				cartPanel.Hide();
				cartPanel.OnExitCartButtonClicked -= ResolveChangeModeButtonClicked;
				break;
			case ShopPanelState.ProductsSelection:
				shopPanel.Hide();
				shopPanel.OnOpenCartButtonClicked -= ResolveChangeModeButtonClicked;
				break;
			case ShopPanelState.ShoppingCart:
				cartPanel.Hide();
				cartPanel.OnExitCartButtonClicked -= ResolveChangeModeButtonClicked;
				break;
			}
		}

		private void ResolveChangeModeButtonClicked()
		{
			CurrentState = ((CurrentState != ShopPanelState.ShoppingCart) ? ShopPanelState.ShoppingCart : ShopPanelState.ProductsSelection);
		}
	}
}
