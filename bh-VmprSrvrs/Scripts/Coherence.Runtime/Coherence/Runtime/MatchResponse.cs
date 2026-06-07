using Newtonsoft.Json;

namespace Coherence.Runtime
{
	public class MatchResponse
	{
		[JsonProperty("match_id")]
		public string MatchId;

		[JsonProperty("players")]
		public MatchedPlayer[] Players;

		[JsonProperty("error")]
		public string Error;
	}
}
