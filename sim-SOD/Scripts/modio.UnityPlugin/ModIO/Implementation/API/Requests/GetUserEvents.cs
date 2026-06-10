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
			return null;
		}
	}
}
