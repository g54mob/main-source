using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TwitchLib.Api.V5.Models.Users;

namespace TwitchLib.Api.V5.Models.Collections
{
	public class CollectionItem
	{
		[JsonProperty(PropertyName = "_id")]
		public string Id { get; protected set; }

		[JsonProperty(PropertyName = "description_html")]
		public string DescriptionHtml { get; protected set; }

		[JsonProperty(PropertyName = "duration")]
		public int Duration { get; protected set; }

		[JsonProperty(PropertyName = "game")]
		public string Game { get; protected set; }

		[JsonProperty(PropertyName = "item_id")]
		public string ItemId { get; protected set; }

		[JsonProperty(PropertyName = "item_type")]
		public string ItemType { get; protected set; }

		[JsonProperty(PropertyName = "owner")]
		public User Owner { get; protected set; }

		[JsonProperty(PropertyName = "published_at")]
		public DateTime PublishedAt { get; protected set; }

		[JsonProperty(PropertyName = "thumbnails")]
		public Dictionary<string, string> Thumbnails { get; protected set; }

		[JsonProperty(PropertyName = "title")]
		public string Title { get; protected set; }

		[JsonProperty(PropertyName = "views")]
		public int Views { get; protected set; }
	}
}
