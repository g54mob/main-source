using System.Collections.Generic;
using Newtonsoft.Json;

namespace DV.UI.Manual
{
	public class ManualStrings
	{
		public string code;

		public Dictionary<string, string> strings;

		[JsonProperty]
		public Dictionary<string, TranslationStats> meta;

		public static ManualStrings FromJson(string json)
		{
			return JsonConvert.DeserializeObject<ManualStrings>(json);
		}
	}
}
