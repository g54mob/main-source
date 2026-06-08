using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TwitchLib.Api.Helix.Models.Helpers;

namespace TwitchLib.Api.Helpers
{
	public static class ExtensionAnalyticsHelper
	{
		public static async Task<List<ExtensionAnalytics>> HandleUrlAsync(string url)
		{
			IEnumerable<string> data = ExtractData(await GetContentsAsync(url));
			return data.Select((string line) => new ExtensionAnalytics(line)).ToList();
		}

		private static IEnumerable<string> ExtractData(IEnumerable<string> cnts)
		{
			return cnts.Where((string line) => line.Any(char.IsDigit)).ToList();
		}

		private static async Task<string[]> GetContentsAsync(string url)
		{
			HttpClient client = new HttpClient();
			return (await client.GetStringAsync(url)).Split(new string[1] { Environment.NewLine }, StringSplitOptions.None);
		}
	}
}
