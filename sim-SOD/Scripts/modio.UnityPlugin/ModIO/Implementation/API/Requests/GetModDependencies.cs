using System;
using ModIO.Implementation.API.Objects;

namespace ModIO.Implementation.API.Requests
{
	internal static class GetModDependencies
	{
		[Serializable]
		internal class ResponseSchema : PaginatedResponse<ModDependenciesObject>
		{
		}

		public static WebRequestConfig Request(long modId)
		{
			return null;
		}
	}
}
