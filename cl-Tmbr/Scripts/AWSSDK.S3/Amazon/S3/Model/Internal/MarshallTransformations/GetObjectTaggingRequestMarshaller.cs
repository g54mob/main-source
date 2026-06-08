using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetObjectTaggingRequestMarshaller : IMarshaller<IRequest, GetObjectTaggingRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static GetObjectTaggingRequestMarshaller _instance;

		public static GetObjectTaggingRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GetObjectTaggingRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((GetObjectTaggingRequest)input);
		}

		public IRequest Marshall(GetObjectTaggingRequest getObjectTaggingRequest)
		{
			IRequest request = new DefaultRequest(getObjectTaggingRequest, "AmazonS3");
			request.HttpMethod = "GET";
			if (getObjectTaggingRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(getObjectTaggingRequest.ExpectedBucketOwner));
			}
			if (getObjectTaggingRequest.IsSetRequestPayer())
			{
				request.Headers.Add(S3Constants.AmzHeaderRequestPayer, S3Transforms.ToStringValue(getObjectTaggingRequest.RequestPayer));
			}
			request.UseQueryString = true;
			if (string.IsNullOrEmpty(getObjectTaggingRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "GetObjectTaggingRequest.BucketName");
			}
			if (string.IsNullOrEmpty(getObjectTaggingRequest.Key))
			{
				throw new ArgumentException("Key is a required property and must be set before making this call.", "GetObjectTaggingRequest.Key");
			}
			request.AddPathResource("{Key+}", S3Transforms.ToStringValue(getObjectTaggingRequest.Key));
			request.ResourcePath = "/{Key+}";
			request.AddSubResource("tagging");
			if (getObjectTaggingRequest.IsSetVersionId())
			{
				request.AddSubResource("versionId", getObjectTaggingRequest.VersionId);
			}
			return request;
		}
	}
}
