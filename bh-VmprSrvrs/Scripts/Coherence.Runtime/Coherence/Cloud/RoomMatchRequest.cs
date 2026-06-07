using Newtonsoft.Json;

namespace Coherence.Cloud
{
	internal struct RoomMatchRequest
	{
		[JsonProperty("tags")]
		public string[] Tags;

		[JsonProperty("region")]
		public string Region;

		[JsonProperty("sim_slug")]
		public string SimSlug;
	}
}
