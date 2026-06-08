using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TwitchLib.Api.Core;
using TwitchLib.Api.Core.Enums;
using TwitchLib.Api.Core.Interfaces;
using TwitchLib.Api.Helix.Models.EventSub;

namespace TwitchLib.Api.Helix
{
	public class EventSub : ApiBase
	{
		public EventSub(IApiSettings settings, IRateLimiter rateLimiter, IHttpCallHandler http)
			: base(settings, rateLimiter, http)
		{
		}

		public Task<CreateEventSubSubscriptionResponse> CreateEventSubSubscriptionAsync(string type, string version, Dictionary<string, string> condition, string method, string callback, string secret, string clientId = null, string accessToken = null)
		{
			var value = new
			{
				type = type,
				version = version,
				condition = condition,
				transport = new { method, callback, secret }
			};
			return TwitchPostGenericAsync<CreateEventSubSubscriptionResponse>("/eventsub/subscriptions", ApiVersion.Helix, JsonConvert.SerializeObject(value), null, accessToken, clientId);
		}

		public Task<GetEventSubSubscriptionsResponse> GetEventSubSubscriptionsAsync(string status = null, string type = null, string after = null, string clientId = null, string accessToken = null)
		{
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			if (!string.IsNullOrWhiteSpace(status))
			{
				list.Add(new KeyValuePair<string, string>("status", status));
			}
			if (!string.IsNullOrWhiteSpace(type))
			{
				list.Add(new KeyValuePair<string, string>("type", type));
			}
			if (!string.IsNullOrWhiteSpace(after))
			{
				list.Add(new KeyValuePair<string, string>("after", after));
			}
			return TwitchGetGenericAsync<GetEventSubSubscriptionsResponse>("/eventsub/subscriptions", ApiVersion.Helix, list, accessToken, clientId);
		}

		public async Task<bool> DeleteEventSubSubscriptionAsync(string id, string clientId = null, string accessToken = null)
		{
			List<KeyValuePair<string, string>> getParams = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("id", id)
			};
			return !string.IsNullOrWhiteSpace(await TwitchDeleteAsync("eventsub/subscriptions", ApiVersion.Helix, getParams, accessToken, clientId));
		}
	}
}
