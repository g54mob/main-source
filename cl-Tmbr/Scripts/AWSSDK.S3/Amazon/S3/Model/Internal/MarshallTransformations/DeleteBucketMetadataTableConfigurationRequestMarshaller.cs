using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class DeleteBucketMetadataTableConfigurationRequestMarshaller : IMarshaller<IRequest, DeleteBucketMetadataTableConfigurationRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static DeleteBucketMetadataTableConfigurationRequestMarshaller _instance;

		public static DeleteBucketMetadataTableConfigurationRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new DeleteBucketMetadataTableConfigurationRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((DeleteBucketMetadataTableConfigurationRequest)input);
		}

		public IRequest Marshall(DeleteBucketMetadataTableConfigurationRequest createBucketMetadataTableConfigurationRequest)
		{
			IRequest request = new DefaultRequest(createBucketMetadataTableConfigurationRequest, "AmazonS3");
			request.HttpMethod = "DELETE";
			if (createBucketMetadataTableConfigurationRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(createBucketMetadataTableConfigurationRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(createBucketMetadataTableConfigurationRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "DeleteBucketMetadataTableConfigurationRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("metadataTable");
			request.UseQueryString = true;
			return request;
		}
	}
}
