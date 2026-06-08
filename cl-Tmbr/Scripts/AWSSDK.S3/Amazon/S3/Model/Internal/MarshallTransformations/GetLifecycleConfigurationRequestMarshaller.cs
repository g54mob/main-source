using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetLifecycleConfigurationRequestMarshaller : IMarshaller<IRequest, GetLifecycleConfigurationRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static GetLifecycleConfigurationRequestMarshaller _instance;

		public static GetLifecycleConfigurationRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GetLifecycleConfigurationRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((GetLifecycleConfigurationRequest)input);
		}

		public IRequest Marshall(GetLifecycleConfigurationRequest getLifecycleConfiguration)
		{
			IRequest request = new DefaultRequest(getLifecycleConfiguration, "AmazonS3");
			request.Suppress404Exceptions = true;
			request.HttpMethod = "GET";
			if (getLifecycleConfiguration.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(getLifecycleConfiguration.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(getLifecycleConfiguration.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "GetLifecycleConfigurationRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("lifecycle");
			request.UseQueryString = true;
			return request;
		}
	}
}
