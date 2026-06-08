using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetBucketAclRequestMarshaller : IMarshaller<IRequest, GetBucketAclRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static GetBucketAclRequestMarshaller _instance = new GetBucketAclRequestMarshaller();

		public static GetBucketAclRequestMarshaller Instance => _instance;

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((GetBucketAclRequest)input);
		}

		public IRequest Marshall(GetBucketAclRequest publicRequest)
		{
			DefaultRequest defaultRequest = new DefaultRequest(publicRequest, "Amazon.S3");
			defaultRequest.HttpMethod = "GET";
			defaultRequest.AddSubResource("acl");
			if (publicRequest.IsSetExpectedBucketOwner())
			{
				defaultRequest.Headers["x-amz-expected-bucket-owner"] = publicRequest.ExpectedBucketOwner;
			}
			if (!publicRequest.IsSetBucketName())
			{
				throw new AmazonS3Exception("Request object does not have required field BucketName set");
			}
			return defaultRequest;
		}

		internal static GetBucketAclRequestMarshaller GetInstance()
		{
			return _instance;
		}
	}
}
