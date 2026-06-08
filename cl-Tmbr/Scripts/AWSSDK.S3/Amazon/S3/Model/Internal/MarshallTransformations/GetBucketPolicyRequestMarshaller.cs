using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetBucketPolicyRequestMarshaller : IMarshaller<IRequest, GetBucketPolicyRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static GetBucketPolicyRequestMarshaller _instance;

		public static GetBucketPolicyRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GetBucketPolicyRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((GetBucketPolicyRequest)input);
		}

		public IRequest Marshall(GetBucketPolicyRequest getBucketPolicyRequest)
		{
			IRequest request = new DefaultRequest(getBucketPolicyRequest, "AmazonS3");
			request.Suppress404Exceptions = true;
			request.HttpMethod = "GET";
			if (getBucketPolicyRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(getBucketPolicyRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(getBucketPolicyRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "GetBucketPolicyRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("policy");
			request.UseQueryString = true;
			return request;
		}
	}
}
