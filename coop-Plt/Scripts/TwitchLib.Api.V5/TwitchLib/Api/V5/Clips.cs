using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitchLib.Api.Core;
using TwitchLib.Api.Core.Enums;
using TwitchLib.Api.Core.Interfaces;
using TwitchLib.Api.V5.Models.Clips;

namespace TwitchLib.Api.V5
{
	public class Clips : ApiBase
	{
		public Clips(IApiSettings settings, IRateLimiter rateLimiter, IHttpCallHandler http)
			: base(settings, rateLimiter, http)
		{
		}

		public Task<Clip> GetClipAsync(string slug)
		{
			return TwitchGetGenericAsync<Clip>("/clips/" + slug, ApiVersion.V5);
		}

		public Task<TopClipsResponse> GetTopClipsAsync(string channel = null, string cursor = null, string game = null, long limit = 10L, TwitchLib.Api.V5.Models.Clips.Period period = TwitchLib.Api.V5.Models.Clips.Period.Week, bool trending = false)
		{
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("limit", limit.ToString())
			};
			if (channel != null)
			{
				list.Add(new KeyValuePair<string, string>("channel", channel));
			}
			if (cursor != null)
			{
				list.Add(new KeyValuePair<string, string>("cursor", cursor));
			}
			if (game != null)
			{
				list.Add(new KeyValuePair<string, string>("game", game));
			}
			list.Add(trending ? new KeyValuePair<string, string>("trending", "true") : new KeyValuePair<string, string>("trending", "false"));
			switch (period)
			{
			case TwitchLib.Api.V5.Models.Clips.Period.All:
				list.Add(new KeyValuePair<string, string>("period", "all"));
				break;
			case TwitchLib.Api.V5.Models.Clips.Period.Month:
				list.Add(new KeyValuePair<string, string>("period", "month"));
				break;
			case TwitchLib.Api.V5.Models.Clips.Period.Week:
				list.Add(new KeyValuePair<string, string>("period", "week"));
				break;
			case TwitchLib.Api.V5.Models.Clips.Period.Day:
				list.Add(new KeyValuePair<string, string>("period", "day"));
				break;
			default:
				throw new ArgumentOutOfRangeException("period", period, null);
			}
			return TwitchGetGenericAsync<TopClipsResponse>("/clips/top", ApiVersion.V5, list);
		}

		public Task<FollowClipsResponse> GetFollowedClipsAsync(long limit = 10L, string cursor = null, bool trending = false, string authToken = null)
		{
			DynamicScopeValidation(AuthScopes.User_Read, authToken);
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("limit", limit.ToString())
			};
			if (cursor != null)
			{
				list.Add(new KeyValuePair<string, string>("cursor", cursor));
			}
			list.Add(trending ? new KeyValuePair<string, string>("trending", "true") : new KeyValuePair<string, string>("trending", "false"));
			return TwitchGetGenericAsync<FollowClipsResponse>("/clips/followed", ApiVersion.V5, list, authToken);
		}
	}
}
