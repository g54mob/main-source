using System;
using ModIO.Implementation.API.Objects;

namespace ModIO.Implementation.API.Requests
{
	internal static class GetUserEvents
	{
		[Serializable]
		internal class ResponseSchema : PaginatedResponse<UserEventObject>
		{
		}

		public static WebRequestConfig Request(string filterUrl = null)
		{
			WebRequestConfig webRequestConfig = new WebRequestConfig
			{
				Url = string.Format("{0}{1}?game_id={2}", Settings.server.serverURL, "/me/events", Settings.server.gameId),
				RequestMethodType = "GET"
			};
			if (filterUrl != null)
			{
				webRequestConfig.Url += filterUrl;
			}
			return webRequestConfig;
		}
	}
}
