using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	internal sealed class ListObjectsPaginator : IPaginator<ListObjectsResponse>, IListObjectsPaginator
	{
		private readonly IAmazonS3 _client;

		private readonly ListObjectsRequest _request;

		private int _isPaginatorInUse;

		public IPaginatedEnumerable<ListObjectsResponse> Responses => new PaginatedResponse<ListObjectsResponse>(this);

		public IPaginatedEnumerable<S3Object> S3Objects => new PaginatedResultKeyResponse<ListObjectsResponse, S3Object>(this, (ListObjectsResponse i) => i.S3Objects ?? new List<S3Object>());

		public IPaginatedEnumerable<string> CommonPrefixes => new PaginatedResultKeyResponse<ListObjectsResponse, string>(this, (ListObjectsResponse i) => i.CommonPrefixes ?? new List<string>());

		internal ListObjectsPaginator(IAmazonS3 client, ListObjectsRequest request)
		{
			_client = client;
			_request = request;
		}

		async IAsyncEnumerable<ListObjectsResponse> IPaginator<ListObjectsResponse>.PaginateAsync([EnumeratorCancellation] CancellationToken cancellationToken)
		{
			if (Interlocked.Exchange(ref _isPaginatorInUse, 1) != 0)
			{
				throw new InvalidOperationException("Paginator has already been consumed and cannot be reused. Please create a new instance.");
			}
			PaginatorUtils.SetUserAgentAdditionOnRequest(_request);
			string marker = _request.Marker;
			ListObjectsResponse response;
			do
			{
				_request.Marker = marker;
				response = await _client.ListObjectsAsync(_request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				marker = response.NextMarker;
				cancellationToken.ThrowIfCancellationRequested();
				yield return response;
			}
			while (response.IsTruncated == true);
		}
	}
}
