using Newtonsoft.Json;

namespace Coherence.Cloud
{
	public struct GameServerMatchOptions
	{
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
