namespace Mono.Net.Security
{
	internal class AsyncReadRequest : AsyncReadOrWriteRequest
	{
		public AsyncReadRequest(MobileAuthenticatedStream parent, bool sync, byte[] buffer, int offset, int size)
			: base(null, sync: false, null, 0, 0)
		{
		}

		protected override AsyncOperationStatus Run(AsyncOperationStatus status)
		{
			return default(AsyncOperationStatus);
		}
	}
}
