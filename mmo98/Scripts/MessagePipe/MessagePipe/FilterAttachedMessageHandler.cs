using System;
using System.Collections.Generic;
using System.Linq;

namespace MessagePipe
{
	internal sealed class FilterAttachedMessageHandler<T> : IMessageHandler<T>
	{
		private Action<T> handler;

		public FilterAttachedMessageHandler(IMessageHandler<T> body, IEnumerable<MessageHandlerFilter<T>> filters)
		{
			Action<T> next = body.Handle;
			foreach (MessageHandlerFilter<T> item in filters.OrderByDescending((MessageHandlerFilter<T> x) => x.Order))
			{
				next = new MessageHandlerFilterRunner<T>(item, next).GetDelegate();
			}
			handler = next;
		}

		public void Handle(T message)
		{
			handler(message);
		}
	}
}
