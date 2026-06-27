using Restory.Data.Shops.HomeDepot;
using Restory.Gameplay.Equipment;
using Restory.UI.Views.Shops.HomeDepot;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.Shops.HomeDepot
{
	public sealed class GUI_HomeDepotShopPaintingPaletteItem : GUI_HomeDepotShopSingleUnitItem
	{
		private AvailableToolsTrackingService toolsTrackingService;

		[Inject]
		private void Construct(AvailableToolsTrackingService toolsTrackingService)
		{
			this.toolsTrackingService = toolsTrackingService;
		}

		protected override void SetUpView(HomeDepotShopItemData shopItemData, int countInCart, bool insufficientFunds)
		{
			if (!(shopItemData is HomeDepotShopPaintingPaletteItemData homeDepotShopPaintingPaletteItemData))
			{
				Debug.LogError("[GUI_HomeDepotShopPaintingPaletteItem] was unable to set up its view, " + string.Format("because supplied [{0}] was not [{1}]", shopItemData, "HomeDepotShopPaintingPaletteItemData"));
				return;
			}
			if (!(view is GUI_HomeDepotShopPaintingPaletteItemView gUI_HomeDepotShopPaintingPaletteItemView))
			{
				Debug.LogError("[GUI_HomeDepotShopPaintingPaletteItem] was unable to set up its view, " + string.Format("because attached [{0}] was not [{1}]", view, "GUI_HomeDepotShopPaintingPaletteItemView"));
				return;
			}
			view.SetUpInitialInfo(homeDepotShopPaintingPaletteItemData.Palette.Icon, localizationSystem.GetTranslation(homeDepotShopPaintingPaletteItemData.Palette.NameLocalizationKey), localizationSystem.GetTranslation(homeDepotShopPaintingPaletteItemData.Palette.DescriptionLocalizationKey), homeDepotShopPaintingPaletteItemData.Price, countInCart, insufficientFunds, shopItemData.ContentRestriction);
			bool isBlocked = !toolsTrackingService.HasDevicePaintingTool;
			gUI_HomeDepotShopPaintingPaletteItemView.SetupPaletteView(homeDepotShopPaintingPaletteItemData.Palette, isBlocked);
		}
	}
}
