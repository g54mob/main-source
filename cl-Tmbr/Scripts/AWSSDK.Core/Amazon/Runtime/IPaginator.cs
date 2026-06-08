using System.Collections.Generic;
using System.Threading;

namespace Amazon.Runtime
{
	public interface IPaginator<TResponse>
	{
		IAsyncEnumerable<TResponse> PaginateAsync(CancellationToken cancellationToken = default(CancellationToken));
	}
}
