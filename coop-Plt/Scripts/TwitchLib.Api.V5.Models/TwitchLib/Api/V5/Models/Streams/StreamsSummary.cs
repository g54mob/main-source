using Newtonsoft.Json;

namespace TwitchLib.Api.V5.Models.Streams
{
	public class StreamsSummary
	{
		[JsonProperty(PropertyName = "channels")]
		public int Channels { get; protected set; }

		[JsonProperty(PropertyName = "viewers")]
		public int Viewers { get; protected set; }
	}
}
