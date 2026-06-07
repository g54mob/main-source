using Newtonsoft.Json;

namespace Coherence.Cloud
{
	internal struct RegionFetchResponse
	{
		[JsonProperty("regions")]
		public string[] Regions;
	}
}
