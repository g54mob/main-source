using System.Collections.Generic;
using Newtonsoft.Json;

namespace Coherence.Cloud
{
	public struct GameServerData
	{
		[JsonProperty("id")]
		public ulong Id;

		[JsonProperty("region")]
		public string Region;

		[JsonProperty("slug")]
		public string Slug;

		[JsonProperty("tag")]
		public string Tag;

		[JsonProperty("kv")]
		public Dictionary<string, string> KV;

		[JsonProperty("size")]
		public string Size;

		[JsonProperty("max_players")]
		public int MaxPlayers;

		[JsonProperty("connected_players")]
		public int ConnectedPlayers;

		[JsonProperty("suspended")]
		public bool Suspended;

		[JsonProperty("ip")]
		public string Ip;

		[JsonProperty("port")]
		public int Port;

		[JsonProperty("created_at")]
		public int CreatedAt;

		[JsonProperty("last_started_at")]
		public int LastStartedAt;
	}
}
