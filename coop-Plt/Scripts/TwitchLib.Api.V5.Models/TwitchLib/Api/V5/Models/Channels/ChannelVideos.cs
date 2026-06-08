using Newtonsoft.Json;
using TwitchLib.Api.V5.Models.Videos;

namespace TwitchLib.Api.V5.Models.Channels
{
	public class ChannelVideos
	{
		[JsonProperty(PropertyName = "_total")]
		public int Total { get; protected set; }

		[JsonProperty(PropertyName = "videos")]
		public Video[] Videos { get; protected set; }
	}
}
