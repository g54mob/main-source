using System;
using Restory.Data.Equipment;

namespace Restory.Data.Shops.HomeDepot
{
	[Serializable]
	public class HomeDepotShopPaintingPaletteItemData : HomeDepotShopItemData
	{
		public PaintingPaletteInfo Palette;

		public HomeDepotShopPaintingPaletteItemData Clone()
		{
			return MemberwiseClone() as HomeDepotShopPaintingPaletteItemData;
		}
	}
}
