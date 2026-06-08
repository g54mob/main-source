using Newtonsoft.Json;

namespace TwitchLib.Api.V5.Models.Streams
{
	public class FeaturedStream
	{
		[JsonProperty(PropertyName = "image")]
		public string Image { get; protected set; }

		[JsonProperty(PropertyName = "priority")]
		public int Priority { get; protected set; }

		[JsonProperty(PropertyName = "scheduled")]
		public bool Scheduled { get; protected set; }

		[JsonProperty(PropertyName = "sponsored")]
		public bool Sponsored { get; protected set; }

		[JsonProperty(PropertyName = "stream")]
		public Stream Stream { get; protected set; }

		[JsonProperty(PropertyName = "text")]
		public string Text { get; protected set; }

		[JsonProperty(PropertyName = "title")]
		public string Title { get; protected set; }
	}
}
