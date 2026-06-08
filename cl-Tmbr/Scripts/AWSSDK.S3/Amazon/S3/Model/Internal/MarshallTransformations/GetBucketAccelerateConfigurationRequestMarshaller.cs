using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetBucketAccelerateConfigurationRequestMarshaller : IMarshaller<IRequest, GetBucketAccelerateConfigurationRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static GetBucketAccelerateConfigurationRequestMarshaller _instance;

		public static GetBucketAccelerateConfigurationRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GetBucketAccelerateConfigurationRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((GetBucketAccelerateConfigurationRequest)input);
		}

		public IRequest Marshall(GetBucketAccelerateConfigurationRequest getBucketAccelerateRequest)
		{
			IRequest request = new DefaultRequest(getBucketAccelerateRequest, "AmazonS3");
			request.HttpMethod = "GET";
			if (getBucketAccelerateRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(getBucketAccelerateRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(getBucketAccelerateRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "GetBucketAccelerateConfigurationRequest.BucketName");
			}
			if (getBucketAccelerateRequest.IsSetRequestPayer())
			{
				request.Headers.Add(S3Constants.AmzHeaderRequestPayer, S3Transforms.ToStringValue(getBucketAccelerateRequest.RequestPayer));
			}
			request.ResourcePath = "/";
			request.AddSubResource("accelerate");
			request.UseQueryString = true;
			return request;
		}
	}
}
