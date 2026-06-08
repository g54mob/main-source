using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetBucketVersioningRequestMarshaller : IMarshaller<IRequest, GetBucketVersioningRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static GetBucketVersioningRequestMarshaller _instance;

		public static GetBucketVersioningRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GetBucketVersioningRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((GetBucketVersioningRequest)input);
		}

		public IRequest Marshall(GetBucketVersioningRequest getBucketVersioningRequest)
		{
			IRequest request = new DefaultRequest(getBucketVersioningRequest, "AmazonS3");
			request.HttpMethod = "GET";
			if (getBucketVersioningRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(getBucketVersioningRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(getBucketVersioningRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "GetBucketVersioningRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("versioning");
			request.UseQueryString = true;
			return request;
		}
	}
}
