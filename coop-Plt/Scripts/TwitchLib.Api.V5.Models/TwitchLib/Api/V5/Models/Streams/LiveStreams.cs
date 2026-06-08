using Newtonsoft.Json;

namespace TwitchLib.Api.V5.Models.Streams
{
	public class LiveStreams
	{
		[JsonProperty(PropertyName = "_total")]
		public int Total { get; protected set; }

		[JsonProperty(PropertyName = "streams")]
		public Stream[] Streams { get; protected set; }
	}
}
