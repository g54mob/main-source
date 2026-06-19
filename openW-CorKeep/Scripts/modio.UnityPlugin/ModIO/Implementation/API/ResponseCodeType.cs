namespace ModIO.Implementation.API
{
	internal enum ResponseCodeType
	{
		ProcessingError = 0,
		NetworkError = 1,
		HttpError = 2,
		Succeeded = 3,
		AbortRequested = 4,
		TimedOut = 5
	}
}
