using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TwitchLib.Api.Core;
using TwitchLib.Api.Core.Enums;
using TwitchLib.Api.Core.Exceptions;
using TwitchLib.Api.Core.Interfaces;
using TwitchLib.Api.Helix.Models.Moderation.CheckAutoModStatus;
using TwitchLib.Api.Helix.Models.Moderation.CheckAutoModStatus.Request;
using TwitchLib.Api.Helix.Models.Moderation.GetBannedEvents;
using TwitchLib.Api.Helix.Models.Moderation.GetBannedUsers;
using TwitchLib.Api.Helix.Models.Moderation.GetModeratorEvents;
using TwitchLib.Api.Helix.Models.Moderation.GetModerators;

namespace TwitchLib.Api.Helix
{
	public class Moderation : ApiBase
	{
		public Moderation(IApiSettings settings, IRateLimiter rateLimiter, IHttpCallHandler http)
			: base(settings, rateLimiter, http)
		{
		}

		public Task ManageHeldAutoModMessages(string userId, string msgId, ManageHeldAutoModMessageActionEnum action, string accessToken = null)
		{
			if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(msgId))
			{
				throw new BadParameterException("userId and msgId cannot be null and must be greater than 0 length");
			}
			JObject jObject = new JObject();
			jObject["user_id"] = userId;
			jObject["msg_id"] = msgId;
			jObject["action"] = action.ToString().ToUpper();
			return TwitchPostAsync("/moderation/automod/message", ApiVersion.Helix, jObject.ToString(), null, accessToken);
		}

		public Task<CheckAutoModStatusResponse> CheckAutoModStatusAsync(List<Message> messages, string broadcasterId, string accessToken = null)
		{
			if (messages == null || messages.Count == 0)
			{
				throw new BadParameterException("messages cannot be null and must be greater than 0 length");
			}
			if (broadcasterId == null || broadcasterId.Length == 0)
			{
				throw new BadParameterException("broadcasterId cannot be null and must be greater than 0 length");
			}
			List<KeyValuePair<string, string>> getParams = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("broacaster_id", broadcasterId)
			};
			MessageRequest value = new MessageRequest
			{
				Messages = messages.ToArray()
			};
			return TwitchPostGenericAsync<CheckAutoModStatusResponse>("/moderation/enforcements/status", ApiVersion.Helix, JsonConvert.SerializeObject(value), getParams, accessToken);
		}

		public Task<GetBannedEventsResponse> GetBannedEventsAsync(string broadcasterId, List<string> userIds = null, string after = null, string first = null, string accessToken = null)
		{
			if (broadcasterId == null || broadcasterId.Length == 0)
			{
				throw new BadParameterException("broadcasterId cannot be null and must be greater than 0 length");
			}
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("broadcaster_id", broadcasterId)
			};
			if (userIds != null && userIds.Count > 0)
			{
				foreach (string userId in userIds)
				{
					list.Add(new KeyValuePair<string, string>("user_id", userId));
				}
			}
			if (after != null)
			{
				list.Add(new KeyValuePair<string, string>("after", after));
			}
			if (first != null)
			{
				list.Add(new KeyValuePair<string, string>("first", first));
			}
			return TwitchGetGenericAsync<GetBannedEventsResponse>("/moderation/banned/events", ApiVersion.Helix, list, accessToken);
		}

		public Task<GetBannedUsersResponse> GetBannedUsersAsync(string broadcasterId, List<string> userIds = null, string after = null, string before = null, string accessToken = null)
		{
			if (broadcasterId == null || broadcasterId.Length == 0)
			{
				throw new BadParameterException("broadcasterId cannot be null and must be greater than 0 length");
			}
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("broadcaster_id", broadcasterId)
			};
			if (userIds != null && userIds.Count > 0)
			{
				foreach (string userId in userIds)
				{
					list.Add(new KeyValuePair<string, string>("user_id", userId));
				}
			}
			if (after != null)
			{
				list.Add(new KeyValuePair<string, string>("after", after));
			}
			if (before != null)
			{
				list.Add(new KeyValuePair<string, string>("before", before));
			}
			return TwitchGetGenericAsync<GetBannedUsersResponse>("/moderation/banned", ApiVersion.Helix, list, accessToken);
		}

		public Task<GetModeratorsResponse> GetModeratorsAsync(string broadcasterId, List<string> userIds = null, string after = null, string accessToken = null)
		{
			if (broadcasterId == null || broadcasterId.Length == 0)
			{
				throw new BadParameterException("broadcasterId cannot be null and must be greater than 0 length");
			}
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("broadcaster_id", broadcasterId)
			};
			if (userIds != null && userIds.Count > 0)
			{
				foreach (string userId in userIds)
				{
					list.Add(new KeyValuePair<string, string>("user_id", userId));
				}
			}
			if (after != null)
			{
				list.Add(new KeyValuePair<string, string>("after", after));
			}
			return TwitchGetGenericAsync<GetModeratorsResponse>("/moderation/moderators", ApiVersion.Helix, list, accessToken);
		}

		public Task<GetModeratorEventsResponse> GetModeratorEventsAsync(string broadcasterId, List<string> userIds = null, string accessToken = null)
		{
			if (broadcasterId == null || broadcasterId.Length == 0)
			{
				throw new BadParameterException("broadcasterId cannot be null and must be greater than 0 length");
			}
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("broadcaster_id", broadcasterId)
			};
			if (userIds != null && userIds.Count > 0)
			{
				foreach (string userId in userIds)
				{
					list.Add(new KeyValuePair<string, string>("user_id", userId));
				}
			}
			return TwitchGetGenericAsync<GetModeratorEventsResponse>("/moderation/moderators/events", ApiVersion.Helix, list, accessToken);
		}
	}
}
