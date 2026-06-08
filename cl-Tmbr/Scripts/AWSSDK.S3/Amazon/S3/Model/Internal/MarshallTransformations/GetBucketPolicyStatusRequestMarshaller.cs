using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetBucketPolicyStatusRequestMarshaller : IMarshaller<IRequest, GetBucketPolicyStatusRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static GetBucketPolicyStatusRequestMarshaller _instance;

		public static GetBucketPolicyStatusRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GetBucketPolicyStatusRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((GetBucketPolicyStatusRequest)input);
		}

		public IRequest Marshall(GetBucketPolicyStatusRequest getBucketPolicyStatusRequest)
		{
			IRequest request = new DefaultRequest(getBucketPolicyStatusRequest, "AmazonS3");
			request.HttpMethod = "GET";
			if (getBucketPolicyStatusRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(getBucketPolicyStatusRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(getBucketPolicyStatusRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "getBucketPolicyStatusRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("policyStatus");
			request.UseQueryString = true;
			return request;
		}
	}
}
