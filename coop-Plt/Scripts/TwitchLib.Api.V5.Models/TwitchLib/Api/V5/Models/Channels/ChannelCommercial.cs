using Newtonsoft.Json;

namespace TwitchLib.Api.V5.Models.Channels
{
	public class ChannelCommercial
	{
		[JsonProperty(PropertyName = "duration")]
		public int Duration { get; protected set; }

		[JsonProperty(PropertyName = "message")]
		public string Message { get; protected set; }

		[JsonProperty(PropertyName = "retryafter")]
		public int RetryAfter { get; protected set; }
	}
}
