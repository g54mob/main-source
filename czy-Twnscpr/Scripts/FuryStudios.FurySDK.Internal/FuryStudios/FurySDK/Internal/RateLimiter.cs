namespace FuryStudios.FurySDK.Internal
{
	public class RateLimiter<T> where T : ILimitedResource
	{
		private class CounterElement
		{
		}

		private class RequestElement
		{
		}

		private class DummyRequest : AsyncRequest
		{
		}
	}
}
