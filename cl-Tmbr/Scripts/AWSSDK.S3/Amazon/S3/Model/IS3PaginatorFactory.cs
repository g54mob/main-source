namespace Amazon.S3.Model
{
	public interface IS3PaginatorFactory
	{
		IListMultipartUploadsPaginator ListMultipartUploads(ListMultipartUploadsRequest request);

		IListObjectsPaginator ListObjects(ListObjectsRequest request);

		IListObjectsV2Paginator ListObjectsV2(ListObjectsV2Request request);

		IListPartsPaginator ListParts(ListPartsRequest request);

		IListVersionsPaginator ListVersions(ListVersionsRequest request);

		IListBucketsPaginator ListBuckets(ListBucketsRequest request);
	}
}
