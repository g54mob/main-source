using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetBucketRequestPaymentRequestMarshaller : IMarshaller<IRequest, GetBucketRequestPaymentRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static GetBucketRequestPaymentRequestMarshaller _instance;

		public static GetBucketRequestPaymentRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GetBucketRequestPaymentRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((GetBucketRequestPaymentRequest)input);
		}

		public IRequest Marshall(GetBucketRequestPaymentRequest getBucketRequestPaymentRequest)
		{
			IRequest request = new DefaultRequest(getBucketRequestPaymentRequest, "AmazonS3");
			request.HttpMethod = "GET";
			if (getBucketRequestPaymentRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(getBucketRequestPaymentRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(getBucketRequestPaymentRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "GetBucketRequestPaymentRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("requestPayment");
			request.UseQueryString = true;
			return request;
		}
	}
}
