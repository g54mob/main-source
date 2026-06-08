using Newtonsoft.Json;

namespace TwitchLib.Api.Core.Models.Root
{
	public class RootToken
	{
		[JsonProperty(PropertyName = "authorization")]
		public RootAuthorization Auth { get; protected set; }

		[JsonProperty(PropertyName = "client_id")]
		public string ClientId { get; protected set; }

		[JsonProperty(PropertyName = "user_id")]
		public string UserId { get; protected set; }

		[JsonProperty(PropertyName = "user_name")]
		public string Username { get; protected set; }

		[JsonProperty(PropertyName = "valid")]
		public bool Valid { get; protected set; }
	}
}
