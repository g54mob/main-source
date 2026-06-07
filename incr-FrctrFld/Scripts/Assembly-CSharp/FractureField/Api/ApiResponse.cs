using System;

namespace FractureField.Api
{
	public class ApiResponse
	{
		public bool Success { get; set; }

		public ApiError Error { get; set; }

		public DateTime Timestamp { get; set; }
	}
	public class ApiResponse<T> : ApiResponse
	{
		public T Data { get; set; }

		public static ApiResponse<T> CreateError(ApiError error)
		{
			return null;
		}
	}
}
