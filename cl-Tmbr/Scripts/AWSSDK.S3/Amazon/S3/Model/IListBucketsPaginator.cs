using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public interface IListBucketsPaginator
	{
		IPaginatedEnumerable<ListBucketsResponse> Responses { get; }

		IPaginatedEnumerable<S3Bucket> Buckets { get; }
	}
}
