using Newtonsoft.Json;

namespace TwitchLib.Api.V5.Models.Chat
{
	public class EmoticonImage
	{
		[JsonProperty(PropertyName = "width")]
		public int Width { get; protected set; }

		[JsonProperty(PropertyName = "height")]
		public int Height { get; protected set; }

		[JsonProperty(PropertyName = "url")]
		public string Url { get; protected set; }

		[JsonProperty(PropertyName = "emoticon_set")]
		public int EmoticonSet { get; protected set; }
	}
}
