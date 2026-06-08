using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.Util;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetObjectLegalHoldRequestMarshaller : IMarshaller<IRequest, GetObjectLegalHoldRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static GetObjectLegalHoldRequestMarshaller _instance;

		public static GetObjectLegalHoldRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GetObjectLegalHoldRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((GetObjectLegalHoldRequest)input);
		}

		public IRequest Marshall(GetObjectLegalHoldRequest publicRequest)
		{
			DefaultRequest defaultRequest = new DefaultRequest(publicRequest, "AmazonS3");
			defaultRequest.HttpMethod = "GET";
			string resourcePath = "/{Key+}";
			defaultRequest.AddSubResource("legal-hold");
			if (publicRequest.IsSetRequestPayer())
			{
				defaultRequest.Headers.Add(S3Constants.AmzHeaderRequestPayer, S3Transforms.ToStringValue(publicRequest.RequestPayer.ToString()));
			}
			if (publicRequest.IsSetExpectedBucketOwner())
			{
				defaultRequest.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(publicRequest.ExpectedBucketOwner));
			}
			if (!publicRequest.IsSetBucketName())
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "publicRequest.BucketName");
			}
			if (!publicRequest.IsSetKey())
			{
				throw new ArgumentException("Key is a required property and must be set before making this call.", "publicRequest.Key");
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
	}
}
