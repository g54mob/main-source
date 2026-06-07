using System.Collections.Generic;
using Newtonsoft.Json;

namespace Coherence.Cloud
{
	internal struct RoomCreationRequest
	{
		[JsonProperty("tags")]
		public string[] Tags;

		[JsonProperty("kv")]
		public Dictionary<string, string> KV;

		[JsonProperty("region")]
		public string Region;

		[JsonProperty("sim_slug")]
		public string SimSlug;

		[JsonProperty("max_players")]
		public int MaxClients;

		[JsonProperty("find_or_create")]
		public bool FindOrCreate;
	}
}
