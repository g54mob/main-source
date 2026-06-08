using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public interface IListObjectsPaginator
	{
		IPaginatedEnumerable<ListObjectsResponse> Responses { get; }

		IPaginatedEnumerable<S3Object> S3Objects { get; }

		IPaginatedEnumerable<string> CommonPrefixes { get; }
	}
}
