using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class DeleteBucketInventoryConfigurationRequestMarshaller : IMarshaller<IRequest, DeleteBucketInventoryConfigurationRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static DeleteBucketInventoryConfigurationRequestMarshaller _instance;

		public static DeleteBucketInventoryConfigurationRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new DeleteBucketInventoryConfigurationRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((DeleteBucketInventoryConfigurationRequest)input);
		}

		public IRequest Marshall(DeleteBucketInventoryConfigurationRequest deleteInventoryConfigurationRequest)
		{
			IRequest request = new DefaultRequest(deleteInventoryConfigurationRequest, "AmazonS3");
			request.HttpMethod = "DELETE";
			if (deleteInventoryConfigurationRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(deleteInventoryConfigurationRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(deleteInventoryConfigurationRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "DeleteBucketInventoryConfigurationRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("inventory");
			request.AddSubResource("id", deleteInventoryConfigurationRequest.InventoryId);
			request.UseQueryString = true;
			return request;
		}
	}
}
