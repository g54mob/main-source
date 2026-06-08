using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetBucketMetadataTableConfigurationRequestMarshaller : IMarshaller<IRequest, GetBucketMetadataTableConfigurationRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static GetBucketMetadataTableConfigurationRequestMarshaller _instance;

		public static GetBucketMetadataTableConfigurationRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GetBucketMetadataTableConfigurationRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((GetBucketMetadataTableConfigurationRequest)input);
		}

		public IRequest Marshall(GetBucketMetadataTableConfigurationRequest createBucketMetadataTableConfigurationRequest)
		{
			IRequest request = new DefaultRequest(createBucketMetadataTableConfigurationRequest, "AmazonS3");
			request.HttpMethod = "GET";
			if (createBucketMetadataTableConfigurationRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(createBucketMetadataTableConfigurationRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(createBucketMetadataTableConfigurationRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "GetBucketMetadataTableConfigurationRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("metadataTable");
			request.UseQueryString = true;
			return request;
		}
	}
}
