using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	internal sealed class ListObjectsV2Paginator : IPaginator<ListObjectsV2Response>, IListObjectsV2Paginator
	{
		private readonly IAmazonS3 _client;

		private readonly ListObjectsV2Request _request;

		private int _isPaginatorInUse;

		public IPaginatedEnumerable<ListObjectsV2Response> Responses => new PaginatedResponse<ListObjectsV2Response>(this);

		public IPaginatedEnumerable<S3Object> S3Objects => new PaginatedResultKeyResponse<ListObjectsV2Response, S3Object>(this, (ListObjectsV2Response i) => i.S3Objects ?? new List<S3Object>());

		public IPaginatedEnumerable<string> CommonPrefixes => new PaginatedResultKeyResponse<ListObjectsV2Response, string>(this, (ListObjectsV2Response i) => i.CommonPrefixes ?? new List<string>());

		internal ListObjectsV2Paginator(IAmazonS3 client, ListObjectsV2Request request)
		{
			_client = client;
			_request = request;
		}

		async IAsyncEnumerable<ListObjectsV2Response> IPaginator<ListObjectsV2Response>.PaginateAsync([EnumeratorCancellation] CancellationToken cancellationToken)
		{
			if (Interlocked.Exchange(ref _isPaginatorInUse, 1) != 0)
			{
				throw new InvalidOperationException("Paginator has already been consumed and cannot be reused. Please create a new instance.");
			}
			PaginatorUtils.SetUserAgentAdditionOnRequest(_request);
			string continuationToken = _request.ContinuationToken;
			ListObjectsV2Response response;
			do
			{
				_request.ContinuationToken = continuationToken;
				response = await _client.ListObjectsV2Async(_request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				continuationToken = response.NextContinuationToken;
				cancellationToken.ThrowIfCancellationRequested();
				yield return response;
			}
			while (response.IsTruncated == true);
		}
	}
}
