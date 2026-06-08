using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class UploadPartRequestMarshaller : IMarshaller<IRequest, UploadPartRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static UploadPartRequestMarshaller _instance;

		public static UploadPartRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new UploadPartRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((UploadPartRequest)input);
		}

		public IRequest Marshall(UploadPartRequest uploadPartRequest)
		{
			IRequest request = new DefaultRequest(uploadPartRequest, "AmazonS3");
			request.HttpMethod = "PUT";
			if (uploadPartRequest.IsSetChecksumAlgorithm())
			{
				request.Headers.Add(S3Constants.AmzHeaderSdkChecksumAlgorithm, S3Transforms.ToStringValue(uploadPartRequest.ChecksumAlgorithm));
			}
			if (uploadPartRequest.IsSetChecksumCRC32())
			{
				request.Headers["x-amz-checksum-crc32"] = S3Transforms.ToStringValue(uploadPartRequest.ChecksumCRC32);
			}
			if (uploadPartRequest.IsSetChecksumCRC32C())
			{
				request.Headers["x-amz-checksum-crc32c"] = S3Transforms.ToStringValue(uploadPartRequest.ChecksumCRC32C);
			}
			if (uploadPartRequest.IsSetChecksumCRC64NVME())
			{
				request.Headers["x-amz-checksum-crc64nvme"] = S3Transforms.ToStringValue(uploadPartRequest.ChecksumCRC64NVME);
			}
			if (uploadPartRequest.IsSetChecksumSHA1())
			{
				request.Headers["x-amz-checksum-sha1"] = S3Transforms.ToStringValue(uploadPartRequest.ChecksumSHA1);
			}
			if (uploadPartRequest.IsSetChecksumSHA256())
			{
				request.Headers["x-amz-checksum-sha256"] = S3Transforms.ToStringValue(uploadPartRequest.ChecksumSHA256);
			}
			if (uploadPartRequest.IsSetMD5Digest())
			{
				request.Headers["Content-MD5"] = uploadPartRequest.MD5Digest;
			}
			if (uploadPartRequest.IsSetServerSideEncryptionCustomerMethod())
			{
				request.Headers.Add("x-amz-server-side-encryption-customer-algorithm", uploadPartRequest.ServerSideEncryptionCustomerMethod);
			}
			if (uploadPartRequest.IsSetServerSideEncryptionCustomerProvidedKey())
			{
				request.Headers.Add("x-amz-server-side-encryption-customer-key", uploadPartRequest.ServerSideEncryptionCustomerProvidedKey);
				if (uploadPartRequest.IsSetServerSideEncryptionCustomerProvidedKeyMD5())
				{
					request.Headers.Add("x-amz-server-side-encryption-customer-key-MD5", uploadPartRequest.ServerSideEncryptionCustomerProvidedKeyMD5);
				}
				else
				{
					request.Headers.Add("x-amz-server-side-encryption-customer-key-MD5", AmazonS3Util.ComputeEncodedMD5FromEncodedString(uploadPartRequest.ServerSideEncryptionCustomerProvidedKey));
				}
			}
			if (uploadPartRequest.IsSetRequestPayer())
			{
				request.Headers.Add(S3Constants.AmzHeaderRequestPayer, S3Transforms.ToStringValue(uploadPartRequest.RequestPayer.ToString()));
			}
			if (uploadPartRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(uploadPartRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(uploadPartRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "UploadPartRequest.BucketName");
			}
			if (string.IsNullOrEmpty(uploadPartRequest.Key))
			{
				throw new ArgumentException("Key is a required property and must be set before making this call.", "UploadPartRequest.Key");
			}
			request.ResourcePath = "/{Key+}";
			request.AddPathResource("{Key+}", S3Transforms.ToStringValue(uploadPartRequest.Key));
			if (uploadPartRequest.IsSetPartNumber())
			{
				request.AddSubResource("partNumber", S3Transforms.ToStringValue(uploadPartRequest.PartNumber.Value));
			}
			if (uploadPartRequest.IsSetUploadId())
			{
				request.AddSubResource("uploadId", S3Transforms.ToStringValue(uploadPartRequest.UploadId));
			}
			if (!request.Headers.ContainsKey("Content-Type"))
			{
				request.Headers.Add("Content-Type", "text/plain");
			}
			return request;
		}
	}
}
