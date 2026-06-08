using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using TwitchLib.Api.Core;
using TwitchLib.Api.Core.Enums;
using TwitchLib.Api.Core.Exceptions;
using TwitchLib.Api.Core.Interfaces;
using TwitchLib.Api.Helix.Models.Users.GetUserActiveExtensions;
using TwitchLib.Api.Helix.Models.Users.GetUserBlockList;
using TwitchLib.Api.Helix.Models.Users.GetUserExtensions;
using TwitchLib.Api.Helix.Models.Users.GetUserFollows;
using TwitchLib.Api.Helix.Models.Users.GetUsers;
using TwitchLib.Api.Helix.Models.Users.Internal;
using TwitchLib.Api.Helix.Models.Users.UpdateUserExtensions;

namespace TwitchLib.Api.Helix
{
	public class Users : ApiBase
	{
		public Users(IApiSettings settings, IRateLimiter rateLimiter, IHttpCallHandler http)
			: base(settings, rateLimiter, http)
		{
		}

		public Task<GetUserBlockListResponse> GetUserBlockListAsync(string broadcasterId, int first = 20, string after = null, string accessToken = null)
		{
			DynamicScopeValidation(AuthScopes.Helix_User_Read_BlockedUsers, accessToken);
			if (first > 100)
			{
				throw new BadParameterException($"Maximum allowed objects is 100 (you passed {first})");
			}
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			list.Add(new KeyValuePair<string, string>("broadcaster_id", broadcasterId));
			list.Add(new KeyValuePair<string, string>("first", first.ToString()));
			if (after != null)
			{
				list.Add(new KeyValuePair<string, string>("after", after));
			}
			return TwitchGetGenericAsync<GetUserBlockListResponse>("/users/blocks", ApiVersion.Helix, list, accessToken);
		}

		public Task BlockUserAsync(string targetUserId, BlockUserSourceContextEnum? sourceContext = null, BlockUserReasonEnum? reason = null, string accessToken = null)
		{
			DynamicScopeValidation(AuthScopes.Helix_User_Manage_BlockedUsers, accessToken);
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			list.Add(new KeyValuePair<string, string>("target_user_id", targetUserId));
			if (sourceContext.HasValue)
			{
				list.Add(new KeyValuePair<string, string>("source_context", sourceContext.Value.ToString().ToLower()));
			}
			if (reason.HasValue)
			{
				list.Add(new KeyValuePair<string, string>("reason", reason.Value.ToString().ToLower()));
			}
			return TwitchPutAsync("/users/blocks", ApiVersion.Helix, null, list, accessToken);
		}

		public Task UnblockUserAsync(string targetUserId, string accessToken = null)
		{
			DynamicScopeValidation(AuthScopes.Helix_User_Manage_BlockedUsers, accessToken);
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			list.Add(new KeyValuePair<string, string>("target_user_id", targetUserId));
			return TwitchDeleteAsync("/user/blocks", ApiVersion.Helix, list, accessToken);
		}

		public Task<GetUsersResponse> GetUsersAsync(List<string> ids = null, List<string> logins = null, string accessToken = null)
		{
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			if (ids != null && ids.Count > 0)
			{
				foreach (string id in ids)
				{
					list.Add(new KeyValuePair<string, string>("id", id));
				}
			}
			if (logins != null && logins.Count > 0)
			{
				foreach (string login in logins)
				{
					list.Add(new KeyValuePair<string, string>("login", login));
				}
			}
			return TwitchGetGenericAsync<GetUsersResponse>("/users", ApiVersion.Helix, list, accessToken);
		}

		public Task<GetUsersFollowsResponse> GetUsersFollowsAsync(string after = null, string before = null, int first = 20, string fromId = null, string toId = null)
		{
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("first", first.ToString())
			};
			if (after != null)
			{
				list.Add(new KeyValuePair<string, string>("after", after));
			}
			if (before != null)
			{
				list.Add(new KeyValuePair<string, string>("before", before));
			}
			if (fromId != null)
			{
				list.Add(new KeyValuePair<string, string>("from_id", fromId));
			}
			if (toId != null)
			{
				list.Add(new KeyValuePair<string, string>("to_id", toId));
			}
			return TwitchGetGenericAsync<GetUsersFollowsResponse>("/users/follows", ApiVersion.Helix, list);
		}

