using Newtonsoft.Json;

namespace TwitchLib.Api.V5.Models.Users
{
	public class Users
	{
		[JsonProperty(PropertyName = "_total")]
		public int Total { get; protected set; }

		[JsonProperty(PropertyName = "users")]
		public User[] Matches { get; protected set; }
	}
}
