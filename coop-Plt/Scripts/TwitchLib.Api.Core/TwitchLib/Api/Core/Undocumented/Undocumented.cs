using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitchLib.Api.Core.Enums;
using TwitchLib.Api.Core.Exceptions;
using TwitchLib.Api.Core.Interfaces;
using TwitchLib.Api.Core.Interfaces.Clips;
using TwitchLib.Api.Core.Models.Undocumented.CSMaps;
using TwitchLib.Api.Core.Models.Undocumented.CSStreams;
using TwitchLib.Api.Core.Models.Undocumented.ChannelExtensionData;
using TwitchLib.Api.Core.Models.Undocumented.ChannelPanels;
using TwitchLib.Api.Core.Models.Undocumented.ChatProperties;
using TwitchLib.Api.Core.Models.Undocumented.ChatUser;
using TwitchLib.Api.Core.Models.Undocumented.Chatters;
using TwitchLib.Api.Core.Models.Undocumented.ClipChat;
using TwitchLib.Api.Core.Models.Undocumented.Comments;
using TwitchLib.Api.Core.Models.Undocumented.RecentEvents;
using TwitchLib.Api.Core.Models.Undocumented.RecentMessages;
using TwitchLib.Api.Core.Models.Undocumented.TwitchPrimeOffers;

namespace TwitchLib.Api.Core.Undocumented
{
	public class Undocumented : ApiBase
	{
		public Undocumented(IApiSettings settings, IRateLimiter rateLimiter, IHttpCallHandler http)
			: base(settings, rateLimiter, http)
		{
		}

		public async Task<GetClipChatResponse> GetClipChatAsync(IClip clip)
		{
			if (clip == null)
			{
				return null;
			}
			string vodId = "v" + clip.VOD.Id;
			string offsetTime = clip.VOD.Url.Split('=')[1];
			long offsetSeconds = 2L;
			if (offsetTime.Contains("h"))
			{
				offsetSeconds += int.Parse(offsetTime.Split('h')[0]) * 60 * 60;
				offsetTime = offsetTime.Replace(offsetTime.Split('h')[0] + "h", "");
			}
			if (offsetTime.Contains("m"))
			{
				offsetSeconds += int.Parse(offsetTime.Split('m')[0]) * 60;
				offsetTime = offsetTime.Replace(offsetTime.Split('m')[0] + "m", "");
			}
			if (offsetTime.Contains("s"))
			{
				offsetSeconds += int.Parse(offsetTime.Split('s')[0]);
			}
			List<KeyValuePair<string, string>> getParams = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("video_id", vodId),
				new KeyValuePair<string, string>("offset_seconds", offsetSeconds.ToString())
			};
			return await GetGenericAsync<GetClipChatResponse>("https://rechat.twitch.tv/rechat-messages", getParams).ConfigureAwait(continueOnCapturedContext: false);
		}

