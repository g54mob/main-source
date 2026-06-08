using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetBucketWebsiteRequestMarshaller : IMarshaller<IRequest, GetBucketWebsiteRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static GetBucketWebsiteRequestMarshaller _instance;

		public static GetBucketWebsiteRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GetBucketWebsiteRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((GetBucketWebsiteRequest)input);
		}

		public IRequest Marshall(GetBucketWebsiteRequest getBucketWebsiteRequest)
		{
			IRequest request = new DefaultRequest(getBucketWebsiteRequest, "AmazonS3");
			request.Suppress404Exceptions = true;
			request.HttpMethod = "GET";
			if (getBucketWebsiteRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(getBucketWebsiteRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(getBucketWebsiteRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "GetBucketWebsiteRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("website");
			request.UseQueryString = true;
			return request;
		}
	}
}
