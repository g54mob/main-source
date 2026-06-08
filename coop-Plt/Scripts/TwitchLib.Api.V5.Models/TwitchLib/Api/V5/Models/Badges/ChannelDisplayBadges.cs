using Newtonsoft.Json;

namespace TwitchLib.Api.V5.Models.Badges
{
	public class ChannelDisplayBadges
	{
		[JsonProperty(PropertyName = "badge_sets")]
		public BadgeSets Sets { get; protected set; }
	}
}
