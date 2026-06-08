using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Amazon.Runtime
{
	public class PaginatedResponse<TResponse> : IPaginatedEnumerable<TResponse>, IAsyncEnumerable<TResponse>
	{
		private readonly IPaginator<TResponse> _paginator;

		public PaginatedResponse(IPaginator<TResponse> paginator)
		{
			_paginator = paginator;
		}

		public async IAsyncEnumerator<TResponse> GetAsyncEnumerator(CancellationToken cancellationToken = default(CancellationToken))
		{
			await foreach (TResponse item in _paginator.PaginateAsync().WithCancellation(cancellationToken).ConfigureAwait(continueOnCapturedContext: false))
			{
				cancellationToken.ThrowIfCancellationRequested();
				yield return item;
			}
		}
	}
}
