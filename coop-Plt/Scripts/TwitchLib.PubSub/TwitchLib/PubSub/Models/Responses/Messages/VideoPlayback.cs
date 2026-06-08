using Newtonsoft.Json.Linq;
using TwitchLib.PubSub.Enums;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
	public class VideoPlayback : MessageData
	{
		public VideoPlaybackType Type { get; }

		public string ServerTime { get; }

		public int PlayDelay { get; }

		public int Viewers { get; }

		public int Length { get; }

		public VideoPlayback(string jsonStr)
		{
			JToken jToken = JObject.Parse(jsonStr);
			switch (jToken.SelectToken("type").ToString())
			{
			case "stream-up":
				Type = VideoPlaybackType.StreamUp;
				break;
			case "stream-down":
				Type = VideoPlaybackType.StreamDown;
				break;
			case "viewcount":
				Type = VideoPlaybackType.ViewCount;
				break;
			case "commercial":
				Type = VideoPlaybackType.Commercial;
				break;
			}
			ServerTime = jToken.SelectToken("server_time")?.ToString();
			switch (Type)
			{
			case VideoPlaybackType.StreamUp:
				PlayDelay = int.Parse(jToken.SelectToken("play_delay").ToString());
				break;
			case VideoPlaybackType.ViewCount:
				Viewers = int.Parse(jToken.SelectToken("viewers").ToString());
				break;
			case VideoPlaybackType.StreamDown:
				break;
			case VideoPlaybackType.Commercial:
				Length = int.Parse(jToken.SelectToken("length").ToString());
				break;
			}
		}
	}
}
