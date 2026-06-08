using System.Collections.Generic;
using System.Threading.Tasks;
using TwitchLib.Api.Core;
using TwitchLib.Api.Core.Enums;
using TwitchLib.Api.Core.Exceptions;
using TwitchLib.Api.Core.Interfaces;
using TwitchLib.Api.Helix.Models.Games;

namespace TwitchLib.Api.Helix
{
	public class Games : ApiBase
	{
		public Games(IApiSettings settings, IRateLimiter rateLimiter, IHttpCallHandler http)
			: base(settings, rateLimiter, http)
		{
		}

		public Task<GetGamesResponse> GetGamesAsync(List<string> gameIds = null, List<string> gameNames = null)
		{
			if ((gameIds == null && gameNames == null) || (gameIds != null && gameIds.Count == 0 && gameNames == null) || (gameNames != null && gameNames.Count == 0 && gameIds == null))
			{
				throw new BadParameterException("Either gameIds or gameNames must have at least one value");
			}
			if (gameIds != null && gameIds.Count > 100)
			{
				throw new BadParameterException("gameIds list cannot exceed 100 items");
			}
			if (gameNames != null && gameNames.Count > 100)
			{
				throw new BadParameterException("gameNames list cannot exceed 100 items");
			}
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			if (gameIds != null && gameIds.Count > 0)
			{
				foreach (string gameId in gameIds)
				{
					list.Add(new KeyValuePair<string, string>("id", gameId));
				}
			}
			if (gameNames != null && gameNames.Count > 0)
			{
				foreach (string gameName in gameNames)
				{
					list.Add(new KeyValuePair<string, string>("name", gameName));
				}
			}
			return TwitchGetGenericAsync<GetGamesResponse>("/games", ApiVersion.Helix, list);
		}

		public Task<GetTopGamesResponse> GetTopGamesAsync(string before = null, string after = null, int first = 20)
		{
			if (first < 0 || first > 100)
			{
				throw new BadParameterException("'first' parameter must be between 1 (inclusive) and 100 (inclusive).");
			}
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("first", first.ToString())
			};
			if (before != null)
			{
				list.Add(new KeyValuePair<string, string>("before", before));
			}
			if (after != null)
			{
				list.Add(new KeyValuePair<string, string>("after", after));
			}
			return TwitchGetGenericAsync<GetTopGamesResponse>("/games/top", ApiVersion.Helix, list);
		}
	}
}