		public Task<TwitchPrimeOffers> GetTwitchPrimeOffersAsync()
		{
			List<KeyValuePair<string, string>> getParams = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("on_site", "1")
			};
			return GetGenericAsync<TwitchPrimeOffers>("https://api.twitch.tv/api/premium/offers", getParams);
		}

		public Task<ChatProperties> GetChatPropertiesAsync(string channelName)
		{
			return GetGenericAsync<ChatProperties>("https://api.twitch.tv/api/channels/" + channelName + "/chat_properties");
		}

		public Task<Panel[]> GetChannelPanelsAsync(string channelName)
		{
			return GetGenericAsync<Panel[]>("https://api.twitch.tv/api/channels/" + channelName + "/panels");
		}

		public Task<CSMapsResponse> GetCSMapsAsync()
		{
			return GetGenericAsync<CSMapsResponse>("https://api.twitch.tv/api/cs/maps");
		}

		public Task<CSStreams> GetCSStreamsAsync(int limit = 25, int offset = 0)
		{
			List<KeyValuePair<string, string>> getParams = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("limit", limit.ToString()),
				new KeyValuePair<string, string>("offset", offset.ToString())
			};
			return GetGenericAsync<CSStreams>("https://api.twitch.tv/api/cs", getParams);
		}

		public Task<RecentMessagesResponse> GetRecentMessagesAsync(string channelId)
		{
			return GetGenericAsync<RecentMessagesResponse>("https://tmi.twitch.tv/api/rooms/" + channelId + "/recent_messages");
		}

		public async Task<List<ChatterFormatted>> GetChattersAsync(string channelName)
		{
			ChattersResponse resp = await GetGenericAsync<ChattersResponse>("https://tmi.twitch.tv/group/user/" + channelName.ToLower() + "/chatters");
			List<ChatterFormatted> chatters = resp.Chatters.Staff.Select((string username) => new ChatterFormatted(username, UserType.Staff)).ToList();
			chatters.AddRange(resp.Chatters.Admins.Select((string username) => new ChatterFormatted(username, UserType.Admin)));
			chatters.AddRange(resp.Chatters.GlobalMods.Select((string username) => new ChatterFormatted(username, UserType.GlobalModerator)));
			chatters.AddRange(resp.Chatters.Moderators.Select((string username) => new ChatterFormatted(username, UserType.Moderator)));
			chatters.AddRange(resp.Chatters.Viewers.Select((string username) => new ChatterFormatted(username, UserType.Viewer)));
			chatters.AddRange(resp.Chatters.VIP.Select((string username) => new ChatterFormatted(username, UserType.VIP)));
			foreach (ChatterFormatted chatter in chatters)
			{
				if (string.Equals(chatter.Username, channelName, StringComparison.CurrentCultureIgnoreCase))
				{
					chatter.UserType = UserType.Broadcaster;
				}
			}
			return chatters;
		}

		public Task<RecentEvents> GetRecentChannelEventsAsync(string channelId)
		{
			return GetGenericAsync<RecentEvents>("https://api.twitch.tv/bits/channels/" + channelId + "/events/recent");
		}

		public Task<ChatUserResponse> GetChatUserAsync(string userId, string channelId = null)
		{
			return GetGenericAsync<ChatUserResponse>((channelId != null) ? ("https://api.twitch.tv/kraken/users/" + userId + "/chat/channels/" + channelId) : ("https://api.twitch.tv/kraken/users/" + userId + "/chat/"));
		}

		public Task<bool> IsUsernameAvailableAsync(string username)
		{
			List<KeyValuePair<string, string>> getParams = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("users_service", "true")
			};
			int num = RequestReturnResponseCode("https://passport.twitch.tv/usernames/" + username, "HEAD", getParams);
			return num switch
			{
				200 => Task.FromResult(result: false), 
				204 => Task.FromResult(result: true), 
				_ => throw new BadResourceException("Unexpected response from resource. Expecting response code 200 or 204, received: " + num), 
			};
		}

		public Task<GetChannelExtensionDataResponse> GetChannelExtensionDataAsync(string channelId)
		{
			return TwitchGetGenericAsync<GetChannelExtensionDataResponse>("/channels/" + channelId + "/extensions", ApiVersion.V5, null, null, null, "https://api.twitch.tv/v5");
		}

		public Task<CommentsPage> GetCommentsPageAsync(string videoId, int? contentOffsetSeconds = null, string cursor = null)
		{
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			if (string.IsNullOrWhiteSpace(videoId))
			{
				throw new BadParameterException("The video id is not valid. It is not allowed to be null, empty or filled with whitespaces.");
			}
			if (contentOffsetSeconds.HasValue)
			{
				list.Add(new KeyValuePair<string, string>("content_offset_seconds", contentOffsetSeconds.Value.ToString()));
			}
			if (cursor != null)
			{
				list.Add(new KeyValuePair<string, string>("cursor", cursor));
			}
			return GetGenericAsync<CommentsPage>("https://api.twitch.tv/kraken/videos/" + videoId + "/comments", list);
		}

		public async Task<List<CommentsPage>> GetAllCommentsAsync(string videoId)
		{
			List<CommentsPage> list = new List<CommentsPage>();
			List<CommentsPage> list2 = list;
			list2.Add(await GetCommentsPageAsync(videoId));
			List<CommentsPage> pages = list;
			while (pages.Last().Next != null)
			{
				List<CommentsPage> list3 = pages;
				list3.Add(await GetCommentsPageAsync(videoId, null, pages.Last().Next));
			}
			return pages;
		}
	}
}
