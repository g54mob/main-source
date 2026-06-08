using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class ListDirectoryBucketsResponseUnmarshaller : S3ReponseUnmarshaller
	{
		private static ListDirectoryBucketsResponseUnmarshaller _instance = new ListDirectoryBucketsResponseUnmarshaller();

		public static ListDirectoryBucketsResponseUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new ListDirectoryBucketsResponseUnmarshaller();
				}
				return _instance;
			}
		}

		public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context)
		{
			ListDirectoryBucketsResponse listDirectoryBucketsResponse = new ListDirectoryBucketsResponse();
			UnmarshallResult(context, listDirectoryBucketsResponse);
			return listDirectoryBucketsResponse;
		}

		private static void UnmarshallResult(XmlUnmarshallerContext context, ListDirectoryBucketsResponse response)
		{
			int currentDepth = context.CurrentDepth;
			int num = currentDepth + 1;
			if (context.IsStartOfDocument)
			{
				num++;
			}
			while (context.Read())
			{
				if (context.IsStartElement || context.IsAttribute)
				{
					if (context.TestExpression("Buckets/Bucket", num))
					{
						if (response.Buckets == null)
						{
							response.Buckets = new List<S3Bucket>();
						}
						BucketUnmarshaller instance = BucketUnmarshaller.Instance;
						response.Buckets.Add(instance.Unmarshall(context));
					}
					else if (context.TestExpression("ContinuationToken", num))
					{
						StringUnmarshaller instance2 = StringUnmarshaller.Instance;
						response.ContinuationToken = instance2.Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					break;
				}
			}
		}

		public override AmazonServiceException UnmarshallException(XmlUnmarshallerContext context, Exception innerException, HttpStatusCode statusCode)
		{
			ErrorResponse errorResponse = XmlErrorResponseUnmarshaller.GetInstance().Unmarshall(context);
			errorResponse.InnerException = innerException;
			errorResponse.StatusCode = statusCode;
			using (MemoryStream responseStream = new MemoryStream(context.GetResponseBodyBytes()))
			{
				using (new XmlUnmarshallerContext(responseStream, maintainResponseBody: false, null))
				{
				}
			}
			return new AmazonS3Exception(errorResponse.Message, innerException, errorResponse.Type, errorResponse.Code, errorResponse.RequestId, statusCode);
		}

		internal static ListDirectoryBucketsResponseUnmarshaller GetInstance()
		{
			return _instance;
		}
	}
}
