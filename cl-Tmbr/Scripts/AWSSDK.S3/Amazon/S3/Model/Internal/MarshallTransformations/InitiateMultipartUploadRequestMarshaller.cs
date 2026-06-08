using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class InitiateMultipartUploadRequestMarshaller : IMarshaller<IRequest, InitiateMultipartUploadRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static InitiateMultipartUploadRequestMarshaller _instance;

		public static InitiateMultipartUploadRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new InitiateMultipartUploadRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((InitiateMultipartUploadRequest)input);
		}

		public IRequest Marshall(InitiateMultipartUploadRequest initiateMultipartUploadRequest)
		{
			IRequest request = new DefaultRequest(initiateMultipartUploadRequest, "AmazonS3");
			request.HttpMethod = "POST";
			if (initiateMultipartUploadRequest.IsSetCannedACL())
			{
				request.Headers.Add("x-amz-acl", S3Transforms.ToStringValue(initiateMultipartUploadRequest.CannedACL));
			}
			if (initiateMultipartUploadRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(initiateMultipartUploadRequest.ExpectedBucketOwner));
			}
			HeadersCollection headers = initiateMultipartUploadRequest.Headers;
			foreach (string key in headers.Keys)
			{
				request.Headers.Add(key, headers[key]);
			}
			HeaderACLRequestMarshaller.Marshall(request, initiateMultipartUploadRequest);
			if (initiateMultipartUploadRequest.IsSetServerSideEncryptionMethod())
			{
				request.Headers.Add("x-amz-server-side-encryption", S3Transforms.ToStringValue(initiateMultipartUploadRequest.ServerSideEncryptionMethod));
			}
			if (initiateMultipartUploadRequest.IsSetServerSideEncryptionCustomerMethod())
			{
				request.Headers.Add("x-amz-server-side-encryption-customer-algorithm", initiateMultipartUploadRequest.ServerSideEncryptionCustomerMethod);
			}
			if (initiateMultipartUploadRequest.IsSetServerSideEncryptionCustomerProvidedKey())
			{
				request.Headers.Add("x-amz-server-side-encryption-customer-key", initiateMultipartUploadRequest.ServerSideEncryptionCustomerProvidedKey);
				if (initiateMultipartUploadRequest.IsSetServerSideEncryptionCustomerProvidedKeyMD5())
				{
					request.Headers.Add("x-amz-server-side-encryption-customer-key-MD5", initiateMultipartUploadRequest.ServerSideEncryptionCustomerProvidedKeyMD5);
				}
				else
				{
					request.Headers.Add("x-amz-server-side-encryption-customer-key-MD5", AmazonS3Util.ComputeEncodedMD5FromEncodedString(initiateMultipartUploadRequest.ServerSideEncryptionCustomerProvidedKey));
				}
			}
			if (initiateMultipartUploadRequest.IsSetServerSideEncryptionKeyManagementServiceKeyId())
			{
				request.Headers.Add("x-amz-server-side-encryption-aws-kms-key-id", initiateMultipartUploadRequest.ServerSideEncryptionKeyManagementServiceKeyId);
			}
			if (initiateMultipartUploadRequest.IsSetServerSideEncryptionKeyManagementServiceEncryptionContext())
			{
				request.Headers.Add("x-amz-server-side-encryption-context", initiateMultipartUploadRequest.ServerSideEncryptionKeyManagementServiceEncryptionContext);
			}
			if (initiateMultipartUploadRequest.IsSetStorageClass())
			{
				request.Headers.Add("x-amz-storage-class", S3Transforms.ToStringValue(initiateMultipartUploadRequest.StorageClass));
			}
			if (initiateMultipartUploadRequest.IsSetWebsiteRedirectLocation())
			{
				request.Headers.Add("x-amz-website-redirect-location", S3Transforms.ToStringValue(initiateMultipartUploadRequest.WebsiteRedirectLocation));
			}
			if (initiateMultipartUploadRequest.IsSetRequestPayer())
			{
				request.Headers.Add(S3Constants.AmzHeaderRequestPayer, S3Transforms.ToStringValue(initiateMultipartUploadRequest.RequestPayer.ToString()));
			}
			if (initiateMultipartUploadRequest.IsSetObjectLockLegalHoldStatus())
			{
				request.Headers.Add("x-amz-object-lock-legal-hold", S3Transforms.ToStringValue(initiateMultipartUploadRequest.ObjectLockLegalHoldStatus));
			}
			if (initiateMultipartUploadRequest.IsSetObjectLockMode())
			{
				request.Headers.Add("x-amz-object-lock-mode", S3Transforms.ToStringValue(initiateMultipartUploadRequest.ObjectLockMode));
			}
			if (initiateMultipartUploadRequest.IsSetObjectLockRetainUntilDate())
			{
				request.Headers.Add("x-amz-object-lock-retain-until-date", S3Transforms.ToStringValue(initiateMultipartUploadRequest.ObjectLockRetainUntilDate.Value, "yyyy-MM-dd\\THH:mm:ss.fff\\Z"));
			}
			if (initiateMultipartUploadRequest.IsSetTagSet())
			{
				request.Headers.Add(S3Constants.AmzHeaderTagging, AmazonS3Util.TagSetToQueryString(initiateMultipartUploadRequest.TagSet));
			}
			if (initiateMultipartUploadRequest.IsSetBucketKeyEnabled())
			{
				request.Headers.Add(S3Constants.AmzHeaderBucketKeyEnabled, S3Transforms.ToStringValue(initiateMultipartUploadRequest.BucketKeyEnabled.Value));
			}
			if (initiateMultipartUploadRequest.IsSetChecksumAlgorithm())
			{
				request.Headers.Add(S3Constants.AmzHeaderChecksumAlgorithm, S3Transforms.ToStringValue(initiateMultipartUploadRequest.ChecksumAlgorithm));
			}
			if (initiateMultipartUploadRequest.IsSetChecksumType())
			{
				request.Headers.Add(S3Constants.AmzHeaderChecksumType, S3Transforms.ToStringValue(initiateMultipartUploadRequest.ChecksumType));
			}
			AmazonS3Util.SetMetadataHeaders(request, initiateMultipartUploadRequest.Metadata);
			if (string.IsNullOrEmpty(initiateMultipartUploadRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "InitiateMultipartUploadRequest.BucketName");
			}
			if (string.IsNullOrEmpty(initiateMultipartUploadRequest.Key))
			{
				throw new ArgumentException("Key is a required property and must be set before making this call.", "InitiateMultipartUploadRequest.Key");
			}
			request.ResourcePath = "/{Key+}";
			request.AddPathResource("{Key+}", S3Transforms.ToStringValue(initiateMultipartUploadRequest.Key));
			request.AddSubResource("uploads");
			request.UseQueryString = true;
			return request;
		}
	}
}
