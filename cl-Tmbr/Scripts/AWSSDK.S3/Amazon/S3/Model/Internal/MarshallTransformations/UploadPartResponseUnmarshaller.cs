using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class UploadPartResponseUnmarshaller : S3ReponseUnmarshaller
	{
		private static UploadPartResponseUnmarshaller _instance;

		public static UploadPartResponseUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new UploadPartResponseUnmarshaller();
				}
				return _instance;
			}
		}

		public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context)
		{
			UploadPartResponse uploadPartResponse = new UploadPartResponse();
			UnmarshallResult(context, uploadPartResponse);
			return uploadPartResponse;
		}

		private static void UnmarshallResult(XmlUnmarshallerContext context, UploadPartResponse response)
		{
			IWebResponseData responseData = context.ResponseData;
			if (responseData.IsHeaderPresent("x-amz-server-side-encryption"))
			{
				response.ServerSideEncryptionMethod = S3Transforms.ToString(responseData.GetHeaderValue("x-amz-server-side-encryption"));
			}
			if (responseData.IsHeaderPresent("ETag"))
			{
				response.ETag = S3Transforms.ToString(responseData.GetHeaderValue("ETag"));
			}
			if (responseData.IsHeaderPresent(S3Constants.AmzHeaderRequestCharged))
			{
				response.RequestCharged = RequestCharged.FindValue(responseData.GetHeaderValue(S3Constants.AmzHeaderRequestCharged));
			}
			if (responseData.IsHeaderPresent(S3Constants.AmzHeaderBucketKeyEnabled))
			{
				response.BucketKeyEnabled = S3Transforms.ToBool(responseData.GetHeaderValue(S3Constants.AmzHeaderBucketKeyEnabled));
			}
			if (context.ResponseData.IsHeaderPresent("x-amz-checksum-crc32"))
			{
				response.ChecksumCRC32 = S3Transforms.ToString(context.ResponseData.GetHeaderValue("x-amz-checksum-crc32"));
			}
			if (context.ResponseData.IsHeaderPresent("x-amz-checksum-crc32c"))
			{
				response.ChecksumCRC32C = S3Transforms.ToString(context.ResponseData.GetHeaderValue("x-amz-checksum-crc32c"));
			}
			if (responseData.IsHeaderPresent("x-amz-checksum-crc64nvme"))
			{
				response.ChecksumCRC64NVME = S3Transforms.ToString(context.ResponseData.GetHeaderValue("x-amz-checksum-crc64nvme"));
			}
			if (context.ResponseData.IsHeaderPresent("x-amz-checksum-sha1"))
			{
				response.ChecksumSHA1 = S3Transforms.ToString(context.ResponseData.GetHeaderValue("x-amz-checksum-sha1"));
			}
			if (context.ResponseData.IsHeaderPresent("x-amz-checksum-sha256"))
			{
				response.ChecksumSHA256 = S3Transforms.ToString(context.ResponseData.GetHeaderValue("x-amz-checksum-sha256"));
			}
		}
	}
}
