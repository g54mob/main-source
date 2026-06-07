using System;
using System.Runtime.CompilerServices;

namespace MessagePipe
{
	internal sealed class RequestHandlerFilterRunner<TRequest, TResponse>
	{
		private readonly RequestHandlerFilter<TRequest, TResponse> filter;

		private readonly Func<TRequest, TResponse> next;

		public RequestHandlerFilterRunner(RequestHandlerFilter<TRequest, TResponse> filter, Func<TRequest, TResponse> next)
		{
			this.filter = filter;
			this.next = next;
		}

		public Func<TRequest, TResponse> GetDelegate()
		{
			return Invoke;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private TResponse Invoke(TRequest request)
		{
			return filter.Invoke(request, next);
		}
	}
}
