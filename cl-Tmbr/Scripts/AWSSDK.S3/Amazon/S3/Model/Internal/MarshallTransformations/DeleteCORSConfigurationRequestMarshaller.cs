using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class DeleteCORSConfigurationRequestMarshaller : IMarshaller<IRequest, DeleteCORSConfigurationRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static DeleteCORSConfigurationRequestMarshaller _instance;

		public static DeleteCORSConfigurationRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new DeleteCORSConfigurationRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((DeleteCORSConfigurationRequest)input);
		}

		public IRequest Marshall(DeleteCORSConfigurationRequest deleteCORSConfigurationRequest)
		{
			IRequest request = new DefaultRequest(deleteCORSConfigurationRequest, "AmazonS3");
			request.HttpMethod = "DELETE";
			if (deleteCORSConfigurationRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(deleteCORSConfigurationRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(deleteCORSConfigurationRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "DeleteCORSConfigurationRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("cors");
			request.UseQueryString = true;
			return request;
		}
	}
}
