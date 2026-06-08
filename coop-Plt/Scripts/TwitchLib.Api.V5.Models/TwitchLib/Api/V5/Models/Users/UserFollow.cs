using System;
using Newtonsoft.Json;
using TwitchLib.Api.V5.Models.Channels;

namespace TwitchLib.Api.V5.Models.Users
{
	public class UserFollow
	{
		[JsonProperty(PropertyName = "created_at")]
		public DateTime CreatedAt { get; protected set; }

		[JsonProperty(PropertyName = "notifications")]
		public bool Notifications { get; protected set; }

		[JsonProperty(PropertyName = "channel")]
		public Channel Channel { get; protected set; }
	}
}
