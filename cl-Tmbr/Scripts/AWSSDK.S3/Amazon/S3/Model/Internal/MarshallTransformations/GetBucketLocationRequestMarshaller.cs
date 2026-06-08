using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetBucketLocationRequestMarshaller : IMarshaller<IRequest, GetBucketLocationRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static GetBucketLocationRequestMarshaller _instance;

		public static GetBucketLocationRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GetBucketLocationRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((GetBucketLocationRequest)input);
		}

		public IRequest Marshall(GetBucketLocationRequest getBucketLocationRequest)
		{
			IRequest request = new DefaultRequest(getBucketLocationRequest, "AmazonS3");
			request.HttpMethod = "GET";
			if (getBucketLocationRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(getBucketLocationRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(getBucketLocationRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "GetBucketLocationRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("location");
			request.UseQueryString = true;
			return request;
		}
	}
}
