using Newtonsoft.Json;

namespace TwitchLib.Api.V5.Models.Streams
{
	public class FeaturedStreams
	{
		[JsonProperty(PropertyName = "featured")]
		public FeaturedStream[] Featured { get; protected set; }
	}
}
