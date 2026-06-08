using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public interface IListObjectsV2Paginator
	{
		IPaginatedEnumerable<ListObjectsV2Response> Responses { get; }

		IPaginatedEnumerable<S3Object> S3Objects { get; }

		IPaginatedEnumerable<string> CommonPrefixes { get; }
	}
}
