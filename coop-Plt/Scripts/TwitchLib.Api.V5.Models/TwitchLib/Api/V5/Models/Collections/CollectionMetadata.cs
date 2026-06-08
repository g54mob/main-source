using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TwitchLib.Api.V5.Models.Users;

namespace TwitchLib.Api.V5.Models.Collections
{
	public class CollectionMetadata
	{
		[JsonProperty(PropertyName = "_id")]
		public string Id { get; protected set; }

		[JsonProperty(PropertyName = "created_at")]
		public DateTime CreatedAt { get; protected set; }

		[JsonProperty(PropertyName = "items_count")]
		public int ItemsCount { get; protected set; }

		[JsonProperty(PropertyName = "owner")]
		public User Owner { get; protected set; }

		[JsonProperty(PropertyName = "thumbnails")]
		public Dictionary<string, string> Thumbnails { get; protected set; }

		[JsonProperty(PropertyName = "title")]
		public string Title { get; protected set; }

		[JsonProperty(PropertyName = "total_duration")]
		public int TotalDuration { get; protected set; }

		[JsonProperty(PropertyName = "updated_at")]
		public DateTime UpdatedAt { get; protected set; }

		[JsonProperty(PropertyName = "views")]
		public int Views { get; protected set; }
	}
}
