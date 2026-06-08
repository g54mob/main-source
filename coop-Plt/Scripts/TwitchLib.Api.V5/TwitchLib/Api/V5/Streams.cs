using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitchLib.Api.Core;
using TwitchLib.Api.Core.Enums;
using TwitchLib.Api.Core.Exceptions;
using TwitchLib.Api.Core.Interfaces;
using TwitchLib.Api.V5.Models.Streams;

namespace TwitchLib.Api.V5
{
	public class Streams : ApiBase
	{
		public Streams(IApiSettings settings, IRateLimiter rateLimiter, IHttpCallHandler http)
			: base(settings, rateLimiter, http)
		{
		}

		public Task<StreamByUser> GetStreamByUserAsync(string channelId, string streamType = null)
		{
			if (string.IsNullOrWhiteSpace(channelId))
			{
				throw new BadParameterException("The channel id is not valid for fetching streams. It is not allowed to be null, empty or filled with whitespaces.");
			}
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			if (!string.IsNullOrWhiteSpace(streamType))
			{
				switch (streamType)
				{
				default:
					if (!(streamType == "watch_party"))
					{
						break;
					}
					goto case "live";
				case "live":
				case "playlist":
				case "all":
					list.Add(new KeyValuePair<string, string>("stream_type", streamType));
					break;
				}
			}
			return TwitchGetGenericAsync<StreamByUser>("/streams/" + channelId, ApiVersion.V5, list);
		}

		public Task<LiveStreams> GetLiveStreamsAsync(List<string> channelList = null, string game = null, string language = null, string streamType = null, int? limit = null, int? offset = null)
		{
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			if (channelList != null && channelList.Count > 0)
			{
				list.Add(new KeyValuePair<string, string>("channel", string.Join(",", channelList)));
			}
			if (!string.IsNullOrWhiteSpace(game))
			{
				list.Add(new KeyValuePair<string, string>("game", game));
			}
			if (!string.IsNullOrWhiteSpace(language))
			{
				list.Add(new KeyValuePair<string, string>("language", language));
			}
			if (!string.IsNullOrWhiteSpace(streamType))
			{
				switch (streamType)
				{
				default:
					if (!(streamType == "watch_party"))
					{
						break;
					}
					goto case "live";
				case "live":
				case "playlist":
				case "all":
					list.Add(new KeyValuePair<string, string>("stream_type", streamType));
					break;
				}
			}
			if (limit.HasValue)
			{
				list.Add(new KeyValuePair<string, string>("limit", limit.Value.ToString()));
			}
			if (offset.HasValue)
			{
				list.Add(new KeyValuePair<string, string>("offset", offset.Value.ToString()));
			}
			return TwitchGetGenericAsync<LiveStreams>("/streams", ApiVersion.V5, list);
		}

		public Task<StreamsSummary> GetStreamsSummaryAsync(string game = null)
		{
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			if (game != null)
			{
				list.Add(new KeyValuePair<string, string>("game", game));
			}
			return TwitchGetGenericAsync<StreamsSummary>("/streams/summary", ApiVersion.V5, list);
		}

		public Task<FeaturedStreams> GetFeaturedStreamAsync(int? limit = null, int? offset = null)
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
			return TwitchGetGenericAsync<FeaturedStreams>("/streams/featured", ApiVersion.V5, list);
		}

		public Task<FollowedStreams> GetFollowedStreamsAsync(string streamType = null, int? limit = null, int? offset = null, string authToken = null)
		{
			DynamicScopeValidation(AuthScopes.User_Read, authToken);
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			if (!string.IsNullOrWhiteSpace(streamType))
			{
				switch (streamType)
				{
				default:
					if (!(streamType == "watch_party"))
					{
						break;
					}
					goto case "live";
				case "live":
				case "playlist":
				case "all":
					list.Add(new KeyValuePair<string, string>("stream_type", streamType));
					break;
				}
			}
			if (limit.HasValue)
			{
				list.Add(new KeyValuePair<string, string>("limit", limit.ToString()));
			}
			if (offset.HasValue)
			{
				list.Add(new KeyValuePair<string, string>("offset", offset.ToString()));
			}
			return TwitchGetGenericAsync<FollowedStreams>("/streams/followed", ApiVersion.V5, list, authToken);
		}

		public async Task<TimeSpan?> GetUptimeAsync(string channelId)
		{
			try
			{
				StreamByUser stream = await GetStreamByUserAsync(channelId).ConfigureAwait(continueOnCapturedContext: false);
				return DateTime.UtcNow - stream.Stream.CreatedAt;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public async Task<bool> BroadcasterOnlineAsync(string channelId)
		{
			return (await GetStreamByUserAsync(channelId).ConfigureAwait(continueOnCapturedContext: false)).Stream != null;
		}
	}
}
