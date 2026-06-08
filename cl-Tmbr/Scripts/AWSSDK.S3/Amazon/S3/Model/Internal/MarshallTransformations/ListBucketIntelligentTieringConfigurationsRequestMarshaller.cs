using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class ListBucketIntelligentTieringConfigurationsRequestMarshaller : IMarshaller<IRequest, ListBucketIntelligentTieringConfigurationsRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static ListBucketIntelligentTieringConfigurationsRequestMarshaller _instance;

		public static ListBucketIntelligentTieringConfigurationsRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new ListBucketIntelligentTieringConfigurationsRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((ListBucketIntelligentTieringConfigurationsRequest)input);
		}

		public IRequest Marshall(ListBucketIntelligentTieringConfigurationsRequest listBucketIntelligentTieringConfigurationsRequest)
		{
			IRequest request = new DefaultRequest(listBucketIntelligentTieringConfigurationsRequest, "AmazonS3");
			request.HttpMethod = "GET";
			if (string.IsNullOrEmpty(listBucketIntelligentTieringConfigurationsRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "listBucketIntelligentTieringConfigurationsRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("intelligent-tiering");
			if (listBucketIntelligentTieringConfigurationsRequest.IsSetContinuationToken())
			{
				request.AddSubResource("continuation-token", listBucketIntelligentTieringConfigurationsRequest.ContinuationToken.ToString());
			}
			request.UseQueryString = true;
			return request;
		}
	}
}
