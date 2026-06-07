using Newtonsoft.Json;

namespace Coherence.Runtime
{
	internal struct MatchRequest
	{
		[JsonProperty("region")]
		public string Region;

		[JsonProperty("team")]
		public string Team;

		[JsonProperty("score")]
		public int Score;

		[JsonProperty("payload")]
		public string Payload;

		[JsonProperty("friends")]
		public string[] Friends;

		[JsonProperty("tags")]
		public string[] Tags;
	}
}
