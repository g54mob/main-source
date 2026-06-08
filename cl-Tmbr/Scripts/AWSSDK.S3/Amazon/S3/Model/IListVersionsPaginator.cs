using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public interface IListVersionsPaginator
	{
		IPaginatedEnumerable<ListVersionsResponse> Responses { get; }

		IPaginatedEnumerable<S3ObjectVersion> Versions { get; }

		IPaginatedEnumerable<string> CommonPrefixes { get; }
	}
}
