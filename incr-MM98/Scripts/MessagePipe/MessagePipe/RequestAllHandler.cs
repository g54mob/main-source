using System.Collections.Generic;
using System.Linq;
using MessagePipe.Internal;

namespace MessagePipe
{
	[Preserve]
	public sealed class RequestAllHandler<TRequest, TResponse> : IRequestAllHandler<TRequest, TResponse>
	{
		private readonly IRequestHandlerCore<TRequest, TResponse>[] handlers;

		[Preserve]
		public RequestAllHandler(IEnumerable<IRequestHandlerCore<TRequest, TResponse>> handlers, FilterAttachedRequestHandlerFactory handlerFactory)
		{
			ICollection<IRequestHandlerCore<TRequest, TResponse>> obj = (handlers as ICollection<IRequestHandlerCore<TRequest, TResponse>>) ?? handlers.ToArray();
			IRequestHandlerCore<TRequest, TResponse>[] array = new IRequestHandlerCore<TRequest, TResponse>[obj.Count];
			int num = 0;
			foreach (IRequestHandlerCore<TRequest, TResponse> item in obj)
			{
				array[num++] = handlerFactory.CreateRequestHandler(item);
			}
			this.handlers = array;
		}

		public TResponse[] InvokeAll(TRequest request)
		{
			TResponse[] array = new TResponse[handlers.Length];
			for (int i = 0; i < handlers.Length; i++)
			{
				array[i] = handlers[i].Invoke(request);
			}
			return array;
		}

		public IEnumerable<TResponse> InvokeAllLazy(TRequest request)
		{
			for (int i = 0; i < handlers.Length; i++)
			{
				yield return handlers[i].Invoke(request);
			}
		}
	}
}
