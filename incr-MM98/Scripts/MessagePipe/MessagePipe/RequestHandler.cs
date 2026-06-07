using MessagePipe.Internal;

namespace MessagePipe
{
	[Preserve]
	public sealed class RequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>, IRequestHandlerCore<TRequest, TResponse>, IRequestHandler
	{
		private readonly IRequestHandlerCore<TRequest, TResponse> handler;

		[Preserve]
		public RequestHandler(IRequestHandlerCore<TRequest, TResponse> handler, FilterAttachedRequestHandlerFactory handlerFactory)
		{
			this.handler = handlerFactory.CreateRequestHandler(handler);
		}

		public TResponse Invoke(TRequest request)
		{
			return handler.Invoke(request);
		}
	}
}
