using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitchLib.Api.Core;
using TwitchLib.Api.Core.Enums;
using TwitchLib.Api.Core.Exceptions;
using TwitchLib.Api.Core.Interfaces;
using TwitchLib.Api.V5.Models.Channels;
using TwitchLib.Api.V5.Models.Subscriptions;

namespace TwitchLib.Api.V5
{
	public class Channels : ApiBase
	{
		public Channels(IApiSettings settings, IRateLimiter rateLimiter, IHttpCallHandler http)
			: base(settings, rateLimiter, http)
		{
		}

		public Task<ChannelAuthed> GetChannelAsync(string authToken = null)
		{
			return TwitchGetGenericAsync<ChannelAuthed>("/channel", ApiVersion.V5, null, authToken);
		}

		public Task<Channel> GetChannelByIDAsync(string channelId)
		{
			if (string.IsNullOrWhiteSpace(channelId))
			{
				throw new BadParameterException("The channel id is not valid. It is not allowed to be null, empty or filled with whitespaces.");
			}
			return TwitchGetGenericAsync<Channel>("/channels/" + channelId, ApiVersion.V5);
		}

		public Task<Channel> UpdateChannelAsync(string channelId, string status = null, string game = null, string delay = null, bool? channelFeedEnabled = null, string authToken = null)
		{
			DynamicScopeValidation(AuthScopes.Helix_User_Edit_Broadcast, authToken);
			if (string.IsNullOrWhiteSpace(channelId))
			{
				throw new BadParameterException("The channel id is not valid. It is not allowed to be null, empty or filled with whitespaces.");
			}
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			if (!string.IsNullOrEmpty(status))
			{
				list.Add(new KeyValuePair<string, string>("status", "\"" + status + "\""));
			}
			if (!string.IsNullOrEmpty(game))
			{
				list.Add(new KeyValuePair<string, string>("game", "\"" + game + "\""));
			}
			if (!string.IsNullOrEmpty(delay))
			{
				list.Add(new KeyValuePair<string, string>("delay", "\"" + delay + "\""));
			}
			if (channelFeedEnabled.HasValue)
			{
				list.Add(new KeyValuePair<string, string>("channel_feed_enabled", (channelFeedEnabled == true) ? "true" : "false"));
			}
			string text = "";
			switch (list.Count)
			{
			case 0:
				throw new BadParameterException("At least one parameter must be specified: status, game, delay, channel_feed_enabled.");
			case 1:
				text = "\"" + list[0].Key + "\": " + list[0].Value;
				break;
			default:
			{
				for (int i = 0; i < list.Count; i++)
				{
					text = ((list.Count - i > 1) ? (text + "\"" + list[i].Key + "\": " + list[i].Value + ",") : (text + "\"" + list[i].Key + "\": " + list[i].Value));
				}
				break;
			}
			}
			text = "{ \"channel\": {" + text + "} }";
			return TwitchPutGenericAsync<Channel>("/channels/" + channelId, ApiVersion.V5, text, null, authToken);
		}

		public Task<ChannelEditors> GetChannelEditorsAsync(string channelId, string authToken = null)
		{
			DynamicScopeValidation(AuthScopes.Channel_Read, authToken);
			if (string.IsNullOrWhiteSpace(channelId))
			{
				throw new BadParameterException("The channel id is not valid. It is not allowed to be null, empty or filled with whitespaces.");
			}
			return TwitchGetGenericAsync<ChannelEditors>("/channels/" + channelId + "/editors", ApiVersion.V5, null, authToken);
		}

