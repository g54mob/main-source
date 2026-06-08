using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetBucketEncryptionRequestMarshaller : IMarshaller<IRequest, GetBucketEncryptionRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static GetBucketEncryptionRequestMarshaller _instance;

		public static GetBucketEncryptionRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GetBucketEncryptionRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((GetBucketEncryptionRequest)input);
		}

		public IRequest Marshall(GetBucketEncryptionRequest getEncryptionRequest)
		{
			IRequest request = new DefaultRequest(getEncryptionRequest, "AmazonS3");
			request.Suppress404Exceptions = true;
			request.HttpMethod = "GET";
			if (getEncryptionRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(getEncryptionRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(getEncryptionRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "GetBucketEncryptionRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("encryption");
			request.UseQueryString = true;
			return request;
		}
	}
}
