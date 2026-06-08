using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetBucketReplicationRequestMarshaller : IMarshaller<IRequest, GetBucketReplicationRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static GetBucketReplicationRequestMarshaller _instance;

		public static GetBucketReplicationRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GetBucketReplicationRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((GetBucketReplicationRequest)input);
		}

		public IRequest Marshall(GetBucketReplicationRequest getBucketReplicationConfigurationRequest)
		{
			IRequest request = new DefaultRequest(getBucketReplicationConfigurationRequest, "AmazonS3");
			request.Suppress404Exceptions = true;
			request.HttpMethod = "GET";
			if (getBucketReplicationConfigurationRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(getBucketReplicationConfigurationRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(getBucketReplicationConfigurationRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "GetBucketReplicationRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("replication");
			request.UseQueryString = true;
			return request;
		}
	}
}
