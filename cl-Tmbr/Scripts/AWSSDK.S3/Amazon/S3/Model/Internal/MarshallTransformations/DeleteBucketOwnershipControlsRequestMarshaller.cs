using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class DeleteBucketOwnershipControlsRequestMarshaller : IMarshaller<IRequest, DeleteBucketOwnershipControlsRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static DeleteBucketOwnershipControlsRequestMarshaller _instance;

		public static DeleteBucketOwnershipControlsRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new DeleteBucketOwnershipControlsRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((DeleteBucketOwnershipControlsRequest)input);
		}

		public IRequest Marshall(DeleteBucketOwnershipControlsRequest deleteBucketOwnershipControlsRequest)
		{
			IRequest request = new DefaultRequest(deleteBucketOwnershipControlsRequest, "AmazonS3");
			request.HttpMethod = "DELETE";
			if (string.IsNullOrEmpty(deleteBucketOwnershipControlsRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "DeleteBucketOwnershipControlsRequest.BucketName");
			}
			if (deleteBucketOwnershipControlsRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(deleteBucketOwnershipControlsRequest.ExpectedBucketOwner));
			}
			request.ResourcePath = "/";
			request.AddSubResource("ownershipControls");
			request.UseQueryString = true;
			return request;
		}
	}
}
