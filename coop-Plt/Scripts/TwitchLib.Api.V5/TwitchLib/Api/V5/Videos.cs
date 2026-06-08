using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using TwitchLib.Api.Core;
using TwitchLib.Api.Core.Enums;
using TwitchLib.Api.Core.Exceptions;
using TwitchLib.Api.Core.Extensions.System;
using TwitchLib.Api.Core.Interfaces;
using TwitchLib.Api.V5.Models.UploadVideo;
using TwitchLib.Api.V5.Models.Videos;

namespace TwitchLib.Api.V5
{
	public class Videos : ApiBase
	{
		private const long MAX_VIDEO_SIZE = 10737418240L;

		public Videos(IApiSettings settings, IRateLimiter rateLimiter, IHttpCallHandler http)
			: base(settings, rateLimiter, http)
		{
		}

		public Task<Video> GetVideoAsync(string videoId)
		{
			if (string.IsNullOrWhiteSpace(videoId))
			{
				throw new BadParameterException("The video id is not valid. It is not allowed to be null, empty or filled with whitespaces.");
			}
			return TwitchGetGenericAsync<Video>("/videos/" + videoId, ApiVersion.V5);
		}

		public Task<TopVideos> GetTopVideosAsync(int? limit = null, int? offset = null, string game = null, string period = null, List<string> broadcastType = null, List<string> language = null, string sort = null)
		{
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			if (limit.HasValue)
			{
				list.Add(new KeyValuePair<string, string>("limit", limit.Value.ToString()));
			}
			if (offset.HasValue)
			{
				list.Add(new KeyValuePair<string, string>("offset", offset.Value.ToString()));
			}
			if (!string.IsNullOrWhiteSpace(game))
			{
				list.Add(new KeyValuePair<string, string>("game", game));
			}
			if (!string.IsNullOrWhiteSpace(period) && (period == "week" || period == "month" || period == "all"))
			{
				list.Add(new KeyValuePair<string, string>("period", period));
			}
			if (broadcastType != null && broadcastType.Count > 0)
			{
				bool flag = false;
				foreach (string item in broadcastType)
				{
					if (item == "archive" || item == "highlight" || item == "upload")
					{
						flag = true;
						continue;
					}
					flag = false;
					break;
				}
				if (flag)
				{
					list.Add(new KeyValuePair<string, string>("broadcast_type", string.Join(",", broadcastType)));
				}
			}
			if (language != null && language.Count > 0)
			{
				list.Add(new KeyValuePair<string, string>("language", string.Join(",", language)));
			}
			if (!string.IsNullOrWhiteSpace(sort) && (sort == "views" || sort == "time"))
			{
				list.Add(new KeyValuePair<string, string>("sort", sort));
			}
			return TwitchGetGenericAsync<TopVideos>("/videos/top", ApiVersion.V5, list);
		}

		public Task<FollowedVideos> GetFollowedVideosAsync(int? limit = null, int? offset = null, List<string> broadcastType = null, List<string> language = null, string sort = null, string authToken = null)
		{
			DynamicScopeValidation(AuthScopes.User_Read, authToken);
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			if (limit.HasValue)
			{
				list.Add(new KeyValuePair<string, string>("limit", limit.Value.ToString()));
			}
			if (offset.HasValue)
			{
				list.Add(new KeyValuePair<string, string>("offset", offset.Value.ToString()));
			}
			if (broadcastType != null && broadcastType.Count > 0)
			{
				bool flag = false;
				foreach (string item in broadcastType)
				{
					if (item == "archive" || item == "highlight" || item == "upload")
					{
						flag = true;
						continue;
					}
					flag = false;
					break;
				}
				if (flag)
				{
					list.Add(new KeyValuePair<string, string>("broadcast_type", string.Join(",", broadcastType)));
				}
			}
			if (language != null && language.Count > 0)
			{
				list.Add(new KeyValuePair<string, string>("language", string.Join(",", language)));
			}
			if (!string.IsNullOrWhiteSpace(sort) && (sort == "views" || sort == "time"))
			{
				list.Add(new KeyValuePair<string, string>("sort", sort));
			}
			return TwitchGetGenericAsync<FollowedVideos>("/videos/followed", ApiVersion.V5, list, authToken);
		}

		public async Task<UploadedVideo> UploadVideoAsync(string channelId, string videoPath, string title, string description, string game, string language = "en", string tagList = "", Viewable viewable = Viewable.Public, DateTime? viewableAt = null, string accessToken = null)
		{
			DynamicScopeValidation(AuthScopes.Channel_Editor, accessToken);
			UploadVideoListing listing = await CreateVideoAsync(channelId, title, description, game, language, tagList, viewable, viewableAt);
			UploadVideoParts(videoPath, listing.Upload);
			await CompleteVideoUploadAsync(listing.Upload, accessToken);
			return listing.Video;
		}

