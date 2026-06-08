using Newtonsoft.Json;

namespace TwitchLib.Api.V5.Models.Users
{
	public class UserEmote
	{
		[JsonProperty(PropertyName = "code")]
		public string Code { get; protected set; }

		[JsonProperty(PropertyName = "id")]
		public int Id { get; protected set; }
	}
}
