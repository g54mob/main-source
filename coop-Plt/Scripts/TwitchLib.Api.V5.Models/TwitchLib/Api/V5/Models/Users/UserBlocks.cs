using Newtonsoft.Json;

namespace TwitchLib.Api.V5.Models.Users
{
	public class UserBlocks
	{
		[JsonProperty(PropertyName = "_total")]
		public int Total { get; protected set; }

		[JsonProperty(PropertyName = "blocks")]
		public UserBlock[] Blocks { get; protected set; }
	}
}
