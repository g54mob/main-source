using Newtonsoft.Json;

namespace TwitchLib.Api.V5.Models.Users
{
	public class UserFollows
	{
		[JsonProperty(PropertyName = "_total")]
		public int Total { get; protected set; }

		[JsonProperty(PropertyName = "follows")]
		public UserFollow[] Follows { get; protected set; }
	}
}
