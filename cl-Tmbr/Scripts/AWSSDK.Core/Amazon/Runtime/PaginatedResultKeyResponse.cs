using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Amazon.Runtime
{
	public class PaginatedResultKeyResponse<TResponse, TResultKey> : IPaginatedEnumerable<TResultKey>, IAsyncEnumerable<TResultKey>
	{
		private readonly IPaginator<TResponse> _paginator;

		private readonly Func<TResponse, IEnumerable<TResultKey>> _resultKeySelector;

		public PaginatedResultKeyResponse(IPaginator<TResponse> paginator, Func<TResponse, IEnumerable<TResultKey>> resultKeySelector)
		{
			_paginator = paginator;
			_resultKeySelector = resultKeySelector;
		}

		public async IAsyncEnumerator<TResultKey> GetAsyncEnumerator(CancellationToken cancellationToken = default(CancellationToken))
		{
			await foreach (TResponse item in _paginator.PaginateAsync().WithCancellation(cancellationToken).ConfigureAwait(continueOnCapturedContext: false))
			{
				foreach (TResultKey item2 in _resultKeySelector(item))
				{
					cancellationToken.ThrowIfCancellationRequested();
					yield return item2;
				}
			}
		}
	}
}
