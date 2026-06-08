using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public interface IListPartsPaginator
	{
		IPaginatedEnumerable<ListPartsResponse> Responses { get; }

		IPaginatedEnumerable<PartDetail> Parts { get; }
	}
}
