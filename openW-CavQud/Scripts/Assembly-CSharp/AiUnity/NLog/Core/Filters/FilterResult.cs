namespace AiUnity.NLog.Core.Filters
{
	public enum FilterResult
	{
		Neutral = 0,
		Log = 1,
		Ignore = 2,
		LogFinal = 3,
		IgnoreFinal = 4
	}
}
