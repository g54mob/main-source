using System;
using System.Globalization;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Internal;
using Amazon.S3.Util;
using Amazon.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class CopyObjectRequestMarshaller : IMarshaller<IRequest, CopyObjectRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static CopyObjectRequestMarshaller _instance;

		public static CopyObjectRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new CopyObjectRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((CopyObjectRequest)input);
		}

		public IRequest Marshall(CopyObjectRequest copyObjectRequest)
		{
			string sourceKey = copyObjectRequest.SourceKey;
			string destinationKey = copyObjectRequest.DestinationKey;
			IRequest request = new DefaultRequest(copyObjectRequest, "AmazonS3");
			request.HttpMethod = "PUT";
			if (copyObjectRequest.IsSetCannedACL())
			{
				request.Headers.Add("x-amz-acl", S3Transforms.ToStringValue(copyObjectRequest.CannedACL));
			}
			HeadersCollection headers = copyObjectRequest.Headers;
			foreach (string key in headers.Keys)
			{
				request.Headers[key] = headers[key];
			}
			HeaderACLRequestMarshaller.Marshall(request, copyObjectRequest);
			if (copyObjectRequest.IsSetSourceBucket())
			{
				request.Headers.Add("x-amz-copy-source", ConstructCopySourceHeaderValue(copyObjectRequest.SourceBucket, sourceKey, copyObjectRequest.SourceVersionId));
			}
			if (copyObjectRequest.IsSetETagToMatch())
			{
				request.Headers.Add("x-amz-copy-source-if-match", S3Transforms.ToStringValue(copyObjectRequest.ETagToMatch));
			}
			if (copyObjectRequest.IsSetModifiedSinceDate())
			{
				request.Headers.Add("x-amz-copy-source-if-modified-since", S3Transforms.ToStringValue(copyObjectRequest.ModifiedSinceDate.Value));
			}
			if (copyObjectRequest.IsSetETagToNotMatch())
			{
				request.Headers.Add("x-amz-copy-source-if-none-match", S3Transforms.ToStringValue(copyObjectRequest.ETagToNotMatch));
			}
			if (copyObjectRequest.IsSetUnmodifiedSinceDate())
			{
				request.Headers.Add("x-amz-copy-source-if-unmodified-since", S3Transforms.ToStringValue(copyObjectRequest.UnmodifiedSinceDate.Value));
			}
			if (copyObjectRequest.IsSetTaggingDirective())
			{
				if (copyObjectRequest.TaggingDirective == TaggingDirective.REPLACE)
				{
					if (copyObjectRequest.IsSetTagSet())
					{
						request.Headers.Add(S3Constants.AmzHeaderTagging, AmazonS3Util.TagSetToQueryString(copyObjectRequest.TagSet));
					}
					request.Headers.Add(S3Constants.AmzHeaderTaggingDirective, TaggingDirective.REPLACE.Value);
				}
				else if (copyObjectRequest.TaggingDirective == TaggingDirective.COPY)
				{
					request.Headers.Add(S3Constants.AmzHeaderTaggingDirective, TaggingDirective.COPY.Value);
				}
			}
			request.Headers.Add("x-amz-metadata-directive", S3Transforms.ToStringValue(copyObjectRequest.MetadataDirective.ToString()));
			if (copyObjectRequest.IsSetObjectLockLegalHoldStatus())
			{
				request.Headers.Add("x-amz-object-lock-legal-hold", S3Transforms.ToStringValue(copyObjectRequest.ObjectLockLegalHoldStatus));
			}
			if (copyObjectRequest.IsSetObjectLockMode())
			{
				request.Headers.Add("x-amz-object-lock-mode", S3Transforms.ToStringValue(copyObjectRequest.ObjectLockMode));
			}
			if (copyObjectRequest.IsSetObjectLockRetainUntilDate())
			{
				request.Headers.Add("x-amz-object-lock-retain-until-date", S3Transforms.ToStringValue(copyObjectRequest.ObjectLockRetainUntilDate.Value, "yyyy-MM-dd\\THH:mm:ss.fff\\Z"));
			}
			if (copyObjectRequest.IsSetServerSideEncryptionMethod())
			{
				request.Headers.Add("x-amz-server-side-encryption", S3Transforms.ToStringValue(copyObjectRequest.ServerSideEncryptionMethod));
			}
			if (copyObjectRequest.IsSetServerSideEncryptionCustomerMethod())
			{
				request.Headers.Add("x-amz-server-side-encryption-customer-algorithm", copyObjectRequest.ServerSideEncryptionCustomerMethod);
			}
			if (copyObjectRequest.IsSetServerSideEncryptionCustomerProvidedKey())
			{
				request.Headers.Add("x-amz-server-side-encryption-customer-key", copyObjectRequest.ServerSideEncryptionCustomerProvidedKey);
				if (copyObjectRequest.IsSetServerSideEncryptionCustomerProvidedKeyMD5())
				{
					request.Headers.Add("x-amz-server-side-encryption-customer-key-MD5", copyObjectRequest.ServerSideEncryptionCustomerProvidedKeyMD5);
				}
				else
				{
					request.Headers.Add("x-amz-server-side-encryption-customer-key-MD5", AmazonS3Util.ComputeEncodedMD5FromEncodedString(copyObjectRequest.ServerSideEncryptionCustomerProvidedKey));
				}
			}
			if (copyObjectRequest.IsSetCopySourceServerSideEncryptionCustomerMethod())
			{
				request.Headers.Add("x-amz-copy-source-server-side-encryption-customer-algorithm", copyObjectRequest.CopySourceServerSideEncryptionCustomerMethod);
			}
			if (copyObjectRequest.IsSetCopySourceServerSideEncryptionCustomerProvidedKey())
			{
				request.Headers.Add("x-amz-copy-source-server-side-encryption-customer-key", copyObjectRequest.CopySourceServerSideEncryptionCustomerProvidedKey);
				if (copyObjectRequest.IsSetCopySourceServerSideEncryptionCustomerProvidedKeyMD5())
				{
					request.Headers.Add("x-amz-copy-source-server-side-encryption-customer-key-MD5", copyObjectRequest.CopySourceServerSideEncryptionCustomerProvidedKeyMD5);
				}
				else
				{
					request.Headers.Add("x-amz-copy-source-server-side-encryption-customer-key-MD5", AmazonS3Util.ComputeEncodedMD5FromEncodedString(copyObjectRequest.CopySourceServerSideEncryptionCustomerProvidedKey));
				}
			}
			if (copyObjectRequest.IsSetServerSideEncryptionKeyManagementServiceKeyId())
			{
				request.Headers.Add("x-amz-server-side-encryption-aws-kms-key-id", copyObjectRequest.ServerSideEncryptionKeyManagementServiceKeyId);
			}
			if (copyObjectRequest.IsSetServerSideEncryptionKeyManagementServiceEncryptionContext())
			{
				request.Headers.Add("x-amz-server-side-encryption-context", copyObjectRequest.ServerSideEncryptionKeyManagementServiceEncryptionContext);
			}
			if (copyObjectRequest.IsSetStorageClass())
			{
				request.Headers.Add("x-amz-storage-class", S3Transforms.ToStringValue(copyObjectRequest.StorageClass));
			}
			if (copyObjectRequest.IsSetWebsiteRedirectLocation())
			{
				request.Headers.Add("x-amz-website-redirect-location", S3Transforms.ToStringValue(copyObjectRequest.WebsiteRedirectLocation));
			}
			if (copyObjectRequest.IsSetRequestPayer())
			{
				request.Headers.Add(S3Constants.AmzHeaderRequestPayer, S3Transforms.ToStringValue(copyObjectRequest.RequestPayer.ToString()));
			}
			if (copyObjectRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(copyObjectRequest.ExpectedBucketOwner));
			}
			if (copyObjectRequest.IsSetExpectedSourceBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedSourceBucketOwner, S3Transforms.ToStringValue(copyObjectRequest.ExpectedSourceBucketOwner));
			}
			if (copyObjectRequest.IsSetBucketKeyEnabled())
			{
				request.Headers.Add(S3Constants.AmzHeaderBucketKeyEnabled, S3Transforms.ToStringValue(copyObjectRequest.BucketKeyEnabled.Value));
			}
			if (copyObjectRequest.IsSetChecksumAlgorithm())
			{
				request.Headers.Add(S3Constants.AmzHeaderChecksumAlgorithm, S3Transforms.ToStringValue(copyObjectRequest.ChecksumAlgorithm));
			}
			AmazonS3Util.SetMetadataHeaders(request, copyObjectRequest.Metadata);
			if (string.IsNullOrEmpty(copyObjectRequest.DestinationBucket))
			{
				throw new ArgumentException("DestinationBucket is a required property and must be set before making this call.", "CopyObjectRequest.DestinationBucket");
			}
			if (string.IsNullOrEmpty(destinationKey))
			{
				throw new ArgumentException("DestinationKey is a required property and must be set before making this call.", "CopyObjectRequest.DestinationKey");
			}
			if (string.IsNullOrEmpty(copyObjectRequest.SourceBucket))
			{
				throw new ArgumentException("SourceBucket is a required property and must be set before making this call.", "CopyObjectRequest.SourceBucket");
			}
			if (string.IsNullOrEmpty(sourceKey))
			{
				throw new ArgumentException("SourceKey is a required property and must be set before making this call.", "CopyObjectRequest.SourceKey");
			}
			request.AddPathResource("{Key+}", S3Transforms.ToStringValue(destinationKey));
			request.ResourcePath = "/{Key+}";
			request.UseQueryString = true;
			return request;
		}

		private static string ConstructCopySourceHeaderValue(string bucket, string key, string version)
		{
			string text;
			if (!string.IsNullOrEmpty(key))
			{
				bool flag = S3ArnUtils.IsS3AccessPointsArn(bucket) || S3ArnUtils.IsS3OutpostsArn(bucket);
				text = AWSSDKUtils.UrlEncode(bucket + (flag ? "/object/" : "/") + key, path: false);
				if (!string.IsNullOrEmpty(version))
				{
					text = string.Format(CultureInfo.InvariantCulture, "{0}?versionId={1}", text, AWSSDKUtils.UrlEncode(version, path: true));
				}
			}
			else
			{
				text = AWSSDKUtils.UrlEncode(bucket, path: true);
			}
			return text;
		}
	}
}
