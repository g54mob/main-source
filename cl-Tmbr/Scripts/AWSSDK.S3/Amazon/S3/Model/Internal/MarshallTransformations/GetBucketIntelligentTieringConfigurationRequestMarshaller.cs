using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetBucketIntelligentTieringConfigurationRequestMarshaller : IMarshaller<IRequest, GetBucketIntelligentTieringConfigurationRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static GetBucketIntelligentTieringConfigurationRequestMarshaller _instance;

		public static GetBucketIntelligentTieringConfigurationRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GetBucketIntelligentTieringConfigurationRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((GetBucketIntelligentTieringConfigurationRequest)input);
		}

		public IRequest Marshall(GetBucketIntelligentTieringConfigurationRequest getBucketIntelligentTieringConfigurationRequest)
		{
			DefaultRequest obj = new DefaultRequest(getBucketIntelligentTieringConfigurationRequest, "AmazonS3")
			{
				Suppress404Exceptions = true,
				HttpMethod = "GET"
			};
			if (string.IsNullOrEmpty(getBucketIntelligentTieringConfigurationRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "GetBucketInventoryConfigurationRequest.BucketName");
			}
			((IRequest)obj).ResourcePath = "/";
			((IRequest)obj).AddSubResource("intelligent-tiering");
			((IRequest)obj).AddSubResource("id", getBucketIntelligentTieringConfigurationRequest.IntelligentTieringId);
			((IRequest)obj).UseQueryString = true;
			return obj;
		}
	}
}
