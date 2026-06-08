using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetBucketAnalyticsConfigurationRequestMarshaller : IMarshaller<IRequest, GetBucketAnalyticsConfigurationRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static GetBucketAnalyticsConfigurationRequestMarshaller _instance;

		public static GetBucketAnalyticsConfigurationRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GetBucketAnalyticsConfigurationRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((GetBucketAnalyticsConfigurationRequest)input);
		}

		public IRequest Marshall(GetBucketAnalyticsConfigurationRequest getAnalyticsConfigurationRequest)
		{
			IRequest request = new DefaultRequest(getAnalyticsConfigurationRequest, "AmazonS3");
			request.Suppress404Exceptions = true;
			request.HttpMethod = "GET";
			if (getAnalyticsConfigurationRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(getAnalyticsConfigurationRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(getAnalyticsConfigurationRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "GetBucketAnalyticsConfigurationRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("analytics");
			request.AddSubResource("id", getAnalyticsConfigurationRequest.AnalyticsId);
			request.UseQueryString = true;
			return request;
		}
	}
}
