using Newtonsoft.Json;

namespace TwitchLib.Api.V5.Models.Badges
{
	public class BadgeSets
	{
		[JsonProperty(PropertyName = "subscriber")]
		public Badge Subscriber { get; protected set; }

		[JsonProperty(PropertyName = "bits")]
		public Badge Bits { get; protected set; }
	}
}
