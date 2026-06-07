namespace FuryStudios.FurySDK.Internal
{
	internal class CompletedAsyncRequest : AsyncRequest
	{
		protected override void OnStarted()
		{
		}
	}
	internal class CompletedAsyncRequest<R> : AsyncRequest<R>
	{
	}
}
