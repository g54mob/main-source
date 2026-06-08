namespace Amazon.S3.Model
{
	public class S3PaginatorFactory : IS3PaginatorFactory
	{
		private readonly IAmazonS3 _client;

		internal S3PaginatorFactory(IAmazonS3 client)
		{
			_client = client;
		}

		public IListMultipartUploadsPaginator ListMultipartUploads(ListMultipartUploadsRequest request)
		{
			return new ListMultipartUploadsPaginator(_client, request);
		}

		public IListObjectsPaginator ListObjects(ListObjectsRequest request)
		{
			return new ListObjectsPaginator(_client, request);
		}

		public IListObjectsV2Paginator ListObjectsV2(ListObjectsV2Request request)
		{
			return new ListObjectsV2Paginator(_client, request);
		}

		public IListPartsPaginator ListParts(ListPartsRequest request)
		{
			return new ListPartsPaginator(_client, request);
		}

		public IListVersionsPaginator ListVersions(ListVersionsRequest request)
		{
			return new ListVersionsPaginator(_client, request);
		}

		public IListBucketsPaginator ListBuckets(ListBucketsRequest request)
		{
			return new ListBucketsPaginator(_client, request);
		}
	}
}
