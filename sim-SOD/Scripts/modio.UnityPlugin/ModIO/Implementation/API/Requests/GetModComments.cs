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
			return null;
		}

		private static string Url(long modId)
		{
			return null;
		}

		public static string UnpaginatedURL(long modId, SearchFilter filter)
		{
			return null;
		}

		public static string PaginatedURL(long modId, SearchFilter filter)
		{
			return null;
		}
	}
}
