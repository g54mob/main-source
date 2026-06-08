using Newtonsoft.Json;

namespace TwitchLib.Api.V5.Models.Videos
{
	public class VideoThumbnail
	{
		[JsonProperty(PropertyName = "type")]
		public string Type { get; protected set; }

		[JsonProperty(PropertyName = "url")]
		public string Url { get; protected set; }
	}
}
