using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class DeleteBucketMetricsConfigurationRequestMarshaller : IMarshaller<IRequest, DeleteBucketMetricsConfigurationRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static DeleteBucketMetricsConfigurationRequestMarshaller _instance;

		public static DeleteBucketMetricsConfigurationRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new DeleteBucketMetricsConfigurationRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((DeleteBucketMetricsConfigurationRequest)input);
		}

		public IRequest Marshall(DeleteBucketMetricsConfigurationRequest deleteBucketMetricsConfigurationRequest)
		{
			IRequest request = new DefaultRequest(deleteBucketMetricsConfigurationRequest, "AmazonS3");
			request.HttpMethod = "DELETE";
			if (deleteBucketMetricsConfigurationRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(deleteBucketMetricsConfigurationRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(deleteBucketMetricsConfigurationRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "DeleteBucketMetricsConfigurationRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("metrics");
			request.AddSubResource("id", deleteBucketMetricsConfigurationRequest.MetricsId);
			request.UseQueryString = true;
			return request;
		}
	}
}
