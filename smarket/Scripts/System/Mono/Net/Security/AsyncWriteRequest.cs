namespace Mono.Net.Security
{
	internal class AsyncWriteRequest : AsyncReadOrWriteRequest
	{
		public AsyncWriteRequest(MobileAuthenticatedStream parent, bool sync, byte[] buffer, int offset, int size)
			: base(null, sync: false, null, 0, 0)
		{
		}

		protected override AsyncOperationStatus Run(AsyncOperationStatus status)
		{
			return default(AsyncOperationStatus);
		}
	}
}