		public Task<ChannelFollowers> GetChannelFollowersAsync(string channelId, int? limit = null, int? offset = null, string cursor = null, string direction = null)
		{
			if (string.IsNullOrWhiteSpace(channelId))
			{
				throw new BadParameterException("The channel id is not valid. It is not allowed to be null, empty or filled with whitespaces.");
			}
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			if (limit.HasValue)
			{
				list.Add(new KeyValuePair<string, string>("limit", limit.ToString()));
			}
			if (offset.HasValue)
			{
				list.Add(new KeyValuePair<string, string>("offset", offset.ToString()));
			}
			if (!string.IsNullOrEmpty(cursor))
			{
				list.Add(new KeyValuePair<string, string>("cursor", cursor));
			}
			if (!string.IsNullOrEmpty(direction) && (direction == "asc" || direction == "desc"))
			{
				list.Add(new KeyValuePair<string, string>("direction", direction));
			}
			return TwitchGetGenericAsync<ChannelFollowers>("/channels/" + channelId + "/follows", ApiVersion.V5, list);
		}

		public async Task<List<ChannelFollow>> GetAllFollowersAsync(string channelId)
		{
			List<ChannelFollow> followers = new List<ChannelFollow>();
			ChannelFollowers firstBatch = await GetChannelFollowersAsync(channelId, 100).ConfigureAwait(continueOnCapturedContext: false);
			int totalFollowers = firstBatch.Total;
			string cursor = firstBatch.Cursor;
			followers.AddRange(firstBatch.Follows.OfType<ChannelFollow>().ToList());
			int amount = firstBatch.Follows.Length;
			int leftOverFollowers = (totalFollowers - amount) % 100;
			int requiredRequests = (totalFollowers - amount - leftOverFollowers) / 100;
			await Task.Delay(1000);
			for (int i = 0; i < requiredRequests; i++)
			{
				ChannelFollowers requestedFollowers = await GetChannelFollowersAsync(channelId, 100, null, cursor).ConfigureAwait(continueOnCapturedContext: false);
				cursor = requestedFollowers.Cursor;
				followers.AddRange(requestedFollowers.Follows.OfType<ChannelFollow>().ToList());
				await Task.Delay(1000);
			}
			if (leftOverFollowers > 0)
			{
				followers.AddRange((await GetChannelFollowersAsync(channelId, leftOverFollowers, null, cursor).ConfigureAwait(continueOnCapturedContext: false)).Follows.OfType<ChannelFollow>().ToList());
			}
			return followers;
		}

		public Task<ChannelTeams> GetChannelTeamsAsync(string channelId)
		{
			if (string.IsNullOrWhiteSpace(channelId))
			{
				throw new BadParameterException("The channel id is not valid. It is not allowed to be null, empty or filled with whitespaces.");
			}
			return TwitchGetGenericAsync<ChannelTeams>("/channels/" + channelId + "/teams", ApiVersion.V5);
		}

		public Task<ChannelSubscribers> GetChannelSubscribersAsync(string channelId, int? limit = null, int? offset = null, string direction = null, string authToken = null)
		{
			DynamicScopeValidation(AuthScopes.Channel_Subscriptions, authToken);
			if (string.IsNullOrWhiteSpace(channelId))
			{
				throw new BadParameterException("The channel id is not valid. It is not allowed to be null, empty or filled with whitespaces.");
			}
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			if (limit.HasValue)
			{
				list.Add(new KeyValuePair<string, string>("limit", limit.ToString()));
			}
			if (offset.HasValue)
			{
				list.Add(new KeyValuePair<string, string>("offset", offset.ToString()));
			}
			if (!string.IsNullOrEmpty(direction) && (direction == "asc" || direction == "desc"))
			{
				list.Add(new KeyValuePair<string, string>("direction", direction));
			}
			return TwitchGetGenericAsync<ChannelSubscribers>("/channels/" + channelId + "/subscriptions", ApiVersion.V5, list, authToken);
		}

