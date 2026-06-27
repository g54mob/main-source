using UnityEngine;

namespace Restory.Data.Shops.HomeDepot
{
	[CreateAssetMenu(menuName = "Restory/Shops/HomeDepotShop", fileName = "Name - HomeDepotShop")]
	public class HomeDepotShopInfo : ScriptableObject
	{
		[SerializeField]
		private HomeDepotShopDecorItemData[] decorItemsList = new HomeDepotShopDecorItemData[0];

		[SerializeField]
		private HomeDepotShopCleaningToolItemData[] cleaningToolsItemsList = new HomeDepotShopCleaningToolItemData[0];

		[SerializeField]
		private HomeDepotShopPaintingPaletteItemData[] paletteItemsList = new HomeDepotShopPaintingPaletteItemData[0];

		[SerializeField]
		private HomeDepotShopPcAppItemData[] pcAppItemsList = new HomeDepotShopPcAppItemData[0];

		public HomeDepotShopDecorItemData[] DecorItemsList => decorItemsList;

		public HomeDepotShopCleaningToolItemData[] CleaningToolsItemsList => cleaningToolsItemsList;

		public HomeDepotShopPaintingPaletteItemData[] PaletteItemsList => paletteItemsList;

		public HomeDepotShopPcAppItemData[] PcAppItemsList => pcAppItemsList;
	}
}
