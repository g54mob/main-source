using System;
using HTTP;

namespace GoogleDocs
{
	public class GSLoader
	{
		private const string GWA_ID = "AKfycbzskft4gA_AKNA-YRlLp-npiydacgvADMS9SaE9upbg_FzoJhE";

		private const string GWA_URL_PATTERN = "https://script.google.com/macros/s/{0}/exec?id={1}";

		private const string GWA_SHEET_URL_PATTERN = "https://script.google.com/macros/s/{0}/exec?id={1}&sheet={2}";

		private IHTTP _http;

		public GSLoader(IHTTP http)
		{
			_http = http;
		}

		public void LoadAllSheets(string ssid, Action<string, bool> callback)
		{
			_http.Get(string.Format("https://script.google.com/macros/s/{0}/exec?id={1}", "AKfycbzskft4gA_AKNA-YRlLp-npiydacgvADMS9SaE9upbg_FzoJhE", ssid), callback);
		}

		public void LoadSheet(string ssid, string sheetname, Action<string, bool> callback)
		{
			_http.Get(string.Format("https://script.google.com/macros/s/{0}/exec?id={1}&sheet={2}", "AKfycbzskft4gA_AKNA-YRlLp-npiydacgvADMS9SaE9upbg_FzoJhE", ssid, sheetname), callback);
		}
	}
}
