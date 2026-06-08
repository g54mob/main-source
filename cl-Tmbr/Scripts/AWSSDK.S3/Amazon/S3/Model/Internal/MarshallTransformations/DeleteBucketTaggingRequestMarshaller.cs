using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class DeleteBucketTaggingRequestMarshaller : IMarshaller<IRequest, DeleteBucketTaggingRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static DeleteBucketTaggingRequestMarshaller _instance;

		public static DeleteBucketTaggingRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new DeleteBucketTaggingRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((DeleteBucketTaggingRequest)input);
		}

		public IRequest Marshall(DeleteBucketTaggingRequest deleteBucketTaggingRequest)
		{
			IRequest request = new DefaultRequest(deleteBucketTaggingRequest, "AmazonS3");
			request.HttpMethod = "DELETE";
			if (deleteBucketTaggingRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(deleteBucketTaggingRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(deleteBucketTaggingRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "DeleteBucketTaggingRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("tagging");
			request.UseQueryString = true;
			return request;
		}
	}
}
