using Newtonsoft.Json;

namespace TwitchLib.Api.V5.Models.Videos
{
	public class VideoChannel
	{
		[JsonProperty(PropertyName = "_id")]
		public string Id { get; protected set; }

		[JsonProperty(PropertyName = "display_name")]
		public string DisplayName { get; protected set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; protected set; }
	}
}
