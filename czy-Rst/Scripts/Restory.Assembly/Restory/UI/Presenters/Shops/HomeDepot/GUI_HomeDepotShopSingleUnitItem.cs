using System;
using Restory.UI.Views.Shops.HomeDepot;
using UnityEngine;

namespace Restory.UI.Presenters.Shops.HomeDepot
{
	public abstract class GUI_HomeDepotShopSingleUnitItem : GUI_HomeDepotShopItem, IShopItemGuiSingleUnit, IShopItemGui
	{
		[SerializeField]
		protected GUI_HomeDepotShopSingleUnitItemView view;

		public event Action<IShopItemGuiSingleUnit> OnAddToCartButtonClicked;

		public event Action<IShopItemGuiSingleUnit> OnRemoveFromCartButtonClicked;

		protected override void Subscribe()
		{
			base.Subscribe();
			view.OnAddToCartButtonClicked += ResolveAddToCartButtonClicked;
			view.OnRemoveFromCartButtonClicked += ResolveRemoveFromCartButtonClicked;
		}

		protected override void Unsubscribe()
		{
			view.OnAddToCartButtonClicked -= ResolveAddToCartButtonClicked;
			view.OnRemoveFromCartButtonClicked -= ResolveRemoveFromCartButtonClicked;
			base.Unsubscribe();
		}

		private void ResolveAddToCartButtonClicked()
		{
			this.OnAddToCartButtonClicked?.Invoke(this);
		}

		private void ResolveRemoveFromCartButtonClicked()
		{
			this.OnRemoveFromCartButtonClicked?.Invoke(this);
		}
	}
}
