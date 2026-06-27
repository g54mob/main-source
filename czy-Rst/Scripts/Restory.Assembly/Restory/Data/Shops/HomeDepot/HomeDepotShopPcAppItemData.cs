using System;
using Restory.Data.PC;

namespace Restory.Data.Shops.HomeDepot
{
	[Serializable]
	public class HomeDepotShopPcAppItemData : HomeDepotShopItemData
	{
		public PcAppInfo Info;

		public HomeDepotShopPcAppItemData Clone()
		{
			return MemberwiseClone() as HomeDepotShopPcAppItemData;
		}
	}
}
