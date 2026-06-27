using Restory.Data.Shops.HomeDepot;
using UnityEngine;

namespace Restory.UI.Presenters.Shops.HomeDepot
{
	public sealed class GUI_HomeDepotShopPcAppItem : GUI_HomeDepotShopSingleUnitItem
	{
		protected override void SetUpView(HomeDepotShopItemData shopItemData, int countInCart, bool insufficientFunds)
		{
			if (!(shopItemData is HomeDepotShopPcAppItemData homeDepotShopPcAppItemData))
			{
				Debug.LogError("[GUI_HomeDepotShopPcAppItem] was unable to set up its view, " + string.Format("because supplied [{0}] was not [{1}]", shopItemData, "HomeDepotShopPcAppItemData"));
			}
			else
			{
				view.SetUpInitialInfo(homeDepotShopPcAppItemData.Info.Icon, localizationSystem.GetTranslation(homeDepotShopPcAppItemData.Info.NameLocalizationKey), localizationSystem.GetTranslation(homeDepotShopPcAppItemData.Info.ShopDescriptionLocalizationKey), homeDepotShopPcAppItemData.Price, countInCart, insufficientFunds, shopItemData.ContentRestriction);
			}
		}
	}
}
