using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class PutObjectRequestMarshaller : IMarshaller<IRequest, PutObjectRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static PutObjectRequestMarshaller _instance;

		public static PutObjectRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PutObjectRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((PutObjectRequest)input);
		}

		public IRequest Marshall(PutObjectRequest putObjectRequest)
		{
			IRequest request = new DefaultRequest(putObjectRequest, "AmazonS3");
			request.HttpMethod = "PUT";
			if (putObjectRequest.IsSetCannedACL())
			{
				request.Headers.Add("x-amz-acl", S3Transforms.ToStringValue(putObjectRequest.CannedACL));
			}
			HeadersCollection headers = putObjectRequest.Headers;
			foreach (string key in headers.Keys)
			{
				request.Headers[key] = headers[key];
			}
			if (putObjectRequest.IsSetMD5Digest())
			{
				request.Headers["Content-MD5"] = putObjectRequest.MD5Digest;
			}
			HeaderACLRequestMarshaller.Marshall(request, putObjectRequest);
			if (putObjectRequest.IsSetServerSideEncryptionMethod())
			{
				request.Headers.Add("x-amz-server-side-encryption", S3Transforms.ToStringValue(putObjectRequest.ServerSideEncryptionMethod));
			}
			if (putObjectRequest.IsSetStorageClass())
			{
				request.Headers.Add("x-amz-storage-class", S3Transforms.ToStringValue(putObjectRequest.StorageClass));
			}
			if (putObjectRequest.IsSetWebsiteRedirectLocation())
			{
				request.Headers.Add("x-amz-website-redirect-location", S3Transforms.ToStringValue(putObjectRequest.WebsiteRedirectLocation));
			}
			if (putObjectRequest.IsSetServerSideEncryptionCustomerMethod())
			{
				request.Headers.Add("x-amz-server-side-encryption-customer-algorithm", putObjectRequest.ServerSideEncryptionCustomerMethod);
			}
			if (putObjectRequest.IsSetServerSideEncryptionCustomerProvidedKey())
			{
				request.Headers.Add("x-amz-server-side-encryption-customer-key", putObjectRequest.ServerSideEncryptionCustomerProvidedKey);
				if (putObjectRequest.IsSetServerSideEncryptionCustomerProvidedKeyMD5())
				{
					request.Headers.Add("x-amz-server-side-encryption-customer-key-MD5", putObjectRequest.ServerSideEncryptionCustomerProvidedKeyMD5);
				}
				else
				{
					request.Headers.Add("x-amz-server-side-encryption-customer-key-MD5", AmazonS3Util.ComputeEncodedMD5FromEncodedString(putObjectRequest.ServerSideEncryptionCustomerProvidedKey));
				}
			}
			if (putObjectRequest.IsSetServerSideEncryptionKeyManagementServiceKeyId())
			{
				request.Headers.Add("x-amz-server-side-encryption-aws-kms-key-id", putObjectRequest.ServerSideEncryptionKeyManagementServiceKeyId);
			}
			if (putObjectRequest.IsSetServerSideEncryptionKeyManagementServiceEncryptionContext())
			{
				request.Headers.Add("x-amz-server-side-encryption-context", putObjectRequest.ServerSideEncryptionKeyManagementServiceEncryptionContext);
			}
			if (putObjectRequest.IsSetObjectLockLegalHoldStatus())
			{
				request.Headers.Add("x-amz-object-lock-legal-hold", S3Transforms.ToStringValue(putObjectRequest.ObjectLockLegalHoldStatus));
			}
			if (putObjectRequest.IsSetObjectLockMode())
			{
				request.Headers.Add("x-amz-object-lock-mode", S3Transforms.ToStringValue(putObjectRequest.ObjectLockMode));
			}
			if (putObjectRequest.IsSetObjectLockRetainUntilDate())
			{
				request.Headers.Add("x-amz-object-lock-retain-until-date", S3Transforms.ToStringValue(putObjectRequest.ObjectLockRetainUntilDate.Value, "yyyy-MM-dd\\THH:mm:ss.fff\\Z"));
			}
			if (putObjectRequest.IsSetRequestPayer())
			{
				request.Headers.Add(S3Constants.AmzHeaderRequestPayer, S3Transforms.ToStringValue(putObjectRequest.RequestPayer.ToString()));
			}
			if (putObjectRequest.IsSetTagSet())
			{
				request.Headers.Add(S3Constants.AmzHeaderTagging, AmazonS3Util.TagSetToQueryString(putObjectRequest.TagSet));
			}
			if (putObjectRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(putObjectRequest.ExpectedBucketOwner));
			}
			if (putObjectRequest.IsSetBucketKeyEnabled())
			{
				request.Headers.Add(S3Constants.AmzHeaderBucketKeyEnabled, S3Transforms.ToStringValue(putObjectRequest.BucketKeyEnabled.Value));
			}
			if (putObjectRequest.IsSetChecksumAlgorithm())
			{
				request.Headers.Add(S3Constants.AmzHeaderSdkChecksumAlgorithm, S3Transforms.ToStringValue(putObjectRequest.ChecksumAlgorithm));
			}
			if (putObjectRequest.IsSetChecksumCRC32())
			{
				request.Headers.Add("x-amz-checksum-crc32", S3Transforms.ToStringValue(putObjectRequest.ChecksumCRC32));
			}
			if (putObjectRequest.IsSetChecksumCRC32C())
			{
				request.Headers.Add("x-amz-checksum-crc32c", S3Transforms.ToStringValue(putObjectRequest.ChecksumCRC32C));
			}
			if (putObjectRequest.IsSetChecksumCRC64NVME())
			{
				request.Headers.Add("x-amz-checksum-crc64nvme", S3Transforms.ToStringValue(putObjectRequest.ChecksumCRC64NVME));
			}
			if (putObjectRequest.IsSetChecksumSHA1())
			{
				request.Headers.Add("x-amz-checksum-sha1", S3Transforms.ToStringValue(putObjectRequest.ChecksumSHA1));
			}
			if (putObjectRequest.IsSetChecksumSHA256())
			{
				request.Headers.Add("x-amz-checksum-sha256", S3Transforms.ToStringValue(putObjectRequest.ChecksumSHA256));
			}
			if (putObjectRequest.IsSetIfNoneMatch())
			{
				request.Headers["If-None-Match"] = putObjectRequest.IfNoneMatch;
			}
			if (putObjectRequest.IsSetIfMatch())
			{
				request.Headers.Add("If-Match", S3Transforms.ToStringValue(putObjectRequest.IfMatch));
			}
			if (putObjectRequest.IsSetWriteOffsetBytes())
			{
				request.Headers.Add("x-amz-write-offset-bytes", S3Transforms.ToStringValue(putObjectRequest.WriteOffsetBytes));
			}
			AmazonS3Util.SetMetadataHeaders(request, putObjectRequest.Metadata);
			if (string.IsNullOrEmpty(putObjectRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "PutObjectRequest.BucketName");
			}
			if (string.IsNullOrEmpty(putObjectRequest.Key))
			{
				throw new ArgumentException("Key is a required property and must be set before making this call.", "PutObjectRequest.Key");
			}
			request.ResourcePath = "/{Key+}";
			request.AddPathResource("{Key+}", S3Transforms.ToStringValue(putObjectRequest.Key));
			if (!request.Headers.ContainsKey("Content-Type"))
			{
				request.Headers.Add("Content-Type", "text/plain");
			}
			return request;
		}
	}
}
