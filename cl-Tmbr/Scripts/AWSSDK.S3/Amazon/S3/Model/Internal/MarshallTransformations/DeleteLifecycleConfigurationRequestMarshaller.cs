using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class DeleteLifecycleConfigurationRequestMarshaller : IMarshaller<IRequest, DeleteLifecycleConfigurationRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static DeleteLifecycleConfigurationRequestMarshaller _instance;

		public static DeleteLifecycleConfigurationRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new DeleteLifecycleConfigurationRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((DeleteLifecycleConfigurationRequest)input);
		}

		public IRequest Marshall(DeleteLifecycleConfigurationRequest deleteLifecycleConfigurationRequest)
		{
			IRequest request = new DefaultRequest(deleteLifecycleConfigurationRequest, "AmazonS3");
			request.HttpMethod = "DELETE";
			if (deleteLifecycleConfigurationRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(deleteLifecycleConfigurationRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(deleteLifecycleConfigurationRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "DeleteLifecycleConfigurationRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("lifecycle");
			request.UseQueryString = true;
			return request;
		}
	}
}
