using System;
using Newtonsoft.Json;

namespace TwitchLib.Api.Core.Models.Root
{
	public class RootAuthorization
	{
		[JsonProperty(PropertyName = "created_at")]
		public DateTime CreatedAt { get; protected set; }

		[JsonProperty(PropertyName = "scopes")]
		public string[] Scopes { get; protected set; }

		[JsonProperty(PropertyName = "updated_at")]
		public DateTime UpdatedAt { get; protected set; }
	}
}
