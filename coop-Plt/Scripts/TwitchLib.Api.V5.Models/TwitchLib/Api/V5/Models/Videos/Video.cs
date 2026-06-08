using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TwitchLib.Api.V5.Models.Videos
{
	public class Video
	{
		[JsonProperty(PropertyName = "_id")]
		public string Id { get; protected set; }

		[JsonProperty(PropertyName = "animated_preview_url")]
		public string AnimatedPreviewUrl { get; protected set; }

		[JsonProperty(PropertyName = "broadcast_id")]
		public string BroadcastId { get; protected set; }

		[JsonProperty(PropertyName = "broadcast_type")]
		public string BroadcastType { get; protected set; }

		[JsonProperty(PropertyName = "channel")]
		public VideoChannel Channel { get; protected set; }

		[JsonProperty(PropertyName = "created_at")]
		public DateTime CreatedAt { get; protected set; }

		[JsonProperty(PropertyName = "description")]
		public string Description { get; protected set; }

		[JsonProperty(PropertyName = "description_html")]
		public string DescriptionHtml { get; protected set; }

		[JsonProperty(PropertyName = "fps")]
		public Dictionary<string, double> Fps { get; protected set; }

		[JsonProperty(PropertyName = "game")]
		public string Game { get; protected set; }

		[JsonProperty(PropertyName = "language")]
		public string Language { get; protected set; }

		[JsonProperty(PropertyName = "length")]
		public long Length { get; protected set; }

		[JsonProperty(PropertyName = "muted_segments")]
		public VideoMutedSegment[] MutedSegments { get; protected set; }

		[JsonProperty(PropertyName = "preview")]
		public VideoPreview Preview { get; protected set; }

		[JsonProperty(PropertyName = "published_at")]
		public DateTime PublishedAt { get; protected set; }

		[JsonProperty(PropertyName = "recorded_at")]
		public DateTime RecordedAt { get; protected set; }

		[JsonProperty(PropertyName = "resolutions")]
		public Dictionary<string, string> Resolutions { get; protected set; }

		[JsonProperty(PropertyName = "status")]
		public string Status { get; protected set; }

		[JsonProperty(PropertyName = "tag_list")]
		public string TagList { get; protected set; }

		[JsonProperty(PropertyName = "thumbnails")]
		public VideoThumbnails Thumbnails { get; protected set; }

		[JsonProperty(PropertyName = "title")]
		public string Title { get; protected set; }

		[JsonProperty(PropertyName = "url")]
		public string Url { get; protected set; }

		[JsonProperty(PropertyName = "viewable")]
		public string Viewable { get; protected set; }

		[JsonProperty(PropertyName = "viewable_at")]
		public DateTime ViewableAt { get; protected set; }

		[JsonProperty(PropertyName = "views")]
		public int Views { get; protected set; }
	}
}
