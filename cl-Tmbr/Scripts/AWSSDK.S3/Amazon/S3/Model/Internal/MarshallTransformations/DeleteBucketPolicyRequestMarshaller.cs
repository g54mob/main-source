using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class DeleteBucketPolicyRequestMarshaller : IMarshaller<IRequest, DeleteBucketPolicyRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static DeleteBucketPolicyRequestMarshaller _instance;

		public static DeleteBucketPolicyRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new DeleteBucketPolicyRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((DeleteBucketPolicyRequest)input);
		}

		public IRequest Marshall(DeleteBucketPolicyRequest deleteBucketPolicyRequest)
		{
			IRequest request = new DefaultRequest(deleteBucketPolicyRequest, "AmazonS3");
			request.HttpMethod = "DELETE";
			if (deleteBucketPolicyRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(deleteBucketPolicyRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(deleteBucketPolicyRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "DeleteBucketPolicyRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("policy");
			request.UseQueryString = true;
			return request;
		}
	}
}
