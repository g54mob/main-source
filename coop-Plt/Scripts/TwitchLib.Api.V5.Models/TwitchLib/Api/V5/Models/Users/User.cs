using System;
using Newtonsoft.Json;
using TwitchLib.Api.Core.Interfaces;

namespace TwitchLib.Api.V5.Models.Users
{
	public class User : IUser
	{
		[JsonProperty(PropertyName = "_id")]
		public string Id { get; internal set; }

		[JsonProperty(PropertyName = "bio")]
		public string Bio { get; internal set; }

		[JsonProperty(PropertyName = "created_at")]
		public DateTime CreatedAt { get; internal set; }

		[JsonProperty(PropertyName = "display_name")]
		public string DisplayName { get; internal set; }

		[JsonProperty(PropertyName = "logo")]
		public string Logo { get; internal set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; internal set; }

		[JsonProperty(PropertyName = "type")]
		public string Type { get; internal set; }

		[JsonProperty(PropertyName = "updated_at")]
		public DateTime UpdatedAt { get; internal set; }
	}
}
