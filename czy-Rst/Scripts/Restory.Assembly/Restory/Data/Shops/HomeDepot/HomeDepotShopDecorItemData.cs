using System;
using Restory.Data.Decors;

namespace Restory.Data.Shops.HomeDepot
{
	[Serializable]
	public class HomeDepotShopDecorItemData : HomeDepotShopItemData
	{
		public DecorInfo DecorInfo;

		public IShopCategory GetCategory()
		{
			IShopCategory category = Category;
			return category ?? DecorInfo.Category;
		}

		public HomeDepotShopDecorItemData Clone()
		{
			return MemberwiseClone() as HomeDepotShopDecorItemData;
		}
	}
}
