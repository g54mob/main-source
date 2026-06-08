using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetBucketLoggingRequestMarshaller : IMarshaller<IRequest, GetBucketLoggingRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static GetBucketLoggingRequestMarshaller _instance;

		public static GetBucketLoggingRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GetBucketLoggingRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((GetBucketLoggingRequest)input);
		}

		public IRequest Marshall(GetBucketLoggingRequest getBucketLoggingRequest)
		{
			IRequest request = new DefaultRequest(getBucketLoggingRequest, "AmazonS3");
			request.Suppress404Exceptions = true;
			request.HttpMethod = "GET";
			if (getBucketLoggingRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(getBucketLoggingRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(getBucketLoggingRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "GetBucketLoggingRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("logging");
			request.UseQueryString = true;
			return request;
		}
	}
}
