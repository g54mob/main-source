using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class ListBucketMetricsConfigurationsRequestMarshaller : IMarshaller<IRequest, ListBucketMetricsConfigurationsRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static ListBucketMetricsConfigurationsRequestMarshaller _instance;

		public static ListBucketMetricsConfigurationsRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new ListBucketMetricsConfigurationsRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((ListBucketMetricsConfigurationsRequest)input);
		}

		public IRequest Marshall(ListBucketMetricsConfigurationsRequest listBucketMetricsConfigurationRequest)
		{
			IRequest request = new DefaultRequest(listBucketMetricsConfigurationRequest, "AmazonS3");
			request.HttpMethod = "GET";
			if (listBucketMetricsConfigurationRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(listBucketMetricsConfigurationRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(listBucketMetricsConfigurationRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "ListBucketMetricsConfigurationsRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("metrics");
			if (listBucketMetricsConfigurationRequest.IsSetContinuationToken())
			{
				request.AddSubResource("continuation-token", listBucketMetricsConfigurationRequest.ContinuationToken.ToString());
			}
			request.UseQueryString = true;
			return request;
		}
	}
}
