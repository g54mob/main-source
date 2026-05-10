namespace Mono.Net.Security
{
	internal class AsyncHandshakeRequest : AsyncProtocolRequest
	{
		public AsyncHandshakeRequest(MobileAuthenticatedStream parent, bool sync)
			: base(null, sync: false)
		{
		}

		protected override AsyncOperationStatus Run(AsyncOperationStatus status)
		{
			return default(AsyncOperationStatus);
		}
	}
}
