using System.Collections.Generic;
using System.Threading.Tasks;
using TwitchLib.Api.Core;
using TwitchLib.Api.Core.Enums;
using TwitchLib.Api.Core.Interfaces;
using TwitchLib.Api.Helix.Models.Analytics;

namespace TwitchLib.Api.Helix
{
	public class Analytics : ApiBase
	{
		public Analytics(IApiSettings settings, IRateLimiter rateLimiter, IHttpCallHandler http)
			: base(settings, rateLimiter, http)
		{
		}

		public Task<GetGameAnalyticsResponse> GetGameAnalyticsAsync(string gameId = null, string authToken = null)
		{
			DynamicScopeValidation(AuthScopes.Helix_Analytics_Read_Games, authToken);
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			if (gameId != null)
			{
				list.Add(new KeyValuePair<string, string>("game_id", gameId));
			}
			return TwitchGetGenericAsync<GetGameAnalyticsResponse>("/analytics/games", ApiVersion.Helix, list, authToken);
		}

		public Task<GetExtensionAnalyticsResponse> GetExtensionAnalyticsAsync(string extensionId, string authToken = null)
		{
			DynamicScopeValidation(AuthScopes.Helix_Analytics_Read_Extensions, authToken);
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			if (extensionId != null)
			{
				list.Add(new KeyValuePair<string, string>("extension_id", extensionId));
			}
			return TwitchGetGenericAsync<GetExtensionAnalyticsResponse>("/analytics/extensions", ApiVersion.Helix, list, authToken);
		}
	}
}
