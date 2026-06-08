using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;
using Amazon.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class ListObjectsRequestMarshaller : IMarshaller<IRequest, ListObjectsRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static ListObjectsRequestMarshaller _instance;

		public static ListObjectsRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new ListObjectsRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((ListObjectsRequest)input);
		}

		public IRequest Marshall(ListObjectsRequest listObjectsRequest)
		{
			IRequest request = new DefaultRequest(listObjectsRequest, "AmazonS3");
			request.HttpMethod = "GET";
			if (listObjectsRequest.IsSetRequestPayer())
			{
				request.Headers.Add(S3Constants.AmzHeaderRequestPayer, S3Transforms.ToStringValue(listObjectsRequest.RequestPayer.ToString()));
			}
			if (listObjectsRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(listObjectsRequest.ExpectedBucketOwner));
			}
			if (listObjectsRequest.IsSetOptionalObjectAttributes())
			{
				request.Headers.Add(S3Constants.AmzOptionalObjectAttributes, AWSSDKUtils.Join(listObjectsRequest.OptionalObjectAttributes));
			}
			if (string.IsNullOrEmpty(listObjectsRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "ListObjectsRequest.BucketName");
			}
			request.ResourcePath = "/";
			if (listObjectsRequest.IsSetDelimiter())
			{
				request.Parameters.Add("delimiter", S3Transforms.ToStringValue(listObjectsRequest.Delimiter));
			}
			if (listObjectsRequest.IsSetMarker())
			{
				request.Parameters.Add("marker", S3Transforms.ToStringValue(listObjectsRequest.Marker));
			}
			if (listObjectsRequest.IsSetMaxKeys())
			{
				request.Parameters.Add("max-keys", S3Transforms.ToStringValue(listObjectsRequest.MaxKeys.Value));
			}
			if (listObjectsRequest.IsSetPrefix())
			{
				request.Parameters.Add("prefix", S3Transforms.ToStringValue(listObjectsRequest.Prefix));
			}
			if (listObjectsRequest.IsSetEncoding())
			{
				request.Parameters.Add("encoding-type", S3Transforms.ToStringValue(listObjectsRequest.Encoding));
			}
			request.UseQueryString = true;
			return request;
		}
	}
}
