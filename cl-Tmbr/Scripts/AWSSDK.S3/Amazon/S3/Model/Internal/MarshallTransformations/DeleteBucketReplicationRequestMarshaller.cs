using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class DeleteBucketReplicationRequestMarshaller : IMarshaller<IRequest, DeleteBucketReplicationRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static DeleteBucketReplicationRequestMarshaller _instance;

		public static DeleteBucketReplicationRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new DeleteBucketReplicationRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((DeleteBucketReplicationRequest)input);
		}

		public IRequest Marshall(DeleteBucketReplicationRequest deleteBucketReplicationRequest)
		{
			IRequest request = new DefaultRequest(deleteBucketReplicationRequest, "AmazonS3");
			request.HttpMethod = "DELETE";
			if (deleteBucketReplicationRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(deleteBucketReplicationRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(deleteBucketReplicationRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "DeleteBucketReplicationRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("replication");
			request.UseQueryString = true;
			return request;
		}
	}
}
