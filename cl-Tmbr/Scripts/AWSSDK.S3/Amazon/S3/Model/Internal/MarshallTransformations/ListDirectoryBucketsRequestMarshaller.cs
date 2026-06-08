using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class ListDirectoryBucketsRequestMarshaller : IMarshaller<IRequest, ListDirectoryBucketsRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static ListDirectoryBucketsRequestMarshaller _instance = new ListDirectoryBucketsRequestMarshaller();

		public static ListDirectoryBucketsRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new ListDirectoryBucketsRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((ListDirectoryBucketsRequest)input);
		}

		public IRequest Marshall(ListDirectoryBucketsRequest publicRequest)
		{
			DefaultRequest defaultRequest = new DefaultRequest(publicRequest, "Amazon.S3");
			defaultRequest.HttpMethod = "GET";
			if (publicRequest.IsSetContinuationToken())
			{
				defaultRequest.Parameters.Add("continuation-token", StringUtils.FromString(publicRequest.ContinuationToken));
			}
			if (publicRequest.IsSetMaxDirectoryBuckets())
			{
				defaultRequest.Parameters.Add("max-directory-buckets", StringUtils.FromInt(publicRequest.MaxDirectoryBuckets));
			}
			defaultRequest.ResourcePath = "/";
			defaultRequest.UseQueryString = true;
			return defaultRequest;
		}

		internal static ListDirectoryBucketsRequestMarshaller GetInstance()
		{
			return _instance;
		}
	}
}
