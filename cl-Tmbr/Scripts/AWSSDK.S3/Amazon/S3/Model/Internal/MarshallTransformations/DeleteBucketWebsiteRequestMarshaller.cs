using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class DeleteBucketWebsiteRequestMarshaller : IMarshaller<IRequest, DeleteBucketWebsiteRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static DeleteBucketWebsiteRequestMarshaller _instance;

		public static DeleteBucketWebsiteRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new DeleteBucketWebsiteRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((DeleteBucketWebsiteRequest)input);
		}

		public IRequest Marshall(DeleteBucketWebsiteRequest deleteBucketWebsiteRequest)
		{
			IRequest request = new DefaultRequest(deleteBucketWebsiteRequest, "AmazonS3");
			request.HttpMethod = "DELETE";
			if (deleteBucketWebsiteRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(deleteBucketWebsiteRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(deleteBucketWebsiteRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "DeleteBucketWebsiteRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("website");
			request.UseQueryString = true;
			return request;
		}
	}
}
