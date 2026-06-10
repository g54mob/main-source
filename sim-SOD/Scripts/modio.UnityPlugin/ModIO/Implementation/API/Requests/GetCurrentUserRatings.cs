using System;
using ModIO.Implementation.API.Objects;

namespace ModIO.Implementation.API.Requests
{
	internal static class GetCurrentUserRatings
	{
		[Serializable]
		internal class ResponseSchema : PaginatedResponse<RatingObject>
		{
		}

		public static WebRequestConfig Request()
		{
			return null;
		}
	}
}
