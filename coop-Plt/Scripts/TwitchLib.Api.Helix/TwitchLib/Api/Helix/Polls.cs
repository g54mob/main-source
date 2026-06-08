using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TwitchLib.Api.Core;
using TwitchLib.Api.Core.Enums;
using TwitchLib.Api.Core.Interfaces;
using TwitchLib.Api.Helix.Models.Polls.CreatePoll;
using TwitchLib.Api.Helix.Models.Polls.EndPoll;
using TwitchLib.Api.Helix.Models.Polls.GetPolls;

namespace TwitchLib.Api.Helix
{
	public class Polls : ApiBase
	{
		public Polls(IApiSettings settings, IRateLimiter rateLimiter, IHttpCallHandler http)
			: base(settings, rateLimiter, http)
		{
		}

		public Task<GetPollsResponse> GetPolls(string broadcasterId, List<string> ids = null, string after = null, int first = 20, string accessToken = null)
		{
			DynamicScopeValidation(AuthScopes.Helix_Channel_Read_Polls, accessToken);
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("broadcaster_id", broadcasterId),
				new KeyValuePair<string, string>("first", first.ToString())
			};
			if (ids != null && ids.Count > 0)
			{
				foreach (string id in ids)
				{
					list.Add(new KeyValuePair<string, string>("id", id));
				}
			}
			if (after != null)
			{
				list.Add(new KeyValuePair<string, string>("after", after));
			}
			return TwitchGetGenericAsync<GetPollsResponse>("/polls", ApiVersion.Helix, list, accessToken);
		}

		public Task<CreatePollResponse> CreatePoll(CreatePollRequest request, string accessToken = null)
		{
			DynamicScopeValidation(AuthScopes.Helix_Channel_Manage_Polls, accessToken);
			return TwitchPostGenericAsync<CreatePollResponse>("/polls", ApiVersion.Helix, JsonConvert.SerializeObject(request), null, accessToken);
		}

		public Task<EndPollResponse> EndPoll(string broadcasterId, string id, PollStatusEnum status, string accessToken = null)
		{
			DynamicScopeValidation(AuthScopes.Helix_Channel_Manage_Polls, accessToken);
			JObject jObject = new JObject();
			jObject["broadcaster_id"] = broadcasterId;
			jObject["id"] = id;
			jObject["status"] = status.ToString();
			return TwitchPatchGenericAsync<EndPollResponse>("/polls", ApiVersion.Helix, jObject.ToString(), null, accessToken);
		}
	}
}
