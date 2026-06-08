using System.Collections.Generic;
using System.Threading.Tasks;
using TwitchLib.Api.Core;
using TwitchLib.Api.Core.Enums;
using TwitchLib.Api.Core.Interfaces;
using TwitchLib.Api.V5.Models.Games;

namespace TwitchLib.Api.V5
{
	public class Games : ApiBase
	{
		public Games(IApiSettings settings, IRateLimiter rateLimiter, IHttpCallHandler http)
			: base(settings, rateLimiter, http)
		{
		}

		public Task<TopGames> GetTopGamesAsync(int? limit = null, int? offset = null)
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
			return TwitchGetGenericAsync<TopGames>("/games/top", ApiVersion.V5, list);
		}
	}
}
