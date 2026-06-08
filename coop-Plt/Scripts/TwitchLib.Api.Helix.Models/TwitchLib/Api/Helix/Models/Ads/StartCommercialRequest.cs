using Newtonsoft.Json;

namespace TwitchLib.Api.Helix.Models.Ads
{
	public class StartCommercialRequest
	{
		[JsonProperty(PropertyName = "broadcaster_id")]
		public string BroadcasterId { get; protected set; }

		[JsonProperty(PropertyName = "length")]
		public int Length { get; protected set; }
	}
}
