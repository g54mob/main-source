using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class DeleteObjectTaggingRequestMarshaller : IMarshaller<IRequest, DeleteObjectTaggingRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static DeleteObjectTaggingRequestMarshaller _instance;

		public static DeleteObjectTaggingRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new DeleteObjectTaggingRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((DeleteObjectTaggingRequest)input);
		}

		public IRequest Marshall(DeleteObjectTaggingRequest deleteObjectTaggingRequest)
		{
			IRequest request = new DefaultRequest(deleteObjectTaggingRequest, "AmazonS3");
			request.HttpMethod = "DELETE";
			if (deleteObjectTaggingRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(deleteObjectTaggingRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(deleteObjectTaggingRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "DeleteObjectTaggingRequest.BucketName");
			}
			if (string.IsNullOrEmpty(deleteObjectTaggingRequest.Key))
			{
				throw new ArgumentException("Key is a required property and must be set before making this call.", "DeleteObjectTaggingRequest.Key");
			}
			request.AddPathResource("{Key+}", S3Transforms.ToStringValue(deleteObjectTaggingRequest.Key));
			request.ResourcePath = "/{Key+}";
			request.AddSubResource("tagging");
			if (deleteObjectTaggingRequest.IsSetVersionId())
			{
				request.AddSubResource("versionId", S3Transforms.ToStringValue(deleteObjectTaggingRequest.VersionId));
			}
			return request;
		}
	}
}
