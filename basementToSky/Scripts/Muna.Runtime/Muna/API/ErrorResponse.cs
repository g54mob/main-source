namespace Muna.API
{
	[Preserve]
	public sealed class ErrorResponse
	{
		public sealed class Error
		{
			public string message;
		}

		public Error[] errors;
	}
}