		public Task<Video> UpdateVideoAsync(string videoId, string description = null, string game = null, string language = null, string tagList = null, string title = null, string authToken = null)
		{
			DynamicScopeValidation(AuthScopes.Channel_Editor, authToken);
			if (string.IsNullOrWhiteSpace(videoId))
			{
				throw new BadParameterException("The video id is not valid. It is not allowed to be null, empty or filled with whitespaces.");
			}
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			if (!string.IsNullOrWhiteSpace(description))
			{
				list.Add(new KeyValuePair<string, string>("description", description));
			}
			if (!string.IsNullOrWhiteSpace(game))
			{
				list.Add(new KeyValuePair<string, string>("game", game));
			}
			if (!string.IsNullOrWhiteSpace(language))
			{
				list.Add(new KeyValuePair<string, string>("language", language));
			}
			if (!string.IsNullOrWhiteSpace(tagList))
			{
				list.Add(new KeyValuePair<string, string>("tagList", tagList));
			}
			if (!string.IsNullOrWhiteSpace(title))
			{
				list.Add(new KeyValuePair<string, string>("title", title));
			}
			return TwitchPutGenericAsync<Video>("/videos/" + videoId, ApiVersion.V5, null, list, authToken);
		}

		public Task DeleteVideoAsync(string videoId, string authToken = null)
		{
			DynamicScopeValidation(AuthScopes.Channel_Editor, authToken);
			if (string.IsNullOrWhiteSpace(videoId))
			{
				throw new BadParameterException("The video id is not valid. It is not allowed to be null, empty or filled with whitespaces.");
			}
			return TwitchDeleteAsync("/videos/" + videoId, ApiVersion.V5, null, authToken);
		}

		private Task<UploadVideoListing> CreateVideoAsync(string channelId, string title, string description = null, string game = null, string language = "en", string tagList = "", Viewable viewable = Viewable.Public, DateTime? viewableAt = null, string accessToken = null)
		{
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("channel_id", channelId),
				new KeyValuePair<string, string>("title", title)
			};
			if (!string.IsNullOrWhiteSpace(description))
			{
				list.Add(new KeyValuePair<string, string>("description", description));
			}
			if (game != null)
			{
				list.Add(new KeyValuePair<string, string>("game", game));
			}
			if (language != null)
			{
				list.Add(new KeyValuePair<string, string>("language", language));
			}
			if (tagList != null)
			{
				list.Add(new KeyValuePair<string, string>("tag_list", tagList));
			}
			list.Add((viewable == Viewable.Public) ? new KeyValuePair<string, string>("viewable", "public") : new KeyValuePair<string, string>("viewable", "private"));
			if (viewableAt.HasValue)
			{
				list.Add(new KeyValuePair<string, string>("viewable_at", viewableAt.Value.ToRfc3339String()));
			}
			return TwitchPostGenericAsync<UploadVideoListing>("/videos", ApiVersion.V5, null, list, accessToken);
		}

		private void UploadVideoParts(string videoPath, Upload upload)
		{
			if (!File.Exists(videoPath))
			{
				throw new BadParameterException("The provided path for a video upload does not appear to be value: " + videoPath);
			}
			FileInfo fileInfo = new FileInfo(videoPath);
			if (fileInfo.Length >= 10737418240L)
			{
				throw new BadParameterException($"The provided file was too large (larger than 10gb). File size: {fileInfo.Length}");
			}
			long length = fileInfo.Length;
			if (length > 25165824)
			{
				using (FileStream fileStream = new FileStream(videoPath, FileMode.Open, FileAccess.Read, FileShare.Read))
				{
					long num = length % 25165824;
					long num2 = (length - num) / 25165824 + 1;
					for (int i = 1; i <= num2; i++)
					{
						byte[] array;
						if (i == num2)
						{
							array = new byte[num];
							fileStream.Read(array, 0, (int)num);
						}
						else
						{
							array = new byte[25165824];
							fileStream.Read(array, 0, 25165824);
						}
						PutBytes($"{upload.Url}?part={i}&upload_token={upload.Token}", array);
						Thread.Sleep(1000);
					}
					return;
				}
			}
			byte[] payload = File.ReadAllBytes(videoPath);
			PutBytes(upload.Url + "?part=1&upload_token=" + upload.Token, payload);
		}

		private Task CompleteVideoUploadAsync(Upload upload, string accessToken)
		{
			return TwitchPostAsync(null, ApiVersion.V5, null, null, accessToken, null, upload.Url + "/complete?upload_token=" + upload.Token);
		}
	}
}
