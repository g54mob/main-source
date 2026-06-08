using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetPublicAccessBlockRequestMarshaller : IMarshaller<IRequest, GetPublicAccessBlockRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static GetPublicAccessBlockRequestMarshaller _instance;

		public static GetPublicAccessBlockRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GetPublicAccessBlockRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((GetPublicAccessBlockRequest)input);
		}

		public IRequest Marshall(GetPublicAccessBlockRequest getPublicAccessBlockRequest)
		{
			IRequest request = new DefaultRequest(getPublicAccessBlockRequest, "AmazonS3");
			request.HttpMethod = "GET";
			if (getPublicAccessBlockRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(getPublicAccessBlockRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(getPublicAccessBlockRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "getPublicAccessBlockRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("publicAccessBlock");
			request.UseQueryString = true;
			return request;
		}
	}
}
