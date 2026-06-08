using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	internal sealed class ListMultipartUploadsPaginator : IPaginator<ListMultipartUploadsResponse>, IListMultipartUploadsPaginator
	{
		private readonly IAmazonS3 _client;

		private readonly ListMultipartUploadsRequest _request;

		private int _isPaginatorInUse;

		public IPaginatedEnumerable<ListMultipartUploadsResponse> Responses => new PaginatedResponse<ListMultipartUploadsResponse>(this);

		public IPaginatedEnumerable<MultipartUpload> Uploads => new PaginatedResultKeyResponse<ListMultipartUploadsResponse, MultipartUpload>(this, (ListMultipartUploadsResponse i) => i.MultipartUploads ?? new List<MultipartUpload>());

		public IPaginatedEnumerable<string> CommonPrefixes => new PaginatedResultKeyResponse<ListMultipartUploadsResponse, string>(this, (ListMultipartUploadsResponse i) => i.CommonPrefixes ?? new List<string>());

		internal ListMultipartUploadsPaginator(IAmazonS3 client, ListMultipartUploadsRequest request)
		{
			_client = client;
			_request = request;
		}

		async IAsyncEnumerable<ListMultipartUploadsResponse> IPaginator<ListMultipartUploadsResponse>.PaginateAsync([EnumeratorCancellation] CancellationToken cancellationToken)
		{
			if (Interlocked.Exchange(ref _isPaginatorInUse, 1) != 0)
			{
				throw new InvalidOperationException("Paginator has already been consumed and cannot be reused. Please create a new instance.");
			}
			PaginatorUtils.SetUserAgentAdditionOnRequest(_request);
			string keyMarker = _request.KeyMarker;
			string uploadIdMarker = _request.UploadIdMarker;
			ListMultipartUploadsResponse response;
			do
			{
				_request.KeyMarker = keyMarker;
				_request.UploadIdMarker = uploadIdMarker;
				response = await _client.ListMultipartUploadsAsync(_request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				keyMarker = response.NextKeyMarker;
				uploadIdMarker = response.NextUploadIdMarker;
				cancellationToken.ThrowIfCancellationRequested();
				yield return response;
			}
			while (response.IsTruncated == true);
		}
	}
}
