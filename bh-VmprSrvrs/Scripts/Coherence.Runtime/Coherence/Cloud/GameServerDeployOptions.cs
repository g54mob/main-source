using System.Collections.Generic;
using Newtonsoft.Json;

namespace Coherence.Cloud
{
	public struct GameServerDeployOptions
	{
		[JsonProperty("kv")]
		public Dictionary<string, string> KV;

		[JsonProperty("max_players")]
		public int MaxPlayers;

		[JsonProperty("region")]
		public string Region;

		[JsonProperty("size")]
		public string Size;

		[JsonProperty("slug")]
		public string Slug;

		[JsonProperty("tag")]
		public string Tag;
	}
}
