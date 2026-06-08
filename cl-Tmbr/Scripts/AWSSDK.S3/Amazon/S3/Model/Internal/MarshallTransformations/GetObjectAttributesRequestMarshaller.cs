using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetObjectAttributesRequestMarshaller : IMarshaller<IRequest, GetObjectAttributesRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static GetObjectAttributesRequestMarshaller _instance = new GetObjectAttributesRequestMarshaller();

		public static GetObjectAttributesRequestMarshaller Instance => _instance;

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((GetObjectAttributesRequest)input);
		}

		public IRequest Marshall(GetObjectAttributesRequest publicRequest)
		{
			DefaultRequest defaultRequest = new DefaultRequest(publicRequest, "Amazon.S3");
			defaultRequest.HttpMethod = "GET";
			string resourcePath = "/{Key+}";
			defaultRequest.AddSubResource("attributes");
			if (publicRequest.IsSetExpectedBucketOwner())
			{
				defaultRequest.Headers["x-amz-expected-bucket-owner"] = publicRequest.ExpectedBucketOwner;
			}
			if (publicRequest.IsSetMaxParts())
			{
				defaultRequest.Headers["x-amz-max-parts"] = StringUtils.FromInt(publicRequest.MaxParts);
			}
			if (publicRequest.IsSetObjectAttributes())
			{
				defaultRequest.Headers["x-amz-object-attributes"] = StringUtils.FromList(publicRequest.ObjectAttributes);
			}
			if (publicRequest.IsSetPartNumberMarker())
			{
				defaultRequest.Headers["x-amz-part-number-marker"] = StringUtils.FromInt(publicRequest.PartNumberMarker);
			}
			if (publicRequest.IsSetRequestPayer())
			{
				defaultRequest.Headers["x-amz-request-payer"] = publicRequest.RequestPayer;
			}
			if (publicRequest.IsSetSSECustomerAlgorithm())
			{
				defaultRequest.Headers["x-amz-server-side-encryption-customer-algorithm"] = publicRequest.SSECustomerAlgorithm;
			}
			if (publicRequest.IsSetSSECustomerKey())
			{
				defaultRequest.Headers["x-amz-server-side-encryption-customer-key"] = publicRequest.SSECustomerKey;
			}
			if (publicRequest.IsSetSSECustomerKeyMD5())
			{
				defaultRequest.Headers["x-amz-server-side-encryption-customer-key-MD5"] = publicRequest.SSECustomerKeyMD5;
			}
			if (!publicRequest.IsSetBucketName())
			{
				throw new AmazonS3Exception("Request object does not have required field BucketName set");
			}
			if (!publicRequest.IsSetKey())
			{
				throw new AmazonS3Exception("Request object does not have required field Key set");
			}
			defaultRequest.AddPathResource("{Key+}", S3Transforms.ToStringValue(publicRequest.Key));
			if (publicRequest.IsSetVersionId())
			{
				defaultRequest.Parameters.Add("versionId", StringUtils.FromString(publicRequest.VersionId));
			}
			defaultRequest.ResourcePath = resourcePath;
			defaultRequest.UseQueryString = true;
			return defaultRequest;
		}

		internal static GetObjectAttributesRequestMarshaller GetInstance()
		{
			return _instance;
		}
	}
}
