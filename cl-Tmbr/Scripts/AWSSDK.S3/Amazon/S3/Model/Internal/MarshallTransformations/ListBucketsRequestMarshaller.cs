using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class ListBucketsRequestMarshaller : IMarshaller<IRequest, ListBucketsRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static ListBucketsRequestMarshaller _instance;

		public static ListBucketsRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new ListBucketsRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((ListBucketsRequest)input);
		}

		public IRequest Marshall(ListBucketsRequest listBucketsRequest)
		{
			IRequest request = new DefaultRequest(listBucketsRequest, "AmazonS3");
			request.HttpMethod = "GET";
			if (listBucketsRequest.IsSetContinuationToken())
			{
				request.Parameters.Add("continuation-token", StringUtils.FromString(listBucketsRequest.ContinuationToken));
			}
			if (listBucketsRequest.IsSetMaxBuckets())
			{
				request.Parameters.Add("max-buckets", StringUtils.FromInt(listBucketsRequest.MaxBuckets));
			}
			if (listBucketsRequest.IsSetPrefix())
			{
				request.Parameters.Add("prefix", StringUtils.FromString(listBucketsRequest.Prefix));
			}
			if (listBucketsRequest.IsSetBucketRegion())
			{
				request.Parameters.Add("bucket-region", StringUtils.FromString(listBucketsRequest.BucketRegion));
			}
			request.ResourcePath = "/";
			request.UseQueryString = true;
			return request;
		}
	}
}
