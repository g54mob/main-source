using System;
using Newtonsoft.Json;

namespace TwitchLib.Api.V5.Models.Users
{
	public class UserBlock
	{
		[JsonProperty(PropertyName = "_id")]
		public long Id { get; protected set; }

		[JsonProperty(PropertyName = "updated_at")]
		public DateTime UpdatedAt { get; protected set; }

		[JsonProperty(PropertyName = "user")]
		public User User { get; protected set; }
	}
}
