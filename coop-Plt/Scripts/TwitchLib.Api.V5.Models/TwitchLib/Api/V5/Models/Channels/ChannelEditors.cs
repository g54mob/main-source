using Newtonsoft.Json;
using TwitchLib.Api.V5.Models.Users;

namespace TwitchLib.Api.V5.Models.Channels
{
	public class ChannelEditors
	{
		[JsonProperty(PropertyName = "users")]
		public User[] Editors { get; protected set; }
	}
}
