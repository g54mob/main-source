using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class DeleteBucketAnalyticsConfigurationRequestMarshaller : IMarshaller<IRequest, DeleteBucketAnalyticsConfigurationRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static DeleteBucketAnalyticsConfigurationRequestMarshaller _instance;

		public static DeleteBucketAnalyticsConfigurationRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new DeleteBucketAnalyticsConfigurationRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((DeleteBucketAnalyticsConfigurationRequest)input);
		}

		public IRequest Marshall(DeleteBucketAnalyticsConfigurationRequest deleteBucketAnalyticsConfigurationRequest)
		{
			IRequest request = new DefaultRequest(deleteBucketAnalyticsConfigurationRequest, "AmazonS3");
			request.HttpMethod = "DELETE";
			if (deleteBucketAnalyticsConfigurationRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(deleteBucketAnalyticsConfigurationRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(deleteBucketAnalyticsConfigurationRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "DeleteBucketAnalyticsConfigurationRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("analytics");
			request.AddSubResource("id", deleteBucketAnalyticsConfigurationRequest.AnalyticsId);
			request.UseQueryString = true;
			return request;
		}
	}
}
