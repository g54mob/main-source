using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class DeleteBucketRequestMarshaller : IMarshaller<IRequest, DeleteBucketRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static DeleteBucketRequestMarshaller _instance;

		public static DeleteBucketRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new DeleteBucketRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((DeleteBucketRequest)input);
		}

		public IRequest Marshall(DeleteBucketRequest deleteBucketRequest)
		{
			IRequest request = new DefaultRequest(deleteBucketRequest, "AmazonS3");
			request.HttpMethod = "DELETE";
			if (deleteBucketRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(deleteBucketRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(deleteBucketRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "DeleteBucketRequest.BucketName");
			}
			request.ResourcePath = "/";
			if (deleteBucketRequest.BucketRegion != null)
			{
				RegionEndpoint alternateEndpoint = ((deleteBucketRequest.BucketRegion == S3Region.USEast1) ? RegionEndpoint.USEast1 : ((!(deleteBucketRequest.BucketRegion == S3Region.EUWest1)) ? RegionEndpoint.GetBySystemName(deleteBucketRequest.BucketRegion.Value) : RegionEndpoint.EUWest1));
				request.AlternateEndpoint = alternateEndpoint;
			}
			request.UseQueryString = true;
			return request;
		}
	}
}
