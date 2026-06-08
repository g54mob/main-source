using System;
using Newtonsoft.Json;

namespace TwitchLib.Api.V5.Models.Streams
{
	public class Stream
	{
		[JsonProperty(PropertyName = "_id")]
		public long Id { get; protected set; }

		[JsonProperty(PropertyName = "average_fps")]
		public double AverageFps { get; protected set; }

		[JsonProperty(PropertyName = "channel")]
		public StreamChannel Channel { get; protected set; }

		[JsonProperty(PropertyName = "created_at")]
		public DateTime CreatedAt { get; protected set; }

		[JsonProperty(PropertyName = "delay")]
		public int Delay { get; protected set; }

		[JsonProperty(PropertyName = "game")]
		public string Game { get; protected set; }

		[JsonProperty(PropertyName = "is_playlist")]
		public bool IsPlaylist { get; protected set; }

		[JsonProperty(PropertyName = "stream_type")]
		public string StreamType { get; protected set; }

		[JsonProperty(PropertyName = "preview")]
		public StreamPreview Preview { get; protected set; }

		[JsonProperty(PropertyName = "video_height")]
		public int VideoHeight { get; protected set; }

		[JsonProperty(PropertyName = "viewers")]
		public int Viewers { get; protected set; }
	}
}
