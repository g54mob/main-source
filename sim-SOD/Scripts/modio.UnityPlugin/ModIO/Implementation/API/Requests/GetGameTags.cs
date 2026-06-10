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
			return null;
		}
	}
}
