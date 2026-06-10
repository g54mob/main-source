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

		private static string Url => null;

		public static WebRequestConfig RequestPaginated(SearchFilter searchFilter)
		{
			return null;
		}

		public static string UnpaginatedURL(SearchFilter filter)
		{
			return null;
		}

		public static string PaginatedURL(SearchFilter filter)
		{
			return null;
		}
	}
}
