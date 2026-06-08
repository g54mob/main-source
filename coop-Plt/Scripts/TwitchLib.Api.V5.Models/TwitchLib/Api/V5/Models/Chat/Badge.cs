using Newtonsoft.Json;

namespace TwitchLib.Api.V5.Models.Chat
{
	public class Badge
	{
		[JsonProperty(PropertyName = "alpha")]
		public string Alpha { get; protected set; }

		[JsonProperty(PropertyName = "image")]
		public string Image { get; protected set; }

		[JsonProperty(PropertyName = "svg")]
		public string SVG { get; protected set; }
	}
}
