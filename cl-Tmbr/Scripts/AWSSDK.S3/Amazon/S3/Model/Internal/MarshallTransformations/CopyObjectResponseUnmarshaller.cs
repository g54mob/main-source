using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class CopyObjectResponseUnmarshaller : S3ReponseUnmarshaller
	{
		private static CopyObjectResponseUnmarshaller _instance;

		public static CopyObjectResponseUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new CopyObjectResponseUnmarshaller();
				}
				return _instance;
			}
		}

		public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context)
		{
			CopyObjectResponse copyObjectResponse = new CopyObjectResponse();
			while (context.Read())
			{
				if (context.IsStartElement)
				{
					UnmarshallResult(context, copyObjectResponse);
				}
			}
			return copyObjectResponse;
		}

		private static void UnmarshallResult(XmlUnmarshallerContext context, CopyObjectResponse response)
		{
			int currentDepth = context.CurrentDepth;
			int num = currentDepth + 1;
			if (context.IsStartOfDocument)
			{
				num += 2;
			}
			while (context.Read())
			{
				if (context.IsStartElement || context.IsAttribute)
				{
					if (context.TestExpression("ETag", num))
					{
						response.ETag = StringUnmarshaller.GetInstance().Unmarshall(context);
					}
					else if (context.TestExpression("LastModified", num))
					{
						response.LastModified = StringUnmarshaller.GetInstance().Unmarshall(context);
					}
					else if (context.TestExpression("ChecksumCRC32", num))
					{
						response.ChecksumCRC32 = StringUnmarshaller.GetInstance().Unmarshall(context);
					}
					else if (context.TestExpression("ChecksumCRC32C", num))
					{
						response.ChecksumCRC32C = StringUnmarshaller.GetInstance().Unmarshall(context);
					}
					else if (context.TestExpression("ChecksumCRC64NVME", num))
					{
						response.ChecksumCRC64NVME = StringUnmarshaller.GetInstance().Unmarshall(context);
					}
					else if (context.TestExpression("ChecksumSHA1", num))
					{
						response.ChecksumSHA1 = StringUnmarshaller.GetInstance().Unmarshall(context);
					}
					else if (context.TestExpression("ChecksumSHA256", num))
					{
						response.ChecksumSHA256 = StringUnmarshaller.GetInstance().Unmarshall(context);
					}
					else if (context.TestExpression("ChecksumType", num))
					{
						response.ChecksumType = StringUnmarshaller.GetInstance().Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return;
				}
			}
			IWebResponseData responseData = context.ResponseData;
			if (responseData.IsHeaderPresent("x-amz-expiration"))
			{
				response.Expiration = new Expiration(responseData.GetHeaderValue("x-amz-expiration"));
			}
			if (responseData.IsHeaderPresent("x-amz-copy-source-version-id"))
			{
				response.SourceVersionId = S3Transforms.ToString(responseData.GetHeaderValue("x-amz-copy-source-version-id"));
			}
			if (responseData.IsHeaderPresent("x-amz-version-id"))
			{
				response.VersionId = S3Transforms.ToString(responseData.GetHeaderValue("x-amz-version-id"));
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
		}
	}
}
