using System;
using System.Collections.Generic;
using Restory.Data.Shops.HomeDepot;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class HomeDepotShopServiceSaveData
	{
		public List<HomeDepotShopDecorItemData> DecorItems { get; set; }

		public List<HomeDepotShopCleaningToolItemData> CleaningToolItems { get; set; }

		public List<HomeDepotShopPaintingPaletteItemData> PaletteItems { get; set; }

		public List<HomeDepotShopPcAppItemData> PcAppItems { get; set; }
	}
}
