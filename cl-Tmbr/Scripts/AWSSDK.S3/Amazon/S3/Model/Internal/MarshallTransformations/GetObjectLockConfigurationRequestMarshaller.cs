using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetObjectLockConfigurationRequestMarshaller : IMarshaller<IRequest, GetObjectLockConfigurationRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static GetObjectLockConfigurationRequestMarshaller _instance;

		public static GetObjectLockConfigurationRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GetObjectLockConfigurationRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((GetObjectLockConfigurationRequest)input);
		}

		public IRequest Marshall(GetObjectLockConfigurationRequest publicRequest)
		{
			DefaultRequest defaultRequest = new DefaultRequest(publicRequest, "AmazonS3");
			defaultRequest.HttpMethod = "GET";
			if (publicRequest.IsSetExpectedBucketOwner())
			{
				defaultRequest.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(publicRequest.ExpectedBucketOwner));
			}
			string resourcePath = "/";
			defaultRequest.AddSubResource("object-lock");
			if (!publicRequest.IsSetBucketName())
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "publicRequest.BucketName");
			}
			defaultRequest.ResourcePath = resourcePath;
			return defaultRequest;
		}
	}
}
