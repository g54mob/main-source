using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public interface IListMultipartUploadsPaginator
	{
		IPaginatedEnumerable<ListMultipartUploadsResponse> Responses { get; }

		IPaginatedEnumerable<MultipartUpload> Uploads { get; }

		IPaginatedEnumerable<string> CommonPrefixes { get; }
	}
}
