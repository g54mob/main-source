using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetBucketMetricsConfigurationRequestMarshaller : IMarshaller<IRequest, GetBucketMetricsConfigurationRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static GetBucketMetricsConfigurationRequestMarshaller _instance;

		public static GetBucketMetricsConfigurationRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GetBucketMetricsConfigurationRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((GetBucketMetricsConfigurationRequest)input);
		}

		public IRequest Marshall(GetBucketMetricsConfigurationRequest getBucketMetricsConfigurationRequest)
		{
			IRequest request = new DefaultRequest(getBucketMetricsConfigurationRequest, "AmazonS3");
			request.Suppress404Exceptions = true;
			request.HttpMethod = "GET";
			if (getBucketMetricsConfigurationRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(getBucketMetricsConfigurationRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(getBucketMetricsConfigurationRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "GetBucketMetricsConfigurationRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("metrics");
			request.AddSubResource("id", getBucketMetricsConfigurationRequest.MetricsId);
			request.UseQueryString = true;
			return request;
		}
	}
}
