using ModIO.Implementation.API.Objects;

namespace ModIO.Implementation.API.Requests
{
	internal static class GetModComments
	{
		public class ResponseSchema : PaginatedResponse<ModCommentObject>
		{
		}

		public static WebRequestConfig RequestPaginated(long modId, SearchFilter searchFilter)
		{
			return new WebRequestConfig
			{
				Url = PaginatedURL(modId, searchFilter),
				RequestMethodType = "GET"
			};
		}

		private static string Url(long modId)
		{
			return string.Format("{0}{1}{2}{3}{4}/comments?", Settings.server.serverURL, "/games/", Settings.server.gameId, "/mods/", modId);
		}

		public static string UnpaginatedURL(long modId, SearchFilter filter)
		{
			return Url(modId) + FilterUtil.ConvertToURL(filter);
		}

		public static string PaginatedURL(long modId, SearchFilter filter)
		{
			return FilterUtil.AddPagination(filter, UnpaginatedURL(modId, filter));
		}
	}
}
