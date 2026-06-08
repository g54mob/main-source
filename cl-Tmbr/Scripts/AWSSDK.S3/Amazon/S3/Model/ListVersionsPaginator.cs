using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	internal sealed class ListVersionsPaginator : IPaginator<ListVersionsResponse>, IListVersionsPaginator
	{
		private readonly IAmazonS3 _client;

		private readonly ListVersionsRequest _request;

		private int _isPaginatorInUse;

		public IPaginatedEnumerable<ListVersionsResponse> Responses => new PaginatedResponse<ListVersionsResponse>(this);

		public IPaginatedEnumerable<S3ObjectVersion> Versions => new PaginatedResultKeyResponse<ListVersionsResponse, S3ObjectVersion>(this, (ListVersionsResponse i) => i.Versions ?? new List<S3ObjectVersion>());

		public IPaginatedEnumerable<string> CommonPrefixes => new PaginatedResultKeyResponse<ListVersionsResponse, string>(this, (ListVersionsResponse i) => i.CommonPrefixes ?? new List<string>());

		internal ListVersionsPaginator(IAmazonS3 client, ListVersionsRequest request)
		{
			_client = client;
			_request = request;
		}

		async IAsyncEnumerable<ListVersionsResponse> IPaginator<ListVersionsResponse>.PaginateAsync([EnumeratorCancellation] CancellationToken cancellationToken)
		{
			if (Interlocked.Exchange(ref _isPaginatorInUse, 1) != 0)
			{
				throw new InvalidOperationException("Paginator has already been consumed and cannot be reused. Please create a new instance.");
			}
			PaginatorUtils.SetUserAgentAdditionOnRequest(_request);
			string keyMarker = _request.KeyMarker;
			string versionIdMarker = _request.VersionIdMarker;
			ListVersionsResponse response;
			do
			{
				_request.KeyMarker = keyMarker;
				_request.VersionIdMarker = versionIdMarker;
				response = await _client.ListVersionsAsync(_request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				keyMarker = response.NextKeyMarker;
				versionIdMarker = response.NextVersionIdMarker;
				cancellationToken.ThrowIfCancellationRequested();
				yield return response;
			}
			while (response.IsTruncated == true);
		}
	}
}
