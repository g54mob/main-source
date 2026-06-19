using System;
using ModIO.Implementation.API.Objects;

namespace ModIO.Implementation.API.Requests
{
	internal static class GetUserSubscriptions
	{
		[Serializable]
		internal class ResponseSchema : PaginatedResponse<ModObject>
		{
		}

		public static WebRequestConfig Request(SearchFilter searchFilter = null)
		{
			string text = ((searchFilter == null) ? "" : FilterUtil.ConvertToURL(searchFilter));
			WebRequestConfig webRequestConfig = new WebRequestConfig();
			webRequestConfig.Url = string.Format("{0}{1}game_id={2}{3}", Settings.server.serverURL, "/me/subscribed?", Settings.server.gameId, text);
			webRequestConfig.RequestMethodType = "GET";
			return webRequestConfig;
		}
	}
}
