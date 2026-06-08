using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class CopyPartResponseUnmarshaller : S3ReponseUnmarshaller
	{
		private static CopyPartResponseUnmarshaller _instance;

		public static CopyPartResponseUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new CopyPartResponseUnmarshaller();
				}
				return _instance;
			}
		}

		public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context)
		{
			CopyPartResponse copyPartResponse = new CopyPartResponse();
			while (context.Read())
			{
				if (context.IsStartElement)
				{
					UnmarshallResult(context, copyPartResponse);
				}
			}
			return copyPartResponse;
		}

		private static void UnmarshallResult(XmlUnmarshallerContext context, CopyPartResponse response)
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
					if (context.TestExpression("ChecksumCRC32", num))
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
					else if (context.TestExpression("ETag", num))
					{
						response.ETag = StringUnmarshaller.GetInstance().Unmarshall(context);
					}
					else if (context.TestExpression("LastModified", num))
					{
						response.LastModified = DateTimeUnmarshaller.GetInstance().Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return;
				}
			}
			IWebResponseData responseData = context.ResponseData;
			if (responseData.IsHeaderPresent("x-amz-copy-source-version-id"))
			{
				response.CopySourceVersionId = S3Transforms.ToString(responseData.GetHeaderValue("x-amz-copy-source-version-id"));
			}
			if (responseData.IsHeaderPresent("x-amz-server-side-encryption"))
			{
				response.ServerSideEncryptionMethod = S3Transforms.ToString(responseData.GetHeaderValue("x-amz-server-side-encryption"));
			}
			if (responseData.IsHeaderPresent("x-amz-server-side-encryption-aws-kms-key-id"))
			{
				response.ServerSideEncryptionKeyManagementServiceKeyId = S3Transforms.ToString(responseData.GetHeaderValue("x-amz-server-side-encryption-aws-kms-key-id"));
			}
			if (responseData.IsHeaderPresent(S3Constants.AmzHeaderBucketKeyEnabled))
			{
				response.BucketKeyEnabled = S3Transforms.ToBool(responseData.GetHeaderValue(S3Constants.AmzHeaderBucketKeyEnabled));
			}
		}
	}
}
