using Newtonsoft.Json;

namespace TwitchLib.Api.V5.Models.Videos
{
	public class VideoMutedSegment
	{
		[JsonProperty(PropertyName = "duration")]
		public long Duration { get; internal set; }

		[JsonProperty(PropertyName = "offset")]
		public long Offset { get; internal set; }
	}
}
