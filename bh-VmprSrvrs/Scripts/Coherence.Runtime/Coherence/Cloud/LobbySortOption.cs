using Newtonsoft.Json;

namespace Coherence.Cloud
{
	public struct LobbySortOption
	{
		[JsonProperty("key")]
		public string Key;

		[JsonProperty("desc")]
		public bool Descending;
	}
}
