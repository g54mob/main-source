using System.Threading;

public static class CTSUtility
{
	public static CancellationToken GenerateToken(ref CancellationTokenSource source)
	{
		source?.Cancel();
		source?.Dispose();
		source = new CancellationTokenSource();
		return source.Token;
	}

	public static void CancelToken(ref CancellationTokenSource source)
	{
		source?.Cancel();
		source?.Dispose();
		source = null;
	}
}
