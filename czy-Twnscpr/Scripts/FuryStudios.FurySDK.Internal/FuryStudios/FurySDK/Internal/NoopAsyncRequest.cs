namespace FuryStudios.FurySDK.Internal
{
	public class NoopAsyncRequest : AsyncRequest
	{
		public NoopAsyncRequest(PlatformFeature unsupportedFeature)
		{
		}

		public NoopAsyncRequest(string errorMessage)
		{
		}
	}
	public class NoopAsyncRequest<R> : AsyncRequest<R>
	{
		public NoopAsyncRequest(PlatformFeature unsupportedFeature)
		{
		}

		public NoopAsyncRequest(string errorMessage)
		{
		}
	}
}
