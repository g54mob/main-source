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
	public class CopyPartRequestMarshaller : IMarshaller<IRequest, CopyPartRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static CopyPartRequestMarshaller _instance;

		public static CopyPartRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new CopyPartRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((CopyPartRequest)input);
		}

		public IRequest Marshall(CopyPartRequest copyPartRequest)
		{
			IRequest request = new DefaultRequest(copyPartRequest, "AmazonS3");
			string sourceKey = copyPartRequest.SourceKey;
			string destinationKey = copyPartRequest.DestinationKey;
			request.HttpMethod = "PUT";
			if (copyPartRequest.IsSetSourceBucket())
			{
				request.Headers.Add("x-amz-copy-source", ConstructCopySourceHeaderValue(copyPartRequest.SourceBucket, sourceKey, copyPartRequest.SourceVersionId));
			}
			if (copyPartRequest.IsSetETagToMatch())
			{
				request.Headers.Add("x-amz-copy-source-if-match", AWSSDKUtils.Join(copyPartRequest.ETagToMatch));
			}
			if (copyPartRequest.IsSetETagToNotMatch())
			{
				request.Headers.Add("x-amz-copy-source-if-none-match", AWSSDKUtils.Join(copyPartRequest.ETagsToNotMatch));
			}
			if (copyPartRequest.IsSetModifiedSinceDate())
			{
				request.Headers.Add("x-amz-copy-source-if-modified-since", copyPartRequest.ModifiedSinceDate.Value.ToUniversalTime().ToString("ddd, dd MMM yyyy HH:mm:ss \\G\\M\\T", CultureInfo.InvariantCulture));
			}
			if (copyPartRequest.IsSetUnmodifiedSinceDate())
			{
				request.Headers.Add("x-amz-copy-source-if-unmodified-since", copyPartRequest.UnmodifiedSinceDate.Value.ToUniversalTime().ToString("ddd, dd MMM yyyy HH:mm:ss \\G\\M\\T", CultureInfo.InvariantCulture));
			}
			if (copyPartRequest.IsSetServerSideEncryptionCustomerMethod())
			{
				request.Headers.Add("x-amz-server-side-encryption-customer-algorithm", copyPartRequest.ServerSideEncryptionCustomerMethod);
			}
			if (copyPartRequest.IsSetServerSideEncryptionCustomerProvidedKey())
			{
				request.Headers.Add("x-amz-server-side-encryption-customer-key", copyPartRequest.ServerSideEncryptionCustomerProvidedKey);
				if (copyPartRequest.IsSetServerSideEncryptionCustomerProvidedKeyMD5())
				{
					request.Headers.Add("x-amz-server-side-encryption-customer-key-MD5", copyPartRequest.ServerSideEncryptionCustomerProvidedKeyMD5);
				}
				else
				{
					request.Headers.Add("x-amz-server-side-encryption-customer-key-MD5", AmazonS3Util.ComputeEncodedMD5FromEncodedString(copyPartRequest.ServerSideEncryptionCustomerProvidedKey));
				}
			}
			if (copyPartRequest.IsSetCopySourceServerSideEncryptionCustomerMethod())
			{
				request.Headers.Add("x-amz-copy-source-server-side-encryption-customer-algorithm", copyPartRequest.CopySourceServerSideEncryptionCustomerMethod);
			}
			if (copyPartRequest.IsSetCopySourceServerSideEncryptionCustomerProvidedKey())
			{
				request.Headers.Add("x-amz-copy-source-server-side-encryption-customer-key", copyPartRequest.CopySourceServerSideEncryptionCustomerProvidedKey);
				if (copyPartRequest.IsSetCopySourceServerSideEncryptionCustomerProvidedKeyMD5())
				{
					request.Headers.Add("x-amz-copy-source-server-side-encryption-customer-key-MD5", copyPartRequest.CopySourceServerSideEncryptionCustomerProvidedKeyMD5);
				}
				else
				{
					request.Headers.Add("x-amz-copy-source-server-side-encryption-customer-key-MD5", AmazonS3Util.ComputeEncodedMD5FromEncodedString(copyPartRequest.CopySourceServerSideEncryptionCustomerProvidedKey));
				}
			}
			if (copyPartRequest.IsSetFirstByte() && copyPartRequest.IsSetLastByte())
			{
				request.Headers.Add("x-amz-copy-source-range", ConstructCopySourceRangeHeader(copyPartRequest.FirstByte.Value, copyPartRequest.LastByte.Value));
			}
			if (copyPartRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(copyPartRequest.ExpectedBucketOwner));
			}
			if (copyPartRequest.IsSetRequestPayer())
			{
				request.Headers.Add(S3Constants.AmzHeaderRequestPayer, S3Transforms.ToStringValue(copyPartRequest.RequestPayer));
			}
			if (copyPartRequest.IsSetExpectedSourceBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedSourceBucketOwner, S3Transforms.ToStringValue(copyPartRequest.ExpectedSourceBucketOwner));
			}
			if (string.IsNullOrEmpty(copyPartRequest.DestinationBucket))
			{
				throw new ArgumentException("DestinationBucket is a required property and must be set before making this call.", "CopyPartRequest.DestinationBucket");
			}
			if (string.IsNullOrEmpty(destinationKey))
			{
				throw new ArgumentException("DestinationKey is a required property and must be set before making this call.", "CopyPartRequest.DestinationKey");
			}
			request.AddPathResource("{Key+}", S3Transforms.ToStringValue(destinationKey));
			request.ResourcePath = "/{Key+}";
			request.AddSubResource("partNumber", S3Transforms.ToStringValue(copyPartRequest.PartNumber.Value));
			request.AddSubResource("uploadId", S3Transforms.ToStringValue(copyPartRequest.UploadId));
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

		private static string ConstructCopySourceRangeHeader(long firstByte, long lastByte)
		{
			return string.Format(CultureInfo.InvariantCulture, "bytes={0}-{1}", firstByte, lastByte);
		}
	}
}
