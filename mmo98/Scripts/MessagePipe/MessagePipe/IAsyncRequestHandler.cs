namespace MessagePipe
{
	public interface IAsyncRequestHandler
	{
	}
	public interface IAsyncRequestHandler<in TRequest, TResponse> : IAsyncRequestHandlerCore<TRequest, TResponse>, IAsyncRequestHandler
	{
	}
}
