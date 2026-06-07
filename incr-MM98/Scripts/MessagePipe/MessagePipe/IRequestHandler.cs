namespace MessagePipe
{
	public interface IRequestHandler
	{
	}
	public interface IRequestHandler<in TRequest, out TResponse> : IRequestHandlerCore<TRequest, TResponse>, IRequestHandler
	{
	}
}
