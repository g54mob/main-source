using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class AbortMultipartUploadRequestMarshaller : IMarshaller<IRequest, AbortMultipartUploadRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static AbortMultipartUploadRequestMarshaller _instance;

		public static AbortMultipartUploadRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new AbortMultipartUploadRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((AbortMultipartUploadRequest)input);
		}

		public IRequest Marshall(AbortMultipartUploadRequest abortMultipartUploadRequest)
		{
			IRequest request = new DefaultRequest(abortMultipartUploadRequest, "AmazonS3");
			request.HttpMethod = "DELETE";
			if (abortMultipartUploadRequest.IsSetRequestPayer())
			{
				request.Headers.Add(S3Constants.AmzHeaderRequestPayer, S3Transforms.ToStringValue(abortMultipartUploadRequest.RequestPayer.ToString()));
			}
			if (abortMultipartUploadRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(abortMultipartUploadRequest.ExpectedBucketOwner));
			}
			if (abortMultipartUploadRequest.IsSetIfMatchInitiatedTime())
			{
				request.Headers.Add(S3Constants.AmzHeaderIfMatchInitiatedTime, S3Transforms.ToStringValue(abortMultipartUploadRequest.IfMatchInitiatedTime.Value));
			}
			if (string.IsNullOrEmpty(abortMultipartUploadRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "AbortMultipartUploadRequest.BucketName");
			}
			if (string.IsNullOrEmpty(abortMultipartUploadRequest.Key))
			{
				throw new ArgumentException("Key is a required property and must be set before making this call.", "AbortMultipartUploadRequest.Key");
			}
			request.AddPathResource("{Key+}", S3Transforms.ToStringValue(abortMultipartUploadRequest.Key));
			request.ResourcePath = "/{Key+}";
			request.AddSubResource("uploadId", S3Transforms.ToStringValue(abortMultipartUploadRequest.UploadId));
			request.UseQueryString = true;
			return request;
		}
	}
}
