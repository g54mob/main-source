using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class HeadBucketRequestMarshaller : IMarshaller<IRequest, HeadBucketRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static HeadBucketRequestMarshaller _instance;

		public static HeadBucketRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new HeadBucketRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((HeadBucketRequest)input);
		}

		public IRequest Marshall(HeadBucketRequest headBucketRequest)
		{
			IRequest request = new DefaultRequest(headBucketRequest, "AmazonS3");
			request.HttpMethod = "HEAD";
			if (headBucketRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(headBucketRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(headBucketRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "HeadBucketRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.UseQueryString = true;
			return request;
		}
	}
}
