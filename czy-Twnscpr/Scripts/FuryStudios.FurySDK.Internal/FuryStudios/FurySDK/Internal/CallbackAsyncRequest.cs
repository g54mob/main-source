namespace FuryStudios.FurySDK.Internal
{
	public class CallbackAsyncRequest : AsyncRequest
	{
	}
	public class CallbackAsyncRequest<R> : AsyncRequest
	{
		protected AsyncRequestCallback<R> callback;

		protected IAsyncRequest<R> parent;

		public override bool ExecuteIfPreviousFailed => false;

		public CallbackAsyncRequest(AsyncRequestCallback<R> callback, IAsyncRequest<R> parent)
		{
		}

		protected override void OnStarted()
		{
		}
	}
}
