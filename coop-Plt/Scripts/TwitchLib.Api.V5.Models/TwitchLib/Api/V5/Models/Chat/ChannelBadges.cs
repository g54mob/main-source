using Newtonsoft.Json;

namespace TwitchLib.Api.V5.Models.Chat
{
	public class ChannelBadges
	{
		[JsonProperty(PropertyName = "admin")]
		public Badge Admin { get; protected set; }

		[JsonProperty(PropertyName = "broadcaster")]
		public Badge Broadcaster { get; protected set; }

		[JsonProperty(PropertyName = "global_mod")]
		public Badge GlobalMod { get; protected set; }

		[JsonProperty(PropertyName = "mod")]
		public Badge Mod { get; protected set; }

		[JsonProperty(PropertyName = "staff")]
		public Badge Staff { get; protected set; }

		[JsonProperty(PropertyName = "subscriber")]
		public Badge Subscriber { get; protected set; }

		[JsonProperty(PropertyName = "turbo")]
		public Badge Turbo { get; protected set; }
	}
}