		public Task PutUsersAsync(string description, string accessToken = null)
		{
			List<KeyValuePair<string, string>> getParams = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("description", description)
			};
			return TwitchPutAsync("/users", ApiVersion.Helix, null, getParams, accessToken);
		}

		public Task<GetUserExtensionsResponse> GetUserExtensionsAsync(string authToken = null)
		{
			return TwitchGetGenericAsync<GetUserExtensionsResponse>("/users/extensions/list", ApiVersion.Helix, null, authToken);
		}

		public Task<GetUserActiveExtensionsResponse> GetUserActiveExtensionsAsync(string userid = null, string authToken = null)
		{
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			if (userid != null)
			{
				list.Add(new KeyValuePair<string, string>("user_id", userid));
			}
			return TwitchGetGenericAsync<GetUserActiveExtensionsResponse>("/users/extensions", ApiVersion.Helix, list, authToken);
		}

		public Task<GetUserActiveExtensionsResponse> UpdateUserExtensionsAsync(IEnumerable<ExtensionSlot> userExtensionStates, string authToken = null)
		{
			DynamicScopeValidation(AuthScopes.Channel_Editor, authToken);
			Dictionary<string, UserExtensionState> dictionary = new Dictionary<string, UserExtensionState>();
			Dictionary<string, UserExtensionState> dictionary2 = new Dictionary<string, UserExtensionState>();
			Dictionary<string, UserExtensionState> dictionary3 = new Dictionary<string, UserExtensionState>();
			foreach (ExtensionSlot userExtensionState in userExtensionStates)
			{
				switch (userExtensionState.Type)
				{
				case ExtensionType.Component:
					dictionary3.Add(userExtensionState.Slot, userExtensionState.UserExtensionState);
					break;
				case ExtensionType.Overlay:
					dictionary2.Add(userExtensionState.Slot, userExtensionState.UserExtensionState);
					break;
				case ExtensionType.Panel:
					dictionary.Add(userExtensionState.Slot, userExtensionState.UserExtensionState);
					break;
				default:
					throw new ArgumentOutOfRangeException("ExtensionType");
				}
			}
			JObject jObject = new JObject();
			UpdateUserExtensionsRequest updateUserExtensionsRequest = new UpdateUserExtensionsRequest();
			if (dictionary.Count > 0)
			{
				updateUserExtensionsRequest.Panel = dictionary;
			}
			if (dictionary2.Count > 0)
			{
				updateUserExtensionsRequest.Overlay = dictionary2;
			}
			if (dictionary3.Count > 0)
			{
				updateUserExtensionsRequest.Component = dictionary3;
			}
			jObject.Add(new JProperty("data", JObject.FromObject(updateUserExtensionsRequest)));
			string payload = jObject.ToString();
			return TwitchPutGenericAsync<GetUserActiveExtensionsResponse>("/users/extensions", ApiVersion.Helix, payload, null, authToken);
		}

		public Task CreateUserFollows(string from_id, string to_id, bool? allow_notifications = null, string authToken = null)
		{
			if (string.IsNullOrWhiteSpace(from_id))
			{
				throw new BadParameterException("from_id must be set");
			}
			if (string.IsNullOrWhiteSpace(to_id))
			{
				throw new BadParameterException("to_id must be set");
			}
			DynamicScopeValidation(AuthScopes.Helix_User_Edit_Follows, authToken);
			JObject jObject = new JObject();
			jObject.Add(new JProperty("from_id", from_id));
			jObject.Add(new JProperty("to_id", to_id));
			if (allow_notifications.HasValue)
			{
				jObject.Add(new JProperty("allow_notifications", allow_notifications.Value));
			}
			string payload = jObject.ToString();
			return TwitchPostAsync("/users/follows", ApiVersion.Helix, payload, null, authToken);
		}

		public Task DeleteUserFollows(string from_id, string to_id, string authToken = null)
		{
			if (string.IsNullOrWhiteSpace(from_id))
			{
				throw new BadParameterException("from_id must be set");
			}
			if (string.IsNullOrWhiteSpace(to_id))
			{
				throw new BadParameterException("to_id must be set");
			}
			DynamicScopeValidation(AuthScopes.Helix_User_Edit_Follows, authToken);
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			list.Add(new KeyValuePair<string, string>("from_id", from_id));
			list.Add(new KeyValuePair<string, string>("to_id", to_id));
			return TwitchDeleteAsync("/users/follows", ApiVersion.Helix, list, authToken);
		}
	}
}
