using System;
using Newtonsoft.Json;
using TwitchLib.Api.V5.Models.Channels;

namespace TwitchLib.Api.V5.Models.Teams
{
	public class Team
	{
		[JsonProperty(PropertyName = "_id")]
		public long Id { get; protected set; }

		[JsonProperty(PropertyName = "background")]
		public string Background { get; protected set; }

		[JsonProperty(PropertyName = "banner")]
		public string Banner { get; protected set; }

		[JsonProperty(PropertyName = "created_at")]
		public DateTime CreatedAt { get; protected set; }

		[JsonProperty(PropertyName = "display_name")]
		public string DisplayName { get; protected set; }

		[JsonProperty(PropertyName = "info")]
		public string Info { get; protected set; }

		[JsonProperty(PropertyName = "logo")]
		public string Logo { get; protected set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; protected set; }

		[JsonProperty(PropertyName = "updated_at")]
		public DateTime UpdatedAt { get; protected set; }

		[JsonProperty(PropertyName = "users")]
		public Channel[] Users { get; protected set; }
	}
}
