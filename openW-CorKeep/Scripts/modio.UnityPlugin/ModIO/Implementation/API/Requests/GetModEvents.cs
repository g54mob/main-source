using System;
using ModIO.Implementation.API.Objects;

namespace ModIO.Implementation.API.Requests
{
	internal static class GetModEvents
	{
		[Serializable]
		internal class ResponseSchema : PaginatedResponse<ModEventObject>
		{
		}

		public static WebRequestConfig Request(string paginationUrl = null)
		{
			WebRequestConfig webRequestConfig = new WebRequestConfig();
			webRequestConfig.Url = string.Format("{0}{1}{2}{3}?", Settings.server.serverURL, "/games/", Settings.server.gameId, "/mods/events");
			webRequestConfig.RequestMethodType = "GET";
			WebRequestConfig webRequestConfig2 = webRequestConfig;
			if (paginationUrl != null)
			{
				webRequestConfig2.Url += paginationUrl;
			}
			return webRequestConfig2;
		}
	}
}
