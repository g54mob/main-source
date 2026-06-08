using Newtonsoft.Json;

namespace TwitchLib.Api.Helix.Models.Streams.GetStreams
{
	public class LiveStreams
	{
		[JsonProperty(PropertyName = "_total")]
		public int Total { get; protected set; }

		[JsonProperty(PropertyName = "streams")]
		public Stream[] Streams { get; protected set; }
	}
}
