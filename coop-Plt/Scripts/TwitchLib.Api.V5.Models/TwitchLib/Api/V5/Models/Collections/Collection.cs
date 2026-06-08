using Newtonsoft.Json;

namespace TwitchLib.Api.V5.Models.Collections
{
	public class Collection
	{
		[JsonProperty(PropertyName = "_id")]
		public string Id { get; protected set; }

		[JsonProperty(PropertyName = "items")]
		public CollectionItem[] Items { get; protected set; }
	}
}
