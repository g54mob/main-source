using System;
using UnityEngine;

namespace Restory.UI.Views.Shops.HomeDepot
{
	public abstract class GUI_HomeDepotShopSingleUnitItemView : GUI_HomeDepotShopItemView
	{
		[SerializeField]
		private GUI_HomeDepotShopItemCartInteractionAddRemoveView cartInteractionView;

		public event Action OnAddToCartButtonClicked;

		public event Action OnRemoveFromCartButtonClicked;

		protected override void SetUpViewButtons(int countInCart, bool insufficientFunds)
		{
			if (countInCart > 0)
			{
				cartInteractionView.SetSelectedState();
			}
			else if (insufficientFunds)
			{
				cartInteractionView.SetInsufficientFundsState();
			}
			else
			{
				cartInteractionView.SetNormalState();
			}
			cartInteractionView.OnAddToCartButtonClicked += ResolveAddToCartButtonClicked;
			cartInteractionView.OnRemoveFromCartButtonClicked += ResolveRemoveFromCartButtonClicked;
		}

		protected override void CleanUpOnClean()
		{
			cartInteractionView.OnAddToCartButtonClicked -= ResolveAddToCartButtonClicked;
			cartInteractionView.OnRemoveFromCartButtonClicked -= ResolveRemoveFromCartButtonClicked;
		}

		private void ResolveAddToCartButtonClicked()
		{
			this.OnAddToCartButtonClicked?.Invoke();
		}

		private void ResolveRemoveFromCartButtonClicked()
		{
			this.OnRemoveFromCartButtonClicked?.Invoke();
		}
	}
}
