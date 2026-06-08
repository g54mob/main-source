using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.Util;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetObjectRetentionRequestMarshaller : IMarshaller<IRequest, GetObjectRetentionRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static GetObjectRetentionRequestMarshaller _instance;

		public static GetObjectRetentionRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GetObjectRetentionRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((GetObjectRetentionRequest)input);
		}

		public IRequest Marshall(GetObjectRetentionRequest publicRequest)
		{
			DefaultRequest defaultRequest = new DefaultRequest(publicRequest, "AmazonS3");
			defaultRequest.HttpMethod = "GET";
			defaultRequest.AddSubResource("retention");
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
			defaultRequest.ResourcePath = "/{Key+}";
			defaultRequest.UseQueryString = true;
			return defaultRequest;
		}
	}
}
