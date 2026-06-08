using Newtonsoft.Json;

namespace TwitchLib.Api.V5.Models.Videos
{
	public class VideoThumbnails
	{
		[JsonProperty(PropertyName = "large")]
		public VideoThumbnail[] Large { get; internal set; }

		[JsonProperty(PropertyName = "medium")]
		public VideoThumbnail[] Medium { get; internal set; }

		[JsonProperty(PropertyName = "small")]
		public VideoThumbnail[] Small { get; internal set; }

		[JsonProperty(PropertyName = "template")]
		public VideoThumbnail[] Template { get; internal set; }
	}
}
