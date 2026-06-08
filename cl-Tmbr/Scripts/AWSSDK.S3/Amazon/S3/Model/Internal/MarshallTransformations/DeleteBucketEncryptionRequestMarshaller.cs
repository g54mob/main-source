using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class DeleteBucketEncryptionRequestMarshaller : IMarshaller<IRequest, DeleteBucketEncryptionRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static DeleteBucketEncryptionRequestMarshaller _instance;

		public static DeleteBucketEncryptionRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new DeleteBucketEncryptionRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((DeleteBucketEncryptionRequest)input);
		}

		public IRequest Marshall(DeleteBucketEncryptionRequest deleteBucketEncryptionRequest)
		{
			IRequest request = new DefaultRequest(deleteBucketEncryptionRequest, "AmazonS3");
			request.HttpMethod = "DELETE";
			if (deleteBucketEncryptionRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(deleteBucketEncryptionRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(deleteBucketEncryptionRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "DeleteBucketEncryptionRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("encryption");
			request.UseQueryString = true;
			return request;
		}
	}
}
