using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TwitchLib.Api.Core;
using TwitchLib.Api.Core.Enums;
using TwitchLib.Api.Core.Exceptions;
using TwitchLib.Api.Core.Interfaces;
using TwitchLib.Api.Helix.Models.Streams.CreateStreamMarker;
using TwitchLib.Api.Helix.Models.Streams.GetStreamKey;
using TwitchLib.Api.Helix.Models.Streams.GetStreamMarkers;
using TwitchLib.Api.Helix.Models.Streams.GetStreamTags;
using TwitchLib.Api.Helix.Models.Streams.GetStreams;
using TwitchLib.Api.Helix.Models.StreamsMetadata;

namespace TwitchLib.Api.Helix
{
	public class Streams : ApiBase
	{
		public Streams(IApiSettings settings, IRateLimiter rateLimiter, IHttpCallHandler http)
			: base(settings, rateLimiter, http)
		{
		}

		public Task<GetStreamsResponse> GetStreamsAsync(string after = null, List<string> communityIds = null, int first = 20, List<string> gameIds = null, List<string> languages = null, string type = "all", List<string> userIds = null, List<string> userLogins = null)
		{
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("first", first.ToString()),
				new KeyValuePair<string, string>("type", type)
			};
			if (after != null)
			{
				list.Add(new KeyValuePair<string, string>("after", after));
			}
			if (communityIds != null && communityIds.Count > 0)
			{
				foreach (string communityId in communityIds)
				{
					list.Add(new KeyValuePair<string, string>("community_id", communityId));
				}
			}
			if (gameIds != null && gameIds.Count > 0)
			{
				foreach (string gameId in gameIds)
				{
					list.Add(new KeyValuePair<string, string>("game_id", gameId));
				}
			}
			if (languages != null && languages.Count > 0)
			{
				foreach (string language in languages)
				{
					list.Add(new KeyValuePair<string, string>("language", language));
				}
			}
			if (userIds != null && userIds.Count > 0)
			{
				foreach (string userId in userIds)
				{
					list.Add(new KeyValuePair<string, string>("user_id", userId));
				}
			}
			if (userLogins != null && userLogins.Count > 0)
			{
				foreach (string userLogin in userLogins)
				{
					list.Add(new KeyValuePair<string, string>("user_login", userLogin));
				}
			}
			return TwitchGetGenericAsync<GetStreamsResponse>("/streams", ApiVersion.Helix, list);
		}

		public Task<GetStreamsMetadataResponse> GetStreamsMetadataAsync(string after = null, List<string> communityIds = null, int first = 20, List<string> gameIds = null, List<string> languages = null, string type = "all", List<string> userIds = null, List<string> userLogins = null)
		{
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("first", first.ToString()),
				new KeyValuePair<string, string>("type", type)
			};
			if (after != null)
			{
				list.Add(new KeyValuePair<string, string>("after", after));
			}
			if (communityIds != null && communityIds.Count > 0)
			{
				foreach (string communityId in communityIds)
				{
					list.Add(new KeyValuePair<string, string>("community_id", communityId));
				}
			}
			if (gameIds != null && gameIds.Count > 0)
			{
				foreach (string gameId in gameIds)
				{
					list.Add(new KeyValuePair<string, string>("game_id", gameId));
				}
			}
			if (languages != null && languages.Count > 0)
			{
				foreach (string language in languages)
				{
					list.Add(new KeyValuePair<string, string>("language", language));
				}
			}
			if (userIds != null && userIds.Count > 0)
			{
				foreach (string userId in userIds)
				{
					list.Add(new KeyValuePair<string, string>("user_id", userId));
				}
			}
			if (userLogins != null && userLogins.Count > 0)
			{
				foreach (string userLogin in userLogins)
				{
					list.Add(new KeyValuePair<string, string>("user_login", userLogin));
				}
			}
			return TwitchGetGenericAsync<GetStreamsMetadataResponse>("/streams/metadata", ApiVersion.Helix, list);
		}

		public Task<GetStreamTagsResponse> GetStreamTagsAsync(string broadcasterId, string accessToken = null)
		{
			if (string.IsNullOrEmpty(broadcasterId))
			{
				throw new BadParameterException("BroadcasterId must be set");
			}
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			list.Add(new KeyValuePair<string, string>("broadcaster_id", broadcasterId));
			return TwitchGetGenericAsync<GetStreamTagsResponse>("/streams/tags", ApiVersion.Helix, list, accessToken);
		}

		public Task ReplaceStreamTagsAsync(string broadcasterId, List<string> tagIds = null, string accessToken = null)
		{
			DynamicScopeValidation(AuthScopes.Helix_User_Edit_Broadcast, accessToken);
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			list.Add(new KeyValuePair<string, string>("broadcaster_id", broadcasterId));
			string payload = null;
			if (tagIds != null && tagIds.Count > 0)
			{
				dynamic val = new JObject();
				val.tag_ids = new JArray(tagIds);
				payload = val.ToString();
			}
			return TwitchPutAsync("/streams/tags", ApiVersion.Helix, payload, list, accessToken);
		}

		public Task<GetStreamKeyResponse> GetStreamKeyAsync(string broadcasterId, string accessToken = null)
		{
			DynamicScopeValidation(AuthScopes.Helix_Channel_Read_Stream_Key, accessToken);
			List<KeyValuePair<string, string>> getParams = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("broadcaster_id", broadcasterId)
			};
			return TwitchGetGenericAsync<GetStreamKeyResponse>("/streams/key", ApiVersion.Helix, getParams, accessToken);
		}

		public Task<CreateStreamMarkerResponse> CreateStreamMarkerAsync(CreateStreamMarkerRequest request, string accessToken = null)
		{
			DynamicScopeValidation(AuthScopes.Helix_User_Edit_Broadcast, accessToken);
			return TwitchPostGenericAsync<CreateStreamMarkerResponse>("/streams/markers", ApiVersion.Helix, JsonConvert.SerializeObject(request), null, accessToken);
		}

		public Task<GetStreamMarkersResponse> GetStreamMarkerAsync(string userId, string videoId, string accessToken = null)
		{
			DynamicScopeValidation(AuthScopes.Helix_User_Edit_Broadcast, accessToken);
			List<KeyValuePair<string, string>> getParams = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("user_id", userId),
				new KeyValuePair<string, string>("video_id", videoId)
			};
			return TwitchGetGenericAsync<GetStreamMarkersResponse>("/stream/markers", ApiVersion.Helix, getParams, accessToken);
		}
	}
}
