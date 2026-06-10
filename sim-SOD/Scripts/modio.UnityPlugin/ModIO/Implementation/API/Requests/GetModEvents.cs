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
			return null;
		}
	}
}
