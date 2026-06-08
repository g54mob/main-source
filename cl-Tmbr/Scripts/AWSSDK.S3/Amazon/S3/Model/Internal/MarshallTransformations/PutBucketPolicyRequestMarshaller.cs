using System;
using System.IO;
using System.Text;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.Util;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class PutBucketPolicyRequestMarshaller : IMarshaller<IRequest, PutBucketPolicyRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static PutBucketPolicyRequestMarshaller _instance;

		public static PutBucketPolicyRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PutBucketPolicyRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((PutBucketPolicyRequest)input);
		}

		public IRequest Marshall(PutBucketPolicyRequest putBucketPolicyRequest)
		{
			IRequest request = new DefaultRequest(putBucketPolicyRequest, "AmazonS3");
			request.HttpMethod = "PUT";
			if (putBucketPolicyRequest.IsSetChecksumAlgorithm())
			{
				request.Headers.Add(S3Constants.AmzHeaderSdkChecksumAlgorithm, S3Transforms.ToStringValue(putBucketPolicyRequest.ChecksumAlgorithm));
			}
			if (putBucketPolicyRequest.IsSetContentMD5())
			{
				request.Headers.Add("Content-MD5", S3Transforms.ToStringValue(putBucketPolicyRequest.ContentMD5));
			}
			if (!request.Headers.ContainsKey("Content-Type"))
			{
				request.Headers.Add("Content-Type", "text/plain");
			}
			if (putBucketPolicyRequest.IsSetConfirmRemoveSelfBucketAccess())
			{
				request.Headers.Add("x-amz-confirm-remove-self-bucket-access", S3Transforms.ToStringValue(putBucketPolicyRequest.ConfirmRemoveSelfBucketAccess.Value));
			}
			if (putBucketPolicyRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(putBucketPolicyRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(putBucketPolicyRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "PutBucketPolicyRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("policy");
			request.ContentStream = new MemoryStream(Encoding.UTF8.GetBytes(putBucketPolicyRequest.Policy));
			ChecksumUtils.SetChecksumData(request, putBucketPolicyRequest.ChecksumAlgorithm, fallbackToMD5: false, isRequestChecksumRequired: true, S3Constants.AmzHeaderSdkChecksumAlgorithm);
			return request;
		}
	}
}
