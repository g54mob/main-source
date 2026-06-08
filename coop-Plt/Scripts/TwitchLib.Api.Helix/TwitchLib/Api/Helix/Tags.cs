using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitchLib.Api.Core;
using TwitchLib.Api.Core.Enums;
using TwitchLib.Api.Core.Interfaces;
using TwitchLib.Api.Helix.Models.Tags;

namespace TwitchLib.Api.Helix
{
	public class Tags : ApiBase
	{
		public Tags(IApiSettings settings, IRateLimiter rateLimiter, IHttpCallHandler http)
			: base(settings, rateLimiter, http)
		{
		}

		public Task<GetAllStreamTagsResponse> GetAllStreamTagsAsync(string after = null, int first = 20, List<string> tagIds = null, string accessToken = null)
		{
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			if (after != null)
			{
				list.Add(new KeyValuePair<string, string>("after", after));
			}
			if (first >= 0 && first <= 100)
			{
				list.Add(new KeyValuePair<string, string>("first", first.ToString()));
				if (tagIds != null && tagIds.Count > 0)
				{
					foreach (string tagId in tagIds)
					{
						list.Add(new KeyValuePair<string, string>("tag_id", tagId));
					}
				}
				return TwitchGetGenericAsync<GetAllStreamTagsResponse>("/tags/streams", ApiVersion.Helix, list, accessToken);
			}
			throw new ArgumentOutOfRangeException("first", "first value cannot exceed 100 and cannot be less than 1");
		}
	}
}
