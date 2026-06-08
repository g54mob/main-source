using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class ListBucketAnalyticsConfigurationsRequestMarshaller : IMarshaller<IRequest, ListBucketAnalyticsConfigurationsRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static ListBucketAnalyticsConfigurationsRequestMarshaller _instance;

		public static ListBucketAnalyticsConfigurationsRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new ListBucketAnalyticsConfigurationsRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((ListBucketAnalyticsConfigurationsRequest)input);
		}

		public IRequest Marshall(ListBucketAnalyticsConfigurationsRequest listBucketAnalyticsConfigurationsRequest)
		{
			IRequest request = new DefaultRequest(listBucketAnalyticsConfigurationsRequest, "AmazonS3");
			request.HttpMethod = "GET";
			if (listBucketAnalyticsConfigurationsRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(listBucketAnalyticsConfigurationsRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(listBucketAnalyticsConfigurationsRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "ListBucketAnalyticsConfigurationsRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("analytics");
			if (listBucketAnalyticsConfigurationsRequest.IsSetContinuationToken())
			{
				request.AddSubResource("continuation-token", listBucketAnalyticsConfigurationsRequest.ContinuationToken.ToString());
			}
			request.UseQueryString = true;
			return request;
		}
	}
}
