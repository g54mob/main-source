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
			return null;
		}
	}
}
