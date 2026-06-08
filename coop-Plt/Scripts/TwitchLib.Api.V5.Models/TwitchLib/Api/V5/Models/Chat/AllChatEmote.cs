using Newtonsoft.Json;

namespace TwitchLib.Api.V5.Models.Chat
{
	public class AllChatEmote
	{
		[JsonProperty(PropertyName = "regex")]
		public string Regex { get; protected set; }

		[JsonProperty(PropertyName = "images")]
		public EmoticonImage[] Images { get; protected set; }
	}
}
