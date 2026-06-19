public struct ClientConnectionResult
{
	public enum Result
	{
		None = 0,
		Failed = 1,
		FailedVersionMismatch = 2,
		Connected = 3
	}

	public Result result;

	public bool isSuccess => result == Result.Connected;

	public static ClientConnectionResult Failed()
	{
		return new ClientConnectionResult
		{
			result = Result.Failed
		};
	}

	public static ClientConnectionResult FailedVersionMismatch()
	{
		return new ClientConnectionResult
		{
			result = Result.FailedVersionMismatch
		};
	}

	public static ClientConnectionResult Success()
	{
		return new ClientConnectionResult
		{
			result = Result.Connected
		};
	}
}
