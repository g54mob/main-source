using System;
using Restory.Data.Equipment;

namespace Restory.Data.Shops.HomeDepot
{
	[Serializable]
	public class HomeDepotShopCleaningToolItemData : HomeDepotShopItemData
	{
		public ToolInfo ToolInfo;

		public IShopCategory GetCategory()
		{
			IShopCategory category = Category;
			return category ?? ToolInfo.ToolsCategory;
		}

		public HomeDepotShopCleaningToolItemData Clone()
		{
			return MemberwiseClone() as HomeDepotShopCleaningToolItemData;
		}
	}
}
