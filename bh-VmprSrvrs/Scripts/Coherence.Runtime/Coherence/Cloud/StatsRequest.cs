using System.Collections.Generic;
using Newtonsoft.Json;

namespace Coherence.Cloud
{
	internal struct StatsRequest
	{
		[JsonProperty("tags")]
		public List<string> Tags;

		[JsonProperty("regions")]
		public List<string> Regions;

		public static string GetRequestBody(List<string> tags = null, List<string> regions = null)
		{
			return null;
		}
	}
}
