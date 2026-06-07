using System;

namespace FractureField.Api
{
	public class ApiError
	{
		public string Code { get; set; }

		public string Message { get; set; }

		public string Details { get; set; }

		public DateTime Timestamp { get; set; }
	}
}
