using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;
using Amazon.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class ListVersionsRequestMarshaller : IMarshaller<IRequest, ListVersionsRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static ListVersionsRequestMarshaller _instance;

		public static ListVersionsRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new ListVersionsRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((ListVersionsRequest)input);
		}

		public IRequest Marshall(ListVersionsRequest listVersionsRequest)
		{
			IRequest request = new DefaultRequest(listVersionsRequest, "AmazonS3");
			request.HttpMethod = "GET";
			if (listVersionsRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(listVersionsRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(listVersionsRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "ListVersionsRequest.BucketName");
			}
			if (listVersionsRequest.IsSetRequestPayer())
			{
				request.Headers.Add(S3Constants.AmzHeaderRequestPayer, S3Transforms.ToStringValue(listVersionsRequest.RequestPayer));
			}
			if (listVersionsRequest.IsSetOptionalObjectAttributes())
			{
				request.Headers.Add(S3Constants.AmzOptionalObjectAttributes, AWSSDKUtils.Join(listVersionsRequest.OptionalObjectAttributes));
			}
			request.ResourcePath = "/";
			request.AddSubResource("versions");
			if (listVersionsRequest.IsSetDelimiter())
			{
				request.Parameters.Add("delimiter", S3Transforms.ToStringValue(listVersionsRequest.Delimiter));
			}
			if (listVersionsRequest.IsSetKeyMarker())
			{
				request.Parameters.Add("key-marker", S3Transforms.ToStringValue(listVersionsRequest.KeyMarker));
			}
			if (listVersionsRequest.IsSetMaxKeys())
			{
				request.Parameters.Add("max-keys", S3Transforms.ToStringValue(listVersionsRequest.MaxKeys.Value));
			}
			if (listVersionsRequest.IsSetPrefix())
			{
				request.Parameters.Add("prefix", S3Transforms.ToStringValue(listVersionsRequest.Prefix));
			}
			if (listVersionsRequest.IsSetVersionIdMarker())
			{
				request.Parameters.Add("version-id-marker", S3Transforms.ToStringValue(listVersionsRequest.VersionIdMarker));
			}
			if (listVersionsRequest.IsSetEncoding())
			{
				request.Parameters.Add("encoding-type", S3Transforms.ToStringValue(listVersionsRequest.Encoding));
			}
			request.UseQueryString = true;
			return request;
		}
	}
}
