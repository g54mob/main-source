using Newtonsoft.Json;

namespace TwitchLib.Api.Core.Models.Undocumented.ChatUser
{
	public class ChatUser
	{
		[JsonProperty(PropertyName = "id")]
		public string Id { get; protected set; }

		[JsonProperty(PropertyName = "version")]
		public string Version { get; protected set; }
	}
}
