using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	internal sealed class ListBucketsPaginator : IPaginator<ListBucketsResponse>, IListBucketsPaginator
	{
		private readonly IAmazonS3 _client;

		private readonly ListBucketsRequest _request;

		private int _isPaginatorInUse;

		public IPaginatedEnumerable<ListBucketsResponse> Responses => new PaginatedResponse<ListBucketsResponse>(this);

		public IPaginatedEnumerable<S3Bucket> Buckets => new PaginatedResultKeyResponse<ListBucketsResponse, S3Bucket>(this, (ListBucketsResponse i) => i.Buckets ?? new List<S3Bucket>());

		internal ListBucketsPaginator(IAmazonS3 client, ListBucketsRequest request)
		{
			_client = client;
			_request = request;
		}

		async IAsyncEnumerable<ListBucketsResponse> IPaginator<ListBucketsResponse>.PaginateAsync([EnumeratorCancellation] CancellationToken cancellationToken)
		{
			if (Interlocked.Exchange(ref _isPaginatorInUse, 1) != 0)
			{
				throw new InvalidOperationException("Paginator has already been consumed and cannot be reused. Please create a new instance.");
			}
			PaginatorUtils.SetUserAgentAdditionOnRequest(_request);
			string continuationToken = _request.ContinuationToken;
			do
			{
				_request.ContinuationToken = continuationToken;
				ListBucketsResponse listBucketsResponse = await _client.ListBucketsAsync(_request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				continuationToken = listBucketsResponse.ContinuationToken;
				cancellationToken.ThrowIfCancellationRequested();
				yield return listBucketsResponse;
			}
			while (!string.IsNullOrEmpty(continuationToken));
		}
	}
}
