using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class ListPartsRequestMarshaller : IMarshaller<IRequest, ListPartsRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static ListPartsRequestMarshaller _instance;

		public static ListPartsRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new ListPartsRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((ListPartsRequest)input);
		}

		public IRequest Marshall(ListPartsRequest listPartsRequest)
		{
			IRequest request = new DefaultRequest(listPartsRequest, "AmazonS3");
			if (listPartsRequest.IsSetRequestPayer())
			{
				request.Headers.Add(S3Constants.AmzHeaderRequestPayer, S3Transforms.ToStringValue(listPartsRequest.RequestPayer.ToString()));
			}
			if (listPartsRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(listPartsRequest.ExpectedBucketOwner));
			}
			request.HttpMethod = "GET";
			if (string.IsNullOrEmpty(listPartsRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "ListPartsRequest.BucketName");
			}
			if (string.IsNullOrEmpty(listPartsRequest.Key))
			{
				throw new ArgumentException("Key is a required property and must be set before making this call.", "ListPartsRequest.Key");
			}
			request.AddPathResource("{Key+}", S3Transforms.ToStringValue(listPartsRequest.Key));
			request.ResourcePath = "/{Key+}";
			if (listPartsRequest.IsSetUploadId())
			{
				request.AddSubResource("uploadId", S3Transforms.ToStringValue(listPartsRequest.UploadId));
			}
			if (listPartsRequest.IsSetMaxParts())
			{
				request.Parameters.Add("max-parts", S3Transforms.ToStringValue(listPartsRequest.MaxParts.Value));
			}
			if (listPartsRequest.IsSetPartNumberMarker())
			{
				request.Parameters.Add("part-number-marker", S3Transforms.ToStringValue(listPartsRequest.PartNumberMarker));
			}
			if (listPartsRequest.IsSetEncoding())
			{
				request.Parameters.Add("encoding-type", S3Transforms.ToStringValue(listPartsRequest.Encoding));
			}
			if (listPartsRequest.IsSetSSECustomerAlgorithm())
			{
				request.Headers["x-amz-server-side-encryption-customer-algorithm"] = S3Transforms.ToStringValue(listPartsRequest.SSECustomerAlgorithm);
			}
			if (listPartsRequest.IsSetSSECustomerKey())
			{
				request.Headers["x-amz-server-side-encryption-customer-key"] = S3Transforms.ToStringValue(listPartsRequest.SSECustomerKey);
			}
			if (listPartsRequest.IsSetSSECustomerKeyMD5())
			{
				request.Headers["x-amz-server-side-encryption-customer-key-MD5"] = S3Transforms.ToStringValue(listPartsRequest.SSECustomerKeyMD5);
			}
			request.UseQueryString = true;
			return request;
		}
	}
}
