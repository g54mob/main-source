using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class DeleteBucketIntelligentTieringConfigurationRequestMarshaller : IMarshaller<IRequest, DeleteBucketIntelligentTieringConfigurationRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static DeleteBucketIntelligentTieringConfigurationRequestMarshaller _instance;

		public static DeleteBucketIntelligentTieringConfigurationRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new DeleteBucketIntelligentTieringConfigurationRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((DeleteBucketIntelligentTieringConfigurationRequest)input);
		}

		public IRequest Marshall(DeleteBucketIntelligentTieringConfigurationRequest deleteBucketIntelligentTieringConfigurationRequest)
		{
			DefaultRequest obj = new DefaultRequest(deleteBucketIntelligentTieringConfigurationRequest, "AmazonS3")
			{
				HttpMethod = "DELETE"
			};
			if (string.IsNullOrEmpty(deleteBucketIntelligentTieringConfigurationRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "deleteBucketIntelligentTieringConfigurationRequest.BucketName");
			}
			((IRequest)obj).ResourcePath = "/";
			((IRequest)obj).AddSubResource("intelligent-tiering");
			((IRequest)obj).AddSubResource("id", deleteBucketIntelligentTieringConfigurationRequest.IntelligentTieringId);
			((IRequest)obj).UseQueryString = true;
			return obj;
		}
	}
}
