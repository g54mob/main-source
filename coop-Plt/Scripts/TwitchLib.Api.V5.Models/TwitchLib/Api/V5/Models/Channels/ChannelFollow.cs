using System;
using Newtonsoft.Json;
using TwitchLib.Api.Core.Interfaces;
using TwitchLib.Api.V5.Models.Users;

namespace TwitchLib.Api.V5.Models.Channels
{
	public class ChannelFollow : IFollow
	{
		[JsonProperty(PropertyName = "created_at")]
		public DateTime CreatedAt { get; protected set; }

		[JsonProperty(PropertyName = "notifications")]
		public bool Notifications { get; protected set; }

		[JsonProperty(PropertyName = "user")]
		public IUser User { get; protected set; }

		public ChannelFollow(User user)
		{
			User = user;
		}
	}
}
