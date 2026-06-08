using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class DeletePublicAccessBlockRequestMarshaller : IMarshaller<IRequest, DeletePublicAccessBlockRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static DeletePublicAccessBlockRequestMarshaller _instance;

		public static DeletePublicAccessBlockRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new DeletePublicAccessBlockRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((DeletePublicAccessBlockRequest)input);
		}

		public IRequest Marshall(DeletePublicAccessBlockRequest deletePublicAccessBlockRequest)
		{
			IRequest request = new DefaultRequest(deletePublicAccessBlockRequest, "AmazonS3");
			request.HttpMethod = "DELETE";
			if (deletePublicAccessBlockRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(deletePublicAccessBlockRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(deletePublicAccessBlockRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "deletePublicAccessBlockRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("publicAccessBlock");
			request.UseQueryString = true;
			return request;
		}
	}
}
