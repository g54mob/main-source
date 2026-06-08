using System;
using System.IO;
using System.Net;
using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class PutObjectResponseUnmarshaller : S3ReponseUnmarshaller
	{
		private static PutObjectResponseUnmarshaller _instance;

		public static PutObjectResponseUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PutObjectResponseUnmarshaller();
				}
				return _instance;
			}
		}

		public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context)
		{
			PutObjectResponse putObjectResponse = new PutObjectResponse();
			UnmarshallResult(context, putObjectResponse);
			return putObjectResponse;
		}

		private static void UnmarshallResult(XmlUnmarshallerContext context, PutObjectResponse response)
		{
			IWebResponseData responseData = context.ResponseData;
			if (responseData.IsHeaderPresent("x-amz-expiration"))
			{
				response.Expiration = new Expiration(responseData.GetHeaderValue("x-amz-expiration"));
			}
			if (responseData.IsHeaderPresent("x-amz-server-side-encryption"))
			{
				response.ServerSideEncryptionMethod = S3Transforms.ToString(responseData.GetHeaderValue("x-amz-server-side-encryption"));
			}
			if (responseData.IsHeaderPresent("x-amz-server-side-encryption-customer-algorithm"))
			{
				response.ServerSideEncryptionCustomerMethod = S3Transforms.ToString(responseData.GetHeaderValue("x-amz-server-side-encryption-customer-algorithm"));
			}
			if (responseData.IsHeaderPresent("x-amz-server-side-encryption-customer-key-MD5"))
			{
				response.ServerSideEncryptionCustomerProvidedKeyMD5 = S3Transforms.ToString(responseData.GetHeaderValue("x-amz-server-side-encryption-customer-key-MD5"));
			}
			if (responseData.IsHeaderPresent("ETag"))
			{
				response.ETag = S3Transforms.ToString(responseData.GetHeaderValue("ETag"));
			}
			if (responseData.IsHeaderPresent("x-amz-version-id"))
			{
				response.VersionId = S3Transforms.ToString(responseData.GetHeaderValue("x-amz-version-id"));
			}
			if (responseData.IsHeaderPresent("x-amz-server-side-encryption-aws-kms-key-id"))
			{
				response.ServerSideEncryptionKeyManagementServiceKeyId = S3Transforms.ToString(responseData.GetHeaderValue("x-amz-server-side-encryption-aws-kms-key-id"));
			}
			if (responseData.IsHeaderPresent("x-amz-server-side-encryption-context"))
			{
				response.ServerSideEncryptionKeyManagementServiceEncryptionContext = S3Transforms.ToString(responseData.GetHeaderValue("x-amz-server-side-encryption-context"));
			}
			if (responseData.IsHeaderPresent(S3Constants.AmzHeaderRequestCharged))
			{
				response.RequestCharged = RequestCharged.FindValue(responseData.GetHeaderValue(S3Constants.AmzHeaderRequestCharged));
			}
			if (responseData.IsHeaderPresent(S3Constants.AmzHeaderBucketKeyEnabled))
			{
				response.BucketKeyEnabled = S3Transforms.ToBool(responseData.GetHeaderValue(S3Constants.AmzHeaderBucketKeyEnabled));
			}
			if (responseData.IsHeaderPresent("x-amz-checksum-crc32"))
			{
				response.ChecksumCRC32 = S3Transforms.ToString(responseData.GetHeaderValue("x-amz-checksum-crc32"));
			}
			if (responseData.IsHeaderPresent("x-amz-checksum-crc32c"))
			{
				response.ChecksumCRC32C = S3Transforms.ToString(responseData.GetHeaderValue("x-amz-checksum-crc32c"));
			}
			if (responseData.IsHeaderPresent("x-amz-checksum-crc64nvme"))
			{
				response.ChecksumCRC64NVME = S3Transforms.ToString(responseData.GetHeaderValue("x-amz-checksum-crc64nvme"));
			}
			if (responseData.IsHeaderPresent("x-amz-checksum-sha1"))
			{
				response.ChecksumSHA1 = S3Transforms.ToString(responseData.GetHeaderValue("x-amz-checksum-sha1"));
			}
			if (responseData.IsHeaderPresent("x-amz-checksum-sha256"))
			{
				response.ChecksumSHA256 = S3Transforms.ToString(responseData.GetHeaderValue("x-amz-checksum-sha256"));
			}
			if (responseData.IsHeaderPresent("x-amz-object-size"))
			{
				response.Size = S3Transforms.ToLong(responseData.GetHeaderValue("x-amz-object-size"));
			}
			if (responseData.IsHeaderPresent(S3Constants.AmzHeaderChecksumType))
			{
				response.ChecksumType = context.ResponseData.GetHeaderValue(S3Constants.AmzHeaderChecksumType);
			}
		}

		public override AmazonServiceException UnmarshallException(XmlUnmarshallerContext context, Exception innerException, HttpStatusCode statusCode)
		{
			S3ErrorResponse s3ErrorResponse = S3ErrorResponseUnmarshaller.Instance.Unmarshall(context);
			s3ErrorResponse.InnerException = innerException;
			s3ErrorResponse.StatusCode = statusCode;
			using (MemoryStream responseStream = new MemoryStream(context.GetResponseBodyBytes()))
			{
				using XmlUnmarshallerContext context2 = new XmlUnmarshallerContext(responseStream, maintainResponseBody: false, null);
				if (s3ErrorResponse.Code != null && s3ErrorResponse.Code.Equals("InvalidRequest"))
				{
					return InvalidRequestExceptionUnmarshaller.Instance.Unmarshall(context2, s3ErrorResponse);
				}
				if (s3ErrorResponse.Code != null && s3ErrorResponse.Code.Equals("InvalidWriteOffset"))
				{
					return InvalidWriteOffsetExceptionUnmarshaller.Instance.Unmarshall(context2, s3ErrorResponse);
				}
				if (s3ErrorResponse.Code != null && s3ErrorResponse.Code.Equals("TooManyParts"))
				{
					return TooManyPartsExceptionUnmarshaller.Instance.Unmarshall(context2, s3ErrorResponse);
				}
				if (s3ErrorResponse.Code != null && s3ErrorResponse.Code.Equals("EncryptionTypeMismatch"))
				{
					return EncryptionTypeMismatchExceptionUnmarshaller.Instance.Unmarshall(context2, s3ErrorResponse);
				}
			}
			return ConstructS3Exception(context, s3ErrorResponse, innerException, statusCode);
		}
	}
}
