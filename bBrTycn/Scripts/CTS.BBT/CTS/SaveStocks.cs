using CTS.Core;

namespace CTS
{
	public class SaveStocks : SaveContainer
	{
		public override void Save(ES3Settings settings)
		{
			ES3.Save("BarStock", Stocks.BarStock, settings);
			ES3.Save("VendorStock", Stocks.VendorStock, settings);
			ES3.Save("StationStocksVisualManager", CTSSingleton<StationStocksVisualManager>.Instance, settings);
		}

		public override void LoadInit(ES3Settings settings)
		{
			ES3.LoadInto("BarStock", Stocks.BarStock, settings);
			ES3.LoadInto("VendorStock", Stocks.VendorStock, settings);
		}

		public override void LoadPost(ES3Settings settings)
		{
			if (ES3.KeyExists("StationStocksVisualManager", settings))
			{
				ES3.LoadInto("StationStocksVisualManager", CTSSingleton<StationStocksVisualManager>.Instance, settings);
				CTSSingleton<StationStocksVisualManager>.Instance.Refresh();
			}
		}
	}
}
