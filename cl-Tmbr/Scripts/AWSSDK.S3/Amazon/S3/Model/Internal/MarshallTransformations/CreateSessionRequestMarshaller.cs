using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class CreateSessionRequestMarshaller : IMarshaller<IRequest, CreateSessionRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static CreateSessionRequestMarshaller _instance = new CreateSessionRequestMarshaller();

		public static CreateSessionRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new CreateSessionRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((CreateSessionRequest)input);
		}

		public IRequest Marshall(CreateSessionRequest publicRequest)
		{
			DefaultRequest defaultRequest = new DefaultRequest(publicRequest, "Amazon.S3");
			defaultRequest.HttpMethod = "GET";
			defaultRequest.AddSubResource("session");
			if (!publicRequest.IsSetBucketName())
			{
				throw new AmazonS3Exception("Request object does not have required field BucketName set");
			}
			if (publicRequest.IsSetSessionMode())
			{
				defaultRequest.Headers["x-amz-create-session-mode"] = publicRequest.SessionMode;
			}
			if (publicRequest.IsSetServerSideEncryptionMethod())
			{
				defaultRequest.Headers["x-amz-server-side-encryption"] = publicRequest.ServerSideEncryption;
			}
			if (publicRequest.IsSetSSEKMSKeyId())
			{
				defaultRequest.Headers["x-amz-server-side-encryption-aws-kms-key-id"] = publicRequest.SSEKMSKeyId;
			}
			if (publicRequest.IsSetSSEKMSEncryptionContext())
			{
				defaultRequest.Headers["x-amz-server-side-encryption-context"] = publicRequest.SSEKMSEncryptionContext;
			}
			if (publicRequest.IsSetBucketKeyEnabled())
			{
				defaultRequest.Headers["x-amz-server-side-encryption-bucket-key-enabled"] = S3Transforms.ToStringValue(publicRequest.BucketKeyEnabled.Value);
			}
			defaultRequest.AddPathResource("{Bucket}", StringUtils.FromString(publicRequest.BucketName));
			defaultRequest.ResourcePath = "/{Bucket}";
			return defaultRequest;
		}

		internal static CreateSessionRequestMarshaller GetInstance()
		{
			return _instance;
		}
	}
}
