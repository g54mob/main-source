using Restory.Data.Shops.HomeDepot;
using UnityEngine;

namespace Restory.UI.Presenters.Shops.HomeDepot
{
	public sealed class GUI_HomeDepotShopToolSingleUnitItem : GUI_HomeDepotShopSingleUnitItem
	{
		protected override void SetUpView(HomeDepotShopItemData shopItemData, int countInCart, bool insufficientFunds)
		{
			if (!(shopItemData is HomeDepotShopCleaningToolItemData homeDepotShopCleaningToolItemData))
			{
				Debug.LogError("[GUI_HomeDepotShopToolSingleUnitItem] was unable to set up its view, " + string.Format("because supplied [{0}] was not [{1}]", shopItemData, "HomeDepotShopCleaningToolItemData"));
			}
			else
			{
				view.SetUpInitialInfo(homeDepotShopCleaningToolItemData.ToolInfo.Icon, localizationSystem.GetTranslation(homeDepotShopCleaningToolItemData.ToolInfo.NameLocalizationKey), localizationSystem.GetTranslation(homeDepotShopCleaningToolItemData.ToolInfo.DescriptionLocalizationKey), homeDepotShopCleaningToolItemData.Price, countInCart, insufficientFunds, shopItemData.ContentRestriction);
			}
		}
	}
}
