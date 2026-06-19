namespace ModIO.Implementation
{
	internal static class ResultBuilder
	{
		public static readonly Result Success = new Result
		{
			code = 0u
		};

		public static readonly Result Unknown = new Result
		{
			code = 1u
		};

		public static Result Create(uint resultCode, uint apiCode = 0u)
		{
			return new Result
			{
				code = resultCode,
				code_api = apiCode
			};
		}
	}
}
