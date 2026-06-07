using System;

namespace MessagePipe
{
	public abstract class RequestHandlerFilter<TRequest, TResponse> : IRequestHandlerFilter, IMessagePipeFilter
	{
		public int Order { get; set; }

		public abstract TResponse Invoke(TRequest request, Func<TRequest, TResponse> next);
	}
}
