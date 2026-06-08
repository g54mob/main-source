using Newtonsoft.Json;

namespace TwitchLib.Api.V5.Models.Chat
{
	public class AllChatEmotes
	{
		[JsonProperty(PropertyName = "emoticons")]
		public AllChatEmote[] Emoticons { get; protected set; }
	}
}
