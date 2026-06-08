using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetBucketInventoryConfigurationRequestMarshaller : IMarshaller<IRequest, GetBucketInventoryConfigurationRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static GetBucketInventoryConfigurationRequestMarshaller _instance;

		public static GetBucketInventoryConfigurationRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GetBucketInventoryConfigurationRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((GetBucketInventoryConfigurationRequest)input);
		}

		public IRequest Marshall(GetBucketInventoryConfigurationRequest getInventoryConfigurationRequest)
		{
			IRequest request = new DefaultRequest(getInventoryConfigurationRequest, "AmazonS3");
			request.Suppress404Exceptions = true;
			request.HttpMethod = "GET";
			if (getInventoryConfigurationRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(getInventoryConfigurationRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(getInventoryConfigurationRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "GetBucketInventoryConfigurationRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("inventory");
			request.AddSubResource("id", getInventoryConfigurationRequest.InventoryId);
			request.UseQueryString = true;
			return request;
		}
	}
}
