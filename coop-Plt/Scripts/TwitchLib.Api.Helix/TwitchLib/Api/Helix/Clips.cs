using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitchLib.Api.Core;
using TwitchLib.Api.Core.Enums;
using TwitchLib.Api.Core.Exceptions;
using TwitchLib.Api.Core.Extensions.System;
using TwitchLib.Api.Core.Interfaces;
using TwitchLib.Api.Helix.Models.Clips.CreateClip;
using TwitchLib.Api.Helix.Models.Clips.GetClips;

namespace TwitchLib.Api.Helix
{
	public class Clips : ApiBase
	{
		public Clips(IApiSettings settings, IRateLimiter rateLimiter, IHttpCallHandler http)
			: base(settings, rateLimiter, http)
		{
		}

		public Task<GetClipsResponse> GetClipsAsync(List<string> clipIds = null, string gameId = null, string broadcasterId = null, string before = null, string after = null, DateTime? startedAt = null, DateTime? endedAt = null, int first = 20)
		{
			if (first < 0 || first > 100)
			{
				throw new BadParameterException("'first' must between 0 (inclusive) and 100 (inclusive).");
			}
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			if (clipIds != null)
			{
				foreach (string clipId in clipIds)
				{
					list.Add(new KeyValuePair<string, string>("id", clipId));
				}
			}
			if (gameId != null)
			{
				list.Add(new KeyValuePair<string, string>("game_id", gameId));
			}
			if (broadcasterId != null)
			{
				list.Add(new KeyValuePair<string, string>("broadcaster_id", broadcasterId));
			}
			if (list.Count != 1)
			{
				throw new BadParameterException("One of the following parameters must be set: clipId, gameId, broadcasterId. Only one is allowed to be set.");
			}
			if (!startedAt.HasValue && endedAt.HasValue)
			{
				throw new BadParameterException("The ended_at parameter cannot be used without the started_at parameter. Please include both parameters!");
			}
			if (startedAt.HasValue)
			{
				list.Add(new KeyValuePair<string, string>("started_at", startedAt.Value.ToRfc3339String()));
			}
			if (endedAt.HasValue)
			{
				list.Add(new KeyValuePair<string, string>("ended_at", endedAt.Value.ToRfc3339String()));
			}
			if (before != null)
			{
				list.Add(new KeyValuePair<string, string>("before", before));
			}
			if (after != null)
			{
				list.Add(new KeyValuePair<string, string>("after", after));
			}
			list.Add(new KeyValuePair<string, string>("first", first.ToString()));
			return TwitchGetGenericAsync<GetClipsResponse>("/clips", ApiVersion.Helix, list);
		}

		public Task<CreatedClipResponse> CreateClipAsync(string broadcasterId, string authToken = null)
		{
			DynamicScopeValidation(AuthScopes.Helix_Clips_Edit);
			List<KeyValuePair<string, string>> getParams = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("broadcaster_id", broadcasterId)
			};
			return TwitchPostGenericAsync<CreatedClipResponse>("/clips", ApiVersion.Helix, null, getParams, authToken);
		}
	}
}
