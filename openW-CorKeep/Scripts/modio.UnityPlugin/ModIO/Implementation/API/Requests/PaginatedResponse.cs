using System;

namespace ModIO.Implementation.API.Requests
{
	[Serializable]
	internal class PaginatedResponse<T>
	{
		public T[] data;

		public long result_total;

		public long result_limit;

		public long result_offset;

		public long result_count;
	}
}
