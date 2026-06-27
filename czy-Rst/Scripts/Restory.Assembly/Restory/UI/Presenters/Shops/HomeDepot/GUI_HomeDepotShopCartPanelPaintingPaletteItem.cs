using System;
using Restory.Data.Shops.HomeDepot;
using Restory.UI.Views.Shops.HomeDepot;
using UnityEngine;

namespace Restory.UI.Presenters.Shops.HomeDepot
{
	public sealed class GUI_HomeDepotShopCartPanelPaintingPaletteItem : GUI_HomeDepotShopCartPanelItem, IShopCartItemGuiSingleUnit, IShopCartItemGui
	{
		[SerializeField]
		private GUI_HomeDepotShopCartPanelPaintingPaletteItemView view;

		public event Action<IShopCartItemGuiSingleUnit> OnRemoveFromCartButtonClicked;

		protected override void SetUpView(HomeDepotShopItemData shopItem)
		{
			if (!(shopItem is HomeDepotShopPaintingPaletteItemData homeDepotShopPaintingPaletteItemData))
			{
				Debug.LogError("[HomeDepotShopItemData] was unable to set up its view, " + string.Format("because supplied [{0}] was not [{1}]", shopItem, "HomeDepotShopPaintingPaletteItemData"));
				return;
			}
			view.SetUpGeneralInfo(homeDepotShopPaintingPaletteItemData.Palette.Icon, localizationSystem.GetTranslation(homeDepotShopPaintingPaletteItemData.Palette.NameLocalizationKey), localizationSystem.GetTranslation(homeDepotShopPaintingPaletteItemData.Palette.DescriptionLocalizationKey), homeDepotShopPaintingPaletteItemData.Price);
			view.SetupPaletteView(homeDepotShopPaintingPaletteItemData.Palette);
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
