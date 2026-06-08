using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitchLib.Api.Core;
using TwitchLib.Api.Core.Enums;
using TwitchLib.Api.Core.Exceptions;
using TwitchLib.Api.Core.Interfaces;
using TwitchLib.Api.Helix.Models.Videos.DeleteVideos;
using TwitchLib.Api.Helix.Models.Videos.GetVideos;

namespace TwitchLib.Api.Helix
{
	public class Videos : ApiBase
	{
		public Videos(IApiSettings settings, IRateLimiter rateLimiter, IHttpCallHandler http)
			: base(settings, rateLimiter, http)
		{
		}

		public Task<DeleteVideosResponse> DeleteVideosAsync(List<string> videoIds, string accessToken = null)
		{
			DynamicScopeValidation(AuthScopes.Helix_Channel_Manage_Videos, accessToken);
			if (videoIds.Count > 5)
			{
				throw new BadParameterException($"Maximum of 5 video ids allowed per request (you passed {videoIds.Count})");
			}
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			foreach (string videoId in videoIds)
			{
				list.Add(new KeyValuePair<string, string>("id", videoId));
			}
			return TwitchDeleteGenericAsync<DeleteVideosResponse>("/videos", ApiVersion.Helix, list, accessToken);
		}

		public Task<GetVideosResponse> GetVideoAsync(List<string> videoIds = null, string userId = null, string gameId = null, string after = null, string before = null, int first = 20, string language = null, Period period = Period.All, VideoSort sort = VideoSort.Time, VideoType type = VideoType.All)
		{
			if ((videoIds == null || videoIds.Count == 0) && userId == null && gameId == null)
			{
				throw new BadParameterException("VideoIds, userId, and gameId cannot all be null/empty.");
			}
			if ((videoIds != null && videoIds.Count > 0 && userId != null) || (videoIds != null && videoIds.Count > 0 && gameId != null) || (userId != null && gameId != null))
			{
				throw new BadParameterException("If videoIds are present, you may not use userid or gameid. If gameid is present, you may not use videoIds or userid. If userid is present, you may not use videoids or gameids.");
			}
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			if (videoIds != null && videoIds.Count > 0)
			{
				foreach (string videoId in videoIds)
				{
					list.Add(new KeyValuePair<string, string>("id", videoId));
				}
			}
			if (userId != null)
			{
				list.Add(new KeyValuePair<string, string>("user_id", userId));
			}
			if (gameId != null)
			{
				list.Add(new KeyValuePair<string, string>("game_id", gameId));
			}
			if (userId != null || gameId != null)
			{
				if (after != null)
				{
					list.Add(new KeyValuePair<string, string>("after", after));
				}
				if (before != null)
				{
					list.Add(new KeyValuePair<string, string>("before", before));
				}
				list.Add(new KeyValuePair<string, string>("first", first.ToString()));
				if (language != null)
				{
					list.Add(new KeyValuePair<string, string>("language", language));
				}
				switch (period)
				{
				case Period.All:
					list.Add(new KeyValuePair<string, string>("period", "all"));
					break;
				case Period.Day:
					list.Add(new KeyValuePair<string, string>("period", "day"));
					break;
				case Period.Month:
					list.Add(new KeyValuePair<string, string>("period", "month"));
					break;
				case Period.Week:
					list.Add(new KeyValuePair<string, string>("period", "week"));
					break;
				default:
					throw new ArgumentOutOfRangeException("period", period, null);
				}
				switch (sort)
				{
				case VideoSort.Time:
					list.Add(new KeyValuePair<string, string>("sort", "time"));
					break;
				case VideoSort.Trending:
					list.Add(new KeyValuePair<string, string>("sort", "trending"));
					break;
				case VideoSort.Views:
					list.Add(new KeyValuePair<string, string>("sort", "views"));
					break;
				default:
					throw new ArgumentOutOfRangeException("sort", sort, null);
				}
				switch (type)
				{
				case VideoType.All:
					list.Add(new KeyValuePair<string, string>("type", "all"));
					break;
				case VideoType.Highlight:
					list.Add(new KeyValuePair<string, string>("type", "highlight"));
					break;
				case VideoType.Archive:
					list.Add(new KeyValuePair<string, string>("type", "archive"));
					break;
				case VideoType.Upload:
					list.Add(new KeyValuePair<string, string>("type", "upload"));
					break;
				default:
					throw new ArgumentOutOfRangeException("type", type, null);
				}
			}
			return TwitchGetGenericAsync<GetVideosResponse>("/videos", ApiVersion.Helix, list);
		}
	}
}
