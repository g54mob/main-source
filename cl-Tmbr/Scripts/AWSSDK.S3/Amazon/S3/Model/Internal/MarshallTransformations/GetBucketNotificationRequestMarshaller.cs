using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetBucketNotificationRequestMarshaller : IMarshaller<IRequest, GetBucketNotificationRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static GetBucketNotificationRequestMarshaller _instance;

		public static GetBucketNotificationRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GetBucketNotificationRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((GetBucketNotificationRequest)input);
		}

		public IRequest Marshall(GetBucketNotificationRequest getBucketNotificationRequest)
		{
			IRequest request = new DefaultRequest(getBucketNotificationRequest, "AmazonS3");
			request.HttpMethod = "GET";
			if (getBucketNotificationRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(getBucketNotificationRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(getBucketNotificationRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "GetBucketNotificationRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("notification");
			request.UseQueryString = true;
			return request;
		}
	}
}
