using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetBucketTaggingRequestMarshaller : IMarshaller<IRequest, GetBucketTaggingRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static GetBucketTaggingRequestMarshaller _instance;

		public static GetBucketTaggingRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GetBucketTaggingRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((GetBucketTaggingRequest)input);
		}

		public IRequest Marshall(GetBucketTaggingRequest getBucketTaggingRequest)
		{
			IRequest request = new DefaultRequest(getBucketTaggingRequest, "AmazonS3");
			request.Suppress404Exceptions = true;
			request.HttpMethod = "GET";
			if (getBucketTaggingRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(getBucketTaggingRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(getBucketTaggingRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "GetBucketTaggingRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("tagging");
			request.UseQueryString = true;
			return request;
		}
	}
}
