namespace ModIO.Implementation
{
	internal static class ResultAnd
	{
		public static ResultAnd<U> Create<U>(Result result, U value)
		{
			return new ResultAnd<U>
			{
				result = result,
				value = value
			};
		}

		public static ResultAnd<U> Create<U>(uint result, U value)
		{
			return new ResultAnd<U>
			{
				result = ResultBuilder.Create(result),
				value = value
			};
		}
	}
}
