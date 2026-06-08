using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	internal sealed class ListPartsPaginator : IPaginator<ListPartsResponse>, IListPartsPaginator
	{
		private readonly IAmazonS3 _client;

		private readonly ListPartsRequest _request;

		private int _isPaginatorInUse;

		public IPaginatedEnumerable<ListPartsResponse> Responses => new PaginatedResponse<ListPartsResponse>(this);

		public IPaginatedEnumerable<PartDetail> Parts => new PaginatedResultKeyResponse<ListPartsResponse, PartDetail>(this, (ListPartsResponse i) => i.Parts ?? new List<PartDetail>());

		internal ListPartsPaginator(IAmazonS3 client, ListPartsRequest request)
		{
			_client = client;
			_request = request;
		}

		async IAsyncEnumerable<ListPartsResponse> IPaginator<ListPartsResponse>.PaginateAsync([EnumeratorCancellation] CancellationToken cancellationToken)
		{
			if (Interlocked.Exchange(ref _isPaginatorInUse, 1) != 0)
			{
				throw new InvalidOperationException("Paginator has already been consumed and cannot be reused. Please create a new instance.");
			}
			PaginatorUtils.SetUserAgentAdditionOnRequest(_request);
			string partNumberMarker = _request.PartNumberMarker;
			ListPartsResponse response;
			do
			{
				_request.PartNumberMarker = partNumberMarker;
				response = await _client.ListPartsAsync(_request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				partNumberMarker = response.NextPartNumberMarker.ToString();
				cancellationToken.ThrowIfCancellationRequested();
				yield return response;
			}
			while (response.IsTruncated == true);
		}
	}
}
