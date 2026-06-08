using System;
using System.IO;
using System.Net;
using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class HeadBucketResponseUnmarshaller : S3ReponseUnmarshaller
	{
		private static HeadBucketResponseUnmarshaller _instance;

		public static HeadBucketResponseUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new HeadBucketResponseUnmarshaller();
				}
				return _instance;
			}
		}

		public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context)
		{
			HeadBucketResponse headBucketResponse = new HeadBucketResponse();
			UnmarshallResult(context, headBucketResponse);
			return headBucketResponse;
		}

		private static void UnmarshallResult(XmlUnmarshallerContext context, HeadBucketResponse response)
		{
			IWebResponseData responseData = context.ResponseData;
			if (responseData.IsHeaderPresent("x-amz-bucket-location-type"))
			{
				response.BucketLocationType = LocationType.FindValue(responseData.GetHeaderValue("x-amz-bucket-location-type"));
			}
			if (responseData.IsHeaderPresent("x-amz-bucket-location-name"))
			{
				response.BucketLocationName = S3Transforms.ToString(responseData.GetHeaderValue("x-amz-bucket-location-name"));
			}
			if (responseData.IsHeaderPresent("x-amz-bucket-region"))
			{
				response.BucketRegion = S3Transforms.ToString(responseData.GetHeaderValue("x-amz-bucket-region"));
			}
			if (responseData.IsHeaderPresent("x-amz-access-point-alias"))
			{
				response.AccessPointAlias = S3Transforms.ToBool(responseData.GetHeaderValue("x-amz-access-point-alias"));
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
				if (s3ErrorResponse.Code != null && s3ErrorResponse.Code.Equals("NoSuchBucket"))
				{
					return NoSuchBucketExceptionUnmarshaller.Instance.Unmarshall(context2, s3ErrorResponse);
				}
			}
			return ConstructS3Exception(context, s3ErrorResponse, innerException, statusCode);
		}
	}
}
