using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetCORSConfigurationRequestMarshaller : IMarshaller<IRequest, GetCORSConfigurationRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static GetCORSConfigurationRequestMarshaller _instance;

		public static GetCORSConfigurationRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GetCORSConfigurationRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((GetCORSConfigurationRequest)input);
		}

		public IRequest Marshall(GetCORSConfigurationRequest getCORSConfigurationRequest)
		{
			IRequest request = new DefaultRequest(getCORSConfigurationRequest, "AmazonS3");
			request.Suppress404Exceptions = true;
			request.HttpMethod = "GET";
			if (getCORSConfigurationRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(getCORSConfigurationRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(getCORSConfigurationRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "GetCORSConfigurationRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("cors");
			request.UseQueryString = true;
			return request;
		}
	}
}