		public async Task<List<Subscription>> GetAllSubscribersAsync(string channelId, string accessToken = null)
		{
			DynamicScopeValidation(AuthScopes.Channel_Subscriptions, accessToken);
			List<Subscription> allSubs = new List<Subscription>();
			ChannelSubscribers firstBatch = await GetChannelSubscribersAsync(channelId, 100, 0, "asc", accessToken);
			int totalSubs = firstBatch.Total;
			allSubs.AddRange(firstBatch.Subscriptions);
			int amount = firstBatch.Subscriptions.Length;
			int leftOverSubs = (totalSubs - amount) % 100;
			int requiredRequests = (totalSubs - amount - leftOverSubs) / 100;
			int currentOffset = amount;
			await Task.Delay(1000);
			for (int i = 0; i < requiredRequests; i++)
			{
				ChannelSubscribers requestedSubs = await GetChannelSubscribersAsync(channelId, 100, currentOffset, "asc", accessToken).ConfigureAwait(continueOnCapturedContext: false);
				allSubs.AddRange(requestedSubs.Subscriptions);
				currentOffset += requestedSubs.Subscriptions.Length;
				await Task.Delay(1000);
			}
			if (leftOverSubs > 0)
			{
				allSubs.AddRange((await GetChannelSubscribersAsync(channelId, leftOverSubs, currentOffset, "asc", accessToken).ConfigureAwait(continueOnCapturedContext: false)).Subscriptions);
			}
			return allSubs;
		}

		public Task<Subscription> CheckChannelSubscriptionByUserAsync(string channelId, string userId, string authToken = null)
		{
			DynamicScopeValidation(AuthScopes.Channel_Check_Subscription, authToken);
			if (string.IsNullOrWhiteSpace(channelId))
			{
				throw new BadParameterException("The channel id is not valid. It is not allowed to be null, empty or filled with whitespaces.");
			}
			if (string.IsNullOrWhiteSpace(userId))
			{
				throw new BadParameterException("The user id is not valid. It is not allowed to be null, empty or filled with whitespaces.");
			}
			return TwitchGetGenericAsync<Subscription>("/channels/" + channelId + "/subscriptions/" + userId, ApiVersion.V5, null, authToken);
		}

		public Task<ChannelVideos> GetChannelVideosAsync(string channelId, int? limit = null, int? offset = null, List<string> broadcastType = null, List<string> language = null, string sort = null)
		{
			if (string.IsNullOrWhiteSpace(channelId))
			{
				throw new BadParameterException("The channel id is not valid. It is not allowed to be null, empty or filled with whitespaces.");
			}
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			if (limit.HasValue)
			{
				list.Add(new KeyValuePair<string, string>("limit", limit.ToString()));
			}
			if (offset.HasValue)
			{
				list.Add(new KeyValuePair<string, string>("offset", offset.ToString()));
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
			return TwitchGetGenericAsync<ChannelVideos>("/channels/" + channelId + "/videos", ApiVersion.V5, list);
		}

		public Task<ChannelCommercial> StartChannelCommercialAsync(string channelId, CommercialLength duration, string authToken = null)
		{
			DynamicScopeValidation(AuthScopes.Channel_Commercial, authToken);
			if (string.IsNullOrWhiteSpace(channelId))
			{
				throw new BadParameterException("The channel id is not valid. It is not allowed to be null, empty or filled with whitespaces.");
			}
			int num = (int)duration;
			string payload = "{\"duration\": " + num + "}";
			return TwitchPostGenericAsync<ChannelCommercial>("/channels/" + channelId + "/commercial", ApiVersion.V5, payload, null, authToken);
		}

		public Task<ChannelAuthed> ResetChannelStreamKeyAsync(string channelId, string authToken = null)
		{
			DynamicScopeValidation(AuthScopes.Channel_Stream, authToken);
			if (string.IsNullOrWhiteSpace(channelId))
			{
				throw new BadParameterException("The channel id is not valid. It is not allowed to be null, empty or filled with whitespaces.");
			}
			return TwitchDeleteGenericAsync<ChannelAuthed>("/channels/" + channelId + "/stream_key", ApiVersion.V5, new List<KeyValuePair<string, string>>(), authToken);
		}
	}
}
