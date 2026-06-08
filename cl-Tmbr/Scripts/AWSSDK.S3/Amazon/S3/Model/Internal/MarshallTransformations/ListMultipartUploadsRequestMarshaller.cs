using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class ListMultipartUploadsRequestMarshaller : IMarshaller<IRequest, ListMultipartUploadsRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static ListMultipartUploadsRequestMarshaller _instance;

		public static ListMultipartUploadsRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new ListMultipartUploadsRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((ListMultipartUploadsRequest)input);
		}

		public IRequest Marshall(ListMultipartUploadsRequest listMultipartUploadsRequest)
		{
			IRequest request = new DefaultRequest(listMultipartUploadsRequest, "AmazonS3");
			request.HttpMethod = "GET";
			if (listMultipartUploadsRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(listMultipartUploadsRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(listMultipartUploadsRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "ListMultipartUploadsRequest.BucketName");
			}
			if (listMultipartUploadsRequest.IsSetRequestPayer())
			{
				request.Headers.Add(S3Constants.AmzHeaderRequestPayer, S3Transforms.ToStringValue(listMultipartUploadsRequest.RequestPayer));
			}
			request.ResourcePath = "/";
			request.AddSubResource("uploads");
			if (listMultipartUploadsRequest.IsSetDelimiter())
			{
				request.Parameters.Add("delimiter", S3Transforms.ToStringValue(listMultipartUploadsRequest.Delimiter));
			}
			if (listMultipartUploadsRequest.IsSetKeyMarker())
			{
				request.Parameters.Add("key-marker", S3Transforms.ToStringValue(listMultipartUploadsRequest.KeyMarker));
			}
			if (listMultipartUploadsRequest.IsSetMaxUploads())
			{
				request.Parameters.Add("max-uploads", S3Transforms.ToStringValue(listMultipartUploadsRequest.MaxUploads.Value));
			}
			if (listMultipartUploadsRequest.IsSetPrefix())
			{
				request.Parameters.Add("prefix", S3Transforms.ToStringValue(listMultipartUploadsRequest.Prefix));
			}
			if (listMultipartUploadsRequest.IsSetUploadIdMarker())
			{
				request.Parameters.Add("upload-id-marker", S3Transforms.ToStringValue(listMultipartUploadsRequest.UploadIdMarker));
			}
			if (listMultipartUploadsRequest.IsSetEncoding())
			{
				request.Parameters.Add("encoding-type", S3Transforms.ToStringValue(listMultipartUploadsRequest.Encoding));
			}
			request.UseQueryString = true;
			return request;
		}
	}
}
