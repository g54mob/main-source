using System;
using Newtonsoft.Json;
using TwitchLib.Api.Core.Interfaces;

namespace TwitchLib.Api.V5.Models.Users
{
	public class UserAuthed : IUser
	{
		[JsonProperty(PropertyName = "_id")]
		public string Id { get; protected set; }

		[JsonProperty(PropertyName = "bio")]
		public string Bio { get; protected set; }

		[JsonProperty(PropertyName = "created_at")]
		public DateTime CreatedAt { get; protected set; }

		[JsonProperty(PropertyName = "display_name")]
		public string DisplayName { get; protected set; }

		[JsonProperty(PropertyName = "email")]
		public string Email { get; protected set; }

		[JsonProperty(PropertyName = "email_verified")]
		public bool EmailVerified { get; protected set; }

		[JsonProperty(PropertyName = "logo")]
		public string Logo { get; protected set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; protected set; }

		[JsonProperty(PropertyName = "notifications")]
		public UserNotifications Notifications { get; protected set; }

		[JsonProperty(PropertyName = "partnered")]
		public bool Partnered { get; protected set; }

		[JsonProperty(PropertyName = "twitter_connected")]
		public bool TwitterConnected { get; protected set; }

		[JsonProperty(PropertyName = "type")]
		public string Type { get; protected set; }

		[JsonProperty(PropertyName = "updated_at")]
		public DateTime UpdatedAt { get; protected set; }
	}
}
