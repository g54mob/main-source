using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetBucketOwnershipControlsRequestMarshaller : IMarshaller<IRequest, GetBucketOwnershipControlsRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static GetBucketOwnershipControlsRequestMarshaller _instance;

		public static GetBucketOwnershipControlsRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GetBucketOwnershipControlsRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((GetBucketOwnershipControlsRequest)input);
		}

		public IRequest Marshall(GetBucketOwnershipControlsRequest getBucketOwnershipControlsRequest)
		{
			IRequest request = new DefaultRequest(getBucketOwnershipControlsRequest, "AmazonS3");
			request.HttpMethod = "GET";
			if (string.IsNullOrEmpty(getBucketOwnershipControlsRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "GetBucketOwnershipControlsRequest.BucketName");
			}
			if (getBucketOwnershipControlsRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(getBucketOwnershipControlsRequest.ExpectedBucketOwner));
			}
			request.ResourcePath = "/";
			request.AddSubResource("ownershipControls");
			request.UseQueryString = true;
			return request;
		}
	}
}
