using System;
using System.Runtime.CompilerServices;

namespace MessagePipe
{
	internal sealed class MessageHandlerFilterRunner<T>
	{
		private readonly MessageHandlerFilter<T> filter;

		private readonly Action<T> next;

		public MessageHandlerFilterRunner(MessageHandlerFilter<T> filter, Action<T> next)
		{
			this.filter = filter;
			this.next = next;
		}

		public Action<T> GetDelegate()
		{
			return Handle;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void Handle(T message)
		{
			filter.Handle(message, next);
		}
	}
}
