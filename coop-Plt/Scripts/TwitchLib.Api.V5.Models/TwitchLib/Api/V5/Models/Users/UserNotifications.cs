using Newtonsoft.Json;

namespace TwitchLib.Api.V5.Models.Users
{
	public class UserNotifications
	{
		[JsonProperty(PropertyName = "email")]
		public bool Email { get; protected set; }

		[JsonProperty(PropertyName = "push")]
		public bool Push { get; protected set; }
	}
}
