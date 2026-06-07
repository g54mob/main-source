using System.Collections.Generic;
using Newtonsoft.Json;

namespace DV.UI.Manual
{
	public class ManualMetadata
	{
		[JsonProperty]
		public string wikiUrlPrefix;

		[JsonProperty]
		public ManualTreeNode tree;

		[JsonProperty]
		public Dictionary<string, LangData> langs;

		public static ManualMetadata FromJson(string json)
		{
			return JsonConvert.DeserializeObject<ManualMetadata>(json);
		}
	}
}
