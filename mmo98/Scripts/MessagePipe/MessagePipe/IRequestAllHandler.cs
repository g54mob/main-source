using System.Collections.Generic;

namespace MessagePipe
{
	public interface IRequestAllHandler<in TRequest, out TResponse>
	{
		TResponse[] InvokeAll(TRequest request);

		IEnumerable<TResponse> InvokeAllLazy(TRequest request);
	}
}
