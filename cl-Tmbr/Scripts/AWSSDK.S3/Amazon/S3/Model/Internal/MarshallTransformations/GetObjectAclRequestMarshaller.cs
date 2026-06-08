using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetObjectAclRequestMarshaller : IMarshaller<IRequest, GetObjectAclRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static GetObjectAclRequestMarshaller _instance = new GetObjectAclRequestMarshaller();

		public static GetObjectAclRequestMarshaller Instance => _instance;

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((GetObjectAclRequest)input);
		}

		public IRequest Marshall(GetObjectAclRequest publicRequest)
		{
			DefaultRequest defaultRequest = new DefaultRequest(publicRequest, "Amazon.S3");
			defaultRequest.HttpMethod = "GET";
			defaultRequest.AddSubResource("acl");
			if (publicRequest.IsSetExpectedBucketOwner())
			{
				defaultRequest.Headers["x-amz-expected-bucket-owner"] = publicRequest.ExpectedBucketOwner;
			}
			if (publicRequest.IsSetRequestPayer())
			{
				defaultRequest.Headers["x-amz-request-payer"] = publicRequest.RequestPayer;
			}
			if (!publicRequest.IsSetBucketName())
			{
				throw new AmazonS3Exception("Request object does not have required field BucketName set");
			}
			if (!publicRequest.IsSetKey())
			{
				throw new AmazonS3Exception("Request object does not have required field Key set");
			}
			defaultRequest.AddPathResource("{Key+}", StringUtils.FromString(publicRequest.Key.TrimStart(new char[1] { '/' })));
			if (publicRequest.IsSetVersionId())
			{
				defaultRequest.Parameters.Add("versionId", StringUtils.FromString(publicRequest.VersionId));
			}
			defaultRequest.ResourcePath = "/{Key+}";
			defaultRequest.UseQueryString = true;
			return defaultRequest;
		}

		internal static GetObjectAclRequestMarshaller GetInstance()
		{
			return _instance;
		}
	}
}
