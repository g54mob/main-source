using System;
using Restory.Data.Shops.HomeDepot;
using Restory.UI.Views.Shops.HomeDepot;
using UnityEngine;

namespace Restory.UI.Presenters.Shops.HomeDepot
{
	public sealed class GUI_HomeDepotShopCartPanelPcAppItem : GUI_HomeDepotShopCartPanelItem, IShopCartItemGuiSingleUnit, IShopCartItemGui
	{
		[SerializeField]
		private GUI_HomeDepotShopCartPanelPcAppItemView view;

		public event Action<IShopCartItemGuiSingleUnit> OnRemoveFromCartButtonClicked;

		protected override void SetUpView(HomeDepotShopItemData shopItem)
		{
			if (!(shopItem is HomeDepotShopPcAppItemData homeDepotShopPcAppItemData))
			{
				Debug.LogError("[HomeDepotShopItemData] was unable to set up its view, " + string.Format("because supplied [{0}] was not [{1}]", shopItem, "HomeDepotShopPcAppItemData"));
			}
			else
			{
				view.SetUpGeneralInfo(homeDepotShopPcAppItemData.Info.Icon, localizationSystem.GetTranslation(homeDepotShopPcAppItemData.Info.NameLocalizationKey), localizationSystem.GetTranslation(homeDepotShopPcAppItemData.Info.ShopDescriptionLocalizationKey), homeDepotShopPcAppItemData.Price);
			}
		}

		protected override void Subscribe()
		{
			base.Subscribe();
			view.OnRemoveFromCartButtonClicked += ResolveRemoveFromCartButtonClicked;
		}

		protected override void Unsubscribe()
		{
			view.OnRemoveFromCartButtonClicked -= ResolveRemoveFromCartButtonClicked;
			base.Unsubscribe();
		}

		private void ResolveRemoveFromCartButtonClicked()
		{
			this.OnRemoveFromCartButtonClicked?.Invoke(this);
		}
	}
}
