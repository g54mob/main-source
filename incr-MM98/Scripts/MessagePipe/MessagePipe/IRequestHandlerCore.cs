namespace MessagePipe
{
	public interface IRequestHandlerCore<in TRequest, out TResponse> : IRequestHandler
	{
		TResponse Invoke(TRequest request);
	}
}
