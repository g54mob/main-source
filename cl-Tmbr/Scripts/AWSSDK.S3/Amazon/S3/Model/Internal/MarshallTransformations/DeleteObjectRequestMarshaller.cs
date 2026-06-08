using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class DeleteObjectRequestMarshaller : IMarshaller<IRequest, DeleteObjectRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static DeleteObjectRequestMarshaller _instance;

		public static DeleteObjectRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new DeleteObjectRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((DeleteObjectRequest)input);
		}

		public IRequest Marshall(DeleteObjectRequest deleteObjectRequest)
		{
			IRequest request = new DefaultRequest(deleteObjectRequest, "AmazonS3");
			request.HttpMethod = "DELETE";
			if (deleteObjectRequest.IsSetBypassGovernanceRetention())
			{
				request.Headers.Add("x-amz-bypass-governance-retention", S3Transforms.ToStringValue(deleteObjectRequest.BypassGovernanceRetention.Value));
			}
			if (deleteObjectRequest.IsSetMfaCodes())
			{
				request.Headers.Add("x-amz-mfa", deleteObjectRequest.MfaCodes.FormattedMfaCodes);
			}
			if (deleteObjectRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(deleteObjectRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(deleteObjectRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "DeleteObjectRequest.BucketName");
			}
			if (string.IsNullOrEmpty(deleteObjectRequest.Key))
			{
				throw new ArgumentException("Key is a required property and must be set before making this call.", "DeleteObjectRequest.Key");
			}
			request.AddPathResource("{Key+}", S3Transforms.ToStringValue(deleteObjectRequest.Key));
			request.ResourcePath = "/{Key+}";
			if (deleteObjectRequest.IsSetVersionId())
			{
				request.AddSubResource("versionId", S3Transforms.ToStringValue(deleteObjectRequest.VersionId));
			}
			if (deleteObjectRequest.IsSetRequestPayer())
			{
				request.Headers.Add(S3Constants.AmzHeaderRequestPayer, S3Transforms.ToStringValue(deleteObjectRequest.RequestPayer.ToString()));
			}
			request.UseQueryString = true;
			if (deleteObjectRequest.IsSetIfMatch())
			{
				request.Headers.Add("If-Match", S3Transforms.ToStringValue(deleteObjectRequest.IfMatch));
			}
			if (deleteObjectRequest.IsSetIfMatchLastModifiedTime())
			{
				request.Headers.Add(S3Constants.AmzHeaderIfMatchLastModifiedTime, S3Transforms.ToStringValue(deleteObjectRequest.IfMatchLastModifiedTime.Value));
			}
			if (deleteObjectRequest.IsSetIfMatchSize())
			{
				request.Headers.Add(S3Constants.AmzHeaderIfMatchSize, S3Transforms.ToStringValue(deleteObjectRequest.IfMatchSize));
			}
			return request;
		}
	}
}
