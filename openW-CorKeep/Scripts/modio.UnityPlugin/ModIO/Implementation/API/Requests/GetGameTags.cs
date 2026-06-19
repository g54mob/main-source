using System;
using ModIO.Implementation.API.Objects;

namespace ModIO.Implementation.API.Requests
{
	internal static class GetGameTags
	{
		[Serializable]
		public class ResponseSchema : PaginatedResponse<GameTagOptionObject>
		{
		}

		public static WebRequestConfig Request()
		{
			WebRequestConfig webRequestConfig = new WebRequestConfig();
			webRequestConfig.Url = string.Format("{0}{1}{2}{3}?show_hidden_tags=true", Settings.server.serverURL, "/games/", Settings.server.gameId, "/tags");
			webRequestConfig.RequestMethodType = "GET";
			return webRequestConfig;
		}
	}
}
