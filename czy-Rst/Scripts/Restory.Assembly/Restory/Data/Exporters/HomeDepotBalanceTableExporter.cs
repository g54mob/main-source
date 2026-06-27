using System.Collections.Generic;
using Restory.Data.Shops.HomeDepot;
using UnityEngine;

namespace Restory.Data.Exporters
{
	[CreateAssetMenu(menuName = "Restory/Exporters/HomeDepotBalanceTableExporter", fileName = "HomeDepotBalanceTableExporter")]
	public class HomeDepotBalanceTableExporter : ScriptableObject
	{
		private const string UPGRADES_GROUP = "Upgrades Section";

		private const string DECOR_GROUP = "Decor Section";

		private const string PALETTES_GROUP = "Palletes Section";

		[SerializeField]
		private string upgradesSectionHeaderName = "Upgrades";

		[SerializeField]
		private string decorSectionHeaderName = "Decor";

		[SerializeField]
		private string palettesSectionHeaderName = "Pallets";

		[SerializeField]
		private string idColumnName = "ID";

		[SerializeField]
		private string priceColumnName = "Price";

		[SerializeField]
		private string zenColumnName = "Zen";

		[SerializeField]
		private HomeDepotShopInfo targetShopInfo;

		[Space]
		private List<HomeDepotUpgradePriceRow> importedUpgradeRows = new List<HomeDepotUpgradePriceRow>();

		private List<HomeDepotDecorPriceRow> importedDecorRows = new List<HomeDepotDecorPriceRow>();

		private List<HomeDepotPalettePriceRow> importedPaletteRows = new List<HomeDepotPalettePriceRow>();

		public HomeDepotShopInfo TargetShopInfo => targetShopInfo;

		public string UpgradesSectionHeaderName => upgradesSectionHeaderName;

		public string DecorSectionHeaderName => decorSectionHeaderName;

		public string PalettesSectionHeaderName => palettesSectionHeaderName;

		public string IdColumnName => idColumnName;

		public string PriceColumnName => priceColumnName;

		public string ZenColumnName => zenColumnName;
	}
}
