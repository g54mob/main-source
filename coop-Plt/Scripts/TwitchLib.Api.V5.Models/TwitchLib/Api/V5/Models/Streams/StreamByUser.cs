using Newtonsoft.Json;

namespace TwitchLib.Api.V5.Models.Streams
{
	public class StreamByUser
	{
		[JsonProperty(PropertyName = "stream")]
		public Stream Stream { get; protected set; }
	}
}
