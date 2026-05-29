namespace FuryStudios.FurySDK
{
	public delegate void AsyncRequestCallback(IAsyncRequest request);
	public delegate void AsyncRequestCallback<R>(IAsyncRequest<R> request);
}
