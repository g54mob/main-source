using System;
using ModIO.Implementation.API.Objects;

namespace ModIO.Implementation.API.Requests
{
	internal static class GetCurrentUserCreations
	{
		[Serializable]
		internal class ResponseSchema : PaginatedResponse<ModObject>
		{
		}

		public static WebRequestConfig Request(SearchFilter searchFilter = null)
		{
			string text = string.Empty;
			if (searchFilter != null)
			{
				text = FilterUtil.ConvertToURL(searchFilter);
			}
			WebRequestConfig webRequestConfig = new WebRequestConfig();
			webRequestConfig.Url = string.Format("{0}{1}?{2}{3}{4}", Settings.server.serverURL, "/me/mods", text, "&game_id=", Settings.server.gameId);
			webRequestConfig.RequestMethodType = "GET";
			return webRequestConfig;
		}
	}
}
