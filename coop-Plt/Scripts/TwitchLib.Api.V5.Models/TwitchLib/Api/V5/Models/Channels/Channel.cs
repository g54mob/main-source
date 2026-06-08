using System;
using Newtonsoft.Json;

namespace TwitchLib.Api.V5.Models.Channels
{
	public class Channel
	{
		[JsonProperty(PropertyName = "_id")]
		public string Id { get; internal set; }

		[JsonProperty(PropertyName = "broadcaster_language")]
		public string BroadcasterLanguage { get; internal set; }

		[JsonProperty(PropertyName = "created_at")]
		public DateTime CreatedAt { get; internal set; }

		[JsonProperty(PropertyName = "display_name")]
		public string DisplayName { get; internal set; }

		[JsonProperty(PropertyName = "followers")]
		public int Followers { get; internal set; }

		[JsonProperty(PropertyName = "broadcaster_type")]
		public string BroadcasterType { get; internal set; }

		[JsonProperty(PropertyName = "game")]
		public string Game { get; internal set; }

		[JsonProperty(PropertyName = "language")]
		public string Language { get; internal set; }

		[JsonProperty(PropertyName = "logo")]
		public string Logo { get; internal set; }

		[JsonProperty(PropertyName = "mature")]
		public bool Mature { get; internal set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; internal set; }

		[JsonProperty(PropertyName = "partner")]
		public bool Partner { get; internal set; }

		[JsonProperty(PropertyName = "profile_banner")]
		public string ProfileBanner { get; internal set; }

		[JsonProperty(PropertyName = "profile_banner_background_color")]
		public string ProfileBannerBackgroundColor { get; internal set; }

		[JsonProperty(PropertyName = "status")]
		public string Status { get; internal set; }

		[JsonProperty(PropertyName = "updated_at")]
		public DateTime UpdatedAt { get; internal set; }

		[JsonProperty(PropertyName = "url")]
		public string Url { get; internal set; }

		[JsonProperty(PropertyName = "video_banner")]
		public string VideoBanner { get; internal set; }

		[JsonProperty(PropertyName = "views")]
		public int Views { get; internal set; }
	}
}
