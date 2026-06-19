using System;
using ModIO.Implementation.API.Objects;

namespace ModIO.Implementation.API.Requests
{
	internal static class GetMods
	{
		[Serializable]
		public class ResponseSchema : PaginatedResponse<ModObject>
		{
		}

		private static string Url => string.Format("{0}{1}{2}{3}?", Settings.server.serverURL, "/games/", Settings.server.gameId, "/mods");

		public static WebRequestConfig RequestPaginated(SearchFilter searchFilter)
		{
			return new WebRequestConfig
			{
				Url = PaginatedURL(searchFilter),
				RequestMethodType = "GET"
			};
		}

		public static string UnpaginatedURL(SearchFilter filter)
		{
			return Url + FilterUtil.ConvertToURL(filter);
		}

		public static string PaginatedURL(SearchFilter filter)
		{
			return FilterUtil.AddPagination(filter, UnpaginatedURL(filter));
		}
	}
}
