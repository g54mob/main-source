using Newtonsoft.Json;

namespace TwitchLib.Api.V5.Models.Videos
{
	public class VideoCreation
	{
		[JsonProperty(PropertyName = "upload")]
		public VideoUpload Upload { get; protected set; }

		[JsonProperty(PropertyName = "video")]
		public Video Video { get; protected set; }
	}
}
